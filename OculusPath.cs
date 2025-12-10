

using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  
  internal sealed class OculusPath
  {
    public static object GetOculusSoftwarePaths()
    {
      List<string> stringList = new List<string>();
      object oculusSoftwarePaths;
      try
      {
        if (Globals.dbg)
          Log.WriteToLog("Entering GetOculusSoftwarePaths");
        string explorerSid = OculusPath.GetExplorerUserSid().ToString();
        string obj = explorerSid + "\\SOFTWARE\\Oculus VR, LLC\\Oculus\\Libraries\\";
        if (Globals.dbg)
          Log.WriteToLog("Looking in " + obj);
        if (Microsoft.Win32.Registry.Users.OpenSubKey(obj, false) != null)
        {
          if (Globals.dbg)
            Log.WriteToLog("Key found, proceeding");
          string[] subKeyNames = Microsoft.Win32.Registry.Users.OpenSubKey(obj).GetSubKeyNames();
          int index = 0;
          while (index < subKeyNames.Length)
          {
            string Right1 = subKeyNames[index];
            if (Globals.dbg)
              Log.WriteToLog("Looking for 'Path' parameter in " + obj + Right1);
            if (Microsoft.Win32.Registry.Users.OpenSubKey(obj + Right1, false).GetValue("Path") != null)
            {
              if (Globals.dbg)
                Log.WriteToLog("'Path' found, opening key");
              string str1 = Convert.ToString(Microsoft.Win32.Registry.Users.OpenSubKey(obj + Right1, false).GetValue("Path"));
              int startIndex = str1.LastIndexOf("}");
              string str2 = str1.Substring(startIndex).TrimStart('}');
              string Right2 = str1.Replace(str2, "") + "\\";
              ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Volume");
              foreach (ManagementObject managementObject in managementObjectSearcher.Get())
              {
                if (string.Equals(managementObject["DeviceID"]?.ToString(), Right2, StringComparison.OrdinalIgnoreCase))
                {
                  string str3 = managementObject["DriveLetter"]?.ToString() + str2;
                  stringList.Add(str3);
                  if (Globals.dbg)
                  {
                    Log.WriteToLog("Added " + str3 + " to Library paths");
                    break;
                  }
                  break;
                }
              }
            }
            else if (Globals.dbg)
              Log.WriteToLog("No 'Path' in " + obj + Right1);
            checked { ++index; }
          }
        }
        else
        {
          Log.WriteToLog("Could not get Oculus Software path from registry");
          FrmMain.fmain.AddToListboxAndScroll("Could not get Oculus Software path from registry");
        }
        oculusSoftwarePaths = (object) stringList;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        int num = (int) Interaction.MsgBox((object) "Could not get Oculus Library paths from the registry. Add them manually on the Advanced tab and restart the application", MsgBoxStyle.Exclamation, (object) "Oculus Tray Tool");
        FrmMain.fmain.AddToListboxAndScroll("Could not get Oculus Library path: " + e.Message);
        MyProject.Forms.FrmMain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog("GetOculusSoftwarePath: " + e.ToString() + stackTrace.ToString());
        oculusSoftwarePaths = (object) stringList;
        ProjectData.ClearProjectError();
      }
      return oculusSoftwarePaths;
    }

    public static object GetExplorerUserSid()
    {
      ManagementObjectCollection objectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name = 'explorer.exe'").Get();
      ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;
      try
      {
        enumerator = objectCollection.GetEnumerator();
        if (enumerator.MoveNext())
        {
          ManagementObject current = (ManagementObject) enumerator.Current;
          string[] args = new string[1];
          current.InvokeMethod("GetOwnerSid", (object[]) args);
          return (object) args[0];
        }
      }
      finally
      {
        enumerator?.Dispose();
      }
      return (object) string.Empty;
    }

    public static void GetOculusPath()
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetOculusPath");
      try
      {
        if (MyProject.Forms.FrmMain.isElevated)
        {
          if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Oculus VR, LLC\\Oculus") != null)
          {
            MyProject.Forms.FrmMain.OculusPath = Convert.ToString(Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Oculus VR, LLC\\Oculus", false).GetValue("Base"));
            Log.WriteToLog("Oculus path: " + MyProject.Forms.FrmMain.OculusPath);
            if (!MyProject.Forms.FrmMain.OculusPath.EndsWith("\\"))
              MyProject.Forms.FrmMain.OculusPath += "\\";
          }
          else if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Oculus VR, LLC\\Oculus") != null)
          {
            MyProject.Forms.FrmMain.OculusPath = Convert.ToString(Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Oculus VR, LLC\\Oculus", true).GetValue("Base"));
            Log.WriteToLog("Oculus path: " + MyProject.Forms.FrmMain.OculusPath);
            if (!MyProject.Forms.FrmMain.OculusPath.EndsWith("\\"))
              MyProject.Forms.FrmMain.OculusPath += "\\";
          }
          MySettingsProperty.Settings.OculusPath = MyProject.Forms.FrmMain.OculusPath;
          MySettingsProperty.Settings.Save();
          if (File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-runtime\\OVRServer_x64.exe"))
          {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-runtime\\OVRServiceLauncher.exe");
            MyProject.Forms.FrmMain.OculusAppVersion = versionInfo.FileMajorPart.ToString() + versionInfo.FileMinorPart.ToString();
            Log.WriteToLog("Oculus App Version: " + versionInfo.FileVersion);
            if (versionInfo.FileMajorPart < 23)
            {
              Log.WriteToLog("Oculus App version is lower than 23, Bitrate option for Link not supported: Disabling option");
              FrmMain.fmain.AddToListboxAndScroll("Oculus App version is lower than 23, Bitrate option for Link not supported: Disabling option");
              FrmMain.fmain.ComboBox6.Enabled = false;
              FrmMain.fmain.SetToolTipText((Control) FrmMain.fmain.Label36, "Oculus App version is lower than 23, Bitrate option for Link not supported");
            }
          }
        }
        else
          Log.WriteToLog("* Not running as Administrator, cannot get Oculus path");
        if (string.Compare(FrmMain.fmain.OculusPath, (string) null, StringComparison.Ordinal) == 0)
          Log.WriteToLog("Could not get Oculus path from registry");
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Exiting GetOculusPath");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.hasWarning = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog("GetOculusPath: " + e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
      }
    }

    public static object GetOculusSoftware(string path)
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetOculusSoftware(" + path + ")");
      List<string> oculusSoftware = new List<string>();
      string[] files = Directory.GetFiles(path, "*.mini");
      int index = 0;
      while (index < files.Length)
      {
        JObject jobject = JObject.Parse(File.ReadAllText(files[index]));
        string path1 = path + "\\Software\\" + jobject.SelectToken("canonicalName").ToString() + "\\" + jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
        if (File.Exists(path1))
          oculusSoftware.Add(path1);
        checked { ++index; }
      }
      return (object) oculusSoftware;
    }
  }
}
