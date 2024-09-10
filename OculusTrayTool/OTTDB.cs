using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class OTTDB
{
	public static SQLiteConnection ott_cnn = new SQLiteConnection();

	public static string updatedProfile = "";

	public static int numWMI = 0;

	public static int numTimer = 0;

	public static void OpenOttDB()
	{
		try
		{
			bool flag = false;
			bool flag2 = false;
			if (File.Exists(Application.StartupPath + "\\ott.db"))
			{
				flag = true;
			}
			if (!flag)
			{
				Log.WriteToLog("ott.db not found, creating..");
				ott_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\ott.db");
				ott_cnn.Open();
				SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
				sQLiteCommand.CommandText = "CREATE TABLE `profiles` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`PPDP`\tTEXT DEFAULT '0',`ASW` TEXT Default 'Inherit',`Priority` TEXT Default 'Normal',`LaunchFile` TEXT,`Path` TEXT,`Method` TEXT,`ASWDelay`\tTEXT DEFAULT '5',`CPUDelay` TEXT DEFAULT '5',`Mirror` TEXT DEFAULT '0',`GPUScaling` TEXT DEFAULT '1',`Comment` TEXT DEFAULT '',`FOV` TEXT DEFAULT '0.0 0.0',`ForceMipMap` TEXT DEFAULT 'False',`OffsetMipMap` TEXT DEFAULT '0',`Enabled` TEXT DEFAULT 'Yes');";
				sQLiteCommand.ExecuteNonQuery();
				sQLiteCommand = new SQLiteCommand(ott_cnn);
				sQLiteCommand.CommandText = "CREATE TABLE `hiddenApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`LaunchFile` TEXT,`Location` TEXT);";
				sQLiteCommand.ExecuteNonQuery();
				sQLiteCommand = new SQLiteCommand(ott_cnn);
				sQLiteCommand.CommandText = "CREATE TABLE `ignoredApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);";
				sQLiteCommand.ExecuteNonQuery();
				sQLiteCommand = new SQLiteCommand(ott_cnn);
				sQLiteCommand.CommandText = "CREATE TABLE `knownApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT,`DisplayName` TEXT,`LaunchFile` TEXT,`CompletePath` TEXT,`AssetFile` TEXT);";
				sQLiteCommand.ExecuteNonQuery();
				sQLiteCommand = new SQLiteCommand(ott_cnn);
				sQLiteCommand.CommandText = "CREATE TABLE `customVoice` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Type` TEXT,`Action` TEXT,`Command` TEXT,`Enabled` INTEGER);";
				sQLiteCommand.ExecuteNonQuery();
				sQLiteCommand = new SQLiteCommand(ott_cnn);
				sQLiteCommand.CommandText = "CREATE TABLE `includedApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);";
				sQLiteCommand.ExecuteNonQuery();
				sQLiteCommand = new SQLiteCommand(ott_cnn);
				sQLiteCommand.CommandText = "CREATE TABLE `LinkPresets` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Name` TEXT,`Curve` TEXT,`Encoding` TEXT,`Bitrate` TEXT,`Sharpening` TEXT,`DBR` TEXT);";
				sQLiteCommand.ExecuteNonQuery();
			}
			else
			{
				if (ott_cnn.State == ConnectionState.Closed)
				{
					Log.WriteToLog("Opening connection to ott.db");
					ott_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\ott.db");
					ott_cnn.Open();
				}
				SQLiteCommand sQLiteCommand2 = new SQLiteCommand(ott_cnn);
				sQLiteCommand2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='ignoredApps'";
				using (SQLiteDataReader sQLiteDataReader = sQLiteCommand2.ExecuteReader())
				{
					if (!sQLiteDataReader.HasRows)
					{
						sQLiteDataReader.Close();
						try
						{
							sQLiteCommand2.CommandText = "CREATE TABLE IF Not EXISTS `ignoredApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);";
							sQLiteCommand2.ExecuteNonQuery();
							Log.WriteToLog("Created missing table 'ignoredApps'");
							flag2 = true;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							Log.WriteToLog("Error creating table 'ignoredApps': " + ex2.Message);
							ProjectData.ClearProjectError();
						}
					}
				}
				sQLiteCommand2 = new SQLiteCommand(ott_cnn);
				sQLiteCommand2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='knownApps'";
				using (SQLiteDataReader sQLiteDataReader2 = sQLiteCommand2.ExecuteReader())
				{
					if (!sQLiteDataReader2.HasRows)
					{
						sQLiteDataReader2.Close();
						try
						{
							sQLiteCommand2.CommandText = "CREATE TABLE IF Not EXISTS `knownApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT,`DisplayName` TEXT,`LaunchFile` TEXT,`CompletePath` TEXT,`AssetFile` TEXT);";
							sQLiteCommand2.ExecuteNonQuery();
							Log.WriteToLog("Created missing table 'knownApps'");
							flag2 = true;
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							Log.WriteToLog("Error creating table 'knownApps': " + ex4.Message);
							ProjectData.ClearProjectError();
						}
					}
				}
				sQLiteCommand2 = new SQLiteCommand(ott_cnn);
				sQLiteCommand2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='profiles'";
				using (SQLiteDataReader sQLiteDataReader3 = sQLiteCommand2.ExecuteReader())
				{
					if (!sQLiteDataReader3.HasRows)
					{
						sQLiteDataReader3.Close();
						try
						{
							sQLiteCommand2.CommandText = "CREATE TABLE IF Not EXISTS `profiles` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`PPDP`\tTEXT DEFAULT '0',`ASW` TEXT Default 'Inherit',`Priority` TEXT Default 'Normal',`LaunchFile` TEXT,`Path` TEXT,`Method` TEXT,`ASWDelay`\tTEXT DEFAULT '5',`CPUDelay` DEFAULT '5',`Mirror` TEXT DEFAULT '0',`GPUScaling` TEXT DEFAULT '1',`Comment` TEXT DEFAULT '',`FOV` TEXT DEFAULT '0.0 0.0',`ForceMipMap` TEXT DEFAULT 'False',`OffsetMipMap` TEXT DEFAULT '0',`Enabled` TEXT DEFAULT 'Yes');";
							sQLiteCommand2.ExecuteNonQuery();
							Log.WriteToLog("Created missing table 'profiles'");
							flag2 = true;
						}
						catch (Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							Exception ex6 = ex5;
							Log.WriteToLog("Error creating table 'profiles': " + ex6.Message);
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						try
						{
							if (!CheckIfColumnExists("profiles", "ASWDelay", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN ASWDelay Default 5";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'ASWDelay'");
							}
						}
						catch (Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							Exception ex8 = ex7;
							Log.WriteToLog("Error adding missing column 'ASWDelay': " + ex8.Message);
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!CheckIfColumnExists("profiles", "CPUDelay", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN CPUDelay Default 5";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'CPUDelay'");
							}
						}
						catch (Exception ex9)
						{
							ProjectData.SetProjectError(ex9);
							Exception ex10 = ex9;
							Log.WriteToLog("Error adding missing column 'CPUDelay': " + ex10.Message);
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!CheckIfColumnExists("profiles", "Mirror", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN Mirror Default 0";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'Mirror'");
							}
						}
						catch (Exception ex11)
						{
							ProjectData.SetProjectError(ex11);
							Exception ex12 = ex11;
							Log.WriteToLog("Error adding missing column 'Mirror': " + ex12.Message);
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!CheckIfColumnExists("profiles", "GPUScaling", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN GPUScaling Default 1";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'GPUScaling'");
							}
						}
						catch (Exception ex13)
						{
							ProjectData.SetProjectError(ex13);
							Exception ex14 = ex13;
							Log.WriteToLog("Error adding missing column 'GPUScaling': " + ex14.Message);
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!CheckIfColumnExists("profiles", "Comment", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN Comment Default ''";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'Comment'");
							}
						}
						catch (Exception ex15)
						{
							ProjectData.SetProjectError(ex15);
							Exception ex16 = ex15;
							Log.WriteToLog("Error adding missing column 'Comment': " + ex16.Message);
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!CheckIfColumnExists("profiles", "FOV", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN FOV Default '0.0 0.0'";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'FOV'");
							}
						}
						catch (Exception ex17)
						{
							ProjectData.SetProjectError(ex17);
							Exception ex18 = ex17;
							Log.WriteToLog("Error adding missing column 'FOV': " + ex18.Message);
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!CheckIfColumnExists("profiles", "ForceMipMap", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN ForceMipMap Default 'False'";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'ForceMipMap'");
							}
						}
						catch (Exception ex19)
						{
							ProjectData.SetProjectError(ex19);
							Exception ex20 = ex19;
							Log.WriteToLog("Error adding missing column 'ForceMipMap': " + ex20.Message);
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!CheckIfColumnExists("profiles", "OffsetMipMap", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN OffsetMipMap Default '0'";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'OffsetMipMap'");
							}
						}
						catch (Exception ex21)
						{
							ProjectData.SetProjectError(ex21);
							Exception ex22 = ex21;
							Log.WriteToLog("Error adding missing column 'OffsetMipMap': " + ex22.Message);
							ProjectData.ClearProjectError();
						}
						try
						{
							if (!CheckIfColumnExists("profiles", "Enabled", ott_cnn))
							{
								sQLiteCommand2 = new SQLiteCommand(ott_cnn);
								sQLiteCommand2.CommandText = "ALTER TABLE profiles ADD COLUMN Enabled Default 'Yes'";
								sQLiteCommand2.ExecuteNonQuery();
								Log.WriteToLog("Added missing column 'Enabled'");
							}
						}
						catch (Exception ex23)
						{
							ProjectData.SetProjectError(ex23);
							Exception ex24 = ex23;
							Log.WriteToLog("Error adding missing column 'Enabled': " + ex24.Message);
							ProjectData.ClearProjectError();
						}
					}
				}
				sQLiteCommand2 = new SQLiteCommand(ott_cnn);
				sQLiteCommand2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='hiddenApps'";
				using (SQLiteDataReader sQLiteDataReader4 = sQLiteCommand2.ExecuteReader())
				{
					if (!sQLiteDataReader4.HasRows)
					{
						sQLiteDataReader4.Close();
						try
						{
							sQLiteCommand2.CommandText = "CREATE TABLE IF Not EXISTS `hiddenApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`LaunchFile` TEXT,`Location` TEXT);";
							sQLiteCommand2.ExecuteNonQuery();
							Log.WriteToLog("Created missing table 'hiddenApps'");
							flag2 = true;
						}
						catch (Exception ex25)
						{
							ProjectData.SetProjectError(ex25);
							Exception ex26 = ex25;
							Log.WriteToLog("Error creating table 'hiddenApps': " + ex26.Message);
							ProjectData.ClearProjectError();
						}
					}
				}
				sQLiteCommand2 = new SQLiteCommand(ott_cnn);
				sQLiteCommand2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='customVoice'";
				using (SQLiteDataReader sQLiteDataReader5 = sQLiteCommand2.ExecuteReader())
				{
					if (!sQLiteDataReader5.HasRows)
					{
						sQLiteDataReader5.Close();
						try
						{
							sQLiteCommand2.CommandText = "CREATE TABLE IF Not EXISTS `customVoice` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Type` TEXT,`Action` TEXT,`Command` TEXT,`Enabled` TEXT);";
							sQLiteCommand2.ExecuteNonQuery();
							Log.WriteToLog("Created missing table 'customVoice'");
							flag2 = true;
						}
						catch (Exception ex27)
						{
							ProjectData.SetProjectError(ex27);
							Exception ex28 = ex27;
							Log.WriteToLog("Error creating table 'customVoice': " + ex28.Message);
							ProjectData.ClearProjectError();
						}
					}
				}
				sQLiteCommand2 = new SQLiteCommand(ott_cnn);
				sQLiteCommand2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='includedApps'";
				using (SQLiteDataReader sQLiteDataReader6 = sQLiteCommand2.ExecuteReader())
				{
					if (!sQLiteDataReader6.HasRows)
					{
						sQLiteDataReader6.Close();
						try
						{
							sQLiteCommand2.CommandText = "CREATE TABLE IF Not EXISTS `includedApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);";
							sQLiteCommand2.ExecuteNonQuery();
							Log.WriteToLog("Created missing table 'includedApps'");
							flag2 = true;
						}
						catch (Exception ex29)
						{
							ProjectData.SetProjectError(ex29);
							Exception ex30 = ex29;
							Log.WriteToLog("Error creating table 'includedApps': " + ex30.Message);
							ProjectData.ClearProjectError();
						}
					}
				}
				sQLiteCommand2 = new SQLiteCommand(ott_cnn);
				sQLiteCommand2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='LinkPresets'";
				using SQLiteDataReader sQLiteDataReader7 = sQLiteCommand2.ExecuteReader();
				if (!sQLiteDataReader7.HasRows)
				{
					sQLiteDataReader7.Close();
					try
					{
						sQLiteCommand2.CommandText = "CREATE TABLE IF Not EXISTS `LinkPresets` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Name` TEXT,`Curve` TEXT,`Encoding` TEXT,`Bitrate` TEXT,`Sharpening` TEXT,`DBR` TEXT);";
						sQLiteCommand2.ExecuteNonQuery();
						Log.WriteToLog("Created missing table 'LinkPresets'");
						flag2 = true;
					}
					catch (Exception ex31)
					{
						ProjectData.SetProjectError(ex31);
						Exception ex32 = ex31;
						Log.WriteToLog("Error creating table 'LinkPresets': " + ex32.Message);
						ProjectData.ClearProjectError();
					}
				}
				try
				{
					if (!CheckIfColumnExists("LinkPresets", "Bitrate", ott_cnn))
					{
						sQLiteCommand2 = new SQLiteCommand(ott_cnn);
						sQLiteCommand2.CommandText = "ALTER TABLE LinkPresets ADD COLUMN Bitrate Default 150";
						sQLiteCommand2.ExecuteNonQuery();
						Log.WriteToLog("Added missing column 'Bitrate'");
					}
				}
				catch (Exception ex33)
				{
					ProjectData.SetProjectError(ex33);
					Exception ex34 = ex33;
					Log.WriteToLog("Error adding missing column 'Bitrate': " + ex34.Message);
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!CheckIfColumnExists("LinkPresets", "Sharpening", ott_cnn))
					{
						sQLiteCommand2 = new SQLiteCommand(ott_cnn);
						sQLiteCommand2.CommandText = "ALTER TABLE LinkPresets ADD COLUMN Sharpening Default 0";
						sQLiteCommand2.ExecuteNonQuery();
						Log.WriteToLog("Added missing column 'Sharpening'");
					}
				}
				catch (Exception ex35)
				{
					ProjectData.SetProjectError(ex35);
					Exception ex36 = ex35;
					Log.WriteToLog("Error adding missing column 'Sharpening': " + ex36.Message);
					ProjectData.ClearProjectError();
				}
				try
				{
					if (!CheckIfColumnExists("LinkPresets", "DBR", ott_cnn))
					{
						sQLiteCommand2 = new SQLiteCommand(ott_cnn);
						sQLiteCommand2.CommandText = "ALTER TABLE LinkPresets ADD COLUMN DBR Default 0";
						sQLiteCommand2.ExecuteNonQuery();
						Log.WriteToLog("Added missing column 'DBR'");
					}
				}
				catch (Exception ex37)
				{
					ProjectData.SetProjectError(ex37);
					Exception ex38 = ex37;
					Log.WriteToLog("Error adding missing column 'DBR': " + ex38.Message);
					ProjectData.ClearProjectError();
				}
			}
			Log.WriteToLog("Database is open for business");
		}
		catch (Exception ex39)
		{
			ProjectData.SetProjectError(ex39);
			Exception ex40 = ex39;
			Log.WriteToLog("OpenOttDb " + ex40.Message);
			ProjectData.ClearProjectError();
		}
	}

	private static bool CheckIfColumnExists(string tableName, string columnName, SQLiteConnection cnn)
	{
		SQLiteCommand sQLiteCommand = cnn.CreateCommand();
		sQLiteCommand.CommandText = $"PRAGMA table_info({tableName})";
		SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
		int ordinal = sQLiteDataReader.GetOrdinal("Name");
		while (sQLiteDataReader.Read())
		{
			if (sQLiteDataReader.GetString(ordinal).Equals(columnName))
			{
				return true;
			}
		}
		return false;
	}

	public static void GetVoiceProfileNames()
	{
		Log.WriteToLog("Reading voice profiles");
		MyProject.Forms.FrmMain.voiceProfileNames.Clear();
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		sQLiteCommand.CommandText = "select distinct Name from userVoice";
		using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
		if (sQLiteDataReader.HasRows)
		{
			while (sQLiteDataReader.Read())
			{
				MyProject.Forms.FrmMain.voiceProfileNames.Add(Conversions.ToString(sQLiteDataReader[0]));
			}
		}
	}

	public static object GetVoiceProfileCommands(string profileName)
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		List<string> list = new List<string>();
		sQLiteCommand.CommandText = "select SpokenCommand,Actions,GameProfile from userVoice where Name = \"" + profileName + "\"";
		using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
		{
			if (sQLiteDataReader.HasRows)
			{
				while (sQLiteDataReader.Read())
				{
					list.Add(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(sQLiteDataReader[0], "|"), sQLiteDataReader[1]), "|"), sQLiteDataReader[2])));
				}
			}
		}
		return list;
	}

	public static void AddVoiceProfileCommand(string voiceProfile, string gameProfile, string spoken, string actions)
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		sQLiteCommand.CommandText = "insert Or replace into userVoice (ID, Name, SpokenCommand, Actions, GameProfile) values ((select ID from userVoice where SpokenCommand = \"" + spoken + "\"), \"" + voiceProfile + "\",\"" + spoken + "\",\"" + actions + "\")";
		sQLiteCommand.ExecuteNonQuery();
	}

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
		numWMI = 0;
		numTimer = 0;
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		checked
		{
			try
			{
				sQLiteCommand.CommandText = "select * from profiles";
				using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
				{
					if (sQLiteDataReader.HasRows)
					{
						while (sQLiteDataReader.Read())
						{
							string text = Conversions.ToString(sQLiteDataReader[1]);
							string text2 = Conversions.ToString(sQLiteDataReader[2]);
							string text3 = Conversions.ToString(sQLiteDataReader[3]);
							string text4 = Conversions.ToString(sQLiteDataReader[4]);
							string text5 = Conversions.ToString(sQLiteDataReader[5]);
							string text6 = Conversions.ToString(sQLiteDataReader[6]);
							string text7 = Conversions.ToString(sQLiteDataReader[7]);
							string text8 = Conversions.ToString((sQLiteDataReader.FieldCount > 8) ? sQLiteDataReader[8] : "5");
							string text9 = Conversions.ToString((sQLiteDataReader.FieldCount > 9) ? sQLiteDataReader[9] : "5");
							string text10 = Conversions.ToString(sQLiteDataReader[10]);
							string text11 = Conversions.ToString(sQLiteDataReader[11]);
							string text12 = Conversions.ToString(sQLiteDataReader[12]);
							string text13 = Conversions.ToString(sQLiteDataReader[13]);
							string text14 = Conversions.ToString(sQLiteDataReader[14]);
							string text15 = Conversions.ToString(sQLiteDataReader[15]);
							string text16 = Conversions.ToString(sQLiteDataReader[16]);
							if (Operators.CompareString(text16, "No", TextCompare: false) == 0)
							{
								num++;
							}
							foreach (KeyValuePair<string, string> game in MyProject.Forms.frmProfiles.GameList)
							{
								if (Operators.CompareString(game.Value, text6, TextCompare: false) == 0)
								{
									MyProject.Forms.frmProfiles.GameList.Remove(game.Key);
									break;
								}
							}
							MyProject.Forms.frmLibrary.DisplayNameList.Add(text.ToLower());
							ListViewItem listViewItem = new ListViewItem();
							listViewItem = MyProject.Forms.frmProfiles.ListView1.Items.Add(text);
							listViewItem.Tag = text + "," + text2 + "," + text3 + "," + text7 + "," + text4 + "," + text6 + "," + text8 + "," + text9 + "," + text10 + "," + text11 + "," + text12 + "," + text13 + "," + text14 + "," + text15 + "," + text16;
							listViewItem.SubItems.Add(text2);
							listViewItem.SubItems.Add(text3);
							listViewItem.SubItems.Add(text4);
							listViewItem.SubItems.Add(text16);
							if (Globals.dbg)
							{
								Log.WriteToLog(text + "," + text3 + "," + text2 + "," + text4 + "," + text5 + "," + text6 + "," + text7);
							}
							GetConfig.numprofiles++;
							if (Operators.CompareString(text16, "Yes", TextCompare: false) == 0)
							{
								MyProject.Forms.FrmMain.profileDisplayNames.Add(text6, text);
								if (Operators.CompareString(text7, "WMI", TextCompare: false) == 0)
								{
									MyProject.Forms.FrmMain.profileList.Add(text6.ToLower(), text2);
									numWMI++;
								}
								if (Operators.CompareString(text7, "Timer", TextCompare: false) == 0)
								{
									MyProject.Forms.FrmMain.profileTimerList.Add(text6, text2);
									numTimer++;
								}
								MyProject.Forms.frmLibrary.ManualStartProfiles.Add(text6.ToLower(), text2);
								MyProject.Forms.FrmMain.profileASWList.Add(text6.ToLower(), text3);
								if (Operators.CompareString(text4, "Default", TextCompare: false) != 0)
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
				Log.WriteToLog("  " + Conversions.ToString(numWMI) + " monitored using WMI");
				Log.WriteToLog("  " + Conversions.ToString(numTimer) + " monitored using Timer");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("GetProfiles(): " + ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void AddProfile(string displayname, string asw, string ppdp, string priority, string LaunchFile, string path, string method, string aswdelay, string cpudelay, string mirror, string agps, string comment, string fov, string forcemipmap, string offsetmipmap, string enabled)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "insert Or replace into profiles (ID, DisplayName, PPDP, ASW, Priority, LaunchFile, Path, Method, ASWDelay, CPUDelay, Mirror, GPUScaling, Comment, FOV, ForceMipMap, OffsetMipMap, Enabled) values ((select ID from Profiles where Path = \"" + path + "\"), \"" + displayname + "\",\"" + ppdp + "\",\"" + asw + "\",\"" + priority + "\",\"" + LaunchFile + "\",\"" + path + "\",\"" + method + "\",\"" + aswdelay + "\",\"" + cpudelay + "\",\"" + mirror + "\",\"" + agps + "\",\"" + comment + "\",\"" + fov + "\",\"" + forcemipmap + "\",\"" + offsetmipmap + "\",\"" + enabled + "\")";
			sQLiteCommand.ExecuteNonQuery();
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
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("AddProfile: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void UpdateProfile(string asw, string ppdp, string path, string name)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			if (Operators.CompareString(asw, null, TextCompare: false) != 0)
			{
				sQLiteCommand.CommandText = "UPDATE profiles SET ASW=" + asw + " WHERE Path = \"" + path + "\"";
				sQLiteCommand.ExecuteNonQuery();
				Log.WriteToLog("Updated '" + name + "'. New ASW setting is '" + asw + "'");
			}
			if (Operators.CompareString(ppdp, null, TextCompare: false) != 0)
			{
				sQLiteCommand.CommandText = "UPDATE profiles SET PPDP=" + ppdp + " WHERE Path = \"" + path + "\"";
				sQLiteCommand.ExecuteNonQuery();
				Log.WriteToLog("Updated '" + name + "'. New Pixel Density setting is '" + ppdp + "'");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("UpdateProfile: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void RemoveProfile(string Path)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			string displayName = GetDisplayName(Path);
			sQLiteCommand.CommandText = "delete from profiles where path = \"" + Path + "\"";
			sQLiteCommand.ExecuteNonQuery();
			Log.WriteToLog("Profile for '" + displayName + "' has been removed");
			FrmMain.fmain.AddToListboxAndScroll("Profile for '" + displayName + "' has been removed");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("RemoveProfile: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void RemoveAllProfiles()
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "delete from profiles";
			sQLiteCommand.ExecuteNonQuery();
			Log.WriteToLog("All Profiles have been removed");
			FrmMain.fmain.AddToListboxAndScroll("All Profiles have been removed");
			MyProject.Forms.frmProfiles.ListView1.Items.Clear();
			GetProfiles();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("RemoveAllProfiles: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void HideApp(string displayname, string launchfile, string location)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "insert or replace into hiddenApps (ID, DisplayName, LaunchFile, Location) values ((select ID from hiddenApps where LaunchFile = \"" + launchfile + "\" AND DisplayName = \"" + displayname + "\"), \"" + displayname + "\",\"" + launchfile + "\",\"" + location + "\")";
			sQLiteCommand.ExecuteNonQuery();
			Log.WriteToLog("App hidden: " + displayname);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("HideApp: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void UnHideApp(string displayname)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "DELETE from hiddenApps where DisplayName = \"" + displayname + "\"";
			sQLiteCommand.ExecuteNonQuery();
			Log.WriteToLog("App Visible: " + displayname);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("UnHideApp: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static bool CheckHiddenApp(string launchfile, string displayname, string location)
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		sQLiteCommand.CommandText = "select * from hiddenApps where DisplayName = \"" + displayname + "\" AND Location = \"" + location + "\" AND LaunchFile = \"" + launchfile + "\"";
		if (Operators.ConditionalCompareObjectNotEqual(sQLiteCommand.ExecuteScalar(), 0, TextCompare: false))
		{
			return true;
		}
		return false;
	}

	public static object GetHiddenApps()
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		List<string> list = new List<string>();
		sQLiteCommand.CommandText = "select DisplayName from hiddenApps";
		using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
		{
			if (sQLiteDataReader.HasRows)
			{
				while (sQLiteDataReader.Read())
				{
					list.Add(Conversions.ToString(sQLiteDataReader[0]));
				}
			}
		}
		return list;
	}

	public static object GetIgnoredApps()
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		List<string> list = new List<string>();
		sQLiteCommand.CommandText = "select FileName from ignoredApps";
		using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
		{
			if (sQLiteDataReader.HasRows)
			{
				while (sQLiteDataReader.Read())
				{
					list.Add(Conversions.ToString(sQLiteDataReader[0]));
					if (!File.Exists(Conversions.ToString(sQLiteDataReader[0])))
					{
						RemoveIgnoredApp(Conversions.ToString(sQLiteDataReader[0]));
					}
				}
			}
		}
		return list;
	}

	public static object GetIncludedApps()
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		List<string> list = new List<string>();
		sQLiteCommand.CommandText = "select FileName from includedApps";
		using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
		{
			if (sQLiteDataReader.HasRows)
			{
				while (sQLiteDataReader.Read())
				{
					list.Add(Conversions.ToString(sQLiteDataReader[0]));
					if (!File.Exists(Conversions.ToString(sQLiteDataReader[0])))
					{
						RemoveIncludedApp(Conversions.ToString(sQLiteDataReader[0]));
					}
				}
			}
		}
		return list;
	}

	public static void RemoveIgnoredApp(string name)
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		sQLiteCommand.CommandText = "delete from ignoredApps where FileName = \"" + name + "\"";
		sQLiteCommand.ExecuteNonQuery();
	}

	public static void RemoveIncludedApp(string name)
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		sQLiteCommand.CommandText = "delete from includedApps where FileName = \"" + name + "\"";
		sQLiteCommand.ExecuteNonQuery();
	}

	public static object GetknownApps()
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		List<string> list = new List<string>();
		sQLiteCommand.CommandText = "select FileName from knownApps";
		using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
		{
			if (sQLiteDataReader.HasRows)
			{
				while (sQLiteDataReader.Read())
				{
					list.Add(Conversions.ToString(sQLiteDataReader[0]));
				}
			}
		}
		return list;
	}

	public static object GetknownAppDetails(string filename)
	{
		SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
		sQLiteCommand.CommandText = "select DisplayName, LaunchFile, CompletePath, AssetFile from knownApps where FileName = \"" + filename + "\"";
		string result = default(string);
		using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
		{
			if (sQLiteDataReader.HasRows)
			{
				while (sQLiteDataReader.Read())
				{
					result = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(sQLiteDataReader[0], ","), sQLiteDataReader[1]), ","), sQLiteDataReader[2]), ","), sQLiteDataReader[3]));
				}
			}
		}
		return result;
	}

	public static void AddKnownApp(string filename, string displayname, string launchfile, string completepath, string assetfile)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "insert into knownApps (FileName, DisplayName, LaunchFile, CompletePath, AssetFile) values (\"" + filename + "\",\"" + displayname + "\",\"" + launchfile + "\",\"" + completepath + "\",\"" + assetfile + "\")";
			sQLiteCommand.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("AddKnownApp: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void AddIgnoreApp(string filename)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "insert into ignoredApps (FileName) values (\"" + filename + "\")";
			sQLiteCommand.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("AddIgnoreApp: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void AddIncludedApp(string filename)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "insert into includedApps (FileName) values (\"" + filename + "\")";
			sQLiteCommand.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("AddIncludedApp: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static string GetDisplayName(string path)
	{
		string result = default(string);
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "select DisplayName from Profiles where Path = \"" + path + "\" COLLATE NOCASE";
			using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
			if (sQLiteDataReader.HasRows && sQLiteDataReader.Read())
			{
				result = Conversions.ToString(sQLiteDataReader[0]);
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("UpdateProfile: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void AddLinkPreset(string name, string curve, string encoding, string bitrate, string sharpening, string dbr)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "insert or replace into LinkPresets (ID, Name, Curve, Encoding, Bitrate, Sharpening, DBR) values ((select ID from LinkPresets where Name = \"" + name + "\"), \"" + name + "\",\"" + curve + "\",\"" + encoding + "\",\"" + bitrate + "\",\"" + sharpening + "\",\"" + dbr + "\")";
			sQLiteCommand.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("AddLinkPreset: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static string GetLinkPresetValueByName(string name, string value)
	{
		string result = default(string);
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "select " + value + " from LinkPresets where Name = \"" + name + "\" COLLATE NOCASE";
			using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
			if (sQLiteDataReader.HasRows && sQLiteDataReader.Read())
			{
				result = Conversions.ToString(sQLiteDataReader[0]);
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetLinkPresetValueByName: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string GetLinkPresetValueByValues(string curve, string encoding, string bitrate, string sharpening, string dbr)
	{
		string result = default(string);
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "select Name from LinkPresets where Curve = \"" + curve + "\" AND Encoding = \"" + encoding + "\" AND Bitrate = \"" + bitrate + "\" AND Sharpening = \"" + sharpening + "\" AND DBR = \"" + dbr + "\"";
			using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
			if (sQLiteDataReader.HasRows && sQLiteDataReader.Read())
			{
				result = Conversions.ToString(sQLiteDataReader[0]);
				return result;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetLinkPresetValueByValues: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static string RemoveLinkPresetByName(string name)
	{
		try
		{
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "delete from LinkPresets where Name = \"" + name + "\"";
			sQLiteCommand.ExecuteNonQuery();
			Log.WriteToLog("Link Preset '" + name + "' has been removed");
			FrmMain.fmain.AddToListboxAndScroll("Link Preset '" + name + "' has been removed");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("RemoveLinkPresetValueByName: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		string result = default(string);
		return result;
	}

	public static List<string> GetLinkPresetNames()
	{
		try
		{
			List<string> list = new List<string>();
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			sQLiteCommand.CommandText = "select Name from LinkPresets";
			using (SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader())
			{
				if (sQLiteDataReader.HasRows)
				{
					while (sQLiteDataReader.Read())
					{
						FrmMain.fmain.ComboBox4.Items.Add(RuntimeHelpers.GetObjectValue(sQLiteDataReader[0]));
						list.Add(Conversions.ToString(sQLiteDataReader[0]));
					}
				}
			}
			if (!list.Contains("GTX 970+"))
			{
				AddLinkPreset("GTX 970+", "Default", "2016", "300", "Auto", "0");
				FrmMain.fmain.ComboBox4.Items.Add("GTX 970+");
			}
			if (!list.Contains("GTX 1070+"))
			{
				AddLinkPreset("GTX 1070+", "High", "2352", "350", "Auto", "0");
				FrmMain.fmain.ComboBox4.Items.Add("GTX 1070+");
			}
			if (!list.Contains("RTX 2070+"))
			{
				AddLinkPreset("RTX 2070+", "Low", "2912", "400", "Auto", "0");
				FrmMain.fmain.ComboBox4.Items.Add("RTX 2070+");
			}
			if (!list.Contains("GTX 1080Ti/RTX 2080+"))
			{
				AddLinkPreset("GTX 1080Ti/RTX 2080+", "Low", "3648", "450", "Auto", "0");
				FrmMain.fmain.ComboBox4.Items.Add("GTX 1080Ti/RTX 2080+");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("GetLinkPresetCurve: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		List<string> result = default(List<string>);
		return result;
	}

	public static void CheckDB()
	{
		Log.WriteToLog("Performing database consistency check...");
		FrmMain.fmain.AddToListboxAndScroll("Performing database consistency check...");
		try
		{
			if (ott_cnn.State == ConnectionState.Closed)
			{
				ott_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\ott.db");
				ott_cnn.Open();
			}
			SQLiteCommand sQLiteCommand = new SQLiteCommand(ott_cnn);
			List<string> list = new List<string>();
			int num = 0;
			int num2 = 0;
			checked
			{
				try
				{
					sQLiteCommand.CommandText = "select ID, DisplayName, CompletePath from knownApps";
					using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
					if (sQLiteDataReader.HasRows)
					{
						while (sQLiteDataReader.Read())
						{
							int num3 = Conversions.ToInteger(sQLiteDataReader[0]);
							string text = Conversions.ToString(sQLiteDataReader[1]);
							string text2 = Conversions.ToString(sQLiteDataReader[2]);
							if (text2.Contains("\\\\") | text2.Contains("/"))
							{
								string text3 = text2.Replace("\\\\", "\\").Replace("/", "\\");
								if (File.Exists(text3))
								{
									Log.WriteToLog(text + " has incorrect path in knownApps, correcting it");
									SQLiteCommand sQLiteCommand2 = new SQLiteCommand(ott_cnn);
									sQLiteCommand2.CommandText = "UPDATE knownApps SET CompletePath = '" + text3 + "' WHERE CompletePath = '" + text2 + "'";
									sQLiteCommand2.ExecuteNonQuery();
									sQLiteCommand2.Dispose();
									num++;
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					if (Globals.dbg)
					{
						Log.WriteToLog("Table 'knownApps' does not exist yet, ignoring");
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					sQLiteCommand.CommandText = "select ID, DisplayName, Path from profiles";
					using SQLiteDataReader sQLiteDataReader2 = sQLiteCommand.ExecuteReader();
					if (sQLiteDataReader2.HasRows)
					{
						while (sQLiteDataReader2.Read())
						{
							int num3 = Conversions.ToInteger(sQLiteDataReader2[0]);
							string text = Conversions.ToString(sQLiteDataReader2[1]);
							string text2 = Conversions.ToString(sQLiteDataReader2[2]);
							if (text2.Contains("\\\\") | text2.Contains("/"))
							{
								string text3 = text2.Replace("\\\\", "\\").Replace("/", "\\");
								if (File.Exists(text3))
								{
									Log.WriteToLog(text + " has incorrect path in profiles, correcting it");
									SQLiteCommand sQLiteCommand3 = new SQLiteCommand(ott_cnn);
									sQLiteCommand3.CommandText = "UPDATE profiles SET Path = '" + text3 + "' WHERE Path = '" + text2 + "'";
									sQLiteCommand3.ExecuteNonQuery();
									sQLiteCommand3.Dispose();
									num++;
								}
								else
								{
									num2++;
									Log.WriteToLog("WARNING: Path for profile '" + text + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
									MyProject.Forms.FrmMain.AddToListboxAndScroll("WARNING: Path for profile '" + text + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
								}
							}
							else if (!File.Exists(text2))
							{
								num2++;
								Log.WriteToLog("WARNING: Path for profile '" + text + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
								MyProject.Forms.FrmMain.AddToListboxAndScroll("WARNING: Path for profile '" + text + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
							}
						}
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					if (Globals.dbg)
					{
						Log.WriteToLog("Table 'profiles' does not exist!");
					}
					ProjectData.ClearProjectError();
				}
				try
				{
					sQLiteCommand.CommandText = "select ID, Mirror, DisplayName from profiles";
					using SQLiteDataReader sQLiteDataReader3 = sQLiteCommand.ExecuteReader();
					if (sQLiteDataReader3.HasRows)
					{
						while (sQLiteDataReader3.Read())
						{
							int num3 = Conversions.ToInteger(sQLiteDataReader3[0]);
							string left = Conversions.ToString(sQLiteDataReader3[1]);
							string text = Conversions.ToString(sQLiteDataReader3[2]);
							if ((Operators.CompareString(left, "0", TextCompare: false) != 0) & (Operators.CompareString(left, "1", TextCompare: false) != 0) & (Operators.CompareString(left, "2", TextCompare: false) != 0))
							{
								Log.WriteToLog(text + " has incorrect value for 'Mirror' in profiles, correcting it");
								MyProject.Forms.FrmMain.AddToListboxAndScroll(text + " has incorrect value for 'Mirror' in profiles, correcting it");
								SQLiteCommand sQLiteCommand4 = new SQLiteCommand(ott_cnn);
								sQLiteCommand4.CommandText = "UPDATE profiles SET Mirror = '0' WHERE ID = '" + Conversions.ToString(num3) + "'";
								sQLiteCommand4.ExecuteNonQuery();
								sQLiteCommand4.Dispose();
								num++;
							}
						}
					}
				}
				catch (Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					Exception ex6 = ex5;
					if (Globals.dbg)
					{
						Log.WriteToLog("Table 'profiles' does not exist!");
					}
					ProjectData.ClearProjectError();
				}
				if (num > 0)
				{
					Log.WriteToLog("Fixed " + Conversions.ToString(num) + " problems");
					FrmMain.fmain.AddToListboxAndScroll("Fixed " + Conversions.ToString(num) + " problems");
				}
			}
			if (num == 0 && num2 == 0)
			{
				Log.WriteToLog("No issues found");
				FrmMain.fmain.AddToListboxAndScroll("No issues found");
			}
			MySettingsProperty.Settings.DBCheck = false;
			MySettingsProperty.Settings.Save();
			ott_cnn.Close();
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			ott_cnn.Close();
			MySettingsProperty.Settings.DBCheck = false;
			MySettingsProperty.Settings.Save();
			Log.WriteToLog("CheckDB: " + ex8.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void AddDefaultLinkPresets()
	{
	}
}
