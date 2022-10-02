#include "clean_not_followed.h"

#include <Windows.h>
#include <iostream>

#include <fstream>
#include <sstream>
#include <string>
#include <iostream>

#include <vector>
#include <set>

bool insert_rand_info(const std::string& infile, const std::string& outfile)
{
    std::ifstream file(infile);
    if (!file.is_open()) {
        std::cerr << "[ERROR] Opening the input file failed!\n";
        return false;
    }
    std::ofstream ofile(outfile);
    if (!ofile.is_open()) {
        std::cerr << "[ERROR] Opening the output file failed!\n";
        return false;
    }

    std::cout << "Opened file: " << infile << std::endl;
    std::string line;
    int rand_id = 0;
    for (size_t line_count = 0; std::getline(file, line); line_count++) {
        ofile << line << std::endl;
        if (line.find("if (my_random() < 0.5) {") != std::string::npos) {
            ofile << "\tdocument.write(\"ok_" << rand_id++ << " <br/>\");" << std::endl;
        }
    }
    file.close();
    ofile.close();
    return true;
}

bool load_followed_rand_map(const std::string& infile, std::set<std::string>& followed_list)
{
    std::ifstream file(infile);
    if (!file.is_open()) {
        std::cerr << "[ERROR] Opening the " << infile << " file failed!\n";
        return false;
    }

    std::string line;
    for (size_t line_count = 0; std::getline(file, line); line_count++) {
        followed_list.insert(line);
        std::cout << "[" << line << "]" << std::endl;
    }
    file.close();
    if (followed_list.size()) {
        return true;
    }
    return false;
}

bool clean_not_followed(const std::string& infile, const std::string& outfile, std::set<std::string>& followed_list)
{
    std::ifstream file(infile);
    if (!file.is_open()) {
        std::cerr << "[ERROR] Opening the input file failed!\n";
        return false;
    }
    std::ofstream ofile(outfile);
    if (!ofile.is_open()) {
        std::cerr << "[ERROR] Opening the output file failed!\n";
        return false;
    }

    std::cout << "Opened file: " << infile << std::endl;
    std::string line;
    int rand_id = 0;
    bool in_rand = false;
    bool is_followed = false;
    bool is_else = false;
    for (size_t line_count = 0; std::getline(file, line); line_count++) {

        if (line.find("if (my_random() < 0.5) {") != std::string::npos) {
            in_rand = true;
            is_else = false;
            continue;
        }
        if (line.find("state =") != std::string::npos) {
            in_rand = false;
            is_followed = false;
            is_else = false;
            ofile << line << std::endl;
            continue;
        }
        if (!in_rand) {
            ofile << line << std::endl;
            continue;
        }
        size_t pos1 = line.find("ok_");
        if (pos1 != std::string::npos) {
            size_t pos2 = line.find(" ");
            size_t diff = pos2 - pos1;
            std::string token = line.substr(pos1, diff);

            if (followed_list.find(token) != followed_list.end()) {
                is_followed = true;
            }
            else {
                is_followed = false;
            }
            ofile << "\tmy_random();" << std::endl;
            std::cout << "Token: [" << token << "]";
            if (is_followed) {
                std::cout << " Followed";
            }
            std::cout << "\n";
            continue;
        }

        if (line.find("} else {") != std::string::npos) {
            is_else = true;
            continue;
        }
        if (line.find("}") != std::string::npos) {
            //end 
            continue;
        }

        if (is_followed && !is_else) {
            ofile << line << std::endl;
        }
        if (!is_followed && is_else) {
            ofile << line << std::endl;
        }
    }
    file.close();
    ofile.close();
    return true;
}

bool clean_not_followed_rand(const std::string& infile, const std::string& outfile)
{
    std::set<std::string> followed_list;
    if (!load_followed_rand_map("list_ok.txt", followed_list)) {
        return false;
    }
    return clean_not_followed(infile, outfile, followed_list);
}
