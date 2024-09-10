using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

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
		if (updateFound)
		{
			return;
		}
		if (manual)
		{
			manualCheck = true;
			Log.WriteToLog("Manual update started");
		}
		FrmMain.fmain.AddToListboxAndScroll("Checking for updates");
		Log.WriteToLog("Checking for updates");
		try
		{
			if (CheckUpdateConnection())
			{
				Log.WriteToLog("Update URL seems reachable");
				WebClient webClient = new WebClient();
				Log.WriteToLog("Downloading version.txt");
				byte[] bytes = webClient.DownloadData(MyProject.Forms.FrmMain.Update_URL);
				string[] array = Strings.Split(Encoding.ASCII.GetString(bytes), "\n");
				string text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
				int num = 0;
				string text2 = null;
				string[] array2 = array;
				foreach (string text3 in array2)
				{
					if (Operators.CompareString(text3, "", TextCompare: false) != 0)
					{
						if (text3.StartsWith("version"))
						{
							string[] array3 = Strings.Split(text3, "=");
							text2 = array3[1].Trim();
							num = Conversions.ToInteger(array3[1].Replace(".", ""));
						}
						if (text3.StartsWith("link"))
						{
							string[] array4 = Strings.Split(text3, "=");
							link = array4[1].ToString().Trim();
						}
					}
				}
				if ((num > Conversions.ToInteger(text.Replace(".", ""))) & (Operators.CompareString(link, "", TextCompare: false) != 0))
				{
					Log.WriteToLog("Update found! Version " + text2.Trim());
					FrmMain.fmain.AddToListboxAndScroll("Update found! Version " + text2.Trim());
					FrmMain.fmain.UpdateTabPage();
					FrmMain.fmain.ShowUpdateToast();
					if (manualCheck)
					{
						FrmMain.fmain.DotNetBarTabcontrol1.SelectedIndex = 6;
					}
					FrmMain.fmain.LabelVer.Text = "New version: " + text2;
					updateFound = true;
					Application.UseWaitCursor = false;
				}
				else
				{
					Log.WriteToLog("No update found");
					FrmMain.fmain.AddToListboxAndScroll("No update found");
					updateFound = false;
					if (manual)
					{
						Interaction.MsgBox("No update found", MsgBoxStyle.Information, "Check for updates");
					}
				}
			}
			else
			{
				Log.WriteToLog("Checking for updates failed: Could not reach update URL");
				FrmMain.fmain.AddToListboxAndScroll("Checking for updates failed: Could not reach update URL");
				if (manual)
				{
					Interaction.MsgBox("Checking for updates failed: Could not reach update URL", MsgBoxStyle.Critical, "Update check failed");
				}
				updateFound = false;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("CheckForUpdate: " + ex2.Message);
			FrmMain.fmain.AddToListboxAndScroll(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void DownloadUpdate(string url, bool install, string dir)
	{
		try
		{
			if (install)
			{
				using (Stream stream = wc.OpenRead(new Uri(url)))
				{
					Log.WriteToLog("Downloading OTTSetup.exe from " + url + " to " + Path.GetTempPath());
					using Stream destination = File.Create(Path.GetTempPath() + "\\OTTSetup.exe");
					stream.CopyTo(destination);
				}
				Log.WriteToLog("Download Complete");
				MyProject.Forms.FrmMain.LabelDownloadStatus.Text = "Download Complete!";
				MyProject.Forms.FrmMain.LabelDownloadStatus.Refresh();
				MyProject.Forms.FrmMain.Cursor = Cursors.Default;
				Process.Start(Path.GetTempPath() + "\\OTTSetup.exe");
				Application.Exit();
				return;
			}
			using (Stream stream2 = wc.OpenRead(new Uri(url)))
			{
				Log.WriteToLog("Downloading OTTSetup.exe from " + url + " to " + Path.GetTempPath());
				using Stream destination2 = File.Create(dir + "\\OTTSetup.exe");
				stream2.CopyTo(destination2);
			}
			Log.WriteToLog("Download Complete");
			MyProject.Forms.FrmMain.LabelDownloadStatus.Text = "Download Complete!";
			MyProject.Forms.FrmMain.LabelDownloadStatus.Refresh();
			MyProject.Forms.FrmMain.Cursor = Cursors.Default;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("DownloadUpdate: " + ex2.Message);
			FrmMain.fmain.AddToListboxAndScroll(ex2.Message);
			Interaction.MsgBox("Download failed!\r\n" + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private static bool CheckUpdateConnection()
	{
		bool result;
		try
		{
			using WebClient webClient = new WebClient();
			Stream stream = webClient.OpenRead("https://www.dropbox.com/s/63qb2oswo2o3ugt");
			result = true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
