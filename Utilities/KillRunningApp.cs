using MetaQuestTrayTool.Forms;


using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.CompilerServices;

#nullable disable
namespace MetaQuestTrayTool
{

  internal sealed class KillRunningApp
  {
    private static Process proc;
    private static Process pParent;

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
        Log.WriteToLog("PID " + Convert.ToString(pid) + " belongs to " + KillRunningApp.proc.ProcessName + " which was started by " + KillRunningApp.pParent.ProcessName + " with PID " + Convert.ToString(KillRunningApp.pParent.Id));
        KillRunningApp.killChildrenProcessesOf(checked ((uint) pid));
        KillRunningApp.KillApp(pid, KillRunningApp.proc.ProcessName);
        if (!string.Equals(KillRunningApp.pParent.ProcessName.ToLower(), "steam", StringComparison.Ordinal) & !string.Equals(KillRunningApp.pParent.ProcessName.ToLower(), "explorer", StringComparison.Ordinal) & !string.Equals(KillRunningApp.pParent.ProcessName.ToLower(), "ovrserver_x64", StringComparison.Ordinal))
          KillRunningApp.KillApp(KillRunningApp.pParent.Id, KillRunningApp.pParent.ProcessName);
      }
      catch (Exception ex)
      {
        Log.WriteToLog("GetParentProcess: " + ex.Message);
      }
    }

    private static void KillApp(int pid, string name)
    {
      Process processById = Process.GetProcessById(pid);
      if (processById == null)
        return;
      processById.Kill();
      Log.WriteToLog("Termination request for " + name + " with PID " + Convert.ToString(pid) + " succeeded");
      FrmMain.fmain.AddToListboxAndScroll("Termination request for " + name + " succeeded");
    }

    private static void killChildrenProcessesOf(uint parentProcessId)
    {
      try
      {
        ManagementObjectCollection objectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ParentProcessId=" + Convert.ToString(parentProcessId)).Get();
        if (objectCollection.Count <= 0)
          return;
        Log.WriteToLog("Killing " + Convert.ToString(objectCollection.Count) + " processes started by process with Id \"" + Convert.ToString(parentProcessId) + "\".");
          foreach (ManagementBaseObject managementBaseObject in objectCollection)
          {
            int int32 = Convert.ToInt32(managementBaseObject["ProcessId"]);
            if (int32 != Process.GetCurrentProcess().Id)
            {
              KillRunningApp.killChildrenProcessesOf(checked ((uint) int32));
              Process processById = Process.GetProcessById(int32);
              Log.WriteToLog("Killing child process \"" + processById.ProcessName + "\" with Id \"" + Convert.ToString(int32) + "\".");
              processById.Kill();
              Log.WriteToLog("Termination request for " + processById.ProcessName + " with PID " + Convert.ToString(int32) + " succeeded");
              FrmMain.fmain.AddToListboxAndScroll("Termination request for " + processById.ProcessName + " succeeded");
            }
          }
      }
      catch (Exception ex)
      {
        Log.WriteToLog("killChildrenProcessesOf: " + ex.Message);
      }
    }
  }
}

