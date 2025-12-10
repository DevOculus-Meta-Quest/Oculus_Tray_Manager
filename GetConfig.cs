
using System.Speech.Recognition;

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

    public static void Load()
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
        FrmMain.fmain.CheckStartMin.Checked = MySettingsProperty.Settings.StartMinimized;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting PowerPlanStart");
        if (string.Compare(MySettingsProperty.Settings.PowerPlanStart, "Not Used", StringComparison.OrdinalIgnoreCase) != 0)
        {
          if (MySettingsProperty.Settings.ApplyPowerPlan == 0)
            PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
          FrmMain.fmain.ComboPowerPlanStart.Text = MySettingsProperty.Settings.PowerPlanStart;
        }
        else if (string.Compare(MySettingsProperty.Settings.PowerPlanStart, "Not Used", StringComparison.OrdinalIgnoreCase) == 0 || string.IsNullOrEmpty(MySettingsProperty.Settings.PowerPlanStart))
        {
          FrmMain.fmain.ComboPowerPlanStart.Text = "Not Used";
          PowerPlans.GetActivePowerPlan();
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting PowerPlanExit");
        if (string.Compare(MySettingsProperty.Settings.PowerPlanExit, "Not Used", StringComparison.OrdinalIgnoreCase) != 0)
          FrmMain.fmain.ComboPowerPlanExit.Text = MySettingsProperty.Settings.PowerPlanExit;
        else if (string.Compare(MySettingsProperty.Settings.PowerPlanExit, "Not Used", StringComparison.OrdinalIgnoreCase) == 0 || string.IsNullOrEmpty(MySettingsProperty.Settings.PowerPlanExit))
          FrmMain.fmain.ComboPowerPlanExit.Text = "Not Used";
        if (Globals.dbg)
          Log.WriteToLog("Reading setting StartHomeDelay");
        OculusTrayTool.GetConfig.StartHomeDelay = MySettingsProperty.Settings.StartHomeDelay;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting UseVoiceCommands");
        OculusTrayTool.GetConfig.useVoiceCommands = MySettingsProperty.Settings.UseVoiceCommands;
        if (MySettingsProperty.Settings.UseVoiceCommands)
        {
          FrmMain.fmain.ComboVoice.Text = "Enabled";
          FrmMain.fmain.BtnVoice.Enabled = true;
          VoiceCommands.sRecognize = new SpeechRecognitionEngine(new CultureInfo(CultureInfo.CurrentUICulture.Name));
          VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
          VoiceCommands.sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognize_SpeechRecognized);
          VoiceCommands.buildGrammars();
          VoiceCommands.isListening = false;
        }
        else
        {
          FrmMain.fmain.ComboVoice.Text = "Disabled";
          FrmMain.fmain.BtnVoice.Enabled = false;
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
            FrmMain.fmain.AddToListboxAndScroll("* Found incorrectly formated Library path. If you have manually added Library paths you may need to do this again");
            MySettingsProperty.Settings.LibraryPath = "";
            MySettingsProperty.Settings.Save();
            FrmMain.fmain.hasWarning = true;
          }
          Log.WriteToLog("Retrieving and cross-checking Oculus Library paths from the registry");
          List<string> oculusSoftwarePaths = (List<string>) OculusPath.GetOculusSoftwarePaths();
          if (oculusSoftwarePaths.Count > 0)
          {

              foreach (string str in oculusSoftwarePaths)
              {
                if (!MySettingsProperty.Settings.LibraryPath.Contains(str))
                {
                if (!string.IsNullOrEmpty(MySettingsProperty.Settings.LibraryPath))
                  {
                    MySettings settings;
                    (settings = MySettingsProperty.Settings).LibraryPath = settings.LibraryPath + "," + str;
                  }
                  else
                  {
                    MySettings settings;
                    (settings = MySettingsProperty.Settings).LibraryPath = settings.LibraryPath + str + ",";
                  }
                  Log.WriteToLog("Found new library path: " + str);
                }
                if (!FrmMain.fmain.OculusSoftwarePaths.Contains(str))
                  FrmMain.fmain.OculusSoftwarePaths.Add(str);
              }


            MySettingsProperty.Settings.LibraryPath = MySettingsProperty.Settings.LibraryPath.TrimEnd(',').TrimStart(',');
            MySettingsProperty.Settings.Save();
          }

          else
          {
            Log.WriteToLog("Warning: No library paths returned from registry!");
            FrmMain.fmain.AddToListboxAndScroll("Warning: No library paths returned from registry!");
            FrmMain.fmain.hasWarning = true;
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
        if (string.IsNullOrEmpty(FrmMain.fmain.OculusPath))
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
        if (!string.IsNullOrEmpty(MySettingsProperty.Settings.FOVh))
          FrmMain.fmain.NumericFOVh.Value = Convert.ToDecimal(MySettingsProperty.Settings.FOVh);
        if (!string.IsNullOrEmpty(MySettingsProperty.Settings.FOVv))
          FrmMain.fmain.NumericFOVv.Value = Convert.ToDecimal(MySettingsProperty.Settings.FOVv);
        if (!string.IsNullOrEmpty(MySettingsProperty.Settings.HotKeyCombos))
        {
          if (Globals.dbg)
            Log.WriteToLog("Reading setting HotKeyCombos");
          OculusTrayTool.GetConfig.GetHotKeys();
        }
        if (Globals.dbg)
          Log.WriteToLog("Reading setting UseHotKeys");
        if (MySettingsProperty.Settings.UseHotKeys && !string.IsNullOrEmpty(MySettingsProperty.Settings.HotKeyCombos))
        {
          OculusTrayTool.GetConfig.UseHotKeys = true;
          FrmMain.fmain.HotKeysCheckBox.Checked = true;
          FrmMain.fmain.BtnConfigureHotKeys.Enabled = true;
          FrmMain.fmain.AddToListboxAndScroll("HotKeys will be usabled once Oculus Home is running");
        }
        else
        {
          OculusTrayTool.GetConfig.UseHotKeys = false;
          FrmMain.fmain.HotKeysCheckBox.Checked = false;
          FrmMain.fmain.BtnConfigureHotKeys.Enabled = false;
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
        MyProject.Forms.frmVoiceSettings.LabelConfidencePercent.Text = MyProject.Forms.frmVoiceSettings.TrackBar1.Value.ToString() + "%";
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
        FrmMain.fmain.ComboHomless.SelectedIndex = MySettingsProperty.Settings.HomelessEnabled;
        if (Globals.dbg)
          Log.WriteToLog("Reading setting HomelessVolume");
        MyProject.Forms.frmHomeless.NumericVolume.Value = new Decimal((double) MySettingsProperty.Settings.HomelessVolume / 10.0);
        if (MySettingsProperty.Settings.HomelessEnabled == 1)
        {
          FrmMain.fmain.BtnHomless.Enabled = true;
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
          MyProject.Forms.frmHomeless.TextBox1.BackColor = Color.FromArgb(Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]), Convert.ToInt32(strArray[2]));
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
        FrmMain.fmain.ComboBox5.SelectedIndex = !MySettingsProperty.Settings.AdaptiveGPUScaling ? 1 : 0;
        FrmMain.fmain.ComboBox8.Text = MySettingsProperty.Settings.ForceMipmap;
        FrmMain.fmain.ComboBox9.Text = MySettingsProperty.Settings.OffsetMipmap;
        if (string.IsNullOrEmpty(MySettingsProperty.Settings.DesktopResolution))
          MySettingsProperty.Settings.DesktopResolution = Convert.ToString(FrmMain.fmain.GetCurrentResolution());
        MySettingsProperty.Settings.Save();
        MyProject.Forms.frmProfiles.ComboResolution.Text = MySettingsProperty.Settings.DesktopResolution;
        Log.WriteToLog("Done reading configuration parameters");
      }
      catch (Exception ex)
      {
        FrmMain.fmain.AddToListboxAndScroll("Error reading configuration parameters: " + ex.Message);
        FrmMain.fmain.hasError = true;
        StackTrace stackTrace = new StackTrace(ex, true);
        Log.WriteToLog(ex.ToString() + stackTrace.ToString());
      }
    }

    private static int CountCharacter(string value, char ch)
    {
      return value.Count(c => c == ch);
    }

    public static void GetHotKeys()
    {
      MyProject.Forms.frmHotKeys.ListView1.Items.Clear();
      MyProject.Forms.frmHotKeys.KeyList.Clear();
      FrmMain.fmain.FuncToKeyDictionary.Clear();
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
          FrmMain.fmain.FuncToKeyDictionary.Add(strArray3[2], strArray3[0]);
          MyProject.Forms.frmHotKeys.FunctionList.Add(strArray3[0]);
        }
        if (strArray3.Length == 2)
        {
          listViewItem2.SubItems.Add(strArray3[1]);
          MyProject.Forms.frmHotKeys.KeyList.Add(strArray3[1]);
          FrmMain.fmain.FuncToKeyDictionary.Add(strArray3[1], strArray3[0]);
          MyProject.Forms.frmHotKeys.FunctionList.Add(strArray3[0]);
        }
        checked { ++index; }
      }
    }
  }
}
