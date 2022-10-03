#include <iostream>

int main()
{
	unsigned char enc_buf[35] = {
		0x50, 0x5E, 0x5E, 0xA3, 0x4F, 0x5B, 0x51, 0x5E, 0x5E, 0x97, 0xA3, 0x80,
		0x90, 0xA3, 0x80, 0x90, 0xA3, 0x80, 0x90, 0xA3, 0x80, 0x90, 0xA3, 0x80,
		0x90, 0xA3, 0x80, 0x90, 0xA3, 0x80, 0x90, 0xA2, 0xA3, 0x6B, 0x7F
	};

	for (size_t i = 0; i < 35; i++) {
		unsigned char val = enc_buf[i];
		unsigned char t = 0xc3 - val;
		printf("%c", t);
	}
};
