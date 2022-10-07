using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace FlareOn.Backdoor
{
	// Token: 0x02000007 RID: 7
	public class DnsClass
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00002FA0 File Offset: 0x00009FA0
		public static MachineCommand _Alive()
		{
			MachineCommand ret = MachineCommand.Failed;
			bool flag = Config._GetAgentId() != null || DnsClass._TryMe(new Func<bool>(DnsClass._FirstAlive));
			if (flag)
			{
				DnsClass._TryMe(() => DnsClass.MainAlive(out ret));
			}
			return ret;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00003000 File Offset: 0x0000A000
		public static MachineCommand Alive()
		{
			MachineCommand result;
			try
			{
				result = DnsClass._Alive();
			}
			catch (InvalidProgramException e)
			{
				result = (MachineCommand)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000303C File Offset: 0x0000A03C
		public static MachineCommand _Receive()
		{
			MachineCommand ret = MachineCommand.Failed;
			Func<bool> fn = null;
			for (;;)
			{
				bool flag;
				if (DnsClass._ReceiveByteIndex < DnsClass._ReceiveDataSize)
				{
					if (fn == null)
					{
						fn =  (() => DnsClass._makeReceive(out ret));
					}
					flag = DnsClass._TryMe(fn);
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					break;
				}
				Util.MakeDelay(Enums.DelayType.dtCommunicate);
			}
			Console.WriteLine(string.Format("Receive : {0}", ret));
			return ret;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000030A4 File Offset: 0x0000A0A4
		public static MachineCommand Receive()
		{
			MachineCommand result;
			try
			{
				result = DnsClass._Receive();
			}
			catch (InvalidProgramException e)
			{
				result = (MachineCommand)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000030E0 File Offset: 0x0000A0E0
		public static MachineCommand CheckingDomainsInLoop()
		{
			MachineCommand ret = MachineCommand.Failed;
			Func<bool> fn = null;
			for (;;)
			{
				if (DnsClass.G >= DnsClass.F)
				{
					goto to_break2;
				}
				
				if (fn == null)
				{
					fn = (() => DnsClass._QueryDomainMakeTwoChecks(out ret));
				}
				if (!DnsClass._TryMe(fn))
				{
					goto to_break2;
				}
				bool flag = ret == MachineCommand.Failed;
				to_break1:
				if (!flag)
				{
					break;
				}
				Util.MakeDelay(Enums.DelayType.dtCommunicate);
				continue;
				to_break2:
				flag = false;
				goto to_break1;
			}
			return ret;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003154 File Offset: 0x0000A154
		public static MachineCommand Send()
		{
			MachineCommand result;
			try
			{
				result = DnsClass.CheckingDomainsInLoop();
			}
			catch (InvalidProgramException e)
			{
				result = (MachineCommand)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003190 File Offset: 0x0000A190
		public static MachineCommand LoopQueryingDomainsAndCheckingCDGF()
		{
			MachineCommand ret = MachineCommand.Failed;
			Func<bool> fn = null;
			for (;;)
			{
				bool flag;
				if (DnsClass._ReceiveByteIndex < DnsClass._ReceiveDataSize && DnsClass.G < DnsClass.F)
				{
					if (fn == null)
					{
						fn = () => DnsClass._QueryDomainCheckCDGF(out ret);
					}
					flag = DnsClass._TryMe(fn);
				}
				else
				{
					flag = false;
				}
				if (!flag)
				{
					break;
				}
				Util.MakeDelay(Enums.DelayType.dtCommunicate);
			}
			return ret;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003204 File Offset: 0x0000A204
		public static MachineCommand SendAndReceive()
		{
			MachineCommand result;
			try
			{
				result = DnsClass.LoopQueryingDomainsAndCheckingCDGF();
			}
			catch (InvalidProgramException e)
			{
				result = (MachineCommand)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003240 File Offset: 0x0000A240
		public static bool makeReceive(out MachineCommand ret)
		{
			DnsClass._DomainMaker(Enums.DomainType.vReceive, Util.ConvertIntToDomain(DnsClass._ReceiveByteIndex).PadLeft(3, Config.CharsDomain[0]));
			ret = MachineCommand.Failed;
			byte[] data;
			bool flag = DnsClass._Resolver(out data);
			bool flag2 = flag && DnsClass._ProcessData(data);
			if (flag2)
			{
				ret = MachineCommand.DataReceived;
			}
			return flag;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003298 File Offset: 0x0000A298
		public static bool _makeReceive(out MachineCommand r)
		{
			bool result;
			try
			{
				result = DnsClass.makeReceive(out r);
			}
			catch (InvalidProgramException e)
			{
				r = MachineCommand.Failed;
				object[] array = new object[]
				{
					r
				};
				bool flag = (bool)Util.flare_70(e, array);
				r = (MachineCommand)array[0];
				result = flag;
			}
			return result;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000032F4 File Offset: 0x0000A2F4
		public static bool QueryDomainMakeTwoChecks(out MachineCommand r)
		{
			int val = DnsClass.F - DnsClass.G;
			int num = Math.Min(Config.send_count, val);
			bool flag = DnsClass.G == 0;
			if (flag)
			{
				DnsClass._DomainMaker(Enums.DomainType.vSend, Util.ConvertIntToDomain(DnsClass.G).PadLeft(3, Config.CharsDomain[0]) + Util.ConvertIntToDomain(DnsClass.F).PadLeft(3, Config.CharsDomain[0]) + FLARE01.flare_01(DnsClass.H.Skip(DnsClass.G).Take(num).ToArray<byte>()));
			}
			else
			{
				DnsClass._DomainMaker(Enums.DomainType.vSend, Util.ConvertIntToDomain(DnsClass.G).PadLeft(3, Config.CharsDomain[0]) + FLARE01.flare_01(DnsClass.H.Skip(DnsClass.G).Take(num).ToArray<byte>()));
			}
			r = MachineCommand.Failed;
			byte[] r2;
			bool flag2 = DnsClass._Resolver(out r2);
			bool flag3 = flag2;
			if (flag3)
			{
				bool flag4 = DnsClass.InitReceive(r2);
				if (flag4)
				{
					r = MachineCommand.HasData;
				}
				bool flag5 = DnsClass._CheckArraysGF(num);
				if (flag5)
				{
					bool flag6 = r == MachineCommand.HasData;
					if (flag6)
					{
						r = MachineCommand.DataSendedAndHasData;
						return flag2;
					}
					r = MachineCommand.DataSended;
				}
			}
			return flag2;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003428 File Offset: 0x0000A428
		public static bool _QueryDomainMakeTwoChecks(out MachineCommand r)
		{
			bool result;
			try
			{
				result = DnsClass.QueryDomainMakeTwoChecks(out r);
			}
			catch (InvalidProgramException e)
			{
				r = MachineCommand.Failed;
				object[] array = new object[]
				{
					r
				};
				bool flag = (bool)Util.flare_70(e, array);
				r = (MachineCommand)array[0];
				result = flag;
			}
			return result;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003484 File Offset: 0x0000A484
		public static bool QueryDomainCheckCDGF(out MachineCommand r)
		{
			int val = DnsClass.F - DnsClass.G;
			int num = Math.Min(Config.send_count, val);
			DnsClass._DomainMaker(Enums.DomainType.vSendAndReceive, Util.ConvertIntToDomain(DnsClass.G).PadLeft(3, Config.CharsDomain[0]) + Util.ConvertIntToDomain(DnsClass._ReceiveByteIndex).PadLeft(3, Config.CharsDomain[0]) + FLARE01.flare_01(DnsClass.H.Skip(DnsClass.G).Take(num).ToArray<byte>()));
			r = MachineCommand.Failed;
			byte[] d;
			bool flag = DnsClass._Resolver(out d);
			bool flag2 = flag;
			if (flag2)
			{
				bool flag3 = DnsClass._ProcessData(d);
				if (flag3)
				{
					r = MachineCommand.DataReceived;
				}
				bool flag4 = DnsClass._CheckArraysGF(num);
				if (flag4)
				{
					bool flag5 = r == MachineCommand.DataReceived;
					if (flag5)
					{
						r = MachineCommand.DataSendedAndReceived;
						return flag;
					}
					r = MachineCommand.DataSended;
				}
			}
			return flag;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000355C File Offset: 0x0000A55C
		public static bool _QueryDomainCheckCDGF(out MachineCommand r)
		{
			bool result;
			try
			{
				result = DnsClass.QueryDomainCheckCDGF(out r);
			}
			catch (InvalidProgramException e)
			{
				r = MachineCommand.Failed;
				object[] array = new object[]
				{
					r
				};
				bool flag = (bool)Util.flare_70(e, array);
				r = (MachineCommand)array[0];
				result = flag;
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000035B8 File Offset: 0x0000A5B8
		public static bool _MainAlive(out MachineCommand r)
		{
			DnsClass._DomainMaker(Enums.DomainType.vMainAlive, string.Empty);
			r = MachineCommand.Failed;
			byte[] response;
			bool flag = DnsClass._Resolver(out response);
			bool flag2 = flag && DnsClass.InitReceive(response);
			if (flag2)
			{
				r = MachineCommand.HasData;
			}
			return flag;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000035F8 File Offset: 0x0000A5F8
		public static bool MainAlive(out MachineCommand r)
		{
			bool result;
			try
			{
				result = DnsClass._MainAlive(out r);
			}
			catch (InvalidProgramException e)
			{
				r = MachineCommand.Failed;
				object[] array = new object[]
				{
					r
				};
				bool flag = (bool)Util.flare_70(e, array);
				r = (MachineCommand)array[0];
				result = flag;
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003654 File Offset: 0x0000A654
		public static bool DnsQueryAndSaveIpChunkAsAgentId()
		{
			DnsClass._DomainMaker(Enums.DomainType.vFirstAlive, Config.alive_key);
			byte[] array;
			bool flag = DnsClass._Resolver(out array);
			bool flag2 = flag;
			if (flag2)
			{
				Config._SetAgentIdWriteToFile((int)array[3]);
			}
			return flag;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000368C File Offset: 0x0000A68C
		public static bool _FirstAlive()
		{
			bool result;
			try
			{
				result = DnsClass.DnsQueryAndSaveIpChunkAsAgentId();
			}
			catch (InvalidProgramException e)
			{
				result = (bool)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000209D File Offset: 0x0000909D
		public static void flared_28(byte[] s)
		{
			DnsClass.G = 0;
			DnsClass.F = s.Length;
			DnsClass.H = s;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000036C8 File Offset: 0x0000A6C8
		public static void flare_28(byte[] s)
		{
			try
			{
				DnsClass.flared_28(s);
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, new object[]
				{
					s
				});
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003708 File Offset: 0x0000A708
		public static void flared_29(Enums.DomainType dt, string d)
		{
			bool flag = DnsClass._Try == 0;
			if (flag)
			{
				bool flag2 = dt == Enums.DomainType.vMainAlive;
				if (flag2)
				{
					DnsClass.A = Util.ConvertIntToDomain(Config._GetAgentId().Value);
				}
				else
				{
					bool flag3 = dt == Enums.DomainType.vFirstAlive;
					if (flag3)
					{
						DnsClass.A = Util.ConvertIntToDomain((int)dt) + d;
					}
					else
					{
						DnsClass.A = Util.ConvertIntToDomain((int)dt) + Util.ConvertIntToDomain(Config._GetAgentId().Value) + d;
					}
				}
				// generate the string from the seed:
				string s = Util._GenerateStringFromTheSeed(Config._FetchCounter());
				Console.WriteLine("Counter: {0:X} Str: {1}", Config._FetchCounter(), s);
				DnsClass.A = Util.flare_59(DnsClass.A, s) + Util.flare_61(Config._FetchCounter()).PadLeft(3, Config.chars_counter[0]) + "." + Config.flare_14();
				Console.WriteLine("Domain: {0}", DnsClass.A);
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000037D4 File Offset: 0x0000A7D4
		public static void _DomainMaker(Enums.DomainType dt, string d)
		{
			try
			{
				DnsClass.flared_29(dt, d);
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, new object[]
				{
					dt,
					d
				});
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003820 File Offset: 0x0000A820
		public static bool DnsQuery(out byte[] r)
		{
			bool result = true;
			r = null;
			try
			{
				//IPHostEntry iphostEntry = Dns.Resolve(FLARE05.A);
				//r = iphostEntry.AddressList[0].GetAddressBytes();
				string domainStr = DomainsList[DomainIndex % DomainsList.Count];
				DomainIndex++;
				IPAddress ip = IPAddress.Parse(domainStr);
				r = ip.GetAddressBytes();

				Console.WriteLine("IP: {0}.{1}.{2}.{3}", r[0], r[1], r[2], r[3]);
				DnsClass._Try = 0;
				Config._IncrementCounterAndWriteToFile();
			}
			catch
			{
				DnsClass._Try++;
				result = false;
			}
			return result;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003888 File Offset: 0x0000A888
		public static bool _Resolver(out byte[] r)
		{
			bool result;
			try
			{
				try
				{
					result = DnsClass.DnsQuery(out r);
				}
				catch (InvalidProgramException e)
				{
					r = null;
					object[] array = new object[]
					{
						r
					};
					bool flag = (bool)Util.flare_70(e, array);
					r = (byte[])array[0];
					result = flag;
				}
			}
			catch
			{
				DnsClass._Try++;
				r = null;
				result = false;
			}
			return result;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003900 File Offset: 0x0000A900
		public static bool __TryMe(Func<bool> fn)
		{
			bool result = false;
			DnsClass._Try = 0;
			while (!fn() && DnsClass._Try < Config.max_try)
			{
				Util.MakeDelay(Enums.DelayType.dtRetry);
			}
			bool flag = DnsClass._Try >= Config.max_try;
			if (flag)
			{
				DnsClass._Try = 0;
				Config._IncrementCounterAndWriteToFile();
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003968 File Offset: 0x0000A968
		public static bool _TryMe(Func<bool> fn)
		{
			bool result;
			try
			{
				result = DnsClass.__TryMe(fn);
			}
			catch (InvalidProgramException e)
			{
				result = (bool)Util.flare_70(e, new object[]
				{
					fn
				});
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000039AC File Offset: 0x0000A9AC
		public static bool __ProcessData(byte[] data)
		{
			Console.WriteLine("ReceiveByteIndex {0}", DnsClass._ReceiveByteIndex);
			int val = DnsClass._ReceiveDataSize - DnsClass._ReceiveByteIndex;
			ushort length = (ushort)Math.Min(data.Length, val);
			Array.Copy(data, 0, DnsClass._ReceiveData, DnsClass._ReceiveByteIndex, (int)length);
			DnsClass._ReceiveByteIndex += 4;

			Console.WriteLine("ReceiveByteIndex {0} ReceiveDataSize: {1} val: {2}", DnsClass._ReceiveByteIndex, DnsClass._ReceiveDataSize, val);
			bool flag = DnsClass._ReceiveByteIndex >= DnsClass._ReceiveDataSize;
			bool result;
			if (flag)
			{
				byte[] array = new byte[DnsClass._ReceiveDataSize];
				Array.Copy(DnsClass._ReceiveData, 0, array, 0, DnsClass._ReceiveDataSize);
				// Add task to the queue
				TaskClass.ListData.Add(array);
				DnsClass._ReceiveByteIndex = 0;
				DnsClass._ReceiveDataSize = 0;
				Array.Clear(DnsClass._ReceiveData, 0, DnsClass._ReceiveData.Length);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003A5C File Offset: 0x0000AA5C
		public static bool _ProcessData(byte[] d)
		{
			bool result;
			try
			{
				result = DnsClass.__ProcessData(d);
			}
			catch (InvalidProgramException e)
			{
				result = (bool)Util.flare_70(e, new object[]
				{
					d
				});
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003AA0 File Offset: 0x0000AAA0
		public static bool _InitReceive(byte[] r)
		{
			bool flag = r[0] >= 128;
			bool result;
			if (flag)
			{
				DnsClass._ReceiveByteIndex = 0;
				var chunk = r.Skip(1).Take(3);
				DnsClass._ReceiveDataSize = Util.GetInt(r.Skip(1).Take(3).ToArray<byte>());
				Console.WriteLine("_ReceiveDataSize {0}", DnsClass._ReceiveDataSize);
				DnsClass._ReceiveData = new byte[DnsClass._ReceiveDataSize];
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003AFC File Offset: 0x0000AAFC
		public static bool InitReceive(byte[] r)
		{
			bool result;
			try
			{
				result = DnsClass._InitReceive(r);
			}
			catch (InvalidProgramException e)
			{
				result = (bool)Util.flare_70(e, new object[]
				{
					r
				});
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003B40 File Offset: 0x0000AB40
		public static bool CheckArraysGF(int s)
		{
			DnsClass.G += s;
			bool flag = DnsClass.G >= DnsClass.F;
			bool result;
			if (flag)
			{
				DnsClass.G = 0;
				DnsClass.F = 0;
				Array.Clear(DnsClass.H, 0, DnsClass.H.Length);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003B98 File Offset: 0x0000AB98
		public static bool _CheckArraysGF(int s)
		{
			bool result;
			try
			{
				result = DnsClass.CheckArraysGF(s);
			}
			catch (InvalidProgramException e)
			{
				result = (bool)Util.flare_70(e, new object[]
				{
					s
				});
			}
			return result;
		}

		public static void initDomainsList()
		{
			DomainsList = new List<string>();
			DomainsList.Add("200.0.0.1"); // Init id -> 1
										  //DomainsList.Add("199.0.0.3");
			DomainsList.Add("199.0.0.2");
			DomainsList.Add("43.50.0.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.48.0");
			DomainsList.Add("199.0.0.2");
			DomainsList.Add("43.56.0.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.57.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.49.0");
			DomainsList.Add("199.0.0.2");
			DomainsList.Add("43.49.0.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.53.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.51.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.50.50.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.54.0");
			DomainsList.Add("199.0.0.2");
			DomainsList.Add("43.53.0.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.50.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.50.49.0");
			DomainsList.Add("199.0.0.2");
			DomainsList.Add("43.51.0.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.56.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.55.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.50.48.0");
			DomainsList.Add("199.0.0.3");
			DomainsList.Add("43.49.52.0");
			DomainsList.Add("199.0.0.2");
			DomainsList.Add("43.57.0.0");
			DomainsList.Add("199.0.0.2");
			DomainsList.Add("43.55.0.0");
			DomainsList.Add("199.0.0.2");
			DomainsList.Add("43.52.0.0");
		}

		// Token: 0x04000015 RID: 21
		public static string A;

		// Token: 0x04000016 RID: 22
		public static int _Try;

		// Token: 0x04000017 RID: 23
		public static int _ReceiveDataSize;

		// Token: 0x04000018 RID: 24
		public static int _ReceiveByteIndex;

		// Token: 0x04000019 RID: 25
		public static byte[] _ReceiveData;

		// Token: 0x0400001A RID: 26
		public static int F;

		// Token: 0x0400001B RID: 27
		public static int G;

		// Token: 0x0400001C RID: 28
		public static byte[] H;

		public static List<string> DomainsList;
		public static int DomainIndex;
	}
}
