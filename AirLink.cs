// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.AirLink
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Diagnostics;
using System.IO;
using System.Management.Automation.Runspaces;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class AirLink
  {
    public static string asar_check = "Get-Command -ErrorAction SilentlyContinue asar";
    public static string node_check = "Get-Command -ErrorAction SilentlyContinue node";
    public static string choco_check = "Get-Command -ErrorAction SilentlyContinue chocolatey";

    public static void EnableAirLink()
    {
      string str = Convert.ToString(DateAndTime.Now).Replace("-", "").Replace("/", "").Replace(":", "").Replace(" ", "");
      string cmd1 = "Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";
      string cmd2 = "choco install nodejs -y";
      string arguments = "/C npm install -g --engine-strict asar";
      string cmd3 = "kill -ErrorAction SilentlyContinue -name OculusClient";
      if (!Conversions.ToString(Packages.CheckCode("(New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js')")).Contains("setTimeout(function enable() {"))
      {
        Log.WriteToLinkLog("Could not download code, aborting");
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Could not download code, aborting");
      }
      else
      {
        string cmd4 = "Add-Content \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\\output\\main.js\" (New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js')";
        MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for chocolatey");
        Log.WriteToLinkLog("Checking for chocolatey");
        if (Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(AirLink.choco_check, ""), (object) 0, false))
        {
          MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing chocolatey..");
          Log.WriteToLinkLog("chocolatey not installed, installing");
          AirLink.RunPSCommand(cmd1);
          if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.choco_check, "chocolatey"), (object) 0, false))
          {
            MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey installed");
          }
          else
          {
            MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey installation failed");
            Log.WriteToLinkLog("chocolatey installation failed");
          }
        }
        else if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.choco_check, "chocolatey"), (object) 0, false))
          MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey already installed");
        if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.choco_check, ""), (object) 0, false))
        {
          MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for nodejs");
          Log.WriteToLinkLog("Checking For nodejs");
          if (Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(AirLink.node_check, ""), (object) 0, false))
          {
            MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing nodejs..");
            Log.WriteToLinkLog("nodejs Not installed, installing");
            AirLink.RunPSCommand(cmd2);
            if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.node_check, "nodejs"), (object) 0, false))
            {
              MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs installed");
            }
            else
            {
              MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs installation failed");
              Log.WriteToLinkLog("nodejs installation failed");
            }
          }
          else if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.node_check, "nodejs"), (object) 0, false))
            MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs already installed");
        }
        if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.node_check, ""), (object) 0, false))
        {
          MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for asar");
          Log.WriteToLinkLog("Checking for asar");
          if (Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(AirLink.asar_check, ""), (object) 0, false))
          {
            MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing asar..");
            Log.WriteToLinkLog("asar Not installed, installing");
            AirLink.RunCMDCommand(arguments);
            if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.asar_check, "asar"), (object) 0, false))
            {
              MyProject.Forms.FrmMain.AddToListboxAndScroll("asar installed");
            }
            else
            {
              MyProject.Forms.FrmMain.AddToListboxAndScroll("asar installation failed");
              Log.WriteToLinkLog("asar installation failed");
            }
          }
          else if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.asar_check, "asar"), (object) 0, false))
            MyProject.Forms.FrmMain.AddToListboxAndScroll("asar already installed");
        }
        if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.asar_check, ""), (object) 0, false))
        {
          MyProject.Forms.FrmMain.AddToListboxAndScroll("Killing OculusClient if it's running");
          Log.WriteToLinkLog("Killing OculusClient if it's running");
          AirLink.RunPSCommand(cmd3);
          MyProject.Forms.FrmMain.AddToListboxAndScroll("Backing up current app.asar to app.asar." + str);
          Log.WriteToLinkLog("Backing up current app.asar to app.asar." + str);
          File.Copy(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar", MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + str);
          MyProject.Forms.FrmMain.AddToListboxAndScroll("Extracting app.asar");
          Log.WriteToLinkLog("Extracting app.asar to " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
          AirLink.RunCMDCommand("/C asar extract \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar\" \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\"");
          MyProject.Forms.FrmMain.AddToListboxAndScroll("Verifying...");
          Log.WriteToLinkLog("Verifying...");
          if (!File.ReadAllText(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\\output\\main.js").Contains("setTimeout(function enable() {"))
          {
            MyProject.Forms.FrmMain.AddToListboxAndScroll("AirLink is not patched, continuing");
            Log.WriteToLinkLog("AirLink is not patched, continuing");
            MyProject.Forms.FrmMain.AddToListboxAndScroll("Downloading pd29's code and patching Link");
            Log.WriteToLinkLog("Downloading latest version of pd29's code from https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js and patching Link");
            AirLink.RunPSCommand(cmd4);
            MyProject.Forms.FrmMain.AddToListboxAndScroll("Compressing app.asar");
            Log.WriteToLinkLog("Re-compressing app.asar");
            AirLink.RunCMDCommand("/C asar pack \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\" \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar\"");
            if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app"))
            {
              Log.WriteToLinkLog("Removing temporary directory " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
              Directory.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app", true);
            }
            MyProject.Forms.FrmMain.AddToListboxAndScroll("AirLink is patched!");
            Log.WriteToLinkLog("AirLink is patched!");
          }
          else
          {
            MyProject.Forms.FrmMain.AddToListboxAndScroll("AirLink is already patched, aborting");
            Log.WriteToLinkLog("AirLink is already patched, aborting");
            if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app"))
            {
              Log.WriteToLinkLog("Removing temporary directory " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
              Directory.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app", true);
            }
            if (!File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + str))
              return;
            Log.WriteToLinkLog("Removing backup " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + str);
            File.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + str);
          }
        }
      }
    }

    private static int RunPSCommand(string cmd)
    {
      int num = 0;
      try
      {
        using (Runspace runspace = RunspaceFactory.CreateRunspace())
        {
          runspace.Open();
          using (Pipeline pipeline = runspace.CreatePipeline())
          {
            pipeline.Commands.AddScript(cmd);
            num = pipeline.Invoke().Count;
          }
          runspace.Close();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        MyProject.Forms.FrmMain.AddToListboxAndScroll(exception.Message);
        object Right;
        Log.WriteToLinkLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object) "RunPSCommand: ", Right), (object) ": "), (object) cmd), (object) ": "), (object) exception.Message), (object) ": "), (object) exception.StackTrace)));
        ProjectData.ClearProjectError();
      }
      return num;
    }

    private static void RunCMDCommand(string arguments)
    {
      try
      {
        Process process = new Process()
        {
          StartInfo = new ProcessStartInfo()
          {
            FileName = "cmd.exe",
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardError = true,
            CreateNoWindow = true
          }
        };
        process.Start();
        process.WaitForExit();
        string end = process.StandardError.ReadToEnd();
        if (Operators.CompareString(end, "", false) == 0)
          return;
        MyProject.Forms.FrmMain.AddToListboxAndScroll(end);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLinkLog("RunCMDCommand: " + arguments + " " + exception.Message + ": " + exception.StackTrace);
        ProjectData.ClearProjectError();
      }
    }
  }
}
