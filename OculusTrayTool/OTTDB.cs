using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x0200003F RID: 63
	[StandardModule]
	internal sealed class OTTDB
	{
		// Token: 0x06000540 RID: 1344 RVA: 0x00028F34 File Offset: 0x00027134
		public static void OpenOttDB()
		{
			try
			{
				bool flag = false;
				bool flag2 = File.Exists(Application.StartupPath + "\\ott.db");
				if (flag2)
				{
					flag = true;
				}
				bool flag3 = !flag;
				if (flag3)
				{
					Log.WriteToLog("ott.db not found, creating..");
					OTTDB.ott_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\ott.db");
					OTTDB.ott_cnn.Open();
					new SQLiteCommand(OTTDB.ott_cnn)
					{
						CommandText = "CREATE TABLE `profiles` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`PPDP`\tTEXT DEFAULT '0',`ASW` TEXT Default 'Inherit',`Priority` TEXT Default 'Normal',`LaunchFile` TEXT,`Path` TEXT,`Method` TEXT,`ASWDelay`\tTEXT DEFAULT '5',`CPUDelay` TEXT DEFAULT '5',`Mirror` TEXT DEFAULT '0',`GPUScaling` TEXT DEFAULT '1',`Comment` TEXT DEFAULT '',`FOV` TEXT DEFAULT '0.0 0.0',`ForceMipMap` TEXT DEFAULT 'False',`OffsetMipMap` TEXT DEFAULT '0',`Enabled` TEXT DEFAULT 'Yes');"
					}.ExecuteNonQuery();
					new SQLiteCommand(OTTDB.ott_cnn)
					{
						CommandText = "CREATE TABLE `hiddenApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`LaunchFile` TEXT,`Location` TEXT);"
					}.ExecuteNonQuery();
					new SQLiteCommand(OTTDB.ott_cnn)
					{
						CommandText = "CREATE TABLE `ignoredApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);"
					}.ExecuteNonQuery();
					new SQLiteCommand(OTTDB.ott_cnn)
					{
						CommandText = "CREATE TABLE `knownApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT,`DisplayName` TEXT,`LaunchFile` TEXT,`CompletePath` TEXT,`AssetFile` TEXT);"
					}.ExecuteNonQuery();
					new SQLiteCommand(OTTDB.ott_cnn)
					{
						CommandText = "CREATE TABLE `customVoice` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Type` TEXT,`Action` TEXT,`Command` TEXT,`Enabled` INTEGER);"
					}.ExecuteNonQuery();
					new SQLiteCommand(OTTDB.ott_cnn)
					{
						CommandText = "CREATE TABLE `includedApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);"
					}.ExecuteNonQuery();
					new SQLiteCommand(OTTDB.ott_cnn)
					{
						CommandText = "CREATE TABLE `LinkPresets` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Name` TEXT,`Curve` TEXT,`Encoding` TEXT,`Bitrate` TEXT,`Sharpening` TEXT,`DBR` TEXT);"
					}.ExecuteNonQuery();
				}
				else
				{
					bool flag4 = OTTDB.ott_cnn.State == ConnectionState.Closed;
					if (flag4)
					{
						Log.WriteToLog("Opening connection to ott.db");
						OTTDB.ott_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\ott.db");
						OTTDB.ott_cnn.Open();
					}
					SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
					sqliteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='ignoredApps'";
					using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
					{
						bool flag5 = !sqliteDataReader.HasRows;
						if (flag5)
						{
							sqliteDataReader.Close();
							try
							{
								sqliteCommand.CommandText = "CREATE TABLE IF Not EXISTS `ignoredApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);";
								sqliteCommand.ExecuteNonQuery();
								Log.WriteToLog("Created missing table 'ignoredApps'");
							}
							catch (Exception ex)
							{
								Log.WriteToLog("Error creating table 'ignoredApps': " + ex.Message);
							}
						}
					}
					sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
					sqliteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='knownApps'";
					using (SQLiteDataReader sqliteDataReader2 = sqliteCommand.ExecuteReader())
					{
						bool flag6 = !sqliteDataReader2.HasRows;
						if (flag6)
						{
							sqliteDataReader2.Close();
							try
							{
								sqliteCommand.CommandText = "CREATE TABLE IF Not EXISTS `knownApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT,`DisplayName` TEXT,`LaunchFile` TEXT,`CompletePath` TEXT,`AssetFile` TEXT);";
								sqliteCommand.ExecuteNonQuery();
								Log.WriteToLog("Created missing table 'knownApps'");
							}
							catch (Exception ex2)
							{
								Log.WriteToLog("Error creating table 'knownApps': " + ex2.Message);
							}
						}
					}
					sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
					sqliteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='profiles'";
					using (SQLiteDataReader sqliteDataReader3 = sqliteCommand.ExecuteReader())
					{
						bool flag7 = !sqliteDataReader3.HasRows;
						if (flag7)
						{
							sqliteDataReader3.Close();
							try
							{
								sqliteCommand.CommandText = "CREATE TABLE IF Not EXISTS `profiles` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`PPDP`\tTEXT DEFAULT '0',`ASW` TEXT Default 'Inherit',`Priority` TEXT Default 'Normal',`LaunchFile` TEXT,`Path` TEXT,`Method` TEXT,`ASWDelay`\tTEXT DEFAULT '5',`CPUDelay` DEFAULT '5',`Mirror` TEXT DEFAULT '0',`GPUScaling` TEXT DEFAULT '1',`Comment` TEXT DEFAULT '',`FOV` TEXT DEFAULT '0.0 0.0',`ForceMipMap` TEXT DEFAULT 'False',`OffsetMipMap` TEXT DEFAULT '0',`Enabled` TEXT DEFAULT 'Yes');";
								sqliteCommand.ExecuteNonQuery();
								Log.WriteToLog("Created missing table 'profiles'");
							}
							catch (Exception ex3)
							{
								Log.WriteToLog("Error creating table 'profiles': " + ex3.Message);
							}
						}
						else
						{
							try
							{
								bool flag8 = !OTTDB.CheckIfColumnExists("profiles", "ASWDelay", OTTDB.ott_cnn);
								if (flag8)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN ASWDelay Default 5"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'ASWDelay'");
								}
							}
							catch (Exception ex4)
							{
								Log.WriteToLog("Error adding missing column 'ASWDelay': " + ex4.Message);
							}
							try
							{
								bool flag9 = !OTTDB.CheckIfColumnExists("profiles", "CPUDelay", OTTDB.ott_cnn);
								if (flag9)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN CPUDelay Default 5"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'CPUDelay'");
								}
							}
							catch (Exception ex5)
							{
								Log.WriteToLog("Error adding missing column 'CPUDelay': " + ex5.Message);
							}
							try
							{
								bool flag10 = !OTTDB.CheckIfColumnExists("profiles", "Mirror", OTTDB.ott_cnn);
								if (flag10)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN Mirror Default 0"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'Mirror'");
								}
							}
							catch (Exception ex6)
							{
								Log.WriteToLog("Error adding missing column 'Mirror': " + ex6.Message);
							}
							try
							{
								bool flag11 = !OTTDB.CheckIfColumnExists("profiles", "GPUScaling", OTTDB.ott_cnn);
								if (flag11)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN GPUScaling Default 1"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'GPUScaling'");
								}
							}
							catch (Exception ex7)
							{
								Log.WriteToLog("Error adding missing column 'GPUScaling': " + ex7.Message);
							}
							try
							{
								bool flag12 = !OTTDB.CheckIfColumnExists("profiles", "Comment", OTTDB.ott_cnn);
								if (flag12)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN Comment Default ''"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'Comment'");
								}
							}
							catch (Exception ex8)
							{
								Log.WriteToLog("Error adding missing column 'Comment': " + ex8.Message);
							}
							try
							{
								bool flag13 = !OTTDB.CheckIfColumnExists("profiles", "FOV", OTTDB.ott_cnn);
								if (flag13)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN FOV Default '0.0 0.0'"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'FOV'");
								}
							}
							catch (Exception ex9)
							{
								Log.WriteToLog("Error adding missing column 'FOV': " + ex9.Message);
							}
							try
							{
								bool flag14 = !OTTDB.CheckIfColumnExists("profiles", "ForceMipMap", OTTDB.ott_cnn);
								if (flag14)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN ForceMipMap Default 'False'"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'ForceMipMap'");
								}
							}
							catch (Exception ex10)
							{
								Log.WriteToLog("Error adding missing column 'ForceMipMap': " + ex10.Message);
							}
							try
							{
								bool flag15 = !OTTDB.CheckIfColumnExists("profiles", "OffsetMipMap", OTTDB.ott_cnn);
								if (flag15)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN OffsetMipMap Default '0'"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'OffsetMipMap'");
								}
							}
							catch (Exception ex11)
							{
								Log.WriteToLog("Error adding missing column 'OffsetMipMap': " + ex11.Message);
							}
							try
							{
								bool flag16 = !OTTDB.CheckIfColumnExists("profiles", "Enabled", OTTDB.ott_cnn);
								if (flag16)
								{
									new SQLiteCommand(OTTDB.ott_cnn)
									{
										CommandText = "ALTER TABLE profiles ADD COLUMN Enabled Default 'Yes'"
									}.ExecuteNonQuery();
									Log.WriteToLog("Added missing column 'Enabled'");
								}
							}
							catch (Exception ex12)
							{
								Log.WriteToLog("Error adding missing column 'Enabled': " + ex12.Message);
							}
						}
					}
					sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
					sqliteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='hiddenApps'";
					using (SQLiteDataReader sqliteDataReader4 = sqliteCommand.ExecuteReader())
					{
						bool flag17 = !sqliteDataReader4.HasRows;
						if (flag17)
						{
							sqliteDataReader4.Close();
							try
							{
								sqliteCommand.CommandText = "CREATE TABLE IF Not EXISTS `hiddenApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`LaunchFile` TEXT,`Location` TEXT);";
								sqliteCommand.ExecuteNonQuery();
								Log.WriteToLog("Created missing table 'hiddenApps'");
							}
							catch (Exception ex13)
							{
								Log.WriteToLog("Error creating table 'hiddenApps': " + ex13.Message);
							}
						}
					}
					sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
					sqliteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='customVoice'";
					using (SQLiteDataReader sqliteDataReader5 = sqliteCommand.ExecuteReader())
					{
						bool flag18 = !sqliteDataReader5.HasRows;
						if (flag18)
						{
							sqliteDataReader5.Close();
							try
							{
								sqliteCommand.CommandText = "CREATE TABLE IF Not EXISTS `customVoice` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Type` TEXT,`Action` TEXT,`Command` TEXT,`Enabled` TEXT);";
								sqliteCommand.ExecuteNonQuery();
								Log.WriteToLog("Created missing table 'customVoice'");
							}
							catch (Exception ex14)
							{
								Log.WriteToLog("Error creating table 'customVoice': " + ex14.Message);
							}
						}
					}
					sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
					sqliteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='includedApps'";
					using (SQLiteDataReader sqliteDataReader6 = sqliteCommand.ExecuteReader())
					{
						bool flag19 = !sqliteDataReader6.HasRows;
						if (flag19)
						{
							sqliteDataReader6.Close();
							try
							{
								sqliteCommand.CommandText = "CREATE TABLE IF Not EXISTS `includedApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);";
								sqliteCommand.ExecuteNonQuery();
								Log.WriteToLog("Created missing table 'includedApps'");
							}
							catch (Exception ex15)
							{
								Log.WriteToLog("Error creating table 'includedApps': " + ex15.Message);
							}
						}
					}
					sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
					sqliteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='LinkPresets'";
					using (SQLiteDataReader sqliteDataReader7 = sqliteCommand.ExecuteReader())
					{
						bool flag20 = !sqliteDataReader7.HasRows;
						if (flag20)
						{
							sqliteDataReader7.Close();
							try
							{
								sqliteCommand.CommandText = "CREATE TABLE IF Not EXISTS `LinkPresets` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Name` TEXT,`Curve` TEXT,`Encoding` TEXT,`Bitrate` TEXT,`Sharpening` TEXT,`DBR` TEXT);";
								sqliteCommand.ExecuteNonQuery();
								Log.WriteToLog("Created missing table 'LinkPresets'");
							}
							catch (Exception ex16)
							{
								Log.WriteToLog("Error creating table 'LinkPresets': " + ex16.Message);
							}
						}
						try
						{
							bool flag21 = !OTTDB.CheckIfColumnExists("LinkPresets", "Bitrate", OTTDB.ott_cnn);
							if (flag21)
							{
								new SQLiteCommand(OTTDB.ott_cnn)
								{
									CommandText = "ALTER TABLE LinkPresets ADD COLUMN Bitrate Default 150"
								}.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'Bitrate'");
							}
						}
						catch (Exception ex17)
						{
							Log.WriteToLog("Error adding missing column 'Bitrate': " + ex17.Message);
						}
						try
						{
							bool flag22 = !OTTDB.CheckIfColumnExists("LinkPresets", "Sharpening", OTTDB.ott_cnn);
							if (flag22)
							{
								new SQLiteCommand(OTTDB.ott_cnn)
								{
									CommandText = "ALTER TABLE LinkPresets ADD COLUMN Sharpening Default 0"
								}.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'Sharpening'");
							}
						}
						catch (Exception ex18)
						{
							Log.WriteToLog("Error adding missing column 'Sharpening': " + ex18.Message);
						}
						try
						{
							bool flag23 = !OTTDB.CheckIfColumnExists("LinkPresets", "DBR", OTTDB.ott_cnn);
							if (flag23)
							{
								new SQLiteCommand(OTTDB.ott_cnn)
								{
									CommandText = "ALTER TABLE LinkPresets ADD COLUMN DBR Default 0"
								}.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'DBR'");
							}
						}
						catch (Exception ex19)
						{
							Log.WriteToLog("Error adding missing column 'DBR': " + ex19.Message);
						}
					}
				}
				Log.WriteToLog("Database is open for business");
			}
			catch (Exception ex20)
			{
				Log.WriteToLog("OpenOttDb " + ex20.Message);
			}
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00029D60 File Offset: 0x00027F60
		private static bool CheckIfColumnExists(string tableName, string columnName, SQLiteConnection cnn)
		{
			SQLiteCommand sqliteCommand = cnn.CreateCommand();
			sqliteCommand.CommandText = string.Format("PRAGMA table_info({0})", tableName);
			SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			int ordinal = sqliteDataReader.GetOrdinal("Name");
			while (sqliteDataReader.Read())
			{
				bool flag = sqliteDataReader.GetString(ordinal).Equals(columnName);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00029DC8 File Offset: 0x00027FC8
		public static void GetVoiceProfileNames()
		{
			Log.WriteToLog("Reading voice profiles");
			MyProject.Forms.FrmMain.voiceProfileNames.Clear();
			using (SQLiteDataReader sqliteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
			{
				CommandText = "select distinct Name from userVoice"
			}.ExecuteReader())
			{
				bool hasRows = sqliteDataReader.HasRows;
				if (hasRows)
				{
					while (sqliteDataReader.Read())
					{
						MyProject.Forms.FrmMain.voiceProfileNames.Add(Conversions.ToString(sqliteDataReader[0]));
					}
				}
			}
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00029E70 File Offset: 0x00028070
		public static object GetVoiceProfileCommands(string profileName)
		{
			SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
			List<string> list = new List<string>();
			sqliteCommand.CommandText = "select SpokenCommand,Actions,GameProfile from userVoice where Name = \"" + profileName + "\"";
			using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
			{
				bool hasRows = sqliteDataReader.HasRows;
				if (hasRows)
				{
					while (sqliteDataReader.Read())
					{
						list.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(sqliteDataReader[0], "|"), sqliteDataReader[1]), "|"), sqliteDataReader[2])));
					}
				}
			}
			return list;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00029F30 File Offset: 0x00028130
		public static void AddVoiceProfileCommand(string voiceProfile, string gameProfile, string spoken, string actions)
		{
			new SQLiteCommand(OTTDB.ott_cnn)
			{
				CommandText = string.Concat(new string[] { "insert Or replace into userVoice (ID, Name, SpokenCommand, Actions, GameProfile) values ((select ID from userVoice where SpokenCommand = \"", spoken, "\"), \"", voiceProfile, "\",\"", spoken, "\",\"", actions, "\")" })
			}.ExecuteNonQuery();
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00029F9C File Offset: 0x0002819C
		public static void GetProfiles()
		{
			Log.WriteToLog("Reading profiles");
			MyProject.Forms.FrmMain.profileList.Clear();
			MyProject.Forms.FrmMain.profileTimerList.Clear();
			MyProject.Forms.FrmMain.profileNames.Clear();
			MyProject.Forms.FrmMain.profileASWList.Clear();
			MyProject.Forms.FrmMain.profileDisplayNames.Clear();
			MyProject.Forms.FrmMain.profilePriorityList.Clear();
			MyProject.Forms.FrmMain.profileAswDelay.Clear();
			MyProject.Forms.FrmMain.profileCpuDelay.Clear();
			MyProject.Forms.frmLibrary.ManualStartProfiles.Clear();
			MyProject.Forms.FrmMain.profilePaths.Clear();
			MyProject.Forms.FrmMain.profileMirror.Clear();
			MyProject.Forms.FrmMain.profileAGPS.Clear();
			MyProject.Forms.FrmMain.profileFOV.Clear();
			MyProject.Forms.FrmMain.profileForceMipMap.Clear();
			MyProject.Forms.FrmMain.profileOffsetMipMap.Clear();
			MyProject.Forms.frmProfiles.ListView1.Items.Clear();
			MyProject.Forms.frmLibrary.DisplayNameList.Clear();
			GetConfig.numprofiles = 0;
			int num = 0;
			OTTDB.numWMI = 0;
			OTTDB.numTimer = 0;
			SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
			checked
			{
				try
				{
					sqliteCommand.CommandText = "select * from profiles";
					using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
					{
						bool hasRows = sqliteDataReader.HasRows;
						if (hasRows)
						{
							while (sqliteDataReader.Read())
							{
								string text = Conversions.ToString(sqliteDataReader[1]);
								string text2 = Conversions.ToString(sqliteDataReader[2]);
								string text3 = Conversions.ToString(sqliteDataReader[3]);
								string text4 = Conversions.ToString(sqliteDataReader[4]);
								string text5 = Conversions.ToString(sqliteDataReader[5]);
								string text6 = Conversions.ToString(sqliteDataReader[6]);
								string text7 = Conversions.ToString(sqliteDataReader[7]);
								string text8 = Conversions.ToString((sqliteDataReader.FieldCount > 8) ? sqliteDataReader[8] : "5");
								string text9 = Conversions.ToString((sqliteDataReader.FieldCount > 9) ? sqliteDataReader[9] : "5");
								string text10 = Conversions.ToString(sqliteDataReader[10]);
								string text11 = Conversions.ToString(sqliteDataReader[11]);
								string text12 = Conversions.ToString(sqliteDataReader[12]);
								string text13 = Conversions.ToString(sqliteDataReader[13]);
								string text14 = Conversions.ToString(sqliteDataReader[14]);
								string text15 = Conversions.ToString(sqliteDataReader[15]);
								string text16 = Conversions.ToString(sqliteDataReader[16]);
								bool flag = Operators.CompareString(text16, "No", false) == 0;
								if (flag)
								{
									num++;
								}
								try
								{
									foreach (KeyValuePair<string, string> keyValuePair in MyProject.Forms.frmProfiles.GameList)
									{
										bool flag2 = Operators.CompareString(keyValuePair.Value, text6, false) == 0;
										if (flag2)
										{
											MyProject.Forms.frmProfiles.GameList.Remove(keyValuePair.Key);
											break;
										}
									}
								}
								finally
								{
									Dictionary<string, string>.Enumerator enumerator;
									((IDisposable)enumerator).Dispose();
								}
								MyProject.Forms.frmLibrary.DisplayNameList.Add(text.ToLower());
								ListViewItem listViewItem = new ListViewItem();
								listViewItem = MyProject.Forms.frmProfiles.ListView1.Items.Add(text);
								listViewItem.Tag = string.Concat(new string[]
								{
									text, ",", text2, ",", text3, ",", text7, ",", text4, ",",
									text6, ",", text8, ",", text9, ",", text10, ",", text11, ",",
									text12, ",", text13, ",", text14, ",", text15, ",", text16
								});
								listViewItem.SubItems.Add(text2);
								listViewItem.SubItems.Add(text3);
								listViewItem.SubItems.Add(text4);
								listViewItem.SubItems.Add(text16);
								bool dbg = Globals.dbg;
								if (dbg)
								{
									Log.WriteToLog(string.Concat(new string[]
									{
										text, ",", text3, ",", text2, ",", text4, ",", text5, ",",
										text6, ",", text7
									}));
								}
								GetConfig.numprofiles++;
								bool flag3 = Operators.CompareString(text16, "Yes", false) == 0;
								if (flag3)
								{
									MyProject.Forms.FrmMain.profileDisplayNames.Add(text6, text);
									bool flag4 = Operators.CompareString(text7, "WMI", false) == 0;
									if (flag4)
									{
										MyProject.Forms.FrmMain.profileList.Add(text6.ToLower(), text2);
										OTTDB.numWMI++;
									}
									bool flag5 = Operators.CompareString(text7, "Timer", false) == 0;
									if (flag5)
									{
										MyProject.Forms.FrmMain.profileTimerList.Add(text6, text2);
										OTTDB.numTimer++;
									}
									MyProject.Forms.frmLibrary.ManualStartProfiles.Add(text6.ToLower(), text2);
									MyProject.Forms.FrmMain.profileASWList.Add(text6.ToLower(), text3);
									bool flag6 = Operators.CompareString(text4, "Default", false) != 0;
									if (flag6)
									{
										MyProject.Forms.FrmMain.profilePriorityList.Add(text6.ToLower(), text4);
										MyProject.Forms.FrmMain.profileCpuDelay.Add(text6.ToLower(), text9);
									}
									MyProject.Forms.FrmMain.profileNames.Add(text6);
									MyProject.Forms.FrmMain.profileAswDelay.Add(text6.ToLower(), text8);
									MyProject.Forms.FrmMain.profilePaths.Add(text6, text5);
									MyProject.Forms.FrmMain.profileMirror.Add(text6.ToLower(), text10);
									MyProject.Forms.FrmMain.profileAGPS.Add(text6.ToLower(), text11);
									MyProject.Forms.FrmMain.profileFOV.Add(text6.ToLower(), text13);
									MyProject.Forms.FrmMain.profileOffsetMipMap.Add(text6.ToLower(), text15);
									MyProject.Forms.FrmMain.profileForceMipMap.Add(text6.ToLower(), text14);
								}
							}
						}
					}
					Log.WriteToLog(Conversions.ToString(GetConfig.numprofiles) + " profiles found");
					Log.WriteToLog(Conversions.ToString(num) + " profiles are disabled");
					Log.WriteToLog("  " + Conversions.ToString(OTTDB.numWMI) + " monitored using WMI");
					Log.WriteToLog("  " + Conversions.ToString(OTTDB.numTimer) + " monitored using Timer");
				}
				catch (Exception ex)
				{
					Log.WriteToLog("GetProfiles(): " + ex.Message);
				}
			}
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0002A814 File Offset: 0x00028A14
		public static void AddProfile(string displayname, string asw, string ppdp, string priority, string LaunchFile, string path, string method, string aswdelay, string cpudelay, string mirror, string agps, string comment, string fov, string forcemipmap, string offsetmipmap, string enabled)
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = string.Concat(new string[]
					{
						"insert Or replace into profiles (ID, DisplayName, PPDP, ASW, Priority, LaunchFile, Path, Method, ASWDelay, CPUDelay, Mirror, GPUScaling, Comment, FOV, ForceMipMap, OffsetMipMap, Enabled) values ((select ID from Profiles where Path = \"", path, "\"), \"", displayname, "\",\"", ppdp, "\",\"", asw, "\",\"", priority,
						"\",\"", LaunchFile, "\",\"", path, "\",\"", method, "\",\"", aswdelay, "\",\"", cpudelay,
						"\",\"", mirror, "\",\"", agps, "\",\"", comment, "\",\"", fov, "\",\"", forcemipmap,
						"\",\"", offsetmipmap, "\",\"", enabled, "\")"
					})
				}.ExecuteNonQuery();
				Log.WriteToLog("Profile updated");
				Log.WriteToLog("  Display Name: " + displayname);
				Log.WriteToLog("  Super Sampling: " + ppdp);
				Log.WriteToLog("  ASW: " + asw);
				Log.WriteToLog("  CPU Priority: " + priority);
				Log.WriteToLog("  Launch File: " + LaunchFile);
				Log.WriteToLog("  Detection Method: " + method);
				Log.WriteToLog("  Path: " + path);
				Log.WriteToLog("  ASW Delay: " + aswdelay);
				Log.WriteToLog("  CPU Delay: " + cpudelay);
				Log.WriteToLog("  Mirror: " + mirror);
				Log.WriteToLog("  GPU Scaling: " + agps);
				Log.WriteToLog("  Comment: " + comment);
				Log.WriteToLog("  FOV: " + fov);
				Log.WriteToLog("  Force MipMap On Layers: " + forcemipmap);
				Log.WriteToLog("  Offset MipMap On Layers: " + offsetmipmap);
				Log.WriteToLog("  Enabled: " + enabled);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("AddProfile: " + ex.Message);
			}
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0002AAB0 File Offset: 0x00028CB0
		public static void UpdateProfile(string asw, string ppdp, string path, string name)
		{
			try
			{
				SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
				bool flag = Operators.CompareString(asw, null, false) != 0;
				if (flag)
				{
					sqliteCommand.CommandText = string.Concat(new string[] { "UPDATE profiles SET ASW=", asw, " WHERE Path = \"", path, "\"" });
					sqliteCommand.ExecuteNonQuery();
					Log.WriteToLog(string.Concat(new string[] { "Updated '", name, "'. New ASW setting is '", asw, "'" }));
				}
				bool flag2 = Operators.CompareString(ppdp, null, false) != 0;
				if (flag2)
				{
					sqliteCommand.CommandText = string.Concat(new string[] { "UPDATE profiles SET PPDP=", ppdp, " WHERE Path = \"", path, "\"" });
					sqliteCommand.ExecuteNonQuery();
					Log.WriteToLog(string.Concat(new string[] { "Updated '", name, "'. New Pixel Density setting is '", ppdp, "'" }));
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("UpdateProfile: " + ex.Message);
			}
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0002AC04 File Offset: 0x00028E04
		public static void RemoveProfile(string Path)
		{
			try
			{
				SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
				string displayName = OTTDB.GetDisplayName(Path);
				sqliteCommand.CommandText = "delete from profiles where path = \"" + Path + "\"";
				sqliteCommand.ExecuteNonQuery();
				Log.WriteToLog("Profile for '" + displayName + "' has been removed");
				FrmMain.fmain.AddToListboxAndScroll("Profile for '" + displayName + "' has been removed");
			}
			catch (Exception ex)
			{
				Log.WriteToLog("RemoveProfile: " + ex.Message);
			}
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0002ACAC File Offset: 0x00028EAC
		public static void RemoveAllProfiles()
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = "delete from profiles"
				}.ExecuteNonQuery();
				Log.WriteToLog("All Profiles have been removed");
				FrmMain.fmain.AddToListboxAndScroll("All Profiles have been removed");
				MyProject.Forms.frmProfiles.ListView1.Items.Clear();
				OTTDB.GetProfiles();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("RemoveAllProfiles: " + ex.Message);
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0002AD4C File Offset: 0x00028F4C
		public static void HideApp(string displayname, string launchfile, string location)
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = string.Concat(new string[]
					{
						"insert or replace into hiddenApps (ID, DisplayName, LaunchFile, Location) values ((select ID from hiddenApps where LaunchFile = \"", launchfile, "\" AND DisplayName = \"", displayname, "\"), \"", displayname, "\",\"", launchfile, "\",\"", location,
						"\")"
					})
				}.ExecuteNonQuery();
				Log.WriteToLog("App hidden: " + displayname);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("HideApp: " + ex.Message);
			}
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0002AE10 File Offset: 0x00029010
		public static void UnHideApp(string displayname)
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = "DELETE from hiddenApps where DisplayName = \"" + displayname + "\""
				}.ExecuteNonQuery();
				Log.WriteToLog("App Visible: " + displayname);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("UnHideApp: " + ex.Message);
			}
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0002AE94 File Offset: 0x00029094
		public static bool CheckHiddenApp(string launchfile, string displayname, string location)
		{
			return Operators.ConditionalCompareObjectNotEqual(new SQLiteCommand(OTTDB.ott_cnn)
			{
				CommandText = string.Concat(new string[] { "select * from hiddenApps where DisplayName = \"", displayname, "\" AND Location = \"", location, "\" AND LaunchFile = \"", launchfile, "\"" })
			}.ExecuteScalar(), 0, false);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0002AF0C File Offset: 0x0002910C
		public static object GetHiddenApps()
		{
			SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
			List<string> list = new List<string>();
			sqliteCommand.CommandText = "select DisplayName from hiddenApps";
			using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
			{
				bool hasRows = sqliteDataReader.HasRows;
				if (hasRows)
				{
					while (sqliteDataReader.Read())
					{
						list.Add(Conversions.ToString(sqliteDataReader[0]));
					}
				}
			}
			return list;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0002AF94 File Offset: 0x00029194
		public static object GetIgnoredApps()
		{
			SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
			List<string> list = new List<string>();
			sqliteCommand.CommandText = "select FileName from ignoredApps";
			using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
			{
				bool hasRows = sqliteDataReader.HasRows;
				if (hasRows)
				{
					while (sqliteDataReader.Read())
					{
						list.Add(Conversions.ToString(sqliteDataReader[0]));
						bool flag = !File.Exists(Conversions.ToString(sqliteDataReader[0]));
						if (flag)
						{
							OTTDB.RemoveIgnoredApp(Conversions.ToString(sqliteDataReader[0]));
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0002B048 File Offset: 0x00029248
		public static object GetIncludedApps()
		{
			SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
			List<string> list = new List<string>();
			sqliteCommand.CommandText = "select FileName from includedApps";
			using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
			{
				bool hasRows = sqliteDataReader.HasRows;
				if (hasRows)
				{
					while (sqliteDataReader.Read())
					{
						list.Add(Conversions.ToString(sqliteDataReader[0]));
						bool flag = !File.Exists(Conversions.ToString(sqliteDataReader[0]));
						if (flag)
						{
							OTTDB.RemoveIncludedApp(Conversions.ToString(sqliteDataReader[0]));
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0002B0FC File Offset: 0x000292FC
		public static void RemoveIgnoredApp(string name)
		{
			new SQLiteCommand(OTTDB.ott_cnn)
			{
				CommandText = "delete from ignoredApps where FileName = \"" + name + "\""
			}.ExecuteNonQuery();
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0002B134 File Offset: 0x00029334
		public static void RemoveIncludedApp(string name)
		{
			new SQLiteCommand(OTTDB.ott_cnn)
			{
				CommandText = "delete from includedApps where FileName = \"" + name + "\""
			}.ExecuteNonQuery();
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0002B16C File Offset: 0x0002936C
		public static object GetknownApps()
		{
			SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
			List<string> list = new List<string>();
			sqliteCommand.CommandText = "select FileName from knownApps";
			using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
			{
				bool hasRows = sqliteDataReader.HasRows;
				if (hasRows)
				{
					while (sqliteDataReader.Read())
					{
						list.Add(Conversions.ToString(sqliteDataReader[0]));
					}
				}
			}
			return list;
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0002B1F4 File Offset: 0x000293F4
		public static object GetknownAppDetails(string filename)
		{
			string text;
			using (SQLiteDataReader sqliteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
			{
				CommandText = "select DisplayName, LaunchFile, CompletePath, AssetFile from knownApps where FileName = \"" + filename + "\""
			}.ExecuteReader())
			{
				bool hasRows = sqliteDataReader.HasRows;
				if (hasRows)
				{
					while (sqliteDataReader.Read())
					{
						text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(sqliteDataReader[0], ","), sqliteDataReader[1]), ","), sqliteDataReader[2]), ","), sqliteDataReader[3]));
					}
				}
			}
			return text;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0002B2BC File Offset: 0x000294BC
		public static void AddKnownApp(string filename, string displayname, string launchfile, string completepath, string assetfile)
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = string.Concat(new string[]
					{
						"insert into knownApps (FileName, DisplayName, LaunchFile, CompletePath, AssetFile) values (\"", filename, "\",\"", displayname, "\",\"", launchfile, "\",\"", completepath, "\",\"", assetfile,
						"\")"
					})
				}.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("AddKnownApp: " + ex.Message);
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0002B370 File Offset: 0x00029570
		public static void AddIgnoreApp(string filename)
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = "insert into ignoredApps (FileName) values (\"" + filename + "\")"
				}.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("AddIgnoreApp: " + ex.Message);
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0002B3E0 File Offset: 0x000295E0
		public static void AddIncludedApp(string filename)
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = "insert into includedApps (FileName) values (\"" + filename + "\")"
				}.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("AddIncludedApp: " + ex.Message);
			}
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0002B450 File Offset: 0x00029650
		public static string GetDisplayName(string path)
		{
			string text;
			try
			{
				using (SQLiteDataReader sqliteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = "select DisplayName from Profiles where Path = \"" + path + "\" COLLATE NOCASE"
				}.ExecuteReader())
				{
					bool hasRows = sqliteDataReader.HasRows;
					if (hasRows && sqliteDataReader.Read())
					{
						text = Conversions.ToString(sqliteDataReader[0]);
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("UpdateProfile: " + ex.Message);
			}
			return text;
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0002B508 File Offset: 0x00029708
		public static void AddLinkPreset(string name, string curve, string encoding, string bitrate, string sharpening, string dbr)
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = string.Concat(new string[]
					{
						"insert or replace into LinkPresets (ID, Name, Curve, Encoding, Bitrate, Sharpening, DBR) values ((select ID from LinkPresets where Name = \"", name, "\"), \"", name, "\",\"", curve, "\",\"", encoding, "\",\"", bitrate,
						"\",\"", sharpening, "\",\"", dbr, "\")"
					})
				}.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("AddLinkPreset: " + ex.Message);
			}
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0002B5D8 File Offset: 0x000297D8
		public static string GetLinkPresetValueByName(string name, string value)
		{
			string text;
			try
			{
				using (SQLiteDataReader sqliteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = string.Concat(new string[] { "select ", value, " from LinkPresets where Name = \"", name, "\" COLLATE NOCASE" })
				}.ExecuteReader())
				{
					bool hasRows = sqliteDataReader.HasRows;
					if (hasRows && sqliteDataReader.Read())
					{
						text = Conversions.ToString(sqliteDataReader[0]);
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetLinkPresetValueByName: " + ex.Message);
			}
			return text;
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0002B6AC File Offset: 0x000298AC
		public static string GetLinkPresetValueByValues(string curve, string encoding, string bitrate, string sharpening, string dbr)
		{
			string text;
			try
			{
				using (SQLiteDataReader sqliteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = string.Concat(new string[]
					{
						"select Name from LinkPresets where Curve = \"", curve, "\" AND Encoding = \"", encoding, "\" AND Bitrate = \"", bitrate, "\" AND Sharpening = \"", sharpening, "\" AND DBR = \"", dbr,
						"\""
					})
				}.ExecuteReader())
				{
					bool hasRows = sqliteDataReader.HasRows;
					if (hasRows && sqliteDataReader.Read())
					{
						text = Conversions.ToString(sqliteDataReader[0]);
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetLinkPresetValueByValues: " + ex.Message);
			}
			return text;
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0002B7A8 File Offset: 0x000299A8
		public static string RemoveLinkPresetByName(string name)
		{
			try
			{
				new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = "delete from LinkPresets where Name = \"" + name + "\""
				}.ExecuteNonQuery();
				Log.WriteToLog("Link Preset '" + name + "' has been removed");
				FrmMain.fmain.AddToListboxAndScroll("Link Preset '" + name + "' has been removed");
			}
			catch (Exception ex)
			{
				Log.WriteToLog("RemoveLinkPresetValueByName: " + ex.Message);
			}
			string text;
			return text;
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0002B84C File Offset: 0x00029A4C
		public static List<string> GetLinkPresetNames()
		{
			try
			{
				List<string> list = new List<string>();
				using (SQLiteDataReader sqliteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
				{
					CommandText = "select Name from LinkPresets"
				}.ExecuteReader())
				{
					bool hasRows = sqliteDataReader.HasRows;
					if (hasRows)
					{
						while (sqliteDataReader.Read())
						{
							FrmMain.fmain.ComboBox4.Items.Add(RuntimeHelpers.GetObjectValue(sqliteDataReader[0]));
							list.Add(Conversions.ToString(sqliteDataReader[0]));
						}
					}
				}
				bool flag = !list.Contains("GTX 970+");
				if (flag)
				{
					OTTDB.AddLinkPreset("GTX 970+", "Default", "2016", "300", "Auto", "0");
					FrmMain.fmain.ComboBox4.Items.Add("GTX 970+");
				}
				bool flag2 = !list.Contains("GTX 1070+");
				if (flag2)
				{
					OTTDB.AddLinkPreset("GTX 1070+", "High", "2352", "350", "Auto", "0");
					FrmMain.fmain.ComboBox4.Items.Add("GTX 1070+");
				}
				bool flag3 = !list.Contains("RTX 2070+");
				if (flag3)
				{
					OTTDB.AddLinkPreset("RTX 2070+", "Low", "2912", "400", "Auto", "0");
					FrmMain.fmain.ComboBox4.Items.Add("RTX 2070+");
				}
				bool flag4 = !list.Contains("GTX 1080Ti/RTX 2080+");
				if (flag4)
				{
					OTTDB.AddLinkPreset("GTX 1080Ti/RTX 2080+", "Low", "3648", "450", "Auto", "0");
					FrmMain.fmain.ComboBox4.Items.Add("GTX 1080Ti/RTX 2080+");
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("GetLinkPresetCurve: " + ex.Message);
			}
			List<string> list2;
			return list2;
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0002BA90 File Offset: 0x00029C90
		public static void CheckDB()
		{
			Log.WriteToLog("Performing database consistency check...");
			FrmMain.fmain.AddToListboxAndScroll("Performing database consistency check...");
			checked
			{
				try
				{
					bool flag = OTTDB.ott_cnn.State == ConnectionState.Closed;
					if (flag)
					{
						OTTDB.ott_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\ott.db");
						OTTDB.ott_cnn.Open();
					}
					SQLiteCommand sqliteCommand = new SQLiteCommand(OTTDB.ott_cnn);
					List<string> list = new List<string>();
					int num = 0;
					int num2 = 0;
					try
					{
						sqliteCommand.CommandText = "select ID, DisplayName, CompletePath from knownApps";
						using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
						{
							bool hasRows = sqliteDataReader.HasRows;
							if (hasRows)
							{
								while (sqliteDataReader.Read())
								{
									int num3 = Conversions.ToInteger(sqliteDataReader[0]);
									string text = Conversions.ToString(sqliteDataReader[1]);
									string text2 = Conversions.ToString(sqliteDataReader[2]);
									bool flag2 = text2.Contains("\\\\") | text2.Contains("/");
									if (flag2)
									{
										string text3 = text2.Replace("\\\\", "\\").Replace("/", "\\");
										bool flag3 = File.Exists(text3);
										if (flag3)
										{
											Log.WriteToLog(text + " has incorrect path in knownApps, correcting it");
											SQLiteCommand sqliteCommand2 = new SQLiteCommand(OTTDB.ott_cnn);
											sqliteCommand2.CommandText = string.Concat(new string[] { "UPDATE knownApps SET CompletePath = '", text3, "' WHERE CompletePath = '", text2, "'" });
											sqliteCommand2.ExecuteNonQuery();
											sqliteCommand2.Dispose();
											num++;
										}
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToLog("Table 'knownApps' does not exist yet, ignoring");
						}
					}
					try
					{
						sqliteCommand.CommandText = "select ID, DisplayName, Path from profiles";
						using (SQLiteDataReader sqliteDataReader2 = sqliteCommand.ExecuteReader())
						{
							bool hasRows2 = sqliteDataReader2.HasRows;
							if (hasRows2)
							{
								while (sqliteDataReader2.Read())
								{
									int num3 = Conversions.ToInteger(sqliteDataReader2[0]);
									string text = Conversions.ToString(sqliteDataReader2[1]);
									string text2 = Conversions.ToString(sqliteDataReader2[2]);
									bool flag4 = text2.Contains("\\\\") | text2.Contains("/");
									if (flag4)
									{
										string text3 = text2.Replace("\\\\", "\\").Replace("/", "\\");
										bool flag5 = File.Exists(text3);
										if (flag5)
										{
											Log.WriteToLog(text + " has incorrect path in profiles, correcting it");
											SQLiteCommand sqliteCommand3 = new SQLiteCommand(OTTDB.ott_cnn);
											sqliteCommand3.CommandText = string.Concat(new string[] { "UPDATE profiles SET Path = '", text3, "' WHERE Path = '", text2, "'" });
											sqliteCommand3.ExecuteNonQuery();
											sqliteCommand3.Dispose();
											num++;
										}
										else
										{
											num2++;
											Log.WriteToLog("WARNING: Path for profile '" + text + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
											MyProject.Forms.FrmMain.AddToListboxAndScroll("WARNING: Path for profile '" + text + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
										}
									}
									else
									{
										bool flag6 = !File.Exists(text2);
										if (flag6)
										{
											num2++;
											Log.WriteToLog("WARNING: Path for profile '" + text + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
											MyProject.Forms.FrmMain.AddToListboxAndScroll("WARNING: Path for profile '" + text + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
										}
									}
								}
							}
						}
					}
					catch (Exception ex2)
					{
						bool dbg2 = Globals.dbg;
						if (dbg2)
						{
							Log.WriteToLog("Table 'profiles' does not exist!");
						}
					}
					try
					{
						sqliteCommand.CommandText = "select ID, Mirror, DisplayName from profiles";
						using (SQLiteDataReader sqliteDataReader3 = sqliteCommand.ExecuteReader())
						{
							bool hasRows3 = sqliteDataReader3.HasRows;
							if (hasRows3)
							{
								while (sqliteDataReader3.Read())
								{
									int num3 = Conversions.ToInteger(sqliteDataReader3[0]);
									string text4 = Conversions.ToString(sqliteDataReader3[1]);
									string text = Conversions.ToString(sqliteDataReader3[2]);
									bool flag7 = (Operators.CompareString(text4, "0", false) != 0) & (Operators.CompareString(text4, "1", false) != 0) & (Operators.CompareString(text4, "2", false) != 0);
									if (flag7)
									{
										Log.WriteToLog(text + " has incorrect value for 'Mirror' in profiles, correcting it");
										MyProject.Forms.FrmMain.AddToListboxAndScroll(text + " has incorrect value for 'Mirror' in profiles, correcting it");
										SQLiteCommand sqliteCommand4 = new SQLiteCommand(OTTDB.ott_cnn);
										sqliteCommand4.CommandText = "UPDATE profiles SET Mirror = '0' WHERE ID = '" + Conversions.ToString(num3) + "'";
										sqliteCommand4.ExecuteNonQuery();
										sqliteCommand4.Dispose();
										num++;
									}
								}
							}
						}
					}
					catch (Exception ex3)
					{
						bool dbg3 = Globals.dbg;
						if (dbg3)
						{
							Log.WriteToLog("Table 'profiles' does not exist!");
						}
					}
					bool flag8 = num > 0;
					if (flag8)
					{
						Log.WriteToLog("Fixed " + Conversions.ToString(num) + " problems");
						FrmMain.fmain.AddToListboxAndScroll("Fixed " + Conversions.ToString(num) + " problems");
					}
					bool flag9 = (num == 0) & (num2 == 0);
					if (flag9)
					{
						Log.WriteToLog("No issues found");
						FrmMain.fmain.AddToListboxAndScroll("No issues found");
					}
					MySettingsProperty.Settings.DBCheck = false;
					MySettingsProperty.Settings.Save();
					OTTDB.ott_cnn.Close();
				}
				catch (Exception ex4)
				{
					OTTDB.ott_cnn.Close();
					MySettingsProperty.Settings.DBCheck = false;
					MySettingsProperty.Settings.Save();
					Log.WriteToLog("CheckDB: " + ex4.Message);
				}
			}
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00008AF8 File Offset: 0x00006CF8
		public static void AddDefaultLinkPresets()
		{
		}

		// Token: 0x04000201 RID: 513
		public static SQLiteConnection ott_cnn = new SQLiteConnection();

		// Token: 0x04000202 RID: 514
		public static string updatedProfile = "";

		// Token: 0x04000203 RID: 515
		public static int numWMI = 0;

		// Token: 0x04000204 RID: 516
		public static int numTimer = 0;
	}
}
