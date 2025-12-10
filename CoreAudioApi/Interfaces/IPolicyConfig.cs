
using CoreAudio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace OculusTrayTool.CoreAudioApi.Interfaces
{
  [Guid("f8679f50-850a-41cf-9c72-430f290290c8")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  internal interface IPolicyConfig
  {
    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetMixFormat(string pszDeviceName, IntPtr ppFormat);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetDeviceFormat(string pszDeviceName, bool bDefault, IntPtr ppFormat);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int ResetDeviceFormat(string pszDeviceName);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int SetDeviceFormat(string pszDeviceName, IntPtr pEndpointFormat, IntPtr MixFormat);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetProcessingPeriod(
      string pszDeviceName,
      bool bDefault,
      IntPtr pmftDefaultPeriod,
      IntPtr pmftMinimumPeriod);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int SetProcessingPeriod(string pszDeviceName, IntPtr pmftPeriod);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetShareMode(string pszDeviceName, IntPtr pMode);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int SetShareMode(string pszDeviceName, IntPtr mode);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int GetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int SetPropertyValue(string pszDeviceName, bool bFxStore, IntPtr key, IntPtr pv);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int SetDefaultEndpoint(string pszDeviceName, ERole role);

    [MethodImpl(MethodImplOptions.PreserveSig)]
    int SetEndpointVisibility(string pszDeviceName, bool bVisible);
  }
}
