using System;
using CoreAudio;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.PolicyClient;

namespace OculusTrayTool
{
	// Token: 0x02000054 RID: 84
	[StandardModule]
	internal sealed class RiftDefault
	{
		// Token: 0x060007F8 RID: 2040 RVA: 0x00048B7C File Offset: 0x00046D7C
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
				Log.WriteToLog("SetRiftDefaultAudioDevice: " + ex.Message);
			}
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00048BF8 File Offset: 0x00046DF8
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
				Log.WriteToLog("SetRiftDefaultMicDevice: " + ex.Message);
			}
		}
	}
}
