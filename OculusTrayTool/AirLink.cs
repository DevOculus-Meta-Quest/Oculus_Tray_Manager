using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class AirLink
{
	public static string asar_check = "Get-Command -ErrorAction SilentlyContinue asar";

	public static string node_check = "Get-Command -ErrorAction SilentlyContinue node";

	public static string choco_check = "Get-Command -ErrorAction SilentlyContinue chocolatey";

	public static void EnableAirLink()
	{
		string text = Convert.ToString(DateAndTime.Now).Replace("-", "").Replace("/", "")
			.Replace(":", "")
			.Replace(" ", "");
		string cmd = "Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))";
		string cmd2 = "choco install nodejs -y";
		string arguments = "/C npm install -g --engine-strict asar";
		string cmd3 = "kill -ErrorAction SilentlyContinue -name OculusClient";
		string cmd4 = "(New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js')";
		string text2 = Conversions.ToString(Packages.CheckCode(cmd4));
		if (!text2.Contains("setTimeout(function enable() {"))
		{
			Log.WriteToLinkLog("Could not download code, aborting");
			MyProject.Forms.FrmMain.AddToListboxAndScroll("Could not download code, aborting");
			return;
		}
		string cmd5 = "Add-Content \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\\output\\main.js\" (New-Object System.Net.WebClient).DownloadString('https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js')";
		MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for chocolatey");
		Log.WriteToLinkLog("Checking for chocolatey");
		if (Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(choco_check, ""), 0, TextCompare: false))
		{
			MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing chocolatey..");
			Log.WriteToLinkLog("chocolatey not installed, installing");
			RunPSCommand(cmd);
			if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(choco_check, "chocolatey"), 0, TextCompare: false))
			{
				MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey installed");
			}
			else
			{
				MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey installation failed");
				Log.WriteToLinkLog("chocolatey installation failed");
			}
		}
		else if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(choco_check, "chocolatey"), 0, TextCompare: false))
		{
			MyProject.Forms.FrmMain.AddToListboxAndScroll("chocolatey already installed");
		}
		if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(choco_check, ""), 0, TextCompare: false))
		{
			MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for nodejs");
			Log.WriteToLinkLog("Checking For nodejs");
			if (Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(node_check, ""), 0, TextCompare: false))
			{
				MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing nodejs..");
				Log.WriteToLinkLog("nodejs Not installed, installing");
				RunPSCommand(cmd2);
				if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(node_check, "nodejs"), 0, TextCompare: false))
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs installed");
				}
				else
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs installation failed");
					Log.WriteToLinkLog("nodejs installation failed");
				}
			}
			else if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(node_check, "nodejs"), 0, TextCompare: false))
			{
				MyProject.Forms.FrmMain.AddToListboxAndScroll("nodejs already installed");
			}
		}
		if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(node_check, ""), 0, TextCompare: false))
		{
			MyProject.Forms.FrmMain.AddToListboxAndScroll("Checking for asar");
			Log.WriteToLinkLog("Checking for asar");
			if (Operators.ConditionalCompareObjectEqual(Packages.CheckPackage(asar_check, ""), 0, TextCompare: false))
			{
				MyProject.Forms.FrmMain.AddToListboxAndScroll("Installing asar..");
				Log.WriteToLinkLog("asar Not installed, installing");
				RunCMDCommand(arguments);
				if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(asar_check, "asar"), 0, TextCompare: false))
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll("asar installed");
				}
				else
				{
					MyProject.Forms.FrmMain.AddToListboxAndScroll("asar installation failed");
					Log.WriteToLinkLog("asar installation failed");
				}
			}
			else if (Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(asar_check, "asar"), 0, TextCompare: false))
			{
				MyProject.Forms.FrmMain.AddToListboxAndScroll("asar already installed");
			}
		}
		if (!Operators.ConditionalCompareObjectNotEqual(Packages.CheckPackage(asar_check, ""), 0, TextCompare: false))
		{
			return;
		}
		MyProject.Forms.FrmMain.AddToListboxAndScroll("Killing OculusClient if it's running");
		Log.WriteToLinkLog("Killing OculusClient if it's running");
		RunPSCommand(cmd3);
		MyProject.Forms.FrmMain.AddToListboxAndScroll("Backing up current app.asar to app.asar." + text);
		Log.WriteToLinkLog("Backing up current app.asar to app.asar." + text);
		File.Copy(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar", MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + text);
		MyProject.Forms.FrmMain.AddToListboxAndScroll("Extracting app.asar");
		Log.WriteToLinkLog("Extracting app.asar to " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
		RunCMDCommand("/C asar extract \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar\" \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\"");
		MyProject.Forms.FrmMain.AddToListboxAndScroll("Verifying...");
		Log.WriteToLinkLog("Verifying...");
		string text3 = File.ReadAllText(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\\output\\main.js");
		if (!text3.Contains("setTimeout(function enable() {"))
		{
			MyProject.Forms.FrmMain.AddToListboxAndScroll("AirLink is not patched, continuing");
			Log.WriteToLinkLog("AirLink is not patched, continuing");
			MyProject.Forms.FrmMain.AddToListboxAndScroll("Downloading pd29's code and patching Link");
			Log.WriteToLinkLog("Downloading latest version of pd29's code from https://raw.githubusercontent.com/pd29/oculus-airlink-enabler/main/airlink.js and patching Link");
			RunPSCommand(cmd5);
			MyProject.Forms.FrmMain.AddToListboxAndScroll("Compressing app.asar");
			Log.WriteToLinkLog("Re-compressing app.asar");
			RunCMDCommand("/C asar pack \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app\" \"" + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar\"");
			if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app"))
			{
				Log.WriteToLinkLog("Removing temporary directory " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app");
				Directory.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app", recursive: true);
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
				Directory.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app", recursive: true);
			}
			if (File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + text))
			{
				Log.WriteToLinkLog("Removing backup " + MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + text);
				File.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-client\\resources\\app.asar." + text);
			}
		}
	}

	private static int RunPSCommand(string cmd)
	{
		int result = 0;
		try
		{
			using Runspace runspace = RunspaceFactory.CreateRunspace();
			runspace.Open();
			using (Pipeline pipeline = runspace.CreatePipeline())
			{
				pipeline.Commands.AddScript(cmd);
				Collection<PSObject> collection = pipeline.Invoke();
				result = collection.Count;
			}
			runspace.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MyProject.Forms.FrmMain.AddToListboxAndScroll(ex2.Message);
			object right = default(object);
			Log.WriteToLinkLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("RunPSCommand: ", right), ": "), cmd), ": "), ex2.Message), ": "), ex2.StackTrace)));
			ProjectData.ClearProjectError();
		}
		return result;
	}

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
			if (Operators.CompareString(text, "", TextCompare: false) != 0)
			{
				MyProject.Forms.FrmMain.AddToListboxAndScroll(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLinkLog("RunCMDCommand: " + arguments + " " + ex2.Message + ": " + ex2.StackTrace);
			ProjectData.ClearProjectError();
		}
	}
}
