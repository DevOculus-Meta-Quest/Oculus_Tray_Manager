using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32.TaskScheduler;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x0200004E RID: 78
	[StandardModule]
	internal sealed class CreateTask
	{
		// Token: 0x060005D8 RID: 1496 RVA: 0x0002EEB8 File Offset: 0x0002D0B8
		public static void CreateScheduledTask(bool everyone)
		{
			bool dbg = Globals.dbg;
			if (dbg)
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
					bool flag = !everyone;
					if (flag)
					{
						logonTrigger.UserId = Environment.UserName;
					}
					logonTrigger.Enabled = true;
					taskDefinition.Triggers.Add<LogonTrigger>(logonTrigger);
					taskDefinition.Actions.Add<ExecAction>(new ExecAction(Application.StartupPath + "\\OculusTrayTool.exe", null, null));
					taskService.RootFolder.RegisterTaskDefinition("Oculus Tray Tool", taskDefinition);
				}
				MySettingsProperty.Settings.StartWithWindows = true;
				MySettingsProperty.Settings.Save();
				Log.WriteToLog("Enabled 'Start with Windows', startup type' Scheduled Task'");
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting CreateScheduledTask");
				}
			}
			catch (Exception ex)
			{
				MyProject.Forms.FrmMain.CheckStartWindows.Checked = false;
				FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + ex.Message);
				MyProject.Forms.FrmMain.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x0002F0A8 File Offset: 0x0002D2A8
		public static void GetAndDeleteTask(object taskName)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetAndDeleteTask");
			}
			try
			{
				using (TaskService taskService = new TaskService())
				{
					Task task = taskService.GetTask(Conversions.ToString(taskName));
					bool flag = task == null;
					if (flag)
					{
						return;
					}
					taskService.RootFolder.DeleteTask(Conversions.ToString(taskName), true);
				}
				Log.WriteToLog("Deleted scheduled task");
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting GetAndDeleteTask");
				}
			}
			catch (Exception ex)
			{
				FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + ex.Message);
				MyProject.Forms.FrmMain.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x0002F1B0 File Offset: 0x0002D3B0
		public static bool GetTask(object taskName)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetTask");
			}
			bool flag2;
			try
			{
				using (TaskService taskService = new TaskService())
				{
					Task task = taskService.GetTask(Conversions.ToString(taskName));
					bool flag = task == null;
					if (flag)
					{
						flag2 = false;
					}
					else
					{
						flag2 = true;
					}
				}
			}
			catch (Exception ex)
			{
				FrmMain.fmain.AddToListboxAndScroll("* Start with Windows: " + ex.Message);
				MyProject.Forms.FrmMain.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
			}
			return flag2;
		}
	}
}
