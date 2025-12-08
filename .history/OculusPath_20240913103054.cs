// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.OculusPath
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
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
  [StandardModule]
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
        object obj = Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(OculusPath.GetExplorerUserSid()), (object) "\\SOFTWARE\\Oculus VR, LLC\\Oculus\\Libraries\\");
        if (Globals.dbg)
          Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject((object) "Looking in ", obj)));
        if (MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(obj), false) != null)
        {
          if (Globals.dbg)
            Log.WriteToLog("Key found, proceeding");
          string[] subKeyNames = MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(obj)).GetSubKeyNames();
          int index = 0;
          while (index < subKeyNames.Length)
          {
            string Right1 = subKeyNames[index];
            if (Globals.dbg)
              Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object) "Looking for 'Path' parameter in ", obj), (object) Right1)));
            if (MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(Operators.ConcatenateObject(obj, (object) Right1)), false).GetValue("Path") != null)
            {
              if (Globals.dbg)
                Log.WriteToLog("'Path' found, opening key");
              string str1 = Conversions.ToString(MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(Operators.ConcatenateObject(obj, (object) Right1)), false).GetValue("Path"));
              int startIndex = str1.LastIndexOf("}");
              string str2 = str1.Substring(startIndex).TrimStart('}');
              string Right2 = str1.Replace(str2, "") + "\\";
              ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Volume");
              try
              {
                foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                {
                  if (Operators.ConditionalCompareObjectEqual(managementObject["DeviceID"], (object) Right2, false))
                  {
                    string str3 = Conversions.ToString(Operators.ConcatenateObject(RuntimeHelpers.GetObjectValue(managementObject["DriveLetter"]), (object) str2));
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
              finally
              {
                ManagementObjectCollection.ManagementObjectEnumerator objectEnumerator;
                objectEnumerator?.Dispose();
              }
            }
            else if (Globals.dbg)
              Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object) "No 'Path' in ", obj), (object) Right1)));
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
      ManagementObjectCollection.ManagementObjectEnumerator enumerator;
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
          if (MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Oculus VR, LLC\\Oculus") != null)
          {
            MyProject.Forms.FrmMain.OculusPath = Conversions.ToString(MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Oculus VR, LLC\\Oculus", false).GetValue("Base"));
            Log.WriteToLog("Oculus path: " + MyProject.Forms.FrmMain.OculusPath);
            if (!MyProject.Forms.FrmMain.OculusPath.EndsWith("\\"))
              MyProject.Forms.FrmMain.OculusPath += "\\";
          }
          else if (MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Oculus VR, LLC\\Oculus") != null)
          {
            MyProject.Forms.FrmMain.OculusPath = Conversions.ToString(MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Oculus VR, LLC\\Oculus", true).GetValue("Base"));
            Log.WriteToLog("Oculus path: " + MyProject.Forms.FrmMain.OculusPath);
            if (!MyProject.Forms.FrmMain.OculusPath.EndsWith("\\"))
              MyProject.Forms.FrmMain.OculusPath += "\\";
          }
          MySettingsProperty.Settings.OculusPath = MyProject.Forms.FrmMain.OculusPath;
          MySettingsProperty.Settings.Save();
          if (File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-runtime\\OVRServer_x64.exe"))
          {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-runtime\\OVRServiceLauncher.exe");
            MyProject.Forms.FrmMain.OculusAppVersion = Conversions.ToString(versionInfo.FileMajorPart) + Conversions.ToString(versionInfo.FileMinorPart);
            Log.WriteToLog("Oculus App Version: " + versionInfo.FileVersion);
            if (versionInfo.FileMajorPart < 23)
            {
              Log.WriteToLog("Oculus App version is lower than 23, Bitrate option for Link not supported: Disabling option");
              FrmMain.fmain.AddToListboxAndScroll("Oculus App version is lower than 23, Bitrate option for Link not supported: Disabling option");
              FrmMain.fmain.ComboBox6.Enabled = false;
              FrmMain.fmain.SetToolTipText("Oculus App version is lower than 23, Bitrate option for Link not supported", (Control) FrmMain.fmain.Label36);
            }
          }
        }
        else
          Log.WriteToLog("* Not running as Administrator, cannot get Oculus path");
        if (Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, (string) null, false) == 0)
          Log.WriteToLog("Could not get Oculus path from registry");
        if (!Globals.dbg)
          return;
        Log.WriteToLog("Exiting GetOculusPath");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        MyProject.Forms.FrmMain.hasWarning = true;
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
