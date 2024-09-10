using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000034 RID: 52
	[StandardModule]
	internal sealed class KillRunningApp
	{
		// Token: 0x060004CF RID: 1231 RVA: 0x000231E8 File Offset: 0x000213E8
		public static void GetParentProcess(int pid)
		{
			try
			{
				KillRunningApp.proc = Process.GetProcessById(pid);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetParentProcess: " + ex.Message);
				return;
			}
			try
			{
				KillRunningApp.pParent = ParentProcessUtilities.GetParentProcess(pid);
				Log.WriteToLog(string.Concat(new string[]
				{
					"PID ",
					Conversions.ToString(pid),
					" belongs to ",
					KillRunningApp.proc.ProcessName,
					" which was started by ",
					KillRunningApp.pParent.ProcessName,
					" with PID ",
					Conversions.ToString(KillRunningApp.pParent.Id)
				}));
				KillRunningApp.killChildrenProcessesOf(checked((uint)pid));
				KillRunningApp.KillApp(pid, KillRunningApp.proc.ProcessName);
				bool flag = (Operators.CompareString(KillRunningApp.pParent.ProcessName.ToLower(), "steam", false) != 0) & (Operators.CompareString(KillRunningApp.pParent.ProcessName.ToLower(), "explorer", false) != 0) & (Operators.CompareString(KillRunningApp.pParent.ProcessName.ToLower(), "ovrserver_x64", false) != 0);
				if (flag)
				{
					KillRunningApp.KillApp(KillRunningApp.pParent.Id, KillRunningApp.pParent.ProcessName);
				}
			}
			catch (Exception ex2)
			{
				Log.WriteToLog("GetParentProcess: " + ex2.Message);
			}
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00023390 File Offset: 0x00021590
		private static void KillApp(int pid, string name)
		{
			Process processById = Process.GetProcessById(pid);
			bool flag = processById != null;
			if (flag)
			{
				processById.Kill();
				Log.WriteToLog(string.Concat(new string[]
				{
					"Termination request for ",
					name,
					" with PID ",
					Conversions.ToString(pid),
					" succeeded"
				}));
				FrmMain.fmain.AddToListboxAndScroll("Termination request for " + name + " succeeded");
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00023408 File Offset: 0x00021608
		private static void killChildrenProcessesOf(uint parentProcessId)
		{
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ParentProcessId=" + Conversions.ToString(parentProcessId));
				ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
				bool flag = managementObjectCollection.Count > 0;
				if (flag)
				{
					Log.WriteToLog(string.Concat(new string[]
					{
						"Killing ",
						Conversions.ToString(managementObjectCollection.Count),
						" processes started by process with Id \"",
						Conversions.ToString(parentProcessId),
						"\"."
					}));
					try
					{
						foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
						{
							int num = Convert.ToInt32(RuntimeHelpers.GetObjectValue(managementBaseObject["ProcessId"]));
							bool flag2 = num != Process.GetCurrentProcess().Id;
							if (flag2)
							{
								KillRunningApp.killChildrenProcessesOf(checked((uint)num));
								Process processById = Process.GetProcessById(num);
								Log.WriteToLog(string.Concat(new string[]
								{
									"Killing child process \"",
									processById.ProcessName,
									"\" with Id \"",
									Conversions.ToString(num),
									"\"."
								}));
								processById.Kill();
								Log.WriteToLog(string.Concat(new string[]
								{
									"Termination request for ",
									processById.ProcessName,
									" with PID ",
									Conversions.ToString(num),
									" succeeded"
								}));
								FrmMain.fmain.AddToListboxAndScroll("Termination request for " + processById.ProcessName + " succeeded");
							}
						}
					}
					finally
					{
						ManagementObjectCollection.ManagementObjectEnumerator enumerator;
						if (enumerator != null)
						{
							((IDisposable)enumerator).Dispose();
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("killChildrenProcessesOf: " + ex.Message);
			}
		}

		// Token: 0x040001C7 RID: 455
		private static Process proc;

		// Token: 0x040001C8 RID: 456
		private static Process pParent;
	}
}
