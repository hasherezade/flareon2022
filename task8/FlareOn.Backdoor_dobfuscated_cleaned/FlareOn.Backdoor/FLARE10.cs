using System;

namespace FlareOn.Backdoor
{
	// Token: 0x0200001E RID: 30
	public static class FLARE10
	{
		// Token: 0x06000071 RID: 113 RVA: 0x00004144 File Offset: 0x0000B144
		public static int flared_41(int mn, int mx)
		{
			bool flag = mn > mx;
			if (flag)
			{
				mn = mx;
			}
			return FLARE10.r.Next(mn, mx + 1);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004174 File Offset: 0x0000B174
		public static int flare_40(int mn, int mx)
		{
			int result;
			try
			{
				result = FLARE10.flared_41(mn, mx);
			}
			catch (InvalidProgramException e)
			{
				result = (int)Util.flare_70(e, new object[]
				{
					mn,
					mx
				});
			}
			return result;
		}

		// Token: 0x04000116 RID: 278
		public static Random r = new Random();
	}
}
