using System;
using System.IO;
using System.IO.Compression;

namespace FlareOn.Backdoor
{
	// Token: 0x02000006 RID: 6
	public class FLARE04
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00002D84 File Offset: 0x00009D84
		public static byte[] flared_17(byte[] d)
		{
			bool flag = d == null || d.Length < 1;
			byte[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				byte[] array2;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress, true))
					{
						deflateStream.Write(d, 0, d.Length);
						deflateStream.Close();
						byte[] array = new byte[memoryStream.Length];
						memoryStream.Seek(0L, SeekOrigin.Begin);
						memoryStream.Read(array, 0, (int)memoryStream.Length);
						array2 = array;
					}
				}
				result = array2;
			}
			return result;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002E3C File Offset: 0x00009E3C
		public static byte[] flare_18(byte[] d)
		{
			byte[] result;
			try
			{
				result = FLARE04.flared_17(d);
			}
			catch (InvalidProgramException e)
			{
				result = (byte[])FLARE15.flare_70(e, new object[]
				{
					d
				});
			}
			return result;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002E80 File Offset: 0x00009E80
		public static byte[] flared_18(byte[] d)
		{
			bool flag = d == null || d.Length < 1;
			byte[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				byte[] array2;
				using (MemoryStream memoryStream = new MemoryStream(d))
				{
					using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
					{
						using (MemoryStream memoryStream2 = new MemoryStream())
						{
							byte[] array = new byte[16384];
							int count;
							while ((count = deflateStream.Read(array, 0, array.Length)) > 0)
							{
								memoryStream2.Write(array, 0, count);
							}
							array2 = memoryStream2.ToArray();
						}
					}
				}
				result = array2;
			}
			return result;
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002F5C File Offset: 0x00009F5C
		public static byte[] flare_19(byte[] d)
		{
			byte[] result;
			try
			{
				result = FLARE04.flared_18(d);
			}
			catch (InvalidProgramException e)
			{
				result = (byte[])FLARE15.flare_70(e, new object[]
				{
					d
				});
			}
			return result;
		}
	}
}
