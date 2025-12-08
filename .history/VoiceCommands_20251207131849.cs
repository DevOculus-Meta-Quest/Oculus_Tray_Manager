// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.VoiceCommands
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using CoreAudio;
using System.Speech.Recognition;
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
        Log.WriteToLog("Initialize: " + ex.Message);
      }
    }

    public static void StartStopBuilder()
    {
      try
      {
        Log.WriteToLog("Initializing voice recognition");
        VoiceCommands.sRecognizeStartStop = new SpeechRecognitionEngine(new CultureInfo(CultureInfo.CurrentUICulture.Name));
        VoiceCommands.sRecognizeStartStop.SetInputToDefaultAudioDevice();
        Grammar grammar1 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.StartVoice.Split(';'))));
        grammar1.Name = "Start";
        Grammar grammar2 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.StopVoice.Split(';'))));
        grammar2.Name = "Stop";
        VoiceCommands.sRecognizeStartStop.LoadGrammarAsync(grammar1);
        VoiceCommands.sRecognizeStartStop.LoadGrammarAsync(grammar2);
        VoiceCommands.sRecognizeStartStop.RecognizeAsync(RecognizeMode.Multiple);
        VoiceCommands.grammarsBuilt = true;
        VoiceCommands.sRecognizeStartStop.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognizeStartStop_SpeechRecognized);
        MMDevice defaultAudioEndpoint = new MMDeviceEnumerator().GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eConsole);
        FrmMain.fmain.AddToListboxAndScroll("Voice recognition initialized, waiting for Oculus Home to start");
        FrmMain.fmain.AddToListboxAndScroll("Input device: " + defaultAudioEndpoint.Properties.GetValue(1).Value + " (" + defaultAudioEndpoint.FriendlyName + ")");
        FrmMain.fmain.AddToListboxAndScroll("Input volume: " + (defaultAudioEndpoint.AudioEndpointVolume.MasterVolumeLevelScalar * 100f).ToString() + "%");
        FrmMain.fmain.AddToListboxAndScroll("Confidence level: " + OculusTrayTool.My.MySettings.Default.Confidence.ToString() + "%");
        FrmMain.fmain.AddToListboxAndScroll("Language: " + VoiceCommands.sRecognizeStartStop.RecognizerInfo.Culture.EnglishName);
        if (!defaultAudioEndpoint.FriendlyName.ToLower().Contains("rift"))
        {
          Log.WriteToLog("Rift microphone is not the default input device.");
          FrmMain.fmain.AddToListboxAndScroll("Rift microphone is not the default input device");
          if (OculusTrayTool.My.MySettings.Default.ShowMicNotDefaultWarning)
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
        FrmMain.fmain.AddToListboxAndScroll("Voice recognition initialization failed: " + ex.Message);
        Log.WriteToLog("Voice recognition initialization failed: " + ex.Message);
        StackTrace stackTrace = new StackTrace(ex, true);
        Log.WriteToLog(ex.ToString() + stackTrace.ToString());
      }
    }

    public static void buildGrammars()
    {
      if (Globals.dbg)
        Log.WriteToLog("Building Grammars for Voice recognition");
      Grammar grammar1 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.EnableASW.Split(';'))));
      grammar1.Name = "EnableASW";
      Grammar grammar2 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.DisableASW.Split(';'))));
      grammar2.Name = "DisableASW";
      Grammar grammar3 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.LockASWOn.Split(';'))));
      grammar3.Name = "LockASWOn";
      Grammar grammar4 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.ShowPerf.Split(';'))));
      grammar4.Name = "ShowPerf";
      Grammar grammar5 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.ShowPD.Split(';'))));
      grammar5.Name = "ShowPD";
      Grammar grammar6 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.Close.Split(';'))));
      grammar6.Name = "Close";
      Grammar grammar7 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.ShowASW.Split(';'))));
      grammar7.Name = "ShowASW";
      Grammar grammar8 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.ShowLatency.Split(';'))));
      grammar8.Name = "ShowLatency";
      Grammar grammar9 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.ShowApplicationRender.Split(';'))));
      grammar9.Name = "ShowApplicationRender";
      Grammar grammar10 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.ShowCompositorRender.Split(';'))));
      grammar10.Name = "ShowCompositorRender";
      Grammar grammar11 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.ShowVersion.Split(';'))));
      grammar11.Name = "ShowVersion";
      Grammar grammar12 = new Grammar(new GrammarBuilder(new Choices(OculusTrayTool.My.MySettings.Default.LaunchSteam.Split(';'))));
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
      Choices alternateChoices2 = new Choices(OculusTrayTool.My.MySettings.Default.SetPD.Split(';'));
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
        if (OculusTrayTool.My.MySettings.Default.EnableASWEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar1);
        if (OculusTrayTool.My.MySettings.Default.DisableASWEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar2);
        if (OculusTrayTool.My.MySettings.Default.LockASWOnEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar3);
        if (OculusTrayTool.My.MySettings.Default.ShowPerfEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar4);
        if (OculusTrayTool.My.MySettings.Default.ShowPDEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar5);
        if (OculusTrayTool.My.MySettings.Default.CloseEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar6);
        if (OculusTrayTool.My.MySettings.Default.SetPDEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar13);
        if (OculusTrayTool.My.MySettings.Default.ShowASWEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar7);
        if (OculusTrayTool.My.MySettings.Default.ShowLatencyEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar8);
        if (OculusTrayTool.My.MySettings.Default.ShowApplicationRenderEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar9);
        if (OculusTrayTool.My.MySettings.Default.ShowCompositorRenderEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar10);
        if (OculusTrayTool.My.MySettings.Default.ShowVersionEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar11);
        if (OculusTrayTool.My.MySettings.Default.LaunchSteamEnabled)
          VoiceCommands.sRecognize.LoadGrammar(grammar12);
        VoiceCommands.sRecognize.RecognizeAsync(RecognizeMode.Multiple);
        if (Globals.dbg)
          Log.WriteToLog("Loading Grammars Done");
      }
      catch (Exception ex)
      {
        Log.WriteToLog("Grammar construction failed: " + ex.Message);
        StackTrace stackTrace = new StackTrace(ex, true);
        Log.WriteToLog(ex.ToString() + stackTrace.ToString());
      }
    }

    private static void sRecognizeStartStop_SpeechRecognized(
      object sender,
      SpeechRecognizedEventArgs e)
    {
      if ((double) e.Result.Confidence < (double) OculusTrayTool.My.MySettings.Default.Confidence / 100.0)
      {
        FrmMain.fmain.AddToListboxAndScroll("Confidence level is too low: " + Math.Round((double) e.Result.Confidence * 100.0).ToString() + "%");
      }
      else
      {
        FrmMain.fmain.AddToListboxAndScroll("Recognized '" + e.Result.Text + "'. Confidence: " + Math.Round((double) e.Result.Confidence * 100.0).ToString() + "%");
        if (string.Equals(e.Result.Grammar.Name, "Start", StringComparison.Ordinal) && !VoiceCommands.isListening)
        {
          if (!OculusTrayTool.My.MySettings.Default.DisableVoiceControlAudioFeedback)
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
        if (string.Equals(e.Result.Grammar.Name, "Stop", StringComparison.Ordinal) && VoiceCommands.isListening)
        {
          VoiceCommands.sRecognize.RecognizeAsyncCancel();
          VoiceCommands.sRecognize.SpeechRecognized -= new EventHandler<SpeechRecognizedEventArgs>(VoiceCommands.sRecognize_SpeechRecognized);
          VoiceCommands.isListening = false;
          if (!OculusTrayTool.My.MySettings.Default.DisableVoiceControlAudioFeedback)
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
      if ((double) e.Result.Confidence < (double) OculusTrayTool.My.MySettings.Default.Confidence / 100.0)
      {
        FrmMain.fmain.AddToListboxAndScroll("Confidence too low at " + Math.Round((double) e.Result.Confidence * 100.0).ToString() + "%");
      }
      else
      {
        FrmMain.fmain.AddToListboxAndScroll("Recognized '" + e.Result.Text + "'. Confidence: " + Math.Round((double) e.Result.Confidence * 100.0).ToString() + "%");
        if (string.Equals(e.Result.Grammar.Name, "SS", StringComparison.Ordinal))
        {
          new Thread((ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool(e.Result.Words.Last<RecognizedWordUnit>().Text))).Start();
          if (!OculusTrayTool.My.MySettings.Default.DisableCallback)
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
        if (string.Equals(e.Result.Grammar.Name, "EnableASW", StringComparison.Ordinal))
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
          if (!OculusTrayTool.My.MySettings.Default.DisableCallback)
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
          if (MyProject.Forms.FrmMain.runningApp != "")
          {
            string str = "";
            if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str))
              OTTDB.UpdateProfile("Auto", "", MyProject.Forms.FrmMain.runningApp, OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp));
          }
        }
        if (string.Equals(e.Result.Grammar.Name, "DisableASW", StringComparison.Ordinal))
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
          if (!OculusTrayTool.My.MySettings.Default.DisableCallback)
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
          if (MyProject.Forms.FrmMain.runningApp != "")
          {
            string str = "";
            if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str))
              OTTDB.UpdateProfile("Off", "", MyProject.Forms.FrmMain.runningApp, OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp));
          }
        }
        if (string.Equals(e.Result.Grammar.Name, "LockASWOn", StringComparison.Ordinal))
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
          if (!OculusTrayTool.My.MySettings.Default.DisableCallback)
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
          if (MyProject.Forms.FrmMain.runningApp != "")
          {
            string str = "";
            if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str))
              OTTDB.UpdateProfile("45 fps", "", MyProject.Forms.FrmMain.runningApp, OTTDB.GetDisplayName(MyProject.Forms.FrmMain.runningApp));
          }
        }
        if (string.Equals(e.Result.Grammar.Name, "Close", StringComparison.Ordinal))
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 0;
        if (string.Equals(e.Result.Grammar.Name, "ShowPD", StringComparison.Ordinal))
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 1;
        if (string.Equals(e.Result.Grammar.Name, "ShowPerf", StringComparison.Ordinal))
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 2;
        if (string.Equals(e.Result.Grammar.Name, "ShowASW", StringComparison.Ordinal))
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 3;
        if (string.Equals(e.Result.Grammar.Name, "ShowLatency", StringComparison.Ordinal))
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 4;
        if (string.Equals(e.Result.Grammar.Name, "ShowApplicationRender", StringComparison.Ordinal))
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 5;
        if (string.Equals(e.Result.Grammar.Name, "ShowCompositorRender", StringComparison.Ordinal))
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 6;
        if (string.Equals(e.Result.Grammar.Name, "ShowVersion", StringComparison.Ordinal))
          MyProject.Forms.FrmMain.ComboVisualHUD.SelectedIndex = 7;
        if (string.Equals(e.Result.Grammar.Name, "StartSteam", StringComparison.Ordinal))
        {
          if (File.Exists(MyProject.Forms.FrmMain.SteamPath + "\\Steam.exe"))
          {
            Log.WriteToLog("Launching SteamVR");
            FrmMain.fmain.AddToListboxAndScroll("Launching SteamVR");
            if (!OculusTrayTool.My.MySettings.Default.DisableCallback)
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
        if (OculusTrayTool.My.MySettings.Default.VoiceActivationVoiceRepeated)
        {
          if (!OculusTrayTool.My.MySettings.Default.DisableVoiceControlAudioFeedback)
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
