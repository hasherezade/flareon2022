#include <windows.h>
#include <detours.h>
#include <iostream>
#include <sstream>


#include <windows.h>
#include <detours.h>
#include <iostream>

#include <stdio.h>

#pragma comment(lib, "ws2_32.lib")

VOID(WINAPI* pSleep)(
    DWORD dwMilliseconds
    ) = ::Sleep;

auto pGethostbyname = reinterpret_cast<decltype(&gethostbyname)>(gethostbyname);
auto pSleepEx = reinterpret_cast<decltype(&SleepEx)>(::SleepEx);

VOID
WINAPI
my_Sleep(
    _In_ DWORD dwMilliseconds
)
{
    OutputDebugStringA("FlareOn: Sleep");
    std::cout << "Sleeping: " << dwMilliseconds << std::endl;
}

DWORD
WINAPI
my_SleepEx(
    _In_ DWORD dwMilliseconds,
    _In_ BOOL bAlertable
)
{
    OutputDebugStringA("FlareOn: SleepEx");
    std::cout << "SleepingEx: " << dwMilliseconds << std::endl;
    return 0;
}


hostent* WINAPI my_gethostbyname(char* name)
{
    static char resolved_chunks[][4] = {
    {200,0,0,1}, {199,0,0,2}, {43,50,0,0}, {199,0,0,3}, {43,49,48,0}, {199,0,0,2}, {43,56,0,0}, {199,0,0,3}, {43,49,57,0}, \
    {199,0,0,3}, {43,49,49,0}, {199,0,0,2}, {43,49,0,0}, {199,0,0,3}, {43,49,53,0}, {199,0,0,3}, {43,49,51,0}, {199,0,0,3}, \
    {43,50,50,0}, {199,0,0,3}, {43,49,54,0}, {199,0,0,2}, {43,53,0,0}, {199,0,0,3}, {43,49,50,0}, {199,0,0,3}, {43,50,49,0}, \
    {199,0,0,2}, {43,51,0,0}, {199,0,0,3}, {43,49,56,0}, {199,0,0,3}, {43,49,55,0}, {199,0,0,3}, {43,50,48,0}, {199,0,0,3}, \
    {43,49,52,0}, {199,0,0,2}, {43,57,0,0}, {199,0,0,2}, {43,55,0,0}, {199,0,0,2}, {43,52,0,0}
    };
    static size_t res_indx = 0;
    static size_t max = _countof(resolved_chunks);

    OutputDebugStringA(name);
    std::cout << "DNS: " << name << std::endl;
    hostent *out = pGethostbyname(name);
    if (out) {
        char* host = out->h_addr_list[0];
        char* valid_ip = resolved_chunks[res_indx % max];  
        res_indx++;
        ::memcpy(host, valid_ip, 4);
        std::cout << "IP: " << (int)host[0] << "." << (int)host[1] << "." << (int)host[2] << "." << (int)host[3] << std::endl;
    }
    else {
        std::cout << "Failed to resolve!\n";
    }
    return out;
}

void hook_apis()
{
    DetourTransactionBegin();
    DetourUpdateThread(GetCurrentThread());
    DetourAttach(&(PVOID&)pSleep, my_Sleep);
    DetourAttach(&(PVOID&)pSleepEx, my_SleepEx);
    DetourAttach(&(PVOID&)pGethostbyname, my_gethostbyname);
    DetourTransactionCommit();
}

BOOL WINAPI DllMain(HANDLE hinstDLL, DWORD fdwReason, LPVOID lpvReserved)
{
    switch (fdwReason)
    {
    case DLL_PROCESS_ATTACH:
        OutputDebugStringA("Hooking the process");
        hook_apis();
        break;
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
        break;
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
