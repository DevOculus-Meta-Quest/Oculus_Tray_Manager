

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable disable
namespace MetaQuestTrayTool.My
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal sealed class MySettings : ApplicationSettingsBase
  {
    private static MySettings defaultInstance = (MySettings) SettingsBase.Synchronized((SettingsBase) new MySettings());

    public static MySettings Default
    {
      get
      {
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
        object obj = this[nameof (WindowLocation)];
        return obj != null ? (Point) obj : new Point();
      }
      set => this[nameof (WindowLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("computer, start listening;speech on")]
    public string StartVoice
    {
      get => Convert.ToString(this[nameof (StartVoice)]);
      set => this[nameof (StartVoice)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("computer, stop listening;speech off")]
    public string StopVoice
    {
      get => Convert.ToString(this[nameof (StopVoice)]);
      set => this[nameof (StopVoice)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("enable spacewarp")]
    public string EnableASW
    {
      get => Convert.ToString(this[nameof (EnableASW)]);
      set => this[nameof (EnableASW)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("disable spacewarp")]
    public string DisableASW
    {
      get => Convert.ToString(this[nameof (DisableASW)]);
      set => this[nameof (DisableASW)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show pixel density; show super sampling")]
    public string ShowPD
    {
      get => Convert.ToString(this[nameof (ShowPD)]);
      set => this[nameof (ShowPD)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show performance")]
    public string ShowPerf
    {
      get => Convert.ToString(this[nameof (ShowPerf)]);
      set => this[nameof (ShowPerf)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("close overlay")]
    public string Close
    {
      get => Convert.ToString(this[nameof (Close)]);
      set => this[nameof (Close)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("set pixel density;set super sampling")]
    public string SetPD
    {
      get => Convert.ToString(this[nameof (SetPD)]);
      set => this[nameof (SetPD)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show spacewarp")]
    public string ShowASW
    {
      get => Convert.ToString(this[nameof (ShowASW)]);
      set => this[nameof (ShowASW)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("663, 492")]
    public Size ScanDialogSize
    {
      get
      {
        object obj = this[nameof (ScanDialogSize)];
        return obj != null ? (Size) obj : new Size();
      }
      set => this[nameof (ScanDialogSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("613, 580")]
    public Size VoiceDialogSize
    {
      get
      {
        object obj = this[nameof (VoiceDialogSize)];
        return obj != null ? (Size) obj : new Size();
      }
      set => this[nameof (VoiceDialogSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string OldCPUID
    {
      get => Convert.ToString(this[nameof (OldCPUID)]);
      set => this[nameof (OldCPUID)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10, 10")]
    public Point ScanWindowLocation
    {
      get
      {
        object obj = this[nameof (ScanWindowLocation)];
        return obj != null ? (Point) obj : new Point();
      }
      set => this[nameof (ScanWindowLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10, 10")]
    public Point ProfilesWindowLocation
    {
      get
      {
        object obj = this[nameof (ProfilesWindowLocation)];
        return obj != null ? (Point) obj : new Point();
      }
      set => this[nameof (ProfilesWindowLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10, 10")]
    public Point VoiceWindowLocation
    {
      get
      {
        object obj = this[nameof (VoiceWindowLocation)];
        return obj != null ? (Point) obj : new Point();
      }
      set => this[nameof (VoiceWindowLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10, 10")]
    public Point ReadmeWindowLocation
    {
      get
      {
        object obj = this[nameof (ReadmeWindowLocation)];
        return obj != null ? (Point) obj : new Point();
      }
      set => this[nameof (ReadmeWindowLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("lock framerate")]
    public string LockASWOn
    {
      get => Convert.ToString(this[nameof (LockASWOn)]);
      set => this[nameof (LockASWOn)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("507, 379")]
    public Size WindowSize
    {
      get
      {
        object obj = this[nameof (WindowSize)];
        return obj != null ? (Size) obj : new Size();
      }
      set => this[nameof (WindowSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0, 0")]
    public Point LogIconLocation
    {
      get
      {
        object obj = this[nameof (LogIconLocation)];
        return obj != null ? (Point) obj : new Point();
      }
      set => this[nameof (LogIconLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show latency timing")]
    public string ShowLatency
    {
      get => Convert.ToString(this[nameof (ShowLatency)]);
      set => this[nameof (ShowLatency)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show application timing")]
    public string ShowApplicationRender
    {
      get => Convert.ToString(this[nameof (ShowApplicationRender)]);
      set => this[nameof (ShowApplicationRender)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show compositor timing")]
    public string ShowCompositorRender
    {
      get => Convert.ToString(this[nameof (ShowCompositorRender)]);
      set => this[nameof (ShowCompositorRender)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show version")]
    public string ShowVersion
    {
      get => Convert.ToString(this[nameof (ShowVersion)]);
      set => this[nameof (ShowVersion)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("946, 584")]
    public Size ProfilesWindowSize
    {
      get
      {
        object obj = this[nameof (ProfilesWindowSize)];
        return obj != null ? (Size) obj : new Size();
      }
      set => this[nameof (ProfilesWindowSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowConfirmRestart
    {
      get => Convert.ToBoolean(this[nameof (ShowConfirmRestart)]);
      set => this[nameof (ShowConfirmRestart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("start steam;launch steam")]
    public string LaunchSteam
    {
      get => Convert.ToString(this[nameof (LaunchSteam)]);
      set => this[nameof (LaunchSteam)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string AssetsPath
    {
      get => Convert.ToString(this[nameof (AssetsPath)]);
      set => this[nameof (AssetsPath)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool StartVoiceEnabled
    {
      get => Convert.ToBoolean(this[nameof (StartVoiceEnabled)]);
      set => this[nameof (StartVoiceEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool StopVoiceEnabled
    {
      get => Convert.ToBoolean(this[nameof (StopVoiceEnabled)]);
      set => this[nameof (StopVoiceEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool EnableASWEnabled
    {
      get => Convert.ToBoolean(this[nameof (EnableASWEnabled)]);
      set => this[nameof (EnableASWEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool DisableASWEnabled
    {
      get => Convert.ToBoolean(this[nameof (DisableASWEnabled)]);
      set => this[nameof (DisableASWEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowPDEnabled
    {
      get => Convert.ToBoolean(this[nameof (ShowPDEnabled)]);
      set => this[nameof (ShowPDEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowPerfEnabled
    {
      get => Convert.ToBoolean(this[nameof (ShowPerfEnabled)]);
      set => this[nameof (ShowPerfEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool CloseEnabled
    {
      get => Convert.ToBoolean(this[nameof (CloseEnabled)]);
      set => this[nameof (CloseEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool SetPDEnabled
    {
      get => Convert.ToBoolean(this[nameof (SetPDEnabled)]);
      set => this[nameof (SetPDEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowASWEnabled
    {
      get => Convert.ToBoolean(this[nameof (ShowASWEnabled)]);
      set => this[nameof (ShowASWEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowLatencyEnabled
    {
      get => Convert.ToBoolean(this[nameof (ShowLatencyEnabled)]);
      set => this[nameof (ShowLatencyEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowApplicationRenderEnabled
    {
      get => Convert.ToBoolean(this[nameof (ShowApplicationRenderEnabled)]);
      set => this[nameof (ShowApplicationRenderEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowCompositorRenderEnabled
    {
      get => Convert.ToBoolean(this[nameof (ShowCompositorRenderEnabled)]);
      set => this[nameof (ShowCompositorRenderEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowVersionEnabled
    {
      get => Convert.ToBoolean(this[nameof (ShowVersionEnabled)]);
      set => this[nameof (ShowVersionEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool LaunchSteamEnabled
    {
      get => Convert.ToBoolean(this[nameof (LaunchSteamEnabled)]);
      set => this[nameof (LaunchSteamEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool LockASWOnEnabled
    {
      get => Convert.ToBoolean(this[nameof (LockASWOnEnabled)]);
      set => this[nameof (LockASWOnEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("9")]
    public float FontSize
    {
      get => Convert.ToSingle(this[nameof (FontSize)]);
      set => this[nameof (FontSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("507, 411")]
    public Size GuiSize
    {
      get
      {
        object obj = this[nameof (GuiSize)];
        return obj != null ? (Size) obj : new Size();
      }
      set => this[nameof (GuiSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartWithWindows
    {
      get => Convert.ToBoolean(this[nameof (StartWithWindows)]);
      set => this[nameof (StartWithWindows)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool RunDebug
    {
      get => Convert.ToBoolean(this[nameof (RunDebug)]);
      set => this[nameof (RunDebug)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool VoiceConfirmProfile
    {
      get => Convert.ToBoolean(this[nameof (VoiceConfirmProfile)]);
      set => this[nameof (VoiceConfirmProfile)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowStillRunning
    {
      get => Convert.ToBoolean(this[nameof (ShowStillRunning)]);
      set => this[nameof (ShowStillRunning)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendHomeToTray
    {
      get => Convert.ToBoolean(this[nameof (SendHomeToTray)]);
      set => this[nameof (SendHomeToTray)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendHomeToTrayOnStart
    {
      get => Convert.ToBoolean(this[nameof (SendHomeToTrayOnStart)]);
      set => this[nameof (SendHomeToTrayOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowHomeToast
    {
      get => Convert.ToBoolean(this[nameof (ShowHomeToast)]);
      set => this[nameof (ShowHomeToast)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartMinimized
    {
      get => Convert.ToBoolean(this[nameof (StartMinimized)]);
      set => this[nameof (StartMinimized)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int StartHomeDelay
    {
      get => Convert.ToInt32(this[nameof (StartHomeDelay)]);
      set => this[nameof (StartHomeDelay)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool UseVoiceCommands
    {
      get => Convert.ToBoolean(this[nameof (UseVoiceCommands)]);
      set => this[nameof (UseVoiceCommands)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DisableFrescoPower
    {
      get => Convert.ToBoolean(this[nameof (DisableFrescoPower)]);
      set => this[nameof (DisableFrescoPower)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string LibraryPath
    {
      get => Convert.ToString(this[nameof (LibraryPath)]);
      set => this[nameof (LibraryPath)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string PPDPStartup
    {
      get => Convert.ToString(this[nameof (PPDPStartup)]);
      set => this[nameof (PPDPStartup)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Not Used")]
    public string PowerPlanStart
    {
      get => Convert.ToString(this[nameof (PowerPlanStart)]);
      set => this[nameof (PowerPlanStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SpoofCPU
    {
      get => Convert.ToBoolean(this[nameof (SpoofCPU)]);
      set => this[nameof (SpoofCPU)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StopOVR
    {
      get => Convert.ToBoolean(this[nameof (StopOVR)]);
      set => this[nameof (StopOVR)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartHomeOnServiceStart
    {
      get => Convert.ToBoolean(this[nameof (StartHomeOnServiceStart)]);
      set => this[nameof (StartHomeOnServiceStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string MetaPath
    {
      get => Convert.ToString(this[nameof (MetaPath)]);
      set => this[nameof (MetaPath)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartOVR
    {
      get => Convert.ToBoolean(this[nameof (StartOVR)]);
      set => this[nameof (StartOVR)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool OVRServerPriority
    {
      get => Convert.ToBoolean(this[nameof (OVRServerPriority)]);
      set => this[nameof (OVRServerPriority)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartHomeOnToolStart
    {
      get => Convert.ToBoolean(this[nameof (StartHomeOnToolStart)]);
      set => this[nameof (StartHomeOnToolStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool CloseHomeOnExit
    {
      get => Convert.ToBoolean(this[nameof (CloseHomeOnExit)]);
      set => this[nameof (CloseHomeOnExit)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool HideAltTab
    {
      get => Convert.ToBoolean(this[nameof (HideAltTab)]);
      set => this[nameof (HideAltTab)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DefaultAudio
    {
      get => Convert.ToString(this[nameof (DefaultAudio)]);
      set => this[nameof (DefaultAudio)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DefaultMic
    {
      get => Convert.ToString(this[nameof (DefaultMic)]);
      set => this[nameof (DefaultMic)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SetRiftAsDefault
    {
      get => Convert.ToBoolean(this[nameof (SetRiftAsDefault)]);
      set => this[nameof (SetRiftAsDefault)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int SetRiftAudioDefault
    {
      get => Convert.ToInt32(this[nameof (SetRiftAudioDefault)]);
      set => this[nameof (SetRiftAudioDefault)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int SetRiftMicDefault
    {
      get => Convert.ToInt32(this[nameof (SetRiftMicDefault)]);
      set => this[nameof (SetRiftMicDefault)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool UseLocalDebugTool
    {
      get => Convert.ToBoolean(this[nameof (UseLocalDebugTool)]);
      set => this[nameof (UseLocalDebugTool)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool UseHotKeys
    {
      get => Convert.ToBoolean(this[nameof (UseHotKeys)]);
      set => this[nameof (UseHotKeys)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int ASW
    {
      get => Convert.ToInt32(this[nameof (ASW)]);
      set => this[nameof (ASW)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool CloseOnX
    {
      get => Convert.ToBoolean(this[nameof (CloseOnX)]);
      set => this[nameof (CloseOnX)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool NoHome
    {
      get => Convert.ToBoolean(this[nameof (NoHome)]);
      set => this[nameof (NoHome)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DisableSensorPower
    {
      get => Convert.ToBoolean(this[nameof (DisableSensorPower)]);
      set => this[nameof (DisableSensorPower)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Not Used")]
    public string PowerPlanExit
    {
      get => Convert.ToString(this[nameof (PowerPlanExit)]);
      set => this[nameof (PowerPlanExit)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10, 10")]
    public Point LibraryWindowLocation
    {
      get
      {
        object obj = this[nameof (LibraryWindowLocation)];
        return obj != null ? (Point) obj : new Point();
      }
      set => this[nameof (LibraryWindowLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1040, 623")]
    public Size LibraryWindowSize
    {
      get
      {
        object obj = this[nameof (LibraryWindowSize)];
        return obj != null ? (Size) obj : new Size();
      }
      set => this[nameof (LibraryWindowSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int ApplyPowerPlan
    {
      get => Convert.ToInt32(this[nameof (ApplyPowerPlan)]);
      set => this[nameof (ApplyPowerPlan)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool UpgradeRequired
    {
      get => Convert.ToBoolean(this[nameof (UpgradeRequired)]);
      set => this[nameof (UpgradeRequired)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string RiftAudioGuid
    {
      get => Convert.ToString(this[nameof (RiftAudioGuid)]);
      set => this[nameof (RiftAudioGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string RiftMicGuid
    {
      get => Convert.ToString(this[nameof (RiftMicGuid)]);
      set => this[nameof (RiftMicGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SystemDefaultMicGuid
    {
      get => Convert.ToString(this[nameof (SystemDefaultMicGuid)]);
      set => this[nameof (SystemDefaultMicGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SystemDefaultAudioGuid
    {
      get => Convert.ToString(this[nameof (SystemDefaultAudioGuid)]);
      set => this[nameof (SystemDefaultAudioGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DisableCallback
    {
      get => Convert.ToBoolean(this[nameof (DisableCallback)]);
      set => this[nameof (DisableCallback)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowMicNotDefaultWarning
    {
      get => Convert.ToBoolean(this[nameof (ShowMicNotDefaultWarning)]);
      set => this[nameof (ShowMicNotDefaultWarning)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("60")]
    public int Confidence
    {
      get => Convert.ToInt32(this[nameof (Confidence)]);
      set => this[nameof (Confidence)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartAppwatcherOnStart
    {
      get => Convert.ToBoolean(this[nameof (StartAppwatcherOnStart)]);
      set => this[nameof (StartAppwatcherOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool DBCheck
    {
      get => Convert.ToBoolean(this[nameof (DBCheck)]);
      set => this[nameof (DBCheck)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    public int DbgToolMethod
    {
      get => Convert.ToInt32(this[nameof (DbgToolMethod)]);
      set => this[nameof (DbgToolMethod)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10, 10")]
    public Point SteamWindowLocation
    {
      get
      {
        object obj = this[nameof (SteamWindowLocation)];
        return obj != null ? (Point) obj : new Point();
      }
      set => this[nameof (SteamWindowLocation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("652, 473")]
    public Size SteamWindowSize
    {
      get
      {
        object obj = this[nameof (SteamWindowSize)];
        return obj != null ? (Size) obj : new Size();
      }
      set => this[nameof (SteamWindowSize)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool AutomaticUpdateCheck
    {
      get => Convert.ToBoolean(this[nameof (AutomaticUpdateCheck)]);
      set => this[nameof (AutomaticUpdateCheck)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string FOVh
    {
      get => Convert.ToString(this[nameof (FOVh)]);
      set => this[nameof (FOVh)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int HomelessEnabled
    {
      get => Convert.ToInt32(this[nameof (HomelessEnabled)]);
      set => this[nameof (HomelessEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0 0 0 ")]
    public string HomlessColor
    {
      get => Convert.ToString(this[nameof (HomlessColor)]);
      set => this[nameof (HomlessColor)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("None")]
    public string HomelessMusic
    {
      get => Convert.ToString(this[nameof (HomelessMusic)]);
      set => this[nameof (HomelessMusic)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("500")]
    public int HomelessVolume
    {
      get => Convert.ToInt32(this[nameof (HomelessVolume)]);
      set => this[nameof (HomelessVolume)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string HomelessHash
    {
      get => Convert.ToString(this[nameof (HomelessHash)]);
      set => this[nameof (HomelessHash)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string HomeHash
    {
      get => Convert.ToString(this[nameof (HomeHash)]);
      set => this[nameof (HomeHash)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool HomelessAutoPatch
    {
      get => Convert.ToBoolean(this[nameof (HomelessAutoPatch)]);
      set => this[nameof (HomelessAutoPatch)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool MirrorHome
    {
      get => Convert.ToBoolean(this[nameof (MirrorHome)]);
      set => this[nameof (MirrorHome)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    public int USBSuspend
    {
      get => Convert.ToInt32(this[nameof (USBSuspend)]);
      set => this[nameof (USBSuspend)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool RestartServiceAfterSleep
    {
      get => Convert.ToBoolean(this[nameof (RestartServiceAfterSleep)]);
      set => this[nameof (RestartServiceAfterSleep)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Next HUD,None,LEFT;Previous HUD,None,RIGHT;Next ASW Mode,None,UP;Previous ASW Mode,None,DOWN")]
    public string HotKeyCombos
    {
      get => Convert.ToString(this[nameof (HotKeyCombos)]);
      set => this[nameof (HotKeyCombos)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool HotKeyVoiceConfirmation
    {
      get => Convert.ToBoolean(this[nameof (HotKeyVoiceConfirmation)]);
      set => this[nameof (HotKeyVoiceConfirmation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool VoiceActivationVoiceContinous
    {
      get => Convert.ToBoolean(this[nameof (VoiceActivationVoiceContinous)]);
      set => this[nameof (VoiceActivationVoiceContinous)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool VoiceActivationVoiceRepeated
    {
      get => Convert.ToBoolean(this[nameof (VoiceActivationVoiceRepeated)]);
      set => this[nameof (VoiceActivationVoiceRepeated)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool VoiceActivationKeyContinous
    {
      get => Convert.ToBoolean(this[nameof (VoiceActivationKeyContinous)]);
      set => this[nameof (VoiceActivationKeyContinous)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool VoiceActivationKeyPush
    {
      get => Convert.ToBoolean(this[nameof (VoiceActivationKeyPush)]);
      set => this[nameof (VoiceActivationKeyPush)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public string SetFallbackMicDefaultCommDev
    {
      get => Convert.ToString(this[nameof (SetFallbackMicDefaultCommDev)]);
      set => this[nameof (SetFallbackMicDefaultCommDev)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string KeyboardVoiceActivationKey
    {
      get => Convert.ToString(this[nameof (KeyboardVoiceActivationKey)]);
      set => this[nameof (KeyboardVoiceActivationKey)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string JoystickVoiceActivationButton
    {
      get => Convert.ToString(this[nameof (JoystickVoiceActivationButton)]);
      set => this[nameof (JoystickVoiceActivationButton)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string JoystickDeviceName
    {
      get => Convert.ToString(this[nameof (JoystickDeviceName)]);
      set => this[nameof (JoystickDeviceName)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool JoystickActivationKeyContinous
    {
      get => Convert.ToBoolean(this[nameof (JoystickActivationKeyContinous)]);
      set => this[nameof (JoystickActivationKeyContinous)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool JoystickActivationKeyPush
    {
      get => Convert.ToBoolean(this[nameof (JoystickActivationKeyPush)]);
      set => this[nameof (JoystickActivationKeyPush)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DisableVoiceControlAudioFeedback
    {
      get => Convert.ToBoolean(this[nameof (DisableVoiceControlAudioFeedback)]);
      set => this[nameof (DisableVoiceControlAudioFeedback)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DefaultComm
    {
      get => Convert.ToString(this[nameof (DefaultComm)]);
      set => this[nameof (DefaultComm)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SystemDefaultCommGuid
    {
      get => Convert.ToString(this[nameof (SystemDefaultCommGuid)]);
      set => this[nameof (SystemDefaultCommGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SystemDefaultCommAudioGuid
    {
      get => Convert.ToString(this[nameof (SystemDefaultCommAudioGuid)]);
      set => this[nameof (SystemDefaultCommAudioGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DefaultCommAudio
    {
      get => Convert.ToString(this[nameof (DefaultCommAudio)]);
      set => this[nameof (DefaultCommAudio)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string PowerPlanCurrent
    {
      get => Convert.ToString(this[nameof (PowerPlanCurrent)]);
      set => this[nameof (PowerPlanCurrent)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetAudioOnStart
    {
      get => Convert.ToString(this[nameof (SetAudioOnStart)]);
      set => this[nameof (SetAudioOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetMicOnStart
    {
      get => Convert.ToString(this[nameof (SetMicOnStart)]);
      set => this[nameof (SetMicOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetAudioCommOnStart
    {
      get => Convert.ToString(this[nameof (SetAudioCommOnStart)]);
      set => this[nameof (SetAudioCommOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetMicCommOnStart
    {
      get => Convert.ToString(this[nameof (SetMicCommOnStart)]);
      set => this[nameof (SetMicCommOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetAudioOnStartGuid
    {
      get => Convert.ToString(this[nameof (SetAudioOnStartGuid)]);
      set => this[nameof (SetAudioOnStartGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetMicOnStartGuid
    {
      get => Convert.ToString(this[nameof (SetMicOnStartGuid)]);
      set => this[nameof (SetMicOnStartGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetAudioCommOnStartGuid
    {
      get => Convert.ToString(this[nameof (SetAudioCommOnStartGuid)]);
      set => this[nameof (SetAudioCommOnStartGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetMicCommOnStartGuid
    {
      get => Convert.ToString(this[nameof (SetMicCommOnStartGuid)]);
      set => this[nameof (SetMicCommOnStartGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string FOVv
    {
      get => Convert.ToString(this[nameof (FOVv)]);
      set => this[nameof (FOVv)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool AdaptiveGPUScaling
    {
      get => Convert.ToBoolean(this[nameof (AdaptiveGPUScaling)]);
      set => this[nameof (AdaptiveGPUScaling)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("2000")]
    public int SleepAfterServiceStart
    {
      get => Convert.ToInt32(this[nameof (SleepAfterServiceStart)]);
      set => this[nameof (SleepAfterServiceStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("2000")]
    public string SleepAfterHomeStart
    {
      get => Convert.ToString(this[nameof (SleepAfterHomeStart)]);
      set => this[nameof (SleepAfterHomeStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DesktopResolution
    {
      get => Convert.ToString(this[nameof (DesktopResolution)]);
      set => this[nameof (DesktopResolution)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Normal")]
    public string OVRSrvPrio
    {
      get => Convert.ToString(this[nameof (OVRSrvPrio)]);
      set => this[nameof (OVRSrvPrio)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public string ForceMipmap
    {
      get => Convert.ToString(this[nameof (ForceMipmap)]);
      set => this[nameof (ForceMipmap)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string OffsetMipmap
    {
      get => Convert.ToString(this[nameof (OffsetMipmap)]);
      set => this[nameof (OffsetMipmap)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StopOVRHome
    {
      get => Convert.ToBoolean(this[nameof (StopOVRHome)]);
      set => this[nameof (StopOVRHome)] = (object) value;
    }
  }
}
