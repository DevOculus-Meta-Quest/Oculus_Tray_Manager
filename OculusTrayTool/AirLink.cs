using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x02000008 RID: 8
	[StandardModule]
	internal sealed class AirLink
	{
		// Token: 0x06000148 RID: 328 RVA: 0x000046E8 File Offset: 0x000028E8
		public static void EnableAirLink()
		{
			string text = Convert.ToString(DateAndTime.Now).Replace("-", "").Replace("/", "")
				.Replace(":", "")
				.Replace(" ", "");
			string text2 = "Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";
			string text3 = "choco install nodejs -y";
			string text4 = "/C npm install -g --engine-strict asar";
			string text5 = "kill -ErrorAction SilentlyContinue -name OculusClient";
			string text6 = "(New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js')";
			string text7 = Conversions.ToString(Packages.CheckCode(text6));
			bool flag = !text7.Contains("setTimeout(function enable() {");
			if (flag)
			{
				Log.WriteToLinkLog("Could not download code, aborting");
				MyProject.Forms.FrmMain.AddToListboxAndScroll("Could not download code, aborting");
			}
			else
			{
				string text8 = "Add-Content \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\\output\\main.js\" (New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js')";
				MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for chocolatey");
				Log.WriteToLinkLog("Checking for chocolatey");
				bool flag2 = Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(AirLink.choco_check, ""), 0, false);
				if (flag2)
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing chocolatey..");
					Log.WriteToLinkLog("chocolatey not installed, installing");
					AirLink.RunPSCommand(text2);
					bool flag3 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.choco_check, "chocolatey"), 0, false);
					if (flag3)
					{
						MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey installed");
					}
					else
					{
						MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey installation failed");
						Log.WriteToLinkLog("chocolatey installation failed");
					}
				}
				else
				{
					bool flag4 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.choco_check, "chocolatey"), 0, false);
					if (flag4)
					{
						MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey already installed");
					}
				}
				bool flag5 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.choco_check, ""), 0, false);
				if (flag5)
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for nodejs");
					Log.WriteToLinkLog("Checking For nodejs");
					bool flag6 = Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(AirLink.node_check, ""), 0, false);
					if (flag6)
					{
						MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing nodejs..");
						Log.WriteToLinkLog("nodejs Not installed, installing");
						AirLink.RunPSCommand(text3);
						bool flag7 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.node_check, "nodejs"), 0, false);
						if (flag7)
						{
							MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs installed");
						}
						else
						{
							MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs installation failed");
							Log.WriteToLinkLog("nodejs installation failed");
						}
					}
					else
					{
						bool flag8 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.node_check, "nodejs"), 0, false);
						if (flag8)
						{
							MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs already installed");
						}
					}
				}
				bool flag9 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.node_check, ""), 0, false);
				if (flag9)
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for asar");
					Log.WriteToLinkLog("Checking for asar");
					bool flag10 = Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(AirLink.asar_check, ""), 0, false);
					if (flag10)
					{
						MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing asar..");
						Log.WriteToLinkLog("asar Not installed, installing");
						AirLink.RunCMDCommand(text4);
						bool flag11 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.asar_check, "asar"), 0, false);
						if (flag11)
						{
							MyProject.Forms.FrmMain.AddToListboxAndScroll("asar installed");
						}
						else
						{
							MyProject.Forms.FrmMain.AddToListboxAndScroll("asar installation failed");
							Log.WriteToLinkLog("asar installation failed");
						}
					}
					else
					{
						bool flag12 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.asar_check, "asar"), 0, false);
						if (flag12)
						{
							MyProject.Forms.FrmMain.AddToListboxAndScroll("asar already installed");
						}
					}
				}
				bool flag13 = Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(AirLink.asar_check, ""), 0, false);
				if (flag13)
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll("Killing OculusClient if it's running");
					Log.WriteToLinkLog("Killing OculusClient if it's running");
					AirLink.RunPSCommand(text5);
					MyProject.Forms.FrmMain.AddToListboxAndScroll("Backing up current app.asar to app.asar." + text);
					Log.WriteToLinkLog("Backing up current app.asar to app.asar." + text);
					File.Copy(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar", MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + text);
					MyProject.Forms.FrmMain.AddToListboxAndScroll("Extracting app.asar");
					Log.WriteToLinkLog("Extracting app.asar to " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
					AirLink.RunCMDCommand(string.Concat(new string[]
					{
						"/C asar extract \"",
						MyProject.Forms.FrmMain.OculusPath,
						"Support\\oculus-client\\resources\\app.asar\" \"",
						MyProject.Forms.FrmMain.OculusPath,
						"Support\\oculus-client\\resources\\app\""
					}));
					MyProject.Forms.FrmMain.AddToListboxAndScroll("Verifying...");
					Log.WriteToLinkLog("Verifying...");
					string text9 = File.ReadAllText(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\\output\\main.js");
					bool flag14 = !text9.Contains("setTimeout(function enable() {");
					if (flag14)
					{
						MyProject.Forms.FrmMain.AddToListboxAndScroll("AirLink is not patched, continuing");
						Log.WriteToLinkLog("AirLink is not patched, continuing");
						MyProject.Forms.FrmMain.AddToListboxAndScroll("Downloading pd29's code and patching Link");
						Log.WriteToLinkLog("Downloading latest version of pd29's code from https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js and patching Link");
						AirLink.RunPSCommand(text8);
						MyProject.Forms.FrmMain.AddToListboxAndScroll("Compressing app.asar");
						Log.WriteToLinkLog("Re-compressing app.asar");
						AirLink.RunCMDCommand(string.Concat(new string[]
						{
							"/C asar pack \"",
							MyProject.Forms.FrmMain.OculusPath,
							"Support\\oculus-client\\resources\\app\" \"",
							MyProject.Forms.FrmMain.OculusPath,
							"Support\\oculus-client\\resources\\app.asar\""
						}));
						bool flag15 = Directory.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
						if (flag15)
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
						bool flag16 = Directory.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
						if (flag16)
						{
							Log.WriteToLinkLog("Removing temporary directory " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
							Directory.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app", true);
						}
						bool flag17 = File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + text);
						if (flag17)
						{
							Log.WriteToLinkLog("Removing backup " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + text);
							File.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + text);
						}
					}
				}
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00004EEC File Offset: 0x000030EC
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
						Collection<PSObject> collection = pipeline.Invoke();
						num = collection.Count;
					}
					runspace.Close();
				}
			}
			catch (Exception ex)
			{
				MyProject.Forms.FrmMain.AddToListboxAndScroll(ex.Message);
				object obj;
				Log.WriteToLinkLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("RunPSCommand: ", obj), ": "), cmd), ": "), ex.Message), ": "), ex.StackTrace)));
			}
			return num;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00005004 File Offset: 0x00003204
		private static void RunCMDCommand(string arguments)
		{
			try
			{
				Process process = new Process
				{
					StartInfo = new ProcessStartInfo
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
				string text = process.StandardError.ReadToEnd();
				bool flag = Operators.CompareString(text, "", false) != 0;
				if (flag)
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll(text);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLinkLog(string.Concat(new string[] { "RunCMDCommand: ", arguments, " ", ex.Message, ": ", ex.StackTrace }));
			}
		}

		// Token: 0x0400000B RID: 11
		public static string asar_check = "Get-Command -ErrorAction SilentlyContinue asar";

		// Token: 0x0400000C RID: 12
		public static string node_check = "Get-Command -ErrorAction SilentlyContinue node";

		// Token: 0x0400000D RID: 13
		public static string choco_check = "Get-Command -ErrorAction SilentlyContinue chocolatey";
	}
}
