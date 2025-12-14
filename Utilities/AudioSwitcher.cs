using System;
using System.Diagnostics;
using MetaQuestTrayTool.PolicyClient;

namespace MetaQuestTrayTool
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
             try
            {
                string guid = My.MySettings.Default.RiftAudioGuid; // Or separate Comm guid?
                
                
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
