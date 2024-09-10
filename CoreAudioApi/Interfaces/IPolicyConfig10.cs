// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.CoreAudioApi.Interfaces.IPolicyConfig10
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using CoreAudio;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace OculusTrayTool.CoreAudioApi.Interfaces
{
  [Guid("00000000-0000-0000-C000-000000000046")]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  internal interface IPolicyConfig10
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
