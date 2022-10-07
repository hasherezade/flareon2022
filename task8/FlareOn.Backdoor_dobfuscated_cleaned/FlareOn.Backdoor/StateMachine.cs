using System;
using System.Collections.Generic;

namespace FlareOn.Backdoor
{
	// Token: 0x02000021 RID: 33
	public class StateMachine
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00002142 File Offset: 0x00009142
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00002149 File Offset: 0x00009149
		public static MachineState CurrentState { get; private set; }

		// Token: 0x06000084 RID: 132 RVA: 0x000046D0 File Offset: 0x0000B6D0
		public static void initTransitionsMap()
		{
			StateMachine.CurrentState = MachineState.Begin;
			StateMachine.t = new Dictionary<StateMachine.StateTransition, MachineState>
			{
				{
					new StateMachine.StateTransition(MachineState.Begin, MachineCommand.Start),
					MachineState.Alive
				},
				{
					new StateMachine.StateTransition(MachineState.Sleep, MachineCommand.Start),
					MachineState.Alive
				},
				{
					new StateMachine.StateTransition(MachineState.Alive, MachineCommand.Failed),
					MachineState.Sleep
				},
				{
					new StateMachine.StateTransition(MachineState.Alive, MachineCommand.HasData),
					MachineState.Receive
				},
				{
					new StateMachine.StateTransition(MachineState.Receive, MachineCommand.Failed),
					MachineState.Sleep
				},
				{
					new StateMachine.StateTransition(MachineState.Receive, MachineCommand.DataReceived),
					MachineState.Do
				},
				{
					new StateMachine.StateTransition(MachineState.Do, MachineCommand.Failed),
					MachineState.SecondSleep
				},
				{
					new StateMachine.StateTransition(MachineState.Do, MachineCommand.HasResult),
					MachineState.Send
				},
				{
					new StateMachine.StateTransition(MachineState.Send, MachineCommand.Failed),
					MachineState.Sleep
				},
				{
					new StateMachine.StateTransition(MachineState.Send, MachineCommand.HasData),
					MachineState.SendAndReceive
				},
				{
					new StateMachine.StateTransition(MachineState.Send, MachineCommand.DataSended),
					MachineState.Do
				},
				{
					new StateMachine.StateTransition(MachineState.Send, MachineCommand.DataSendedAndHasData),
					MachineState.Receive
				},
				{
					new StateMachine.StateTransition(MachineState.SendAndReceive, MachineCommand.Failed),
					MachineState.Sleep
				},
				{
					new StateMachine.StateTransition(MachineState.SendAndReceive, MachineCommand.DataReceived),
					MachineState.Send
				},
				{
					new StateMachine.StateTransition(MachineState.SendAndReceive, MachineCommand.DataSended),
					MachineState.Receive
				},
				{
					new StateMachine.StateTransition(MachineState.SendAndReceive, MachineCommand.DataSendedAndReceived),
					MachineState.Do
				},
				{
					new StateMachine.StateTransition(MachineState.SecondSleep, MachineCommand.Start),
					MachineState.Alive
				}
			};
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000047F0 File Offset: 0x0000B7F0
		public static void _initTransitionsMap()
		{
			try
			{
				StateMachine.initTransitionsMap();
			}
			catch (InvalidProgramException e)
			{
				Util.flare_70(e, null);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004828 File Offset: 0x0000B828
		public static MachineState _GetNext(MachineCommand c)
		{
			StateMachine.StateTransition key = new StateMachine.StateTransition(StateMachine.CurrentState, c);
			MachineState result;
			bool flag = !StateMachine.t.TryGetValue(key, out result);
			if (flag)
			{
				throw new Exception("Invalid transition: " + StateMachine.CurrentState.ToString() + " -> " + c.ToString());
			}
			return result;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004894 File Offset: 0x0000B894
		public static MachineState GetNext(MachineCommand c)
		{
			MachineState result;
			try
			{
				result = StateMachine._GetNext(c);
			}
			catch (InvalidProgramException e)
			{
				result = (MachineState)Util.flare_70(e, new object[]
				{
					c
				});
			}
			return result;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000048DC File Offset: 0x0000B8DC
		public static MachineState _MoveNext(MachineCommand command)
		{
			StateMachine.CurrentState = StateMachine.GetNext(command);
			return StateMachine.CurrentState;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004900 File Offset: 0x0000B900
		public static MachineState MoveNext(MachineCommand c)
		{
			MachineState result;
			try
			{
				result = StateMachine._MoveNext(c);
			}
			catch (InvalidProgramException e)
			{
				result = (MachineState)Util.flare_70(e, new object[]
				{
					c
				});
			}
			return result;
		}

		// Token: 0x04000124 RID: 292
		public static Dictionary<StateMachine.StateTransition, MachineState> t;

		// Token: 0x02000022 RID: 34
		public class StateTransition
		{
			// Token: 0x0600008B RID: 139 RVA: 0x00002151 File Offset: 0x00009151
			public StateTransition(MachineState cs, MachineCommand c)
			{
				this.CurrentState = cs;
				this.Command = c;
			}

			// Token: 0x0600008C RID: 140 RVA: 0x00004948 File Offset: 0x0000B948
			public override int GetHashCode()
			{
				return 17 + 31 * this.CurrentState.GetHashCode() + 31 * this.Command.GetHashCode();
			}

			// Token: 0x0600008D RID: 141 RVA: 0x00004988 File Offset: 0x0000B988
			public override bool Equals(object obj)
			{
				StateMachine.StateTransition flare = obj as StateMachine.StateTransition;
				return flare != null && this.CurrentState == flare.CurrentState && this.Command == flare.Command;
			}

			// Token: 0x04000125 RID: 293
			private readonly MachineState CurrentState;

			// Token: 0x04000126 RID: 294
			private readonly MachineCommand Command;
		}
	}
}
