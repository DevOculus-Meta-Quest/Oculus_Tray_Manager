// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.GetConfig
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.Speech.Recognition;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class GetConfig
  {
    public static bool disable_fresco_power = false;
    public static string ppdp;
    public static string ppdpstartup;
    public static bool hideAltTab = false;
    public static string RiftAudioDevice;
    public static string RiftMicDevice;
    public static bool SetRiftDefault = false;
    public static bool useVoiceCommands = false;
    public static string DefaultAudioName;
    public static string DefaultMicName;
    public static bool SetPowerPlan = false;
    public static int StartHomeDelay;
    public static bool UseHotKeys = false;
    public static bool IsReading = false;
    public static int numprofiles = 0;
    public static bool ProfilesRead = false;

    public static void GetConfig()
    {
      try
      {
        if (Globals.dbg)
          Log.WriteToLog("Entering GetConfig");
        MySettingsProperty.Settings.NoHome = false;
        MySettingsProperty.Settings.Save();
        Log.WriteToLog("Reading configuration parameters from " + ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath);
        if (Globals.dbg)
          Log.WriteToLog("Reading setting StartMinimized");
        MyProject.Forms.FrmMain.CheckStartMin.Checked = MySettingsProperty.Settings.StartMinimized;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting PowerPlanStart");
        if (Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "Not Used", false) != 0)
        {
          if (MySettingsProperty.Settings.ApplyPowerPlan == 0)
            PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
          MyProject.Forms.FrmMain.ComboPowerPlanStart.Text = MySettingsProperty.Settings.PowerPlanStart;
        }
        else if (Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "Not Used", false) == 0 | Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "", false) == 0)
        {
          MyProject.Forms.FrmMain.ComboPowerPlanStart.Text = "Not Used";
          PowerPlans.GetActivePowerPlan();
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting PowerPlanExit");
        if (Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", false) != 0)
          MyProject.Forms.FrmMain.ComboPowerPlanExit.Text = MySettingsProperty.Settings.PowerPlanExit;
        else if (Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", false) == 0 | Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "", false) == 0)
          MyProject.Forms.FrmMain.ComboPowerPlanExit.Text = "Not Used";
        if (Globals.dbg)
          Log.WriteToLog("Reading setting StartHomeDelay");
        OculusTrayTool.GetConfig.StartHomeDelay = MySettingsProperty.Settings.StartHomeDelay;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting UseVoiceCommands");
        OculusTrayTool.GetConfig.useVoiceCommands = MySettingsProperty.Settings.UseVoiceCommands;
        if (MySettingsProperty.Settings.UseVoiceCommands)
        {
          MyProject.Forms.FrmMain.ComboVoice.Text = "Enabled";
          MyProject.Forms.FrmMain.BtnVoice.Enabled = true;
          VoiceCommands.sRecognize = new SpeechRecognitionEngine(new CultureInfo(CultureInfo.CurrentUICulture.Name));
          VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
          VoiceCommands.sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognize_SpeechRecognized);
          VoiceCommands.buildGrammars();
          VoiceCommands.isListening = false;
        }
        else
        {
          MyProject.Forms.FrmMain.ComboVoice.Text = "Disabled";
          MyProject.Forms.FrmMain.BtnVoice.Enabled = false;
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting AutomaticUpdateCheck");
        FrmMain.fmain.CheckBoxCheckForUpdates.Checked = MySettingsProperty.Settings.AutomaticUpdateCheck;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting HideAltTab");
        OculusTrayTool.GetConfig.hideAltTab = MySettingsProperty.Settings.HideAltTab;
        FrmMain.fmain.CheckBoxAltTab.Checked = MySettingsProperty.Settings.HideAltTab;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting StartAppwatcherOnStart");
        FrmMain.fmain.CheckStartWatcher.Checked = MySettingsProperty.Settings.StartAppwatcherOnStart;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting VoiceConfirmProfile");
        MyProject.Forms.frmProfiles.CheckVoiceConfirm.Checked = MySettingsProperty.Settings.VoiceConfirmProfile;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting LibraryPath");
        bool flag = false;
        if (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0 & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString()))
        {
          string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
          int index = 0;
          while (index < strArray.Length)
          {
            string str = strArray[index];
            if (OculusTrayTool.GetConfig.CountCharacter(str, ':') > 1)
            {
              flag = true;
              break;
            }
            Log.WriteToLog("Adding " + str + " to known library paths");
            FrmMain.fmain.OculusSoftwarePaths.Add(str);
            checked { ++index; }
          }
          if (flag)
          {
            Log.WriteToLog("Found incorrectly formated Library path, resetting to null. Manually added paths must be re-added by the user.");
            MyProject.Forms.FrmMain.AddToListboxAndScroll("* Found incorrectly formated Library path. If you have manually added Library paths you may need to do this again");
            MySettingsProperty.Settings.LibraryPath = "";
            MySettingsProperty.Settings.Save();
            MyProject.Forms.FrmMain.hasWarning = true;
          }
          Log.WriteToLog("Retrieving and cross-checking Oculus Library paths from the registry");
          List<string> oculusSoftwarePaths = (List<string>) OculusPath.GetOculusSoftwarePaths();
          if (oculusSoftwarePaths.Count > 0)
          {
            try
            {
              foreach (string str in oculusSoftwarePaths)
              {
                if (!MySettingsProperty.Settings.LibraryPath.Contains(str))
                {
                  if (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0)
                  {
                    // ISSUE: variable of a compiler-generated type
                    MySettings settings;
                    (settings = MySettingsProperty.Settings).LibraryPath = settings.LibraryPath + "," + str;
                  }
                  else
                  {
                    // ISSUE: variable of a compiler-generated type
                    MySettings settings;
                    (settings = MySettingsProperty.Settings).LibraryPath = settings.LibraryPath + str + ",";
                  }
                  Log.WriteToLog("Found new library path: " + str);
                }
                if (!MyProject.Forms.FrmMain.OculusSoftwarePaths.Contains(str))
                  FrmMain.fmain.OculusSoftwarePaths.Add(str);
              }
            }
            finally
            {
              List<string>.Enumerator enumerator;
              enumerator.Dispose();
            }
            MySettingsProperty.Settings.LibraryPath = MySettingsProperty.Settings.LibraryPath.TrimEnd(',').TrimStart(',');
            MySettingsProperty.Settings.Save();
          }
          else
          {
            Log.WriteToLog("Warning: No library paths returned from registry!");
            FrmMain.fmain.AddToListboxAndScroll("Warning: No library paths returned from registry!");
            MyProject.Forms.FrmMain.hasWarning = true;
          }
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting PPDPStartup");
        OculusTrayTool.GetConfig.ppdpstartup = MySettingsProperty.Settings.PPDPStartup;
        FrmMain.fmain.ComboSSstart.Text = OculusTrayTool.GetConfig.ppdpstartup;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting StopOVR");
        FrmMain.fmain.CheckStopService.Checked = MySettingsProperty.Settings.StopOVR;
        FrmMain.fmain.CheckStopServiceHome.Checked = MySettingsProperty.Settings.StopOVRHome;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting StartHomeOnServiceStart");
        FrmMain.fmain.CheckLaunchHome.Checked = MySettingsProperty.Settings.StartHomeOnServiceStart;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting OculusPath");
        if (Operators.CompareString(FrmMain.fmain.OculusPath, "", false) == 0)
          FrmMain.fmain.OculusPath = MySettingsProperty.Settings.OculusPath;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting ApplyPowerPlan");
        FrmMain.fmain.ComboApplyPlan.SelectedIndex = MySettingsProperty.Settings.ApplyPowerPlan;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting StartOVR");
        FrmMain.fmain.CheckStartService.Checked = MySettingsProperty.Settings.StartOVR;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting StartHomeOnToolStart");
        FrmMain.fmain.CheckLaunchHomeTool.Checked = MySettingsProperty.Settings.StartHomeOnToolStart;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting CloseHomeOnExit");
        FrmMain.fmain.CheckCloseHome.Checked = MySettingsProperty.Settings.CloseHomeOnExit;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting SetRiftAsDefault");
        OculusTrayTool.GetConfig.SetRiftDefault = MySettingsProperty.Settings.SetRiftAsDefault;
        if (MySettingsProperty.Settings.SetRiftAsDefault)
          FrmMain.fmain.CheckRiftAudio.Checked = true;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting FOV");
        if (Operators.CompareString(MySettingsProperty.Settings.FOVh, (string) null, false) != 0)
          MyProject.Forms.FrmMain.NumericFOVh.Value = Conversions.ToDecimal(MySettingsProperty.Settings.FOVh);
        if (Operators.CompareString(MySettingsProperty.Settings.FOVv, (string) null, false) != 0)
          MyProject.Forms.FrmMain.NumericFOVv.Value = Conversions.ToDecimal(MySettingsProperty.Settings.FOVv);
        if (Operators.CompareString(MySettingsProperty.Settings.HotKeyCombos, "", false) != 0)
        {
          if (Globals.dbg)
            Log.WriteToLog("Reading setting HotKeyCombos");
          OculusTrayTool.GetConfig.GetHotKeys();
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting UseHotKeys");
        if (MySettingsProperty.Settings.UseHotKeys & Operators.CompareString(MySettingsProperty.Settings.HotKeyCombos, "", false) != 0)
        {
          OculusTrayTool.GetConfig.UseHotKeys = true;
          MyProject.Forms.FrmMain.HotKeysCheckBox.Checked = true;
          MyProject.Forms.FrmMain.BtnConfigureHotKeys.Enabled = true;
          FrmMain.fmain.AddToListboxAndScroll("HotKeys will be usabled once Oculus Home is running");
        }
        else
        {
          OculusTrayTool.GetConfig.UseHotKeys = false;
          MyProject.Forms.FrmMain.HotKeysCheckBox.Checked = false;
          MyProject.Forms.FrmMain.BtnConfigureHotKeys.Enabled = false;
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting CloseOnX");
        if (!MySettingsProperty.Settings.CloseOnX)
          FrmMain.fmain.CheckMinimizeOnX.Checked = true;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting DisableSensorPower");
        if (MySettingsProperty.Settings.DisableSensorPower)
        {
          FrmMain.fmain.CheckSensorPower.Checked = true;
          PowerPlans.CheckPowerState(true);
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting Confidence");
        MyProject.Forms.frmVoiceSettings.TrackBar1.Value = MySettingsProperty.Settings.Confidence;
        MyProject.Forms.frmVoiceSettings.LabelConfidencePercent.Text = Conversions.ToString(MyProject.Forms.frmVoiceSettings.TrackBar1.Value) + "%";
        if (Globals.dbg)
          Log.WriteToLog("Reading setting SendHomeToTray");
        FrmMain.fmain.CheckSendHomeToTray.Checked = MySettingsProperty.Settings.SendHomeToTray;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting SendHomeToTrayOnStart");
        FrmMain.fmain.CheckSendHomeToTrayOnStart.Checked = MySettingsProperty.Settings.SendHomeToTrayOnStart;
        GetDevices.GetAllAudioDevices();
        GetDevices.GetAllMicDevices();
        if (Globals.dbg)
          Log.WriteToLog("Reading setting HomelessEnabled");
        MyProject.Forms.FrmMain.ComboHomless.SelectedIndex = MySettingsProperty.Settings.HomelessEnabled;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting HomelessVolume");
        MyProject.Forms.frmHomeless.NumericVolume.Value = new Decimal((double) MySettingsProperty.Settings.HomelessVolume / 10.0);
        if (MySettingsProperty.Settings.HomelessEnabled == 1)
        {
          MyProject.Forms.FrmMain.BtnHomless.Enabled = true;
          if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
          {
            string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
            int index = 0;
            while (index < files.Length)
            {
              MyProject.Forms.frmHomeless.ComboMusic.Items.Add((object) Path.GetFileName(files[index]));
              checked { ++index; }
            }
          }
          if (Globals.dbg)
            Log.WriteToLog("Reading setting HomlessColor");
          string[] strArray = Strings.Split(MySettingsProperty.Settings.HomlessColor);
          MyProject.Forms.frmHomeless.TextBox1.BackColor = Color.FromArgb(Conversions.ToInteger(strArray[0]), Conversions.ToInteger(strArray[1]), Conversions.ToInteger(strArray[2]));
          if (Globals.dbg)
            Log.WriteToLog("Reading setting HomelessMusic");
          MyProject.Forms.frmHomeless.ComboMusic.Text = MySettingsProperty.Settings.HomelessMusic;
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting MirrorHome");
        FrmMain.fmain.ComboMirrorHome.SelectedIndex = !MySettingsProperty.Settings.MirrorHome ? 1 : 0;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting RestartServiceAfterSleep");
        FrmMain.fmain.CheckRestartSleep.Checked = MySettingsProperty.Settings.RestartServiceAfterSleep;
        if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
          MyProject.Forms.frmHotKeys.CheckBox1.Checked = true;
        if (MySettingsProperty.Settings.JoystickActivationKeyContinous)
        {
          MyProject.Forms.frmVoiceSettings.CheckBox5.Checked = true;
          MyProject.Forms.frmVoiceSettings.ComboDevice.Enabled = true;
          MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
        }
        if (MySettingsProperty.Settings.JoystickActivationKeyPush)
        {
          MyProject.Forms.frmVoiceSettings.CheckBox6.Checked = true;
          MyProject.Forms.frmVoiceSettings.ComboDevice.Enabled = true;
          MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
        }
        if (MySettingsProperty.Settings.VoiceActivationKeyPush)
        {
          MyProject.Forms.frmVoiceSettings.CheckBox4.Checked = true;
          MyProject.Forms.frmVoiceSettings.ComboDevice.Enabled = true;
          MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
        }
        if (MySettingsProperty.Settings.VoiceActivationKeyContinous)
        {
          MyProject.Forms.frmVoiceSettings.CheckBox3.Checked = true;
          MyProject.Forms.frmVoiceSettings.ComboDevice.Enabled = true;
          MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
        }
        if (MySettingsProperty.Settings.VoiceActivationVoiceRepeated)
          MyProject.Forms.frmVoiceSettings.CheckBox2.Checked = true;
        if (MySettingsProperty.Settings.VoiceActivationVoiceContinous)
          MyProject.Forms.frmVoiceSettings.CheckBox1.Checked = true;
        GetControllers.GetAllControllers();
        MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
        FrmMain.fmain.LoadVoiceSettings();
        if (MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
          MyProject.Forms.frmVoiceSettings.CheckBox7.Checked = true;
        MyProject.Forms.FrmMain.ComboBox5.SelectedIndex = !MySettingsProperty.Settings.AdaptiveGPUScaling ? 1 : 0;
        MyProject.Forms.FrmMain.ComboBox8.Text = MySettingsProperty.Settings.ForceMipmap;
        MyProject.Forms.FrmMain.ComboBox9.Text = MySettingsProperty.Settings.OffsetMipmap;
        if (Operators.CompareString(MySettingsProperty.Settings.DesktopResolution, "", false) == 0)
          MySettingsProperty.Settings.DesktopResolution = Conversions.ToString(MyProject.Forms.FrmMain.GetCurrentResolution());
        MySettingsProperty.Settings.Save();
        MyProject.Forms.frmProfiles.ComboResolution.Text = MySettingsProperty.Settings.DesktopResolution;
        Log.WriteToLog("Done reading configuration parameters");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("Error reading configuration parameters: " + e.Message);
        MyProject.Forms.FrmMain.hasError = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private static int CountCharacter(string value, char ch)
    {
      return value.Count<char>((Func<char, bool>) ([SpecialName] (c) => (int) c == (int) ch));
    }

    public static void GetHotKeys()
    {
      MyProject.Forms.frmHotKeys.ListView1.Items.Clear();
      MyProject.Forms.frmHotKeys.KeyList.Clear();
      MyProject.Forms.FrmMain.FuncToKeyDictionary.Clear();
      MyProject.Forms.frmHotKeys.FunctionList.Clear();
      string[] strArray1 = Strings.Split(MySettingsProperty.Settings.HotKeyCombos, ";");
      if (strArray1.Length <= 0)
        return;
      string[] strArray2 = strArray1;
      int index = 0;
      while (index < strArray2.Length)
      {
        string[] strArray3 = Strings.Split(strArray2[index], ",");
        ListViewItem listViewItem1 = new ListViewItem();
        ListViewItem listViewItem2 = MyProject.Forms.frmHotKeys.ListView1.Items.Add(strArray3[0]);
        if (strArray3.Length > 2)
        {
          listViewItem2.SubItems.Add(strArray3[2]);
          MyProject.Forms.frmHotKeys.KeyList.Add(strArray3[2]);
          MyProject.Forms.FrmMain.FuncToKeyDictionary.Add(strArray3[2], strArray3[0]);
          MyProject.Forms.frmHotKeys.FunctionList.Add(strArray3[0]);
        }
        if (strArray3.Length == 2)
        {
          listViewItem2.SubItems.Add(strArray3[1]);
          MyProject.Forms.frmHotKeys.KeyList.Add(strArray3[1]);
          MyProject.Forms.FrmMain.FuncToKeyDictionary.Add(strArray3[1], strArray3[0]);
          MyProject.Forms.frmHotKeys.FunctionList.Add(strArray3[0]);
        }
        checked { ++index; }
      }
    }
  }
}
