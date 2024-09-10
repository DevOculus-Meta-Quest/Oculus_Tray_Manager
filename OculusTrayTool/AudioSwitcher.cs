using System;
using System.Threading;
using System.Windows.Forms;
using CoreAudio;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.PolicyClient;

namespace OculusTrayTool
{
	// Token: 0x02000009 RID: 9
	[StandardModule]
	internal sealed class AudioSwitcher
	{
		// Token: 0x0600014B RID: 331 RVA: 0x000050F0 File Offset: 0x000032F0
		public static void SetDefaultAudioDeviceOnStart(bool PlayLaunchDetected)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering SetDefaultAudioDeviceOnStart");
			}
			try
			{
				MMDeviceEnumerator mmdeviceEnumerator = new MMDeviceEnumerator();
				MMDevice defaultAudioEndpoint = mmdeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eConsole);
				bool flag = Operators.CompareString(defaultAudioEndpoint.FriendlyName.ToLower(), MySettingsProperty.Settings.SetAudioOnStart.ToLower(), false) == 0;
				if (flag)
				{
					Log.WriteToLog(MySettingsProperty.Settings.SetAudioOnStart + " is already the default audio device");
					FrmMain.fmain.AddToListboxAndScroll(MySettingsProperty.Settings.SetAudioOnStart + " is already the default audio device");
				}
				else
				{
					bool flag2 = Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, "Use current default", false) == 0;
					if (flag2)
					{
						Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Storing current default audio device '", GetDevices.GetDefaultAudioDeviceName()), "'")));
						MySettingsProperty.Settings.SystemDefaultAudioGuid = Conversions.ToString(GetDevices.GetDefaultAudioDevice());
						MySettingsProperty.Settings.DefaultAudio = Conversions.ToString(GetDevices.GetDefaultAudioDeviceName());
						MySettingsProperty.Settings.Save();
					}
					Log.WriteToLog("Setting " + MySettingsProperty.Settings.SetAudioOnStart + " as default audio device");
					PolicyConfigClient policyConfigClient = new PolicyConfigClient();
					policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SetAudioOnStartGuid, ERole.eConsole);
					policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SetAudioOnStartGuid, ERole.eMultimedia);
					MMDevice defaultAudioEndpoint2 = mmdeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eConsole);
					FrmMain.fmain.AddToListboxAndScroll(defaultAudioEndpoint2.FriendlyName + " is now the default audio device");
					MyProject.Forms.FrmMain.ToolStripMenuItem3.Text = "Set Fallback as default Audio/Mic";
					bool flag3 = PlayLaunchDetected;
					if (flag3)
					{
						PlayLaunchDetected = false;
						Thread thread = new Thread((AudioSwitcher._Closure$__.$I0-0 == null) ? (AudioSwitcher._Closure$__.$I0-0 = delegate
						{
							MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
						}) : AudioSwitcher._Closure$__.$I0-0);
						thread.Start();
					}
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting SetDefaultAudioDeviceOnStart");
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("SetDefaultAudioDeviceOnStart: " + ex.Message);
				FrmMain.fmain.AddToListboxAndScroll("Could not change default audio device: " + ex.Message);
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00005348 File Offset: 0x00003548
		public static void SetDefaultAudioCommDeviceOnStart()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering SetDefaultAudioCommDeviceOnStart");
			}
			try
			{
				bool flag = Operators.CompareString(MySettingsProperty.Settings.SetAudioCommOnStart, "", false) == 0;
				if (!flag)
				{
					bool flag2 = Operators.CompareString(MySettingsProperty.Settings.SetAudioCommOnStart, "Use current default", false) == 0;
					if (flag2)
					{
						Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Storing current default audio comm device '", GetDevices.GetDefaultAudioCommDeviceName()), "'")));
						MySettingsProperty.Settings.SetAudioCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultAudioCommDevice());
						MySettingsProperty.Settings.SetAudioCommOnStart = Conversions.ToString(GetDevices.GetDefaultAudioCommDeviceName());
						MySettingsProperty.Settings.Save();
					}
					Log.WriteToLog("Setting " + MySettingsProperty.Settings.SetAudioCommOnStart + " as default audio communication device");
					PolicyConfigClient policyConfigClient = new PolicyConfigClient();
					policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SetAudioCommOnStartGuid, ERole.eCommunications);
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Exiting SetDefaultAudioCommDeviceOnStart");
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("SetDefaultAudioCommDeviceOnStart: " + ex.Message);
				FrmMain.fmain.AddToListboxAndScroll("Could not change default audio communications device: " + ex.Message);
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x000054A8 File Offset: 0x000036A8
		public static void SetDefaultMicDeviceOnStart()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering SetDefaultMicDeviceOnStart");
			}
			try
			{
				bool flag = Operators.CompareString(MySettingsProperty.Settings.SetMicOnStart, "", false) == 0;
				if (!flag)
				{
					MMDeviceEnumerator mmdeviceEnumerator = new MMDeviceEnumerator();
					MMDevice defaultAudioEndpoint = mmdeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole);
					bool flag2 = Operators.CompareString(defaultAudioEndpoint.FriendlyName.ToLower(), MySettingsProperty.Settings.SetMicOnStart.ToLower(), false) == 0;
					if (flag2)
					{
						FrmMain.fmain.AddToListboxAndScroll(MySettingsProperty.Settings.SetMicOnStart + " is already the default mic device");
						bool useVoiceCommands = GetConfig.useVoiceCommands;
						if (useVoiceCommands)
						{
							MyProject.Forms.FrmMain.EnableDisableVoice(true);
						}
					}
					else
					{
						bool flag3 = Operators.CompareString(MySettingsProperty.Settings.SetMicOnStart, "Use current default", false) == 0;
						if (flag3)
						{
							Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Storing current default mic device '", GetDevices.GetDefaultMicDeviceName()), "'")));
							MySettingsProperty.Settings.SetMicOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicDevice());
							MySettingsProperty.Settings.SetMicOnStart = Conversions.ToString(GetDevices.GetDefaultMicDeviceName());
							MySettingsProperty.Settings.Save();
						}
						Log.WriteToLog("Setting " + MySettingsProperty.Settings.SetMicOnStart + " as default mic device");
						PolicyConfigClient policyConfigClient = new PolicyConfigClient();
						policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SetMicOnStartGuid, ERole.eConsole);
						policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SetMicOnStartGuid, ERole.eMultimedia);
						MMDevice defaultAudioEndpoint2 = mmdeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole);
						FrmMain.fmain.AddToListboxAndScroll(defaultAudioEndpoint2.FriendlyName + " is now the default mic device");
						MyProject.Forms.FrmMain.ToolStripMenuItem3.Text = "Set Fallback as default Audio/Mic";
						bool useVoiceCommands2 = GetConfig.useVoiceCommands;
						if (useVoiceCommands2)
						{
							MyProject.Forms.FrmMain.EnableDisableVoice(true);
						}
					}
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Exiting SetDefaultMicDeviceOnStart");
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("SetDefaultMicDeviceOnStart: " + ex.Message);
				FrmMain.fmain.AddToListboxAndScroll("Could not change default mic device: " + ex.Message);
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00005708 File Offset: 0x00003908
		public static void SetDefaultMicCommDeviceOnStart()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering SetDefaultMicCommDeviceOnStart");
			}
			try
			{
				bool flag = Operators.CompareString(MySettingsProperty.Settings.SetMicCommOnStart, "", false) == 0;
				if (!flag)
				{
					bool flag2 = Operators.CompareString(MySettingsProperty.Settings.SetMicCommOnStart, "Use current default", false) == 0;
					if (flag2)
					{
						Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Storing current default mic comm device '", GetDevices.GetDefaultMicCommDeviceName()), "'")));
						MySettingsProperty.Settings.SetMicCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicCommDevice());
						MySettingsProperty.Settings.SetMicCommOnStart = Conversions.ToString(GetDevices.GetDefaultMicCommDeviceName());
						MySettingsProperty.Settings.Save();
					}
					Log.WriteToLog("Setting " + MySettingsProperty.Settings.SetMicCommOnStart + " as default mic communication device");
					PolicyConfigClient policyConfigClient = new PolicyConfigClient();
					policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SetMicCommOnStartGuid, ERole.eCommunications);
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog("Exiting SetDefaultMicCommDeviceOnStart");
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("SetDefaultMicCommDeviceOnStart: " + ex.Message);
				FrmMain.fmain.AddToListboxAndScroll("Could not change default mic communications device: " + ex.Message);
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00005868 File Offset: 0x00003A68
		public static void SetFallbackAudioDevice()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering SetFallbackAudioDevice");
			}
			try
			{
				bool flag = (Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.DefaultAudio.ToString()) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultAudioGuid, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.SystemDefaultAudioGuid.ToString());
				if (flag)
				{
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog(string.Concat(new string[]
						{
							"Setting '",
							MySettingsProperty.Settings.DefaultAudio,
							"' ",
							MySettingsProperty.Settings.SystemDefaultAudioGuid.Replace("{", "[").Replace("}", "]"),
							" as default audio device"
						}));
					}
					else
					{
						Log.WriteToLog("Setting '" + MySettingsProperty.Settings.DefaultAudio + "' as default audio device");
					}
					FrmMain.fmain.AddToListboxAndScroll("Setting '" + MySettingsProperty.Settings.DefaultAudio + "' as default audio device");
					PolicyConfigClient policyConfigClient = new PolicyConfigClient();
					try
					{
						policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SystemDefaultAudioGuid, ERole.eConsole);
						policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SystemDefaultAudioGuid, ERole.eMultimedia);
					}
					catch (Exception ex)
					{
						Log.WriteToLog("Could not set '" + MySettingsProperty.Settings.DefaultAudio + "' as default audio device: " + ex.Message);
					}
				}
				else
				{
					Log.WriteToLog("Could not set fallback audio device, no device selected");
					FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio device, no device selected");
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Exiting SetFallbackAudioDevice");
				}
			}
			catch (Exception ex2)
			{
				Log.WriteToLog("SetFallbackAudioDevice: " + ex2.Message);
				FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio device: " + ex2.Message);
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00005ABC File Offset: 0x00003CBC
		public static void SetFallbackMicDevice()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering SetFallbackMicDevice");
			}
			try
			{
				bool flag = (Operators.CompareString(MySettingsProperty.Settings.DefaultMic, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.DefaultMic.ToString()) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultMicGuid, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.SystemDefaultMicGuid.ToString());
				if (flag)
				{
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog(string.Concat(new string[]
						{
							"Setting '",
							MySettingsProperty.Settings.DefaultMic,
							"' ",
							MySettingsProperty.Settings.SystemDefaultMicGuid.Replace("{", "[").Replace("}", "]"),
							" as default microphone device"
						}));
					}
					else
					{
						Log.WriteToLog("Setting '" + MySettingsProperty.Settings.DefaultMic + "' as default microphone device");
					}
					FrmMain.fmain.AddToListboxAndScroll("Setting '" + MySettingsProperty.Settings.DefaultMic + "' as default microphone device");
					PolicyConfigClient policyConfigClient = new PolicyConfigClient();
					try
					{
						policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SystemDefaultMicGuid, ERole.eConsole);
						policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SystemDefaultMicGuid, ERole.eMultimedia);
					}
					catch (Exception ex)
					{
						Log.WriteToLog("Could not set '" + MySettingsProperty.Settings.DefaultMic + "' as default microphone device: " + ex.Message);
					}
				}
				else
				{
					Log.WriteToLog("Could not set fallback microphone device, no device selected");
					FrmMain.fmain.AddToListboxAndScroll("Could not set fallback microphone device, no device selected");
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Exiting SetFallbackMicDevice");
				}
			}
			catch (Exception ex2)
			{
				Log.WriteToLog("SetFallbackMicDevice: " + ex2.Message);
				FrmMain.fmain.AddToListboxAndScroll("Could not set fallback microphone device: " + ex2.Message);
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00005D10 File Offset: 0x00003F10
		public static void SetFallbackCommMicDevice()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering SetFallbackCommDevice");
			}
			try
			{
				bool flag = (Operators.CompareString(MySettingsProperty.Settings.DefaultComm, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.DefaultComm.ToString()) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultCommGuid, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.SystemDefaultCommGuid.ToString());
				if (flag)
				{
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog(string.Concat(new string[]
						{
							"Setting '",
							MySettingsProperty.Settings.DefaultComm,
							"' ",
							MySettingsProperty.Settings.SystemDefaultCommGuid.Replace("{", "[").Replace("}", "]"),
							" as default mic communications device"
						}));
					}
					else
					{
						Log.WriteToLog("Setting '" + MySettingsProperty.Settings.DefaultComm + "' as default mic communications device");
					}
					FrmMain.fmain.AddToListboxAndScroll("Setting '" + MySettingsProperty.Settings.DefaultComm + "' as default mic communications device");
					PolicyConfigClient policyConfigClient = new PolicyConfigClient();
					try
					{
						policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SystemDefaultCommGuid, ERole.eCommunications);
					}
					catch (Exception ex)
					{
						Log.WriteToLog("Could not set '" + MySettingsProperty.Settings.DefaultComm + "' as default mic communications device: " + ex.Message);
					}
				}
				else
				{
					Log.WriteToLog("Could not set fallback communications mic device, no device selected");
					FrmMain.fmain.AddToListboxAndScroll("Could not set fallback mic ommunications device, no device selected");
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Exiting SetFallbackCommDevice");
				}
			}
			catch (Exception ex2)
			{
				Log.WriteToLog("SetFallbackCommDevice: " + ex2.Message);
				FrmMain.fmain.AddToListboxAndScroll("Could not set fallback mic communications device: " + ex2.Message);
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00005F50 File Offset: 0x00004150
		public static void SetFallbackCommAudioDevice()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering SetFallbackCommDevice");
			}
			try
			{
				bool flag = (Operators.CompareString(MySettingsProperty.Settings.DefaultCommAudio, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.DefaultCommAudio.ToString()) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultCommAudioGuid, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.SystemDefaultCommAudioGuid.ToString());
				if (flag)
				{
					bool dbg2 = Globals.dbg;
					if (dbg2)
					{
						Log.WriteToLog(string.Concat(new string[]
						{
							"Setting '",
							MySettingsProperty.Settings.DefaultCommAudio,
							"' ",
							MySettingsProperty.Settings.SystemDefaultCommAudioGuid.Replace("{", "[").Replace("}", "]"),
							" as default audio communications device"
						}));
					}
					else
					{
						Log.WriteToLog("Setting '" + MySettingsProperty.Settings.DefaultCommAudio + "' as default audio communications device");
					}
					FrmMain.fmain.AddToListboxAndScroll("Setting '" + MySettingsProperty.Settings.DefaultCommAudio + "' as default audio communications device");
					PolicyConfigClient policyConfigClient = new PolicyConfigClient();
					try
					{
						policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SystemDefaultCommAudioGuid, ERole.eCommunications);
					}
					catch (Exception ex)
					{
						Log.WriteToLog("Could not set '" + MySettingsProperty.Settings.DefaultCommAudio + "' as default audio communications device: " + ex.Message);
					}
				}
				else
				{
					Log.WriteToLog("Could not set fallback audio communications device, no device selected");
					FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio communications device, no device selected");
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Exiting SetFallbackCommDevice");
				}
			}
			catch (Exception ex2)
			{
				Log.WriteToLog("SetFallbackCommDevice: " + ex2.Message);
				FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio communications device: " + ex2.Message);
			}
		}
	}
}
