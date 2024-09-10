using System;
using CoreAudio;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.PolicyClient;

namespace OculusTrayTool;

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
			Exception ex2 = ex;
			Log.WriteToLog("SetRiftDefaultAudioDevice: " + ex2.Message);
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
			Exception ex2 = ex;
			Log.WriteToLog("SetRiftDefaultMicDevice: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}
}
