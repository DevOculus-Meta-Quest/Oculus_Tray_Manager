// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.RunCommand
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class RunCommand
  {
    public static List<string> usb_suspend_list = new List<string>();
    public static int DebugToolInstances = 0;
    public static string debug_tool_path = "";

    public static void Run_debug_tool(string ss)
    {
      if (Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0)
      {
        Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting SuperSampling to " + ss);
        FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting SuperSampling to " + ss);
      }
      else
      {
        Log.WriteToLog("Setting SuperSampling to " + ss);
        FrmMain.fmain.AddToListboxAndScroll("Setting SuperSampling to " + ss);
      }
      Process process = new Process();
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\ppdp.txt"))
        {
          streamWriter.WriteLine("service set-pixels-per-display-pixel " + ss);
          streamWriter.WriteLine("exit");
        }
        process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\ppdp.txt\"")
        {
          UseShellExecute = false,
          CreateNoWindow = true
        };
        if (Globals.dbg)
          Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
        if (MySettingsProperty.Settings.DbgToolMethod == 1)
          UACHelper.UACHelper.StartWithShell(process.StartInfo);
        if (MySettingsProperty.Settings.DbgToolMethod != 2)
          return;
        process.Start();
        process.WaitForExit();
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        Exception exception = ex1;
        try
        {
          Log.WriteToLog("Set SuperSampling: Failed: " + exception.Message);
          Log.WriteToLog("Set SuperSampling: Re-trying...");
          if (MySettingsProperty.Settings.DbgToolMethod == 1)
          {
            process.Start();
            process.WaitForExit();
            MySettingsProperty.Settings.DbgToolMethod = 2;
            MySettingsProperty.Settings.Save();
          }
          if (MySettingsProperty.Settings.DbgToolMethod == 2)
          {
            UACHelper.UACHelper.StartWithShell(process.StartInfo);
            MySettingsProperty.Settings.DbgToolMethod = 1;
            MySettingsProperty.Settings.Save();
          }
        }
        catch (Exception ex2)
        {
          ProjectData.SetProjectError(ex2);
          Exception e = ex2;
          Log.WriteToLog("Set SuperSampling: Failed: " + e.Message);
          StackTrace stackTrace = new StackTrace(e, true);
          Log.WriteToLog(e.ToString() + stackTrace.ToString());
          FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
          ProjectData.ClearProjectError();
        }
        ProjectData.ClearProjectError();
      }
    }

    public static void Run_debug_tool_info(string info)
    {
      Log.WriteToLog("Setting Info Overlay to " + info);
      Process process = new Process();
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\perf.txt"))
        {
          streamWriter.WriteLine(info);
          streamWriter.WriteLine("exit");
        }
        process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\perf.txt\"")
        {
          UseShellExecute = false,
          CreateNoWindow = true
        };
        if (Globals.dbg)
          Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
        if (MySettingsProperty.Settings.DbgToolMethod == 1)
          UACHelper.UACHelper.StartWithShell(process.StartInfo);
        if (MySettingsProperty.Settings.DbgToolMethod != 2)
          return;
        process.Start();
        process.WaitForExit();
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        Exception exception = ex1;
        try
        {
          Log.WriteToLog("Set Info Overlay: Failed: " + exception.Message);
          Log.WriteToLog("Set Info Overlay: Re-trying...");
          if (MySettingsProperty.Settings.DbgToolMethod == 1)
          {
            process.Start();
            process.WaitForExit();
            MySettingsProperty.Settings.DbgToolMethod = 2;
            MySettingsProperty.Settings.Save();
          }
          if (MySettingsProperty.Settings.DbgToolMethod == 2)
          {
            UACHelper.UACHelper.StartWithShell(process.StartInfo);
            MySettingsProperty.Settings.DbgToolMethod = 1;
            MySettingsProperty.Settings.Save();
          }
        }
        catch (Exception ex2)
        {
          ProjectData.SetProjectError(ex2);
          Exception e = ex2;
          Log.WriteToLog("Warning: Set Info Overlay: " + e.Message);
          StackTrace stackTrace = new StackTrace(e, true);
          Log.WriteToLog(e.ToString() + stackTrace.ToString());
          FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
          ProjectData.ClearProjectError();
        }
        ProjectData.ClearProjectError();
      }
    }

    public static void Run_debug_tool_asw(string info)
    {
      Log.WriteToLog("Setting ASW to " + info);
      Process process = new Process();
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\asw.txt"))
        {
          streamWriter.WriteLine(info);
          streamWriter.WriteLine("exit");
        }
        process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\asw.txt\"")
        {
          UseShellExecute = false,
          CreateNoWindow = true
        };
        if (Globals.dbg)
          Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
        if (MySettingsProperty.Settings.DbgToolMethod == 1)
          UACHelper.UACHelper.StartWithShell(process.StartInfo);
        if (MySettingsProperty.Settings.DbgToolMethod != 2)
          return;
        process.Start();
        process.WaitForExit();
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        Exception exception = ex1;
        try
        {
          Log.WriteToLog("Set ASW: Failed: " + exception.Message);
          Log.WriteToLog("Set ASW: Re-trying...");
          if (MySettingsProperty.Settings.DbgToolMethod == 1)
          {
            process.Start();
            process.WaitForExit();
            MySettingsProperty.Settings.DbgToolMethod = 2;
            MySettingsProperty.Settings.Save();
          }
          if (MySettingsProperty.Settings.DbgToolMethod == 2)
          {
            UACHelper.UACHelper.StartWithShell(process.StartInfo);
            MySettingsProperty.Settings.DbgToolMethod = 1;
            MySettingsProperty.Settings.Save();
          }
        }
        catch (Exception ex2)
        {
          ProjectData.SetProjectError(ex2);
          Exception e = ex2;
          Log.WriteToLog("Set ASW: Failed: " + e.Message);
          StackTrace stackTrace = new StackTrace(e, true);
          Log.WriteToLog(e.ToString() + stackTrace.ToString());
          FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
          ProjectData.ClearProjectError();
        }
        ProjectData.ClearProjectError();
      }
    }

    public static void Run_debug_tool_fov(string info)
    {
      if (Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0)
      {
        Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting FOV to " + info.Replace(" ", ";"));
        FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting FOV to " + info.Replace(" ", ";"));
      }
      else
      {
        Log.WriteToLog("Setting FOV to " + info.Replace(" ", ";"));
        FrmMain.fmain.AddToListboxAndScroll("Setting FOV to " + info.Replace(" ", ";"));
      }
      Process process = new Process();
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\fov.txt"))
        {
          streamWriter.WriteLine("service set-client-fov-tan-angle-multiplier " + info);
          streamWriter.WriteLine("exit");
        }
        process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\fov.txt\"")
        {
          UseShellExecute = false,
          CreateNoWindow = true
        };
        if (Globals.dbg)
          Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
        if (MySettingsProperty.Settings.DbgToolMethod == 1)
          UACHelper.UACHelper.StartWithShell(process.StartInfo);
        if (MySettingsProperty.Settings.DbgToolMethod != 2)
          return;
        process.Start();
        process.WaitForExit();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        Log.WriteToLog("Set FOV: Failed: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void Run_debug_tool_agps(string info)
    {
      if (Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0)
      {
        Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting Adaptive GPU Scaling to " + info);
        FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting Adaptive GPU Scaling to " + info);
      }
      else
      {
        Log.WriteToLog("Setting Adaptive GPU Scaling to " + info);
        FrmMain.fmain.AddToListboxAndScroll("Setting Adaptive GPU Scaling to " + info);
      }
      Process process = new Process();
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\agps.txt"))
        {
          streamWriter.WriteLine("service enable-adaptive-gpu-perf-scale " + info);
          streamWriter.WriteLine("exit");
        }
        process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\agps.txt\"")
        {
          UseShellExecute = false,
          CreateNoWindow = true
        };
        if (Globals.dbg)
          Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
        if (MySettingsProperty.Settings.DbgToolMethod == 1)
          UACHelper.UACHelper.StartWithShell(process.StartInfo);
        if (MySettingsProperty.Settings.DbgToolMethod != 2)
          return;
        process.Start();
        process.WaitForExit();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        Log.WriteToLog("Set GPU Scaling: Failed: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void Run_debug_tool_force_mipmap(string info)
    {
      if (Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0)
      {
        Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting Force MipMap Generation On All Layers to " + info.ToLower());
        FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting Force MipMap Generation On All Layers to " + info.ToLower());
      }
      else
      {
        Log.WriteToLog("Setting Force MipMap Generation On All Layers to " + info.ToLower());
        FrmMain.fmain.AddToListboxAndScroll("Setting Force MipMap Generation On All Layers to " + info.ToLower());
      }
      Process process = new Process();
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\force.txt"))
        {
          streamWriter.WriteLine("service set-force-mip-gen-on-all-layers " + info.ToLower());
          streamWriter.WriteLine("exit");
        }
        process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\force.txt\"")
        {
          UseShellExecute = false,
          CreateNoWindow = true
        };
        if (Globals.dbg)
          Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
        if (MySettingsProperty.Settings.DbgToolMethod == 1)
          UACHelper.UACHelper.StartWithShell(process.StartInfo);
        if (MySettingsProperty.Settings.DbgToolMethod != 2)
          return;
        process.Start();
        process.WaitForExit();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        Log.WriteToLog("Setting force-mip-gen-on-all-layers: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void Run_debug_tool_offset_mipmap(string info)
    {
      if (Operators.CompareString(FrmMain.fmain.runningApp, "", false) != 0)
      {
        Log.WriteToLog(FrmMain.fmain.runningapp_displayname + ": Setting Offset MipMap Bias On All Layers to " + info);
        FrmMain.fmain.AddToListboxAndScroll(FrmMain.fmain.runningapp_displayname + ": Setting Offset MipMap Bias On All Layers to " + info);
      }
      else
      {
        Log.WriteToLog("Setting Offset MipMap Bias On All Layers to " + info);
        FrmMain.fmain.AddToListboxAndScroll("Setting Offset MipMap Bias On All Layers to " + info);
      }
      Process process = new Process();
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\offset.txt"))
        {
          streamWriter.WriteLine("service set-offset-mip-bias-on-all-layers " + info);
          streamWriter.WriteLine("exit");
        }
        process.StartInfo = new ProcessStartInfo("\"" + RunCommand.debug_tool_path + "\"", " -f \"" + Application.StartupPath + "\\offset.txt\"")
        {
          UseShellExecute = false,
          CreateNoWindow = true
        };
        if (Globals.dbg)
          Log.WriteToLog("Command: " + process.StartInfo.FileName + process.StartInfo.Arguments);
        if (MySettingsProperty.Settings.DbgToolMethod == 1)
          UACHelper.UACHelper.StartWithShell(process.StartInfo);
        if (MySettingsProperty.Settings.DbgToolMethod != 2)
          return;
        process.Start();
        process.WaitForExit();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        Log.WriteToLog("Setting offset-mip-bias-on-all-layers: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void StartHome()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering StartHome");
      try
      {
        if (Process.GetProcessesByName("OculusClient").Length > 0)
          return;
        FrmMain.fmain.AddToListboxAndScroll("Launching Oculus Home in " + Conversions.ToString(GetConfig.StartHomeDelay) + " seconds..");
        Log.WriteToLog("Launching Oculus Home");
        Thread.Sleep(checked (GetConfig.StartHomeDelay * 1000));
        if (Globals.dbg)
          Log.WriteToLog("Starting process " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\OculusClient.exe");
        new Process()
        {
          StartInfo = new ProcessStartInfo(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\OculusClient.exe")
          {
            UseShellExecute = true
          }
        }.Start();
        if (Globals.dbg)
          Log.WriteToLog("Process started");
        if (Globals.dbg)
          Log.WriteToLog("Exiting StartHome");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        Log.WriteToLog("Warning: Could not launch Oculus Home: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void CloseDebugTool()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering CloseDebugTool");
      try
      {
        Log.WriteToLog("Checking for running instances of the OculusDebugTool");
        RunCommand.DebugToolInstances = 0;
        Process[] processesByName = Process.GetProcessesByName("OculusDebugToolCLI");
        int index = 0;
        while (index < processesByName.Length)
        {
          Process process = processesByName[index];
          try
          {
            process.Kill();
            checked { ++RunCommand.DebugToolInstances; }
            Thread.Sleep(100);
          }
          catch (InvalidOperationException ex)
          {
            ProjectData.SetProjectError((Exception) ex);
            InvalidOperationException operationException = ex;
            if ((double) operationException.HResult == Conversions.ToDouble("-2146233079 "))
            {
              ProjectData.ClearProjectError();
              return;
            }
            Log.WriteToLog("Warning: CloseDebugTool: " + operationException.Message);
            ProjectData.ClearProjectError();
          }
          checked { ++index; }
        }
        if (RunCommand.DebugToolInstances > 0)
          Log.WriteToLog("Killed " + Conversions.ToString(RunCommand.DebugToolInstances) + " running instances of the OculusDebugTool");
        else
          Log.WriteToLog("Found " + Conversions.ToString(RunCommand.DebugToolInstances) + " running instances of the OculusDebugTool");
        if (File.Exists(Application.StartupPath + "\\perf_info.txt"))
        {
          File.Delete(Application.StartupPath + "\\perf_info.txt");
          if (Globals.dbg)
            Log.WriteToLog("Deleted temporary file: perf_info.txt");
        }
        if (File.Exists(Application.StartupPath + "\\ppdp.txt"))
        {
          File.Delete(Application.StartupPath + "\\ppdp.txt");
          if (Globals.dbg)
            Log.WriteToLog("Deleted temporary file: ppdp.txt");
        }
        if (File.Exists(Application.StartupPath + "\\usb.txt"))
        {
          File.Delete(Application.StartupPath + "\\usb.txt");
          if (Globals.dbg)
            Log.WriteToLog("Deleted temporary file: usb.txt");
        }
        if (File.Exists(Application.StartupPath + "\\fov.txt"))
        {
          File.Delete(Application.StartupPath + "\\fov.txt");
          if (Globals.dbg)
            Log.WriteToLog("Deleted temporary file: fov.txt");
        }
        if (File.Exists(Application.StartupPath + "\\agps.txt"))
        {
          File.Delete(Application.StartupPath + "\\agps.txt");
          if (Globals.dbg)
            Log.WriteToLog("Deleted temporary file: agps.txt");
        }
        if (File.Exists(Application.StartupPath + "\\asw.txt"))
        {
          File.Delete(Application.StartupPath + "\\asw.txt");
          if (Globals.dbg)
            Log.WriteToLog("Deleted temporary file: asw.txt");
        }
        if (File.Exists(Application.StartupPath + "\\force.txt"))
        {
          File.Delete(Application.StartupPath + "\\force.txt");
          if (Globals.dbg)
            Log.WriteToLog("Deleted temporary file: force.txt");
        }
        if (File.Exists(Application.StartupPath + "\\offset.txt"))
        {
          File.Delete(Application.StartupPath + "\\offset.txt");
          if (Globals.dbg)
            Log.WriteToLog("Deleted temporary file: offset.txt");
        }
        if (Globals.dbg)
          Log.WriteToLog("Exiting CloseDebugTool");
      }
      catch (Win32Exception ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        if (Operators.CompareString(ex.HResult.ToString(), "0x80004005", false) == 0)
          ProjectData.ClearProjectError();
        else
          ProjectData.ClearProjectError();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        Log.WriteToLog("CloseDebugTool: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void Run_PowerCFG(string name, string id)
    {
      try
      {
        Process process = new Process();
        process.StartInfo = new ProcessStartInfo("cmd.exe", "/c powercfg /setactive " + id)
        {
          UseShellExecute = false,
          CreateNoWindow = true
        };
        process.Start();
        process.WaitForExit();
        FrmMain.fmain.AddToListboxAndScroll("Power Plan set to " + name);
        PowerPlans.GetActivePowerPlan();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        Log.WriteToLog("Run_PowerCFG: " + e.Message);
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        FrmMain.fmain.AddToListboxAndScroll("* " + e.Message);
        ProjectData.ClearProjectError();
      }
    }
  }
}
