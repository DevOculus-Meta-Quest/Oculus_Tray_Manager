using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32.TaskScheduler;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class CreateTask
{
	public static void CreateScheduledTask(bool everyone)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering CreateScheduledTask");
		}
		try
		{
			using (TaskService taskService = new TaskService())
			{
				TaskDefinition taskDefinition = taskService.NewTask();
				taskDefinition.RegistrationInfo.Description = "Oculus Tray Tool";
				taskDefinition.RegistrationInfo.Author = "ApollyonVR";
				taskDefinition.Settings.DisallowStartIfOnBatteries = false;
				taskDefinition.Settings.StopIfGoingOnBatteries = false;
				taskDefinition.Settings.IdleSettings.StopOnIdleEnd = false;
				taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;
				LogonTrigger logonTrigger = new LogonTrigger();
				logonTrigger.StartBoundary = DateTime.Now;
				if (!everyone)
				{
					logonTrigger.UserId = Environment.UserName;
				}
				logonTrigger.Enabled = true;
				taskDefinition.Triggers.Add(logonTrigger);
				taskDefinition.Actions.Add(new ExecAction(Application.StartupPath + "\\OculusTrayTool.exe"));
				taskService.RootFolder.RegisterTaskDefinition("Oculus Tray Tool", taskDefinition);
			}
			MySettingsProperty.Settings.StartWithWindows = true;
			MySettingsProperty.Settings.Save();
			Log.WriteToLog("Enabled 'Start with Windows', startup type' Scheduled Task'");
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting CreateScheduledTask");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MyProject.Forms.FrmMain.CheckStartWindows.Checked = false;
			FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + ex2.Message);
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public static void GetAndDeleteTask(object taskName)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetAndDeleteTask");
		}
		try
		{
			using (TaskService taskService = new TaskService())
			{
				Task task = taskService.GetTask(Conversions.ToString(taskName));
				if (task == null)
				{
					return;
				}
				taskService.RootFolder.DeleteTask(Conversions.ToString(taskName));
			}
			Log.WriteToLog("Deleted scheduled task");
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetAndDeleteTask");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + ex2.Message);
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public static bool GetTask(object taskName)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetTask");
		}
		bool result = default(bool);
		try
		{
			using TaskService taskService = new TaskService();
			Task task = taskService.GetTask(Conversions.ToString(taskName));
			if (task == null)
			{
				result = false;
				return result;
			}
			result = true;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + ex2.Message);
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
