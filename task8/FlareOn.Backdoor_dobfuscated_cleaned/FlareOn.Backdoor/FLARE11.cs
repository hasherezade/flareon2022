using System;
using System.Security.Cryptography;

namespace FlareOn.Backdoor
{
	// Token: 0x0200001F RID: 31
	public class FLARE11
	{
		// Token: 0x06000074 RID: 116 RVA: 0x000041C8 File Offset: 0x0000B1C8
		public static void flared_42(uint s = 5489U)
		{
			FLARE11.state = new uint[624];
			FLARE11.f = 1812433253U;
			FLARE11.m = 397U;
			FLARE11.u = 11U;
			FLARE11.s = 7U;
			FLARE11.b = 2636928640U;
			FLARE11.t = 15U;
			FLARE11.c = 4022730752U;
			FLARE11.l = 18U;
			FLARE11.index = 624U;
			FLARE11.lower_mask = 2147483647U;
			FLARE11.upper_mask = 2147483648U;
			FLARE11.state[0] = s;
			bool flag = TaskClass.CommandsAndMethods == null;
			if (flag)
			{
				TaskClass.CommandsAndMethods = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
				Util.c.CollectionChanged += TaskClass.ToMaybeWriteFlagToFile;
			}
			for (int i = 1; i < 624; i++)
			{
				FLARE11.state[i] = FLARE11.flare_45((long)((ulong)(FLARE11.f * (FLARE11.state[i - 1] ^ FLARE11.state[i - 1] >> 30)) + (ulong)((long)i)));
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000042C4 File Offset: 0x0000B2C4
		public static void flare_41(uint s = 5489U)
		{
			try
			{
				FLARE11.flared_42(s);
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, new object[]
				{
					s
				});
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004308 File Offset: 0x0000B308
		public static void flared_43()
		{
			for (uint num = 0U; num < 624U; num += 1U)
			{
				uint num2 = FLARE11.flare_45((long)((ulong)((FLARE11.state[(int)num] & FLARE11.upper_mask) + (FLARE11.state[(int)((num + 1U) % 624U)] & FLARE11.lower_mask))));
				uint num3 = num2 >> 1;
				bool flag = num2 % 2U > 0U;
				if (flag)
				{
					num3 = FLARE11.flare_45((long)((ulong)(num3 ^ 2567483615U)));
				}
				FLARE11.state[(int)num] = (FLARE11.state[(int)((num + FLARE11.m) % 624U)] ^ num3);
			}
			FLARE11.index = 0U;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00004398 File Offset: 0x0000B398
		public static void flare_42()
		{
			try
			{
				FLARE11.flared_43();
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, null);
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000043D0 File Offset: 0x0000B3D0
		public static uint flared_44()
		{
			bool flag = FLARE11.index >= 624U;
			if (flag)
			{
				FLARE11.flare_42();
			}
			uint num = FLARE11.state[(int)FLARE11.index];
			num ^= num >> (int)FLARE11.u;
			num ^= (num << (int)FLARE11.s & FLARE11.b);
			num ^= (num << (int)FLARE11.t & FLARE11.c);
			num ^= num >> (int)FLARE11.l;
			FLARE11.index += 1U;
			return FLARE11.flare_45((long)((ulong)num));
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000445C File Offset: 0x0000B45C
		public static uint flare_43()
		{
			uint result;
			try
			{
				result = FLARE11.flared_44();
			}
			catch (InvalidProgramException e)
			{
				result = (uint)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00004498 File Offset: 0x0000B498
		public static int flared_45(int mn, int mx)
		{
			int num = mx - mn;
			uint num2 = FLARE11.flare_43();
			return (int)((long)mn + (long)((ulong)num2 % (ulong)((long)num)));
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000044C0 File Offset: 0x0000B4C0
		public static int flare_44(int mn, int mx)
		{
			int result;
			try
			{
				result = FLARE11.flared_45(mn, mx);
			}
			catch (InvalidProgramException e)
			{
				result = (int)Util.flare_70(e, new object[]
				{
					mn,
					mx
				});
			}
			return result;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00004514 File Offset: 0x0000B514
		public static uint flared_46(long n)
		{
			return Convert.ToUInt32(n);
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000452C File Offset: 0x0000B52C
		public static uint flare_45(long n)
		{
			uint result;
			try
			{
				result = FLARE11.flared_46(n);
			}
			catch (InvalidProgramException e)
			{
				result = (uint)Util.flare_70(e, new object[]
				{
					n
				});
			}
			return result;
		}

		// Token: 0x04000117 RID: 279
		public static uint[] state;

		// Token: 0x04000118 RID: 280
		public static uint f;

		// Token: 0x04000119 RID: 281
		public static uint m;

		// Token: 0x0400011A RID: 282
		public static uint u;

		// Token: 0x0400011B RID: 283
		public static uint s;

		// Token: 0x0400011C RID: 284
		public static uint b;

		// Token: 0x0400011D RID: 285
		public static uint t;

		// Token: 0x0400011E RID: 286
		public static uint c;

		// Token: 0x0400011F RID: 287
		public static uint l;

		// Token: 0x04000120 RID: 288
		public static uint index;

		// Token: 0x04000121 RID: 289
		public static uint lower_mask;

		// Token: 0x04000122 RID: 290
		public static uint upper_mask;
	}
}
