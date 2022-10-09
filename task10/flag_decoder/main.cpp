#include <Windows.h>
#include <iostream>
#include <stdio.h>


unsigned char g_EncFlag[] = {
	0x2D, 0x0C, 0x00, 0x1D, 0x1A, 0x7F, 0x17, 0x1C, 0x4E, 0x02, 0x11, 0x28,
	0x08, 0x10, 0x48, 0x05, 0x00, 0x00, 0x1A, 0x7F, 0x2A, 0xF6, 0x17, 0x44,
	0x32, 0x0F, 0xFC, 0x1A, 0x60, 0x2C, 0x08, 0x10, 0x1C, 0x60, 0x02, 0x19,
	0x41, 0x17, 0x11, 0x5A, 0x0E, 0x1D, 0x0E, 0x39, 0x0A, 0x04, 0x27, 0x18
};

struct buf {
    BYTE size;
    BYTE buf[1];
};

typedef unsigned int uint;
typedef unsigned short ushort;


void decoding_func(byte* param_1, byte* param_2, byte* param_3)
{
    uint uVar1;
    ushort uVar2;
    ushort uVar3;
    ushort uVar4;

    uVar1 = 0;
    uVar4 = 1;
    //output will have the same length as input:
    *param_3 = *param_1;
    while (true) {
        uVar2 = (ushort)uVar1;
        uVar3 = uVar2 + 1;
        uVar1 = (uint)uVar3;
        if (*param_1 <= uVar2) break;
        uVar2 = uVar4;
        if (*param_2 < uVar4) {
            uVar2 = (ushort)(*param_2 != 0);
        }
        uVar4 = uVar2 + 1;
        param_3[uVar3] = param_2[uVar2] ^ param_1[uVar1];
    }
    //CRC16(param_3);
    return;
}

void hexdump(BYTE* buf, size_t size)
{
    for (int i = 0; i < size; i++) {
        printf("%02X ", buf[i]);
    }
    printf("\n");
}

int main(int argc, char *argv[])
{
    char input[100] = { 0 };
    buf* inp_buf = (buf*)input;

    char demo_str[] = "AAA";
    inp_buf->size = strlen(demo_str);
    ::memcpy(inp_buf->buf, demo_str, inp_buf->size);

    if (argc > 1) {
        size_t len = strlen(argv[1]);
        inp_buf->size = len;
        ::memcpy(inp_buf->buf, argv[1], len);
    }

    std::cout << "Input: " << inp_buf->buf << "\n";
    unsigned char outBuf[100] = { 0 };
    buf* out_buf = (buf*)outBuf;
    decoding_func(g_EncFlag, (BYTE*)inp_buf, outBuf);
    hexdump(outBuf, sizeof(outBuf));
    printf("%s\n", out_buf->buf);
    return 0;
}

