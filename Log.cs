// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.Log
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class Log
  {
    private static object lockObject = RuntimeHelpers.GetObjectValue(new object());

    public static void WriteToLog(string s)
    {
      try
      {
        object lockObject = Log.lockObject;
        ObjectFlowControl.CheckForSyncLockOnValueType(lockObject);
        bool lockTaken = false;
        try
        {
          Monitor.Enter(lockObject, ref lockTaken);
          using (StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\ott.log"))
          {
            streamWriter.WriteLine(string.Format("{0}: {1}", (object) DateTime.Now, (object) string.Format(s)));
            streamWriter.Flush();
          }
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(lockObject);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static void WriteToMigrateLog(string s)
    {
      try
      {
        object lockObject = Log.lockObject;
        ObjectFlowControl.CheckForSyncLockOnValueType(lockObject);
        bool lockTaken = false;
        try
        {
          Monitor.Enter(lockObject, ref lockTaken);
          using (StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\migrate.log"))
          {
            streamWriter.WriteLine(string.Format("{0}: {1}", (object) DateTime.Now, (object) string.Format(s)));
            streamWriter.Flush();
          }
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(lockObject);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    public static void WriteToLinkLog(string s)
    {
      try
      {
        object lockObject = Log.lockObject;
        ObjectFlowControl.CheckForSyncLockOnValueType(lockObject);
        bool lockTaken = false;
        try
        {
          Monitor.Enter(lockObject, ref lockTaken);
          using (StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\AirLinkPatch.log"))
          {
            streamWriter.WriteLine(string.Format("{0}: {1}", (object) DateTime.Now, (object) string.Format(s)));
            streamWriter.Flush();
          }
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(lockObject);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }
  }
}
