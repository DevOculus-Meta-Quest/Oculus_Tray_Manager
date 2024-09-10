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

namespace OculusTrayTool
{
	// Token: 0x0200002B RID: 43
	[StandardModule]
	internal sealed class GetGames
	{
		// Token: 0x060003F3 RID: 1011 RVA: 0x00019E34 File Offset: 0x00018034
		public static void GetSteamGames()
		{
			try
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Updating list of Steam games..");
				}
				List<SteamNode> list = null;
				bool flag = !Globals.oculus.TryRefresh();
				if (!flag)
				{
					bool flag2 = !Globals.steam.TryRefresh();
					if (!flag2)
					{
						bool flag3 = !Globals.steam.TryGetVRManifest(ref list);
						if (!flag3)
						{
							bool flag4 = !Globals.steam.TryGetAppInfo(list, true, true);
							if (!flag4)
							{
								try
								{
									foreach (SteamNode steamNode in list)
									{
										bool flag5 = steamNode.Executable != null;
										if (flag5)
										{
											bool dbg2 = Globals.dbg;
											if (dbg2)
											{
												Log.WriteToLog(string.Concat(new string[]
												{
													"GetSteamGames: Name: ",
													steamNode.Name,
													" Executable: ",
													Path.GetFileName(steamNode.Executable.Replace("/", "\\")),
													" Full path: ",
													steamNode.LibraryFolder,
													"\\steamapps\\common\\",
													steamNode.InstallDir,
													"\\",
													steamNode.Executable.Replace("/", "\\")
												}));
											}
											string text = string.Concat(new string[]
											{
												steamNode.LibraryFolder,
												"\\steamapps\\common\\",
												steamNode.InstallDir,
												"\\",
												steamNode.Executable.Replace("/", "\\")
											});
											bool flag6 = !MyProject.Forms.FrmMain.AllAppsList.ContainsKey(text);
											if (flag6)
											{
												MyProject.Forms.FrmMain.AllAppsList.Add(text, steamNode.Name);
												MyProject.Forms.frmProfiles.GameList.Add(steamNode.Name, text);
												bool dbg3 = Globals.dbg;
												if (dbg3)
												{
													Log.WriteToLog(string.Concat(new string[] { "GetSteamGames: All Apps List: Added Steam App '", steamNode.Name, "' with path '", text, "'" }));
												}
											}
											bool flag7 = !GetGames.steamGameList.Contains(steamNode.Name);
											if (flag7)
											{
												GetGames.steamGameList.Add(steamNode.Name);
												bool dbg4 = Globals.dbg;
												if (dbg4)
												{
													Log.WriteToLog("GetSteamGames: Steam Game List: Added Steam App '" + steamNode.Name + "'");
												}
											}
										}
									}
								}
								finally
								{
									List<SteamNode>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
								Log.WriteToLog("Found " + Conversions.ToString(GetGames.steamGameList.Count) + " Steam VR Apps");
								try
								{
									foreach (string text2 in GetGames.steamGameList)
									{
										Log.WriteToLog("Steam VR App '" + text2.ToString() + "' added to available games list");
									}
								}
								finally
								{
									List<string>.Enumerator enumerator2;
									((IDisposable)enumerator2).Dispose();
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetSteamGames: " + ex.Message);
			}
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0001A1D4 File Offset: 0x000183D4
		public static void GetThirdPartyApps(string p)
		{
			Log.WriteToLog("Parsing Third-Party Manifests in " + p);
			string oculusPath = MySettingsProperty.Settings.OculusPath;
			string text = Path.Combine(oculusPath, "CoreData\\Software\\StoreAssets");
			string text2 = "";
			bool flag = (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString());
			if (flag)
			{
				string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary);
				string text3 = array[0];
				text2 = Path.Combine(text3, "Software\\StoreAssets");
			}
			string text4 = "";
			string[] files = Directory.GetFiles(p, "*.json");
			int i = 0;
			checked
			{
				while (i < files.Length)
				{
					text4 = files[i];
					try
					{
						bool flag2 = text4.Contains("_assets.json");
						if (!flag2)
						{
							bool flag3 = !MyProject.Forms.FrmMain.includedApps.Contains(text4);
							if (flag3)
							{
								bool flag4 = MyProject.Forms.FrmMain.ignoredApps.Contains(text4);
								if (flag4)
								{
									bool dbg = Globals.dbg;
									if (dbg)
									{
										Log.WriteToLog("GetThirdPartyApps: " + text4 + " is on the ignore list");
									}
									goto IL_07E2;
								}
							}
							bool dbg2 = Globals.dbg;
							if (dbg2)
							{
								Log.WriteToLog("GetThirdPartyApps: Opening " + text4);
							}
							string text5 = File.ReadAllText(text4);
							JObject jobject = JObject.Parse(text5);
							string text6 = jobject.SelectToken("canonicalName").ToString();
							string text7 = p + "\\" + text6 + ".json";
							List<JToken> list = ((IEnumerable<JToken>)jobject.Children()).ToList<JToken>();
							string fileName;
							string text8;
							string text9;
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
											fileName = Path.GetFileName(jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
											text8 = jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
											bool flag5 = text9.ToLower().EndsWith(".exe") | (Operators.CompareString(text9.ToLower(), "unknown app", false) == 0);
											if (flag5)
											{
												text9 = Path.GetFileNameWithoutExtension(fileName);
											}
											break;
										}
									}
									else
									{
										text9 = jproperty.Value.ToString();
									}
								}
							}
							finally
							{
								List<JToken>.Enumerator enumerator;
								((IDisposable)enumerator).Dispose();
							}
							bool flag6 = (bool)jobject.SelectToken("thirdParty");
							bool flag7 = !flag6;
							if (flag7)
							{
								bool flag8 = !MyProject.Forms.FrmMain.includedApps.Contains(text4);
								if (flag8)
								{
									bool flag9 = !MyProject.Forms.FrmMain.ignoredApps.Contains(text4);
									if (flag9)
									{
										bool dbg3 = Globals.dbg;
										if (dbg3)
										{
											Log.WriteToLog("GetThirdPartyApps:  -> App is not a VR app, adding to ignore list");
										}
										OTTDB.AddIgnoreApp(text4);
										MyProject.Forms.FrmMain.ignoredApps.Add(text4);
									}
								}
							}
							else
							{
								bool flag10 = (Operators.CompareString(text9, "", false) != 0) & (Operators.CompareString(text8, "", false) != 0);
								if (flag10)
								{
									bool dbg4 = Globals.dbg;
									if (dbg4)
									{
										Log.WriteToLog("GetThirdPartyApps: Looking for '" + text9 + "' in Steam game list");
									}
									bool flag11 = GetGames.steamGameList.Contains(text9);
									if (flag11)
									{
										GetGames.AddThirdPartyGameToList(text, text2, text4, GetGames.steamGameList, text7, text9, fileName, text8, text6);
									}
									else
									{
										bool dbg5 = Globals.dbg;
										if (dbg5)
										{
											Log.WriteToLog("GetThirdPartyApps: '" + text9 + "' not found in Steam game list, checking Oculus database");
										}
										StringBuilder stringBuilder = new StringBuilder();
										SQLiteConnection sqliteConnection = new SQLiteConnection();
										bool flag12 = sqliteConnection.State == ConnectionState.Closed;
										if (flag12)
										{
											sqliteConnection = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
											sqliteConnection.Open();
										}
										try
										{
											SQLiteCommand sqliteCommand = new SQLiteCommand(sqliteConnection);
											sqliteCommand.CommandText = "select value from Objects WHERE hashkey=\"" + text6 + "_LocalAppState\" AND typename='LocalApplicationState'";
											bool dbg6 = Globals.dbg;
											if (dbg6)
											{
												Log.WriteToLog("GetThirdPartyApps:  -> Looking for entry: " + text6 + "_LocalAppState");
											}
											using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
											{
												bool hasRows = sqliteDataReader.HasRows;
												if (hasRows)
												{
													bool dbg7 = Globals.dbg;
													if (dbg7)
													{
														Log.WriteToLog("GetThirdPartyApps:  -> Reading entry for " + text6 + "_LocalAppState");
													}
													while (sqliteDataReader.Read())
													{
														byte[] bytes = GetGames.GetBytes(sqliteDataReader);
														stringBuilder.Append(Encoding.Default.GetString(bytes));
													}
												}
											}
										}
										catch (Exception ex)
										{
											Log.WriteToLog("GetThirdPartyApps:  -> Failed to read database entry for appId '" + text6 + "': " + ex.Message);
											FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + text6 + "': " + ex.Message);
											goto IL_07E2;
										}
										bool flag13 = !MyProject.Forms.FrmMain.includedApps.Contains(text4);
										if (flag13)
										{
											bool flag14 = stringBuilder.ToString().Contains("FLAT");
											if (flag14)
											{
												bool dbg8 = Globals.dbg;
												if (dbg8)
												{
													Log.WriteToLog("GetThirdPartyApps:  -> App does not appear to be a VR app, ignoring");
												}
												bool flag15 = !MyProject.Forms.FrmMain.ignoredApps.Contains(text4);
												if (flag15)
												{
													bool dbg9 = Globals.dbg;
													if (dbg9)
													{
														Log.WriteToLog("GetThirdPartyApps:  -> App is not a VR app, adding to ignore list");
													}
													OTTDB.AddIgnoreApp(text4);
													MyProject.Forms.FrmMain.ignoredApps.Add(text4);
												}
												goto IL_07E2;
											}
										}
										bool flag16 = Operators.CompareString(stringBuilder.ToString(), "", false) != 0;
										if (flag16)
										{
											GetGames.AddThirdPartyGameToList(text, text2, text4, GetGames.steamGameList, text7, text9, fileName, text8, text6);
										}
										bool flag17 = Operators.CompareString(stringBuilder.ToString(), "", false) == 0;
										if (flag17)
										{
											bool dbg10 = Globals.dbg;
											if (dbg10)
											{
												Log.WriteToLog("GetThirdPartyApps:  -> Not found, looking for secondary entry: " + text6 + ": UserAppPlayTime");
											}
											using (SQLiteDataReader sqliteDataReader2 = new SQLiteCommand(sqliteConnection)
											{
												CommandText = "select value from Objects WHERE hashkey LIKE \"%" + text6 + "%\" AND typename='UserAppPlayTime'"
											}.ExecuteReader())
											{
												bool hasRows2 = sqliteDataReader2.HasRows;
												if (hasRows2)
												{
													bool dbg11 = Globals.dbg;
													if (dbg11)
													{
														Log.WriteToLog("GetThirdPartyApps:  -> Found entry for " + text6 + ": UserAppPlayTime");
													}
													GetGames.AddThirdPartyGameToList(text, text2, text4, GetGames.steamGameList, text7, text9, fileName, text8, text6);
												}
												else
												{
													bool flag18 = !MyProject.Forms.FrmMain.includedApps.Contains(text4);
													if (flag18)
													{
														bool dbg12 = Globals.dbg;
														if (dbg12)
														{
															Log.WriteToLog("GetThirdPartyApps:  -> App does not appear to be a VR app or has been uninstalled, ignoring");
														}
														bool flag19 = !MyProject.Forms.FrmMain.ignoredApps.Contains(text4);
														if (flag19)
														{
															bool dbg13 = Globals.dbg;
															if (dbg13)
															{
																Log.WriteToLog("GetThirdPartyApps:  -> App is not a VR app, adding to ignore list");
															}
															OTTDB.AddIgnoreApp(text4);
															MyProject.Forms.FrmMain.ignoredApps.Add(text4);
														}
													}
													else
													{
														GetGames.AddThirdPartyGameToList(text, text2, text4, GetGames.steamGameList, text7, text9, fileName, text8, text6);
													}
												}
											}
										}
									}
								}
							}
						}
					}
					catch (Exception ex2)
					{
						Log.WriteToLog("GetThirdPartyApps: Failed to open manifest file: " + ex2.Message);
					}
					IL_07E2:
					i++;
					continue;
					goto IL_07E2;
				}
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0001AA58 File Offset: 0x00018C58
		private static void AddThirdPartyGameToList(string assetPath, string otherAssetPath, string manifest, List<string> steamGameList, string displayNameAssetFile, string DisplayName, string LaunchFile, string completePath, string canonName)
		{
			bool flag = !MyProject.Forms.FrmMain.AllAppsList.ContainsKey(completePath);
			if (flag)
			{
				MyProject.Forms.FrmMain.AllAppsList.Add(completePath, DisplayName);
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog(string.Concat(new string[] { "AddThirdPartyGameToList: All Apps List: Added Steam App '", DisplayName, "' with path '", completePath, "'" }));
				}
			}
			bool dbg2 = Globals.dbg;
			if (dbg2)
			{
				Log.WriteToLog("AddThirdPartyGameToList: Game found, checking for hidden attribute");
			}
			bool flag2 = !OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Both");
			if (flag2)
			{
				bool dbg3 = Globals.dbg;
				if (dbg3)
				{
					Log.WriteToLog("AddThirdPartyGameToList: Game is not hidden");
				}
				bool flag3 = !MyProject.Forms.frmProfiles.GameList.ContainsKey(DisplayName);
				if (flag3)
				{
					bool flag4 = !MyProject.Forms.FrmMain.profilePaths.ContainsKey(completePath);
					if (flag4)
					{
						MyProject.Forms.frmProfiles.GameList.Add(DisplayName, completePath);
						Log.WriteToLog("Third-Party App '" + DisplayName + "' added to available games list");
					}
					else
					{
						Log.WriteToLog("Third-Party App '" + DisplayName + "' has a profile, NOT added");
					}
				}
				bool flag5 = !GetGames.manifesDictionary.ContainsKey(DisplayName);
				if (flag5)
				{
					GetGames.manifesDictionary.Add(DisplayName, manifest);
				}
				bool flag6 = File.Exists(assetPath + "\\" + canonName + "_assets\\cover_landscape_image.jpg");
				if (flag6)
				{
					bool flag7 = !GetGames.assetPaths.ContainsKey(DisplayName);
					if (flag7)
					{
						GetGames.assetPaths.Add(DisplayName, assetPath + "\\" + canonName + "_assets");
						bool dbg4 = Globals.dbg;
						if (dbg4)
						{
							Log.WriteToLog(string.Concat(new string[] { "Added ", assetPath, "\\", canonName, "_assets as asset path for '", DisplayName, "'" }));
						}
					}
				}
				else
				{
					bool flag8 = File.Exists(otherAssetPath + "\\" + canonName + "_assets\\cover_landscape_image.jpg");
					if (flag8)
					{
						bool flag9 = !GetGames.assetPaths.ContainsKey(DisplayName);
						if (flag9)
						{
							GetGames.assetPaths.Add(DisplayName, otherAssetPath + "\\" + canonName + "_assets");
							bool dbg5 = Globals.dbg;
							if (dbg5)
							{
								Log.WriteToLog(string.Concat(new string[] { "Added ", otherAssetPath, "\\", canonName, "_assets as asset path for '", DisplayName, "'" }));
							}
						}
					}
					else
					{
						Log.WriteToLog("AddThirdPartyGameToList(): Warning: Could not find asset path for '" + DisplayName + "' in ");
						Log.WriteToLog(string.Concat(new string[] { " -> ", assetPath, "\\", canonName, "_assets" }));
						Log.WriteToLog(string.Concat(new string[] { " -> ", otherAssetPath, "\\", canonName, "_assets" }));
					}
				}
			}
			else
			{
				bool dbg6 = Globals.dbg;
				if (dbg6)
				{
					Log.WriteToLog("AddThirdPartyGameToList: Game is hidden");
				}
			}
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0001ADB0 File Offset: 0x00018FB0
		public static void GetFiles(string p)
		{
			checked
			{
				try
				{
					SQLiteConnection sqliteConnection = new SQLiteConnection();
					string[] array = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",", -1, CompareMethod.Binary);
					string oculusPath = MySettingsProperty.Settings.OculusPath;
					string text = "";
					string text2 = Path.Combine(oculusPath, "CoreData\\Software\\StoreAssets");
					bool flag = (Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0) & !string.IsNullOrWhiteSpace(MySettingsProperty.Settings.LibraryPath.ToString());
					if (flag)
					{
						string text3 = array[0];
						text = Path.Combine(text3, "Software\\StoreAssets");
					}
					bool dbg = Globals.dbg;
					if (dbg)
					{
						Log.WriteToLog("GetApps: Looking for Oculus database");
					}
					bool flag2 = File.Exists(Application.StartupPath + "\\data.sqlite");
					if (flag2)
					{
						bool dbg2 = Globals.dbg;
						if (dbg2)
						{
							Log.WriteToLog("GetApps: Opening database copy");
						}
						try
						{
							bool flag3 = sqliteConnection.State == ConnectionState.Closed;
							if (flag3)
							{
								sqliteConnection = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
								sqliteConnection.Open();
							}
						}
						catch (Exception ex)
						{
							Log.WriteToLog("GetApps: Failed to open database copy: " + ex.Message);
							Interaction.MsgBox("Failed to open database copy: " + ex.Message, MsgBoxStyle.Critical, "Error opening database");
							FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + ex.Message);
							MyProject.Forms.FrmMain.hasError = true;
							return;
						}
						Log.WriteToLog("Parsing Manifests in " + p);
						SQLiteCommand sqliteCommand = new SQLiteCommand(sqliteConnection);
						string[] files = Directory.GetFiles(p, "*.mini");
						int i = 0;
						while (i < files.Length)
						{
							string text4 = files[i];
							try
							{
								bool flag4 = !MyProject.Forms.FrmMain.includedApps.Contains(text4);
								if (flag4)
								{
									bool flag5 = MyProject.Forms.FrmMain.ignoredApps.Contains(text4.Replace(".mini", ""));
									if (flag5)
									{
										bool dbg3 = Globals.dbg;
										if (dbg3)
										{
											Log.WriteToLog("GetApps: " + text4 + " is on the ignore list");
										}
										goto IL_09A3;
									}
								}
								bool dbg4 = Globals.dbg;
								if (dbg4)
								{
									Log.WriteToLog("GetApps: Opening " + text4);
								}
								string text5 = File.ReadAllText(text4);
								JObject jobject = JObject.Parse(text5);
								string text6 = "";
								text6 = jobject.SelectToken("appId").ToString();
								bool flag6 = Operators.CompareString(text6, "", false) != 0;
								if (flag6)
								{
									bool dbg5 = Globals.dbg;
									if (dbg5)
									{
										Log.WriteToLog("    appId is '" + text6 + "'");
									}
									string text7 = jobject.SelectToken("canonicalName").ToString();
									bool dbg6 = Globals.dbg;
									if (dbg6)
									{
										Log.WriteToLog("    canonicalName is '" + text7 + "'");
									}
									string text8 = jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
									bool dbg7 = Globals.dbg;
									if (dbg7)
									{
										Log.WriteToLog("    launchfile is '" + text8 + "'");
									}
									string text9 = string.Concat(new string[]
									{
										p.Replace("\\Manifests", ""),
										"\\Software\\",
										text7.Replace("/", "\\").Replace("\\\\", "\\"),
										"\\",
										text8.Replace("/", "\\").Replace("\\\\", "\\")
									});
									bool dbg8 = Globals.dbg;
									if (dbg8)
									{
										Log.WriteToLog("    completePath is '" + text9 + "'");
									}
									StringBuilder stringBuilder = new StringBuilder();
									try
									{
										sqliteCommand.CommandText = "select value from Objects WHERE hashkey='" + text6 + "' AND typename='Application'";
										using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
										{
											bool hasRows = sqliteDataReader.HasRows;
											if (!hasRows)
											{
												goto IL_09A3;
											}
											while (sqliteDataReader.Read())
											{
												byte[] bytes = GetGames.GetBytes(sqliteDataReader);
												stringBuilder.Append(Encoding.Default.GetString(bytes));
											}
										}
									}
									catch (Exception ex2)
									{
										Log.WriteToLog("GetApps:  -> Failed to read database entry for appId '" + text6 + "': " + ex2.Message);
										FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + text6 + "': " + ex2.Message);
										MyProject.Forms.FrmMain.hasError = true;
										return;
									}
									bool flag7 = stringBuilder.ToString().Contains("FLAT");
									if (flag7)
									{
										bool flag8 = !MyProject.Forms.FrmMain.includedApps.Contains(text4);
										if (flag8)
										{
											bool flag9 = !MyProject.Forms.FrmMain.ignoredApps.Contains(text4);
											if (flag9)
											{
												bool dbg9 = Globals.dbg;
												if (dbg9)
												{
													Log.WriteToLog("GetApps:  ->  App does not appear to be a VR app, adding to ignore list");
												}
												OTTDB.AddIgnoreApp(text4);
												MyProject.Forms.FrmMain.ignoredApps.Add(text4);
											}
											goto IL_09A3;
										}
									}
									string text10 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
									string text11 = "display:name::";
									string text12 = ":display:short:description";
									int num = text10.IndexOf(text11);
									int num2 = text10.IndexOf(text12);
									bool flag10 = num > -1 && num2 > -1;
									if (flag10)
									{
										string text13 = Strings.Mid(text10, num + text11.Length + 1, num2 - num - text11.Length).Replace(":", " ").TrimEnd(new char[] { ':' })
											.TrimEnd(new char[] { ' ' });
										text13 = text13.Remove(text13.Length - 1);
										bool dbg10 = Globals.dbg;
										if (dbg10)
										{
											Log.WriteToLog("    Appname is '" + text13 + "'");
										}
										bool flag11 = (Operators.CompareString(text13, "", false) != 0) & (Operators.CompareString(text9, "", false) != 0);
										if (flag11)
										{
											bool flag12 = !MyProject.Forms.FrmMain.AllAppsList.ContainsKey(text9);
											if (flag12)
											{
												MyProject.Forms.FrmMain.AllAppsList.Add(text9, text13);
												bool dbg11 = Globals.dbg;
												if (dbg11)
												{
													Log.WriteToLog(string.Concat(new string[] { "All Apps List: Added Oculus Store App '", text13, "' with path '", text9, "'" }));
												}
											}
											bool flag13 = !OTTDB.CheckHiddenApp(text8, text13, "Both");
											if (flag13)
											{
												bool flag14 = !MyProject.Forms.frmProfiles.GameList.ContainsKey(text13);
												if (flag14)
												{
													bool flag15 = !MyProject.Forms.FrmMain.profilePaths.ContainsKey(text9);
													if (flag15)
													{
														MyProject.Forms.frmProfiles.GameList.Add(text13, text9);
														Log.WriteToLog("Oculus Store App '" + text13 + "' added to available games list");
													}
													else
													{
														Log.WriteToLog("Oculus Store App '" + text13 + "' has a profile, NOT added");
													}
												}
												bool flag16 = !GetGames.manifesDictionary.ContainsKey(text13);
												if (flag16)
												{
													GetGames.manifesDictionary.Add(text13, text4);
												}
												bool flag17 = File.Exists(text2 + "\\" + text7 + "_assets\\cover_landscape_image.jpg");
												if (flag17)
												{
													bool flag18 = !GetGames.assetPaths.ContainsKey(text13);
													if (flag18)
													{
														GetGames.assetPaths.Add(text13, text2 + "\\" + text7 + "_assets");
														bool dbg12 = Globals.dbg;
														if (dbg12)
														{
															Log.WriteToLog(string.Concat(new string[] { "Added ", text2, "\\", text7, "_assets as asset path for '", text13, "'" }));
														}
													}
												}
												else
												{
													bool flag19 = File.Exists(text + "\\" + text7 + "_assets\\cover_landscape_image.jpg");
													if (flag19)
													{
														bool flag20 = !GetGames.assetPaths.ContainsKey(text13);
														if (flag20)
														{
															GetGames.assetPaths.Add(text13, text + "\\" + text7 + "_assets");
															bool dbg13 = Globals.dbg;
															if (dbg13)
															{
																Log.WriteToLog(string.Concat(new string[] { "Added ", text, "\\", text7, "_assets as asset path for '", text13, "'" }));
															}
														}
													}
													else
													{
														Log.WriteToLog("GetFiles(): Warning: Could not find asset path for '" + text13 + "' in ");
														Log.WriteToLog(string.Concat(new string[] { " -> ", text2, "\\", text7, "_assets" }));
														Log.WriteToLog(string.Concat(new string[] { " -> ", text, "\\", text7, "_assets" }));
													}
												}
											}
										}
									}
								}
							}
							catch (Exception ex3)
							{
								Log.WriteToLog("GetApps:  -> Failed to open manifest file: " + ex3.Message);
							}
							IL_09A3:
							i++;
							continue;
							goto IL_09A3;
						}
						sqliteCommand.Dispose();
						sqliteConnection.Close();
						bool dbg14 = Globals.dbg;
						if (dbg14)
						{
							Log.WriteToLog("GetApps: Connection closed");
						}
					}
				}
				catch (Exception ex4)
				{
					Log.WriteToLog("GetApps: " + ex4.Message);
				}
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0001B848 File Offset: 0x00019A48
		private static string ByteArrayToString(byte[] ba)
		{
			string text = BitConverter.ToString(ba);
			return text.Replace("-", "");
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0001B874 File Offset: 0x00019A74
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
					while (GetGames.InlineAssignHelper<long>(ref num2, reader.GetBytes(0, num, array, 0, array.Length)) > 0L)
					{
						memoryStream.Write(array, 0, (int)num2);
						num += num2;
					}
					array2 = memoryStream.ToArray();
				}
				return array2;
			}
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0001B8F4 File Offset: 0x00019AF4
		private static T InlineAssignHelper<T>(ref T target, T value)
		{
			target = value;
			return value;
		}

		// Token: 0x0400015B RID: 347
		public static Dictionary<string, string> manifesDictionary = new Dictionary<string, string>();

		// Token: 0x0400015C RID: 348
		public static Dictionary<string, string> assetPaths = new Dictionary<string, string>();

		// Token: 0x0400015D RID: 349
		public static List<string> steamGameList = new List<string>();
	}
}
