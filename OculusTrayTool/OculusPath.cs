using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class OculusPath
{
	public static object GetOculusSoftwarePaths()
	{
		List<string> list = new List<string>();
		object result;
		try
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Entering GetOculusSoftwarePaths");
			}
			string text = "";
			object objectValue = RuntimeHelpers.GetObjectValue(GetExplorerUserSid());
			object obj = Operators.ConcatenateObject(objectValue, "\\SOFTWARE\\Oculus VR, LLC\\Oculus\\Libraries\\");
			if (Globals.dbg)
			{
				Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject("Looking in ", obj)));
			}
			if (MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(obj), writable: false) != null)
			{
				if (Globals.dbg)
				{
					Log.WriteToLog("Key found, proceeding");
				}
				string[] subKeyNames = MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(obj)).GetSubKeyNames();
				foreach (string right in subKeyNames)
				{
					if (Globals.dbg)
					{
						Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Looking for 'Path' parameter in ", obj), right)));
					}
					if (MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(Operators.ConcatenateObject(obj, right)), writable: false).GetValue("Path") != null)
					{
						if (Globals.dbg)
						{
							Log.WriteToLog("'Path' found, opening key");
						}
						string text2 = Conversions.ToString(MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(Operators.ConcatenateObject(obj, right)), writable: false).GetValue("Path"));
						int startIndex = text2.LastIndexOf("}");
						string text3 = text2.Substring(startIndex).TrimStart('}');
						string right2 = text2.Replace(text3, "") + "\\";
						ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Volume");
						foreach (ManagementObject item in managementObjectSearcher.Get())
						{
							if (Operators.ConditionalCompareObjectEqual(item["DeviceID"], right2, TextCompare: false))
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(item["DriveLetter"]);
								text = Conversions.ToString(Operators.ConcatenateObject(objectValue2, text3));
								list.Add(text);
								if (Globals.dbg)
								{
									Log.WriteToLog("Added " + text + " to Library paths");
								}
								break;
							}
						}
					}
					else if (Globals.dbg)
					{
						Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("No 'Path' in ", obj), right)));
					}
				}
			}
			else
			{
				Log.WriteToLog("Could not get Oculus Software path from registry");
				FrmMain.fmain.AddToListboxAndScroll("Could not get Oculus Software path from registry");
			}
			result = list;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox("Could not get Oculus Library paths from the registry. Add them manually on the Advanced tab and restart the application", MsgBoxStyle.Exclamation, "Oculus Tray Tool");
			FrmMain.fmain.AddToListboxAndScroll("Could not get Oculus Library path: " + ex2.Message);
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("GetOculusSoftwarePath: " + ex2.ToString() + stackTrace.ToString());
			result = list;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object GetExplorerUserSid()
	{
		ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name = 'explorer.exe'").Get();
		using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator())
		{
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				string[] array = new string[1];
				managementObject.InvokeMethod("GetOwnerSid", array);
				return array[0];
			}
		}
		return string.Empty;
	}

	public static void GetOculusPath()
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetOculusPath");
		}
		try
		{
			if (MyProject.Forms.FrmMain.isElevated)
			{
				if (MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Oculus VR, LLC\\Oculus") != null)
				{
					MyProject.Forms.FrmMain.OculusPath = Conversions.ToString(MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Oculus VR, LLC\\Oculus", writable: false).GetValue("Base"));
					Log.WriteToLog("Oculus path: " + MyProject.Forms.FrmMain.OculusPath);
					if (!MyProject.Forms.FrmMain.OculusPath.EndsWith("\\"))
					{
						MyProject.Forms.FrmMain.OculusPath = MyProject.Forms.FrmMain.OculusPath + "\\";
					}
				}
				else if (MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Oculus VR, LLC\\Oculus") != null)
				{
					MyProject.Forms.FrmMain.OculusPath = Conversions.ToString(MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Oculus VR, LLC\\Oculus", writable: true).GetValue("Base"));
					Log.WriteToLog("Oculus path: " + MyProject.Forms.FrmMain.OculusPath);
					if (!MyProject.Forms.FrmMain.OculusPath.EndsWith("\\"))
					{
						MyProject.Forms.FrmMain.OculusPath = MyProject.Forms.FrmMain.OculusPath + "\\";
					}
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
						FrmMain.fmain.SetToolTipText("Oculus App version is lower than 23, Bitrate option for Link not supported", FrmMain.fmain.Label36);
					}
				}
			}
			else
			{
				Log.WriteToLog("* Not running as Administrator, cannot get Oculus path");
			}
			if (Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, null, TextCompare: false) == 0)
			{
				Log.WriteToLog("Could not get Oculus path from registry");
			}
			if (Globals.dbg)
			{
				Log.WriteToLog("Exiting GetOculusPath");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MyProject.Forms.FrmMain.hasWarning = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog("GetOculusPath: " + ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public static object GetOculusSoftware(string path)
	{
		if (Globals.dbg)
		{
			Log.WriteToLog("Entering GetOculusSoftware(" + path + ")");
		}
		List<string> list = new List<string>();
		string[] files = Directory.GetFiles(path, "*.mini");
		foreach (string path2 in files)
		{
			string json = File.ReadAllText(path2);
			JObject jObject = JObject.Parse(json);
			string text = path + "\\Software\\" + jObject.SelectToken("canonicalName").ToString() + "\\" + jObject.SelectToken("launchFile").ToString().Replace("/", "\\");
			if (File.Exists(text))
			{
				list.Add(text);
			}
		}
		return list;
	}
}
