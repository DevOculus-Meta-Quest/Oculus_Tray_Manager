// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.CheckUpdate
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class CheckUpdate
  {
    private static bool updateFound = false;
    public static string link;
    private static WebClient wc = new WebClient();
    public static Form frmToast;
    private static bool manualCheck = false;

    public static void CheckForUpdate(bool manual)
    {
      if (CheckUpdate.updateFound)
        return;
      if (manual)
      {
        CheckUpdate.manualCheck = true;
        Log.WriteToLog("Manual update started");
      }
      FrmMain.fmain.AddToListboxAndScroll("Checking for updates");
      Log.WriteToLog("Checking for updates");
      try
      {
        if (CheckUpdate.CheckUpdateConnection())
        {
          Log.WriteToLog("Update URL seems reachable");
          WebClient webClient = new WebClient();
          Log.WriteToLog("Downloading version.txt");
          string[] strArray1 = Strings.Split(Encoding.ASCII.GetString(webClient.DownloadData(MyProject.Forms.FrmMain.Update_URL)), "\n");
          string str1 = Assembly.GetExecutingAssembly().GetName().Version.ToString();
          int num1 = 0;
          string str2 = (string) null;
          string[] strArray2 = strArray1;
          int index = 0;
          while (index < strArray2.Length)
          {
            string str3 = strArray2[index];
            if (Operators.CompareString(str3, "", false) != 0)
            {
              if (str3.StartsWith("version"))
              {
                string[] strArray3 = Strings.Split(str3, "=");
                str2 = strArray3[1].Trim();
                num1 = Conversions.ToInteger(strArray3[1].Replace(".", ""));
              }
              if (str3.StartsWith("link"))
                CheckUpdate.link = Strings.Split(str3, "=")[1].ToString().Trim();
            }
            checked { ++index; }
          }
          if (num1 > Conversions.ToInteger(str1.Replace(".", "")) & Operators.CompareString(CheckUpdate.link, "", false) != 0)
          {
            Log.WriteToLog("Update found! Version " + str2.Trim());
            FrmMain.fmain.AddToListboxAndScroll("Update found! Version " + str2.Trim());
            FrmMain.fmain.UpdateTabPage();
            FrmMain.fmain.ShowUpdateToast();
            if (CheckUpdate.manualCheck)
              FrmMain.fmain.DotNetBarTabcontrol1.SelectedIndex = 6;
            FrmMain.fmain.LabelVer.Text = "New version: " + str2;
            CheckUpdate.updateFound = true;
            Application.UseWaitCursor = false;
          }
          else
          {
            Log.WriteToLog("No update found");
            FrmMain.fmain.AddToListboxAndScroll("No update found");
            CheckUpdate.updateFound = false;
            if (manual)
            {
              int num2 = (int) Interaction.MsgBox((object) "No update found", MsgBoxStyle.Information, (object) "Check for updates");
            }
          }
        }
        else
        {
          Log.WriteToLog("Checking for updates failed: Could not reach update URL");
          FrmMain.fmain.AddToListboxAndScroll("Checking for updates failed: Could not reach update URL");
          if (manual)
          {
            int num = (int) Interaction.MsgBox((object) "Checking for updates failed: Could not reach update URL", MsgBoxStyle.Critical, (object) "Update check failed");
          }
          CheckUpdate.updateFound = false;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("CheckForUpdate: " + exception.Message);
        FrmMain.fmain.AddToListboxAndScroll(exception.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void DownloadUpdate(string url, bool install, string dir)
    {
      try
      {
        if (install)
        {
          using (Stream stream = CheckUpdate.wc.OpenRead(new Uri(url)))
          {
            Log.WriteToLog("Downloading OTTSetup.exe from " + url + " to " + Path.GetTempPath());
            using (Stream destination = (Stream) System.IO.File.Create(Path.GetTempPath() + "\\OTTSetup.exe"))
              stream.CopyTo(destination);
          }
          Log.WriteToLog("Download Complete");
          MyProject.Forms.FrmMain.LabelDownloadStatus.Text = "Download Complete!";
          MyProject.Forms.FrmMain.LabelDownloadStatus.Refresh();
          MyProject.Forms.FrmMain.Cursor = Cursors.Default;
          Process.Start(Path.GetTempPath() + "\\OTTSetup.exe");
          Application.Exit();
        }
        else
        {
          using (Stream stream = CheckUpdate.wc.OpenRead(new Uri(url)))
          {
            Log.WriteToLog("Downloading OTTSetup.exe from " + url + " to " + Path.GetTempPath());
            using (Stream destination = (Stream) System.IO.File.Create(dir + "\\OTTSetup.exe"))
              stream.CopyTo(destination);
          }
          Log.WriteToLog("Download Complete");
          MyProject.Forms.FrmMain.LabelDownloadStatus.Text = "Download Complete!";
          MyProject.Forms.FrmMain.LabelDownloadStatus.Refresh();
          MyProject.Forms.FrmMain.Cursor = Cursors.Default;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("DownloadUpdate: " + exception.Message);
        FrmMain.fmain.AddToListboxAndScroll(exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Download failed!\r\n" + exception.Message));
        ProjectData.ClearProjectError();
      }
    }

    private static bool CheckUpdateConnection()
    {
      bool flag;
      try
      {
        using (WebClient webClient = new WebClient())
        {
          webClient.OpenRead("https://www.dropbox.com/s/63qb2oswo2o3ugt");
          flag = true;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }
  }
}
