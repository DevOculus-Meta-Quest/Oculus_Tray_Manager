// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.OTTDB
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
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
        bool flag1 = false;
        bool flag2 = false;
        if (File.Exists(Application.StartupPath + "\\ott.db"))
          flag1 = true;
        if (!flag1)
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
          if (OTTDB.ott_cnn.State == ConnectionState.Closed)
          {
            Log.WriteToLog("Opening connection to ott.db");
            OTTDB.ott_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\ott.db");
            OTTDB.ott_cnn.Open();
          }
          SQLiteCommand sqLiteCommand1 = new SQLiteCommand(OTTDB.ott_cnn);
          sqLiteCommand1.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='ignoredApps'";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand1.ExecuteReader())
          {
            if (!sqLiteDataReader.HasRows)
            {
              sqLiteDataReader.Close();
              try
              {
                sqLiteCommand1.CommandText = "CREATE TABLE IF Not EXISTS `ignoredApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);";
                sqLiteCommand1.ExecuteNonQuery();
                Log.WriteToLog("Created missing table 'ignoredApps'");
                flag2 = true;
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error creating table 'ignoredApps': " + ex.Message);
                ProjectData.ClearProjectError();
              }
            }
          }
          SQLiteCommand sqLiteCommand2 = new SQLiteCommand(OTTDB.ott_cnn);
          sqLiteCommand2.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='knownApps'";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand2.ExecuteReader())
          {
            if (!sqLiteDataReader.HasRows)
            {
              sqLiteDataReader.Close();
              try
              {
                sqLiteCommand2.CommandText = "CREATE TABLE IF Not EXISTS `knownApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT,`DisplayName` TEXT,`LaunchFile` TEXT,`CompletePath` TEXT,`AssetFile` TEXT);";
                sqLiteCommand2.ExecuteNonQuery();
                Log.WriteToLog("Created missing table 'knownApps'");
                flag2 = true;
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error creating table 'knownApps': " + ex.Message);
                ProjectData.ClearProjectError();
              }
            }
          }
          SQLiteCommand sqLiteCommand3 = new SQLiteCommand(OTTDB.ott_cnn);
          sqLiteCommand3.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='profiles'";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand3.ExecuteReader())
          {
            if (!sqLiteDataReader.HasRows)
            {
              sqLiteDataReader.Close();
              try
              {
                sqLiteCommand3.CommandText = "CREATE TABLE IF Not EXISTS `profiles` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`PPDP`\tTEXT DEFAULT '0',`ASW` TEXT Default 'Inherit',`Priority` TEXT Default 'Normal',`LaunchFile` TEXT,`Path` TEXT,`Method` TEXT,`ASWDelay`\tTEXT DEFAULT '5',`CPUDelay` DEFAULT '5',`Mirror` TEXT DEFAULT '0',`GPUScaling` TEXT DEFAULT '1',`Comment` TEXT DEFAULT '',`FOV` TEXT DEFAULT '0.0 0.0',`ForceMipMap` TEXT DEFAULT 'False',`OffsetMipMap` TEXT DEFAULT '0',`Enabled` TEXT DEFAULT 'Yes');";
                sqLiteCommand3.ExecuteNonQuery();
                Log.WriteToLog("Created missing table 'profiles'");
                flag2 = true;
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error creating table 'profiles': " + ex.Message);
                ProjectData.ClearProjectError();
              }
            }
            else
            {
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "ASWDelay", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN ASWDelay Default 5"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'ASWDelay'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'ASWDelay': " + ex.Message);
                ProjectData.ClearProjectError();
              }
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "CPUDelay", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN CPUDelay Default 5"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'CPUDelay'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'CPUDelay': " + ex.Message);
                ProjectData.ClearProjectError();
              }
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "Mirror", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN Mirror Default 0"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'Mirror'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'Mirror': " + ex.Message);
                ProjectData.ClearProjectError();
              }
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "GPUScaling", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN GPUScaling Default 1"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'GPUScaling'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'GPUScaling': " + ex.Message);
                ProjectData.ClearProjectError();
              }
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "Comment", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN Comment Default ''"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'Comment'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'Comment': " + ex.Message);
                ProjectData.ClearProjectError();
              }
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "FOV", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN FOV Default '0.0 0.0'"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'FOV'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'FOV': " + ex.Message);
                ProjectData.ClearProjectError();
              }
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "ForceMipMap", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN ForceMipMap Default 'False'"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'ForceMipMap'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'ForceMipMap': " + ex.Message);
                ProjectData.ClearProjectError();
              }
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "OffsetMipMap", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN OffsetMipMap Default '0'"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'OffsetMipMap'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'OffsetMipMap': " + ex.Message);
                ProjectData.ClearProjectError();
              }
              try
              {
                if (!OTTDB.CheckIfColumnExists("profiles", "Enabled", OTTDB.ott_cnn))
                {
                  new SQLiteCommand(OTTDB.ott_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN Enabled Default 'Yes'"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'Enabled'");
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error adding missing column 'Enabled': " + ex.Message);
                ProjectData.ClearProjectError();
              }
            }
          }
          SQLiteCommand sqLiteCommand4 = new SQLiteCommand(OTTDB.ott_cnn);
          sqLiteCommand4.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='hiddenApps'";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand4.ExecuteReader())
          {
            if (!sqLiteDataReader.HasRows)
            {
              sqLiteDataReader.Close();
              try
              {
                sqLiteCommand4.CommandText = "CREATE TABLE IF Not EXISTS `hiddenApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`LaunchFile` TEXT,`Location` TEXT);";
                sqLiteCommand4.ExecuteNonQuery();
                Log.WriteToLog("Created missing table 'hiddenApps'");
                flag2 = true;
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error creating table 'hiddenApps': " + ex.Message);
                ProjectData.ClearProjectError();
              }
            }
          }
          SQLiteCommand sqLiteCommand5 = new SQLiteCommand(OTTDB.ott_cnn);
          sqLiteCommand5.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='customVoice'";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand5.ExecuteReader())
          {
            if (!sqLiteDataReader.HasRows)
            {
              sqLiteDataReader.Close();
              try
              {
                sqLiteCommand5.CommandText = "CREATE TABLE IF Not EXISTS `customVoice` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Type` TEXT,`Action` TEXT,`Command` TEXT,`Enabled` TEXT);";
                sqLiteCommand5.ExecuteNonQuery();
                Log.WriteToLog("Created missing table 'customVoice'");
                flag2 = true;
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error creating table 'customVoice': " + ex.Message);
                ProjectData.ClearProjectError();
              }
            }
          }
          SQLiteCommand sqLiteCommand6 = new SQLiteCommand(OTTDB.ott_cnn);
          sqLiteCommand6.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='includedApps'";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand6.ExecuteReader())
          {
            if (!sqLiteDataReader.HasRows)
            {
              sqLiteDataReader.Close();
              try
              {
                sqLiteCommand6.CommandText = "CREATE TABLE IF Not EXISTS `includedApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);";
                sqLiteCommand6.ExecuteNonQuery();
                Log.WriteToLog("Created missing table 'includedApps'");
                flag2 = true;
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error creating table 'includedApps': " + ex.Message);
                ProjectData.ClearProjectError();
              }
            }
          }
          SQLiteCommand sqLiteCommand7 = new SQLiteCommand(OTTDB.ott_cnn);
          sqLiteCommand7.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='LinkPresets'";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand7.ExecuteReader())
          {
            if (!sqLiteDataReader.HasRows)
            {
              sqLiteDataReader.Close();
              try
              {
                sqLiteCommand7.CommandText = "CREATE TABLE IF Not EXISTS `LinkPresets` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Name` TEXT,`Curve` TEXT,`Encoding` TEXT,`Bitrate` TEXT,`Sharpening` TEXT,`DBR` TEXT);";
                sqLiteCommand7.ExecuteNonQuery();
                Log.WriteToLog("Created missing table 'LinkPresets'");
                flag2 = true;
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                Log.WriteToLog("Error creating table 'LinkPresets': " + ex.Message);
                ProjectData.ClearProjectError();
              }
            }
            try
            {
              if (!OTTDB.CheckIfColumnExists("LinkPresets", "Bitrate", OTTDB.ott_cnn))
              {
                new SQLiteCommand(OTTDB.ott_cnn)
                {
                  CommandText = "ALTER TABLE LinkPresets ADD COLUMN Bitrate Default 150"
                }.ExecuteNonQuery();
                Log.WriteToLog("Added missing column 'Bitrate'");
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Log.WriteToLog("Error adding missing column 'Bitrate': " + ex.Message);
              ProjectData.ClearProjectError();
            }
            try
            {
              if (!OTTDB.CheckIfColumnExists("LinkPresets", "Sharpening", OTTDB.ott_cnn))
              {
                new SQLiteCommand(OTTDB.ott_cnn)
                {
                  CommandText = "ALTER TABLE LinkPresets ADD COLUMN Sharpening Default 0"
                }.ExecuteNonQuery();
                Log.WriteToLog("Added missing column 'Sharpening'");
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Log.WriteToLog("Error adding missing column 'Sharpening': " + ex.Message);
              ProjectData.ClearProjectError();
            }
            try
            {
              if (!OTTDB.CheckIfColumnExists("LinkPresets", "DBR", OTTDB.ott_cnn))
              {
                new SQLiteCommand(OTTDB.ott_cnn)
                {
                  CommandText = "ALTER TABLE LinkPresets ADD COLUMN DBR Default 0"
                }.ExecuteNonQuery();
                Log.WriteToLog("Added missing column 'DBR'");
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Log.WriteToLog("Error adding missing column 'DBR': " + ex.Message);
              ProjectData.ClearProjectError();
            }
          }
        }
        Log.WriteToLog("Database is open for business");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("OpenOttDb " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private static bool CheckIfColumnExists(
      string tableName,
      string columnName,
      SQLiteConnection cnn)
    {
      SQLiteCommand command = cnn.CreateCommand();
      command.CommandText = string.Format("PRAGMA table_info({0})", (object) tableName);
      SQLiteDataReader sqLiteDataReader = command.ExecuteReader();
      int ordinal = sqLiteDataReader.GetOrdinal("Name");
      while (sqLiteDataReader.Read())
      {
        if (sqLiteDataReader.GetString(ordinal).Equals(columnName))
          return true;
      }
      return false;
    }

    public static void GetVoiceProfileNames()
    {
      Log.WriteToLog("Reading voice profiles");
      MyProject.Forms.FrmMain.voiceProfileNames.Clear();
      using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
      {
        CommandText = "select distinct Name from userVoice"
      }.ExecuteReader())
      {
        if (!sqLiteDataReader.HasRows)
          return;
        while (sqLiteDataReader.Read())
          MyProject.Forms.FrmMain.voiceProfileNames.Add(Conversions.ToString(sqLiteDataReader[0]));
      }
    }

    public static object GetVoiceProfileCommands(string profileName)
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(OTTDB.ott_cnn);
      List<string> voiceProfileCommands = new List<string>();
      sqLiteCommand.CommandText = "select SpokenCommand,Actions,GameProfile from userVoice where Name = \"" + profileName + "\"";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
            voiceProfileCommands.Add(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(sqLiteDataReader[0], (object) "|"), sqLiteDataReader[1]), (object) "|"), sqLiteDataReader[2])));
        }
      }
      return (object) voiceProfileCommands;
    }

    public static void AddVoiceProfileCommand(
      string voiceProfile,
      string gameProfile,
      string spoken,
      string actions)
    {
      new SQLiteCommand(OTTDB.ott_cnn)
      {
        CommandText = ("insert Or replace into userVoice (ID, Name, SpokenCommand, Actions, GameProfile) values ((select ID from userVoice where SpokenCommand = \"" + spoken + "\"), \"" + voiceProfile + "\",\"" + spoken + "\",\"" + actions + "\")")
      }.ExecuteNonQuery();
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
      OTTDB.numWMI = 0;
      OTTDB.numTimer = 0;
      SQLiteCommand sqLiteCommand = new SQLiteCommand(OTTDB.ott_cnn);
      try
      {
        sqLiteCommand.CommandText = "select * from profiles";
        using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            while (sqLiteDataReader.Read())
            {
              string text1 = Conversions.ToString(sqLiteDataReader[1]);
              string text2 = Conversions.ToString(sqLiteDataReader[2]);
              string text3 = Conversions.ToString(sqLiteDataReader[3]);
              string str1 = Conversions.ToString(sqLiteDataReader[4]);
              string str2 = Conversions.ToString(sqLiteDataReader[5]);
              string str3 = Conversions.ToString(sqLiteDataReader[6]);
              string Left = Conversions.ToString(sqLiteDataReader[7]);
              string str4 = Conversions.ToString(sqLiteDataReader.FieldCount > 8 ? sqLiteDataReader[8] : (object) "5");
              string str5 = Conversions.ToString(sqLiteDataReader.FieldCount > 9 ? sqLiteDataReader[9] : (object) "5");
              string str6 = Conversions.ToString(sqLiteDataReader[10]);
              string str7 = Conversions.ToString(sqLiteDataReader[11]);
              string str8 = Conversions.ToString(sqLiteDataReader[12]);
              string str9 = Conversions.ToString(sqLiteDataReader[13]);
              string str10 = Conversions.ToString(sqLiteDataReader[14]);
              string str11 = Conversions.ToString(sqLiteDataReader[15]);
              string str12 = Conversions.ToString(sqLiteDataReader[16]);
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str12, "No", false) == 0)
                checked { ++num; }
              try
              {
                foreach (KeyValuePair<string, string> game in MyProject.Forms.frmProfiles.GameList)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(game.Value, str3, false) == 0)
                  {
                    MyProject.Forms.frmProfiles.GameList.Remove(game.Key);
                    break;
                  }
                }
              }
              finally
              {
                Dictionary<string, string>.Enumerator enumerator;
                enumerator.Dispose();
              }
              MyProject.Forms.frmLibrary.DisplayNameList.Add(text1.ToLower());
              ListViewItem listViewItem1 = new ListViewItem();
              ListViewItem listViewItem2 = MyProject.Forms.frmProfiles.ListView1.Items.Add(text1);
              listViewItem2.Tag = (object) (text1 + "," + text2 + "," + text3 + "," + Left + "," + str1 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + "," + str10 + "," + str11 + "," + str12);
              listViewItem2.SubItems.Add(text2);
              listViewItem2.SubItems.Add(text3);
              listViewItem2.SubItems.Add(str1);
              listViewItem2.SubItems.Add(str12);
              if (Globals.dbg)
                Log.WriteToLog(text1 + "," + text3 + "," + text2 + "," + str1 + "," + str2 + "," + str3 + "," + Left);
              checked { ++GetConfig.numprofiles; }
              if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str12, "Yes", false) == 0)
              {
                MyProject.Forms.FrmMain.profileDisplayNames.Add(str3, text1);
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "WMI", false) == 0)
                {
                  MyProject.Forms.FrmMain.profileList.Add(str3.ToLower(), text2);
                  checked { ++OTTDB.numWMI; }
                }
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "Timer", false) == 0)
                {
                  MyProject.Forms.FrmMain.profileTimerList.Add(str3, text2);
                  checked { ++OTTDB.numTimer; }
                }
                MyProject.Forms.frmLibrary.ManualStartProfiles.Add(str3.ToLower(), text2);
                MyProject.Forms.FrmMain.profileASWList.Add(str3.ToLower(), text3);
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "Default", false) != 0)
                {
                  MyProject.Forms.FrmMain.profilePriorityList.Add(str3.ToLower(), str1);
                  MyProject.Forms.FrmMain.profileCpuDelay.Add(str3.ToLower(), str5);
                }
                MyProject.Forms.FrmMain.profileNames.Add(str3);
                MyProject.Forms.FrmMain.profileAswDelay.Add(str3.ToLower(), str4);
                MyProject.Forms.FrmMain.profilePaths.Add(str3, str2);
                MyProject.Forms.FrmMain.profileMirror.Add(str3.ToLower(), str6);
                MyProject.Forms.FrmMain.profileAGPS.Add(str3.ToLower(), str7);
                MyProject.Forms.FrmMain.profileFOV.Add(str3.ToLower(), str9);
                MyProject.Forms.FrmMain.profileOffsetMipMap.Add(str3.ToLower(), str11);
                MyProject.Forms.FrmMain.profileForceMipMap.Add(str3.ToLower(), str10);
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
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetProfiles(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void AddProfile(
      string displayname,
      string asw,
      string ppdp,
      string priority,
      string LaunchFile,
      string path,
      string method,
      string aswdelay,
      string cpudelay,
      string mirror,
      string agps,
      string comment,
      string fov,
      string forcemipmap,
      string offsetmipmap,
      string enabled)
    {
      try
      {
        new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("insert Or replace into profiles (ID, DisplayName, PPDP, ASW, Priority, LaunchFile, Path, Method, ASWDelay, CPUDelay, Mirror, GPUScaling, Comment, FOV, ForceMipMap, OffsetMipMap, Enabled) values ((select ID from Profiles where Path = \"" + path + "\"), \"" + displayname + "\",\"" + ppdp + "\",\"" + asw + "\",\"" + priority + "\",\"" + LaunchFile + "\",\"" + path + "\",\"" + method + "\",\"" + aswdelay + "\",\"" + cpudelay + "\",\"" + mirror + "\",\"" + agps + "\",\"" + comment + "\",\"" + fov + "\",\"" + forcemipmap + "\",\"" + offsetmipmap + "\",\"" + enabled + "\")")
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
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("AddProfile: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void UpdateProfile(string asw, string ppdp, string path, string name)
    {
      try
      {
        SQLiteCommand sqLiteCommand = new SQLiteCommand(OTTDB.ott_cnn);
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(asw, (string) null, false) != 0)
        {
          sqLiteCommand.CommandText = "UPDATE profiles SET ASW=" + asw + " WHERE Path = \"" + path + "\"";
          sqLiteCommand.ExecuteNonQuery();
          Log.WriteToLog("Updated '" + name + "'. New ASW setting is '" + asw + "'");
        }
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(ppdp, (string) null, false) == 0)
          return;
        sqLiteCommand.CommandText = "UPDATE profiles SET PPDP=" + ppdp + " WHERE Path = \"" + path + "\"";
        sqLiteCommand.ExecuteNonQuery();
        Log.WriteToLog("Updated '" + name + "'. New Pixel Density setting is '" + ppdp + "'");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("UpdateProfile: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void RemoveProfile(string Path)
    {
      try
      {
        SQLiteCommand sqLiteCommand = new SQLiteCommand(OTTDB.ott_cnn);
        string displayName = OTTDB.GetDisplayName(Path);
        sqLiteCommand.CommandText = "delete from profiles where path = \"" + Path + "\"";
        sqLiteCommand.ExecuteNonQuery();
        Log.WriteToLog("Profile for '" + displayName + "' has been removed");
        FrmMain.fmain.AddToListboxAndScroll("Profile for '" + displayName + "' has been removed");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("RemoveProfile: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

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
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("RemoveAllProfiles: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void HideApp(string displayname, string launchfile, string location)
    {
      try
      {
        new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("insert or replace into hiddenApps (ID, DisplayName, LaunchFile, Location) values ((select ID from hiddenApps where LaunchFile = \"" + launchfile + "\" AND DisplayName = \"" + displayname + "\"), \"" + displayname + "\",\"" + launchfile + "\",\"" + location + "\")")
        }.ExecuteNonQuery();
        Log.WriteToLog("App hidden: " + displayname);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("HideApp: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void UnHideApp(string displayname)
    {
      try
      {
        new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("DELETE from hiddenApps where DisplayName = \"" + displayname + "\"")
        }.ExecuteNonQuery();
        Log.WriteToLog("App Visible: " + displayname);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("UnHideApp: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static bool CheckHiddenApp(string launchfile, string displayname, string location)
    {
      return Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectNotEqual(new SQLiteCommand(OTTDB.ott_cnn)
      {
        CommandText = ("select * from hiddenApps where DisplayName = \"" + displayname + "\" AND Location = \"" + location + "\" AND LaunchFile = \"" + launchfile + "\"")
      }.ExecuteScalar(), (object) 0, false);
    }

    public static object GetHiddenApps()
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(OTTDB.ott_cnn);
      List<string> hiddenApps = new List<string>();
      sqLiteCommand.CommandText = "select DisplayName from hiddenApps";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
            hiddenApps.Add(Conversions.ToString(sqLiteDataReader[0]));
        }
      }
      return (object) hiddenApps;
    }

    public static object GetIgnoredApps()
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(OTTDB.ott_cnn);
      List<string> ignoredApps = new List<string>();
      sqLiteCommand.CommandText = "select FileName from ignoredApps";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
          {
            ignoredApps.Add(Conversions.ToString(sqLiteDataReader[0]));
            if (!File.Exists(Conversions.ToString(sqLiteDataReader[0])))
              OTTDB.RemoveIgnoredApp(Conversions.ToString(sqLiteDataReader[0]));
          }
        }
      }
      return (object) ignoredApps;
    }

    public static object GetIncludedApps()
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(OTTDB.ott_cnn);
      List<string> includedApps = new List<string>();
      sqLiteCommand.CommandText = "select FileName from includedApps";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
          {
            includedApps.Add(Conversions.ToString(sqLiteDataReader[0]));
            if (!File.Exists(Conversions.ToString(sqLiteDataReader[0])))
              OTTDB.RemoveIncludedApp(Conversions.ToString(sqLiteDataReader[0]));
          }
        }
      }
      return (object) includedApps;
    }

    public static void RemoveIgnoredApp(string name)
    {
      new SQLiteCommand(OTTDB.ott_cnn)
      {
        CommandText = ("delete from ignoredApps where FileName = \"" + name + "\"")
      }.ExecuteNonQuery();
    }

    public static void RemoveIncludedApp(string name)
    {
      new SQLiteCommand(OTTDB.ott_cnn)
      {
        CommandText = ("delete from includedApps where FileName = \"" + name + "\"")
      }.ExecuteNonQuery();
    }

    public static object GetknownApps()
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(OTTDB.ott_cnn);
      List<string> stringList = new List<string>();
      sqLiteCommand.CommandText = "select FileName from knownApps";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
            stringList.Add(Conversions.ToString(sqLiteDataReader[0]));
        }
      }
      return (object) stringList;
    }

    public static object GetknownAppDetails(string filename)
    {
      string str;
      using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
      {
        CommandText = ("select DisplayName, LaunchFile, CompletePath, AssetFile from knownApps where FileName = \"" + filename + "\"")
      }.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
            str = Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject(sqLiteDataReader[0], (object) ","), sqLiteDataReader[1]), (object) ","), sqLiteDataReader[2]), (object) ","), sqLiteDataReader[3]));
        }
      }
      return (object) str;
    }

    public static void AddKnownApp(
      string filename,
      string displayname,
      string launchfile,
      string completepath,
      string assetfile)
    {
      try
      {
        new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("insert into knownApps (FileName, DisplayName, LaunchFile, CompletePath, AssetFile) values (\"" + filename + "\",\"" + displayname + "\",\"" + launchfile + "\",\"" + completepath + "\",\"" + assetfile + "\")")
        }.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("AddKnownApp: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void AddIgnoreApp(string filename)
    {
      try
      {
        new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("insert into ignoredApps (FileName) values (\"" + filename + "\")")
        }.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("AddIgnoreApp: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void AddIncludedApp(string filename)
    {
      try
      {
        new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("insert into includedApps (FileName) values (\"" + filename + "\")")
        }.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("AddIncludedApp: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static string GetDisplayName(string path)
    {
      string displayName;
      try
      {
        using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("select DisplayName from Profiles where Path = \"" + path + "\" COLLATE NOCASE")
        }.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            if (sqLiteDataReader.Read())
            {
              displayName = Conversions.ToString(sqLiteDataReader[0]);
              goto label_10;
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("UpdateProfile: " + ex.Message);
        ProjectData.ClearProjectError();
      }
label_10:
      return displayName;
    }

    public static void AddLinkPreset(
      string name,
      string curve,
      string encoding,
      string bitrate,
      string sharpening,
      string dbr)
    {
      try
      {
        new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("insert or replace into LinkPresets (ID, Name, Curve, Encoding, Bitrate, Sharpening, DBR) values ((select ID from LinkPresets where Name = \"" + name + "\"), \"" + name + "\",\"" + curve + "\",\"" + encoding + "\",\"" + bitrate + "\",\"" + sharpening + "\",\"" + dbr + "\")")
        }.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("AddLinkPreset: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static string GetLinkPresetValueByName(string name, string value)
    {
      string presetValueByName;
      try
      {
        using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("select " + value + " from LinkPresets where Name = \"" + name + "\" COLLATE NOCASE")
        }.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            if (sqLiteDataReader.Read())
            {
              presetValueByName = Conversions.ToString(sqLiteDataReader[0]);
              goto label_10;
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetLinkPresetValueByName: " + ex.Message);
        ProjectData.ClearProjectError();
      }
label_10:
      return presetValueByName;
    }

    public static string GetLinkPresetValueByValues(
      string curve,
      string encoding,
      string bitrate,
      string sharpening,
      string dbr)
    {
      string presetValueByValues;
      try
      {
        using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("select Name from LinkPresets where Curve = \"" + curve + "\" AND Encoding = \"" + encoding + "\" AND Bitrate = \"" + bitrate + "\" AND Sharpening = \"" + sharpening + "\" AND DBR = \"" + dbr + "\"")
        }.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            if (sqLiteDataReader.Read())
            {
              presetValueByValues = Conversions.ToString(sqLiteDataReader[0]);
              goto label_10;
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetLinkPresetValueByValues: " + ex.Message);
        ProjectData.ClearProjectError();
      }
label_10:
      return presetValueByValues;
    }

    public static string RemoveLinkPresetByName(string name)
    {
      try
      {
        new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = ("delete from LinkPresets where Name = \"" + name + "\"")
        }.ExecuteNonQuery();
        Log.WriteToLog("Link Preset '" + name + "' has been removed");
        FrmMain.fmain.AddToListboxAndScroll("Link Preset '" + name + "' has been removed");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("RemoveLinkPresetValueByName: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      string str;
      return str;
    }

    public static List<string> GetLinkPresetNames()
    {
      try
      {
        List<string> stringList = new List<string>();
        using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(OTTDB.ott_cnn)
        {
          CommandText = "select Name from LinkPresets"
        }.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            while (sqLiteDataReader.Read())
            {
              FrmMain.fmain.ComboBox4.Items.Add(RuntimeHelpers.GetObjectValue(sqLiteDataReader[0]));
              stringList.Add(Conversions.ToString(sqLiteDataReader[0]));
            }
          }
        }
        if (!stringList.Contains("GTX 970+"))
        {
          OTTDB.AddLinkPreset("GTX 970+", "Default", "2016", "300", "Auto", "0");
          FrmMain.fmain.ComboBox4.Items.Add((object) "GTX 970+");
        }
        if (!stringList.Contains("GTX 1070+"))
        {
          OTTDB.AddLinkPreset("GTX 1070+", "High", "2352", "350", "Auto", "0");
          FrmMain.fmain.ComboBox4.Items.Add((object) "GTX 1070+");
        }
        if (!stringList.Contains("RTX 2070+"))
        {
          OTTDB.AddLinkPreset("RTX 2070+", "Low", "2912", "400", "Auto", "0");
          FrmMain.fmain.ComboBox4.Items.Add((object) "RTX 2070+");
        }
        if (!stringList.Contains("GTX 1080Ti/RTX 2080+"))
        {
          OTTDB.AddLinkPreset("GTX 1080Ti/RTX 2080+", "Low", "3648", "450", "Auto", "0");
          FrmMain.fmain.ComboBox4.Items.Add((object) "GTX 1080Ti/RTX 2080+");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetLinkPresetCurve: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      List<string> linkPresetNames;
      return linkPresetNames;
    }

    public static void CheckDB()
    {
      Log.WriteToLog("Performing database consistency check...");
      FrmMain.fmain.AddToListboxAndScroll("Performing database consistency check...");
      try
      {
        if (OTTDB.ott_cnn.State == ConnectionState.Closed)
        {
          OTTDB.ott_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\ott.db");
          OTTDB.ott_cnn.Open();
        }
        SQLiteCommand sqLiteCommand1 = new SQLiteCommand(OTTDB.ott_cnn);
        List<string> stringList = new List<string>();
        int num1 = 0;
        int num2 = 0;
        int integer1;
        try
        {
          sqLiteCommand1.CommandText = "select ID, DisplayName, CompletePath from knownApps";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand1.ExecuteReader())
          {
            if (sqLiteDataReader.HasRows)
            {
              while (sqLiteDataReader.Read())
              {
                integer1 = Conversions.ToInteger(sqLiteDataReader[0]);
                string str1 = Conversions.ToString(sqLiteDataReader[1]);
                string str2 = Conversions.ToString(sqLiteDataReader[2]);
                if (str2.Contains("\\\\") | str2.Contains("/"))
                {
                  string path = str2.Replace("\\\\", "\\").Replace("/", "\\");
                  if (File.Exists(path))
                  {
                    Log.WriteToLog(str1 + " has incorrect path in knownApps, correcting it");
                    SQLiteCommand sqLiteCommand2 = new SQLiteCommand(OTTDB.ott_cnn);
                    sqLiteCommand2.CommandText = "UPDATE knownApps SET CompletePath = '" + path + "' WHERE CompletePath = '" + str2 + "'";
                    sqLiteCommand2.ExecuteNonQuery();
                    sqLiteCommand2.Dispose();
                    checked { ++num1; }
                  }
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          if (Globals.dbg)
            Log.WriteToLog("Table 'knownApps' does not exist yet, ignoring");
          ProjectData.ClearProjectError();
        }
        try
        {
          sqLiteCommand1.CommandText = "select ID, DisplayName, Path from profiles";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand1.ExecuteReader())
          {
            if (sqLiteDataReader.HasRows)
            {
              while (sqLiteDataReader.Read())
              {
                integer1 = Conversions.ToInteger(sqLiteDataReader[0]);
                string str = Conversions.ToString(sqLiteDataReader[1]);
                string path1 = Conversions.ToString(sqLiteDataReader[2]);
                if (path1.Contains("\\\\") | path1.Contains("/"))
                {
                  string path2 = path1.Replace("\\\\", "\\").Replace("/", "\\");
                  if (File.Exists(path2))
                  {
                    Log.WriteToLog(str + " has incorrect path in profiles, correcting it");
                    SQLiteCommand sqLiteCommand3 = new SQLiteCommand(OTTDB.ott_cnn);
                    sqLiteCommand3.CommandText = "UPDATE profiles SET Path = '" + path2 + "' WHERE Path = '" + path1 + "'";
                    sqLiteCommand3.ExecuteNonQuery();
                    sqLiteCommand3.Dispose();
                    checked { ++num1; }
                  }
                  else
                  {
                    checked { ++num2; }
                    Log.WriteToLog("WARNING: Path for profile '" + str + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
                    MyProject.Forms.FrmMain.AddToListboxAndScroll("WARNING: Path for profile '" + str + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
                  }
                }
                else if (!File.Exists(path1))
                {
                  checked { ++num2; }
                  Log.WriteToLog("WARNING: Path for profile '" + str + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
                  MyProject.Forms.FrmMain.AddToListboxAndScroll("WARNING: Path for profile '" + str + "' does not exist. Game might have been uninstalled. Recommend removing the profile.");
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          if (Globals.dbg)
            Log.WriteToLog("Table 'profiles' does not exist!");
          ProjectData.ClearProjectError();
        }
        try
        {
          sqLiteCommand1.CommandText = "select ID, Mirror, DisplayName from profiles";
          using (SQLiteDataReader sqLiteDataReader = sqLiteCommand1.ExecuteReader())
          {
            if (sqLiteDataReader.HasRows)
            {
              while (sqLiteDataReader.Read())
              {
                int integer2 = Conversions.ToInteger(sqLiteDataReader[0]);
                string Left = Conversions.ToString(sqLiteDataReader[1]);
                string str = Conversions.ToString(sqLiteDataReader[2]);
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "0", false) != 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "1", false) != 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "2", false) != 0)
                {
                  Log.WriteToLog(str + " has incorrect value for 'Mirror' in profiles, correcting it");
                  MyProject.Forms.FrmMain.AddToListboxAndScroll(str + " has incorrect value for 'Mirror' in profiles, correcting it");
                  SQLiteCommand sqLiteCommand4 = new SQLiteCommand(OTTDB.ott_cnn);
                  sqLiteCommand4.CommandText = "UPDATE profiles SET Mirror = '0' WHERE ID = '" + Conversions.ToString(integer2) + "'";
                  sqLiteCommand4.ExecuteNonQuery();
                  sqLiteCommand4.Dispose();
                  checked { ++num1; }
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          if (Globals.dbg)
            Log.WriteToLog("Table 'profiles' does not exist!");
          ProjectData.ClearProjectError();
        }
        if (num1 > 0)
        {
          Log.WriteToLog("Fixed " + Conversions.ToString(num1) + " problems");
          FrmMain.fmain.AddToListboxAndScroll("Fixed " + Conversions.ToString(num1) + " problems");
        }
        if (num1 == 0 & num2 == 0)
        {
          Log.WriteToLog("No issues found");
          FrmMain.fmain.AddToListboxAndScroll("No issues found");
        }
        MySettingsProperty.Settings.DBCheck = false;
        MySettingsProperty.Settings.Save();
        OTTDB.ott_cnn.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        OTTDB.ott_cnn.Close();
        MySettingsProperty.Settings.DBCheck = false;
        MySettingsProperty.Settings.Save();
        Log.WriteToLog("CheckDB: " + exception.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void AddDefaultLinkPresets()
    {
    }
  }
}
