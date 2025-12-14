
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
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Voice recognition initialized, waiting for Oculus Home to start");
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Input device: " + Convert.ToString(defaultAudioEndpoint.Properties.GetValue(1).Value) + " (" + defaultAudioEndpoint.FriendlyName + ")");
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Input volume: " + (defaultAudioEndpoint.AudioEndpointVolume.MasterVolumeLevelScalar * 100f).ToString() + "%");
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Confidence level: " + Convert.ToString(OculusTrayTool.My.MySettings.Default.Confidence) + "%");
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Language: " + VoiceCommands.sRecognizeStartStop.RecognizerInfo.Culture.EnglishName);
        if (!defaultAudioEndpoint.FriendlyName.ToLower().Contains("rift"))
        {
          Log.WriteToLog("Rift microphone is not the default input device.");
          MyProject.Forms.FrmMain.AddToListboxAndScroll("Rift microphone is not the default input device");
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
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Voice recognition initialization failed: " + ex.Message);
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

    private static void sRecognizeStartStop_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
      if (e.Result.Text == "Stop")
      {
        VoiceCommands.StopListening();
      }
      else if (e.Result.Text == "Start")
      {
          if (Globals.dbg) Log.WriteToLog("Voice Command: Start");
          VoiceCommands.sRecognizeStartStop.RecognizeAsyncStop();
          VoiceCommands.isListening = true;
      }
    }

    public static void sRecognize_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
        if (Globals.dbg) Log.WriteToLog("Main Voice Command Recognized: " + e.Result.Text);
    }

    public static void StopListening()
    {
        if (Globals.dbg) Log.WriteToLog("Voice Command: Stop Listening");
        VoiceCommands.isListening = false;
        if (VoiceCommands.sRecognize != null)
        {
            VoiceCommands.sRecognize.RecognizeAsyncStop();
        }
        if (VoiceCommands.sRecognizeStartStop != null)
        {
             VoiceCommands.sRecognizeStartStop.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
  }
}
