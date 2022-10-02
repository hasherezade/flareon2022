#include <iostream>
#include <string>
#include <sstream>

#include "rc4.h"
#include "md5.h"
#include "base64.h"

std::wstring make_key(int num)
{
    std::wstringstream ss;
    ss << L"FO9";
    ss << num;

    std::wstring data_str = ss.str();

    //std::wcout << "Key:" << data_str << "\n";
    const wchar_t* data = data_str.c_str();
    size_t data_size = data_str.length() * 2;

    MD5 md5;
    md5.update((unsigned char*)data, data_size);
    md5.finalize();
    std::string s = md5.hexdigest();
    std::wstring wsTmp(s.begin(), s.end());
    return wsTmp;
}


void crack_random_key1()
{
    srand(time(NULL));

    while (true) {

        int rand_num = rand();

        std::wstring key_str = make_key(rand_num);
        //std::wcout << "KeyMD5:"<< key_str << std::endl;

        const wchar_t* key = key_str.c_str();
        size_t key_size = key_str.length() * 2;

        std::wstring data_str = L"ahoy";
        const wchar_t* data = data_str.c_str();
        size_t data_size = data_str.length() * 2;

        struct rc4_state* s = (struct rc4_state*)malloc(sizeof(struct rc4_state));

        rc4_setup(s, (unsigned char*)key, key_size);
        rc4_crypt(s, (unsigned char*)data, data_size);

        std::string b64str = base64_encode((unsigned char*)data, data_size);

        if (b64str == "ydN8BXq16RE=")
        {
            std::wcout << "Num: " << rand_num << std::endl;
            std::cout << "Encrypted: " << b64str << std::endl;
            std::wcout << "Found key: " << key_str << std::endl;
            break;
        }
    }
}

int main()
{
    crack_random_key1();
    return 0;
}
