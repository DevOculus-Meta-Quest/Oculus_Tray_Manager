using System;
using System.Runtime.InteropServices;
using CoreAudio;

namespace OculusTrayTool.CoreAudioApi.Interfaces
{
	// Token: 0x02000031 RID: 49
	[Guid("f8679f50-850a-41cf-9c72-430f290290c8")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	internal interface IPolicyConfig
	{
		// Token: 0x060004AD RID: 1197
		[PreserveSig]
		int GetMixFormat(string pszDeviceName, IntPtr ppFormat);

		// Token: 0x060004AE RID: 1198
		[PreserveSig]
		int GetDeviceFormat(string pszDeviceName, bool bDefault, IntPtr ppFormat);

		// Token: 0x060004AF RID: 1199
		[PreserveSig]
		int ResetDeviceFormat(string pszDeviceName);

		// Token: 0x060004B0 RID: 1200
		[PreserveSig]
		int SetDeviceFormat(string pszDeviceName, IntPtr pEndpointFormat, IntPtr MixFormat);

		// Token: 0x060004B1 RID: 1201
		[PreserveSig]
		int GetProcessingPeriod(string pszDeviceName, bool bDefault, IntPtr pmftDefaultPeriod, IntPtr pmftMinimumPeriod);

		// Token: 0x060004B2 RID: 1202
		[PreserveSig]
		int SetProcessingPeriod(string pszDeviceName, IntPtr pmftPeriod);

		// Token: 0x060004B3 RID: 1203
		[PreserveSig]
		int GetShareMode(string pszDeviceName, IntPtr pMode);

		// Token: 0x060004B4 RID: 1204
		[PreserveSig]
		int SetShareMode(string pszDeviceName, IntPtr mode);

		// Token: 0x060004B5 RID: 1205
		[PreserveSig]
		int GetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

		// Token: 0x060004B6 RID: 1206
		[PreserveSig]
		int SetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

		// Token: 0x060004B7 RID: 1207
		[PreserveSig]
		int SetDefaultEndpoint(string pszDeviceName, ERole role);

		// Token: 0x060004B8 RID: 1208
		[PreserveSig]
		int SetEndpointVisibility(string pszDeviceName, bool bVisible);
	}
}
