// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.My.MySettings
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable disable
namespace OculusTrayTool.My
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  internal sealed class MySettings : ApplicationSettingsBase
  {
    private static MySettings defaultInstance = (MySettings) SettingsBase.Synchronized((SettingsBase) new MySettings());
    private static bool addedHandler;
    private static object addedHandlerLockObject = RuntimeHelpers.GetObjectValue(new object());

    [DebuggerNonUserCode]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    private static void AutoSaveSettings(object sender, EventArgs e)
    {
      if (!MyProject.Application.SaveMySettingsOnExit)
        return;
      MySettingsProperty.Settings.Save();
    }

    public static MySettings Default
    {
      get
      {
        if (!MySettings.addedHandler)
        {
          object handlerLockObject = MySettings.addedHandlerLockObject;
          ObjectFlowControl.CheckForSyncLockOnValueType(handlerLockObject);
          bool lockTaken = false;
          try
          {
            Monitor.Enter(handlerLockObject, ref lockTaken);
            if (!MySettings.addedHandler)
            {
              MyProject.Application.Shutdown += (ShutdownEventHandler) ([DebuggerNonUserCode, EditorBrowsable(EditorBrowsableState.Advanced)] (sender, e) =>
              {
                if (!MyProject.Application.SaveMySettingsOnExit)
                  return;
                MySettingsProperty.Settings.Save();
              });
              MySettings.addedHandler = true;
            }
          }
          finally
          {
            if (lockTaken)
              Monitor.Exit(handlerLockObject);
          }
        }
        MySettings defaultInstance = MySettings.defaultInstance;
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
      get => Conversions.ToString(this[nameof (StartVoice)]);
      set => this[nameof (StartVoice)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("computer, stop listening;speech off")]
    public string StopVoice
    {
      get => Conversions.ToString(this[nameof (StopVoice)]);
      set => this[nameof (StopVoice)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("enable spacewarp")]
    public string EnableASW
    {
      get => Conversions.ToString(this[nameof (EnableASW)]);
      set => this[nameof (EnableASW)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("disable spacewarp")]
    public string DisableASW
    {
      get => Conversions.ToString(this[nameof (DisableASW)]);
      set => this[nameof (DisableASW)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show pixel density; show super sampling")]
    public string ShowPD
    {
      get => Conversions.ToString(this[nameof (ShowPD)]);
      set => this[nameof (ShowPD)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show performance")]
    public string ShowPerf
    {
      get => Conversions.ToString(this[nameof (ShowPerf)]);
      set => this[nameof (ShowPerf)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("close overlay")]
    public string Close
    {
      get => Conversions.ToString(this[nameof (Close)]);
      set => this[nameof (Close)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("set pixel density;set super sampling")]
    public string SetPD
    {
      get => Conversions.ToString(this[nameof (SetPD)]);
      set => this[nameof (SetPD)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show spacewarp")]
    public string ShowASW
    {
      get => Conversions.ToString(this[nameof (ShowASW)]);
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
      get => Conversions.ToString(this[nameof (OldCPUID)]);
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
      get => Conversions.ToString(this[nameof (LockASWOn)]);
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
      get => Conversions.ToString(this[nameof (ShowLatency)]);
      set => this[nameof (ShowLatency)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show application timing")]
    public string ShowApplicationRender
    {
      get => Conversions.ToString(this[nameof (ShowApplicationRender)]);
      set => this[nameof (ShowApplicationRender)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show compositor timing")]
    public string ShowCompositorRender
    {
      get => Conversions.ToString(this[nameof (ShowCompositorRender)]);
      set => this[nameof (ShowCompositorRender)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("show version")]
    public string ShowVersion
    {
      get => Conversions.ToString(this[nameof (ShowVersion)]);
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
      get => Conversions.ToBoolean(this[nameof (ShowConfirmRestart)]);
      set => this[nameof (ShowConfirmRestart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("start steam;launch steam")]
    public string LaunchSteam
    {
      get => Conversions.ToString(this[nameof (LaunchSteam)]);
      set => this[nameof (LaunchSteam)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string AssetsPath
    {
      get => Conversions.ToString(this[nameof (AssetsPath)]);
      set => this[nameof (AssetsPath)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool StartVoiceEnabled
    {
      get => Conversions.ToBoolean(this[nameof (StartVoiceEnabled)]);
      set => this[nameof (StartVoiceEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool StopVoiceEnabled
    {
      get => Conversions.ToBoolean(this[nameof (StopVoiceEnabled)]);
      set => this[nameof (StopVoiceEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool EnableASWEnabled
    {
      get => Conversions.ToBoolean(this[nameof (EnableASWEnabled)]);
      set => this[nameof (EnableASWEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool DisableASWEnabled
    {
      get => Conversions.ToBoolean(this[nameof (DisableASWEnabled)]);
      set => this[nameof (DisableASWEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowPDEnabled
    {
      get => Conversions.ToBoolean(this[nameof (ShowPDEnabled)]);
      set => this[nameof (ShowPDEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowPerfEnabled
    {
      get => Conversions.ToBoolean(this[nameof (ShowPerfEnabled)]);
      set => this[nameof (ShowPerfEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool CloseEnabled
    {
      get => Conversions.ToBoolean(this[nameof (CloseEnabled)]);
      set => this[nameof (CloseEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool SetPDEnabled
    {
      get => Conversions.ToBoolean(this[nameof (SetPDEnabled)]);
      set => this[nameof (SetPDEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowASWEnabled
    {
      get => Conversions.ToBoolean(this[nameof (ShowASWEnabled)]);
      set => this[nameof (ShowASWEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowLatencyEnabled
    {
      get => Conversions.ToBoolean(this[nameof (ShowLatencyEnabled)]);
      set => this[nameof (ShowLatencyEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowApplicationRenderEnabled
    {
      get => Conversions.ToBoolean(this[nameof (ShowApplicationRenderEnabled)]);
      set => this[nameof (ShowApplicationRenderEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowCompositorRenderEnabled
    {
      get => Conversions.ToBoolean(this[nameof (ShowCompositorRenderEnabled)]);
      set => this[nameof (ShowCompositorRenderEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowVersionEnabled
    {
      get => Conversions.ToBoolean(this[nameof (ShowVersionEnabled)]);
      set => this[nameof (ShowVersionEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool LaunchSteamEnabled
    {
      get => Conversions.ToBoolean(this[nameof (LaunchSteamEnabled)]);
      set => this[nameof (LaunchSteamEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool LockASWOnEnabled
    {
      get => Conversions.ToBoolean(this[nameof (LockASWOnEnabled)]);
      set => this[nameof (LockASWOnEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("9")]
    public float FontSize
    {
      get => Conversions.ToSingle(this[nameof (FontSize)]);
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
      get => Conversions.ToBoolean(this[nameof (StartWithWindows)]);
      set => this[nameof (StartWithWindows)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool RunDebug
    {
      get => Conversions.ToBoolean(this[nameof (RunDebug)]);
      set => this[nameof (RunDebug)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool VoiceConfirmProfile
    {
      get => Conversions.ToBoolean(this[nameof (VoiceConfirmProfile)]);
      set => this[nameof (VoiceConfirmProfile)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowStillRunning
    {
      get => Conversions.ToBoolean(this[nameof (ShowStillRunning)]);
      set => this[nameof (ShowStillRunning)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendHomeToTray
    {
      get => Conversions.ToBoolean(this[nameof (SendHomeToTray)]);
      set => this[nameof (SendHomeToTray)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SendHomeToTrayOnStart
    {
      get => Conversions.ToBoolean(this[nameof (SendHomeToTrayOnStart)]);
      set => this[nameof (SendHomeToTrayOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowHomeToast
    {
      get => Conversions.ToBoolean(this[nameof (ShowHomeToast)]);
      set => this[nameof (ShowHomeToast)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartMinimized
    {
      get => Conversions.ToBoolean(this[nameof (StartMinimized)]);
      set => this[nameof (StartMinimized)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int StartHomeDelay
    {
      get => Conversions.ToInteger(this[nameof (StartHomeDelay)]);
      set => this[nameof (StartHomeDelay)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool UseVoiceCommands
    {
      get => Conversions.ToBoolean(this[nameof (UseVoiceCommands)]);
      set => this[nameof (UseVoiceCommands)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DisableFrescoPower
    {
      get => Conversions.ToBoolean(this[nameof (DisableFrescoPower)]);
      set => this[nameof (DisableFrescoPower)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string LibraryPath
    {
      get => Conversions.ToString(this[nameof (LibraryPath)]);
      set => this[nameof (LibraryPath)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string PPDPStartup
    {
      get => Conversions.ToString(this[nameof (PPDPStartup)]);
      set => this[nameof (PPDPStartup)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Not Used")]
    public string PowerPlanStart
    {
      get => Conversions.ToString(this[nameof (PowerPlanStart)]);
      set => this[nameof (PowerPlanStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SpoofCPU
    {
      get => Conversions.ToBoolean(this[nameof (SpoofCPU)]);
      set => this[nameof (SpoofCPU)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StopOVR
    {
      get => Conversions.ToBoolean(this[nameof (StopOVR)]);
      set => this[nameof (StopOVR)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartHomeOnServiceStart
    {
      get => Conversions.ToBoolean(this[nameof (StartHomeOnServiceStart)]);
      set => this[nameof (StartHomeOnServiceStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string OculusPath
    {
      get => Conversions.ToString(this[nameof (OculusPath)]);
      set => this[nameof (OculusPath)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartOVR
    {
      get => Conversions.ToBoolean(this[nameof (StartOVR)]);
      set => this[nameof (StartOVR)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool OVRServerPriority
    {
      get => Conversions.ToBoolean(this[nameof (OVRServerPriority)]);
      set => this[nameof (OVRServerPriority)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartHomeOnToolStart
    {
      get => Conversions.ToBoolean(this[nameof (StartHomeOnToolStart)]);
      set => this[nameof (StartHomeOnToolStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool CloseHomeOnExit
    {
      get => Conversions.ToBoolean(this[nameof (CloseHomeOnExit)]);
      set => this[nameof (CloseHomeOnExit)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool HideAltTab
    {
      get => Conversions.ToBoolean(this[nameof (HideAltTab)]);
      set => this[nameof (HideAltTab)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DefaultAudio
    {
      get => Conversions.ToString(this[nameof (DefaultAudio)]);
      set => this[nameof (DefaultAudio)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DefaultMic
    {
      get => Conversions.ToString(this[nameof (DefaultMic)]);
      set => this[nameof (DefaultMic)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool SetRiftAsDefault
    {
      get => Conversions.ToBoolean(this[nameof (SetRiftAsDefault)]);
      set => this[nameof (SetRiftAsDefault)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int SetRiftAudioDefault
    {
      get => Conversions.ToInteger(this[nameof (SetRiftAudioDefault)]);
      set => this[nameof (SetRiftAudioDefault)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int SetRiftMicDefault
    {
      get => Conversions.ToInteger(this[nameof (SetRiftMicDefault)]);
      set => this[nameof (SetRiftMicDefault)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool UseLocalDebugTool
    {
      get => Conversions.ToBoolean(this[nameof (UseLocalDebugTool)]);
      set => this[nameof (UseLocalDebugTool)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool UseHotKeys
    {
      get => Conversions.ToBoolean(this[nameof (UseHotKeys)]);
      set => this[nameof (UseHotKeys)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int ASW
    {
      get => Conversions.ToInteger(this[nameof (ASW)]);
      set => this[nameof (ASW)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool CloseOnX
    {
      get => Conversions.ToBoolean(this[nameof (CloseOnX)]);
      set => this[nameof (CloseOnX)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool NoHome
    {
      get => Conversions.ToBoolean(this[nameof (NoHome)]);
      set => this[nameof (NoHome)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DisableSensorPower
    {
      get => Conversions.ToBoolean(this[nameof (DisableSensorPower)]);
      set => this[nameof (DisableSensorPower)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Not Used")]
    public string PowerPlanExit
    {
      get => Conversions.ToString(this[nameof (PowerPlanExit)]);
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
      get => Conversions.ToInteger(this[nameof (ApplyPowerPlan)]);
      set => this[nameof (ApplyPowerPlan)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool UpgradeRequired
    {
      get => Conversions.ToBoolean(this[nameof (UpgradeRequired)]);
      set => this[nameof (UpgradeRequired)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string RiftAudioGuid
    {
      get => Conversions.ToString(this[nameof (RiftAudioGuid)]);
      set => this[nameof (RiftAudioGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string RiftMicGuid
    {
      get => Conversions.ToString(this[nameof (RiftMicGuid)]);
      set => this[nameof (RiftMicGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SystemDefaultMicGuid
    {
      get => Conversions.ToString(this[nameof (SystemDefaultMicGuid)]);
      set => this[nameof (SystemDefaultMicGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SystemDefaultAudioGuid
    {
      get => Conversions.ToString(this[nameof (SystemDefaultAudioGuid)]);
      set => this[nameof (SystemDefaultAudioGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DisableCallback
    {
      get => Conversions.ToBoolean(this[nameof (DisableCallback)]);
      set => this[nameof (DisableCallback)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool ShowMicNotDefaultWarning
    {
      get => Conversions.ToBoolean(this[nameof (ShowMicNotDefaultWarning)]);
      set => this[nameof (ShowMicNotDefaultWarning)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("60")]
    public int Confidence
    {
      get => Conversions.ToInteger(this[nameof (Confidence)]);
      set => this[nameof (Confidence)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StartAppwatcherOnStart
    {
      get => Conversions.ToBoolean(this[nameof (StartAppwatcherOnStart)]);
      set => this[nameof (StartAppwatcherOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool DBCheck
    {
      get => Conversions.ToBoolean(this[nameof (DBCheck)]);
      set => this[nameof (DBCheck)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    public int DbgToolMethod
    {
      get => Conversions.ToInteger(this[nameof (DbgToolMethod)]);
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
      get => Conversions.ToBoolean(this[nameof (AutomaticUpdateCheck)]);
      set => this[nameof (AutomaticUpdateCheck)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string FOVh
    {
      get => Conversions.ToString(this[nameof (FOVh)]);
      set => this[nameof (FOVh)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public int HomelessEnabled
    {
      get => Conversions.ToInteger(this[nameof (HomelessEnabled)]);
      set => this[nameof (HomelessEnabled)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0 0 0 ")]
    public string HomlessColor
    {
      get => Conversions.ToString(this[nameof (HomlessColor)]);
      set => this[nameof (HomlessColor)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("None")]
    public string HomelessMusic
    {
      get => Conversions.ToString(this[nameof (HomelessMusic)]);
      set => this[nameof (HomelessMusic)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("500")]
    public int HomelessVolume
    {
      get => Conversions.ToInteger(this[nameof (HomelessVolume)]);
      set => this[nameof (HomelessVolume)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string HomelessHash
    {
      get => Conversions.ToString(this[nameof (HomelessHash)]);
      set => this[nameof (HomelessHash)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string HomeHash
    {
      get => Conversions.ToString(this[nameof (HomeHash)]);
      set => this[nameof (HomeHash)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool HomelessAutoPatch
    {
      get => Conversions.ToBoolean(this[nameof (HomelessAutoPatch)]);
      set => this[nameof (HomelessAutoPatch)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool MirrorHome
    {
      get => Conversions.ToBoolean(this[nameof (MirrorHome)]);
      set => this[nameof (MirrorHome)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    public int USBSuspend
    {
      get => Conversions.ToInteger(this[nameof (USBSuspend)]);
      set => this[nameof (USBSuspend)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool RestartServiceAfterSleep
    {
      get => Conversions.ToBoolean(this[nameof (RestartServiceAfterSleep)]);
      set => this[nameof (RestartServiceAfterSleep)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Next HUD,None,LEFT;Previous HUD,None,RIGHT;Next ASW Mode,None,UP;Previous ASW Mode,None,DOWN")]
    public string HotKeyCombos
    {
      get => Conversions.ToString(this[nameof (HotKeyCombos)]);
      set => this[nameof (HotKeyCombos)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool HotKeyVoiceConfirmation
    {
      get => Conversions.ToBoolean(this[nameof (HotKeyVoiceConfirmation)]);
      set => this[nameof (HotKeyVoiceConfirmation)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool VoiceActivationVoiceContinous
    {
      get => Conversions.ToBoolean(this[nameof (VoiceActivationVoiceContinous)]);
      set => this[nameof (VoiceActivationVoiceContinous)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool VoiceActivationVoiceRepeated
    {
      get => Conversions.ToBoolean(this[nameof (VoiceActivationVoiceRepeated)]);
      set => this[nameof (VoiceActivationVoiceRepeated)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool VoiceActivationKeyContinous
    {
      get => Conversions.ToBoolean(this[nameof (VoiceActivationKeyContinous)]);
      set => this[nameof (VoiceActivationKeyContinous)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool VoiceActivationKeyPush
    {
      get => Conversions.ToBoolean(this[nameof (VoiceActivationKeyPush)]);
      set => this[nameof (VoiceActivationKeyPush)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public string SetFallbackMicDefaultCommDev
    {
      get => Conversions.ToString(this[nameof (SetFallbackMicDefaultCommDev)]);
      set => this[nameof (SetFallbackMicDefaultCommDev)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string KeyboardVoiceActivationKey
    {
      get => Conversions.ToString(this[nameof (KeyboardVoiceActivationKey)]);
      set => this[nameof (KeyboardVoiceActivationKey)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string JoystickVoiceActivationButton
    {
      get => Conversions.ToString(this[nameof (JoystickVoiceActivationButton)]);
      set => this[nameof (JoystickVoiceActivationButton)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string JoystickDeviceName
    {
      get => Conversions.ToString(this[nameof (JoystickDeviceName)]);
      set => this[nameof (JoystickDeviceName)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool JoystickActivationKeyContinous
    {
      get => Conversions.ToBoolean(this[nameof (JoystickActivationKeyContinous)]);
      set => this[nameof (JoystickActivationKeyContinous)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool JoystickActivationKeyPush
    {
      get => Conversions.ToBoolean(this[nameof (JoystickActivationKeyPush)]);
      set => this[nameof (JoystickActivationKeyPush)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool DisableVoiceControlAudioFeedback
    {
      get => Conversions.ToBoolean(this[nameof (DisableVoiceControlAudioFeedback)]);
      set => this[nameof (DisableVoiceControlAudioFeedback)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DefaultComm
    {
      get => Conversions.ToString(this[nameof (DefaultComm)]);
      set => this[nameof (DefaultComm)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SystemDefaultCommGuid
    {
      get => Conversions.ToString(this[nameof (SystemDefaultCommGuid)]);
      set => this[nameof (SystemDefaultCommGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SystemDefaultCommAudioGuid
    {
      get => Conversions.ToString(this[nameof (SystemDefaultCommAudioGuid)]);
      set => this[nameof (SystemDefaultCommAudioGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DefaultCommAudio
    {
      get => Conversions.ToString(this[nameof (DefaultCommAudio)]);
      set => this[nameof (DefaultCommAudio)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string PowerPlanCurrent
    {
      get => Conversions.ToString(this[nameof (PowerPlanCurrent)]);
      set => this[nameof (PowerPlanCurrent)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetAudioOnStart
    {
      get => Conversions.ToString(this[nameof (SetAudioOnStart)]);
      set => this[nameof (SetAudioOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetMicOnStart
    {
      get => Conversions.ToString(this[nameof (SetMicOnStart)]);
      set => this[nameof (SetMicOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetAudioCommOnStart
    {
      get => Conversions.ToString(this[nameof (SetAudioCommOnStart)]);
      set => this[nameof (SetAudioCommOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetMicCommOnStart
    {
      get => Conversions.ToString(this[nameof (SetMicCommOnStart)]);
      set => this[nameof (SetMicCommOnStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetAudioOnStartGuid
    {
      get => Conversions.ToString(this[nameof (SetAudioOnStartGuid)]);
      set => this[nameof (SetAudioOnStartGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetMicOnStartGuid
    {
      get => Conversions.ToString(this[nameof (SetMicOnStartGuid)]);
      set => this[nameof (SetMicOnStartGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetAudioCommOnStartGuid
    {
      get => Conversions.ToString(this[nameof (SetAudioCommOnStartGuid)]);
      set => this[nameof (SetAudioCommOnStartGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string SetMicCommOnStartGuid
    {
      get => Conversions.ToString(this[nameof (SetMicCommOnStartGuid)]);
      set => this[nameof (SetMicCommOnStartGuid)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string FOVv
    {
      get => Conversions.ToString(this[nameof (FOVv)]);
      set => this[nameof (FOVv)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    public bool AdaptiveGPUScaling
    {
      get => Conversions.ToBoolean(this[nameof (AdaptiveGPUScaling)]);
      set => this[nameof (AdaptiveGPUScaling)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("2000")]
    public int SleepAfterServiceStart
    {
      get => Conversions.ToInteger(this[nameof (SleepAfterServiceStart)]);
      set => this[nameof (SleepAfterServiceStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("2000")]
    public string SleepAfterHomeStart
    {
      get => Conversions.ToString(this[nameof (SleepAfterHomeStart)]);
      set => this[nameof (SleepAfterHomeStart)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DesktopResolution
    {
      get => Conversions.ToString(this[nameof (DesktopResolution)]);
      set => this[nameof (DesktopResolution)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Normal")]
    public string OVRSrvPrio
    {
      get => Conversions.ToString(this[nameof (OVRSrvPrio)]);
      set => this[nameof (OVRSrvPrio)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public string ForceMipmap
    {
      get => Conversions.ToString(this[nameof (ForceMipmap)]);
      set => this[nameof (ForceMipmap)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0")]
    public string OffsetMipmap
    {
      get => Conversions.ToString(this[nameof (OffsetMipmap)]);
      set => this[nameof (OffsetMipmap)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool StopOVRHome
    {
      get => Conversions.ToBoolean(this[nameof (StopOVRHome)]);
      set => this[nameof (StopOVRHome)] = (object) value;
    }
  }
}
