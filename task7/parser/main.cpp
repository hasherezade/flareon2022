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

bool rewrite_backwards(const std::string& infile, const std::string& outfile)
{
    std::vector<std::string> all_lines;
    std::ifstream file(infile);
    if (!file.is_open()) {
        std::cerr << "[ERROR] Opening the " << infile << " file failed!\n";
        return false;
    }

    const std::string add_token = " += ";
    const std::string sub_token = " -= ";

    std::string line;
    for (size_t line_count = 0; std::getline(file, line); line_count++) {

        size_t pos1 = line.find(add_token);
        if (pos1 != std::string::npos) {
            //std::cout << "Add Found in: " <<  line << "\n";
            line.replace(pos1, add_token.length(), sub_token);
            all_lines.push_back(line);
            //std::cout << "Replaced: " << line << "\n";
            continue;
        }
        pos1 = line.find(sub_token);
        if (pos1 != std::string::npos) {
            //std::cout << "Sub Found in : " << line << "\n";
            line.replace(pos1, sub_token.length(), add_token);
            all_lines.push_back(line);
            //std::cout << "Replaced: " << line << "\n";
            continue;
        }

        all_lines.push_back(line);
    }
    file.close();
    std::cout << "Processed, lines: " << all_lines.size() << std::endl;
    
    std::ofstream ofile(outfile);
    if (!ofile.is_open()) {
        std::cerr << "[ERROR] Opening the output file failed!\n";
        return false;
    }
    for (size_t i = all_lines.size(); i != 0; i-- ) {
        std::string line1 = all_lines[i -1];
        ofile << line1 << std::endl;
    }
    ofile.close();
    std::cout << "Done!\n";
    return true;
}


int main(int argc, char* argv[])
{
    if (argc < 3) {
        std::cout << "Params missing!\n";
        system("pause");
        return 0;
    }

    rewrite_backwards(argv[1], argv[2]);
    return 1;
}
