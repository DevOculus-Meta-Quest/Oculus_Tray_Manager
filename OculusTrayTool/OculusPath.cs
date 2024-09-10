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

namespace OculusTrayTool
{
	// Token: 0x0200003E RID: 62
	[StandardModule]
	internal sealed class OculusPath
	{
		// Token: 0x0600053B RID: 1339 RVA: 0x0002867C File Offset: 0x0002687C
		public static object GetOculusSoftwarePaths()
		{
			List<string> list = new List<string>();
			object obj2;
			try
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Entering GetOculusSoftwarePaths");
				}
				object objectValue = RuntimeHelpers.GetObjectValue(OculusPath.GetExplorerUserSid());
				object obj = Operators.ConcatenateObject(objectValue, "\\SOFTWARE\\Oculus VR, LLC\\Oculus\\Libraries\\");
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject("Looking in ", obj)));
				}
				bool flag = MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(obj), false) != null;
				if (flag)
				{
					bool dbg3 = Globals.dbg;
					if (dbg3)
					{
						Log.WriteToLog("Key found, proceeding");
					}
					foreach (string text in MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(obj)).GetSubKeyNames())
					{
						bool dbg4 = Globals.dbg;
						if (dbg4)
						{
							Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("Looking for 'Path' parameter in ", obj), text)));
						}
						bool flag2 = MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(Operators.ConcatenateObject(obj, text)), false).GetValue("Path") != null;
						if (flag2)
						{
							bool dbg5 = Globals.dbg;
							if (dbg5)
							{
								Log.WriteToLog("'Path' found, opening key");
							}
							string text2 = Conversions.ToString(MyProject.Computer.Registry.Users.OpenSubKey(Conversions.ToString(Operators.ConcatenateObject(obj, text)), false).GetValue("Path"));
							int num = text2.LastIndexOf("}");
							string text3 = text2.Substring(num).TrimStart(new char[] { '}' });
							string text4 = text2.Replace(text3, "") + "\\";
							ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Volume");
							try
							{
								foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
								{
									ManagementObject managementObject = (ManagementObject)managementBaseObject;
									bool flag3 = Operators.ConditionalCompareObjectEqual(managementObject["DeviceID"], text4, false);
									if (flag3)
									{
										object objectValue2 = RuntimeHelpers.GetObjectValue(managementObject["DriveLetter"]);
										string text5 = Conversions.ToString(Operators.ConcatenateObject(objectValue2, text3));
										list.Add(text5);
										bool dbg6 = Globals.dbg;
										if (dbg6)
										{
											Log.WriteToLog("Added " + text5 + " to Library paths");
										}
										break;
									}
								}
							}
							finally
							{
								ManagementObjectCollection.ManagementObjectEnumerator enumerator;
								if (enumerator != null)
								{
									((IDisposable)enumerator).Dispose();
								}
							}
						}
						else
						{
							bool dbg7 = Globals.dbg;
							if (dbg7)
							{
								Log.WriteToLog(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("No 'Path' in ", obj), text)));
							}
						}
					}
				}
				else
				{
					Log.WriteToLog("Could not get Oculus Software path from registry");
					FrmMain.fmain.AddToListboxAndScroll("Could not get Oculus Software path from registry");
				}
				obj2 = list;
			}
			catch (Exception ex)
			{
				Interaction.MsgBox("Could not get Oculus Library paths from the registry. Add them manually on the Advanced tab and restart the application", MsgBoxStyle.Exclamation, "Oculus Tray Tool");
				FrmMain.fmain.AddToListboxAndScroll("Could not get Oculus Library path: " + ex.Message);
				MyProject.Forms.FrmMain.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("GetOculusSoftwarePath: " + ex.ToString() + stackTrace.ToString());
				obj2 = list;
			}
			return obj2;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00028A10 File Offset: 0x00026C10
		public static object GetExplorerUserSid()
		{
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name = 'explorer.exe'").Get();
			try
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator();
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject = (ManagementObject)enumerator.Current;
					string[] array = new string[1];
					managementObject.InvokeMethod("GetOwnerSid", array);
					return array[0];
				}
			}
			finally
			{
				ManagementObjectCollection.ManagementObjectEnumerator enumerator;
				if (enumerator != null)
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			return string.Empty;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00028A94 File Offset: 0x00026C94
		public static void GetOculusPath()
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetOculusPath");
			}
			try
			{
				bool isElevated = MyProject.Forms.FrmMain.isElevated;
				if (isElevated)
				{
					bool flag = MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Oculus VR, LLC\\Oculus") != null;
					if (flag)
					{
						MyProject.Forms.FrmMain.OculusPath = Conversions.ToString(MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Oculus VR, LLC\\Oculus", false).GetValue("Base"));
						Log.WriteToLog("Oculus path: " + MyProject.Forms.FrmMain.OculusPath);
						bool flag2 = !MyProject.Forms.FrmMain.OculusPath.EndsWith("\\");
						if (flag2)
						{
							MyProject.Forms.FrmMain.OculusPath = MyProject.Forms.FrmMain.OculusPath + "\\";
						}
					}
					else
					{
						bool flag3 = MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Oculus VR, LLC\\Oculus") != null;
						if (flag3)
						{
							MyProject.Forms.FrmMain.OculusPath = Conversions.ToString(MyProject.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Oculus VR, LLC\\Oculus", true).GetValue("Base"));
							Log.WriteToLog("Oculus path: " + MyProject.Forms.FrmMain.OculusPath);
							bool flag4 = !MyProject.Forms.FrmMain.OculusPath.EndsWith("\\");
							if (flag4)
							{
								MyProject.Forms.FrmMain.OculusPath = MyProject.Forms.FrmMain.OculusPath + "\\";
							}
						}
					}
					MySettingsProperty.Settings.OculusPath = MyProject.Forms.FrmMain.OculusPath;
					MySettingsProperty.Settings.Save();
					bool flag5 = File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-runtime\\OVRServer_x64.exe");
					if (flag5)
					{
						FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-runtime\\OVRServiceLauncher.exe");
						MyProject.Forms.FrmMain.OculusAppVersion = Conversions.ToString(versionInfo.FileMajorPart) + Conversions.ToString(versionInfo.FileMinorPart);
						Log.WriteToLog("Oculus App Version: " + versionInfo.FileVersion);
						bool flag6 = versionInfo.FileMajorPart < 23;
						if (flag6)
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
				bool flag7 = Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, null, false) == 0;
				if (flag7)
				{
					Log.WriteToLog("Could not get Oculus path from registry");
				}
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToLog("Exiting GetOculusPath");
				}
			}
			catch (Exception ex)
			{
				MyProject.Forms.FrmMain.hasWarning = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog("GetOculusPath: " + ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00028E24 File Offset: 0x00027024
		public static object GetOculusSoftware(string path)
		{
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToLog("Entering GetOculusSoftware(" + path + ")");
			}
			List<string> list = new List<string>();
			foreach (string text in Directory.GetFiles(path, "*.mini"))
			{
				string text2 = File.ReadAllText(text);
				JObject jobject = JObject.Parse(text2);
				string text3 = string.Concat(new string[]
				{
					path,
					"\\Software\\",
					jobject.SelectToken("canonicalName").ToString(),
					"\\",
					jobject.SelectToken("launchFile").ToString().Replace("/", "\\")
				});
				bool flag = File.Exists(text3);
				if (flag)
				{
					list.Add(text3);
				}
			}
			return list;
		}
	}
}
