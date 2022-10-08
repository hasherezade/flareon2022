#include <windows.h>
#include <iostream>

#include <detours.h> // include MS Detours header
#include <peconv.h> // include libPeConv header

int64_t(*_p_init_stuff)() = nullptr;
int64_t(__fastcall* _p_maybe_mul)(int64_t* out_buf, uint64_t* rand_buf1_ptr, uint64_t* rand_buf2) = nullptr;
char (__fastcall *_p_calculate_d)(DWORD* a1, DWORD* a2, int64_t* rsa_euler) = nullptr; //0x1b46

int64_t(__fastcall *_p_protect_by_assymetric_crypt)(
    DWORD* key_out_buf,
    const void* key,
    const void* RSA_private,
    int64_t* RSA_n) = nullptr; //0x16cc

size_t g_PESize = 0;
BYTE *g_PEBuf = NULL;

FILE* g_Log = NULL;

int64_t my_init_stuff()
{
    std::cout << "[+] Initializing random keys...\n";
    int64_t ret = _p_init_stuff();
    std::cout << "[+] Keys initialized, val: " << ret << "\n";
    return ret;
}


int64_t __fastcall print_in_hex_to_file(FILE* Stream, int64_t* a2)
{
    int64_t result; // rax
    int64_t i; // rbx
    int64_t v6; // r8

    result = 0i64;
    for (i = 0i64; i != -17; --i)
    {
        v6 = a2[i + 16];
        if ((DWORD)result || v6)
        {
            fprintf(Stream, "%016llx", v6);
            fflush(g_Log);
            result = 1i64;
        }
    }
    fprintf(Stream, "\n");
    fflush(g_Log);
    return result;
}

int64_t __fastcall my_maybe_mul(int64_t* out_buf, uint64_t* rand_buf1_ptr, uint64_t* rand_buf2)
{
    std::cout << __FUNCTION__ << std::endl;

    fprintf(g_Log, "Val1 =\n");
    print_in_hex_to_file(g_Log, (int64_t*)rand_buf1_ptr);

    fprintf(g_Log, "Val2 =\n");
    print_in_hex_to_file(g_Log, (int64_t*)rand_buf2);

    int64_t ret = _p_maybe_mul(out_buf, rand_buf1_ptr, rand_buf2);

    fprintf(g_Log, "Val1 * Val2 =\n");
    print_in_hex_to_file(g_Log, (int64_t*)out_buf);
    fprintf(g_Log, "\n");
    return ret;
}

char __fastcall my_calculate_d(DWORD* a1, DWORD* a2, int64_t* rsa_euler)
{
    std::cout << __FUNCTION__ << std::endl;
    char ret = _p_calculate_d(a1, a2, rsa_euler);

    fprintf(g_Log, "PHI=\n");
    print_in_hex_to_file(g_Log, (int64_t*)rsa_euler);

    fprintf(g_Log, "D=\n");
    print_in_hex_to_file(g_Log, (int64_t*)a2);
    fprintf(g_Log, "\n");
    return ret;
}

int64_t __fastcall my_protect_by_assymetric_crypt(
    DWORD* key_out_buf,
    const void* key,
    const void* RSA_private,
    int64_t* RSA_n)
{

    fprintf(g_Log, "Inp=\n");
    print_in_hex_to_file(g_Log, (int64_t*)key);
    fprintf(g_Log, "\n");

    int64_t ret = _p_protect_by_assymetric_crypt(key_out_buf, key, RSA_private, RSA_n);

    fprintf(g_Log, "Priv=\n");
    print_in_hex_to_file(g_Log, (int64_t*)RSA_private);
    fprintf(g_Log, "\n");

    fprintf(g_Log, "N=\n");
    print_in_hex_to_file(g_Log, (int64_t*)RSA_n);
    fprintf(g_Log, "\n");

    fprintf(g_Log, "Protected =\n");
    print_in_hex_to_file(g_Log, (int64_t*)key_out_buf);
    fprintf(g_Log, "\n");
    return ret;
}

//-----

void init_function_ptrs()
{
    _p_init_stuff = (int64_t(*)())((ULONG_PTR)g_PEBuf + 0x21d0);
    _p_maybe_mul = (int64_t(__fastcall * )(int64_t * out_buf, uint64_t * rand_buf1_ptr, uint64_t * rand_buf2)) ((ULONG_PTR)g_PEBuf + 0x1550);
    _p_calculate_d = (char(__fastcall*)(DWORD * a1, DWORD * a2, int64_t * rsa_euler))((ULONG_PTR)g_PEBuf + 0x1b46);

    _p_protect_by_assymetric_crypt = (int64_t(__fastcall*)(
        DWORD * key_out_buf,
        const void* key,
        const void* RSA_private,
        int64_t * RSA_n)) ((ULONG_PTR)g_PEBuf + 0x16cc);

    std::cout << "Function pointeres initialized\n";
}

void hook_apis()
{
    //initialize hooking:
    DetourTransactionBegin();
    DetourUpdateThread(GetCurrentThread());

    // the APIs that we want to hook:
    DetourAttach(&(PVOID&)_p_init_stuff, my_init_stuff);
    DetourAttach(&(PVOID&)_p_maybe_mul, my_maybe_mul);
    DetourAttach(&(PVOID&)_p_calculate_d, my_calculate_d);
    DetourAttach(&(PVOID&)_p_protect_by_assymetric_crypt, my_protect_by_assymetric_crypt);

    //finalize hooking:
    DetourTransactionCommit();

    std::cout << "APIs hooked!\n";
}

BYTE* load_pe(const LPCSTR pe_path)
{
    // manually load the PE file using libPeConv:
    size_t v_size = 0;
#ifdef LOAD_FROM_PATH
    //if the PE is dropped on the disk, you can load it from the file:
    BYTE* my_pe = peconv::load_pe_executable(pe_path, v_size);
#else
    size_t bufsize = 0;
    BYTE *buffer = peconv::load_file(pe_path, bufsize);

    // if the file is NOT dropped on the disk, you can load it directly from a memory buffer:
    BYTE* my_pe = peconv::load_pe_executable(buffer, bufsize, v_size);
#endif
    if (!my_pe) {
        return NULL;
    }
    
    // set the loaded PE in the global variables:
    g_PESize = v_size;
    g_PEBuf = my_pe;

    // if the loaded PE needs to access resources, you may need to connect it to the PEB:
    peconv::set_main_module_in_peb((HMODULE)my_pe);
    return g_PEBuf;
}

int run_pe_entrypoint(BYTE *my_pe)
{
    //calculate the Entry Point of the manually loaded module
    DWORD ep_rva = peconv::get_entry_point_rva(my_pe);
    if (!ep_rva) {
        return -2;
    }
    ULONG_PTR ep_va = ep_rva + (ULONG_PTR)my_pe;
    //assuming that the payload is an EXE file (not DLL) this will be the simplest prototype of the main:
    int(*new_main)() = (int(*)())ep_va;
    //call the Entry Point of the manually loaded PE:
    return new_main();
}

int main(int argc, char *argv[])
{
    const LPCSTR pe_path = "C:\\Users\\tester\\Desktop\\flareon.exe";// argv[1];

    // manually load an EXE with libPEConv:
    if (!load_pe(pe_path)) {
        std::cout << "[-] Loading the PE: "<< pe_path << " failed!\n";
        return -1;
    }
    std::cout << "Loaded!\n";
    init_function_ptrs();

    hook_apis();

    system("del *.Encrypted"); //clean previous

    // run the manually loaded EXE:
    int res = run_pe_entrypoint(g_PEBuf);
    system("pause");

    return 0;
}
