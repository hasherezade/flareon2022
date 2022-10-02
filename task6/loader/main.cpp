#include <Windows.h>

#include <iostream>
#include <string>
#include <sstream>

int (__cdecl* to_decode_strings1)(const BYTE* lpString2, DWORD* str_size) = nullptr;
int (__cdecl* decode_string)(char* in_str, char* out_str) = nullptr;
int main()
{
    HMODULE lib = LoadLibraryA("HDW1.dll");
    if (!lib) {
        std::cout << "Loading failed!\n";
        return -1;
    }


    BYTE buf[] = { 0x3E, 0x39, 0x51, 0xFB, 0xA2, 0x11, 0xF7, 0xB9, 0x2C, 0x00 };
    size_t offset = 0x1000;
    DWORD out_size = 0;
    to_decode_strings1 = (int(__cdecl * )(const BYTE*, DWORD * ))((ULONG_PTR)lib + offset);
    decode_string = (int(__cdecl * )(char*, char* ))((ULONG_PTR)lib + 0x14ae);

    char out_str[100];
    memset(out_str, 0, 100);

    char rawData[21] = {
        0x56, 0x62, 0x63, 0x7F, 0x78, 0x65, 0x7E, 0x6D, 0x76, 0x63, 0x7E, 0x78,
        0x79, 0x37, 0x51, 0x76, 0x7E, 0x7B, 0x72, 0x73, 0x00
    };

    decode_string(rawData, out_str);
    std::cout << out_str << std::endl;
    std::cout << "to_decode_strings1"<< std::endl;
    to_decode_strings1(buf, &out_size);
    std::cout << "out_size: "<< std::hex << out_size << std::endl;
    return 0;
}
