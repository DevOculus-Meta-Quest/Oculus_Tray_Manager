using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CoreAudio;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using OculusTrayTool.PolicyClient;

namespace OculusTrayTool;

[StandardModule]
internal sealed class AudioSwitcher
{
	public static void SetDefaultAudioDeviceOnStart(bool PlayLaunchDetected)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering SetDefaultAudioDeviceOnStart");
		}
		try
		{
			MMDeviceEnumerator mMDeviceEnumerator = new MMDeviceEnumerator();
			MMDevice defaultAudioEndpoint = mMDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eConsole);
			if (Operators.CompareString(defaultAudioEndpoint.FriendlyName.ToLower(), MySettingsProperty.Settings.SetAudioOnStart.ToLower(), TextCompare: false) == 0)
			{
				Log.WriteToLog(MySettingsProperty.Settings.SetAudioOnStart + " is already the default audio device");
				FrmMain.fmain.AddToListboxAndScroll(MySettingsProperty.Settings.SetAudioOnStart + " is already the default audio device");
			}
			else
			{
				if (Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, "Use current default", TextCompare: false) == 0)
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
				MMDevice defaultAudioEndpoint2 = mMDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eConsole);
				FrmMain.fmain.AddToListboxAndScroll(defaultAudioEndpoint2.FriendlyName + " is now the default audio device");
				MyProject.Forms.FrmMain.ToolStripMenuItem3.Text = "Set Fallback as default Audio/Mic";
				if (PlayLaunchDetected)
				{
					PlayLaunchDetected = false;
					Thread thread = new Thread([SpecialName] () =>
					{
						MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\gamelaunchdetected.wav");
					});
					thread.Start();
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting SetDefaultAudioDeviceOnStart");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("SetDefaultAudioDeviceOnStart: " + ex2.Message);
			FrmMain.fmain.AddToListboxAndScroll("Could not change default audio device: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetDefaultAudioCommDeviceOnStart()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering SetDefaultAudioCommDeviceOnStart");
		}
		try
		{
			if (Operators.CompareString(MySettingsProperty.Settings.SetAudioCommOnStart, "", TextCompare: false) != 0)
			{
				if (Operators.CompareString(MySettingsProperty.Settings.SetAudioCommOnStart, "Use current default", TextCompare: false) == 0)
				{
					Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Storing current default audio comm device '", GetDevices.GetDefaultAudioCommDeviceName()), "'")));
					MySettingsProperty.Settings.SetAudioCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultAudioCommDevice());
					MySettingsProperty.Settings.SetAudioCommOnStart = Conversions.ToString(GetDevices.GetDefaultAudioCommDeviceName());
					MySettingsProperty.Settings.Save();
				}
				Log.WriteToLog("Setting " + MySettingsProperty.Settings.SetAudioCommOnStart + " as default audio communication device");
				PolicyConfigClient policyConfigClient = new PolicyConfigClient();
				policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SetAudioCommOnStartGuid, ERole.eCommunications);
				if (Globals.dbg)
				{
					Log.WriteToLog("Exiting SetDefaultAudioCommDeviceOnStart");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("SetDefaultAudioCommDeviceOnStart: " + ex2.Message);
			FrmMain.fmain.AddToListboxAndScroll("Could not change default audio communications device: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetDefaultMicDeviceOnStart()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering SetDefaultMicDeviceOnStart");
		}
		try
		{
			if (Operators.CompareString(MySettingsProperty.Settings.SetMicOnStart, "", TextCompare: false) == 0)
			{
				return;
			}
			MMDeviceEnumerator mMDeviceEnumerator = new MMDeviceEnumerator();
			MMDevice defaultAudioEndpoint = mMDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole);
			if (Operators.CompareString(defaultAudioEndpoint.FriendlyName.ToLower(), MySettingsProperty.Settings.SetMicOnStart.ToLower(), TextCompare: false) == 0)
			{
				FrmMain.fmain.AddToListboxAndScroll(MySettingsProperty.Settings.SetMicOnStart + " is already the default mic device");
				if (GetConfig.useVoiceCommands)
				{
					MyProject.Forms.FrmMain.EnableDisableVoice(enable: true);
				}
			}
			else
			{
				if (Operators.CompareString(MySettingsProperty.Settings.SetMicOnStart, "Use current default", TextCompare: false) == 0)
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
				MMDevice defaultAudioEndpoint2 = mMDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole);
				FrmMain.fmain.AddToListboxAndScroll(defaultAudioEndpoint2.FriendlyName + " is now the default mic device");
				MyProject.Forms.FrmMain.ToolStripMenuItem3.Text = "Set Fallback as default Audio/Mic";
				if (GetConfig.useVoiceCommands)
				{
					MyProject.Forms.FrmMain.EnableDisableVoice(enable: true);
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting SetDefaultMicDeviceOnStart");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("SetDefaultMicDeviceOnStart: " + ex2.Message);
			FrmMain.fmain.AddToListboxAndScroll("Could not change default mic device: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetDefaultMicCommDeviceOnStart()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering SetDefaultMicCommDeviceOnStart");
		}
		try
		{
			if (Operators.CompareString(MySettingsProperty.Settings.SetMicCommOnStart, "", TextCompare: false) != 0)
			{
				if (Operators.CompareString(MySettingsProperty.Settings.SetMicCommOnStart, "Use current default", TextCompare: false) == 0)
				{
					Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Storing current default mic comm device '", GetDevices.GetDefaultMicCommDeviceName()), "'")));
					MySettingsProperty.Settings.SetMicCommOnStartGuid = Conversions.ToString(GetDevices.GetDefaultMicCommDevice());
					MySettingsProperty.Settings.SetMicCommOnStart = Conversions.ToString(GetDevices.GetDefaultMicCommDeviceName());
					MySettingsProperty.Settings.Save();
				}
				Log.WriteToLog("Setting " + MySettingsProperty.Settings.SetMicCommOnStart + " as default mic communication device");
				PolicyConfigClient policyConfigClient = new PolicyConfigClient();
				policyConfigClient.SetDefaultEndpoint(MySettingsProperty.Settings.SetMicCommOnStartGuid, ERole.eCommunications);
				if (Globals.dbg)
				{
					Log.WriteToLog("Exiting SetDefaultMicCommDeviceOnStart");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("SetDefaultMicCommDeviceOnStart: " + ex2.Message);
			FrmMain.fmain.AddToListboxAndScroll("Could not change default mic communications device: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetFallbackAudioDevice()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering SetFallbackAudioDevice");
		}
		try
		{
			if ((Operators.CompareString(MySettingsProperty.Settings.DefaultAudio, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.DefaultAudio.ToString()) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultAudioGuid, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.SystemDefaultAudioGuid.ToString()))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Setting '" + MySettingsProperty.Settings.DefaultAudio + "' " + MySettingsProperty.Settings.SystemDefaultAudioGuid.Replace("{", "[").Replace("}", "]") + " as default audio device");
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
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Log.WriteToLog("Could not set '" + MySettingsProperty.Settings.DefaultAudio + "' as default audio device: " + ex2.Message);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				Log.WriteToLog("Could not set fallback audio device, no device selected");
				FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio device, no device selected");
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting SetFallbackAudioDevice");
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteToLog("SetFallbackAudioDevice: " + ex4.Message);
			FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio device: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetFallbackMicDevice()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering SetFallbackMicDevice");
		}
		try
		{
			if ((Operators.CompareString(MySettingsProperty.Settings.DefaultMic, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.DefaultMic.ToString()) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultMicGuid, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.SystemDefaultMicGuid.ToString()))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Setting '" + MySettingsProperty.Settings.DefaultMic + "' " + MySettingsProperty.Settings.SystemDefaultMicGuid.Replace("{", "[").Replace("}", "]") + " as default microphone device");
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
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Log.WriteToLog("Could not set '" + MySettingsProperty.Settings.DefaultMic + "' as default microphone device: " + ex2.Message);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				Log.WriteToLog("Could not set fallback microphone device, no device selected");
				FrmMain.fmain.AddToListboxAndScroll("Could not set fallback microphone device, no device selected");
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting SetFallbackMicDevice");
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteToLog("SetFallbackMicDevice: " + ex4.Message);
			FrmMain.fmain.AddToListboxAndScroll("Could not set fallback microphone device: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetFallbackCommMicDevice()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering SetFallbackCommDevice");
		}
		try
		{
			if ((Operators.CompareString(MySettingsProperty.Settings.DefaultComm, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.DefaultComm.ToString()) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultCommGuid, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.SystemDefaultCommGuid.ToString()))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Setting '" + MySettingsProperty.Settings.DefaultComm + "' " + MySettingsProperty.Settings.SystemDefaultCommGuid.Replace("{", "[").Replace("}", "]") + " as default mic communications device");
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
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Log.WriteToLog("Could not set '" + MySettingsProperty.Settings.DefaultComm + "' as default mic communications device: " + ex2.Message);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				Log.WriteToLog("Could not set fallback communications mic device, no device selected");
				FrmMain.fmain.AddToListboxAndScroll("Could not set fallback mic ommunications device, no device selected");
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting SetFallbackCommDevice");
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteToLog("SetFallbackCommDevice: " + ex4.Message);
			FrmMain.fmain.AddToListboxAndScroll("Could not set fallback mic communications device: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void SetFallbackCommAudioDevice()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering SetFallbackCommDevice");
		}
		try
		{
			if ((Operators.CompareString(MySettingsProperty.Settings.DefaultCommAudio, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.DefaultCommAudio.ToString()) & (Operators.CompareString(MySettingsProperty.Settings.SystemDefaultCommAudioGuid, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.SystemDefaultCommAudioGuid.ToString()))
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Setting '" + MySettingsProperty.Settings.DefaultCommAudio + "' " + MySettingsProperty.Settings.SystemDefaultCommAudioGuid.Replace("{", "[").Replace("}", "]") + " as default audio communications device");
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
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Log.WriteToLog("Could not set '" + MySettingsProperty.Settings.DefaultCommAudio + "' as default audio communications device: " + ex2.Message);
					ProjectData.ClearProjectError();
				}
			}
			else
			{
				Log.WriteToLog("Could not set fallback audio communications device, no device selected");
				FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio communications device, no device selected");
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting SetFallbackCommDevice");
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteToLog("SetFallbackCommDevice: " + ex4.Message);
			FrmMain.fmain.AddToListboxAndScroll("Could not set fallback audio communications device: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
	}
}
