// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.VoiceCommands
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using CoreAudio;
using Microsoft.Speech.Recognition;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class VoiceCommands
  {
    public static SpeechRecognitionEngine sRecognize = (SpeechRecognitionEngine) null;
    public static SpeechRecognitionEngine sRecognizeStartStop = (SpeechRecognitionEngine) null;
    public static bool isListening = false;
    public static bool grammarsBuilt = false;

    public static void Initialize()
    {
      try
      {
        VoiceCommands.sRecognize = new SpeechRecognitionEngine();
        VoiceCommands.sRecognizeStartStop = new SpeechRecognitionEngine();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("Initialize: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void StartStopBuilder()
    {
      try
      {
        Log.WriteToLog("Initializing voice recognition");
        VoiceCommands.sRecognizeStartStop = new SpeechRecognitionEngine(new CultureInfo(CultureInfo.CurrentUICulture.Name));
        VoiceCommands.sRecognizeStartStop.SetInputToDefaultAudioDevice();
        Grammar grammar1 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.StartVoice, ";"))));
        grammar1.Name = "Start";
        Grammar grammar2 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.StopVoice, ";"))));
        grammar2.Name = "Stop";
        VoiceCommands.sRecognizeStartStop.LoadGrammarAsync(grammar1);
        VoiceCommands.sRecognizeStartStop.LoadGrammarAsync(grammar2);
        VoiceCommands.sRecognizeStartStop.RecognizeAsync(RecognizeMode.Multiple);
        VoiceCommands.grammarsBuilt = true;
        VoiceCommands.sRecognizeStartStop.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognizeStartStop_SpeechRecognized);
        MMDevice defaultAudioEndpoint = new MMDeviceEnumerator().GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole);
        FrmMain.fmain.AddToListboxAndScroll("Voice recognition initialized, waiting for Oculus Home to start");
        FrmMain.fmain.AddToListboxAndScroll(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object) "Input device: ", defaultAudioEndpoint.Properties.GetValue(1).Value), (object) " ("), (object) defaultAudioEndpoint.FriendlyName), (object) ")")));
        FrmMain.fmain.AddToListboxAndScroll("Input volume: " + Conversions.ToString(defaultAudioEndpoint.AudioEndpointVolume.MasterVolumeLevelScalar * 100f) + "%");
        FrmMain.fmain.AddToListboxAndScroll("Confidence level: " + Conversions.ToString(MySettingsProperty.Settings.Confidence) + "%");
        FrmMain.fmain.AddToListboxAndScroll("Language: " + VoiceCommands.sRecognizeStartStop.RecognizerInfo.Culture.EnglishName);
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
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Start/Stop grammars built, ready to receive commands");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("Voice recognition initialization failed: " + e.Message);
        Log.WriteToLog("Voice recognition initialization failed: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static void buildGrammars()
    {
      if (Globals.dbg)
        Log.WriteToLog("Building Grammars for Voice recognition");
      Grammar grammar1 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.EnableASW, ";"))));
      grammar1.Name = "EnableASW";
      Grammar grammar2 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.DisableASW, ";"))));
      grammar2.Name = "DisableASW";
      Grammar grammar3 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.LockASWOn, ";"))));
      grammar3.Name = "LockASWOn";
      Grammar grammar4 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.ShowPerf, ";"))));
      grammar4.Name = "ShowPerf";
      Grammar grammar5 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.ShowPD, ";"))));
      grammar5.Name = "ShowPD";
      Grammar grammar6 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.Close, ";"))));
      grammar6.Name = "Close";
      Grammar grammar7 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.ShowASW, ";"))));
      grammar7.Name = "ShowASW";
      Grammar grammar8 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.ShowLatency, ";"))));
      grammar8.Name = "ShowLatency";
      Grammar grammar9 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.ShowApplicationRender, ";"))));
      grammar9.Name = "ShowApplicationRender";
      Grammar grammar10 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.ShowCompositorRender, ";"))));
      grammar10.Name = "ShowCompositorRender";
      Grammar grammar11 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.ShowVersion, ";"))));
      grammar11.Name = "ShowVersion";
      Grammar grammar12 = new Grammar(new GrammarBuilder(new Choices(Strings.Split(MySettingsProperty.Settings.LaunchSteam, ";"))));
      grammar12.Name = "StartSteam";
      Choices alternateChoices1 = new Choices(new string[16]
      {
        "0",
        "1.1",
        "1.2",
        "1.3",
        "1.4",
        "1.5",
        "1.6",
        "1.7",
        "1.8",
        "1.9",
        "2.0",
        "2.1",
        "2.2",
        "2.3",
        "2.4",
        "2.5"
      });
      Choices alternateChoices2 = new Choices(Strings.Split(MySettingsProperty.Settings.SetPD, ";"));
      GrammarBuilder builder = new GrammarBuilder();
      builder.Append(alternateChoices2);
      builder.Append(alternateChoices1);
      Grammar grammar13 = new Grammar(builder);
      grammar13.Name = "SS";
      if (Globals.dbg)
        Log.WriteToLog("Building Grammars Done");
      try
      {
        if (Globals.dbg)
          Log.WriteToLog("Loading Grammars");
        VoiceCommands.sRecognize.RequestRecognizerUpdate();
        if (MySettingsProperty.Settings.EnableASWEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar1);
        if (MySettingsProperty.Settings.DisableASWEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar2);
        if (MySettingsProperty.Settings.LockASWOnEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar3);
        if (MySettingsProperty.Settings.ShowPerfEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar4);
        if (MySettingsProperty.Settings.ShowPDEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar5);
        if (MySettingsProperty.Settings.CloseEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar6);
        if (MySettingsProperty.Settings.SetPDEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar13);
        if (MySettingsProperty.Settings.ShowASWEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar7);
        if (MySettingsProperty.Settings.ShowLatencyEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar8);
        if (MySettingsProperty.Settings.ShowApplicationRenderEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar9);
        if (MySettingsProperty.Settings.ShowCompositorRenderEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar10);
        if (MySettingsProperty.Settings.ShowVersionEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar11);
        if (MySettingsProperty.Settings.LaunchSteamEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar12);
        VoiceCommands.sRecognize.RecognizeAsync(RecognizeMode.Multiple);
        if (Globals.dbg)
          Log.WriteToLog("Loading Grammars Done");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        Log.WriteToLog("Grammar construction failed: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    private static void sRecognizeStartStop_SpeechRecognized(
      object sender,
      SpeechRecognizedEventArgs e)
    {
      if ((double) e.Result.Confidence < (double) MySettingsProperty.Settings.Confidence / 100.0)
      {
        FrmMain.fmain.AddToListboxAndScroll("Confidence level is too low: " + Conversions.ToString(Math.Round((double) e.Result.Confidence * 100.0)) + "%");
      }
      else
      {
        FrmMain.fmain.AddToListboxAndScroll("Recognized '" + e.Result.Text + "'. Confidence: " + Conversions.ToString(Math.Round((double) e.Result.Confidence * 100.0)) + "%");
        if (Operators.CompareString(e.Result.Grammar.Name, "Start", false) == 0 && !VoiceCommands.isListening)
        {
          if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (VoiceCommands._Closure\u0024__.\u0024I8\u002D0 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = VoiceCommands._Closure\u0024__.\u0024I8\u002D0;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              VoiceCommands._Closure\u0024__.\u0024I8\u002D0 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechon.wav", AudioPlayMode.Background));
            }
            new Thread(start).Start();
          }
          Log.WriteToLog("Adding handler for speech recognition");
          VoiceCommands.sRecognize = new SpeechRecognitionEngine(new CultureInfo(CultureInfo.CurrentUICulture.Name));
          VoiceCommands.sRecognize.SetInputToDefaultAudioDevice();
          VoiceCommands.sRecognize.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognize_SpeechRecognized);
          VoiceCommands.buildGrammars();
          VoiceCommands.isListening = true;
        }
        if (Operators.CompareString(e.Result.Grammar.Name, "Stop", false) == 0 && VoiceCommands.isListening)
        {
          VoiceCommands.sRecognize.RecognizeAsyncCancel();
          VoiceCommands.sRecognize.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognize_SpeechRecognized);
          VoiceCommands.isListening = false;
          if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (VoiceCommands._Closure\u0024__.\u0024I8\u002D1 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = VoiceCommands._Closure\u0024__.\u0024I8\u002D1;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              VoiceCommands._Closure\u0024__.\u0024I8\u002D1 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav"));
            }
            new Thread(start).Start();
          }
        }
      }
      Thread.Sleep(100);
    }

    public static void StopListening()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering StopListening");
      if (VoiceCommands.isListening)
      {
        VoiceCommands.sRecognize.RecognizeAsyncCancel();
        VoiceCommands.sRecognize.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognize_SpeechRecognized);
        VoiceCommands.isListening = false;
      }
      if (!Globals.dbg)
        return;
      Log.WriteToLog("Exiting StopListening");
    }

    public static void DisableVoice()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering DisableVoice");
      if (VoiceCommands.grammarsBuilt)
      {
        VoiceCommands.sRecognizeStartStop.RecognizeAsyncCancel();
        VoiceCommands.sRecognizeStartStop.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognizeStartStop_SpeechRecognized);
        VoiceCommands.isListening = false;
        VoiceCommands.grammarsBuilt = false;
      }
      if (!Globals.dbg)
        return;
      Log.WriteToLog("Exiting DisableVoice");
    }

    public static void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
      if (!VoiceCommands.isListening)
        return;
      if ((double) e.Result.Confidence < (double) MySettingsProperty.Settings.Confidence / 100.0)
      {
        FrmMain.fmain.AddToListboxAndScroll("Confidence too low at " + Conversions.ToString(Math.Round((double) e.Result.Confidence * 100.0)) + "%");
      }
      else
      {
        FrmMain.fmain.AddToListboxAndScroll("Recognized '" + e.Result.Text + "'. Confidence: " + Conversions.ToString(Math.Round((double) e.Result.Confidence * 100.0)) + "%");
        if (Operators.CompareString(e.Result.Grammar.Name, "SS", false) == 0)
        {
          new Thread((ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool(e.Result.Words.Last<RecognizedWordUnit>().Text))).Start();
          if (!MySettingsProperty.Settings.DisableCallback)
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (VoiceCommands._Closure\u0024__.\u0024I11\u002D1 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = VoiceCommands._Closure\u0024__.\u0024I11\u002D1;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              VoiceCommands._Closure\u0024__.\u0024I11\u002D1 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\affirmative.wav"));
            }
            new Thread(start).Start();
          }
          if (Operators.CompareString(MyProject.Forms.FrmMain.runningApp, (string) null, false) != 0)
          {
            string str1 = "";
            string str2 = "";
            MyProject.Forms.FrmMain.profileASWList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str2);
            if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str1))
            {
              string displayName = OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp);
              OTTDB.UpdateProfile("", e.Result.Words.Last<RecognizedWordUnit>().Text, MyProject.Forms.FrmMain.runningApp, displayName);
            }
            MyProject.Forms.FrmMain.CurrentSS = e.Result.Words.Last<RecognizedWordUnit>().Text;
          }
          else
            FrmMain.fmain.AddToListboxAndScroll(e.Result.Text);
        }
        if (Operators.CompareString(e.Result.Grammar.Name, "EnableASW", false) == 0)
        {
          ThreadStart start1;
          // ISSUE: reference to a compiler-generated field
          if (VoiceCommands._Closure\u0024__.\u0024I11\u002D2 != null)
          {
            // ISSUE: reference to a compiler-generated field
            start1 = VoiceCommands._Closure\u0024__.\u0024I11\u002D2;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            VoiceCommands._Closure\u0024__.\u0024I11\u002D2 = start1 = (ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool_asw("server:asw.Auto"));
          }
          new Thread(start1).Start();
          FrmMain.fmain.AddToListboxAndScroll("ASW set to Auto");
          GetConfig.IsReading = true;
          MyProject.Forms.FrmMain.ComboBox1.Text = "Auto";
          GetConfig.IsReading = false;
          if (!MySettingsProperty.Settings.DisableCallback)
          {
            ThreadStart start2;
            // ISSUE: reference to a compiler-generated field
            if (VoiceCommands._Closure\u0024__.\u0024I11\u002D3 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start2 = VoiceCommands._Closure\u0024__.\u0024I11\u002D3;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              VoiceCommands._Closure\u0024__.\u0024I11\u002D3 = start2 = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\enabled.wav"));
            }
            new Thread(start2).Start();
          }
          if (Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", false) != 0)
          {
            string str = "";
            if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str))
              OTTDB.UpdateProfile("Auto", "", MyProject.Forms.FrmMain.runningApp, OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp));
          }
        }
        if (Operators.CompareString(e.Result.Grammar.Name, "DisableASW", false) == 0)
        {
          ThreadStart start3;
          // ISSUE: reference to a compiler-generated field
          if (VoiceCommands._Closure\u0024__.\u0024I11\u002D4 != null)
          {
            // ISSUE: reference to a compiler-generated field
            start3 = VoiceCommands._Closure\u0024__.\u0024I11\u002D4;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            VoiceCommands._Closure\u0024__.\u0024I11\u002D4 = start3 = (ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool_asw("server:asw.Off"));
          }
          new Thread(start3).Start();
          FrmMain.fmain.AddToListboxAndScroll("ASW set to Off");
          GetConfig.IsReading = true;
          MyProject.Forms.FrmMain.ComboBox1.Text = "Off";
          GetConfig.IsReading = false;
          if (!MySettingsProperty.Settings.DisableCallback)
          {
            ThreadStart start4;
            // ISSUE: reference to a compiler-generated field
            if (VoiceCommands._Closure\u0024__.\u0024I11\u002D5 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start4 = VoiceCommands._Closure\u0024__.\u0024I11\u002D5;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              VoiceCommands._Closure\u0024__.\u0024I11\u002D5 = start4 = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\disabled.wav"));
            }
            new Thread(start4).Start();
          }
          if (Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", false) != 0)
          {
            string str = "";
            if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str))
              OTTDB.UpdateProfile("Off", "", MyProject.Forms.FrmMain.runningApp, OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp));
          }
        }
        if (Operators.CompareString(e.Result.Grammar.Name, "LockASWOn", false) == 0)
        {
          ThreadStart start5;
          // ISSUE: reference to a compiler-generated field
          if (VoiceCommands._Closure\u0024__.\u0024I11\u002D6 != null)
          {
            // ISSUE: reference to a compiler-generated field
            start5 = VoiceCommands._Closure\u0024__.\u0024I11\u002D6;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            VoiceCommands._Closure\u0024__.\u0024I11\u002D6 = start5 = (ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool_asw("server:asw.Clock45"));
          }
          new Thread(start5).Start();
          FrmMain.fmain.AddToListboxAndScroll("Framerate Locked @ 45 fps");
          GetConfig.IsReading = true;
          MyProject.Forms.FrmMain.ComboBox1.Text = "45 fps";
          GetConfig.IsReading = false;
          if (!MySettingsProperty.Settings.DisableCallback)
          {
            ThreadStart start6;
            // ISSUE: reference to a compiler-generated field
            if (VoiceCommands._Closure\u0024__.\u0024I11\u002D7 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start6 = VoiceCommands._Closure\u0024__.\u0024I11\u002D7;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              VoiceCommands._Closure\u0024__.\u0024I11\u002D7 = start6 = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\frameratelocked.wav"));
            }
            new Thread(start6).Start();
          }
          if (Operators.CompareString(MyProject.Forms.FrmMain.runningApp, "", false) != 0)
          {
            string str = "";
            if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str))
              OTTDB.UpdateProfile("45 fps", "", MyProject.Forms.FrmMain.runningApp, OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp));
          }
        }
        if (Operators.CompareString(e.Result.Grammar.Name, "Close", false) == 0)
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 0;
        if (Operators.CompareString(e.Result.Grammar.Name, "ShowPD", false) == 0)
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 1;
        if (Operators.CompareString(e.Result.Grammar.Name, "ShowPerf", false) == 0)
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 2;
        if (Operators.CompareString(e.Result.Grammar.Name, "ShowASW", false) == 0)
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 3;
        if (Operators.CompareString(e.Result.Grammar.Name, "ShowLatency", false) == 0)
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 4;
        if (Operators.CompareString(e.Result.Grammar.Name, "ShowApplicationRender", false) == 0)
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 5;
        if (Operators.CompareString(e.Result.Grammar.Name, "ShowCompositorRender", false) == 0)
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 6;
        if (Operators.CompareString(e.Result.Grammar.Name, "ShowVersion", false) == 0)
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 7;
        if (Operators.CompareString(e.Result.Grammar.Name, "StartSteam", false) == 0)
        {
          if (File.Exists(MyProject.Forms.FrmMain.SteamPath + "\\Steam.exe"))
          {
            Log.WriteToLog("Launching SteamVR");
            FrmMain.fmain.AddToListboxAndScroll("Launching SteamVR");
            if (!MySettingsProperty.Settings.DisableCallback)
            {
              ThreadStart start;
              // ISSUE: reference to a compiler-generated field
              if (VoiceCommands._Closure\u0024__.\u0024I11\u002D8 != null)
              {
                // ISSUE: reference to a compiler-generated field
                start = VoiceCommands._Closure\u0024__.\u0024I11\u002D8;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                VoiceCommands._Closure\u0024__.\u0024I11\u002D8 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\onemoment.wav"));
              }
              new Thread(start).Start();
            }
            new Process()
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
            FrmMain.fmain.AddToListboxAndScroll("Unable to launch SteamVR, Steam not found");
        }
        if (MySettingsProperty.Settings.VoiceActivationVoiceRepeated)
        {
          if (!MySettingsProperty.Settings.DisableVoiceControlAudioFeedback)
          {
            ThreadStart start;
            // ISSUE: reference to a compiler-generated field
            if (VoiceCommands._Closure\u0024__.\u0024I11\u002D9 != null)
            {
              // ISSUE: reference to a compiler-generated field
              start = VoiceCommands._Closure\u0024__.\u0024I11\u002D9;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              VoiceCommands._Closure\u0024__.\u0024I11\u002D9 = start = (ThreadStart) ([SpecialName] () => MyProject.Computer.Audio.Play(Application.StartupPath + "\\Sounds\\speechoff.wav"));
            }
            new Thread(start).Start();
          }
          VoiceCommands.StopListening();
        }
      }
    }
  }
}
