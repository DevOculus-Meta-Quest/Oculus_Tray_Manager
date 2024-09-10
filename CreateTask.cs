// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.CreateTask
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32.TaskScheduler;
using OculusTrayTool.My;
using System;
using System.Diagnostics;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class CreateTask
  {
    public static void CreateScheduledTask(bool everyone)
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering CreateScheduledTask");
      try
      {
        using (TaskService taskService = new TaskService())
        {
          TaskDefinition definition = taskService.NewTask();
          definition.RegistrationInfo.Description = "Oculus Tray Tool";
          definition.RegistrationInfo.Author = "ApollyonVR";
          definition.Settings.DisallowStartIfOnBatteries = false;
          definition.Settings.StopIfGoingOnBatteries = false;
          definition.Settings.IdleSettings.StopOnIdleEnd = false;
          definition.Principal.RunLevel = TaskRunLevel.Highest;
          LogonTrigger unboundTrigger = new LogonTrigger();
          unboundTrigger.StartBoundary = DateTime.Now;
          if (!everyone)
            unboundTrigger.UserId = Environment.UserName;
          unboundTrigger.Enabled = true;
          definition.Triggers.Add<LogonTrigger>(unboundTrigger);
          definition.Actions.Add<ExecAction>(new ExecAction(Application.StartupPath + "\\OculusTrayTool.exe"));
          taskService.RootFolder.RegisterTaskDefinition("Oculus Tray Tool", definition);
        }
        MySettingsProperty.Settings.StartWithWindows = true;
        MySettingsProperty.Settings.Save();
        Log.WriteToLog("Enabled 'Start with Windows', startup type' Scheduled Task'");
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Exiting CreateScheduledTask");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        MyProject.Forms.FrmMain.CheckStartWindows.Checked = false;
        FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static void GetAndDeleteTask(object taskName)
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetAndDeleteTask");
      try
      {
        using (TaskService taskService = new TaskService())
        {
          if (taskService.GetTask(Conversions.ToString(taskName)) == null)
            return;
          taskService.RootFolder.DeleteTask(Conversions.ToString(taskName));
        }
        Log.WriteToLog("Deleted scheduled task");
        if (Globals.dbg)
          Log.WriteToLog("Exiting GetAndDeleteTask");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static bool GetTask(object taskName)
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetTask");
      bool task;
      try
      {
        using (TaskService taskService = new TaskService())
          task = taskService.GetTask(Conversions.ToString(taskName)) != null;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
      return task;
    }
  }
}
