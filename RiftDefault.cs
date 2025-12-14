
using CoreAudio;

using OculusTrayTool.My;
using OculusTrayTool.PolicyClient;
using System;

#nullable disable
namespace OculusTrayTool
{

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
        // ProjectData.SetProjectError(ex);
        Log.WriteToLog("SetRiftDefaultAudioDevice: " + ex.Message);
        // ProjectData.ClearProjectError();
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
        // ProjectData.SetProjectError(ex);
        Log.WriteToLog("SetRiftDefaultMicDevice: " + ex.Message);
        // ProjectData.ClearProjectError();
      }
    }
  }
}
