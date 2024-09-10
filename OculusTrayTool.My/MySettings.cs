using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool.My;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
internal sealed class MySettings : ApplicationSettingsBase
{
	private static MySettings defaultInstance = (MySettings)SettingsBase.Synchronized(new MySettings());

	private static bool addedHandler;

	private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());

	public static MySettings Default
	{
		get
		{
			if (!addedHandler)
			{
				object obj = addedHandlerLockObject;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					if (!addedHandler)
					{
						MyProject.Application.Shutdown += [DebuggerNonUserCode] [EditorBrowsable(EditorBrowsableState.Advanced)] (object sender, EventArgs e) =>
						{
							if (MyProject.Application.SaveMySettingsOnExit)
							{
								MySettingsProperty.Settings.Save();
							}
						};
						addedHandler = true;
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
			return defaultInstance;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("10, 10")]
	public Point WindowLocation
	{
		get
		{
			object obj = this["WindowLocation"];
			return (obj != null) ? ((Point)obj) : default(Point);
		}
		set
		{
			this["WindowLocation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("computer, start listening;speech on")]
	public string StartVoice
	{
		get
		{
			return Conversions.ToString(this["StartVoice"]);
		}
		set
		{
			this["StartVoice"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("computer, stop listening;speech off")]
	public string StopVoice
	{
		get
		{
			return Conversions.ToString(this["StopVoice"]);
		}
		set
		{
			this["StopVoice"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("enable spacewarp")]
	public string EnableASW
	{
		get
		{
			return Conversions.ToString(this["EnableASW"]);
		}
		set
		{
			this["EnableASW"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("disable spacewarp")]
	public string DisableASW
	{
		get
		{
			return Conversions.ToString(this["DisableASW"]);
		}
		set
		{
			this["DisableASW"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("show pixel density; show super sampling")]
	public string ShowPD
	{
		get
		{
			return Conversions.ToString(this["ShowPD"]);
		}
		set
		{
			this["ShowPD"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("show performance")]
	public string ShowPerf
	{
		get
		{
			return Conversions.ToString(this["ShowPerf"]);
		}
		set
		{
			this["ShowPerf"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("close overlay")]
	public string Close
	{
		get
		{
			return Conversions.ToString(this["Close"]);
		}
		set
		{
			this["Close"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("set pixel density;set super sampling")]
	public string SetPD
	{
		get
		{
			return Conversions.ToString(this["SetPD"]);
		}
		set
		{
			this["SetPD"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("show spacewarp")]
	public string ShowASW
	{
		get
		{
			return Conversions.ToString(this["ShowASW"]);
		}
		set
		{
			this["ShowASW"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("663, 492")]
	public Size ScanDialogSize
	{
		get
		{
			object obj = this["ScanDialogSize"];
			return (obj != null) ? ((Size)obj) : default(Size);
		}
		set
		{
			this["ScanDialogSize"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("613, 580")]
	public Size VoiceDialogSize
	{
		get
		{
			object obj = this["VoiceDialogSize"];
			return (obj != null) ? ((Size)obj) : default(Size);
		}
		set
		{
			this["VoiceDialogSize"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string OldCPUID
	{
		get
		{
			return Conversions.ToString(this["OldCPUID"]);
		}
		set
		{
			this["OldCPUID"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("10, 10")]
	public Point ScanWindowLocation
	{
		get
		{
			object obj = this["ScanWindowLocation"];
			return (obj != null) ? ((Point)obj) : default(Point);
		}
		set
		{
			this["ScanWindowLocation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("10, 10")]
	public Point ProfilesWindowLocation
	{
		get
		{
			object obj = this["ProfilesWindowLocation"];
			return (obj != null) ? ((Point)obj) : default(Point);
		}
		set
		{
			this["ProfilesWindowLocation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("10, 10")]
	public Point VoiceWindowLocation
	{
		get
		{
			object obj = this["VoiceWindowLocation"];
			return (obj != null) ? ((Point)obj) : default(Point);
		}
		set
		{
			this["VoiceWindowLocation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("10, 10")]
	public Point ReadmeWindowLocation
	{
		get
		{
			object obj = this["ReadmeWindowLocation"];
			return (obj != null) ? ((Point)obj) : default(Point);
		}
		set
		{
			this["ReadmeWindowLocation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("lock framerate")]
	public string LockASWOn
	{
		get
		{
			return Conversions.ToString(this["LockASWOn"]);
		}
		set
		{
			this["LockASWOn"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("507, 379")]
	public Size WindowSize
	{
		get
		{
			object obj = this["WindowSize"];
			return (obj != null) ? ((Size)obj) : default(Size);
		}
		set
		{
			this["WindowSize"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0, 0")]
	public Point LogIconLocation
	{
		get
		{
			object obj = this["LogIconLocation"];
			return (obj != null) ? ((Point)obj) : default(Point);
		}
		set
		{
			this["LogIconLocation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("show latency timing")]
	public string ShowLatency
	{
		get
		{
			return Conversions.ToString(this["ShowLatency"]);
		}
		set
		{
			this["ShowLatency"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("show application timing")]
	public string ShowApplicationRender
	{
		get
		{
			return Conversions.ToString(this["ShowApplicationRender"]);
		}
		set
		{
			this["ShowApplicationRender"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("show compositor timing")]
	public string ShowCompositorRender
	{
		get
		{
			return Conversions.ToString(this["ShowCompositorRender"]);
		}
		set
		{
			this["ShowCompositorRender"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("show version")]
	public string ShowVersion
	{
		get
		{
			return Conversions.ToString(this["ShowVersion"]);
		}
		set
		{
			this["ShowVersion"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("946, 584")]
	public Size ProfilesWindowSize
	{
		get
		{
			object obj = this["ProfilesWindowSize"];
			return (obj != null) ? ((Size)obj) : default(Size);
		}
		set
		{
			this["ProfilesWindowSize"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowConfirmRestart
	{
		get
		{
			return Conversions.ToBoolean(this["ShowConfirmRestart"]);
		}
		set
		{
			this["ShowConfirmRestart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("start steam;launch steam")]
	public string LaunchSteam
	{
		get
		{
			return Conversions.ToString(this["LaunchSteam"]);
		}
		set
		{
			this["LaunchSteam"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string AssetsPath
	{
		get
		{
			return Conversions.ToString(this["AssetsPath"]);
		}
		set
		{
			this["AssetsPath"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool StartVoiceEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["StartVoiceEnabled"]);
		}
		set
		{
			this["StartVoiceEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool StopVoiceEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["StopVoiceEnabled"]);
		}
		set
		{
			this["StopVoiceEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool EnableASWEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["EnableASWEnabled"]);
		}
		set
		{
			this["EnableASWEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool DisableASWEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["DisableASWEnabled"]);
		}
		set
		{
			this["DisableASWEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowPDEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["ShowPDEnabled"]);
		}
		set
		{
			this["ShowPDEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowPerfEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["ShowPerfEnabled"]);
		}
		set
		{
			this["ShowPerfEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool CloseEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["CloseEnabled"]);
		}
		set
		{
			this["CloseEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool SetPDEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["SetPDEnabled"]);
		}
		set
		{
			this["SetPDEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowASWEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["ShowASWEnabled"]);
		}
		set
		{
			this["ShowASWEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowLatencyEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["ShowLatencyEnabled"]);
		}
		set
		{
			this["ShowLatencyEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowApplicationRenderEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["ShowApplicationRenderEnabled"]);
		}
		set
		{
			this["ShowApplicationRenderEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowCompositorRenderEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["ShowCompositorRenderEnabled"]);
		}
		set
		{
			this["ShowCompositorRenderEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowVersionEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["ShowVersionEnabled"]);
		}
		set
		{
			this["ShowVersionEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool LaunchSteamEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["LaunchSteamEnabled"]);
		}
		set
		{
			this["LaunchSteamEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool LockASWOnEnabled
	{
		get
		{
			return Conversions.ToBoolean(this["LockASWOnEnabled"]);
		}
		set
		{
			this["LockASWOnEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("9")]
	public float FontSize
	{
		get
		{
			return Conversions.ToSingle(this["FontSize"]);
		}
		set
		{
			this["FontSize"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("507, 411")]
	public Size GuiSize
	{
		get
		{
			object obj = this["GuiSize"];
			return (obj != null) ? ((Size)obj) : default(Size);
		}
		set
		{
			this["GuiSize"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool StartWithWindows
	{
		get
		{
			return Conversions.ToBoolean(this["StartWithWindows"]);
		}
		set
		{
			this["StartWithWindows"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool RunDebug
	{
		get
		{
			return Conversions.ToBoolean(this["RunDebug"]);
		}
		set
		{
			this["RunDebug"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool VoiceConfirmProfile
	{
		get
		{
			return Conversions.ToBoolean(this["VoiceConfirmProfile"]);
		}
		set
		{
			this["VoiceConfirmProfile"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowStillRunning
	{
		get
		{
			return Conversions.ToBoolean(this["ShowStillRunning"]);
		}
		set
		{
			this["ShowStillRunning"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool SendHomeToTray
	{
		get
		{
			return Conversions.ToBoolean(this["SendHomeToTray"]);
		}
		set
		{
			this["SendHomeToTray"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool SendHomeToTrayOnStart
	{
		get
		{
			return Conversions.ToBoolean(this["SendHomeToTrayOnStart"]);
		}
		set
		{
			this["SendHomeToTrayOnStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowHomeToast
	{
		get
		{
			return Conversions.ToBoolean(this["ShowHomeToast"]);
		}
		set
		{
			this["ShowHomeToast"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool StartMinimized
	{
		get
		{
			return Conversions.ToBoolean(this["StartMinimized"]);
		}
		set
		{
			this["StartMinimized"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int StartHomeDelay
	{
		get
		{
			return Conversions.ToInteger(this["StartHomeDelay"]);
		}
		set
		{
			this["StartHomeDelay"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool UseVoiceCommands
	{
		get
		{
			return Conversions.ToBoolean(this["UseVoiceCommands"]);
		}
		set
		{
			this["UseVoiceCommands"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool DisableFrescoPower
	{
		get
		{
			return Conversions.ToBoolean(this["DisableFrescoPower"]);
		}
		set
		{
			this["DisableFrescoPower"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string LibraryPath
	{
		get
		{
			return Conversions.ToString(this["LibraryPath"]);
		}
		set
		{
			this["LibraryPath"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public string PPDPStartup
	{
		get
		{
			return Conversions.ToString(this["PPDPStartup"]);
		}
		set
		{
			this["PPDPStartup"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Not Used")]
	public string PowerPlanStart
	{
		get
		{
			return Conversions.ToString(this["PowerPlanStart"]);
		}
		set
		{
			this["PowerPlanStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool SpoofCPU
	{
		get
		{
			return Conversions.ToBoolean(this["SpoofCPU"]);
		}
		set
		{
			this["SpoofCPU"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool StopOVR
	{
		get
		{
			return Conversions.ToBoolean(this["StopOVR"]);
		}
		set
		{
			this["StopOVR"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool StartHomeOnServiceStart
	{
		get
		{
			return Conversions.ToBoolean(this["StartHomeOnServiceStart"]);
		}
		set
		{
			this["StartHomeOnServiceStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string OculusPath
	{
		get
		{
			return Conversions.ToString(this["OculusPath"]);
		}
		set
		{
			this["OculusPath"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool StartOVR
	{
		get
		{
			return Conversions.ToBoolean(this["StartOVR"]);
		}
		set
		{
			this["StartOVR"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool OVRServerPriority
	{
		get
		{
			return Conversions.ToBoolean(this["OVRServerPriority"]);
		}
		set
		{
			this["OVRServerPriority"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool StartHomeOnToolStart
	{
		get
		{
			return Conversions.ToBoolean(this["StartHomeOnToolStart"]);
		}
		set
		{
			this["StartHomeOnToolStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool CloseHomeOnExit
	{
		get
		{
			return Conversions.ToBoolean(this["CloseHomeOnExit"]);
		}
		set
		{
			this["CloseHomeOnExit"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool HideAltTab
	{
		get
		{
			return Conversions.ToBoolean(this["HideAltTab"]);
		}
		set
		{
			this["HideAltTab"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string DefaultAudio
	{
		get
		{
			return Conversions.ToString(this["DefaultAudio"]);
		}
		set
		{
			this["DefaultAudio"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string DefaultMic
	{
		get
		{
			return Conversions.ToString(this["DefaultMic"]);
		}
		set
		{
			this["DefaultMic"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool SetRiftAsDefault
	{
		get
		{
			return Conversions.ToBoolean(this["SetRiftAsDefault"]);
		}
		set
		{
			this["SetRiftAsDefault"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int SetRiftAudioDefault
	{
		get
		{
			return Conversions.ToInteger(this["SetRiftAudioDefault"]);
		}
		set
		{
			this["SetRiftAudioDefault"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int SetRiftMicDefault
	{
		get
		{
			return Conversions.ToInteger(this["SetRiftMicDefault"]);
		}
		set
		{
			this["SetRiftMicDefault"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool UseLocalDebugTool
	{
		get
		{
			return Conversions.ToBoolean(this["UseLocalDebugTool"]);
		}
		set
		{
			this["UseLocalDebugTool"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool UseHotKeys
	{
		get
		{
			return Conversions.ToBoolean(this["UseHotKeys"]);
		}
		set
		{
			this["UseHotKeys"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int ASW
	{
		get
		{
			return Conversions.ToInteger(this["ASW"]);
		}
		set
		{
			this["ASW"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool CloseOnX
	{
		get
		{
			return Conversions.ToBoolean(this["CloseOnX"]);
		}
		set
		{
			this["CloseOnX"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool NoHome
	{
		get
		{
			return Conversions.ToBoolean(this["NoHome"]);
		}
		set
		{
			this["NoHome"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool DisableSensorPower
	{
		get
		{
			return Conversions.ToBoolean(this["DisableSensorPower"]);
		}
		set
		{
			this["DisableSensorPower"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Not Used")]
	public string PowerPlanExit
	{
		get
		{
			return Conversions.ToString(this["PowerPlanExit"]);
		}
		set
		{
			this["PowerPlanExit"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("10, 10")]
	public Point LibraryWindowLocation
	{
		get
		{
			object obj = this["LibraryWindowLocation"];
			return (obj != null) ? ((Point)obj) : default(Point);
		}
		set
		{
			this["LibraryWindowLocation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("1040, 623")]
	public Size LibraryWindowSize
	{
		get
		{
			object obj = this["LibraryWindowSize"];
			return (obj != null) ? ((Size)obj) : default(Size);
		}
		set
		{
			this["LibraryWindowSize"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int ApplyPowerPlan
	{
		get
		{
			return Conversions.ToInteger(this["ApplyPowerPlan"]);
		}
		set
		{
			this["ApplyPowerPlan"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool UpgradeRequired
	{
		get
		{
			return Conversions.ToBoolean(this["UpgradeRequired"]);
		}
		set
		{
			this["UpgradeRequired"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string RiftAudioGuid
	{
		get
		{
			return Conversions.ToString(this["RiftAudioGuid"]);
		}
		set
		{
			this["RiftAudioGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string RiftMicGuid
	{
		get
		{
			return Conversions.ToString(this["RiftMicGuid"]);
		}
		set
		{
			this["RiftMicGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SystemDefaultMicGuid
	{
		get
		{
			return Conversions.ToString(this["SystemDefaultMicGuid"]);
		}
		set
		{
			this["SystemDefaultMicGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SystemDefaultAudioGuid
	{
		get
		{
			return Conversions.ToString(this["SystemDefaultAudioGuid"]);
		}
		set
		{
			this["SystemDefaultAudioGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool DisableCallback
	{
		get
		{
			return Conversions.ToBoolean(this["DisableCallback"]);
		}
		set
		{
			this["DisableCallback"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool ShowMicNotDefaultWarning
	{
		get
		{
			return Conversions.ToBoolean(this["ShowMicNotDefaultWarning"]);
		}
		set
		{
			this["ShowMicNotDefaultWarning"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("60")]
	public int Confidence
	{
		get
		{
			return Conversions.ToInteger(this["Confidence"]);
		}
		set
		{
			this["Confidence"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool StartAppwatcherOnStart
	{
		get
		{
			return Conversions.ToBoolean(this["StartAppwatcherOnStart"]);
		}
		set
		{
			this["StartAppwatcherOnStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool DBCheck
	{
		get
		{
			return Conversions.ToBoolean(this["DBCheck"]);
		}
		set
		{
			this["DBCheck"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("1")]
	public int DbgToolMethod
	{
		get
		{
			return Conversions.ToInteger(this["DbgToolMethod"]);
		}
		set
		{
			this["DbgToolMethod"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("10, 10")]
	public Point SteamWindowLocation
	{
		get
		{
			object obj = this["SteamWindowLocation"];
			return (obj != null) ? ((Point)obj) : default(Point);
		}
		set
		{
			this["SteamWindowLocation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("652, 473")]
	public Size SteamWindowSize
	{
		get
		{
			object obj = this["SteamWindowSize"];
			return (obj != null) ? ((Size)obj) : default(Size);
		}
		set
		{
			this["SteamWindowSize"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool AutomaticUpdateCheck
	{
		get
		{
			return Conversions.ToBoolean(this["AutomaticUpdateCheck"]);
		}
		set
		{
			this["AutomaticUpdateCheck"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public string FOVh
	{
		get
		{
			return Conversions.ToString(this["FOVh"]);
		}
		set
		{
			this["FOVh"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public int HomelessEnabled
	{
		get
		{
			return Conversions.ToInteger(this["HomelessEnabled"]);
		}
		set
		{
			this["HomelessEnabled"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0 0 0 ")]
	public string HomlessColor
	{
		get
		{
			return Conversions.ToString(this["HomlessColor"]);
		}
		set
		{
			this["HomlessColor"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("None")]
	public string HomelessMusic
	{
		get
		{
			return Conversions.ToString(this["HomelessMusic"]);
		}
		set
		{
			this["HomelessMusic"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("500")]
	public int HomelessVolume
	{
		get
		{
			return Conversions.ToInteger(this["HomelessVolume"]);
		}
		set
		{
			this["HomelessVolume"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string HomelessHash
	{
		get
		{
			return Conversions.ToString(this["HomelessHash"]);
		}
		set
		{
			this["HomelessHash"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string HomeHash
	{
		get
		{
			return Conversions.ToString(this["HomeHash"]);
		}
		set
		{
			this["HomeHash"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool HomelessAutoPatch
	{
		get
		{
			return Conversions.ToBoolean(this["HomelessAutoPatch"]);
		}
		set
		{
			this["HomelessAutoPatch"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool MirrorHome
	{
		get
		{
			return Conversions.ToBoolean(this["MirrorHome"]);
		}
		set
		{
			this["MirrorHome"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("1")]
	public int USBSuspend
	{
		get
		{
			return Conversions.ToInteger(this["USBSuspend"]);
		}
		set
		{
			this["USBSuspend"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool RestartServiceAfterSleep
	{
		get
		{
			return Conversions.ToBoolean(this["RestartServiceAfterSleep"]);
		}
		set
		{
			this["RestartServiceAfterSleep"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Next HUD,None,LEFT;Previous HUD,None,RIGHT;Next ASW Mode,None,UP;Previous ASW Mode,None,DOWN")]
	public string HotKeyCombos
	{
		get
		{
			return Conversions.ToString(this["HotKeyCombos"]);
		}
		set
		{
			this["HotKeyCombos"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool HotKeyVoiceConfirmation
	{
		get
		{
			return Conversions.ToBoolean(this["HotKeyVoiceConfirmation"]);
		}
		set
		{
			this["HotKeyVoiceConfirmation"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool VoiceActivationVoiceContinous
	{
		get
		{
			return Conversions.ToBoolean(this["VoiceActivationVoiceContinous"]);
		}
		set
		{
			this["VoiceActivationVoiceContinous"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool VoiceActivationVoiceRepeated
	{
		get
		{
			return Conversions.ToBoolean(this["VoiceActivationVoiceRepeated"]);
		}
		set
		{
			this["VoiceActivationVoiceRepeated"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool VoiceActivationKeyContinous
	{
		get
		{
			return Conversions.ToBoolean(this["VoiceActivationKeyContinous"]);
		}
		set
		{
			this["VoiceActivationKeyContinous"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool VoiceActivationKeyPush
	{
		get
		{
			return Conversions.ToBoolean(this["VoiceActivationKeyPush"]);
		}
		set
		{
			this["VoiceActivationKeyPush"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public string SetFallbackMicDefaultCommDev
	{
		get
		{
			return Conversions.ToString(this["SetFallbackMicDefaultCommDev"]);
		}
		set
		{
			this["SetFallbackMicDefaultCommDev"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string KeyboardVoiceActivationKey
	{
		get
		{
			return Conversions.ToString(this["KeyboardVoiceActivationKey"]);
		}
		set
		{
			this["KeyboardVoiceActivationKey"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string JoystickVoiceActivationButton
	{
		get
		{
			return Conversions.ToString(this["JoystickVoiceActivationButton"]);
		}
		set
		{
			this["JoystickVoiceActivationButton"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string JoystickDeviceName
	{
		get
		{
			return Conversions.ToString(this["JoystickDeviceName"]);
		}
		set
		{
			this["JoystickDeviceName"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool JoystickActivationKeyContinous
	{
		get
		{
			return Conversions.ToBoolean(this["JoystickActivationKeyContinous"]);
		}
		set
		{
			this["JoystickActivationKeyContinous"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool JoystickActivationKeyPush
	{
		get
		{
			return Conversions.ToBoolean(this["JoystickActivationKeyPush"]);
		}
		set
		{
			this["JoystickActivationKeyPush"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool DisableVoiceControlAudioFeedback
	{
		get
		{
			return Conversions.ToBoolean(this["DisableVoiceControlAudioFeedback"]);
		}
		set
		{
			this["DisableVoiceControlAudioFeedback"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string DefaultComm
	{
		get
		{
			return Conversions.ToString(this["DefaultComm"]);
		}
		set
		{
			this["DefaultComm"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SystemDefaultCommGuid
	{
		get
		{
			return Conversions.ToString(this["SystemDefaultCommGuid"]);
		}
		set
		{
			this["SystemDefaultCommGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SystemDefaultCommAudioGuid
	{
		get
		{
			return Conversions.ToString(this["SystemDefaultCommAudioGuid"]);
		}
		set
		{
			this["SystemDefaultCommAudioGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string DefaultCommAudio
	{
		get
		{
			return Conversions.ToString(this["DefaultCommAudio"]);
		}
		set
		{
			this["DefaultCommAudio"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string PowerPlanCurrent
	{
		get
		{
			return Conversions.ToString(this["PowerPlanCurrent"]);
		}
		set
		{
			this["PowerPlanCurrent"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SetAudioOnStart
	{
		get
		{
			return Conversions.ToString(this["SetAudioOnStart"]);
		}
		set
		{
			this["SetAudioOnStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SetMicOnStart
	{
		get
		{
			return Conversions.ToString(this["SetMicOnStart"]);
		}
		set
		{
			this["SetMicOnStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SetAudioCommOnStart
	{
		get
		{
			return Conversions.ToString(this["SetAudioCommOnStart"]);
		}
		set
		{
			this["SetAudioCommOnStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SetMicCommOnStart
	{
		get
		{
			return Conversions.ToString(this["SetMicCommOnStart"]);
		}
		set
		{
			this["SetMicCommOnStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SetAudioOnStartGuid
	{
		get
		{
			return Conversions.ToString(this["SetAudioOnStartGuid"]);
		}
		set
		{
			this["SetAudioOnStartGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SetMicOnStartGuid
	{
		get
		{
			return Conversions.ToString(this["SetMicOnStartGuid"]);
		}
		set
		{
			this["SetMicOnStartGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SetAudioCommOnStartGuid
	{
		get
		{
			return Conversions.ToString(this["SetAudioCommOnStartGuid"]);
		}
		set
		{
			this["SetAudioCommOnStartGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string SetMicCommOnStartGuid
	{
		get
		{
			return Conversions.ToString(this["SetMicCommOnStartGuid"]);
		}
		set
		{
			this["SetMicCommOnStartGuid"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public string FOVv
	{
		get
		{
			return Conversions.ToString(this["FOVv"]);
		}
		set
		{
			this["FOVv"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("True")]
	public bool AdaptiveGPUScaling
	{
		get
		{
			return Conversions.ToBoolean(this["AdaptiveGPUScaling"]);
		}
		set
		{
			this["AdaptiveGPUScaling"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("2000")]
	public int SleepAfterServiceStart
	{
		get
		{
			return Conversions.ToInteger(this["SleepAfterServiceStart"]);
		}
		set
		{
			this["SleepAfterServiceStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("2000")]
	public string SleepAfterHomeStart
	{
		get
		{
			return Conversions.ToString(this["SleepAfterHomeStart"]);
		}
		set
		{
			this["SleepAfterHomeStart"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string DesktopResolution
	{
		get
		{
			return Conversions.ToString(this["DesktopResolution"]);
		}
		set
		{
			this["DesktopResolution"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("Normal")]
	public string OVRSrvPrio
	{
		get
		{
			return Conversions.ToString(this["OVRSrvPrio"]);
		}
		set
		{
			this["OVRSrvPrio"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public string ForceMipmap
	{
		get
		{
			return Conversions.ToString(this["ForceMipmap"]);
		}
		set
		{
			this["ForceMipmap"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("0")]
	public string OffsetMipmap
	{
		get
		{
			return Conversions.ToString(this["OffsetMipmap"]);
		}
		set
		{
			this["OffsetMipmap"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool StopOVRHome
	{
		get
		{
			return Conversions.ToBoolean(this["StopOVRHome"]);
		}
		set
		{
			this["StopOVRHome"] = value;
		}
	}

	[DebuggerNonUserCode]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	private static void AutoSaveSettings(object sender, EventArgs e)
	{
		if (MyProject.Application.SaveMySettingsOnExit)
		{
			MySettingsProperty.Settings.Save();
		}
	}
}
