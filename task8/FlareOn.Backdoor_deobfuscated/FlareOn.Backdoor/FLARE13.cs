using System;
using System.Collections.Generic;

namespace FlareOn.Backdoor
{
	// Token: 0x02000021 RID: 33
	public class FLARE13
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000082 RID: 130 RVA: 0x00002142 File Offset: 0x00009142
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00002149 File Offset: 0x00009149
		public static FLARE08 cs { get; private set; }

		// Token: 0x06000084 RID: 132 RVA: 0x000046D0 File Offset: 0x0000B6D0
		public static void flared_48()
		{
			FLARE13.cs = FLARE08.A;
			FLARE13.t = new Dictionary<FLARE13.FLARE16, FLARE08>
			{
				{
					new FLARE13.FLARE16(FLARE08.A, FLARE07.A),
					FLARE08.C
				},
				{
					new FLARE13.FLARE16(FLARE08.B, FLARE07.A),
					FLARE08.C
				},
				{
					new FLARE13.FLARE16(FLARE08.C, FLARE07.B),
					FLARE08.B
				},
				{
					new FLARE13.FLARE16(FLARE08.C, FLARE07.C),
					FLARE08.D
				},
				{
					new FLARE13.FLARE16(FLARE08.D, FLARE07.B),
					FLARE08.B
				},
				{
					new FLARE13.FLARE16(FLARE08.D, FLARE07.D),
					FLARE08.E
				},
				{
					new FLARE13.FLARE16(FLARE08.E, FLARE07.B),
					FLARE08.H
				},
				{
					new FLARE13.FLARE16(FLARE08.E, FLARE07.E),
					FLARE08.F
				},
				{
					new FLARE13.FLARE16(FLARE08.F, FLARE07.B),
					FLARE08.B
				},
				{
					new FLARE13.FLARE16(FLARE08.F, FLARE07.C),
					FLARE08.G
				},
				{
					new FLARE13.FLARE16(FLARE08.F, FLARE07.F),
					FLARE08.E
				},
				{
					new FLARE13.FLARE16(FLARE08.F, FLARE07.G),
					FLARE08.D
				},
				{
					new FLARE13.FLARE16(FLARE08.G, FLARE07.B),
					FLARE08.B
				},
				{
					new FLARE13.FLARE16(FLARE08.G, FLARE07.D),
					FLARE08.F
				},
				{
					new FLARE13.FLARE16(FLARE08.G, FLARE07.F),
					FLARE08.D
				},
				{
					new FLARE13.FLARE16(FLARE08.G, FLARE07.H),
					FLARE08.E
				},
				{
					new FLARE13.FLARE16(FLARE08.H, FLARE07.A),
					FLARE08.C
				}
			};
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000047F0 File Offset: 0x0000B7F0
		public static void flare_48()
		{
			try
			{
				FLARE13.flared_48();
			}
			catch (InvalidProgramException e)
			{
				FLARE15.flare_70(e, null);
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00004828 File Offset: 0x0000B828
		public static FLARE08 flared_49(FLARE07 c)
		{
			FLARE13.FLARE16 key = new FLARE13.FLARE16(FLARE13.cs, c);
			FLARE08 result;
			bool flag = !FLARE13.t.TryGetValue(key, out result);
			if (flag)
			{
				throw new Exception("Invalid transition: " + FLARE13.cs.ToString() + " -> " + c.ToString());
			}
			return result;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00004894 File Offset: 0x0000B894
		public static FLARE08 flare_49(FLARE07 c)
		{
			FLARE08 result;
			try
			{
				result = FLARE13.flared_49(c);
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE08)FLARE15.flare_70(e, new object[]
				{
					c
				});
			}
			return result;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000048DC File Offset: 0x0000B8DC
		public static FLARE08 flared_50(FLARE07 c)
		{
			FLARE13.cs = FLARE13.flare_49(c);
			return FLARE13.cs;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004900 File Offset: 0x0000B900
		public static FLARE08 flare_50(FLARE07 c)
		{
			FLARE08 result;
			try
			{
				result = FLARE13.flared_50(c);
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE08)FLARE15.flare_70(e, new object[]
				{
					c
				});
			}
			return result;
		}

		// Token: 0x04000124 RID: 292
		public static Dictionary<FLARE13.FLARE16, FLARE08> t;

		// Token: 0x02000022 RID: 34
		public class FLARE16
		{
			// Token: 0x0600008B RID: 139 RVA: 0x00002151 File Offset: 0x00009151
			public FLARE16(FLARE08 cs, FLARE07 c)
			{
				this.cs = cs;
				this.c = c;
			}

			// Token: 0x0600008C RID: 140 RVA: 0x00004948 File Offset: 0x0000B948
			public override int GetHashCode()
			{
				return 17 + 31 * this.cs.GetHashCode() + 31 * this.c.GetHashCode();
			}

			// Token: 0x0600008D RID: 141 RVA: 0x00004988 File Offset: 0x0000B988
			public override bool Equals(object obj)
			{
				FLARE13.FLARE16 flare = obj as FLARE13.FLARE16;
				return flare != null && this.cs == flare.cs && this.c == flare.c;
			}

			// Token: 0x04000125 RID: 293
			private readonly FLARE08 cs;

			// Token: 0x04000126 RID: 294
			private readonly FLARE07 c;
		}
	}
}
