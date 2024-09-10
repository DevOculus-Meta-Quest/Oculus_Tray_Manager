using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000027 RID: 39
	[StandardModule]
	internal sealed class GetConfig
	{
		// Token: 0x060003DC RID: 988 RVA: 0x000171E8 File Offset: 0x000153E8
		public static void GetConfig()
		{
			try
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Entering GetConfig");
				}
				MySettingsProperty.Settings.NoHome = false;
				MySettingsProperty.Settings.Save();
				Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
				Log.WriteToLog("Reading configuration parameters from " + configuration.FilePath);
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Reading setting StartMinimized");
				}
				bool startMinimized = MySettingsProperty.Settings.StartMinimized;
				if (startMinimized)
				{
					MyProject.Forms.FrmMain.CheckStartMin.Checked = true;
				}
				else
				{
					MyProject.Forms.FrmMain.CheckStartMin.Checked = false;
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Reading setting PowerPlanStart");
				}
				bool flag = Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "Not Used", false) != 0;
				if (flag)
				{
					bool flag2 = MySettingsProperty.Settings.ApplyPowerPlan == 0;
					if (flag2)
					{
						PowerPlans.SetActivePowerPlan(MySettingsProperty.Settings.PowerPlanStart);
					}
					MyProject.Forms.FrmMain.ComboPowerPlanStart.Text = MySettingsProperty.Settings.PowerPlanStart;
				}
				else
				{
					bool flag3 = (Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "Not Used", false) == 0) | (Operators.CompareString(MySettingsProperty.Settings.PowerPlanStart, "", false) == 0);
					if (flag3)
					{
						MyProject.Forms.FrmMain.ComboPowerPlanStart.Text = "Not Used";
						PowerPlans.GetActivePowerPlan();
					}
				}
				bool dbg4 = Globals.dbg;
				if (dbg4)
				{
					Log.WriteToLog("Reading setting PowerPlanExit");
				}
				bool flag4 = Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", false) != 0;
				if (flag4)
				{
					MyProject.Forms.FrmMain.ComboPowerPlanExit.Text = MySettingsProperty.Settings.PowerPlanExit;
				}
				else
				{
					bool flag5 = (Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "Not Used", false) == 0) | (Operators.CompareString(MySettingsProperty.Settings.PowerPlanExit, "", false) == 0);
					if (flag5)
					{
						MyProject.Forms.FrmMain.ComboPowerPlanExit.Text = "Not Used";
					}
				}
				bool dbg5 = Globals.dbg;
				if (dbg5)
				{
					Log.WriteToLog("Reading setting StartHomeDelay");
				}
				OculusTrayTool.GetConfig.StartHomeDelay = MySettingsProperty.Settings.StartHomeDelay;
				bool dbg6 = Globals.dbg;
				if (dbg6)
				{
					Log.WriteToLog("Reading setting UseVoiceCommands");
				}
				OculusTrayTool.GetConfig.useVoiceCommands = MySettingsProperty.Settings.UseVoiceCommands;
				bool flag6 = MySettingsProperty.Settings.UseVoiceCommands;
				if (flag6)
				{
					MyProject.Forms.FrmMain.ComboVoice.Text = "Enabled";
					MyProject.Forms.FrmMain.BtnVoice.Enabled = true;
					CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.Name);
					VoiceCommands.sRecognize = new SpeechRecognitionEngine(cultureInfo);
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
				bool dbg7 = Globals.dbg;
				if (dbg7)
				{
					Log.WriteToLog("Reading setting AutomaticUpdateCheck");
				}
				bool automaticUpdateCheck = MySettingsProperty.Settings.AutomaticUpdateCheck;
				if (automaticUpdateCheck)
				{
					FrmMain.fmain.CheckBoxCheckForUpdates.Checked = true;
				}
				else
				{
					FrmMain.fmain.CheckBoxCheckForUpdates.Checked = false;
				}
				bool dbg8 = Globals.dbg;
				if (dbg8)
				{
					Log.WriteToLog("Reading setting HideAltTab");
				}
				OculusTrayTool.GetConfig.hideAltTab = MySettingsProperty.Settings.HideAltTab;
				bool flag7 = MySettingsProperty.Settings.HideAltTab;
				if (flag7)
				{
					FrmMain.fmain.CheckBoxAltTab.Checked = true;
				}
				else
				{
					FrmMain.fmain.CheckBoxAltTab.Checked = false;
				}
				bool dbg9 = Globals.dbg;
				if (dbg9)
				{
					Log.WriteToLog("Reading setting StartAppwatcherOnStart");
				}
				bool startAppwatcherOnStart = MySettingsProperty.Settings.StartAppwatcherOnStart;
				if (startAppwatcherOnStart)
				{
					FrmMain.fmain.CheckStartWatcher.Checked = true;
				}
				else
				{
					FrmMain.fmain.CheckStartWatcher.Checked = false;
				}
				bool dbg10 = Globals.dbg;
				if (dbg10)
				{
					Log.WriteToLog("Reading setting VoiceConfirmProfile");
				}
				bool voiceConfirmProfile = MySettingsProperty.Settings.VoiceConfirmProfile;
				if (voiceConfirmProfile)
				{
					MyProject.Forms.frmProfiles.CheckVoiceConfirm.Checked = true;
				}
				else
				{
					MyProject.Forms.frmProfiles.CheckVoiceConfirm.Checked = false;
				}
				bool dbg11 = Globals.dbg;
				if (dbg11)
				{
					Log.WriteToLog("Reading setting LibraryPath");
				}
				bool flag8 = false;
				bool flag9 = (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString());
				if (flag9)
				{
					string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary);
					foreach (string text in array)
					{
						bool flag10 = OculusTrayTool.GetConfig.CountCharacter(text, ':') > 1;
						if (flag10)
						{
							flag8 = true;
							break;
						}
						Log.WriteToLog("Adding " + text + " to known library paths");
						FrmMain.fmain.OculusSoftwarePaths.Add(text);
					}
					bool flag11 = flag8;
					if (flag11)
					{
						Log.WriteToLog("Found incorrectly formated Library path, resetting to null. Manually added paths must be re-added by the user.");
						MyProject.Forms.FrmMain.AddToListboxAndScroll("* Found incorrectly formated Library path. If you have manually added Library paths you may need to do this again");
						MySettingsProperty.Settings.LibraryPath = "";
						MySettingsProperty.Settings.Save();
						MyProject.Forms.FrmMain.hasWarning = true;
					}
					Log.WriteToLog("Retrieving and cross-checking Oculus Library paths from the registry");
					List<string> list = (List<string>)OculusPath.GetOculusSoftwarePaths();
					bool flag12 = list.Count > 0;
					if (flag12)
					{
						try
						{
							foreach (string text2 in list)
							{
								bool flag13 = !MySettingsProperty.Settings.LibraryPath.Contains(text2);
								if (flag13)
								{
									bool flag14 = Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0;
									if (flag14)
									{
										MySettings mySettings;
										(mySettings = MySettingsProperty.Settings).LibraryPath = mySettings.LibraryPath + "," + text2;
									}
									else
									{
										MySettings mySettings;
										(mySettings = MySettingsProperty.Settings).LibraryPath = mySettings.LibraryPath + text2 + ",";
									}
									Log.WriteToLog("Found new library path: " + text2);
								}
								bool flag15 = !MyProject.Forms.FrmMain.OculusSoftwarePaths.Contains(text2);
								if (flag15)
								{
									FrmMain.fmain.OculusSoftwarePaths.Add(text2);
								}
							}
						}
						finally
						{
							List<string>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						MySettingsProperty.Settings.LibraryPath = MySettingsProperty.Settings.LibraryPath.TrimEnd(new char[] { ',' }).TrimStart(new char[] { ',' });
						MySettingsProperty.Settings.Save();
					}
					else
					{
						Log.WriteToLog("Warning: No library paths returned from registry!");
						FrmMain.fmain.AddToListboxAndScroll("Warning: No library paths returned from registry!");
						MyProject.Forms.FrmMain.hasWarning = true;
					}
				}
				bool dbg12 = Globals.dbg;
				if (dbg12)
				{
					Log.WriteToLog("Reading setting PPDPStartup");
				}
				OculusTrayTool.GetConfig.ppdpstartup = MySettingsProperty.Settings.PPDPStartup;
				FrmMain.fmain.ComboSSstart.Text = OculusTrayTool.GetConfig.ppdpstartup;
				bool dbg13 = Globals.dbg;
				if (dbg13)
				{
					Log.WriteToLog("Reading setting StopOVR");
				}
				FrmMain.fmain.CheckStopService.Checked = MySettingsProperty.Settings.StopOVR;
				FrmMain.fmain.CheckStopServiceHome.Checked = MySettingsProperty.Settings.StopOVRHome;
				bool dbg14 = Globals.dbg;
				if (dbg14)
				{
					Log.WriteToLog("Reading setting StartHomeOnServiceStart");
				}
				FrmMain.fmain.CheckLaunchHome.Checked = MySettingsProperty.Settings.StartHomeOnServiceStart;
				bool dbg15 = Globals.dbg;
				if (dbg15)
				{
					Log.WriteToLog("Reading setting OculusPath");
				}
				bool flag16 = Operators.CompareString(FrmMain.fmain.OculusPath, "", false) == 0;
				if (flag16)
				{
					FrmMain.fmain.OculusPath = MySettingsProperty.Settings.OculusPath;
				}
				bool dbg16 = Globals.dbg;
				if (dbg16)
				{
					Log.WriteToLog("Reading setting ApplyPowerPlan");
				}
				FrmMain.fmain.ComboApplyPlan.SelectedIndex = MySettingsProperty.Settings.ApplyPowerPlan;
				bool dbg17 = Globals.dbg;
				if (dbg17)
				{
					Log.WriteToLog("Reading setting StartOVR");
				}
				FrmMain.fmain.CheckStartService.Checked = MySettingsProperty.Settings.StartOVR;
				bool dbg18 = Globals.dbg;
				if (dbg18)
				{
					Log.WriteToLog("Reading setting StartHomeOnToolStart");
				}
				FrmMain.fmain.CheckLaunchHomeTool.Checked = MySettingsProperty.Settings.StartHomeOnToolStart;
				bool dbg19 = Globals.dbg;
				if (dbg19)
				{
					Log.WriteToLog("Reading setting CloseHomeOnExit");
				}
				FrmMain.fmain.CheckCloseHome.Checked = MySettingsProperty.Settings.CloseHomeOnExit;
				bool dbg20 = Globals.dbg;
				if (dbg20)
				{
					Log.WriteToLog("Reading setting SetRiftAsDefault");
				}
				OculusTrayTool.GetConfig.SetRiftDefault = MySettingsProperty.Settings.SetRiftAsDefault;
				bool setRiftAsDefault = MySettingsProperty.Settings.SetRiftAsDefault;
				if (setRiftAsDefault)
				{
					FrmMain.fmain.CheckRiftAudio.Checked = true;
				}
				bool dbg21 = Globals.dbg;
				if (dbg21)
				{
					Log.WriteToLog("Reading setting FOV");
				}
				bool flag17 = Operators.CompareString(MySettingsProperty.Settings.FOVh, null, false) != 0;
				if (flag17)
				{
					MyProject.Forms.FrmMain.NumericFOVh.Value = Conversions.ToDecimal(MySettingsProperty.Settings.FOVh);
				}
				bool flag18 = Operators.CompareString(MySettingsProperty.Settings.FOVv, null, false) != 0;
				if (flag18)
				{
					MyProject.Forms.FrmMain.NumericFOVv.Value = Conversions.ToDecimal(MySettingsProperty.Settings.FOVv);
				}
				bool flag19 = Operators.CompareString(MySettingsProperty.Settings.HotKeyCombos, "", false) != 0;
				if (flag19)
				{
					bool dbg22 = Globals.dbg;
					if (dbg22)
					{
						Log.WriteToLog("Reading setting HotKeyCombos");
					}
					OculusTrayTool.GetConfig.GetHotKeys();
				}
				bool dbg23 = Globals.dbg;
				if (dbg23)
				{
					Log.WriteToLog("Reading setting UseHotKeys");
				}
				bool flag20 = MySettingsProperty.Settings.UseHotKeys & (Operators.CompareString(MySettingsProperty.Settings.HotKeyCombos, "", false) != 0);
				if (flag20)
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
				bool dbg24 = Globals.dbg;
				if (dbg24)
				{
					Log.WriteToLog("Reading setting CloseOnX");
				}
				bool flag21 = !MySettingsProperty.Settings.CloseOnX;
				if (flag21)
				{
					FrmMain.fmain.CheckMinimizeOnX.Checked = true;
				}
				bool dbg25 = Globals.dbg;
				if (dbg25)
				{
					Log.WriteToLog("Reading setting DisableSensorPower");
				}
				bool disableSensorPower = MySettingsProperty.Settings.DisableSensorPower;
				if (disableSensorPower)
				{
					FrmMain.fmain.CheckSensorPower.Checked = true;
					PowerPlans.CheckPowerState(true);
				}
				bool dbg26 = Globals.dbg;
				if (dbg26)
				{
					Log.WriteToLog("Reading setting Confidence");
				}
				MyProject.Forms.frmVoiceSettings.TrackBar1.Value = MySettingsProperty.Settings.Confidence;
				MyProject.Forms.frmVoiceSettings.LabelConfidencePercent.Text = Conversions.ToString(MyProject.Forms.frmVoiceSettings.TrackBar1.Value) + "%";
				bool dbg27 = Globals.dbg;
				if (dbg27)
				{
					Log.WriteToLog("Reading setting SendHomeToTray");
				}
				bool sendHomeToTray = MySettingsProperty.Settings.SendHomeToTray;
				if (sendHomeToTray)
				{
					FrmMain.fmain.CheckSendHomeToTray.Checked = true;
				}
				else
				{
					FrmMain.fmain.CheckSendHomeToTray.Checked = false;
				}
				bool dbg28 = Globals.dbg;
				if (dbg28)
				{
					Log.WriteToLog("Reading setting SendHomeToTrayOnStart");
				}
				bool sendHomeToTrayOnStart = MySettingsProperty.Settings.SendHomeToTrayOnStart;
				if (sendHomeToTrayOnStart)
				{
					FrmMain.fmain.CheckSendHomeToTrayOnStart.Checked = true;
				}
				else
				{
					FrmMain.fmain.CheckSendHomeToTrayOnStart.Checked = false;
				}
				GetDevices.GetAllAudioDevices();
				GetDevices.GetAllMicDevices();
				bool dbg29 = Globals.dbg;
				if (dbg29)
				{
					Log.WriteToLog("Reading setting HomelessEnabled");
				}
				MyProject.Forms.FrmMain.ComboHomless.SelectedIndex = MySettingsProperty.Settings.HomelessEnabled;
				bool dbg30 = Globals.dbg;
				if (dbg30)
				{
					Log.WriteToLog("Reading setting HomelessVolume");
				}
				MyProject.Forms.frmHomeless.NumericVolume.Value = new decimal((double)MySettingsProperty.Settings.HomelessVolume / 10.0);
				bool flag22 = MySettingsProperty.Settings.HomelessEnabled == 1;
				if (flag22)
				{
					MyProject.Forms.FrmMain.BtnHomless.Enabled = true;
					bool flag23 = Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
					if (flag23)
					{
						string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
						foreach (string text3 in files)
						{
							MyProject.Forms.frmHomeless.ComboMusic.Items.Add(Path.GetFileName(text3));
						}
					}
					bool dbg31 = Globals.dbg;
					if (dbg31)
					{
						Log.WriteToLog("Reading setting HomlessColor");
					}
					string[] array4 = Strings.Split(MySettingsProperty.Settings.HomlessColor, " ", -1, CompareMethod.Binary);
					Color color = Color.FromArgb(Conversions.ToInteger(array4[0]), Conversions.ToInteger(array4[1]), Conversions.ToInteger(array4[2]));
					MyProject.Forms.frmHomeless.TextBox1.BackColor = color;
					bool dbg32 = Globals.dbg;
					if (dbg32)
					{
						Log.WriteToLog("Reading setting HomelessMusic");
					}
					MyProject.Forms.frmHomeless.ComboMusic.Text = MySettingsProperty.Settings.HomelessMusic;
				}
				bool dbg33 = Globals.dbg;
				if (dbg33)
				{
					Log.WriteToLog("Reading setting MirrorHome");
				}
				bool mirrorHome = MySettingsProperty.Settings.MirrorHome;
				if (mirrorHome)
				{
					FrmMain.fmain.ComboMirrorHome.SelectedIndex = 0;
				}
				else
				{
					FrmMain.fmain.ComboMirrorHome.SelectedIndex = 1;
				}
				bool dbg34 = Globals.dbg;
				if (dbg34)
				{
					Log.WriteToLog("Reading setting RestartServiceAfterSleep");
				}
				bool restartServiceAfterSleep = MySettingsProperty.Settings.RestartServiceAfterSleep;
				if (restartServiceAfterSleep)
				{
					FrmMain.fmain.CheckRestartSleep.Checked = true;
				}
				else
				{
					FrmMain.fmain.CheckRestartSleep.Checked = false;
				}
				bool hotKeyVoiceConfirmation = MySettingsProperty.Settings.HotKeyVoiceConfirmation;
				if (hotKeyVoiceConfirmation)
				{
					MyProject.Forms.frmHotKeys.CheckBox1.Checked = true;
				}
				bool joystickActivationKeyContinous = MySettingsProperty.Settings.JoystickActivationKeyContinous;
				if (joystickActivationKeyContinous)
				{
					MyProject.Forms.frmVoiceSettings.CheckBox5.Checked = true;
					MyProject.Forms.frmVoiceSettings.ComboDevice.Enabled = true;
					MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
				}
				bool joystickActivationKeyPush = MySettingsProperty.Settings.JoystickActivationKeyPush;
				if (joystickActivationKeyPush)
				{
					MyProject.Forms.frmVoiceSettings.CheckBox6.Checked = true;
					MyProject.Forms.frmVoiceSettings.ComboDevice.Enabled = true;
					MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
				}
				bool voiceActivationKeyPush = MySettingsProperty.Settings.VoiceActivationKeyPush;
				if (voiceActivationKeyPush)
				{
					MyProject.Forms.frmVoiceSettings.CheckBox4.Checked = true;
					MyProject.Forms.frmVoiceSettings.ComboDevice.Enabled = true;
					MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
				}
				bool voiceActivationKeyContinous = MySettingsProperty.Settings.VoiceActivationKeyContinous;
				if (voiceActivationKeyContinous)
				{
					MyProject.Forms.frmVoiceSettings.CheckBox3.Checked = true;
					MyProject.Forms.frmVoiceSettings.ComboDevice.Enabled = true;
					MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
				}
				bool voiceActivationVoiceRepeated = MySettingsProperty.Settings.VoiceActivationVoiceRepeated;
				if (voiceActivationVoiceRepeated)
				{
					MyProject.Forms.frmVoiceSettings.CheckBox2.Checked = true;
				}
				bool voiceActivationVoiceContinous = MySettingsProperty.Settings.VoiceActivationVoiceContinous;
				if (voiceActivationVoiceContinous)
				{
					MyProject.Forms.frmVoiceSettings.CheckBox1.Checked = true;
				}
				GetControllers.GetAllControllers();
				MyProject.Forms.frmVoiceSettings.AddItemsToDeviceList();
				FrmMain.fmain.LoadVoiceSettings();
				bool disableVoiceControlAudioFeedback = MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
				if (disableVoiceControlAudioFeedback)
				{
					MyProject.Forms.frmVoiceSettings.CheckBox7.Checked = true;
				}
				bool adaptiveGPUScaling = MySettingsProperty.Settings.AdaptiveGPUScaling;
				if (adaptiveGPUScaling)
				{
					MyProject.Forms.FrmMain.ComboBox5.SelectedIndex = 0;
				}
				else
				{
					MyProject.Forms.FrmMain.ComboBox5.SelectedIndex = 1;
				}
				MyProject.Forms.FrmMain.ComboBox8.Text = MySettingsProperty.Settings.ForceMipmap;
				MyProject.Forms.FrmMain.ComboBox9.Text = MySettingsProperty.Settings.OffsetMipmap;
				bool flag24 = Operators.CompareString(MySettingsProperty.Settings.DesktopResolution, "", false) == 0;
				if (flag24)
				{
					MySettingsProperty.Settings.DesktopResolution = Conversions.ToString(MyProject.Forms.FrmMain.GetCurrentResolution());
				}
				MySettingsProperty.Settings.Save();
				MyProject.Forms.frmProfiles.ComboResolution.Text = MySettingsProperty.Settings.DesktopResolution;
				Log.WriteToLog("Done reading configuration parameters");
			}
			catch (Exception ex)
			{
				FrmMain.fmain.AddToListboxAndScroll("Error reading configuration parameters: " + ex.Message);
				MyProject.Forms.FrmMain.hasError = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00018430 File Offset: 0x00016630
		private static int CountCharacter(string value, char ch)
		{
			return value.Count((char c) => c == ch);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00018464 File Offset: 0x00016664
		public static void GetHotKeys()
		{
			MyProject.Forms.frmHotKeys.ListView1.Items.Clear();
			MyProject.Forms.frmHotKeys.KeyList.Clear();
			MyProject.Forms.FrmMain.FuncToKeyDictionary.Clear();
			MyProject.Forms.frmHotKeys.FunctionList.Clear();
			string[] array = Strings.Split(MySettingsProperty.Settings.HotKeyCombos, ";", -1, CompareMethod.Binary);
			bool flag = array.Length > 0;
			if (flag)
			{
				foreach (string text in array)
				{
					string[] array3 = Strings.Split(text, ",", -1, CompareMethod.Binary);
					ListViewItem listViewItem = new ListViewItem();
					listViewItem = MyProject.Forms.frmHotKeys.ListView1.Items.Add(array3[0]);
					bool flag2 = array3.Length > 2;
					if (flag2)
					{
						listViewItem.SubItems.Add(array3[2]);
						MyProject.Forms.frmHotKeys.KeyList.Add(array3[2]);
						MyProject.Forms.FrmMain.FuncToKeyDictionary.Add(array3[2], array3[0]);
						MyProject.Forms.frmHotKeys.FunctionList.Add(array3[0]);
					}
					bool flag3 = array3.Length == 2;
					if (flag3)
					{
						listViewItem.SubItems.Add(array3[1]);
						MyProject.Forms.frmHotKeys.KeyList.Add(array3[1]);
						MyProject.Forms.FrmMain.FuncToKeyDictionary.Add(array3[1], array3[0]);
						MyProject.Forms.frmHotKeys.FunctionList.Add(array3[0]);
					}
				}
			}
		}

		// Token: 0x04000140 RID: 320
		public static bool disable_fresco_power = false;

		// Token: 0x04000141 RID: 321
		public static string ppdp;

		// Token: 0x04000142 RID: 322
		public static string ppdpstartup;

		// Token: 0x04000143 RID: 323
		public static bool hideAltTab = false;

		// Token: 0x04000144 RID: 324
		public static string RiftAudioDevice;

		// Token: 0x04000145 RID: 325
		public static string RiftMicDevice;

		// Token: 0x04000146 RID: 326
		public static bool SetRiftDefault = false;

		// Token: 0x04000147 RID: 327
		public static bool useVoiceCommands = false;

		// Token: 0x04000148 RID: 328
		public static string DefaultAudioName;

		// Token: 0x04000149 RID: 329
		public static string DefaultMicName;

		// Token: 0x0400014A RID: 330
		public static bool SetPowerPlan = false;

		// Token: 0x0400014B RID: 331
		public static int StartHomeDelay;

		// Token: 0x0400014C RID: 332
		public static bool UseHotKeys = false;

		// Token: 0x0400014D RID: 333
		public static bool IsReading = false;

		// Token: 0x0400014E RID: 334
		public static int numprofiles = 0;

		// Token: 0x0400014F RID: 335
		public static bool ProfilesRead = false;
	}
}
