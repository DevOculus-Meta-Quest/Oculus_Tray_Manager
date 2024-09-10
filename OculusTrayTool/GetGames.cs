using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class GetGames
{
	public static Dictionary<string, string> manifesDictionary = new Dictionary<string, string>();

	public static Dictionary<string, string> assetPaths = new Dictionary<string, string>();

	public static List<string> steamGameList = new List<string>();

	public static void GetSteamGames()
	{
		try
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Updating list of Steam games..");
			}
			List<SteamNode> steamList = null;
			if (!Globals.oculus.TryRefresh() || !Globals.steam.TryRefresh() || !Globals.steam.TryGetVRManifest(ref steamList) || !Globals.steam.TryGetAppInfo(steamList, windowsOnly: true, vrOnly: true))
			{
				return;
			}
			foreach (SteamNode item in steamList)
			{
				if (item.Executable == null)
				{
					continue;
				}
				if (Globals.dbg)
				{
					Log.WriteToLog("GetSteamGames: Name: " + item.Name + " Executable: " + Path.GetFileName(item.Executable.Replace("/", "\\")) + " Full path: " + item.LibraryFolder + "\\steamapps\\common\\" + item.InstallDir + "\\" + item.Executable.Replace("/", "\\"));
				}
				string text = item.LibraryFolder + "\\steamapps\\common\\" + item.InstallDir + "\\" + item.Executable.Replace("/", "\\");
				if (!MyProject.Forms.FrmMain.AllAppsList.ContainsKey(text))
				{
					MyProject.Forms.FrmMain.AllAppsList.Add(text, item.Name);
					MyProject.Forms.frmProfiles.GameList.Add(item.Name, text);
					if (Globals.dbg)
					{
						Log.WriteToLog("GetSteamGames: All Apps List: Added Steam App '" + item.Name + "' with path '" + text + "'");
					}
				}
				if (!steamGameList.Contains(item.Name))
				{
					steamGameList.Add(item.Name);
					if (Globals.dbg)
					{
						Log.WriteToLog("GetSteamGames: Steam Game List: Added Steam App '" + item.Name + "'");
					}
				}
			}
			Log.WriteToLog("Found " + Conversions.ToString(steamGameList.Count) + " Steam VR Apps");
			foreach (string steamGame in steamGameList)
			{
				Log.WriteToLog("Steam VR App '" + steamGame.ToString() + "' added to available games list");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetSteamGames: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void GetThirdPartyApps(string p)
	{
		Log.WriteToLog("Parsing Third-Party Manifests in " + p);
		string oculusPath = MySettingsProperty.Settings.OculusPath;
		string assetPath = Path.Combine(oculusPath, "CoreData\\Software\\StoreAssets");
		string text = "";
		string otherAssetPath = "";
		if ((Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString()))
		{
			string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
			text = array[0];
			otherAssetPath = Path.Combine(text, "Software\\StoreAssets");
		}
		else
		{
			text = oculusPath;
		}
		string text2 = "";
		string[] files = Directory.GetFiles(p, "*.json");
		string fileName = default(string);
		string text4 = default(string);
		string text5 = default(string);
		for (int i = 0; i < files.Length; i = checked(i + 1))
		{
			text2 = files[i];
			try
			{
				if (text2.Contains("_assets.json"))
				{
					continue;
				}
				if (!MyProject.Forms.FrmMain.includedApps.Contains(text2) && MyProject.Forms.FrmMain.ignoredApps.Contains(text2))
				{
					if (Globals.dbg)
					{
						Log.WriteToLog("GetThirdPartyApps: " + text2 + " is on the ignore list");
					}
					continue;
				}
				if (Globals.dbg)
				{
					Log.WriteToLog("GetThirdPartyApps: Opening " + text2);
				}
				string json = File.ReadAllText(text2);
				JObject jObject = JObject.Parse(json);
				string text3 = jObject.SelectToken("canonicalName").ToString();
				string displayNameAssetFile = p + "\\" + text3 + ".json";
				List<JToken> list = jObject.Children().ToList();
				foreach (JProperty item in list)
				{
					item.CreateReader();
					string name = item.Name;
					if (Operators.CompareString(name, "displayName", TextCompare: false) != 0)
					{
						if (Operators.CompareString(name, "launchFile", TextCompare: false) == 0)
						{
							fileName = Path.GetFileName(item.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
							text4 = item.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
							if (text5.ToLower().EndsWith(".exe") | (Operators.CompareString(text5.ToLower(), "unknown app", TextCompare: false) == 0))
							{
								text5 = Path.GetFileNameWithoutExtension(fileName);
							}
							break;
						}
					}
					else
					{
						text5 = item.Value.ToString();
					}
				}
				if (!(bool)jObject.SelectToken("thirdParty"))
				{
					if (!MyProject.Forms.FrmMain.includedApps.Contains(text2) && !MyProject.Forms.FrmMain.ignoredApps.Contains(text2))
					{
						if (Globals.dbg)
						{
							Log.WriteToLog("GetThirdPartyApps:  -> App is not a VR app, adding to ignore list");
						}
						OTTDB.AddIgnoreApp(text2);
						MyProject.Forms.FrmMain.ignoredApps.Add(text2);
					}
				}
				else
				{
					if (!((Operators.CompareString(text5, "", TextCompare: false) != 0) & (Operators.CompareString(text4, "", TextCompare: false) != 0)))
					{
						continue;
					}
					if (Globals.dbg)
					{
						Log.WriteToLog("GetThirdPartyApps: Looking for '" + text5 + "' in Steam game list");
					}
					if (steamGameList.Contains(text5))
					{
						AddThirdPartyGameToList(assetPath, otherAssetPath, text2, steamGameList, displayNameAssetFile, text5, fileName, text4, text3);
						continue;
					}
					if (Globals.dbg)
					{
						Log.WriteToLog("GetThirdPartyApps: '" + text5 + "' not found in Steam game list, checking Oculus database");
					}
					StringBuilder stringBuilder = new StringBuilder();
					SQLiteConnection sQLiteConnection = new SQLiteConnection();
					if (sQLiteConnection.State == ConnectionState.Closed)
					{
						sQLiteConnection = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
						sQLiteConnection.Open();
					}
					try
					{
						SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
						sQLiteCommand.CommandText = "select value from Objects WHERE hashkey=\"" + text3 + "_LocalAppState\" AND typename='LocalApplicationState'";
						if (Globals.dbg)
						{
							Log.WriteToLog("GetThirdPartyApps:  -> Looking for entry: " + text3 + "_LocalAppState");
						}
						using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
						if (sQLiteDataReader.HasRows)
						{
							if (Globals.dbg)
							{
								Log.WriteToLog("GetThirdPartyApps:  -> Reading entry for " + text3 + "_LocalAppState");
							}
							while (sQLiteDataReader.Read())
							{
								byte[] bytes = GetBytes(sQLiteDataReader);
								stringBuilder.Append(Encoding.Default.GetString(bytes));
							}
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Log.WriteToLog("GetThirdPartyApps:  -> Failed to read database entry for appId '" + text3 + "': " + ex2.Message);
						FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + text3 + "': " + ex2.Message);
						ProjectData.ClearProjectError();
						goto end_IL_00be;
					}
					if (!MyProject.Forms.FrmMain.includedApps.Contains(text2) && stringBuilder.ToString().Contains("FLAT"))
					{
						if (Globals.dbg)
						{
							Log.WriteToLog("GetThirdPartyApps:  -> App does not appear to be a VR app, ignoring");
						}
						if (!MyProject.Forms.FrmMain.ignoredApps.Contains(text2))
						{
							if (Globals.dbg)
							{
								Log.WriteToLog("GetThirdPartyApps:  -> App is not a VR app, adding to ignore list");
							}
							OTTDB.AddIgnoreApp(text2);
							MyProject.Forms.FrmMain.ignoredApps.Add(text2);
						}
						continue;
					}
					if (Operators.CompareString(stringBuilder.ToString(), "", TextCompare: false) != 0)
					{
						AddThirdPartyGameToList(assetPath, otherAssetPath, text2, steamGameList, displayNameAssetFile, text5, fileName, text4, text3);
					}
					if (Operators.CompareString(stringBuilder.ToString(), "", TextCompare: false) != 0)
					{
						continue;
					}
					if (Globals.dbg)
					{
						Log.WriteToLog("GetThirdPartyApps:  -> Not found, looking for secondary entry: " + text3 + ": UserAppPlayTime");
					}
					SQLiteCommand sQLiteCommand2 = new SQLiteCommand(sQLiteConnection);
					sQLiteCommand2.CommandText = "select value from Objects WHERE hashkey LIKE \"%" + text3 + "%\" AND typename='UserAppPlayTime'";
					using (SQLiteDataReader sQLiteDataReader2 = sQLiteCommand2.ExecuteReader())
					{
						if (sQLiteDataReader2.HasRows)
						{
							if (Globals.dbg)
							{
								Log.WriteToLog("GetThirdPartyApps:  -> Found entry for " + text3 + ": UserAppPlayTime");
							}
							AddThirdPartyGameToList(assetPath, otherAssetPath, text2, steamGameList, displayNameAssetFile, text5, fileName, text4, text3);
						}
						else if (!MyProject.Forms.FrmMain.includedApps.Contains(text2))
						{
							if (Globals.dbg)
							{
								Log.WriteToLog("GetThirdPartyApps:  -> App does not appear to be a VR app or has been uninstalled, ignoring");
							}
							if (!MyProject.Forms.FrmMain.ignoredApps.Contains(text2))
							{
								if (Globals.dbg)
								{
									Log.WriteToLog("GetThirdPartyApps:  -> App is not a VR app, adding to ignore list");
								}
								OTTDB.AddIgnoreApp(text2);
								MyProject.Forms.FrmMain.ignoredApps.Add(text2);
							}
						}
						else
						{
							AddThirdPartyGameToList(assetPath, otherAssetPath, text2, steamGameList, displayNameAssetFile, text5, fileName, text4, text3);
						}
					}
					continue;
				}
				end_IL_00be:;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Log.WriteToLog("GetThirdPartyApps: Failed to open manifest file: " + ex4.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void AddThirdPartyGameToList(string assetPath, string otherAssetPath, string manifest, List<string> steamGameList, string displayNameAssetFile, string DisplayName, string LaunchFile, string completePath, string canonName)
	{
		if (!MyProject.Forms.FrmMain.AllAppsList.ContainsKey(completePath))
		{
			MyProject.Forms.FrmMain.AllAppsList.Add(completePath, DisplayName);
			if (Globals.dbg)
			{
				Log.WriteToLog("AddThirdPartyGameToList: All Apps List: Added Steam App '" + DisplayName + "' with path '" + completePath + "'");
			}
		}
		if (Globals.dbg)
		{
			Log.WriteToLog("AddThirdPartyGameToList: Game found, checking for hidden attribute");
		}
		if (!OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Both"))
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("AddThirdPartyGameToList: Game is not hidden");
			}
			if (!MyProject.Forms.frmProfiles.GameList.ContainsKey(DisplayName))
			{
				if (!MyProject.Forms.FrmMain.profilePaths.ContainsKey(completePath))
				{
					MyProject.Forms.frmProfiles.GameList.Add(DisplayName, completePath);
					Log.WriteToLog("Third-Party App '" + DisplayName + "' added to available games list");
				}
				else
				{
					Log.WriteToLog("Third-Party App '" + DisplayName + "' has a profile, NOT added");
				}
			}
			if (!manifesDictionary.ContainsKey(DisplayName))
			{
				manifesDictionary.Add(DisplayName, manifest);
			}
			if (File.Exists(assetPath + "\\" + canonName + "_assets\\cover_landscape_image.jpg"))
			{
				if (!assetPaths.ContainsKey(DisplayName))
				{
					assetPaths.Add(DisplayName, assetPath + "\\" + canonName + "_assets");
					if (Globals.dbg)
					{
						Log.WriteToLog("Added " + assetPath + "\\" + canonName + "_assets as asset path for '" + DisplayName + "'");
					}
				}
			}
			else if (File.Exists(otherAssetPath + "\\" + canonName + "_assets\\cover_landscape_image.jpg"))
			{
				if (!assetPaths.ContainsKey(DisplayName))
				{
					assetPaths.Add(DisplayName, otherAssetPath + "\\" + canonName + "_assets");
					if (Globals.dbg)
					{
						Log.WriteToLog("Added " + otherAssetPath + "\\" + canonName + "_assets as asset path for '" + DisplayName + "'");
					}
				}
			}
			else
			{
				Log.WriteToLog("AddThirdPartyGameToList(): Warning: Could not find asset path for '" + DisplayName + "' in ");
				Log.WriteToLog(" -> " + assetPath + "\\" + canonName + "_assets");
				Log.WriteToLog(" -> " + otherAssetPath + "\\" + canonName + "_assets");
			}
		}
		else if (Globals.dbg)
		{
			Log.WriteToLog("AddThirdPartyGameToList: Game is hidden");
		}
	}

	public static void GetFiles(string p)
	{
		checked
		{
			try
			{
				SQLiteConnection sQLiteConnection = new SQLiteConnection();
				string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
				string oculusPath = MySettingsProperty.Settings.OculusPath;
				string text = "";
				string text2 = "";
				string text3 = Path.Combine(oculusPath, "CoreData\\Software\\StoreAssets");
				if ((Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", TextCompare: false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString()))
				{
					text = array[0];
					text2 = Path.Combine(text, "Software\\StoreAssets");
				}
				else
				{
					text = oculusPath;
				}
				if (Globals.dbg)
				{
					Log.WriteToLog("GetApps: Looking for Oculus database");
				}
				if (!File.Exists(Application.StartupPath + "\\data.sqlite"))
				{
					return;
				}
				if (Globals.dbg)
				{
					Log.WriteToLog("GetApps: Opening database copy");
				}
				try
				{
					if (sQLiteConnection.State == ConnectionState.Closed)
					{
						sQLiteConnection = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
						sQLiteConnection.Open();
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Log.WriteToLog("GetApps: Failed to open database copy: " + ex2.Message);
					Interaction.MsgBox("Failed to open database copy: " + ex2.Message, MsgBoxStyle.Critical, "Error opening database");
					FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + ex2.Message);
					MyProject.Forms.FrmMain.hasError = true;
					ProjectData.ClearProjectError();
					return;
				}
				Log.WriteToLog("Parsing Manifests in " + p);
				SQLiteCommand sQLiteCommand = new SQLiteCommand(sQLiteConnection);
				string[] files = Directory.GetFiles(p, "*.mini");
				foreach (string text4 in files)
				{
					try
					{
						if (!MyProject.Forms.FrmMain.includedApps.Contains(text4) && MyProject.Forms.FrmMain.ignoredApps.Contains(text4.Replace(".mini", "")))
						{
							if (Globals.dbg)
							{
								Log.WriteToLog("GetApps: " + text4 + " is on the ignore list");
							}
							continue;
						}
						if (Globals.dbg)
						{
							Log.WriteToLog("GetApps: Opening " + text4);
						}
						string json = File.ReadAllText(text4);
						JObject jObject = JObject.Parse(json);
						string text5 = "";
						text5 = jObject.SelectToken("appId").ToString();
						if (Operators.CompareString(text5, "", TextCompare: false) == 0)
						{
							continue;
						}
						if (Globals.dbg)
						{
							Log.WriteToLog("    appId is '" + text5 + "'");
						}
						string text6 = jObject.SelectToken("canonicalName").ToString();
						if (Globals.dbg)
						{
							Log.WriteToLog("    canonicalName is '" + text6 + "'");
						}
						string text7 = jObject.SelectToken("launchFile").ToString().Replace("/", "\\");
						if (Globals.dbg)
						{
							Log.WriteToLog("    launchfile is '" + text7 + "'");
						}
						string text8 = p.Replace("\\Manifests", "") + "\\Software\\" + text6.Replace("/", "\\").Replace("\\\\", "\\") + "\\" + text7.Replace("/", "\\").Replace("\\\\", "\\");
						if (Globals.dbg)
						{
							Log.WriteToLog("    completePath is '" + text8 + "'");
						}
						StringBuilder stringBuilder = new StringBuilder();
						try
						{
							sQLiteCommand.CommandText = "select value from Objects WHERE hashkey='" + text5 + "' AND typename='Application'";
							using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
							if (sQLiteDataReader.HasRows)
							{
								while (sQLiteDataReader.Read())
								{
									byte[] bytes = GetBytes(sQLiteDataReader);
									stringBuilder.Append(Encoding.Default.GetString(bytes));
								}
								goto IL_04a9;
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							Log.WriteToLog("GetApps:  -> Failed to read database entry for appId '" + text5 + "': " + ex4.Message);
							FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + text5 + "': " + ex4.Message);
							MyProject.Forms.FrmMain.hasError = true;
							ProjectData.ClearProjectError();
							return;
						}
						goto end_IL_01bb;
						IL_04a9:
						if (stringBuilder.ToString().Contains("FLAT") && !MyProject.Forms.FrmMain.includedApps.Contains(text4))
						{
							if (!MyProject.Forms.FrmMain.ignoredApps.Contains(text4))
							{
								if (Globals.dbg)
								{
									Log.WriteToLog("GetApps:  ->  App does not appear to be a VR app, adding to ignore list");
								}
								OTTDB.AddIgnoreApp(text4);
								MyProject.Forms.FrmMain.ignoredApps.Add(text4);
							}
							continue;
						}
						string text9 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
						string text10 = "display:name::";
						string value = ":display:short:description";
						int num = text9.IndexOf(text10);
						int num2 = text9.IndexOf(value);
						if (num <= -1 || num2 <= -1)
						{
							continue;
						}
						string text11 = Strings.Mid(text9, num + text10.Length + 1, num2 - num - text10.Length).Replace(":", " ").TrimEnd(':')
							.TrimEnd(' ');
						text11 = text11.Remove(text11.Length - 1);
						if (Globals.dbg)
						{
							Log.WriteToLog("    Appname is '" + text11 + "'");
						}
						if (!((Operators.CompareString(text11, "", TextCompare: false) != 0) & (Operators.CompareString(text8, "", TextCompare: false) != 0)))
						{
							continue;
						}
						if (!MyProject.Forms.FrmMain.AllAppsList.ContainsKey(text8))
						{
							MyProject.Forms.FrmMain.AllAppsList.Add(text8, text11);
							if (Globals.dbg)
							{
								Log.WriteToLog("All Apps List: Added Oculus Store App '" + text11 + "' with path '" + text8 + "'");
							}
						}
						if (OTTDB.CheckHiddenApp(text7, text11, "Both"))
						{
							continue;
						}
						if (!MyProject.Forms.frmProfiles.GameList.ContainsKey(text11))
						{
							if (!MyProject.Forms.FrmMain.profilePaths.ContainsKey(text8))
							{
								MyProject.Forms.frmProfiles.GameList.Add(text11, text8);
								Log.WriteToLog("Oculus Store App '" + text11 + "' added to available games list");
							}
							else
							{
								Log.WriteToLog("Oculus Store App '" + text11 + "' has a profile, NOT added");
							}
						}
						if (!manifesDictionary.ContainsKey(text11))
						{
							manifesDictionary.Add(text11, text4);
						}
						if (File.Exists(text3 + "\\" + text6 + "_assets\\cover_landscape_image.jpg"))
						{
							if (!assetPaths.ContainsKey(text11))
							{
								assetPaths.Add(text11, text3 + "\\" + text6 + "_assets");
								if (Globals.dbg)
								{
									Log.WriteToLog("Added " + text3 + "\\" + text6 + "_assets as asset path for '" + text11 + "'");
								}
							}
						}
						else if (File.Exists(text2 + "\\" + text6 + "_assets\\cover_landscape_image.jpg"))
						{
							if (!assetPaths.ContainsKey(text11))
							{
								assetPaths.Add(text11, text2 + "\\" + text6 + "_assets");
								if (Globals.dbg)
								{
									Log.WriteToLog("Added " + text2 + "\\" + text6 + "_assets as asset path for '" + text11 + "'");
								}
							}
						}
						else
						{
							Log.WriteToLog("GetFiles(): Warning: Could not find asset path for '" + text11 + "' in ");
							Log.WriteToLog(" -> " + text3 + "\\" + text6 + "_assets");
							Log.WriteToLog(" -> " + text2 + "\\" + text6 + "_assets");
						}
						end_IL_01bb:;
					}
					catch (Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						Exception ex6 = ex5;
						Log.WriteToLog("GetApps:  -> Failed to open manifest file: " + ex6.Message);
						ProjectData.ClearProjectError();
					}
				}
				sQLiteCommand.Dispose();
				sQLiteConnection.Close();
				if (Globals.dbg)
				{
					Log.WriteToLog("GetApps: Connection closed");
				}
			}
			catch (Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				Exception ex8 = ex7;
				Log.WriteToLog("GetApps: " + ex8.Message);
				ProjectData.ClearProjectError();
			}
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
