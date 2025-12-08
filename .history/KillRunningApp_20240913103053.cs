// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.KillRunningApp
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.CompilerServices;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
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
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetParentProcess: " + ex.Message);
        ProjectData.ClearProjectError();
        return;
      }
      try
      {
        KillRunningApp.pParent = ParentProcessUtilities.GetParentProcess(pid);
        Log.WriteToLog("PID " + Conversions.ToString(pid) + " belongs to " + KillRunningApp.proc.ProcessName + " which was started by " + KillRunningApp.pParent.ProcessName + " with PID " + Conversions.ToString(KillRunningApp.pParent.Id));
        KillRunningApp.killChildrenProcessesOf(checked ((uint) pid));
        KillRunningApp.KillApp(pid, KillRunningApp.proc.ProcessName);
        if (Operators.CompareString(KillRunningApp.pParent.ProcessName.ToLower(), "steam", false) != 0 & Operators.CompareString(KillRunningApp.pParent.ProcessName.ToLower(), "explorer", false) != 0 & Operators.CompareString(KillRunningApp.pParent.ProcessName.ToLower(), "ovrserver_x64", false) != 0)
          KillRunningApp.KillApp(KillRunningApp.pParent.Id, KillRunningApp.pParent.ProcessName);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetParentProcess: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private static void KillApp(int pid, string name)
    {
      Process processById = Process.GetProcessById(pid);
      if (processById == null)
        return;
      processById.Kill();
      Log.WriteToLog("Termination request for " + name + " with PID " + Conversions.ToString(pid) + " succeeded");
      FrmMain.fmain.AddToListboxAndScroll("Termination request for " + name + " succeeded");
    }

    private static void killChildrenProcessesOf(uint parentProcessId)
    {
      try
      {
        ManagementObjectCollection objectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ParentProcessId=" + Conversions.ToString(parentProcessId)).Get();
        if (objectCollection.Count <= 0)
          return;
        Log.WriteToLog("Killing " + Conversions.ToString(objectCollection.Count) + " processes started by process with Id \"" + Conversions.ToString(parentProcessId) + "\".");
        try
        {
          foreach (ManagementBaseObject managementBaseObject in objectCollection)
          {
            int int32 = Convert.ToInt32(RuntimeHelpers.GetObjectValue(managementBaseObject["ProcessId"]));
            if (int32 != Process.GetCurrentProcess().Id)
            {
              KillRunningApp.killChildrenProcessesOf(checked ((uint) int32));
              Process processById = Process.GetProcessById(int32);
              Log.WriteToLog("Killing child process \"" + processById.ProcessName + "\" with Id \"" + Conversions.ToString(int32) + "\".");
              processById.Kill();
              Log.WriteToLog("Termination request for " + processById.ProcessName + " with PID " + Conversions.ToString(int32) + " succeeded");
              FrmMain.fmain.AddToListboxAndScroll("Termination request for " + processById.ProcessName + " succeeded");
            }
          }
        }
        finally
        {
          ManagementObjectCollection.ManagementObjectEnumerator objectEnumerator;
          objectEnumerator?.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("killChildrenProcessesOf: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }
  }
}
