using System;

namespace FlareOn.Backdoor
{
	// Token: 0x02000013 RID: 19
	public enum MachineState
	{
		// Token: 0x0400004F RID: 79
		Begin,
		// Token: 0x04000050 RID: 80
		Sleep,
		// Token: 0x04000051 RID: 81
		Alive,
		// Token: 0x04000052 RID: 82
		Receive,
		// Token: 0x04000053 RID: 83
		Do,
		// Token: 0x04000054 RID: 84
		Send,
		// Token: 0x04000055 RID: 85
		SendAndReceive,
		// Token: 0x04000056 RID: 86
		SecondSleep
	}
}
