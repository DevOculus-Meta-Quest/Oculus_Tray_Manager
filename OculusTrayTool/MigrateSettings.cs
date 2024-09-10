using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class MigrateSettings
{
	public static Dictionary<string, string> oldProfiles = new Dictionary<string, string>();

	public static void MigrateConfig()
	{
		try
		{
			Log.WriteToMigrateLog("Migrating configuration");
			Log.WriteToLog("Migrating configuration");
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(Application.StartupPath + "\\config.xml");
			XmlNode xmlNode = xmlDocument.SelectSingleNode("/Config");
			if (!Information.IsNothing(xmlNode["StartMinimized"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartMinimized");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartMinimized = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "True", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartMinimized = true;
				}
				else
				{
					MySettingsProperty.Settings.StartMinimized = false;
				}
			}
			if (!Information.IsNothing(xmlNode["StartHomeDelay"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartHomeDelay");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartHomeDelay = 3;
				}
				else
				{
					MySettingsProperty.Settings.StartHomeDelay = Conversions.ToInteger(xmlNode2.InnerText);
				}
			}
			if (!Information.IsNothing(xmlNode["UseVoiceCommands"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/UseVoiceCommands");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.UseVoiceCommands = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "True", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.UseVoiceCommands = true;
				}
				else
				{
					MySettingsProperty.Settings.UseVoiceCommands = false;
				}
			}
			if (!Information.IsNothing(xmlNode["DisableFrescoPower"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/DisableFrescoPower");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.DisableFrescoPower = false;
				}
				else
				{
					if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
					{
						MySettingsProperty.Settings.DisableFrescoPower = false;
					}
					if (Operators.CompareString(xmlNode2.InnerText, "True", TextCompare: false) == 0)
					{
						MySettingsProperty.Settings.DisableFrescoPower = true;
					}
				}
			}
			if (!Information.IsNothing(xmlNode["LibraryPath"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/LibraryPath");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) != 0 && Directory.Exists(xmlNode2.InnerText.TrimEnd('\\') + "\\Manifests"))
				{
					MySettingsProperty.Settings.LibraryPath = xmlNode2.InnerText;
				}
			}
			if (!Information.IsNothing(xmlNode["PPDPStartup"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/PPDPStartup");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.PPDPStartup = "0";
				}
				else
				{
					MySettingsProperty.Settings.PPDPStartup = xmlNode2.InnerText;
				}
			}
			if (!Information.IsNothing(xmlNode["PowerPlan"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/PowerPlan");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) != 0)
				{
					MySettingsProperty.Settings.PowerPlanStart = xmlNode2.InnerText;
				}
			}
			if (!Information.IsNothing(xmlNode["SpoofCPU"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/SpoofCPU");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) != 0)
				{
					if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
					{
						MySettingsProperty.Settings.SpoofCPU = false;
					}
					if (Operators.CompareString(xmlNode2.InnerText, "True", TextCompare: false) == 0)
					{
						MySettingsProperty.Settings.SpoofCPU = true;
					}
				}
			}
			if (!Information.IsNothing(xmlNode["StopOVR"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StopOVR");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StopOVR = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StopOVR = false;
				}
				else
				{
					MySettingsProperty.Settings.StopOVR = true;
				}
			}
			if (!Information.IsNothing(xmlNode["StartHomeOnServiceStart"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartHomeOnServiceStart");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartHomeOnServiceStart = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartHomeOnServiceStart = false;
				}
				else
				{
					MySettingsProperty.Settings.StartHomeOnServiceStart = true;
				}
			}
			if (!Information.IsNothing(xmlNode["OculusPath"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/OculusPath");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) != 0)
				{
					if (Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, "", TextCompare: false) == 0)
					{
						MySettingsProperty.Settings.OculusPath = xmlNode2.InnerText;
					}
				}
				else if (Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, "", TextCompare: false) != 0)
				{
					MySettingsProperty.Settings.OculusPath = MyProject.Forms.FrmMain.OculusPath;
				}
			}
			if (!Information.IsNothing(xmlNode["StartOVR"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartOVR");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartOVR = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartOVR = false;
				}
				else
				{
					MySettingsProperty.Settings.StartOVR = true;
				}
			}
			if (!Information.IsNothing(xmlNode["OVRServerPriority"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/OVRServerPriority");
				if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.OVRServerPriority = false;
				}
				else
				{
					MySettingsProperty.Settings.OVRServerPriority = true;
				}
			}
			if (!Information.IsNothing(xmlNode["StartHomeOnToolStart"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartHomeOnToolStart");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartHomeOnToolStart = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.StartHomeOnToolStart = false;
				}
				else
				{
					MySettingsProperty.Settings.StartHomeOnToolStart = true;
				}
			}
			if (!Information.IsNothing(xmlNode["CloseHomeOnExit"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/CloseHomeOnExit");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.CloseHomeOnExit = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.CloseHomeOnExit = false;
				}
				else
				{
					MySettingsProperty.Settings.CloseHomeOnExit = true;
				}
			}
			if (!Information.IsNothing(xmlNode["HideAltTab"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/HideAltTab");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.HideAltTab = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.HideAltTab = false;
				}
				else
				{
					MySettingsProperty.Settings.HideAltTab = true;
				}
			}
			if (!Information.IsNothing(xmlNode["DefaultAudio"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/DefaultAudio");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.DefaultAudio = "";
				}
				else
				{
					MySettingsProperty.Settings.DefaultAudio = xmlNode2.InnerText;
				}
			}
			if (!Information.IsNothing(xmlNode["DefaultMic"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/DefaultMic");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.DefaultMic = "";
				}
				else
				{
					MySettingsProperty.Settings.DefaultMic = xmlNode2.InnerText;
				}
			}
			if (!Information.IsNothing(xmlNode["SetRiftAsDefault"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/SetRiftAsDefault");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetRiftAsDefault = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetRiftAsDefault = false;
				}
				else
				{
					MySettingsProperty.Settings.SetRiftAsDefault = true;
				}
			}
			if (!Information.IsNothing(xmlNode["SetRiftAudioDefault"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/SetRiftAudioDefault");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetRiftAudioDefault = 0;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetRiftAudioDefault = 0;
				}
				else
				{
					MySettingsProperty.Settings.SetRiftAudioDefault = -1;
				}
			}
			if (!Information.IsNothing(xmlNode["SetRiftMicDefault"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/SetRiftMicDefault");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetRiftMicDefault = 0;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.SetRiftMicDefault = 0;
				}
				else
				{
					MySettingsProperty.Settings.SetRiftMicDefault = -1;
				}
			}
			if (!Information.IsNothing(xmlNode["UseLocalDebugTool"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/UseLocalDebugTool");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.UseLocalDebugTool = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.UseLocalDebugTool = false;
				}
				else
				{
					MySettingsProperty.Settings.UseLocalDebugTool = true;
				}
			}
			if (!Information.IsNothing(xmlNode["UseHotKeys"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/UseHotKeys");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.UseHotKeys = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.UseHotKeys = false;
				}
				else
				{
					MySettingsProperty.Settings.UseHotKeys = true;
				}
			}
			if (!Information.IsNothing(xmlNode["ASW"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/ASW");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.ASW = 0;
				}
				else
				{
					MySettingsProperty.Settings.ASW = Conversions.ToInteger(xmlNode2.InnerText);
				}
			}
			if (!Information.IsNothing(xmlNode["CloseOnX"]))
			{
				XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/CloseOnX");
				if (Operators.CompareString(xmlNode2.InnerText, "", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.CloseOnX = false;
				}
				else if (Operators.CompareString(xmlNode2.InnerText, "False", TextCompare: false) == 0)
				{
					MySettingsProperty.Settings.CloseOnX = false;
				}
				else
				{
					MySettingsProperty.Settings.CloseOnX = true;
				}
			}
			xmlDocument.Save(Application.StartupPath + "\\config.xml");
			MySettingsProperty.Settings.Save();
			Log.WriteToLog("Settings migration complete!");
			Log.WriteToMigrateLog("Migration complete! App.config settings below");
			MyProject.Forms.FrmMain.PrintSettings(migrate: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			FrmMain.fmain.AddToListboxAndScroll("Error migrating configurarion parameters: " + ex2.Message);
			MyProject.Forms.FrmMain.hasError = true;
			StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
			Log.WriteToLog(ex2.ToString() + stackTrace.ToString());
			Log.WriteToMigrateLog(ex2.ToString() + stackTrace.ToString());
			ProjectData.ClearProjectError();
		}
	}

	public static void GetOldProfiles()
	{
		checked
		{
			try
			{
				if (Globals.dbg)
				{
					Log.WriteToMigrateLog("Entering GetOldProfiles");
				}
				MyProject.Forms.FrmMain.profileList.Clear();
				MyProject.Forms.FrmMain.profileNames.Clear();
				MyProject.Forms.FrmMain.profileASWList.Clear();
				MyProject.Forms.FrmMain.profileDisplayNames.Clear();
				MyProject.Forms.FrmMain.profilePriorityList.Clear();
				bool flag = false;
				GetConfig.numprofiles = 0;
				Log.WriteToMigrateLog("Getting old profiles");
				Log.WriteToLog("Getting old profiles");
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Application.StartupPath + "\\config.xml");
				XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Config/Profiles");
				foreach (XmlElement item in xmlNodeList)
				{
					foreach (XmlNode childNode in item.ChildNodes)
					{
						GetConfig.numprofiles++;
						XmlNode xmlNode2 = childNode.SelectSingleNode("name");
						XmlNode xmlNode3 = childNode.SelectSingleNode("PPDP");
						XmlNode xmlNode4 = childNode.SelectSingleNode("ASW");
						XmlNode xmlNode5 = childNode.SelectSingleNode("Priority");
						XmlNode xmlNode6 = childNode.SelectSingleNode("displayname");
						oldProfiles.Add(xmlNode2.InnerText + ".exe", xmlNode3.InnerText + "," + xmlNode4.InnerText + "," + xmlNode5.InnerText);
						Log.WriteToMigrateLog("Found profile: " + xmlNode2.InnerText + ".exe," + xmlNode3.InnerText + "," + xmlNode4.InnerText + "," + xmlNode5.InnerText);
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				FrmMain.fmain.AddToListboxAndScroll("Error: GetOldProfiles: " + ex2.Message);
				MyProject.Forms.FrmMain.hasError = true;
				StackTrace stackTrace = new StackTrace(ex2, fNeedFileInfo: true);
				Log.WriteToLog("GetOldProfiles: " + ex2.ToString() + stackTrace.ToString());
				Log.WriteToMigrateLog("GetOldProfiles: " + ex2.ToString() + stackTrace.ToString());
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
		}
	}

	public static void MigrateThirdPartyProfiles(string p)
	{
		try
		{
			Log.WriteToMigrateLog("Migrating third-party profiles");
			string[] files = Directory.GetFiles(p, "*_assets.json");
			string fileName = default(string);
			string text4 = default(string);
			string text5 = default(string);
			foreach (string path in files)
			{
				string json = File.ReadAllText(path);
				JObject jObject = JObject.Parse(json);
				string text = "";
				text = jObject.SelectToken("appId").ToString();
				if (Operators.CompareString(text, "", TextCompare: false) != 0)
				{
					continue;
				}
				string text2 = jObject.SelectToken("canonicalName").ToString();
				string text3 = p + "\\" + text2.Replace("_assets", "") + ".json";
				string json2 = File.ReadAllText(text3);
				JObject jObject2 = JObject.Parse(json2);
				List<JToken> list = jObject2.Children().ToList();
				if (Globals.dbg)
				{
					Log.WriteToMigrateLog(" - > " + text3);
				}
				foreach (JProperty item in list)
				{
					item.CreateReader();
					string name = item.Name;
					if (Operators.CompareString(name, "displayName", TextCompare: false) != 0)
					{
						if (Operators.CompareString(name, "launchFile", TextCompare: false) == 0)
						{
							fileName = Path.GetFileName(item.Value.ToString().Replace("\\\\", "\\"));
							text4 = item.Value.ToString().Replace("\\\\", "\\");
							if (Globals.dbg)
							{
								Log.WriteToMigrateLog("    LaunchFile is '" + fileName + "'");
							}
							if (Globals.dbg)
							{
								Log.WriteToMigrateLog("    completePath is '" + text4 + "'");
							}
							break;
						}
					}
					else
					{
						text5 = item.Value.ToString();
						if (Globals.dbg)
						{
							Log.WriteToMigrateLog("    DisplayName is '" + text5 + "'");
						}
					}
				}
				if (text5.ToLower().EndsWith(".exe"))
				{
					text5 = Path.GetFileNameWithoutExtension(fileName);
				}
				if (Globals.dbg)
				{
					Log.WriteToMigrateLog("Looking for match: " + Path.GetFileName(fileName));
				}
				string value = "";
				oldProfiles.TryGetValue(Path.GetFileName(fileName), out value);
				if (Operators.CompareString(value, "", TextCompare: false) != 0)
				{
					string[] array = Strings.Split(value, ",");
					string ppdp = array[0];
					string asw = array[1];
					string priority = array[2];
					OTTDB.AddProfile(text5, asw, ppdp, priority, fileName, text4, "WMI", "5", "5", "0", "1", "", "0.00 0.00", "False", "0", "Yes");
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("MigrateThirdPartyApps: " + ex2.Message);
			Log.WriteToMigrateLog("MigrateThirdPartyApps: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void MigrateHomeProfiles(string p)
	{
		Log.WriteToMigrateLog("Migrating Oculus Native profiles");
		SQLiteConnection sQLiteConnection = new SQLiteConnection();
		if (Globals.dbg)
		{
			Log.WriteToMigrateLog("Looking for Oculus database");
		}
		if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite"))
		{
			return;
		}
		if (Globals.dbg)
		{
			Log.WriteToMigrateLog("Database found, making a copy");
		}
		try
		{
			File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", overwrite: true);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToMigrateLog("Failed to create database copy: " + ex2.Message);
			Interaction.MsgBox("Failed to create database copy: " + ex2.Message, MsgBoxStyle.Critical, "Error copying database");
			FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + ex2.Message);
			MyProject.Forms.FrmMain.hasError = true;
			ProjectData.ClearProjectError();
			return;
		}
		if (Globals.dbg)
		{
			Log.WriteToMigrateLog("Opening database copy");
		}
		try
		{
			if (sQLiteConnection.State == ConnectionState.Closed)
			{
				sQLiteConnection = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
				sQLiteConnection.Open();
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			Log.WriteToLog("Failed to open database copy: " + ex4.Message);
			Log.WriteToMigrateLog("Failed to open database copy: " + ex4.Message);
			Interaction.MsgBox("Failed to open database copy: " + ex4.Message, MsgBoxStyle.Critical, "Error opening database");
			FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + ex4.Message);
			MyProject.Forms.FrmMain.hasError = true;
			ProjectData.ClearProjectError();
			return;
		}
		if (Globals.dbg)
		{
			Log.WriteToMigrateLog("Parsing manifests");
		}
		SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
		try
		{
			string[] files = Directory.GetFiles(p + "\\Manifests", "*.mini");
			foreach (string text in files)
			{
				if (Globals.dbg)
				{
					Log.WriteToMigrateLog(" -> " + text);
				}
				string json = File.ReadAllText(text);
				JObject jObject = JObject.Parse(json);
				string text2 = "";
				text2 = jObject.SelectToken("appId").ToString();
				if (Globals.dbg)
				{
					Log.WriteToMigrateLog("    appId is '" + text2 + "'");
				}
				if (Operators.CompareString(text2, "", TextCompare: false) != 0)
				{
					string text3 = jObject.SelectToken("canonicalName").ToString();
					if (Globals.dbg)
					{
						Log.WriteToMigrateLog("    canonicalName is '" + text3 + "'");
					}
					string text4 = jObject.SelectToken("launchFile").ToString().Replace("/", "\\");
					if (Globals.dbg)
					{
						Log.WriteToMigrateLog("    launchfile is '" + text4 + "'");
					}
					string text5 = p + "\\Software\\" + text3.Replace("/", "\\").Replace("\\\\", "\\") + "\\" + text4.Replace("/", "\\").Replace("\\\\", "\\");
					if (Globals.dbg)
					{
						Log.WriteToMigrateLog("    completePath is '" + text5 + "'");
					}
					StringBuilder stringBuilder = new StringBuilder();
					try
					{
						sQLiteCommand.CommandText = "select value from Objects WHERE hashkey='" + text2 + "' AND typename='Application'";
						using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
						while (sQLiteDataReader.Read())
						{
							byte[] bytes = GetBytes(sQLiteDataReader);
							stringBuilder.Append(Encoding.Default.GetString(bytes));
						}
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						Log.WriteToLog("Failed to read database entry for appId '" + text2 + "': " + ex6.Message);
						Log.WriteToMigrateLog("Failed to read database entry for appId '" + text2 + "': " + ex6.Message);
						Interaction.MsgBox("Failed to read database entry for appId '" + text2 + "': " + ex6.Message, MsgBoxStyle.Critical, "Error reading database");
						FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + text2 + "': " + ex6.Message);
						MyProject.Forms.FrmMain.hasError = true;
						ProjectData.ClearProjectError();
						return;
					}
					string text6 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
					string text7 = "display:name::";
					string value = ":display:short:description";
					int num = text6.IndexOf(text7);
					int num2 = text6.IndexOf(value);
					if (num > -1 && num2 > -1)
					{
						string text8 = checked(Strings.Mid(text6, num + text7.Length + 1, num2 - num - text7.Length)).Replace(":", " ").TrimEnd('r').TrimEnd('s')
							.TrimEnd(':')
							.TrimEnd(' ');
						if (Globals.dbg)
						{
							Log.WriteToMigrateLog("    Appname is '" + text8 + "'");
						}
						if (Globals.dbg)
						{
							Log.WriteToMigrateLog("Looking for match: " + Path.GetFileName(text4));
						}
						string value2 = "";
						oldProfiles.TryGetValue(Path.GetFileName(text4), out value2);
						if (Operators.CompareString(value2, "", TextCompare: false) != 0)
						{
							string[] array = Strings.Split(value2, ",");
							string ppdp = array[0];
							string asw = array[1];
							string priority = array[2];
							OTTDB.AddProfile(text8, asw, ppdp, priority, text4, text5, "WMI", "5", "5", "0", "1", "", "0.00 0.00", "False", "0", "Yes");
						}
					}
				}
				else
				{
					Log.WriteToMigrateLog("* Found NO match for appId '" + text2 + "'. Manifest file: " + text);
				}
			}
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			Log.WriteToLog("Failed to open manifest file: " + ex8.Message);
			Log.WriteToMigrateLog("Failed to open manifest file: " + ex8.Message);
			Interaction.MsgBox("Failed to open manifest file: " + ex8.Message, MsgBoxStyle.Critical, "Error reading mainfest");
			FrmMain.fmain.AddToListboxAndScroll("Failed to open manifest file: " + ex8.Message);
			MyProject.Forms.FrmMain.hasError = true;
			sQLiteCommand.Dispose();
			sQLiteConnection.Close();
			ProjectData.ClearProjectError();
			return;
		}
		sQLiteCommand.Dispose();
		sQLiteConnection.Close();
		if (Globals.dbg)
		{
			Log.WriteToMigrateLog("Connection closed");
		}
		File.Delete(Application.StartupPath + "\\data.sqlite");
		if (Globals.dbg)
		{
			Log.WriteToMigrateLog("Database copy deleted");
		}
	}

	private static string ByteArrayToString(byte[] ba)
	{
		string text = BitConverter.ToString(ba);
		return text.Replace("-", "");
	}

	private static byte[] GetBytes(SQLiteDataReader reader)
	{
		byte[] array = new byte[2048];
		long num = 0L;
		checked
		{
			using MemoryStream memoryStream = new MemoryStream();
			long target = default(long);
			for (; InlineAssignHelper(ref target, reader.GetBytes(0, num, array, 0, array.Length)) > 0; num += target)
			{
				memoryStream.Write(array, 0, (int)target);
			}
			return memoryStream.ToArray();
		}
	}

	private static T InlineAssignHelper<T>(ref T target, T value)
	{
		target = value;
		return value;
	}
}
