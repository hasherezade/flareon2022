#include <Windows.h>
#include <iostream>

#include <fstream>
#include <sstream>
#include <string>
#include <iostream>

#include <vector>
#include <map>


#include "string_util.h"
#include "rewrite_states.h"


bool insert_val_info(const std::string& infile, const std::string& outfile)
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

        const std::string  rand_val = "Math.floor(my_random() * 256)";
        size_t pos1 = line.find(rand_val);
        if (pos1 == std::string::npos) {
            ofile << line << std::endl;     //rewrite line as is
            continue;
        }

        std::stringstream ss;
        ss << "val_";
        ss << rand_id++;
        std::string val_id = ss.str();

        ofile << "\tvar "<< val_id << " = " << rand_val << ";" << std::endl;
        ofile << "\tdocument.write(\"" << val_id << " = \" + " << val_id<< " + \"" << " <br/>\");" << std::endl;
        line.replace(pos1, rand_val.length(), val_id);
        ofile << line << std::endl;
    }
    file.close();
    ofile.close();
    return true;
}

bool replace_vals(const std::string& infile, const std::string& outfile, std::map<std::string, std::string>& val_list)
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

        if (line.find("Math.floor(my_random() * 256)") != std::string::npos) {
            ofile << "\tmy_random();" << std::endl;
            continue;
        }
        if (line.find("document.write(\"val_") != std::string::npos) {
            //ofile << line << std::endl;
            continue;
        }
        size_t pos1 = line.find("val_");
        if (pos1 == std::string::npos) {
            ofile << line << std::endl;
            continue;
        }
        size_t pos2 = line.find(")");
        if (pos2 == std::string::npos) {
            pos2 = line.find(";");
        }
        size_t diff = pos2 - pos1;
        std::string curr_val = line.substr(pos1, diff);
        std::cout << "Curr Val: [" << curr_val  << "]"<< std::endl;
        if (val_list.find(curr_val) != val_list.end()) {
            std::cout << "\t = [" <<val_list[curr_val] << "]" << std::endl;
            line.replace(pos1, diff, val_list[curr_val]);
            ofile << line << std::endl;
        }
    }
    file.close();
    ofile.close();
    return true;
}

bool load_resolved_vals_map(const std::string& infile, std::map<std::string, std::string>& val_list)
{
    std::ifstream file(infile);
    if (!file.is_open()) {
        std::cerr << "[ERROR] Opening the " << infile << " file failed!\n";
        return false;
    }

    std::string line;
    for (size_t line_count = 0; std::getline(file, line); line_count++) {
        const std::string separator = " = ";
        size_t pos1 = line.find(separator);
        std::string token = line.substr(0, pos1);
        std::string value = line.substr(pos1 + separator.length());
        val_list[token] = value;
    }
    file.close();
    if (val_list.size()) {
        return true;
    }
    return false;
}

int main(int argc, char* argv[])
{
    if (argc < 3) {
        std::cout << "Params missing!\n";
        system("pause");
        return 0;
    }
    /*
    if (!insert_rand_info(argv[1], argv[2])) {
        std::cerr << "Failed!\n";
    }
    */

    //insert_val_info(argv[1], argv[2]);
    std::map<std::string, std::string> val_list;

    if (!load_resolved_vals_map("vals_list.txt", val_list)) {
        std::cout << "Loading failed!\n";
        return -1;
    }

    /*for (auto itr = val_list.begin(); itr != val_list.end(); ++itr) {
        std::cout << "[" << itr->first << "] = [" << itr->second << "]" << std::endl;
    } */
    replace_vals(argv[1], argv[2], val_list);
    return 1;
}
