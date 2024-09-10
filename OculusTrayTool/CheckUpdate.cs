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

namespace OculusTrayTool
{
	// Token: 0x0200000C RID: 12
	[StandardModule]
	internal sealed class CheckUpdate
	{
		// Token: 0x06000156 RID: 342 RVA: 0x000062A8 File Offset: 0x000044A8
		public static void CheckForUpdate(bool manual)
		{
			bool flag = !CheckUpdate.updateFound;
			if (flag)
			{
				if (manual)
				{
					CheckUpdate.manualCheck = true;
					Log.WriteToLog("Manual update started");
				}
				FrmMain.fmain.AddToListboxAndScroll("Checking for updates");
				Log.WriteToLog("Checking for updates");
				try
				{
					bool flag2 = CheckUpdate.CheckUpdateConnection();
					if (flag2)
					{
						Log.WriteToLog("Update URL seems reachable");
						WebClient webClient = new WebClient();
						Log.WriteToLog("Downloading version.txt");
						byte[] array = webClient.DownloadData(MyProject.Forms.FrmMain.Update_URL);
						string[] array2 = Strings.Split(Encoding.ASCII.GetString(array), "\n", -1, CompareMethod.Binary);
						string text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
						int num = 0;
						string text2 = null;
						foreach (string text3 in array2)
						{
							bool flag3 = Operators.CompareString(text3, "", false) != 0;
							if (flag3)
							{
								bool flag4 = text3.StartsWith("version");
								if (flag4)
								{
									string[] array4 = Strings.Split(text3, "=", -1, CompareMethod.Binary);
									text2 = array4[1].Trim();
									num = Conversions.ToInteger(array4[1].Replace(".", ""));
								}
								bool flag5 = text3.StartsWith("link");
								if (flag5)
								{
									string[] array5 = Strings.Split(text3, "=", -1, CompareMethod.Binary);
									CheckUpdate.link = array5[1].ToString().Trim();
								}
							}
						}
						bool flag6 = (num > Conversions.ToInteger(text.Replace(".", ""))) & (Operators.CompareString(CheckUpdate.link, "", false) != 0);
						if (flag6)
						{
							Log.WriteToLog("Update found! Version " + text2.Trim());
							FrmMain.fmain.AddToListboxAndScroll("Update found! Version " + text2.Trim());
							FrmMain.fmain.UpdateTabPage();
							FrmMain.fmain.ShowUpdateToast();
							bool flag7 = CheckUpdate.manualCheck;
							if (flag7)
							{
								FrmMain.fmain.DotNetBarTabcontrol1.SelectedIndex = 6;
							}
							FrmMain.fmain.LabelVer.Text = "New version: " + text2;
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
						CheckUpdate.updateFound = false;
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("CheckForUpdate: " + ex.Message);
					FrmMain.fmain.AddToListboxAndScroll(ex.Message);
				}
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x000065D8 File Offset: 0x000047D8
		public static void DownloadUpdate(string url, bool install, string dir)
		{
			try
			{
				if (install)
				{
					using (Stream stream = CheckUpdate.wc.OpenRead(new Uri(url)))
					{
						Log.WriteToLog("Downloading OTTSetup.exe from " + url + " to " + Path.GetTempPath());
						using (Stream stream2 = File.Create(Path.GetTempPath() + "\\OTTSetup.exe"))
						{
							stream.CopyTo(stream2);
						}
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
					using (Stream stream3 = CheckUpdate.wc.OpenRead(new Uri(url)))
					{
						Log.WriteToLog("Downloading OTTSetup.exe from " + url + " to " + Path.GetTempPath());
						using (Stream stream4 = File.Create(dir + "\\OTTSetup.exe"))
						{
							stream3.CopyTo(stream4);
						}
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
				Interaction.MsgBox("Download failed!\r\n" + ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00006850 File Offset: 0x00004A50
		private static bool CheckUpdateConnection()
		{
			bool flag;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					Stream stream = webClient.OpenRead("https://www.dropbox.com/s/63qb2oswo2o3ugt");
					flag = true;
				}
			}
			catch (Exception ex)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x0400000F RID: 15
		private static bool updateFound = false;

		// Token: 0x04000010 RID: 16
		public static string link;

		// Token: 0x04000011 RID: 17
		private static WebClient wc = new WebClient();

		// Token: 0x04000012 RID: 18
		public static Form frmToast;

		// Token: 0x04000013 RID: 19
		private static bool manualCheck = false;
	}
}
