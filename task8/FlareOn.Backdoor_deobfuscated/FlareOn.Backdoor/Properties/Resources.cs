using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace FlareOn.Backdoor.Properties
{
	// Token: 0x02000027 RID: 39
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060000BD RID: 189 RVA: 0x00002181 File Offset: 0x00009181
		internal Resources()
		{
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000BE RID: 190 RVA: 0x000141EC File Offset: 0x0001B1EC
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("FlareOn.Backdoor.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00014234 File Offset: 0x0001B234
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x0000218B File Offset: 0x0000918B
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400013D RID: 317
		public static ResourceManager resourceMan;

		// Token: 0x0400013E RID: 318
		public static CultureInfo resourceCulture;
	}
}
