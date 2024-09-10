using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CoreAudio;
using Microsoft.Speech.Recognition;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x0200005F RID: 95
	[StandardModule]
	internal sealed class VoiceCommands
	{
		// Token: 0x06000934 RID: 2356 RVA: 0x00054C40 File Offset: 0x00052E40
		public static void Initialize()
		{
			try
			{
				VoiceCommands.sRecognize = new SpeechRecognitionEngine();
				VoiceCommands.sRecognizeStartStop = new SpeechRecognitionEngine();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Initialize: " + ex.Message);
			}
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00054C9C File Offset: 0x00052E9C
		public static void StartStopBuilder()
		{
			try
			{
				Log.WriteToLog("Initializing voice recognition");
				CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.Name);
				VoiceCommands.sRecognizeStartStop = new SpeechRecognitionEngine(cultureInfo);
				VoiceCommands.sRecognizeStartStop.SetInputToDefaultAudioDevice();
				Choices choices = new Choices(Strings.Split(MySettingsProperty.Settings.StartVoice, ";", -1, CompareMethod.Binary));
				GrammarBuilder grammarBuilder = new GrammarBuilder(choices);
				Grammar grammar = new Grammar(grammarBuilder);
				grammar.Name = "Start";
				Choices choices2 = new Choices(Strings.Split(MySettingsProperty.Settings.StopVoice, ";", -1, CompareMethod.Binary));
				grammarBuilder = new GrammarBuilder(choices2);
				Grammar grammar2 = new Grammar(grammarBuilder);
				grammar2.Name = "Stop";
				VoiceCommands.sRecognizeStartStop.LoadGrammarAsync(grammar);
				VoiceCommands.sRecognizeStartStop.LoadGrammarAsync(grammar2);
				VoiceCommands.sRecognizeStartStop.RecognizeAsync(RecognizeMode.Multiple);
				VoiceCommands.grammarsBuilt = true;
				VoiceCommands.sRecognizeStartStop.SpeechRecognized += VoiceCommands.sRecognizeStartStop_SpeechRecognized;
				MMDeviceEnumerator mmdeviceEnumerator = new MMDeviceEnumerator();
				MMDevice defaultAudioEndpoint = mmdeviceEnumerator.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole);
				FrmMain.fmain.AddToListboxAndScroll("Voice recognition initialized, waiting for Oculus Home to start");
				FrmMain.fmain.AddToListboxAndScroll(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("Input device: ", defaultAudioEndpoint.Properties.GetValue(1).Value), " ("), defaultAudioEndpoint.FriendlyName), ")")));
				FrmMain.fmain.AddToListboxAndScroll("Input volume: " + Conversions.ToString(defaultAudioEndpoint.AudioEndpointVolume.MasterVolumeLevelScalar * 100f) + "%");
				FrmMain.fmain.AddToListboxAndScroll("Confidence level: " + Conversions.ToString(MySettingsProperty.Settings.Confidence) + "%");
				FrmMain.fmain.AddToListboxAndScroll("Language: " + VoiceCommands.sRecognizeStartStop.RecognizerInfo.Culture.EnglishName);
				bool flag = !defaultAudioEndpoint.FriendlyName.ToLower().Contains("rift");
				if (flag)
				{
					Log.WriteToLog("Rift microphone is not the default input device.");
					FrmMain.fmain.AddToListboxAndScroll("Rift microphone is not the default input device");
					bool showMicNotDefaultWarning = MySettingsProperty.Settings.ShowMicNotDefaultWarning;
					if (showMicNotDefaultWarning)
					{
						MyProject.Forms.frmMicNotDefaultWarning.TopMost = true;
						MyProject.Forms.frmMicNotDefaultWarning.Show();
					}
				}
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Start/Stop grammars built, ready to receive commands");
				}
			}
			catch (Exception ex)
			{
				FrmMain.fmain.AddToListboxAndScroll("Voice recognition initialization failed: " + ex.Message);
				Log.WriteToLog("Voice recognition initialization failed: " + ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00054F90 File Offset: 0x00053190
		public static void buildGrammars()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Building Grammars for Voice recognition");
			}
			Choices choices = new Choices(Strings.Split(MySettingsProperty.Settings.EnableASW, ";", -1, CompareMethod.Binary));
			GrammarBuilder grammarBuilder = new GrammarBuilder(choices);
			Grammar grammar = new Grammar(grammarBuilder);
			grammar.Name = "EnableASW";
			Choices choices2 = new Choices(Strings.Split(MySettingsProperty.Settings.DisableASW, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices2);
			Grammar grammar2 = new Grammar(grammarBuilder);
			grammar2.Name = "DisableASW";
			Choices choices3 = new Choices(Strings.Split(MySettingsProperty.Settings.LockASWOn, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices3);
			Grammar grammar3 = new Grammar(grammarBuilder);
			grammar3.Name = "LockASWOn";
			Choices choices4 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowPerf, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices4);
			Grammar grammar4 = new Grammar(grammarBuilder);
			grammar4.Name = "ShowPerf";
			Choices choices5 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowPD, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices5);
			Grammar grammar5 = new Grammar(grammarBuilder);
			grammar5.Name = "ShowPD";
			Choices choices6 = new Choices(Strings.Split(MySettingsProperty.Settings.Close, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices6);
			Grammar grammar6 = new Grammar(grammarBuilder);
			grammar6.Name = "Close";
			Choices choices7 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowASW, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices7);
			Grammar grammar7 = new Grammar(grammarBuilder);
			grammar7.Name = "ShowASW";
			Choices choices8 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowLatency, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices8);
			Grammar grammar8 = new Grammar(grammarBuilder);
			grammar8.Name = "ShowLatency";
			Choices choices9 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowApplicationRender, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices9);
			Grammar grammar9 = new Grammar(grammarBuilder);
			grammar9.Name = "ShowApplicationRender";
			Choices choices10 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowCompositorRender, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices10);
			Grammar grammar10 = new Grammar(grammarBuilder);
			grammar10.Name = "ShowCompositorRender";
			Choices choices11 = new Choices(Strings.Split(MySettingsProperty.Settings.ShowVersion, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices11);
			Grammar grammar11 = new Grammar(grammarBuilder);
			grammar11.Name = "ShowVersion";
			Choices choices12 = new Choices(Strings.Split(MySettingsProperty.Settings.LaunchSteam, ";", -1, CompareMethod.Binary));
			grammarBuilder = new GrammarBuilder(choices12);
			Grammar grammar12 = new Grammar(grammarBuilder);
			grammar12.Name = "StartSteam";
			Choices choices13 = new Choices(new string[]
			{
				"0", "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9",
				"2.0", "2.1", "2.2", "2.3", "2.4", "2.5"
			});
			Choices choices14 = new Choices(Strings.Split(MySettingsProperty.Settings.SetPD, ";", -1, CompareMethod.Binary));
			GrammarBuilder grammarBuilder2 = new GrammarBuilder();
			grammarBuilder2.Append(choices14);
			grammarBuilder2.Append(choices13);
			Grammar grammar13 = new Grammar(grammarBuilder2);
			grammar13.Name = "SS";
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("Building Grammars Done");
			}
			try
			{
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("Loading Grammars");
				}
				VoiceCommands.sRecognize.RequestRecognizerUpdate();
				bool enableASWEnabled = MySettingsProperty.Settings.EnableASWEnabled;
				if (enableASWEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar);
				}
				bool disableASWEnabled = MySettingsProperty.Settings.DisableASWEnabled;
				if (disableASWEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar2);
				}
				bool lockASWOnEnabled = MySettingsProperty.Settings.LockASWOnEnabled;
				if (lockASWOnEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar3);
				}
				bool showPerfEnabled = MySettingsProperty.Settings.ShowPerfEnabled;
				if (showPerfEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar4);
				}
				bool showPDEnabled = MySettingsProperty.Settings.ShowPDEnabled;
				if (showPDEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar5);
				}
				bool closeEnabled = MySettingsProperty.Settings.CloseEnabled;
				if (closeEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar6);
				}
				bool setPDEnabled = MySettingsProperty.Settings.SetPDEnabled;
				if (setPDEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar13);
				}
				bool showASWEnabled = MySettingsProperty.Settings.ShowASWEnabled;
				if (showASWEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar7);
				}
				bool showLatencyEnabled = MySettingsProperty.Settings.ShowLatencyEnabled;
				if (showLatencyEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar8);
				}
				bool showApplicationRenderEnabled = MySettingsProperty.Settings.ShowApplicationRenderEnabled;
				if (showApplicationRenderEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar9);
				}
				bool showCompositorRenderEnabled = MySettingsProperty.Settings.ShowCompositorRenderEnabled;
				if (showCompositorRenderEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar10);
				}
				bool showVersionEnabled = MySettingsProperty.Settings.ShowVersionEnabled;
				if (showVersionEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar11);
				}
				bool launchSteamEnabled = MySettingsProperty.Settings.LaunchSteamEnabled;
				if (launchSteamEnabled)
				{
					VoiceCommands.sRecognize.LoadGrammar(grammar12);
				}
				VoiceCommands.sRecognize.RecognizeAsync(RecognizeMode.Multiple);
				bool dbg4 = Globals.dbg;
				if (dbg4)
				{
					Log.WriteToLog("Loading Grammars Done");
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("Grammar construction failed: " + ex.Message);
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00055588 File Offset: 0x00053788
		private static void sRecognizeStartStop_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			bool flag = (double)e.Result.Confidence < (double)MySettingsProperty.Settings.Confidence / 100.0;
			if (flag)
			{
				FrmMain.fmain.AddToListboxAndScroll("Confidence level is too low: " + Conversions.ToString(Math.Round((double)(e.Result.Confidence * 100f))) + "%");
			}
			else
			{
				FrmMain.fmain.AddToListboxAndScroll(string.Concat(new string[]
				{
					"Recognized '",
					e.Result.Text,
					"'. Confidence: ",
					Conversions.ToString(Math.Round((double)(e.Result.Confidence * 100f))),
					"%"
				}));
				bool flag2 = Operators.CompareString(e.Result.Grammar.Name, "Start", false) == 0;
				if (flag2)
				{
					bool flag3 = !VoiceCommands.isListening;
					if (flag3)
					{
						bool flag4 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
						if (flag4)
						{
							Thread thread = new Thread((VoiceCommands._Closure$__.$I8-0 == null) ? (VoiceCommands._Closure$__.$I8-0 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background);
							}) : VoiceCommands._Closure$__.$I8-0);
							thread.Start();
						}
						Log.WriteToLog("Adding handler for speech recognition");
						CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.Name);
						VoiceCommands.sRecognize = new SpeechRecognitionEngine(cultureInfo);
						VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
						VoiceCommands.sRecognize.SpeechRecognized += VoiceCommands.sRecognize_SpeechRecognized;
						VoiceCommands.buildGrammars();
						VoiceCommands.isListening = true;
					}
				}
				bool flag5 = Operators.CompareString(e.Result.Grammar.Name, "Stop", false) == 0;
				if (flag5)
				{
					bool flag6 = VoiceCommands.isListening;
					if (flag6)
					{
						VoiceCommands.sRecognize.RecognizeAsyncCancel();
						VoiceCommands.sRecognize.SpeechRecognized -= VoiceCommands.sRecognize_SpeechRecognized;
						VoiceCommands.isListening = false;
						bool flag7 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
						if (flag7)
						{
							Thread thread2 = new Thread((VoiceCommands._Closure$__.$I8-1 == null) ? (VoiceCommands._Closure$__.$I8-1 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav");
							}) : VoiceCommands._Closure$__.$I8-1);
							thread2.Start();
						}
					}
				}
			}
			Thread.Sleep(100);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x000557D8 File Offset: 0x000539D8
		public static void StopListening()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering StopListening");
			}
			bool flag = VoiceCommands.isListening;
			if (flag)
			{
				VoiceCommands.sRecognize.RecognizeAsyncCancel();
				VoiceCommands.sRecognize.SpeechRecognized -= VoiceCommands.sRecognize_SpeechRecognized;
				VoiceCommands.isListening = false;
			}
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("Exiting StopListening");
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00055844 File Offset: 0x00053A44
		public static void DisableVoice()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering DisableVoice");
			}
			bool flag = VoiceCommands.grammarsBuilt;
			if (flag)
			{
				VoiceCommands.sRecognizeStartStop.RecognizeAsyncCancel();
				VoiceCommands.sRecognizeStartStop.SpeechRecognized -= VoiceCommands.sRecognizeStartStop_SpeechRecognized;
				VoiceCommands.isListening = false;
				VoiceCommands.grammarsBuilt = false;
			}
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("Exiting DisableVoice");
			}
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x000558B4 File Offset: 0x00053AB4
		public static void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			bool flag = !VoiceCommands.isListening;
			if (!flag)
			{
				bool flag2 = (double)e.Result.Confidence < (double)MySettingsProperty.Settings.Confidence / 100.0;
				if (flag2)
				{
					FrmMain.fmain.AddToListboxAndScroll("Confidence too low at " + Conversions.ToString(Math.Round((double)(e.Result.Confidence * 100f))) + "%");
				}
				else
				{
					FrmMain.fmain.AddToListboxAndScroll(string.Concat(new string[]
					{
						"Recognized '",
						e.Result.Text,
						"'. Confidence: ",
						Conversions.ToString(Math.Round((double)(e.Result.Confidence * 100f))),
						"%"
					}));
					bool flag3 = Operators.CompareString(e.Result.Grammar.Name, "SS", false) == 0;
					if (flag3)
					{
						Thread thread = new Thread(delegate
						{
							RunCommand.Run_debug_tool(e.Result.Words.Last<RecognizedWordUnit>().Text);
						});
						thread.Start();
						bool flag4 = !MySettingsProperty.Settings.DisableCallback;
						if (flag4)
						{
							Thread thread2 = new Thread((VoiceCommands._Closure$__.$I11-1 == null) ? (VoiceCommands._Closure$__.$I11-1 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\affirmative.wav");
							}) : VoiceCommands._Closure$__.$I11-1);
							thread2.Start();
						}
						bool flag5 = Operators.CompareString(MyProject.Forms.FrmMain.runningApp, null, false) != 0;
						if (flag5)
						{
							string text = "";
							string text2 = "";
							MyProject.Forms.FrmMain.profileASWList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text2);
							bool flag6 = MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text);
							if (flag6)
							{
								string displayName = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
								OTTDB.UpdateProfile("", e.Result.Words.Last<RecognizedWordUnit>().Text, MyProject.Forms.FrmMain.runningApp, displayName);
							}
							MyProject.Forms.FrmMain.CurrentSS = e.Result.Words.Last<RecognizedWordUnit>().Text;
						}
						else
						{
							FrmMain.fmain.AddToListboxAndScroll(e.Result.Text);
						}
					}
					bool flag7 = Operators.CompareString(e.Result.Grammar.Name, "EnableASW", false) == 0;
					if (flag7)
					{
						Thread thread3 = new Thread((VoiceCommands._Closure$__.$I11-2 == null) ? (VoiceCommands._Closure$__.$I11-2 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Auto");
						}) : VoiceCommands._Closure$__.$I11-2);
						thread3.Start();
						FrmMain.fmain.AddToListboxAndScroll("ASW set to Auto");
						GetConfig.IsReading = true;
						MyProject.Forms.FrmMain.ComboBox1.Text = "Auto";
						GetConfig.IsReading = false;
						bool flag8 = !MySettingsProperty.Settings.DisableCallback;
						if (flag8)
						{
							Thread thread4 = new Thread((VoiceCommands._Closure$__.$I11-3 == null) ? (VoiceCommands._Closure$__.$I11-3 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav");
							}) : VoiceCommands._Closure$__.$I11-3);
							thread4.Start();
						}
						bool flag9 = Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", false) != 0;
						if (flag9)
						{
							string text3 = "";
							bool flag10 = MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text3);
							if (flag10)
							{
								string displayName2 = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
								OTTDB.UpdateProfile("Auto", "", MyProject.Forms.FrmMain.runningApp, displayName2);
							}
						}
					}
					bool flag11 = Operators.CompareString(e.Result.Grammar.Name, "DisableASW", false) == 0;
					if (flag11)
					{
						Thread thread5 = new Thread((VoiceCommands._Closure$__.$I11-4 == null) ? (VoiceCommands._Closure$__.$I11-4 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Off");
						}) : VoiceCommands._Closure$__.$I11-4);
						thread5.Start();
						FrmMain.fmain.AddToListboxAndScroll("ASW set to Off");
						GetConfig.IsReading = true;
						MyProject.Forms.FrmMain.ComboBox1.Text = "Off";
						GetConfig.IsReading = false;
						bool flag12 = !MySettingsProperty.Settings.DisableCallback;
						if (flag12)
						{
							Thread thread6 = new Thread((VoiceCommands._Closure$__.$I11-5 == null) ? (VoiceCommands._Closure$__.$I11-5 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav");
							}) : VoiceCommands._Closure$__.$I11-5);
							thread6.Start();
						}
						bool flag13 = Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", false) != 0;
						if (flag13)
						{
							string text4 = "";
							bool flag14 = MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text4);
							if (flag14)
							{
								string displayName3 = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
								OTTDB.UpdateProfile("Off", "", MyProject.Forms.FrmMain.runningApp, displayName3);
							}
						}
					}
					bool flag15 = Operators.CompareString(e.Result.Grammar.Name, "LockASWOn", false) == 0;
					if (flag15)
					{
						Thread thread7 = new Thread((VoiceCommands._Closure$__.$I11-6 == null) ? (VoiceCommands._Closure$__.$I11-6 = delegate
						{
							RunCommand.Run_debug_tool_asw("server:asw.Clock45");
						}) : VoiceCommands._Closure$__.$I11-6);
						thread7.Start();
						FrmMain.fmain.AddToListboxAndScroll("Framerate Locked @ 45 fps");
						GetConfig.IsReading = true;
						MyProject.Forms.FrmMain.ComboBox1.Text = "45 fps";
						GetConfig.IsReading = false;
						bool flag16 = !MySettingsProperty.Settings.DisableCallback;
						if (flag16)
						{
							Thread thread8 = new Thread((VoiceCommands._Closure$__.$I11-7 == null) ? (VoiceCommands._Closure$__.$I11-7 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelocked.wav");
							}) : VoiceCommands._Closure$__.$I11-7);
							thread8.Start();
						}
						bool flag17 = Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", false) != 0;
						if (flag17)
						{
							string text5 = "";
							bool flag18 = MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out text5);
							if (flag18)
							{
								string displayName4 = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
								OTTDB.UpdateProfile("45 fps", "", MyProject.Forms.FrmMain.runningApp, displayName4);
							}
						}
					}
					bool flag19 = Operators.CompareString(e.Result.Grammar.Name, "Close", false) == 0;
					if (flag19)
					{
						MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 0;
					}
					bool flag20 = Operators.CompareString(e.Result.Grammar.Name, "ShowPD", false) == 0;
					if (flag20)
					{
						MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 1;
					}
					bool flag21 = Operators.CompareString(e.Result.Grammar.Name, "ShowPerf", false) == 0;
					if (flag21)
					{
						MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 2;
					}
					bool flag22 = Operators.CompareString(e.Result.Grammar.Name, "ShowASW", false) == 0;
					if (flag22)
					{
						MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 3;
					}
					bool flag23 = Operators.CompareString(e.Result.Grammar.Name, "ShowLatency", false) == 0;
					if (flag23)
					{
						MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 4;
					}
					bool flag24 = Operators.CompareString(e.Result.Grammar.Name, "ShowApplicationRender", false) == 0;
					if (flag24)
					{
						MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 5;
					}
					bool flag25 = Operators.CompareString(e.Result.Grammar.Name, "ShowCompositorRender", false) == 0;
					if (flag25)
					{
						MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 6;
					}
					bool flag26 = Operators.CompareString(e.Result.Grammar.Name, "ShowVersion", false) == 0;
					if (flag26)
					{
						MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 7;
					}
					bool flag27 = Operators.CompareString(e.Result.Grammar.Name, "StartSteam", false) == 0;
					if (flag27)
					{
						bool flag28 = File.Exists(MyProject.Forms.FrmMain.SteamPath + "\\Steam.exe");
						if (flag28)
						{
							Log.WriteToLog("Launching SteamVR");
							FrmMain.fmain.AddToListboxAndScroll("Launching SteamVR");
							bool flag29 = !MySettingsProperty.Settings.DisableCallback;
							if (flag29)
							{
								Thread thread9 = new Thread((VoiceCommands._Closure$__.$I11-8 == null) ? (VoiceCommands._Closure$__.$I11-8 = delegate
								{
									MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\onemoment.wav");
								}) : VoiceCommands._Closure$__.$I11-8);
								thread9.Start();
							}
							new Process
							{
								StartInfo = new ProcessStartInfo(MyProject.Forms.FrmMain.SteamPath + "\\Steam.exe")
								{
									UseShellExecute = false,
									CreateNoWindow = true,
									Arguments = " -applaunch 250820"
								}
							}.Start();
						}
						else
						{
							FrmMain.fmain.AddToListboxAndScroll("Unable to launch SteamVR, Steam not found");
						}
					}
					bool voiceActivationVoiceRepeated = MySettingsProperty.Settings.VoiceActivationVoiceRepeated;
					if (voiceActivationVoiceRepeated)
					{
						bool flag30 = !MySettingsProperty.Settings.DisableVoiceControlAudioFeedback;
						if (flag30)
						{
							Thread thread10 = new Thread((VoiceCommands._Closure$__.$I11-9 == null) ? (VoiceCommands._Closure$__.$I11-9 = delegate
							{
								MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav");
							}) : VoiceCommands._Closure$__.$I11-9);
							thread10.Start();
						}
						VoiceCommands.StopListening();
					}
				}
			}
		}

		// Token: 0x040003E8 RID: 1000
		public static SpeechRecognitionEngine sRecognize = null;

		// Token: 0x040003E9 RID: 1001
		public static SpeechRecognitionEngine sRecognizeStartStop = null;

		// Token: 0x040003EA RID: 1002
		public static bool isListening = false;

		// Token: 0x040003EB RID: 1003
		public static bool grammarsBuilt = false;
	}
}
