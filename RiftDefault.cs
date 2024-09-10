// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.RiftDefault
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using CoreAudio;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.PolicyClient;
using System;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class RiftDefault
  {
    public static void SetRiftDefaultAudioDevice()
    {
      try
      {
        Log.WriteToLog("Setting Rift as default audio device");
        PolicyConfigClient policyConfigClient = new PolicyConfigClient();
        policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.RiftAudioGuid, ERole.eConsole);
        policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.RiftAudioGuid, ERole.eMultimedia);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("SetRiftDefaultAudioDevice: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void SetRiftDefaultMicDevice()
    {
      try
      {
        Log.WriteToLog("Setting Rift as default mic device");
        PolicyConfigClient policyConfigClient = new PolicyConfigClient();
        policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.RiftMicGuid, ERole.eConsole);
        policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.RiftMicGuid, ERole.eMultimedia);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("SetRiftDefaultMicDevice: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }
  }
}
