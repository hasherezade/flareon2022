using System;

namespace FlareOn.Backdoor
{
	// Token: 0x02000012 RID: 18
	public enum MachineCommand
	{
		// Token: 0x04000046 RID: 70
		Start,
		// Token: 0x04000047 RID: 71
		Failed,
		// Token: 0x04000048 RID: 72
		HasData,
		// Token: 0x04000049 RID: 73
		DataReceived,
		// Token: 0x0400004A RID: 74
		HasResult,
		// Token: 0x0400004B RID: 75
		DataSended,
		// Token: 0x0400004C RID: 76
		DataSendedAndHasData,
		// Token: 0x0400004D RID: 77
		DataSendedAndReceived
	}
}
