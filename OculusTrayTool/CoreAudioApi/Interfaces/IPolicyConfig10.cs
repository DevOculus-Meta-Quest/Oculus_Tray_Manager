using System;
using System.Runtime.InteropServices;
using CoreAudio;

namespace OculusTrayTool.CoreAudioApi.Interfaces
{
	// Token: 0x02000032 RID: 50
	[Guid("00000000-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IPolicyConfig10
	{
		// Token: 0x060004B9 RID: 1209
		[PreserveSig]
		int GetMixFormat(string pszDeviceName, IntPtr ppFormat);

		// Token: 0x060004BA RID: 1210
		[PreserveSig]
		int GetDeviceFormat(string pszDeviceName, bool bDefault, IntPtr ppFormat);

		// Token: 0x060004BB RID: 1211
		[PreserveSig]
		int ResetDeviceFormat(string pszDeviceName);

		// Token: 0x060004BC RID: 1212
		[PreserveSig]
		int SetDeviceFormat(string pszDeviceName, IntPtr pEndpointFormat, IntPtr MixFormat);

		// Token: 0x060004BD RID: 1213
		[PreserveSig]
		int GetProcessingPeriod(string pszDeviceName, bool bDefault, IntPtr pmftDefaultPeriod, IntPtr pmftMinimumPeriod);

		// Token: 0x060004BE RID: 1214
		[PreserveSig]
		int SetProcessingPeriod(string pszDeviceName, IntPtr pmftPeriod);

		// Token: 0x060004BF RID: 1215
		[PreserveSig]
		int GetShareMode(string pszDeviceName, IntPtr pMode);

		// Token: 0x060004C0 RID: 1216
		[PreserveSig]
		int SetShareMode(string pszDeviceName, IntPtr mode);

		// Token: 0x060004C1 RID: 1217
		[PreserveSig]
		int GetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

		// Token: 0x060004C2 RID: 1218
		[PreserveSig]
		int SetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

		// Token: 0x060004C3 RID: 1219
		[PreserveSig]
		int SetDefaultEndpoint(string pszDeviceName, ERole role);

		// Token: 0x060004C4 RID: 1220
		[PreserveSig]
		int SetEndpointVisibility(string pszDeviceName, bool bVisible);
	}
}
