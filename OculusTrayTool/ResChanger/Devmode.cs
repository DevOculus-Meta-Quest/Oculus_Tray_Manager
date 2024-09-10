using System;
using System.Runtime.InteropServices;

namespace OculusTrayTool.ResChanger
{
	// Token: 0x02000047 RID: 71
	public struct Devmode
	{
		// Token: 0x04000217 RID: 535
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmDeviceName;

		// Token: 0x04000218 RID: 536
		[MarshalAs(UnmanagedType.U2)]
		public ushort dmSpecVersion;

		// Token: 0x04000219 RID: 537
		[MarshalAs(UnmanagedType.U2)]
		public ushort dmDriverVersion;

		// Token: 0x0400021A RID: 538
		[MarshalAs(UnmanagedType.U2)]
		public ushort dmSize;

		// Token: 0x0400021B RID: 539
		[MarshalAs(UnmanagedType.U2)]
		public ushort dmDriverExtra;

		// Token: 0x0400021C RID: 540
		[MarshalAs(UnmanagedType.U4)]
		public uint dmFields;

		// Token: 0x0400021D RID: 541
		public Pointl dmPosition;

		// Token: 0x0400021E RID: 542
		[MarshalAs(UnmanagedType.U4)]
		public uint dmDisplayOrientation;

		// Token: 0x0400021F RID: 543
		[MarshalAs(UnmanagedType.U4)]
		public uint dmDisplayFixedOutput;

		// Token: 0x04000220 RID: 544
		[MarshalAs(UnmanagedType.I2)]
		public short dmColor;

		// Token: 0x04000221 RID: 545
		[MarshalAs(UnmanagedType.I2)]
		public short dmDuplex;

		// Token: 0x04000222 RID: 546
		[MarshalAs(UnmanagedType.I2)]
		public short dmYResolution;

		// Token: 0x04000223 RID: 547
		[MarshalAs(UnmanagedType.I2)]
		public short dmTTOption;

		// Token: 0x04000224 RID: 548
		[MarshalAs(UnmanagedType.I2)]
		public short dmCollate;

		// Token: 0x04000225 RID: 549
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmFormName;

		// Token: 0x04000226 RID: 550
		[MarshalAs(UnmanagedType.U2)]
		public ushort dmLogPixels;

		// Token: 0x04000227 RID: 551
		[MarshalAs(UnmanagedType.U4)]
		public uint dmBitsPerPel;

		// Token: 0x04000228 RID: 552
		[MarshalAs(UnmanagedType.U4)]
		public uint dmPelsWidth;

		// Token: 0x04000229 RID: 553
		[MarshalAs(UnmanagedType.U4)]
		public uint dmPelsHeight;

		// Token: 0x0400022A RID: 554
		[MarshalAs(UnmanagedType.U4)]
		public uint dmDisplayFlags;

		// Token: 0x0400022B RID: 555
		[MarshalAs(UnmanagedType.U4)]
		public uint dmDisplayFrequency;

		// Token: 0x0400022C RID: 556
		[MarshalAs(UnmanagedType.U4)]
		public uint dmICMMethod;

		// Token: 0x0400022D RID: 557
		[MarshalAs(UnmanagedType.U4)]
		public uint dmICMIntent;

		// Token: 0x0400022E RID: 558
		[MarshalAs(UnmanagedType.U4)]
		public uint dmMediaType;

		// Token: 0x0400022F RID: 559
		[MarshalAs(UnmanagedType.U4)]
		public uint dmDitherType;

		// Token: 0x04000230 RID: 560
		[MarshalAs(UnmanagedType.U4)]
		public uint dmReserved1;

		// Token: 0x04000231 RID: 561
		[MarshalAs(UnmanagedType.U4)]
		public uint dmReserved2;

		// Token: 0x04000232 RID: 562
		[MarshalAs(UnmanagedType.U4)]
		public uint dmPanningWidth;

		// Token: 0x04000233 RID: 563
		[MarshalAs(UnmanagedType.U4)]
		public uint dmPanningHeight;
	}
}
