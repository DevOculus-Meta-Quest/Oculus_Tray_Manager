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
using Microsoft.Speech.Recognition;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

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
			{
				Log.WriteToLog("Entering GetConfig");
			}
			MySettingsProperty.Settings.NoHome = false;
			MySettingsProperty.Settings.Save();
			Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
			Log.WriteToLog("Reading configuration parameters from " + configuration.FilePath);
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting StartMinimized");
			}
			if (MySettingsProperty.Settings.StartMinimized)
			{
				MyProject.Forms.FrmMain.CheckStartMin.Checked = true;
			}
			else
			{
				MyProject.Forms.FrmMain.CheckStartMin.Checked = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting PowerPlanStart");
			}
			if (Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "Not Used", TextCompare: false) != 0)
			{
				if (MySettingsProperty.Settings.ApplyPowerPlan == 0)
				{
					PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
				}
				MyProject.Forms.FrmMain.ComboPowerPlanStart.Text = MySettingsProperty.Settings.PowerPlanStart;
			}
			else if ((Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "Not Used", TextCompare: false) == 0) | (Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "", TextCompare: false) == 0))
			{
				MyProject.Forms.FrmMain.ComboPowerPlanStart.Text = "Not Used";
				PowerPlans.GetActivePowerPlan();
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting PowerPlanExit");
			}
			if (Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", TextCompare: false) != 0)
			{
				MyProject.Forms.FrmMain.ComboPowerPlanExit.Text = MySettingsProperty.Settings.PowerPlanExit;
			}
			else if ((Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", TextCompare: false) == 0) | (Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "", TextCompare: false) == 0))
			{
				MyProject.Forms.FrmMain.ComboPowerPlanExit.Text = "Not Used";
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting StartHomeDelay");
			}
			StartHomeDelay = MySettingsProperty.Settings.StartHomeDelay;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting UseVoiceCommands");
			}
			useVoiceCommands = MySettingsProperty.Settings.UseVoiceCommands;
			if (MySettingsProperty.Settings.UseVoiceCommands)
			{
				MyProject.Forms.FrmMain.ComboVoice.Text = "Enabled";
				MyProject.Forms.FrmMain.BtnVoice.Enabled = true;
				CultureInfo culture = new CultureInfo(CultureInfo.CurrentUICulture.Name);
				VoiceCommands.sRecognize = new SpeechRecognitionEngine(culture);
				VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
				VoiceCommands.sRecognize.SpeechRecognized += VoiceCommands.sRecognize_SpeechRecognized;
				VoiceCommands.buildGrammars();
				VoiceCommands.isListening = false;
			}
			else
			{
				MyProject.Forms.FrmMain.ComboVoice.Text = "Disabled";
				MyProject.Forms.FrmMain.BtnVoice.Enabled = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting AutomaticUpdateCheck");
			}
			if (MySettingsProperty.Settings.AutomaticUpdateCheck)
			{
				FrmMain.fmain.CheckBoxCheckForUpdates.Checked = true;
			}
			else
			{
				FrmMain.fmain.CheckBoxCheckForUpdates.Checked = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting HideAltTab");
			}
			hideAltTab = MySettingsProperty.Settings.HideAltTab;
			if (MySettingsProperty.Settings.HideAltTab)
			{
				FrmMain.fmain.CheckBoxAltTab.Checked = true;
			}
			else
			{
				FrmMain.fmain.CheckBoxAltTab.Checked = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting StartAppwatcherOnStart");
			}
			if (MySettingsProperty.Settings.StartAppwatcherOnStart)
			{
				FrmMain.fmain.CheckStartWatcher.Checked = true;
			}
			else
			{
				FrmMain.fmain.CheckStartWatcher.Checked = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting VoiceConfirmProfile");
			}
			if (MySettingsProperty.Settings.VoiceConfirmProfile)
			{
				MyProject.Forms.frmProfiles.CheckVoiceConfirm.Checked = true;
			}
			else
			{
				MyProject.Forms.frmProfiles.CheckVoiceConfirm.Checked = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting LibraryPath");
			}
			bool flag = false;
			if ((Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString()))
			{
				string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (CountCharacter(text, ':') > 1)
					{
						flag = true;
						break;
					}
					Log.WriteToLog("Adding " + text + " to known library paths");
					FrmMain.fmain.OculusSoftwarePaths.Add(text);
				}
				if (flag)
				{
					Log.WriteToLog("Found incorrectly formated Library path, resetting to null. Manually added paths must be re-added by the user.");
					MyProject.Forms.FrmMain.AddToListboxAndScroll("* Found incorrectly formated Library path. If you have manually added Library paths you may need to do this again");
					MySettingsProperty.Settings.LibraryPath = "";
					MySettingsProperty.Settings.Save();
					flag = false;
					MyProject.Forms.FrmMain.hasWarning = true;
				}
				Log.WriteToLog("Retrieving and cross-checking Oculus Library paths from the registry");
				List<string> list = (List<string>)OculusPath.GetOculusSoftwarePaths();
				if (list.Count > 0)
				{
					foreach (string item in list)
					{
						if (!MySettingsProperty.Settings.LibraryPath.Contains(item))
						{
							if (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) != 0)
							{
								MySettings settings;
								(settings = MySettingsProperty.Settings).LibraryPath = settings.LibraryPath + "," + item;
							}
							else
							{
								MySettings settings;
								(settings = MySettingsProperty.Settings).LibraryPath = settings.LibraryPath + item + ",";
							}
							Log.WriteToLog("Found new library path: " + item);
						}
						if (!MyProject.Forms.FrmMain.OculusSoftwarePaths.Contains(item))
						{
							FrmMain.fmain.OculusSoftwarePaths.Add(item);
						}
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
			{
				Log.WriteToLog("Reading setting PPDPStartup");
			}
			ppdpstartup = MySettingsProperty.Settings.PPDPStartup;
			FrmMain.fmain.ComboSSstart.Text = ppdpstartup;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting StopOVR");
			}
			FrmMain.fmain.CheckStopService.Checked = MySettingsProperty.Settings.StopOVR;
			FrmMain.fmain.CheckStopServiceHome.Checked = MySettingsProperty.Settings.StopOVRHome;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting StartHomeOnServiceStart");
			}
			FrmMain.fmain.CheckLaunchHome.Checked = MySettingsProperty.Settings.StartHomeOnServiceStart;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting OculusPath");
			}
			if (Operators.CompareString(FrmMain.fmain.OculusPath, "", TextCompare: false) == 0)
			{
				FrmMain.fmain.OculusPath = MySettingsProperty.Settings.OculusPath;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting ApplyPowerPlan");
			}
			FrmMain.fmain.ComboApplyPlan.SelectedIndex = MySettingsProperty.Settings.ApplyPowerPlan;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting StartOVR");
			}
			FrmMain.fmain.CheckStartService.Checked = MySettingsProperty.Settings.StartOVR;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting StartHomeOnToolStart");
			}
			FrmMain.fmain.CheckLaunchHomeTool.Checked = MySettingsProperty.Settings.StartHomeOnToolStart;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting CloseHomeOnExit");
			}
			FrmMain.fmain.CheckCloseHome.Checked = MySettingsProperty.Settings.CloseHomeOnExit;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting SetRiftAsDefault");
			}
			SetRiftDefault = MySettingsProperty.Settings.SetRiftAsDefault;
			if (MySettingsProperty.Settings.SetRiftAsDefault)
			{
				FrmMain.fmain.CheckRiftAudio.Checked = true;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting FOV");
			}
			if (Operators.CompareString(MySettingsProperty.Settings.FOVh, null, TextCompare: false) != 0)
			{
				MyProject.Forms.FrmMain.NumericFOVh.Value = Conversions.ToDecimal(MySettingsProperty.Settings.FOVh);
			}
			if (Operators.CompareString(MySettingsProperty.Settings.FOVv, null, TextCompare: false) != 0)
			{
				MyProject.Forms.FrmMain.NumericFOVv.Value = Conversions.ToDecimal(MySettingsProperty.Settings.FOVv);
			}
			if (Operators.CompareString(MySettingsProperty.Settings.HotKeyCombos, "", TextCompare: false) != 0)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Reading setting HotKeyCombos");
				}
				GetHotKeys();
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting UseHotKeys");
			}
			if (MySettingsProperty.Settings.UseHotKeys & (Operators.CompareString(MySettingsProperty.Settings.HotKeyCombos, "", TextCompare: false) != 0))
			{
				UseHotKeys = true;
				MyProject.Forms.FrmMain.HotKeysCheckBox.Checked = true;
				MyProject.Forms.FrmMain.BtnConfigureHotKeys.Enabled = true;
				FrmMain.fmain.AddToListboxAndScroll("HotKeys will be usabled once Oculus Home is running");
			}
			else
			{
				UseHotKeys = false;
				MyProject.Forms.FrmMain.HotKeysCheckBox.Checked = false;
				MyProject.Forms.FrmMain.BtnConfigureHotKeys.Enabled = false;
				object obj = null;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting CloseOnX");
			}
			if (!MySettingsProperty.Settings.CloseOnX)
			{
				FrmMain.fmain.CheckMinimizeOnX.Checked = true;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting DisableSensorPower");
			}
			if (MySettingsProperty.Settings.DisableSensorPower)
			{
				FrmMain.fmain.CheckSensorPower.Checked = true;
				PowerPlans.CheckPowerState(change: true);
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting Confidence");
			}
			MyProject.Forms.frmVoiceSettings.TrackBar1.Value = MySettingsProperty.Settings.Confidence;
			MyProject.Forms.frmVoiceSettings.LabelConfidencePercent.Text = Conversions.ToString(MyProject.Forms.frmVoiceSettings.TrackBar1.Value) + "%";
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting SendHomeToTray");
			}
			if (MySettingsProperty.Settings.SendHomeToTray)
			{
				FrmMain.fmain.CheckSendHomeToTray.Checked = true;
			}
			else
			{
				FrmMain.fmain.CheckSendHomeToTray.Checked = false;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting SendHomeToTrayOnStart");
			}
			if (MySettingsProperty.Settings.SendHomeToTrayOnStart)
			{
				FrmMain.fmain.CheckSendHomeToTrayOnStart.Checked = true;
			}
			else
			{
				FrmMain.fmain.CheckSendHomeToTrayOnStart.Checked = false;
			}
			GetDevices.GetAllAudioDevices();
			GetDevices.GetAllMicDevices();
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting HomelessEnabled");
			}
			MyProject.Forms.FrmMain.ComboHomless.SelectedIndex = MySettingsProperty.Settings.HomelessEnabled;
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting HomelessVolume");
			}
			MyProject.Forms.frmHomeless.NumericVolume.Value = new decimal((double)MySettingsProperty.Settings.HomelessVolume / 10.0);
			if (MySettingsProperty.Settings.HomelessEnabled == 1)
			{
				MyProject.Forms.FrmMain.BtnHomless.Enabled = true;
				if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
				{
					string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
					string[] array3 = files;
					foreach (string path in array3)
					{
						MyProject.Forms.frmHomeless.ComboMusic.Items.Add(Path.GetFileName(path));
					}
				}
				if (Globals.dbg)
				{
					Log.WriteToLog("Reading setting HomlessColor");
				}
				string[] array4 = Strings.Split(MySettingsProperty.Settings.HomlessColor);
				Color backColor = Color.FromArgb(Conversions.ToInteger(array4[0]), Conversions.ToInteger(array4[1]), Conversions.ToInteger(array4[2]));
				MyProject.Forms.frmHomeless.TextBox1.BackColor = backColor;
				if (Globals.dbg)
				{
					Log.WriteToLog("Reading setting HomelessMusic");
				}
				MyProject.Forms.frmHomeless.ComboMusic.Text = MySettingsProperty.Settings.HomelessMusic;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting MirrorHome");
			}
			if (MySettingsProperty.Settings.MirrorHome)
			{
				FrmMain.fmain.ComboMirrorHome.SelectedIndex = 0;
			}
			else
			{
				FrmMain.fmain.ComboMirrorHome.SelectedIndex = 1;
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Reading setting RestartServiceAfterSleep");
			}
			if (MySettingsProperty.Settings.RestartServiceAfterSleep)
			{
				FrmMain.fmain.CheckRestartSleep.Checked = true;
			}
			else
			{
				FrmMain.fmain.CheckRestartSleep.Checked = false;
			}
			if (MySettingsProperty.Settings.HotKeyVoiceConfirmation)
			{
				MyProject.Forms.frmHotKeys.CheckBox1.Checked = true;
			}
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
			{
				MyProject.Forms.frmVoiceSettings.CheckBox2.Checked = true;
			}
			if (MySettingsProperty.Settings.VoiceActivationVoiceContinous)
			{
				MyProject.Forms.frmVoiceSettings.CheckBox1.Checked = true;
			}
			GetControllers.GetAllControllers();
			MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
			FrmMain.fmain.LoadVoiceSettings();
			if (MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
			{
				MyProject.Forms.frmVoiceSettings.CheckBox7.Checked = true;
			}
			if (MySettingsProperty.Settings.AdaptiveGPUScaling)
			{
				MyProject.Forms.FrmMain.ComboBox5.SelectedIndex = 0;
			}
			else
			{
				MyProject.Forms.FrmMain.ComboBox5.SelectedIndex = 1;
			}
			MyProject.Forms.FrmMain.ComboBox8.Text = MySettingsProperty.Settings.ForceMipmap;
			MyProject.Forms.FrmMain.ComboBox9.Text = MySettingsProperty.Settings.OffsetMipmap;
			if (Operators.CompareString(MySettingsProperty.Settings.DesktopResolution, "", TextCompare: false) == 0)
			{
				MySettingsProperty.Settings.DesktopResolution = Conversions.ToString(MyProject.Forms.FrmMain.GetCurrentResolution());
			}
			MySettingsProperty.Settings.Save();
			MyProject.Forms.frmProfiles.ComboResolution.Text = MySettingsProperty.Settings.DesktopResolution;
			Log.WriteToLog("Done reading configuration parameters");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("Error reading configuration parameters: " + ex2.Message);
			MyProject.Forms.FrmMain.hasError = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private static int CountCharacter(string value, char ch)
	{
		return value.Count([SpecialName] (char c) => c == ch);
	}

	public static void GetHotKeys()
	{
		MyProject.Forms.frmHotKeys.ListView1.Items.Clear();
		MyProject.Forms.frmHotKeys.KeyList.Clear();
		MyProject.Forms.FrmMain.FuncToKeyDictionary.Clear();
		MyProject.Forms.frmHotKeys.FunctionList.Clear();
		string[] array = Strings.Split(MySettingsProperty.Settings.HotKeyCombos, ";");
		if (array.Length <= 0)
		{
			return;
		}
		string[] array2 = array;
		foreach (string expression in array2)
		{
			string[] array3 = Strings.Split(expression, ",");
			ListViewItem listViewItem = new ListViewItem();
			listViewItem = MyProject.Forms.frmHotKeys.ListView1.Items.Add(array3[0]);
			if (array3.Length > 2)
			{
				listViewItem.SubItems.Add(array3[2]);
				MyProject.Forms.frmHotKeys.KeyList.Add(array3[2]);
				MyProject.Forms.FrmMain.FuncToKeyDictionary.Add(array3[2], array3[0]);
				MyProject.Forms.frmHotKeys.FunctionList.Add(array3[0]);
			}
			if (array3.Length == 2)
			{
				listViewItem.SubItems.Add(array3[1]);
				MyProject.Forms.frmHotKeys.KeyList.Add(array3[1]);
				MyProject.Forms.FrmMain.FuncToKeyDictionary.Add(array3[1], array3[0]);
				MyProject.Forms.frmHotKeys.FunctionList.Add(array3[0]);
			}
		}
	}
}
