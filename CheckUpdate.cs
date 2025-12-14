

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
          string[] strArray1 = Encoding.ASCII.GetString(webClient.DownloadData(MyProject.Forms.FrmMain.Update_URL)).Split('\n');
          string str1 = Assembly.GetExecutingAssembly().GetName().Version.ToString();
          int num1 = 0;
          string str2 = (string) null;
          string[] strArray2 = strArray1;
          int index = 0;
          while (index < strArray2.Length)
          {
            string str3 = strArray2[index];
            if (!string.IsNullOrEmpty(str3))
            {
              if (str3.StartsWith("version"))
              {
                string[] strArray3 = str3.Split('=');
                str2 = strArray3[1].Trim();
                num1 = Convert.ToInt32(strArray3[1].Replace(".", ""));
              }
              if (str3.StartsWith("link"))
                CheckUpdate.link = str3.Split('=')[1].ToString().Trim();
            }
            checked { ++index; }
          }
          if (num1 > Convert.ToInt32(str1.Replace(".", "")) & !string.IsNullOrEmpty(CheckUpdate.link))
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
              DialogResult result = MessageBox.Show("No update found", "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          }
        }
        else
        {
          Log.WriteToLog("Checking for updates failed: Could not reach update URL");
          FrmMain.fmain.AddToListboxAndScroll("Checking for updates failed: Could not reach update URL");
          if (manual)
          {
            DialogResult result = MessageBox.Show("Checking for updates failed: Could not reach update URL", "Update check failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          CheckUpdate.updateFound = false;
        }
      }
      catch (Exception ex)
      {
        Log.WriteToLog("CheckForUpdate: " + ex.Message);
        FrmMain.fmain.AddToListboxAndScroll(ex.Message);
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
        Log.WriteToLog("DownloadUpdate: " + ex.Message);
        FrmMain.fmain.AddToListboxAndScroll(ex.Message);
        MessageBox.Show("Download failed!\r\n" + ex.Message);
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
        flag = false;
      }
      return flag;
    }
  }
}
