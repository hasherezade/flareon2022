using System;

namespace FlareOn.Backdoor
{
	// Token: 0x0200000C RID: 12
	public static class Enums
	{
		// Token: 0x0200000D RID: 13
		public enum DomainType
		{
			// Token: 0x04000025 RID: 37
			vFirstAlive,
			// Token: 0x04000026 RID: 38
			vSend,
			// Token: 0x04000027 RID: 39
			vReceive,
			// Token: 0x04000028 RID: 40
			vSendAndReceive,
			// Token: 0x04000029 RID: 41
			vMainAlive
		}

		// Token: 0x0200000E RID: 14
		public enum DelayType
		{
			// Token: 0x0400002B RID: 43
			dtAlive,
			// Token: 0x0400002C RID: 44
			dtCommunicate,
			// Token: 0x0400002D RID: 45
			dtSecondCheck,
			// Token: 0x0400002E RID: 46
			dtRetry
		}

		// Token: 0x0200000F RID: 15
		public enum TaskType
		{
			// Token: 0x04000030 RID: 48
			Cmd = 70, // Cmd
			// Token: 0x04000031 RID: 49
			CompressedCmd,
			// Token: 0x04000032 RID: 50
			Static = 43, //Static
			// Token: 0x04000033 RID: 51
			File = 95, //File
			// Token: 0x04000034 RID: 52
			CompressedFile
		}

		// Token: 0x02000010 RID: 16
		public enum SR
		{
			// Token: 0x04000036 RID: 54
			A,
			// Token: 0x04000037 RID: 55
			B,
			// Token: 0x04000038 RID: 56
			C,
			// Token: 0x04000039 RID: 57
			D,
			// Token: 0x0400003A RID: 58
			E
		}

		// Token: 0x02000011 RID: 17
		public enum OT
		{
			// Token: 0x0400003C RID: 60
			A,
			// Token: 0x0400003D RID: 61
			B,
			// Token: 0x0400003E RID: 62
			C,
			// Token: 0x0400003F RID: 63
			D,
			// Token: 0x04000040 RID: 64
			E,
			// Token: 0x04000041 RID: 65
			F,
			// Token: 0x04000042 RID: 66
			G,
			// Token: 0x04000043 RID: 67
			H,
			// Token: 0x04000044 RID: 68
			I
		}
	}
}
