using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace FlareOn.Backdoor
{
	// Token: 0x02000014 RID: 20
	public class FLARE09
	{
		// Token: 0x06000058 RID: 88 RVA: 0x00003BE0 File Offset: 0x0000ABE0
		public static void flared_35(string f)
		{
			using (FileStream fileStream = new FileStream(f, FileMode.Open, FileAccess.Read))
			{
				BinaryReader binaryReader = new BinaryReader(fileStream);
				FLARE09.dosHeader = FLARE09.FromBinaryReader<FLARE09.IMAGE_DOS_HEADER>(binaryReader);
				fileStream.Seek((long)((ulong)FLARE09.dosHeader.e_lfanew), SeekOrigin.Begin);
				uint num = binaryReader.ReadUInt32();
				FLARE09.fileHeader = FLARE09.FromBinaryReader<FLARE09.IMAGE_FILE_HEADER>(binaryReader);
				FLARE09.optionalHeader32 = FLARE09.FromBinaryReader<FLARE09.IMAGE_OPTIONAL_HEADER32>(binaryReader);
				FLARE09.imageSectionHeaders = new FLARE09.IMAGE_SECTION_HEADER[(int)FLARE09.fileHeader.NumberOfSections];
				for (int i = 0; i < FLARE09.imageSectionHeaders.Length; i++)
				{
					FLARE09.imageSectionHeaders[i] = FLARE09.FromBinaryReader<FLARE09.IMAGE_SECTION_HEADER>(binaryReader);
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003C98 File Offset: 0x0000AC98
		public static void flare_37(string f)
		{
			try
			{
				FLARE09.flared_35(f);
			}
			catch (InvalidProgramException e)
			{
				Util.flare_71(e, new object[]
				{
					f
				}, Util.pe_m, Util.pe_b);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003CE4 File Offset: 0x0000ACE4
		public static FLARE09 flared_36()
		{
			string location = Assembly.GetCallingAssembly().Location;
			FLARE09 result = new FLARE09();
			FLARE09.flare_37(location);
			return result;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003D10 File Offset: 0x0000AD10
		public static FLARE09 flare_38()
		{
			FLARE09 result;
			try
			{
				result = FLARE09.flared_36();
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE09)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003D4C File Offset: 0x0000AD4C
		public static FLARE09 flared_37()
		{
			string location = Assembly.GetAssembly(typeof(FLARE09)).Location;
			FLARE09 result = new FLARE09();
			FLARE09.flare_37(location);
			return result;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003D84 File Offset: 0x0000AD84
		public static FLARE09 flare_39()
		{
			FLARE09 result;
			try
			{
				result = FLARE09.flared_37();
			}
			catch (InvalidProgramException e)
			{
				result = (FLARE09)Util.flare_70(e, null);
			}
			return result;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003DC0 File Offset: 0x0000ADC0
		public static T FromBinaryReader<T>(BinaryReader reader)
		{
			byte[] value = reader.ReadBytes(Marshal.SizeOf(typeof(T)));
			GCHandle gchandle = GCHandle.Alloc(value, GCHandleType.Pinned);
			T result = (T)((object)Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(T)));
			gchandle.Free();
			return result;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003E18 File Offset: 0x0000AE18
		public bool Is32BitHeader
		{
			get
			{
				ushort num = 256;
				return (num & this.FileHeader.Characteristics) == num;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00003E40 File Offset: 0x0000AE40
		public FLARE09.IMAGE_FILE_HEADER FileHeader
		{
			get
			{
				return FLARE09.fileHeader;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00003E58 File Offset: 0x0000AE58
		public FLARE09.IMAGE_OPTIONAL_HEADER32 OptionalHeader32
		{
			get
			{
				return FLARE09.optionalHeader32;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00003E70 File Offset: 0x0000AE70
		public FLARE09.IMAGE_OPTIONAL_HEADER64 OptionalHeader64
		{
			get
			{
				return FLARE09.optionalHeader64;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00003E88 File Offset: 0x0000AE88
		public FLARE09.IMAGE_SECTION_HEADER[] ImageSectionHeaders
		{
			get
			{
				return FLARE09.imageSectionHeaders;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00003EA0 File Offset: 0x0000AEA0
		public DateTime TimeStamp
		{
			get
			{
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
				dateTime = dateTime.AddSeconds(FLARE09.fileHeader.TimeDateStamp);
				dateTime += TimeZone.CurrentTimeZone.GetUtcOffset(dateTime);
				return dateTime;
			}
		}

		// Token: 0x04000057 RID: 87
		public static FLARE09.IMAGE_DOS_HEADER dosHeader;

		// Token: 0x04000058 RID: 88
		public static FLARE09.IMAGE_FILE_HEADER fileHeader;

		// Token: 0x04000059 RID: 89
		public static FLARE09.IMAGE_OPTIONAL_HEADER32 optionalHeader32;

		// Token: 0x0400005A RID: 90
		public static FLARE09.IMAGE_OPTIONAL_HEADER64 optionalHeader64;

		// Token: 0x0400005B RID: 91
		public static FLARE09.IMAGE_SECTION_HEADER[] imageSectionHeaders;

		// Token: 0x02000015 RID: 21
		public struct IMAGE_DOS_HEADER
		{
			// Token: 0x0400005C RID: 92
			public ushort e_magic;

			// Token: 0x0400005D RID: 93
			public ushort e_cblp;

			// Token: 0x0400005E RID: 94
			public ushort e_cp;

			// Token: 0x0400005F RID: 95
			public ushort e_crlc;

			// Token: 0x04000060 RID: 96
			public ushort e_cparhdr;

			// Token: 0x04000061 RID: 97
			public ushort e_minalloc;

			// Token: 0x04000062 RID: 98
			public ushort e_maxalloc;

			// Token: 0x04000063 RID: 99
			public ushort e_ss;

			// Token: 0x04000064 RID: 100
			public ushort e_sp;

			// Token: 0x04000065 RID: 101
			public ushort e_csum;

			// Token: 0x04000066 RID: 102
			public ushort e_ip;

			// Token: 0x04000067 RID: 103
			public ushort e_cs;

			// Token: 0x04000068 RID: 104
			public ushort e_lfarlc;

			// Token: 0x04000069 RID: 105
			public ushort e_ovno;

			// Token: 0x0400006A RID: 106
			public ushort e_res_0;

			// Token: 0x0400006B RID: 107
			public ushort e_res_1;

			// Token: 0x0400006C RID: 108
			public ushort e_res_2;

			// Token: 0x0400006D RID: 109
			public ushort e_res_3;

			// Token: 0x0400006E RID: 110
			public ushort e_oemid;

			// Token: 0x0400006F RID: 111
			public ushort e_oeminfo;

			// Token: 0x04000070 RID: 112
			public ushort e_res2_0;

			// Token: 0x04000071 RID: 113
			public ushort e_res2_1;

			// Token: 0x04000072 RID: 114
			public ushort e_res2_2;

			// Token: 0x04000073 RID: 115
			public ushort e_res2_3;

			// Token: 0x04000074 RID: 116
			public ushort e_res2_4;

			// Token: 0x04000075 RID: 117
			public ushort e_res2_5;

			// Token: 0x04000076 RID: 118
			public ushort e_res2_6;

			// Token: 0x04000077 RID: 119
			public ushort e_res2_7;

			// Token: 0x04000078 RID: 120
			public ushort e_res2_8;

			// Token: 0x04000079 RID: 121
			public ushort e_res2_9;

			// Token: 0x0400007A RID: 122
			public uint e_lfanew;
		}

		// Token: 0x02000016 RID: 22
		public struct IMAGE_DATA_DIRECTORY
		{
			// Token: 0x0400007B RID: 123
			public uint VirtualAddress;

			// Token: 0x0400007C RID: 124
			public uint Size;
		}

		// Token: 0x02000017 RID: 23
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct IMAGE_OPTIONAL_HEADER32
		{
			// Token: 0x0400007D RID: 125
			public ushort Magic;

			// Token: 0x0400007E RID: 126
			public byte MajorLinkerVersion;

			// Token: 0x0400007F RID: 127
			public byte MinorLinkerVersion;

			// Token: 0x04000080 RID: 128
			public uint SizeOfCode;

			// Token: 0x04000081 RID: 129
			public uint SizeOfInitializedData;

			// Token: 0x04000082 RID: 130
			public uint SizeOfUninitializedData;

			// Token: 0x04000083 RID: 131
			public uint AddressOfEntryPoint;

			// Token: 0x04000084 RID: 132
			public uint BaseOfCode;

			// Token: 0x04000085 RID: 133
			public uint BaseOfData;

			// Token: 0x04000086 RID: 134
			public uint ImageBase;

			// Token: 0x04000087 RID: 135
			public uint SectionAlignment;

			// Token: 0x04000088 RID: 136
			public uint FileAlignment;

			// Token: 0x04000089 RID: 137
			public ushort MajorOperatingSystemVersion;

			// Token: 0x0400008A RID: 138
			public ushort MinorOperatingSystemVersion;

			// Token: 0x0400008B RID: 139
			public ushort MajorImageVersion;

			// Token: 0x0400008C RID: 140
			public ushort MinorImageVersion;

			// Token: 0x0400008D RID: 141
			public ushort MajorSubsystemVersion;

			// Token: 0x0400008E RID: 142
			public ushort MinorSubsystemVersion;

			// Token: 0x0400008F RID: 143
			public uint Win32VersionValue;

			// Token: 0x04000090 RID: 144
			public uint SizeOfImage;

			// Token: 0x04000091 RID: 145
			public uint SizeOfHeaders;

			// Token: 0x04000092 RID: 146
			public uint CheckSum;

			// Token: 0x04000093 RID: 147
			public ushort Subsystem;

			// Token: 0x04000094 RID: 148
			public ushort DllCharacteristics;

			// Token: 0x04000095 RID: 149
			public uint SizeOfStackReserve;

			// Token: 0x04000096 RID: 150
			public uint SizeOfStackCommit;

			// Token: 0x04000097 RID: 151
			public uint SizeOfHeapReserve;

			// Token: 0x04000098 RID: 152
			public uint SizeOfHeapCommit;

			// Token: 0x04000099 RID: 153
			public uint LoaderFlags;

			// Token: 0x0400009A RID: 154
			public uint NumberOfRvaAndSizes;

			// Token: 0x0400009B RID: 155
			public FLARE09.IMAGE_DATA_DIRECTORY ExportTable;

			// Token: 0x0400009C RID: 156
			public FLARE09.IMAGE_DATA_DIRECTORY ImportTable;

			// Token: 0x0400009D RID: 157
			public FLARE09.IMAGE_DATA_DIRECTORY ResourceTable;

			// Token: 0x0400009E RID: 158
			public FLARE09.IMAGE_DATA_DIRECTORY ExceptionTable;

			// Token: 0x0400009F RID: 159
			public FLARE09.IMAGE_DATA_DIRECTORY CertificateTable;

			// Token: 0x040000A0 RID: 160
			public FLARE09.IMAGE_DATA_DIRECTORY BaseRelocationTable;

			// Token: 0x040000A1 RID: 161
			public FLARE09.IMAGE_DATA_DIRECTORY Debug;

			// Token: 0x040000A2 RID: 162
			public FLARE09.IMAGE_DATA_DIRECTORY Architecture;

			// Token: 0x040000A3 RID: 163
			public FLARE09.IMAGE_DATA_DIRECTORY GlobalPtr;

			// Token: 0x040000A4 RID: 164
			public FLARE09.IMAGE_DATA_DIRECTORY TLSTable;

			// Token: 0x040000A5 RID: 165
			public FLARE09.IMAGE_DATA_DIRECTORY LoadConfigTable;

			// Token: 0x040000A6 RID: 166
			public FLARE09.IMAGE_DATA_DIRECTORY BoundImport;

			// Token: 0x040000A7 RID: 167
			public FLARE09.IMAGE_DATA_DIRECTORY IAT;

			// Token: 0x040000A8 RID: 168
			public FLARE09.IMAGE_DATA_DIRECTORY DelayImportDescriptor;

			// Token: 0x040000A9 RID: 169
			public FLARE09.IMAGE_DATA_DIRECTORY CLRRuntimeHeader;

			// Token: 0x040000AA RID: 170
			public FLARE09.IMAGE_DATA_DIRECTORY Reserved;
		}

		// Token: 0x02000018 RID: 24
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct IMAGE_OPTIONAL_HEADER64
		{
			// Token: 0x040000AB RID: 171
			public ushort Magic;

			// Token: 0x040000AC RID: 172
			public byte MajorLinkerVersion;

			// Token: 0x040000AD RID: 173
			public byte MinorLinkerVersion;

			// Token: 0x040000AE RID: 174
			public uint SizeOfCode;

			// Token: 0x040000AF RID: 175
			public uint SizeOfInitializedData;

			// Token: 0x040000B0 RID: 176
			public uint SizeOfUninitializedData;

			// Token: 0x040000B1 RID: 177
			public uint AddressOfEntryPoint;

			// Token: 0x040000B2 RID: 178
			public uint BaseOfCode;

			// Token: 0x040000B3 RID: 179
			public ulong ImageBase;

			// Token: 0x040000B4 RID: 180
			public uint SectionAlignment;

			// Token: 0x040000B5 RID: 181
			public uint FileAlignment;

			// Token: 0x040000B6 RID: 182
			public ushort MajorOperatingSystemVersion;

			// Token: 0x040000B7 RID: 183
			public ushort MinorOperatingSystemVersion;

			// Token: 0x040000B8 RID: 184
			public ushort MajorImageVersion;

			// Token: 0x040000B9 RID: 185
			public ushort MinorImageVersion;

			// Token: 0x040000BA RID: 186
			public ushort MajorSubsystemVersion;

			// Token: 0x040000BB RID: 187
			public ushort MinorSubsystemVersion;

			// Token: 0x040000BC RID: 188
			public uint Win32VersionValue;

			// Token: 0x040000BD RID: 189
			public uint SizeOfImage;

			// Token: 0x040000BE RID: 190
			public uint SizeOfHeaders;

			// Token: 0x040000BF RID: 191
			public uint CheckSum;

			// Token: 0x040000C0 RID: 192
			public ushort Subsystem;

			// Token: 0x040000C1 RID: 193
			public ushort DllCharacteristics;

			// Token: 0x040000C2 RID: 194
			public ulong SizeOfStackReserve;

			// Token: 0x040000C3 RID: 195
			public ulong SizeOfStackCommit;

			// Token: 0x040000C4 RID: 196
			public ulong SizeOfHeapReserve;

			// Token: 0x040000C5 RID: 197
			public ulong SizeOfHeapCommit;

			// Token: 0x040000C6 RID: 198
			public uint LoaderFlags;

			// Token: 0x040000C7 RID: 199
			public uint NumberOfRvaAndSizes;

			// Token: 0x040000C8 RID: 200
			public FLARE09.IMAGE_DATA_DIRECTORY ExportTable;

			// Token: 0x040000C9 RID: 201
			public FLARE09.IMAGE_DATA_DIRECTORY ImportTable;

			// Token: 0x040000CA RID: 202
			public FLARE09.IMAGE_DATA_DIRECTORY ResourceTable;

			// Token: 0x040000CB RID: 203
			public FLARE09.IMAGE_DATA_DIRECTORY ExceptionTable;

			// Token: 0x040000CC RID: 204
			public FLARE09.IMAGE_DATA_DIRECTORY CertificateTable;

			// Token: 0x040000CD RID: 205
			public FLARE09.IMAGE_DATA_DIRECTORY BaseRelocationTable;

			// Token: 0x040000CE RID: 206
			public FLARE09.IMAGE_DATA_DIRECTORY Debug;

			// Token: 0x040000CF RID: 207
			public FLARE09.IMAGE_DATA_DIRECTORY Architecture;

			// Token: 0x040000D0 RID: 208
			public FLARE09.IMAGE_DATA_DIRECTORY GlobalPtr;

			// Token: 0x040000D1 RID: 209
			public FLARE09.IMAGE_DATA_DIRECTORY TLSTable;

			// Token: 0x040000D2 RID: 210
			public FLARE09.IMAGE_DATA_DIRECTORY LoadConfigTable;

			// Token: 0x040000D3 RID: 211
			public FLARE09.IMAGE_DATA_DIRECTORY BoundImport;

			// Token: 0x040000D4 RID: 212
			public FLARE09.IMAGE_DATA_DIRECTORY IAT;

			// Token: 0x040000D5 RID: 213
			public FLARE09.IMAGE_DATA_DIRECTORY DelayImportDescriptor;

			// Token: 0x040000D6 RID: 214
			public FLARE09.IMAGE_DATA_DIRECTORY CLRRuntimeHeader;

			// Token: 0x040000D7 RID: 215
			public FLARE09.IMAGE_DATA_DIRECTORY Reserved;
		}

		// Token: 0x02000019 RID: 25
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct IMAGE_FILE_HEADER
		{
			// Token: 0x040000D8 RID: 216
			public ushort Machine;

			// Token: 0x040000D9 RID: 217
			public ushort NumberOfSections;

			// Token: 0x040000DA RID: 218
			public uint TimeDateStamp;

			// Token: 0x040000DB RID: 219
			public uint PointerToSymbolTable;

			// Token: 0x040000DC RID: 220
			public uint NumberOfSymbols;

			// Token: 0x040000DD RID: 221
			public ushort SizeOfOptionalHeader;

			// Token: 0x040000DE RID: 222
			public ushort Characteristics;
		}

		// Token: 0x0200001A RID: 26
		[StructLayout(LayoutKind.Explicit)]
		public struct IMAGE_SECTION_HEADER
		{
			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000066 RID: 102 RVA: 0x00003EEC File Offset: 0x0000AEEC
			public string Section
			{
				get
				{
					return new string(this.Name);
				}
			}

			// Token: 0x040000DF RID: 223
			[FieldOffset(0)]
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public char[] Name;

			// Token: 0x040000E0 RID: 224
			[FieldOffset(8)]
			public uint VirtualSize;

			// Token: 0x040000E1 RID: 225
			[FieldOffset(12)]
			public uint VirtualAddress;

			// Token: 0x040000E2 RID: 226
			[FieldOffset(16)]
			public uint SizeOfRawData;

			// Token: 0x040000E3 RID: 227
			[FieldOffset(20)]
			public uint PointerToRawData;

			// Token: 0x040000E4 RID: 228
			[FieldOffset(24)]
			public uint PointerToRelocations;

			// Token: 0x040000E5 RID: 229
			[FieldOffset(28)]
			public uint PointerToLinenumbers;

			// Token: 0x040000E6 RID: 230
			[FieldOffset(32)]
			public ushort NumberOfRelocations;

			// Token: 0x040000E7 RID: 231
			[FieldOffset(34)]
			public ushort NumberOfLinenumbers;

			// Token: 0x040000E8 RID: 232
			[FieldOffset(36)]
			public FLARE09.DataSectionFlags Characteristics;
		}

		// Token: 0x0200001B RID: 27
		[Flags]
		public enum DataSectionFlags : uint
		{
			// Token: 0x040000EA RID: 234
			TypeReg = 0U,
			// Token: 0x040000EB RID: 235
			TypeDsect = 1U,
			// Token: 0x040000EC RID: 236
			TypeNoLoad = 2U,
			// Token: 0x040000ED RID: 237
			TypeGroup = 4U,
			// Token: 0x040000EE RID: 238
			TypeNoPadded = 8U,
			// Token: 0x040000EF RID: 239
			TypeCopy = 16U,
			// Token: 0x040000F0 RID: 240
			ContentCode = 32U,
			// Token: 0x040000F1 RID: 241
			ContentInitializedData = 64U,
			// Token: 0x040000F2 RID: 242
			ContentUninitializedData = 128U,
			// Token: 0x040000F3 RID: 243
			LinkOther = 256U,
			// Token: 0x040000F4 RID: 244
			LinkInfo = 512U,
			// Token: 0x040000F5 RID: 245
			TypeOver = 1024U,
			// Token: 0x040000F6 RID: 246
			LinkRemove = 2048U,
			// Token: 0x040000F7 RID: 247
			LinkComDat = 4096U,
			// Token: 0x040000F8 RID: 248
			NoDeferSpecExceptions = 16384U,
			// Token: 0x040000F9 RID: 249
			RelativeGP = 32768U,
			// Token: 0x040000FA RID: 250
			MemPurgeable = 131072U,
			// Token: 0x040000FB RID: 251
			Memory16Bit = 131072U,
			// Token: 0x040000FC RID: 252
			MemoryLocked = 262144U,
			// Token: 0x040000FD RID: 253
			MemoryPreload = 524288U,
			// Token: 0x040000FE RID: 254
			Align1Bytes = 1048576U,
			// Token: 0x040000FF RID: 255
			Align2Bytes = 2097152U,
			// Token: 0x04000100 RID: 256
			Align4Bytes = 3145728U,
			// Token: 0x04000101 RID: 257
			Align8Bytes = 4194304U,
			// Token: 0x04000102 RID: 258
			Align16Bytes = 5242880U,
			// Token: 0x04000103 RID: 259
			Align32Bytes = 6291456U,
			// Token: 0x04000104 RID: 260
			Align64Bytes = 7340032U,
			// Token: 0x04000105 RID: 261
			Align128Bytes = 8388608U,
			// Token: 0x04000106 RID: 262
			Align256Bytes = 9437184U,
			// Token: 0x04000107 RID: 263
			Align512Bytes = 10485760U,
			// Token: 0x04000108 RID: 264
			Align1024Bytes = 11534336U,
			// Token: 0x04000109 RID: 265
			Align2048Bytes = 12582912U,
			// Token: 0x0400010A RID: 266
			Align4096Bytes = 13631488U,
			// Token: 0x0400010B RID: 267
			Align8192Bytes = 14680064U,
			// Token: 0x0400010C RID: 268
			LinkExtendedRelocationOverflow = 16777216U,
			// Token: 0x0400010D RID: 269
			MemoryDiscardable = 33554432U,
			// Token: 0x0400010E RID: 270
			MemoryNotCached = 67108864U,
			// Token: 0x0400010F RID: 271
			MemoryNotPaged = 134217728U,
			// Token: 0x04000110 RID: 272
			MemoryShared = 268435456U,
			// Token: 0x04000111 RID: 273
			MemoryExecute = 536870912U,
			// Token: 0x04000112 RID: 274
			MemoryRead = 1073741824U,
			// Token: 0x04000113 RID: 275
			MemoryWrite = 2147483648U
		}
	}
}
