using System;
using System.Collections;
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

namespace OculusTrayTool
{
	// Token: 0x02000038 RID: 56
	[StandardModule]
	internal sealed class MigrateSettings
	{
		// Token: 0x060004E8 RID: 1256 RVA: 0x00023C80 File Offset: 0x00021E80
		public static void MigrateConfig()
		{
			try
			{
				Log.WriteToMigrateLog("Migrating configuration");
				Log.WriteToLog("Migrating configuration");
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Application.StartupPath + "\\config.xml");
				XmlNode xmlNode = xmlDocument.SelectSingleNode("/Config");
				bool flag = !Information.IsNothing(xmlNode["StartMinimized"]);
				if (flag)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartMinimized");
					bool flag2 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag2)
					{
						MySettingsProperty.Settings.StartMinimized = false;
					}
					else
					{
						bool flag3 = Operators.CompareString(xmlNode2.InnerText, "True", false) == 0;
						if (flag3)
						{
							MySettingsProperty.Settings.StartMinimized = true;
						}
						else
						{
							MySettingsProperty.Settings.StartMinimized = false;
						}
					}
				}
				bool flag4 = !Information.IsNothing(xmlNode["StartHomeDelay"]);
				if (flag4)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartHomeDelay");
					bool flag5 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag5)
					{
						MySettingsProperty.Settings.StartHomeDelay = 3;
					}
					else
					{
						MySettingsProperty.Settings.StartHomeDelay = Conversions.ToInteger(xmlNode2.InnerText);
					}
				}
				bool flag6 = !Information.IsNothing(xmlNode["UseVoiceCommands"]);
				if (flag6)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/UseVoiceCommands");
					bool flag7 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag7)
					{
						MySettingsProperty.Settings.UseVoiceCommands = false;
					}
					else
					{
						bool flag8 = Operators.CompareString(xmlNode2.InnerText, "True", false) == 0;
						if (flag8)
						{
							MySettingsProperty.Settings.UseVoiceCommands = true;
						}
						else
						{
							MySettingsProperty.Settings.UseVoiceCommands = false;
						}
					}
				}
				bool flag9 = !Information.IsNothing(xmlNode["DisableFrescoPower"]);
				if (flag9)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/DisableFrescoPower");
					bool flag10 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag10)
					{
						MySettingsProperty.Settings.DisableFrescoPower = false;
					}
					else
					{
						bool flag11 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag11)
						{
							MySettingsProperty.Settings.DisableFrescoPower = false;
						}
						bool flag12 = Operators.CompareString(xmlNode2.InnerText, "True", false) == 0;
						if (flag12)
						{
							MySettingsProperty.Settings.DisableFrescoPower = true;
						}
					}
				}
				bool flag13 = !Information.IsNothing(xmlNode["LibraryPath"]);
				if (flag13)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/LibraryPath");
					bool flag14 = Operators.CompareString(xmlNode2.InnerText, "", false) != 0;
					if (flag14)
					{
						bool flag15 = Directory.Exists(xmlNode2.InnerText.TrimEnd(new char[] { '\\' }) + "\\Manifests");
						if (flag15)
						{
							MySettingsProperty.Settings.LibraryPath = xmlNode2.InnerText;
						}
					}
				}
				bool flag16 = !Information.IsNothing(xmlNode["PPDPStartup"]);
				if (flag16)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/PPDPStartup");
					bool flag17 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag17)
					{
						MySettingsProperty.Settings.PPDPStartup = "0";
					}
					else
					{
						MySettingsProperty.Settings.PPDPStartup = xmlNode2.InnerText;
					}
				}
				bool flag18 = !Information.IsNothing(xmlNode["PowerPlan"]);
				if (flag18)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/PowerPlan");
					bool flag19 = Operators.CompareString(xmlNode2.InnerText, "", false) != 0;
					if (flag19)
					{
						MySettingsProperty.Settings.PowerPlanStart = xmlNode2.InnerText;
					}
				}
				bool flag20 = !Information.IsNothing(xmlNode["SpoofCPU"]);
				if (flag20)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/SpoofCPU");
					bool flag21 = Operators.CompareString(xmlNode2.InnerText, "", false) != 0;
					if (flag21)
					{
						bool flag22 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag22)
						{
							MySettingsProperty.Settings.SpoofCPU = false;
						}
						bool flag23 = Operators.CompareString(xmlNode2.InnerText, "True", false) == 0;
						if (flag23)
						{
							MySettingsProperty.Settings.SpoofCPU = true;
						}
					}
				}
				bool flag24 = !Information.IsNothing(xmlNode["StopOVR"]);
				if (flag24)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StopOVR");
					bool flag25 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag25)
					{
						MySettingsProperty.Settings.StopOVR = false;
					}
					else
					{
						bool flag26 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag26)
						{
							MySettingsProperty.Settings.StopOVR = false;
						}
						else
						{
							MySettingsProperty.Settings.StopOVR = true;
						}
					}
				}
				bool flag27 = !Information.IsNothing(xmlNode["StartHomeOnServiceStart"]);
				if (flag27)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartHomeOnServiceStart");
					bool flag28 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag28)
					{
						MySettingsProperty.Settings.StartHomeOnServiceStart = false;
					}
					else
					{
						bool flag29 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag29)
						{
							MySettingsProperty.Settings.StartHomeOnServiceStart = false;
						}
						else
						{
							MySettingsProperty.Settings.StartHomeOnServiceStart = true;
						}
					}
				}
				bool flag30 = !Information.IsNothing(xmlNode["OculusPath"]);
				if (flag30)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/OculusPath");
					bool flag31 = Operators.CompareString(xmlNode2.InnerText, "", false) != 0;
					if (flag31)
					{
						bool flag32 = Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, "", false) == 0;
						if (flag32)
						{
							MySettingsProperty.Settings.OculusPath = xmlNode2.InnerText;
						}
					}
					else
					{
						bool flag33 = Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, "", false) != 0;
						if (flag33)
						{
							MySettingsProperty.Settings.OculusPath = MyProject.Forms.FrmMain.OculusPath;
						}
					}
				}
				bool flag34 = !Information.IsNothing(xmlNode["StartOVR"]);
				if (flag34)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartOVR");
					bool flag35 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag35)
					{
						MySettingsProperty.Settings.StartOVR = false;
					}
					else
					{
						bool flag36 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag36)
						{
							MySettingsProperty.Settings.StartOVR = false;
						}
						else
						{
							MySettingsProperty.Settings.StartOVR = true;
						}
					}
				}
				bool flag37 = !Information.IsNothing(xmlNode["OVRServerPriority"]);
				if (flag37)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/OVRServerPriority");
					bool flag38 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
					if (flag38)
					{
						MySettingsProperty.Settings.OVRServerPriority = false;
					}
					else
					{
						MySettingsProperty.Settings.OVRServerPriority = true;
					}
				}
				bool flag39 = !Information.IsNothing(xmlNode["StartHomeOnToolStart"]);
				if (flag39)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartHomeOnToolStart");
					bool flag40 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag40)
					{
						MySettingsProperty.Settings.StartHomeOnToolStart = false;
					}
					else
					{
						bool flag41 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag41)
						{
							MySettingsProperty.Settings.StartHomeOnToolStart = false;
						}
						else
						{
							MySettingsProperty.Settings.StartHomeOnToolStart = true;
						}
					}
				}
				bool flag42 = !Information.IsNothing(xmlNode["CloseHomeOnExit"]);
				if (flag42)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/CloseHomeOnExit");
					bool flag43 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag43)
					{
						MySettingsProperty.Settings.CloseHomeOnExit = false;
					}
					else
					{
						bool flag44 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag44)
						{
							MySettingsProperty.Settings.CloseHomeOnExit = false;
						}
						else
						{
							MySettingsProperty.Settings.CloseHomeOnExit = true;
						}
					}
				}
				bool flag45 = !Information.IsNothing(xmlNode["HideAltTab"]);
				if (flag45)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/HideAltTab");
					bool flag46 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag46)
					{
						MySettingsProperty.Settings.HideAltTab = false;
					}
					else
					{
						bool flag47 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag47)
						{
							MySettingsProperty.Settings.HideAltTab = false;
						}
						else
						{
							MySettingsProperty.Settings.HideAltTab = true;
						}
					}
				}
				bool flag48 = !Information.IsNothing(xmlNode["DefaultAudio"]);
				if (flag48)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/DefaultAudio");
					bool flag49 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag49)
					{
						MySettingsProperty.Settings.DefaultAudio = "";
					}
					else
					{
						MySettingsProperty.Settings.DefaultAudio = xmlNode2.InnerText;
					}
				}
				bool flag50 = !Information.IsNothing(xmlNode["DefaultMic"]);
				if (flag50)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/DefaultMic");
					bool flag51 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag51)
					{
						MySettingsProperty.Settings.DefaultMic = "";
					}
					else
					{
						MySettingsProperty.Settings.DefaultMic = xmlNode2.InnerText;
					}
				}
				bool flag52 = !Information.IsNothing(xmlNode["SetRiftAsDefault"]);
				if (flag52)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/SetRiftAsDefault");
					bool flag53 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag53)
					{
						MySettingsProperty.Settings.SetRiftAsDefault = false;
					}
					else
					{
						bool flag54 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag54)
						{
							MySettingsProperty.Settings.SetRiftAsDefault = false;
						}
						else
						{
							MySettingsProperty.Settings.SetRiftAsDefault = true;
						}
					}
				}
				bool flag55 = !Information.IsNothing(xmlNode["SetRiftAudioDefault"]);
				if (flag55)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/SetRiftAudioDefault");
					bool flag56 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag56)
					{
						MySettingsProperty.Settings.SetRiftAudioDefault = 0;
					}
					else
					{
						bool flag57 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag57)
						{
							MySettingsProperty.Settings.SetRiftAudioDefault = 0;
						}
						else
						{
							MySettingsProperty.Settings.SetRiftAudioDefault = -1;
						}
					}
				}
				bool flag58 = !Information.IsNothing(xmlNode["SetRiftMicDefault"]);
				if (flag58)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/SetRiftMicDefault");
					bool flag59 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag59)
					{
						MySettingsProperty.Settings.SetRiftMicDefault = 0;
					}
					else
					{
						bool flag60 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag60)
						{
							MySettingsProperty.Settings.SetRiftMicDefault = 0;
						}
						else
						{
							MySettingsProperty.Settings.SetRiftMicDefault = -1;
						}
					}
				}
				bool flag61 = !Information.IsNothing(xmlNode["UseLocalDebugTool"]);
				if (flag61)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/UseLocalDebugTool");
					bool flag62 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag62)
					{
						MySettingsProperty.Settings.UseLocalDebugTool = false;
					}
					else
					{
						bool flag63 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag63)
						{
							MySettingsProperty.Settings.UseLocalDebugTool = false;
						}
						else
						{
							MySettingsProperty.Settings.UseLocalDebugTool = true;
						}
					}
				}
				bool flag64 = !Information.IsNothing(xmlNode["UseHotKeys"]);
				if (flag64)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/UseHotKeys");
					bool flag65 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag65)
					{
						MySettingsProperty.Settings.UseHotKeys = false;
					}
					else
					{
						bool flag66 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag66)
						{
							MySettingsProperty.Settings.UseHotKeys = false;
						}
						else
						{
							MySettingsProperty.Settings.UseHotKeys = true;
						}
					}
				}
				bool flag67 = !Information.IsNothing(xmlNode["ASW"]);
				if (flag67)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/ASW");
					bool flag68 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag68)
					{
						MySettingsProperty.Settings.ASW = 0;
					}
					else
					{
						MySettingsProperty.Settings.ASW = Conversions.ToInteger(xmlNode2.InnerText);
					}
				}
				bool flag69 = !Information.IsNothing(xmlNode["CloseOnX"]);
				if (flag69)
				{
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/CloseOnX");
					bool flag70 = Operators.CompareString(xmlNode2.InnerText, "", false) == 0;
					if (flag70)
					{
						MySettingsProperty.Settings.CloseOnX = false;
					}
					else
					{
						bool flag71 = Operators.CompareString(xmlNode2.InnerText, "False", false) == 0;
						if (flag71)
						{
							MySettingsProperty.Settings.CloseOnX = false;
						}
						else
						{
							MySettingsProperty.Settings.CloseOnX = true;
						}
					}
				}
				xmlDocument.Save(Application.StartupPath + "\\config.xml");
				MySettingsProperty.Settings.Save();
				Log.WriteToLog("Settings migration complete!");
				Log.WriteToMigrateLog("Migration complete! App.config settings below");
				MyProject.Forms.FrmMain.PrintSettings(true);
			}
			catch (Exception ex)
			{
				FrmMain.fmain.AddToListboxAndScroll("Error migrating configurarion parameters: " + ex.Message);
				MyProject.Forms.FrmMain.hasError = true;
				StackTrace stackTrace = new StackTrace(ex, true);
				Log.WriteToLog(ex.ToString() + stackTrace.ToString());
				Log.WriteToMigrateLog(ex.ToString() + stackTrace.ToString());
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00024A58 File Offset: 0x00022C58
		public static void GetOldProfiles()
		{
			checked
			{
				try
				{
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToMigrateLog("Entering GetOldProfiles");
					}
					MyProject.Forms.FrmMain.profileList.Clear();
					MyProject.Forms.FrmMain.profileNames.Clear();
					MyProject.Forms.FrmMain.profileASWList.Clear();
					MyProject.Forms.FrmMain.profileDisplayNames.Clear();
					MyProject.Forms.FrmMain.profilePriorityList.Clear();
					GetConfig.numprofiles = 0;
					Log.WriteToMigrateLog("Getting old profiles");
					Log.WriteToLog("Getting old profiles");
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(Application.StartupPath + "\\config.xml");
					XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Config/Profiles");
					try
					{
						foreach (object obj in xmlNodeList)
						{
							XmlElement xmlElement = (XmlElement)obj;
							try
							{
								foreach (object obj2 in xmlElement.ChildNodes)
								{
									XmlNode xmlNode = (XmlNode)obj2;
									GetConfig.numprofiles++;
									XmlNode xmlNode2 = xmlNode.SelectSingleNode("name");
									XmlNode xmlNode3 = xmlNode.SelectSingleNode("PPDP");
									XmlNode xmlNode4 = xmlNode.SelectSingleNode("ASW");
									XmlNode xmlNode5 = xmlNode.SelectSingleNode("Priority");
									XmlNode xmlNode6 = xmlNode.SelectSingleNode("displayname");
									MigrateSettings.oldProfiles.Add(xmlNode2.InnerText + ".exe", string.Concat(new string[] { xmlNode3.InnerText, ",", xmlNode4.InnerText, ",", xmlNode5.InnerText }));
									Log.WriteToMigrateLog(string.Concat(new string[] { "Found profile: ", xmlNode2.InnerText, ".exe,", xmlNode3.InnerText, ",", xmlNode4.InnerText, ",", xmlNode5.InnerText }));
								}
							}
							finally
							{
								IEnumerator enumerator2;
								if (enumerator2 is IDisposable)
								{
									(enumerator2 as IDisposable).Dispose();
								}
							}
						}
					}
					finally
					{
						IEnumerator enumerator;
						if (enumerator is IDisposable)
						{
							(enumerator as IDisposable).Dispose();
						}
					}
				}
				catch (Exception ex)
				{
					FrmMain.fmain.AddToListboxAndScroll("Error: GetOldProfiles: " + ex.Message);
					MyProject.Forms.FrmMain.hasError = true;
					StackTrace stackTrace = new StackTrace(ex, true);
					Log.WriteToLog("GetOldProfiles: " + ex.ToString() + stackTrace.ToString());
					Log.WriteToMigrateLog("GetOldProfiles: " + ex.ToString() + stackTrace.ToString());
				}
				finally
				{
				}
			}
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00024DAC File Offset: 0x00022FAC
		public static void MigrateThirdPartyProfiles(string p)
		{
			try
			{
				Log.WriteToMigrateLog("Migrating third-party profiles");
				foreach (string text in Directory.GetFiles(p, "*_assets.json"))
				{
					string text2 = File.ReadAllText(text);
					JObject jobject = JObject.Parse(text2);
					string text3 = jobject.SelectToken("appId").ToString();
					bool flag = Operators.CompareString(text3, "", false) == 0;
					if (flag)
					{
						string text4 = jobject.SelectToken("canonicalName").ToString();
						string text5 = p + "\\" + text4.Replace("_assets", "") + ".json";
						string text6 = File.ReadAllText(text5);
						JObject jobject2 = JObject.Parse(text6);
						List<JToken> list = ((IEnumerable<JToken>)jobject2.Children()).ToList<JToken>();
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToMigrateLog(" - > " + text5);
						}
						string fileName;
						string text7;
						string text8;
						try
						{
							foreach (JToken jtoken in list)
							{
								JProperty jproperty = (JProperty)jtoken;
								jproperty.CreateReader();
								string name = jproperty.Name;
								if (Operators.CompareString(name, "displayName", false) != 0)
								{
									if (Operators.CompareString(name, "launchFile", false) == 0)
									{
										fileName = Path.GetFileName(jproperty.Value.ToString().Replace("\\\\", "\\"));
										text7 = jproperty.Value.ToString().Replace("\\\\", "\\");
										bool dbg2 = Globals.dbg;
										if (dbg2)
										{
											Log.WriteToMigrateLog("    LaunchFile is '" + fileName + "'");
										}
										bool dbg3 = Globals.dbg;
										if (dbg3)
										{
											Log.WriteToMigrateLog("    completePath is '" + text7 + "'");
										}
										break;
									}
								}
								else
								{
									text8 = jproperty.Value.ToString();
									bool dbg4 = Globals.dbg;
									if (dbg4)
									{
										Log.WriteToMigrateLog("    DisplayName is '" + text8 + "'");
									}
								}
							}
						}
						finally
						{
							List<JToken>.Enumerator enumerator;
							((IDisposable)enumerator).Dispose();
						}
						bool flag2 = text8.ToLower().EndsWith(".exe");
						if (flag2)
						{
							text8 = Path.GetFileNameWithoutExtension(fileName);
						}
						bool dbg5 = Globals.dbg;
						if (dbg5)
						{
							Log.WriteToMigrateLog("Looking for match: " + Path.GetFileName(fileName));
						}
						string text9 = "";
						MigrateSettings.oldProfiles.TryGetValue(Path.GetFileName(fileName), out text9);
						bool flag3 = Operators.CompareString(text9, "", false) != 0;
						if (flag3)
						{
							string[] array = Strings.Split(text9, ",", -1, CompareMethod.Binary);
							string text10 = array[0];
							string text11 = array[1];
							string text12 = array[2];
							OTTDB.AddProfile(text8, text11, text10, text12, fileName, text7, "WMI", "5", "5", "0", "1", "", "0.00 0.00", "False", "0", "Yes");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("MigrateThirdPartyApps: " + ex.Message);
				Log.WriteToMigrateLog("MigrateThirdPartyApps: " + ex.Message);
			}
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00025138 File Offset: 0x00023338
		public static void MigrateHomeProfiles(string p)
		{
			Log.WriteToMigrateLog("Migrating Oculus Native profiles");
			SQLiteConnection sqliteConnection = new SQLiteConnection();
			bool dbg = Globals.dbg;
			if (dbg)
			{
				Log.WriteToMigrateLog("Looking for Oculus database");
			}
			bool flag = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite");
			if (flag)
			{
				bool dbg2 = Globals.dbg;
				if (dbg2)
				{
					Log.WriteToMigrateLog("Database found, making a copy");
				}
				try
				{
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", true);
				}
				catch (Exception ex)
				{
					Log.WriteToMigrateLog("Failed to create database copy: " + ex.Message);
					Interaction.MsgBox("Failed to create database copy: " + ex.Message, MsgBoxStyle.Critical, "Error copying database");
					FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + ex.Message);
					MyProject.Forms.FrmMain.hasError = true;
					return;
				}
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToMigrateLog("Opening database copy");
				}
				try
				{
					bool flag2 = sqliteConnection.State == ConnectionState.Closed;
					if (flag2)
					{
						sqliteConnection = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
						sqliteConnection.Open();
					}
				}
				catch (Exception ex2)
				{
					Log.WriteToLog("Failed to open database copy: " + ex2.Message);
					Log.WriteToMigrateLog("Failed to open database copy: " + ex2.Message);
					Interaction.MsgBox("Failed to open database copy: " + ex2.Message, MsgBoxStyle.Critical, "Error opening database");
					FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + ex2.Message);
					MyProject.Forms.FrmMain.hasError = true;
					return;
				}
				bool dbg4 = Globals.dbg;
				if (dbg4)
				{
					Log.WriteToMigrateLog("Parsing manifests");
				}
				SQLiteCommand sqliteCommand = new SQLiteCommand(sqliteConnection);
				try
				{
					foreach (string text in Directory.GetFiles(p + "\\Manifests", "*.mini"))
					{
						bool dbg5 = Globals.dbg;
						if (dbg5)
						{
							Log.WriteToMigrateLog(" -> " + text);
						}
						string text2 = File.ReadAllText(text);
						JObject jobject = JObject.Parse(text2);
						string text3 = "";
						text3 = jobject.SelectToken("appId").ToString();
						bool dbg6 = Globals.dbg;
						if (dbg6)
						{
							Log.WriteToMigrateLog("    appId is '" + text3 + "'");
						}
						bool flag3 = Operators.CompareString(text3, "", false) != 0;
						if (flag3)
						{
							string text4 = jobject.SelectToken("canonicalName").ToString();
							bool dbg7 = Globals.dbg;
							if (dbg7)
							{
								Log.WriteToMigrateLog("    canonicalName is '" + text4 + "'");
							}
							string text5 = jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
							bool dbg8 = Globals.dbg;
							if (dbg8)
							{
								Log.WriteToMigrateLog("    launchfile is '" + text5 + "'");
							}
							string text6 = string.Concat(new string[]
							{
								p,
								"\\Software\\",
								text4.Replace("/", "\\").Replace("\\\\", "\\"),
								"\\",
								text5.Replace("/", "\\").Replace("\\\\", "\\")
							});
							bool dbg9 = Globals.dbg;
							if (dbg9)
							{
								Log.WriteToMigrateLog("    completePath is '" + text6 + "'");
							}
							StringBuilder stringBuilder = new StringBuilder();
							try
							{
								sqliteCommand.CommandText = "select value from Objects WHERE hashkey='" + text3 + "' AND typename='Application'";
								using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
								{
									while (sqliteDataReader.Read())
									{
										byte[] bytes = MigrateSettings.GetBytes(sqliteDataReader);
										stringBuilder.Append(Encoding.Default.GetString(bytes));
									}
								}
							}
							catch (Exception ex3)
							{
								Log.WriteToLog("Failed to read database entry for appId '" + text3 + "': " + ex3.Message);
								Log.WriteToMigrateLog("Failed to read database entry for appId '" + text3 + "': " + ex3.Message);
								Interaction.MsgBox("Failed to read database entry for appId '" + text3 + "': " + ex3.Message, MsgBoxStyle.Critical, "Error reading database");
								FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + text3 + "': " + ex3.Message);
								MyProject.Forms.FrmMain.hasError = true;
								return;
							}
							string text7 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
							string text8 = "display:name::";
							string text9 = ":display:short:description";
							int num = text7.IndexOf(text8);
							int num2 = text7.IndexOf(text9);
							bool flag4 = num > -1 && num2 > -1;
							if (flag4)
							{
								string text10 = checked(Strings.Mid(text7, num + text8.Length + 1, num2 - num - text8.Length)).Replace(":", " ").TrimEnd(new char[] { 'r' }).TrimEnd(new char[] { 's' })
									.TrimEnd(new char[] { ':' })
									.TrimEnd(new char[] { ' ' });
								bool dbg10 = Globals.dbg;
								if (dbg10)
								{
									Log.WriteToMigrateLog("    Appname is '" + text10 + "'");
								}
								bool dbg11 = Globals.dbg;
								if (dbg11)
								{
									Log.WriteToMigrateLog("Looking for match: " + Path.GetFileName(text5));
								}
								string text11 = "";
								MigrateSettings.oldProfiles.TryGetValue(Path.GetFileName(text5), out text11);
								bool flag5 = Operators.CompareString(text11, "", false) != 0;
								if (flag5)
								{
									string[] array = Strings.Split(text11, ",", -1, CompareMethod.Binary);
									string text12 = array[0];
									string text13 = array[1];
									string text14 = array[2];
									OTTDB.AddProfile(text10, text13, text12, text14, text5, text6, "WMI", "5", "5", "0", "1", "", "0.00 0.00", "False", "0", "Yes");
								}
							}
						}
						else
						{
							Log.WriteToMigrateLog("* Found NO match for appId '" + text3 + "'. Manifest file: " + text);
						}
					}
				}
				catch (Exception ex4)
				{
					Log.WriteToLog("Failed to open manifest file: " + ex4.Message);
					Log.WriteToMigrateLog("Failed to open manifest file: " + ex4.Message);
					Interaction.MsgBox("Failed to open manifest file: " + ex4.Message, MsgBoxStyle.Critical, "Error reading mainfest");
					FrmMain.fmain.AddToListboxAndScroll("Failed to open manifest file: " + ex4.Message);
					MyProject.Forms.FrmMain.hasError = true;
					sqliteCommand.Dispose();
					sqliteConnection.Close();
					return;
				}
				sqliteCommand.Dispose();
				sqliteConnection.Close();
				bool dbg12 = Globals.dbg;
				if (dbg12)
				{
					Log.WriteToMigrateLog("Connection closed");
				}
				File.Delete(Application.StartupPath + "\\data.sqlite");
				bool dbg13 = Globals.dbg;
				if (dbg13)
				{
					Log.WriteToMigrateLog("Database copy deleted");
				}
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00025958 File Offset: 0x00023B58
		private static string ByteArrayToString(byte[] ba)
		{
			string text = BitConverter.ToString(ba);
			return text.Replace("-", "");
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00025984 File Offset: 0x00023B84
		private static byte[] GetBytes(SQLiteDataReader reader)
		{
			byte[] array = new byte[2048];
			long num = 0L;
			checked
			{
				byte[] array2;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					long num2;
					while (MigrateSettings.InlineAssignHelper<long>(ref num2, reader.GetBytes(0, num, array, 0, array.Length)) > 0L)
					{
						memoryStream.Write(array, 0, (int)num2);
						num += num2;
					}
					array2 = memoryStream.ToArray();
				}
				return array2;
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00025A04 File Offset: 0x00023C04
		private static T InlineAssignHelper<T>(ref T target, T value)
		{
			target = value;
			return value;
		}

		// Token: 0x040001D5 RID: 469
		public static Dictionary<string, string> oldProfiles = new Dictionary<string, string>();
	}
}
