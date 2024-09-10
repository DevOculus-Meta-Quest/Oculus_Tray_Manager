using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CoreAudio;
using Microsoft.Speech.Recognition;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class VoiceCommands
{
	public static SpeechRecognitionEngine sRecognize = null;

	public static SpeechRecognitionEngine sRecognizeStartStop = null;

	public static bool isListening = false;

	public static bool grammarsBuilt = false;

	public static void Initialize()
	{
		try
		{
			sRecognize = new SpeechRecognitionEngine();
			sRecognizeStartStop = new SpeechRecognitionEngine();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Initialize: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void StartStopBuilder()
	{
		try
		{
			Log.WriteToLog("Initializing voice recognition");
			CultureInfo culture = new CultureInfo(CultureInfo.CurrentUICulture.Name);
			sRecognizeStartStop = new SpeechRecognitionEngine(culture);
			sRecognizeStartStop.SetInputToDefaultAudioDevice();
			Choices alternateChoices = new Choices(Strings.Split(MySettingsProperty.Settings.StartVoice, ";"));
			GrammarBuilder builder = new GrammarBuilder(alternateChoices);
			Grammar grammar = new Grammar(builder);
			grammar.Name = "Start";
			Choices alternateChoices2 = new Choices(Strings.Split(MySettingsProperty.Settings.StopVoice, ";"));
			builder = new GrammarBuilder(alternateChoices2);
			Grammar grammar2 = new Grammar(builder);
			grammar2.Name = "Stop";
			sRecognizeStartStop.LoadGrammarAsync(grammar);
			sRecognizeStartStop.LoadGrammarAsync(grammar2);
			sRecognizeStartStop.RecognizeAsync(RecognizeMode.Multiple);
			grammarsBuilt = true;
			sRecognizeStartStop.SpeechRecognized += sRecognizeStartStop_SpeechRecognized;
			MMDeviceEnumerator mMDeviceEnumerator = new MMDeviceEnumerator();
			MMDevice defaultAudioEndpoint = mMDeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole);
			FrmMain.fmain.AddToListboxAndScroll("Voice recognition initialized, waiting for Oculus Home to start");
			FrmMain.fmain.AddToListboxAndScroll(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Input device: ", defaultAudioEndpoint.Properties.GetValue(1).Value), " ("), defaultAudioEndpoint.FriendlyName), ")")));
			FrmMain.fmain.AddToListboxAndScroll("Input volume: " + Conversions.ToString(defaultAudioEndpoint.AudioEndpointVolume.MasterVolumeLevelScalar * 100f) + "%");
			FrmMain.fmain.AddToListboxAndScroll("Confidence level: " + Conversions.ToString(MySettingsProperty.Settings.Confidence) + "%");
			FrmMain.fmain.AddToListboxAndScroll("Language: " + sRecognizeStartStop.RecognizerInfo.Culture.EnglishName);
			if (!defaultAudioEndpoint.FriendlyName.ToLower().Contains("rift"))
			{
				Log.WriteToLog("Rift microphone is not the default input device.");
				FrmMain.fmain.AddToListboxAndScroll("Rift microphone is not the default input device");
				if (MySettingsProperty.Settings.ShowMicNotDefaultWarning)
				{
					MyProject.Forms.frmMicNotDefaultWarning.TopMost = true;
					MyProject.Forms.frmMicNotDefaultWarning.Show();
				}
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Start/Stop grammars built, ready to receive commands");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("Voice recognition initialization failed: " + ex2.Message);
			Log.WriteToLog("Voice recognition initialization failed: " + ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public static void buildGrammars()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Building Grammars for Voice recognition");
		}
		Choices alternateChoices = new Choices(Strings.Split(MySettingsProperty.Settings.EnableASW, ";"));
		GrammarBuilder builder = new GrammarBuilder(alternateChoices);
		Grammar grammar = new Grammar(builder);
		grammar.Name = "EnableASW";
		Choices alternateChoices2 = new Choices(Strings.Split(MySettingsProperty.Settings.DisableASW, ";"));
		builder = new GrammarBuilder(alternateChoices2);
		Grammar grammar2 = new Grammar(builder);
		grammar2.Name = "DisableASW";
		Choices alternateChoices3 = new Choices(Strings.Split(MySettingsProperty.Settings.LockASWOn, ";"));
		builder = new GrammarBuilder(alternateChoices3);
		Grammar grammar3 = new Grammar(builder);
		grammar3.Name = "LockASWOn";
		Choices alternateChoices4 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowPerf, ";"));
		builder = new GrammarBuilder(alternateChoices4);
		Grammar grammar4 = new Grammar(builder);
		grammar4.Name = "ShowPerf";
		Choices alternateChoices5 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowPD, ";"));
		builder = new GrammarBuilder(alternateChoices5);
		Grammar grammar5 = new Grammar(builder);
		grammar5.Name = "ShowPD";
		Choices alternateChoices6 = new Choices(Strings.Split(MySettingsProperty.Settings.Close, ";"));
		builder = new GrammarBuilder(alternateChoices6);
		Grammar grammar6 = new Grammar(builder);
		grammar6.Name = "Close";
		Choices alternateChoices7 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowASW, ";"));
		builder = new GrammarBuilder(alternateChoices7);
		Grammar grammar7 = new Grammar(builder);
		grammar7.Name = "ShowASW";
		Choices alternateChoices8 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowLatency, ";"));
		builder = new GrammarBuilder(alternateChoices8);
		Grammar grammar8 = new Grammar(builder);
		grammar8.Name = "ShowLatency";
		Choices alternateChoices9 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowApplicationRender, ";"));
		builder = new GrammarBuilder(alternateChoices9);
		Grammar grammar9 = new Grammar(builder);
		grammar9.Name = "ShowApplicationRender";
		Choices alternateChoices10 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowCompositorRender, ";"));
		builder = new GrammarBuilder(alternateChoices10);
		Grammar grammar10 = new Grammar(builder);
		grammar10.Name = "ShowCompositorRender";
		Choices alternateChoices11 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowVersion, ";"));
		builder = new GrammarBuilder(alternateChoices11);
		Grammar grammar11 = new Grammar(builder);
		grammar11.Name = "ShowVersion";
		Choices alternateChoices12 = new Choices(Strings.Split(MySettingsProperty.Settings.LaunchSteam, ";"));
		builder = new GrammarBuilder(alternateChoices12);
		Grammar grammar12 = new Grammar(builder);
		grammar12.Name = "StartSteam";
		Choices alternateChoices13 = new Choices("0", "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9", "2.0", "2.1", "2.2", "2.3", "2.4", "2.5");
		Choices alternateChoices14 = new Choices(Strings.Split(MySettingsProperty.Settings.SetPD, ";"));
		GrammarBuilder grammarBuilder = new GrammarBuilder();
		grammarBuilder.Append(alternateChoices14);
		grammarBuilder.Append(alternateChoices13);
		Grammar grammar13 = new Grammar(grammarBuilder);
		grammar13.Name = "SS";
		if (Globals.dbg)
		{
			Log.WriteToLog("Building Grammars Done");
		}
		try
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Loading Grammars");
			}
			sRecognize.RequestRecognizerUpdate();
			if (MySettingsProperty.Settings.EnableASWEnabled)
			{
				sRecognize.LoadGrammar(grammar);
			}
			if (MySettingsProperty.Settings.DisableASWEnabled)
			{
				sRecognize.LoadGrammar(grammar2);
			}
			if (MySettingsProperty.Settings.LockASWOnEnabled)
			{
				sRecognize.LoadGrammar(grammar3);
			}
			if (MySettingsProperty.Settings.ShowPerfEnabled)
			{
				sRecognize.LoadGrammar(grammar4);
			}
			if (MySettingsProperty.Settings.ShowPDEnabled)
			{
				sRecognize.LoadGrammar(grammar5);
			}
			if (MySettingsProperty.Settings.CloseEnabled)
			{
				sRecognize.LoadGrammar(grammar6);
			}
			if (MySettingsProperty.Settings.SetPDEnabled)
			{
				sRecognize.LoadGrammar(grammar13);
			}
			if (MySettingsProperty.Settings.ShowASWEnabled)
			{
				sRecognize.LoadGrammar(grammar7);
			}
			if (MySettingsProperty.Settings.ShowLatencyEnabled)
			{
				sRecognize.LoadGrammar(grammar8);
			}
			if (MySettingsProperty.Settings.ShowApplicationRenderEnabled)
			{
				sRecognize.LoadGrammar(grammar9);
			}
			if (MySettingsProperty.Settings.ShowCompositorRenderEnabled)
			{
				sRecognize.LoadGrammar(grammar10);
			}
			if (MySettingsProperty.Settings.ShowVersionEnabled)
			{
				sRecognize.LoadGrammar(grammar11);
			}
			if (MySettingsProperty.Settings.LaunchSteamEnabled)
			{
				sRecognize.LoadGrammar(grammar12);
			}
			sRecognize.RecognizeAsync(RecognizeMode.Multiple);
			if (Globals.dbg)
			{
				Log.WriteToLog("Loading Grammars Done");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("Grammar construction failed: " + ex2.Message);
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	private static void sRecognizeStartStop_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
	{
		if ((double)e.Result.Confidence < (double)MySettingsProperty.Settings.Confidence / 100.0)
		{
			FrmMain.fmain.AddToListboxAndScroll("Confidence level is too low: " + Conversions.ToString(Math.Round(e.Result.Confidence * 100f)) + "%");
		}
		else
		{
			FrmMain.fmain.AddToListboxAndScroll("Recognized '" + e.Result.Text + "'. Confidence: " + Conversions.ToString(Math.Round(e.Result.Confidence * 100f)) + "%");
			if (Operators.CompareString(e.Result.Grammar.Name, "Start", TextCompare: false) == 0 && !isListening)
			{
				if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
				{
					Thread thread = new Thread([SpecialName] () =>
					{
						MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
					});
					thread.Start();
				}
				Log.WriteToLog("Adding handler for speech recognition");
				CultureInfo culture = new CultureInfo(CultureInfo.CurrentUICulture.Name);
				sRecognize = new SpeechRecognitionEngine(culture);
				sRecognize.SetInputToDefaultAudioDevice();
				sRecognize.SpeechRecognized += sRecognize_SpeechRecognized;
				buildGrammars();
				isListening = true;
			}
			if (Operators.CompareString(e.Result.Grammar.Name, "Stop", TextCompare: false) == 0 && isListening)
			{
				sRecognize.RecognizeAsyncCancel();
				sRecognize.SpeechRecognized -= sRecognize_SpeechRecognized;
				isListening = false;
				if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
				{
					Thread thread2 = new Thread([SpecialName] () =>
					{
						MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav");
					});
					thread2.Start();
				}
			}
		}
		Thread.Sleep(100);
	}

	public static void StopListening()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering StopListening");
		}
		if (isListening)
		{
			sRecognize.RecognizeAsyncCancel();
			sRecognize.SpeechRecognized -= sRecognize_SpeechRecognized;
			isListening = false;
		}
		if (Globals.dbg)
		{
			Log.WriteToLog("Exiting StopListening");
		}
	}

	public static void DisableVoice()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering DisableVoice");
		}
		if (grammarsBuilt)
		{
			sRecognizeStartStop.RecognizeAsyncCancel();
			sRecognizeStartStop.SpeechRecognized -= sRecognizeStartStop_SpeechRecognized;
			isListening = false;
			grammarsBuilt = false;
		}
		if (Globals.dbg)
		{
			Log.WriteToLog("Exiting DisableVoice");
		}
	}

	public static void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
	{
		if (!isListening)
		{
			return;
		}
		if ((double)e.Result.Confidence < (double)MySettingsProperty.Settings.Confidence / 100.0)
		{
			FrmMain.fmain.AddToListboxAndScroll("Confidence too low at " + Conversions.ToString(Math.Round(e.Result.Confidence * 100f)) + "%");
			return;
		}
		FrmMain.fmain.AddToListboxAndScroll("Recognized '" + e.Result.Text + "'. Confidence: " + Conversions.ToString(Math.Round(e.Result.Confidence * 100f)) + "%");
		if (Operators.CompareString(e.Result.Grammar.Name, "SS", TextCompare: false) == 0)
		{
			Thread thread = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool(e.Result.Words.Last().Text);
			});
			thread.Start();
			if (!MySettingsProperty.Settings.DisableCallback)
			{
				Thread thread2 = new Thread([SpecialName] () =>
				{
					MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\affirmative.wav");
				});
				thread2.Start();
			}
			if (Operators.CompareString(MyProject.Forms.FrmMain.runningApp, null, TextCompare: false) != 0)
			{
				string value = "";
				string value2 = "";
				MyProject.Forms.FrmMain.profileASWList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value2);
				if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value))
				{
					string displayName = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
					OTTDB.UpdateProfile("", e.Result.Words.Last().Text, MyProject.Forms.FrmMain.runningApp, displayName);
				}
				MyProject.Forms.FrmMain.CurrentSS = e.Result.Words.Last().Text;
			}
			else
			{
				FrmMain.fmain.AddToListboxAndScroll(e.Result.Text);
			}
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "EnableASW", TextCompare: false) == 0)
		{
			Thread thread3 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Auto");
			});
			thread3.Start();
			FrmMain.fmain.AddToListboxAndScroll("ASW set to Auto");
			GetConfig.IsReading = true;
			MyProject.Forms.FrmMain.ComboBox1.Text = "Auto";
			GetConfig.IsReading = false;
			if (!MySettingsProperty.Settings.DisableCallback)
			{
				Thread thread4 = new Thread([SpecialName] () =>
				{
					MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav");
				});
				thread4.Start();
			}
			if (Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", TextCompare: false) != 0)
			{
				string value3 = "";
				if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value3))
				{
					string displayName2 = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
					OTTDB.UpdateProfile("Auto", "", MyProject.Forms.FrmMain.runningApp, displayName2);
				}
			}
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "DisableASW", TextCompare: false) == 0)
		{
			Thread thread5 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Off");
			});
			thread5.Start();
			FrmMain.fmain.AddToListboxAndScroll("ASW set to Off");
			GetConfig.IsReading = true;
			MyProject.Forms.FrmMain.ComboBox1.Text = "Off";
			GetConfig.IsReading = false;
			if (!MySettingsProperty.Settings.DisableCallback)
			{
				Thread thread6 = new Thread([SpecialName] () =>
				{
					MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav");
				});
				thread6.Start();
			}
			if (Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", TextCompare: false) != 0)
			{
				string value4 = "";
				if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value4))
				{
					string displayName3 = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
					OTTDB.UpdateProfile("Off", "", MyProject.Forms.FrmMain.runningApp, displayName3);
				}
			}
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "LockASWOn", TextCompare: false) == 0)
		{
			Thread thread7 = new Thread([SpecialName] () =>
			{
				RunCommand.Run_debug_tool_asw("server:asw.Clock45");
			});
			thread7.Start();
			FrmMain.fmain.AddToListboxAndScroll("Framerate Locked @ 45 fps");
			GetConfig.IsReading = true;
			MyProject.Forms.FrmMain.ComboBox1.Text = "45 fps";
			GetConfig.IsReading = false;
			if (!MySettingsProperty.Settings.DisableCallback)
			{
				Thread thread8 = new Thread([SpecialName] () =>
				{
					MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelocked.wav");
				});
				thread8.Start();
			}
			if (Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", TextCompare: false) != 0)
			{
				string value5 = "";
				if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out value5))
				{
					string displayName4 = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
					OTTDB.UpdateProfile("45 fps", "", MyProject.Forms.FrmMain.runningApp, displayName4);
				}
			}
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "Close", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 0;
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "ShowPD", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 1;
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "ShowPerf", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 2;
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "ShowASW", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 3;
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "ShowLatency", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 4;
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "ShowApplicationRender", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 5;
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "ShowCompositorRender", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 6;
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "ShowVersion", TextCompare: false) == 0)
		{
			MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 7;
		}
		if (Operators.CompareString(e.Result.Grammar.Name, "StartSteam", TextCompare: false) == 0)
		{
			if (File.Exists(MyProject.Forms.FrmMain.SteamPath + "\\Steam.exe"))
			{
				Log.WriteToLog("Launching SteamVR");
				FrmMain.fmain.AddToListboxAndScroll("Launching SteamVR");
				if (!MySettingsProperty.Settings.DisableCallback)
				{
					Thread thread9 = new Thread([SpecialName] () =>
					{
						MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\onemoment.wav");
					});
					thread9.Start();
				}
				Process process = new Process();
				ProcessStartInfo processStartInfo = new ProcessStartInfo(MyProject.Forms.FrmMain.SteamPath + "\\Steam.exe");
				processStartInfo.UseShellExecute = false;
				processStartInfo.CreateNoWindow = true;
				processStartInfo.Arguments = " -applaunch 250820";
				process.StartInfo = processStartInfo;
				process.Start();
			}
			else
			{
				FrmMain.fmain.AddToListboxAndScroll("Unable to launch SteamVR, Steam not found");
			}
		}
		if (!MySettingsProperty.Settings.VoiceActivationVoiceRepeated)
		{
			return;
		}
		if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
		{
			Thread thread10 = new Thread([SpecialName] () =>
			{
				MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav");
			});
			thread10.Start();
		}
		StopListening();
	}
}
