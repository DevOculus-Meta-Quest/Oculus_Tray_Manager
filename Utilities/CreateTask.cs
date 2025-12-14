using MetaQuestTrayTool.Forms;


using Microsoft.Win32.TaskScheduler;
using MetaQuestTrayTool.My;
using System;
using System.Diagnostics;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool
{

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
          definition.RegistrationInfo.Description = "Meta Quest Tray Tool";
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
          definition.Actions.Add<ExecAction>(new ExecAction(Application.StartupPath + "\\MetaQuestTrayTool.exe"));
          taskService.RootFolder.RegisterTaskDefinition("Meta Quest Tray Tool", definition);
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
        Exception e = ex;
        FrmMain.fmain.CheckStartWindows.Checked = false;
        FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + e.Message);
        Log.WriteToLog("WARNING TRIGGERED: CreateScheduledTask exception");
        FrmMain.fmain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
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
          if (taskService.GetTask(Convert.ToString(taskName)) == null)
            return;
          taskService.RootFolder.DeleteTask(Convert.ToString(taskName));
        }
        Log.WriteToLog("Deleted scheduled task");
        if (Globals.dbg)
          Log.WriteToLog("Exiting GetAndDeleteTask");
      }
      catch (Exception ex)
      {
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + e.Message);
        Log.WriteToLog("WARNING TRIGGERED: GetAndDeleteTask exception");
        FrmMain.fmain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
      }
    }

    public static bool GetTask(object taskName)
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetTask");
      bool task = false;
      try
      {
        using (TaskService taskService = new TaskService())
          task = taskService.GetTask(Convert.ToString(taskName)) != null;
      }
      catch (Exception ex)
      {
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + e.Message);
        Log.WriteToLog("WARNING TRIGGERED: GetTask exception");
        FrmMain.fmain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
      }
      return task;
    }
  }
}

