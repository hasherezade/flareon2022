using System;

namespace FlareOn.Backdoor
{
	// Token: 0x02000020 RID: 32
	public class FLARE12
	{
		// Token: 0x0600007F RID: 127 RVA: 0x00004574 File Offset: 0x0000B574
		public static byte[] _RC4(byte[] p, byte[] d)
		{
			int[] array = new int[256];
			int[] array2 = new int[256];
			byte[] array3 = new byte[d.Length];
			int i;
			for (i = 0; i < 256; i++)
			{
				array[i] = (int)p[i % p.Length];
				array2[i] = i;
			}
			int num;
			for (i = (num = 0); i < 256; i++)
			{
				num = (num + array2[i] + array[i]) % 256;
				int num2 = array2[i];
				array2[i] = array2[num];
				array2[num] = num2;
			}
			int num3;
			num = (num3 = (i = 0));
			while (i < d.Length)
			{
				num3++;
				num3 %= 256;
				num += array2[num3];
				num %= 256;
				int num2 = array2[num3];
				array2[num3] = array2[num];
				array2[num] = num2;
				int num4 = array2[(array2[num3] + array2[num]) % 256];
				array3[i] = (byte)((int)d[i] ^ num4);
				i++;
			}
			return array3;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000467C File Offset: 0x0000B67C
		public static byte[] RC4(byte[] p, byte[] d)
		{
			byte[] result;
			try
			{
				result = FLARE12._RC4(p, d);
			}
			catch (InvalidProgramException e)
			{
				result = (byte[])Util.flare_71(e, new object[]
				{
					p,
					d
				}, Util.d_m, Util.d_b);
			}
			return result;
		}
	}
}
