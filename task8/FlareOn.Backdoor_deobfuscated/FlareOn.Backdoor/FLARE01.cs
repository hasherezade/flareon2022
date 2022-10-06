using System;

namespace FlareOn.Backdoor
{
	// Token: 0x02000002 RID: 2
	public class FLARE01
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002194 File Offset: 0x00009194
		public static string flared_00(byte[] i)
		{
			bool flag = i == null || i.Length == 0;
			if (flag)
			{
				throw new ArgumentNullException("input");
			}
			int num = (int)Math.Ceiling((double)i.Length / 5.0) * 8;
			char[] array = new char[num];
			byte b = 0;
			byte b2 = 5;
			int num2 = 0;
			foreach (byte b3 in i)
			{
				b = (byte)((int)b | b3 >> (int)(8 - b2));
				array[num2++] = FLARE01.flare_02(b);
				bool flag2 = b2 < 4;
				if (flag2)
				{
					b = (byte)(b3 >> (int)(3 - b2) & 31);
					array[num2++] = FLARE01.flare_02(b);
					b2 += 5;
				}
				b2 -= 3;
				b = (byte)((int)b3 << (int)b2 & 31);
			}
			bool flag3 = num2 != num;
			if (flag3)
			{
				array[num2++] = FLARE01.flare_02(b);
			}
			return new string(array).Replace("\0", "");
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000229C File Offset: 0x0000929C
		public static string flare_01(byte[] i)
		{
			string result;
			try
			{
				result = FLARE01.flared_00(i);
			}
			catch (InvalidProgramException e)
			{
				result = (string)FLARE15.flare_70(e, new object[]
				{
					i
				});
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000022E0 File Offset: 0x000092E0
		public static char flared_01(byte b)
		{
			bool flag = b < 26;
			char result;
			if (flag)
			{
				result = (char)(b + 97);
			}
			else
			{
				bool flag2 = b < 32;
				if (!flag2)
				{
					throw new ArgumentException("Byte is not a value Base32 value.", "b");
				}
				result = (char)(b + 24);
			}
			return result;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002324 File Offset: 0x00009324
		public static char flare_02(byte b)
		{
			char result;
			try
			{
				result = FLARE01.flared_01(b);
			}
			catch (InvalidProgramException e)
			{
				result = (char)FLARE15.flare_70(e, new object[]
				{
					b
				});
			}
			return result;
		}
	}
}
