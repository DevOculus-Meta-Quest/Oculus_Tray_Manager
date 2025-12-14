

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  internal static class Log
  {
    private static object lockObject = new object();

    public static void WriteToLog(string s)
    {
      try
      {
        object lockObject = Log.lockObject;
        object lockObject = Log.lockObject;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(lockObject, ref lockTaken);
          using (StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\ott_debug.log"))
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
        
        // Write to UI outside lock
        if (FrmMain.fmain != null)
        {
             try { FrmMain.fmain.AddToListboxAndScroll(s); } catch {}
        }
      }
      catch (Exception ex)
      {
      catch (Exception ex)
      {
      }
      }
    }

    public static void ClearLog()
    {
      try
      {
        object lockObject = Log.lockObject;
        bool lockTaken = false;
        try
        {
          Monitor.Enter(lockObject, ref lockTaken);
          // Overwrite with empty content to clear the file
          File.WriteAllText(Application.StartupPath + "\\ott_debug.log", string.Empty);
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit(lockObject);
        }
      }
      catch (Exception ex)
      {
      catch (Exception ex)
      {
      }
      }
    }

    public static void WriteToMigrateLog(string s)
    {
      try
      {
        object lockObject = Log.lockObject;
        object lockObject = Log.lockObject;
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
      catch (Exception ex)
      {
      }
      }
    }

    public static void WriteToLinkLog(string s)
    {
      try
      {
        object lockObject = Log.lockObject;
        object lockObject = Log.lockObject;
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
      catch (Exception ex)
      {
      }
      }
    }
  }
}
