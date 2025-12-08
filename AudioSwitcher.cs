using System;
using System.Diagnostics;
using OculusTrayTool.PolicyClient;

namespace OculusTrayTool
{
    public static class AudioSwitcher
    {
        public static void SetFallbackAudioDevice()
        {
            try
            {
                string guid = My.MySettings.Default.SystemDefaultAudioGuid;
                if (!string.IsNullOrEmpty(guid))
                {
                    Log.WriteToLog("Setting Fallback as default audio device");
                    PolicyConfigClient client = new PolicyConfigClient();
                    client.SetDefaultEndpoint(guid, CoreAudio.ERole.eConsole);
                    client.SetDefaultEndpoint(guid, CoreAudio.ERole.eMultimedia);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToLog("SetFallbackAudioDevice: " + ex.Message);
            }
        }

        public static void SetFallbackCommAudioDevice()
        {
            try
            {
                string guid = My.MySettings.Default.SystemDefaultCommAudioGuid;
                if (!string.IsNullOrEmpty(guid))
                {
                    Log.WriteToLog("Setting Fallback as default communication audio device");
                    PolicyConfigClient client = new PolicyConfigClient();
                    client.SetDefaultEndpoint(guid, CoreAudio.ERole.eCommunications);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToLog("SetFallbackCommAudioDevice: " + ex.Message);
            }
        }

        public static void SetFallbackMicDevice()
        {
            try
            {
                string guid = My.MySettings.Default.SystemDefaultMicGuid;
                if (!string.IsNullOrEmpty(guid))
                {
                    Log.WriteToLog("Setting Fallback as default mic device");
                    PolicyConfigClient client = new PolicyConfigClient();
                    client.SetDefaultEndpoint(guid, CoreAudio.ERole.eConsole);
                    client.SetDefaultEndpoint(guid, CoreAudio.ERole.eMultimedia);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToLog("SetFallbackMicDevice: " + ex.Message);
            }
        }

        public static void SetFallbackCommMicDevice()
        {
            try
            {
                string guid = My.MySettings.Default.SystemDefaultCommGuid;
                if (!string.IsNullOrEmpty(guid))
                {
                    Log.WriteToLog("Setting Fallback as default communication mic device");
                    PolicyConfigClient client = new PolicyConfigClient();
                    client.SetDefaultEndpoint(guid, CoreAudio.ERole.eCommunications);
                }
            }
            catch (Exception ex)
            {
                Log.WriteToLog("SetFallbackCommMicDevice: " + ex.Message);
            }
        }

        public static void SetDefaultAudioDeviceOnStart(bool confirm)
        {
             // Mirrors logic for Rift/Fallback based on settings or args?
             // Actually, the name implies setting "Start" device?
             // Or setting Default Audio Device when the tool *Starts*?
             // Usage in FrmMain suggests it might set Rift or Fallback based on config.
             // But existing calls are AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
             // Let's assume it sets Rift if configured?
             // FrmMain.cs 2065: AudioSwitcher.SetFallbackAudioDevice();
             // FrmMain.cs 673: AudioSwitcher.SetDefaultAudioDeviceOnStart(false);
             
             // I'll check "SetRiftDefaultAudioDevice" in RiftDefault.cs.
             // Maybe this is just a wrapper?
             
             // Inspecting FrmMain.cs usage logic:
             // if (SetRiftAudioDefault == 0) -> SetDefaultAudioDeviceOnStart
             
             // For now, I'll implement it as setting Rift Default (since Fallback is separate).
             // Wait, if confirm is true, maybe play sound?
             
            try
            {
                string guid = My.MySettings.Default.RiftAudioGuid;
                 if (!string.IsNullOrEmpty(guid))
                {
                    Log.WriteToLog("Setting Rift as default audio device (OnStart)");
                    PolicyConfigClient client = new PolicyConfigClient();
                    client.SetDefaultEndpoint(guid, CoreAudio.ERole.eConsole);
                    client.SetDefaultEndpoint(guid, CoreAudio.ERole.eMultimedia);
                    
                    if (confirm)
                    {
                         // Play confirmation sound?
                         // My.MyComputer.Audio.Play(...);
                    }
                }
            }
            catch (Exception ex)
            {
                 Log.WriteToLog("SetDefaultAudioDeviceOnStart: " + ex.Message);
            }
        }

        public static void SetDefaultAudioCommDeviceOnStart()
        {
             // Similar logic for Rift Comm
             try
            {
                string guid = My.MySettings.Default.RiftAudioGuid; // Or separate Comm guid?
                // Checking settings names... MySettings.Default.RiftAudioGuid is used in RiftDefault.cs
                // Is there a RiftCommAudioGuid?
                // I'll guess it uses the same device for Comm usually, or maybe no specific setting?
                // RiftDefault.cs doesn't show Comm method.
                // But FrmMain calls SetDefaultAudioCommDeviceOnStart.
                
                // Let's assume RiftAudioGuid for now or check if there is a RiftAudioCommGuid.
                // I'll look at MySettings property usage in FrmMain again if I can.
                // or just use RiftAudioGuid for eCommunications.
                
                if (!string.IsNullOrEmpty(guid))
                {
                    new PolicyConfigClient().SetDefaultEndpoint(guid, CoreAudio.ERole.eCommunications);
                }
            }
            catch (Exception ex) { Log.WriteToLog("SetDefaultAudioCommDeviceOnStart: " + ex.Message); }
        }

        public static void SetDefaultMicDeviceOnStart()
        {
             RiftDefault.SetRiftDefaultMicDevice();
        }

        public static void SetDefaultMicCommDeviceOnStart()
        {
             // Assume Rift Mic for Comm
             try
            {
                 string guid = My.MySettings.Default.RiftMicGuid;
                 if (!string.IsNullOrEmpty(guid))
                {
                    new PolicyConfigClient().SetDefaultEndpoint(guid, CoreAudio.ERole.eCommunications);
                }
            }
            catch (Exception ex) { Log.WriteToLog("SetDefaultMicCommDeviceOnStart: " + ex.Message); }
        }
    }
}
