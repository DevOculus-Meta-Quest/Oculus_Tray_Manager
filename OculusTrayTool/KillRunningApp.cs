using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[StandardModule]
internal sealed class KillRunningApp
{
	private static Process proc;

	private static Process pParent;

	public static void GetParentProcess(int pid)
	{
		try
		{
			proc = Process.GetProcessById(pid);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetParentProcess: " + ex2.Message);
			ProjectData.ClearProjectError();
			return;
		}
		try
		{
			pParent = ParentProcessUtilities.GetParentProcess(pid);
			Log.WriteToLog("PID " + Conversions.ToString(pid) + " belongs to " + proc.ProcessName + " which was started by " + pParent.ProcessName + " with PID " + Conversions.ToString(pParent.Id));
			killChildrenProcessesOf(checked((uint)pid));
			KillApp(pid, proc.ProcessName);
			if ((Operators.CompareString(pParent.ProcessName.ToLower(), "steam", TextCompare: false) != 0) & (Operators.CompareString(pParent.ProcessName.ToLower(), "explorer", TextCompare: false) != 0) & (Operators.CompareString(pParent.ProcessName.ToLower(), "ovrserver_x64", TextCompare: false) != 0))
			{
				KillApp(pParent.Id, pParent.ProcessName);
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteToLog("GetParentProcess: " + ex4.Message);
			ProjectData.ClearProjectError();
		}
	}

	private static void KillApp(int pid, string name)
	{
		Process processById = Process.GetProcessById(pid);
		if (processById != null)
		{
			processById.Kill();
			Log.WriteToLog("Termination request for " + name + " with PID " + Conversions.ToString(pid) + " succeeded");
			FrmMain.fmain.AddToListboxAndScroll("Termination request for " + name + " succeeded");
		}
	}

	private static void killChildrenProcessesOf(uint parentProcessId)
	{
		try
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ParentProcessId=" + Conversions.ToString(parentProcessId));
			ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
			if (managementObjectCollection.Count <= 0)
			{
				return;
			}
			Log.WriteToLog("Killing " + Conversions.ToString(managementObjectCollection.Count) + " processes started by process with Id \"" + Conversions.ToString(parentProcessId) + "\".");
			foreach (ManagementBaseObject item in managementObjectCollection)
			{
				int num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(item["ProcessId"]));
				if (num != Process.GetCurrentProcess().Id)
				{
					killChildrenProcessesOf(checked((uint)num));
					Process processById = Process.GetProcessById(num);
					Log.WriteToLog("Killing child process \"" + processById.ProcessName + "\" with Id \"" + Conversions.ToString(num) + "\".");
					processById.Kill();
					Log.WriteToLog("Termination request for " + processById.ProcessName + " with PID " + Conversions.ToString(num) + " succeeded");
					FrmMain.fmain.AddToListboxAndScroll("Termination request for " + processById.ProcessName + " succeeded");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("killChildrenProcessesOf: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}
}
