﻿#include <Windows.h>
#include <iostream>

#include <fstream>
#include <sstream>
#include <string>
#include <iostream>

#include <vector>
#include <map>

#include "string_util.h"

bool has_token(std::vector<std::string>& tokens, const std::string& token)
{
    std::vector<std::string>::iterator itr;
    for (itr = tokens.begin(); itr != tokens.end(); itr++) {
        if (*itr == token) {
            return true;
        }
    }
    return false;
}

std::string get_constant(std::map<std::string, std::string>& consts_lines, std::vector<std::string>& tokens_line)
{
    std::map<std::string, std::string>::iterator itr;
    for (itr = consts_lines.begin(); itr != consts_lines.end(); itr++) {
        std::string const_name = itr->first;
        if (has_token(tokens_line, const_name)) {
            return const_name;
        }
    }
    return "";
}

std::vector<std::string> split_to_tokens(std::string orig_line)
{
    const char to_replace[] = { '\t', ',' };
    std::string line = orig_line;
    for (size_t i = 0; i < _countof(to_replace); i++) {
        replace_char(line, to_replace[i], ' ');
    }

    std::vector<std::string> tokens = split_by_delimiter(line, ' ');

    //post-process tokens
    std::vector<std::string>::iterator itr;
    for (itr = tokens.begin(); itr != tokens.end(); itr++) {
        std::string& token = *itr;
        remove_prefix(token, "FLAT:");
    }
    return tokens;
}

bool is_case_end(std::string& line)
{
    if (line.find("break;") != std::string::npos) {
        return true;
    }
    if (line.find("continue;") != std::string::npos) {
        return true;
    }
    return false;
}

int fetch_case_number(std::string &line)
{
    const std::string case_str = "case ";
    std::size_t case_found = line.find(case_str);
    if (case_found == std::string::npos) {
        return 0;
    }
    std::size_t dot_found = line.find(":");
    if (dot_found == std::string::npos) {
        return 0;
    }
    size_t case_end = case_found + case_str.length();
    size_t len = dot_found - case_end;
    std::string number_str = line.substr(case_end, len);
    //std::cout << "New case found: " << line << "\n";

    int number = 0;
    std::stringstream ss;
    ss << number_str;
    ss >> number;
    return number;
}

bool load_states_map(const std::string& infile, std::map<int, int> &num_to_case)
{
    std::ifstream file(infile);
    if (!file.is_open()) {
        std::cerr << "[ERROR] Opening the states file failed!\n";
        return false;
    }

    std::string line;
    for (size_t line_count = 0; std::getline(file, line); line_count++) {
        int case_num = 0;
        std::stringstream iss1;
        iss1 << std::dec << line;
        iss1 >> case_num; //read the expected size
        //std::cout << line_count << " : " << case_num << "\n";
        num_to_case[line_count] = case_num;
    }
    file.close();
    if (num_to_case.size()) {
        return true;
    }
    return false;
}

bool process_file(const std::string& infile, std::map<int, std::string> &cases)
{
    std::ifstream file(infile);
    if (!file.is_open()) {
        std::cerr << "[ERROR] Opening the input file failed!\n";
        return false;
    }

    std::string seg_name = "";
    std::string const_name = "";
    bool code_start = false;

    int current_case = 0;
    std::string line;
    for (size_t line_count = 0; std::getline(file, line); line_count++) {

        int number = fetch_case_number(line);
        if (number != 0) {
            //ofile << "\nNUM: [" << number << "]\n";
            current_case = number;
            continue;
        }
        if (is_case_end(line)) {
            current_case = 0;
            continue;
        }
        if (line.find("state = ") != std::string::npos) {
            continue;
        }
        if (line.find("//}") != std::string::npos) {
            continue;
        }
        cases[current_case] += line + "\n";
    }
    file.close();

    if (cases.size()) {
        return true;
    }
    return false;
}

bool process_cases(const std::string &infile, const std::string &outfile, std::map<int, int> &num_to_case)
{
    std::map<int, std::string> cases;
    if (!process_file(infile, cases)) {
        return false;
    }

    std::ofstream ofile(outfile);
    if (!ofile.is_open()) {
        std::cerr << "[ERROR] Opening the output file failed!\n";
        return false;
    }
    
    size_t i = 0;
    for (auto itr = num_to_case.begin(); itr != num_to_case.end(); ++itr) {
        int case_num = itr->second;
        ofile << "\tvalidate_arr(b, " << i++ << ");" << std::endl;
        //ofile << case_num << " :\n";
        ofile << cases[case_num] << std::endl;
    }
    ofile.close();

    return true;
}

int main(int argc, char* argv[])
{
    if (argc < 3) {
        std::cout << "Params missing!\n";
        system("pause");
        return 0;
    }

    std::map<int, int> num_to_case;
    if (!load_states_map("states.txt", num_to_case)) {
        std::cerr << "Couln't load the states\n";
        return -2;
    }

    if (process_cases(argv[1], argv[2], num_to_case)) {
        return 0;
    }
    return 1;
}
