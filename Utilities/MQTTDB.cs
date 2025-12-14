using MetaQuestTrayTool.Forms;


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;


#nullable disable
namespace MetaQuestTrayTool
{

  internal sealed class MQTTDB
  {
    public static SQLiteConnection MQTT_cnn = new SQLiteConnection();
    public static string updatedProfile = "";
    public static int numWMI = 0;
    public static int numTimer = 0;

    public static void OpenMQTTDB()
    {
      try
      {
        bool flag1 = false;
        bool flag2 = false;
        if (File.Exists(Application.StartupPath + "\\MQTT.db"))
          flag1 = true;
        if (!flag1)
        {
          Log.WriteToLog("MQTT.db not found, creating..");
          MQTTDB.MQTT_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\MQTT.db");
          MQTTDB.MQTT_cnn.Open();
          new SQLiteCommand(MQTTDB.MQTT_cnn)
          {
            CommandText = "CREATE TABLE `profiles` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`PPDP`\tTEXT DEFAULT '0',`ASW` TEXT Default 'Inherit',`Priority` TEXT Default 'Normal',`LaunchFile` TEXT,`Path` TEXT,`Method` TEXT,`ASWDelay`\tTEXT DEFAULT '5',`CPUDelay` TEXT DEFAULT '5',`Mirror` TEXT DEFAULT '0',`GPUScaling` TEXT DEFAULT '1',`Comment` TEXT DEFAULT '',`FOV` TEXT DEFAULT '0.0 0.0',`ForceMipMap` TEXT DEFAULT 'False',`OffsetMipMap` TEXT DEFAULT '0',`Enabled` TEXT DEFAULT 'Yes');"
          }.ExecuteNonQuery();
          new SQLiteCommand(MQTTDB.MQTT_cnn)
          {
            CommandText = "CREATE TABLE `hiddenApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`DisplayName` TEXT,`LaunchFile` TEXT,`Location` TEXT);"
          }.ExecuteNonQuery();
          new SQLiteCommand(MQTTDB.MQTT_cnn)
          {
            CommandText = "CREATE TABLE `ignoredApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);"
          }.ExecuteNonQuery();
          new SQLiteCommand(MQTTDB.MQTT_cnn)
          {
            CommandText = "CREATE TABLE `knownApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT,`DisplayName` TEXT,`LaunchFile` TEXT,`CompletePath` TEXT,`AssetFile` TEXT);"
          }.ExecuteNonQuery();
          new SQLiteCommand(MQTTDB.MQTT_cnn)
          {
            CommandText = "CREATE TABLE `customVoice` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Type` TEXT,`Action` TEXT,`Command` TEXT,`Enabled` INTEGER);"
          }.ExecuteNonQuery();
          new SQLiteCommand(MQTTDB.MQTT_cnn)
          {
            CommandText = "CREATE TABLE `includedApps` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`FileName` TEXT);"
          }.ExecuteNonQuery();
          new SQLiteCommand(MQTTDB.MQTT_cnn)
          {
            CommandText = "CREATE TABLE `LinkPresets` (`ID` Integer PRIMARY KEY AUTOINCREMENT,`Name` TEXT,`Curve` TEXT,`Encoding` TEXT,`Bitrate` TEXT,`Sharpening` TEXT,`DBR` TEXT);"
          }.ExecuteNonQuery();
        }
        else
        {
          if (MQTTDB.MQTT_cnn.State == ConnectionState.Closed)
          {
            Log.WriteToLog("Opening connection to MQTT.db");
            MQTTDB.MQTT_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\MQTT.db");
            MQTTDB.MQTT_cnn.Open();
          }
          SQLiteCommand sqLiteCommand1 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
                Log.WriteToLog("Error creating table 'ignoredApps': " + ex.Message);
              }
            }
          }
          SQLiteCommand sqLiteCommand2 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
                Log.WriteToLog("Error creating table 'knownApps': " + ex.Message);
              }
            }
          }
          SQLiteCommand sqLiteCommand3 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
                Log.WriteToLog("Error creating table 'profiles': " + ex.Message);
              }
            }
            else
            {
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "ASWDelay", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN ASWDelay Default 5"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'ASWDelay'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'ASWDelay': " + ex.Message);
              }
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "CPUDelay", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN CPUDelay Default 5"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'CPUDelay'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'CPUDelay': " + ex.Message);
              }
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "Mirror", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN Mirror Default 0"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'Mirror'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'Mirror': " + ex.Message);
              }
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "GPUScaling", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN GPUScaling Default 1"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'GPUScaling'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'GPUScaling': " + ex.Message);
              }
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "Comment", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN Comment Default ''"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'Comment'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'Comment': " + ex.Message);
              }
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "FOV", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN FOV Default '0.0 0.0'"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'FOV'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'FOV': " + ex.Message);
              }
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "ForceMipMap", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN ForceMipMap Default 'False'"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'ForceMipMap'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'ForceMipMap': " + ex.Message);
              }
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "OffsetMipMap", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN OffsetMipMap Default '0'"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'OffsetMipMap'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'OffsetMipMap': " + ex.Message);
              }
              try
              {
                if (!MQTTDB.CheckIfColumnExists("profiles", "Enabled", MQTTDB.MQTT_cnn))
                {
                  new SQLiteCommand(MQTTDB.MQTT_cnn)
                  {
                    CommandText = "ALTER TABLE profiles ADD COLUMN Enabled Default 'Yes'"
                  }.ExecuteNonQuery();
                  Log.WriteToLog("Added missing column 'Enabled'");
                }
              }
              catch (Exception ex)
              {
                Log.WriteToLog("Error adding missing column 'Enabled': " + ex.Message);
              }
            }
          }
          SQLiteCommand sqLiteCommand4 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
                Log.WriteToLog("Error creating table 'hiddenApps': " + ex.Message);
              }
            }
          }
          SQLiteCommand sqLiteCommand5 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
                Log.WriteToLog("Error creating table 'customVoice': " + ex.Message);
              }
            }
          }
          SQLiteCommand sqLiteCommand6 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
                Log.WriteToLog("Error creating table 'includedApps': " + ex.Message);
              }
            }
          }
          SQLiteCommand sqLiteCommand7 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
                Log.WriteToLog("Error creating table 'LinkPresets': " + ex.Message);
              }
            }
            try
            {
              if (!MQTTDB.CheckIfColumnExists("LinkPresets", "Bitrate", MQTTDB.MQTT_cnn))
              {
                new SQLiteCommand(MQTTDB.MQTT_cnn)
                {
                  CommandText = "ALTER TABLE LinkPresets ADD COLUMN Bitrate Default 150"
                }.ExecuteNonQuery();
                Log.WriteToLog("Added missing column 'Bitrate'");
              }
            }
            catch (Exception ex)
            {
              Log.WriteToLog("Error adding missing column 'Bitrate': " + ex.Message);
            }
            try
            {
              if (!MQTTDB.CheckIfColumnExists("LinkPresets", "Sharpening", MQTTDB.MQTT_cnn))
              {
                new SQLiteCommand(MQTTDB.MQTT_cnn)
                {
                  CommandText = "ALTER TABLE LinkPresets ADD COLUMN Sharpening Default 0"
                }.ExecuteNonQuery();
                Log.WriteToLog("Added missing column 'Sharpening'");
              }
            }
            catch (Exception ex)
            {
              Log.WriteToLog("Error adding missing column 'Sharpening': " + ex.Message);
            }
            try
            {
              if (!MQTTDB.CheckIfColumnExists("LinkPresets", "DBR", MQTTDB.MQTT_cnn))
              {
                new SQLiteCommand(MQTTDB.MQTT_cnn)
                {
                  CommandText = "ALTER TABLE LinkPresets ADD COLUMN DBR Default 0"
                }.ExecuteNonQuery();
                Log.WriteToLog("Added missing column 'DBR'");
              }
            }
            catch (Exception ex)
            {
              Log.WriteToLog("Error adding missing column 'DBR': " + ex.Message);
            }
          }
        }
        Log.WriteToLog("Database is open for business");
      }
      catch (Exception ex)
      {
        Log.WriteToLog("OpenMQTTDB " + ex.Message);
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
      FrmMain.fmain.voiceProfileNames.Clear();
      using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(MQTTDB.MQTT_cnn)
      {
        CommandText = "select distinct Name from userVoice"
      }.ExecuteReader())
      {
        if (!sqLiteDataReader.HasRows)
          return;
        while (sqLiteDataReader.Read())
          FrmMain.fmain.voiceProfileNames.Add(sqLiteDataReader[0].ToString());
      }
    }

    public static object GetVoiceProfileCommands(string profileName)
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(MQTTDB.MQTT_cnn);
      List<string> voiceProfileCommands = new List<string>();
      sqLiteCommand.CommandText = "select SpokenCommand,Actions,GameProfile from userVoice where Name = \"" + profileName + "\"";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
            voiceProfileCommands.Add(sqLiteDataReader[0].ToString() + "|" + sqLiteDataReader[1].ToString() + "|" + sqLiteDataReader[2].ToString());
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
      new SQLiteCommand(MQTTDB.MQTT_cnn)
      {
        CommandText = ("insert Or replace into userVoice (ID, Name, SpokenCommand, Actions, GameProfile) values ((select ID from userVoice where SpokenCommand = \"" + spoken + "\"), \"" + voiceProfile + "\",\"" + spoken + "\",\"" + actions + "\")")
      }.ExecuteNonQuery();
    }

    public static void GetProfiles()
    {
      Log.WriteToLog("Reading profiles");
      FrmMain.fmain.profileList.Clear();
      FrmMain.fmain.profileTimerList.Clear();
      FrmMain.fmain.profileNames.Clear();
      FrmMain.fmain.profileASWList.Clear();
      FrmMain.fmain.profileDisplayNames.Clear();
      FrmMain.fmain.profilePriorityList.Clear();
      FrmMain.fmain.profileAswDelay.Clear();
      FrmMain.fmain.profileCpuDelay.Clear();
      // MyProject.Forms.frmLibrary.ManualStartProfiles.Clear(); // Needs reference to FrmLibrary instance or similar
      FrmMain.fmain.profilePaths.Clear();
      FrmMain.fmain.profileMirror.Clear();
      FrmMain.fmain.profileAGPS.Clear();
      FrmMain.fmain.profileFOV.Clear();
      FrmMain.fmain.profileForceMipMap.Clear();
      FrmMain.fmain.profileOffsetMipMap.Clear();
      // MyProject.Forms.frmProfiles.ListView1.Items.Clear(); // Needs reference to FrmProfiles instance
      // MyProject.Forms.frmLibrary.DisplayNameList.Clear();  // Needs reference to FrmLibrary instance
      GetConfig.numprofiles = 0;
      int num = 0;
      MQTTDB.numWMI = 0;
      MQTTDB.numTimer = 0;
      SQLiteCommand sqLiteCommand = new SQLiteCommand(MQTTDB.MQTT_cnn);
      try
      {
        sqLiteCommand.CommandText = "select * from profiles";
        using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
              while (sqLiteDataReader.Read())
            {
              string text1 = sqLiteDataReader[1].ToString();
              string text2 = sqLiteDataReader[2].ToString();
              string text3 = sqLiteDataReader[3].ToString();
              string str1 = sqLiteDataReader[4].ToString();
              string str2 = sqLiteDataReader[5].ToString();
              string str3 = sqLiteDataReader[6].ToString();
              string Left = sqLiteDataReader[7].ToString();
              string str4 = (sqLiteDataReader.FieldCount > 8 ? sqLiteDataReader[8] : (object) "5").ToString();
              string str5 = (sqLiteDataReader.FieldCount > 9 ? sqLiteDataReader[9] : (object) "5").ToString();
              string str6 = sqLiteDataReader[10].ToString();
              string str7 = sqLiteDataReader[11].ToString();
              string str8 = sqLiteDataReader[12].ToString();
              string str9 = sqLiteDataReader[13].ToString();
              string str10 = sqLiteDataReader[14].ToString();
              string str11 = sqLiteDataReader[15].ToString();
              string str12 = sqLiteDataReader[16].ToString();
              if (String.Compare(str12, "No", false) == 0)
                checked { ++num; }
                foreach (KeyValuePair<string, string> game in GetGames.GameList)
                {
                  if (String.Compare(game.Value, str3, false) == 0)
                  {
                    GetGames.GameList.Remove(game.Key);
                    break;
                  }
                }
              // MyProject.Forms.frmLibrary.DisplayNameList.Add(text1.ToLower());
              ListViewItem listViewItem1 = new ListViewItem();
              // ListViewItem listViewItem2 = MyProject.Forms.frmProfiles.ListView1.Items.Add(text1);
              // listViewItem2.Tag = (object) (text1 + "," + text2 + "," + text3 + "," + Left + "," + str1 + "," + str3 + "," + str4 + "," + str5 + "," + str6 + "," + str7 + "," + str8 + "," + str9 + "," + str10 + "," + str11 + "," + str12);
              // listViewItem2.SubItems.Add(text2);
              // listViewItem2.SubItems.Add(text3);
              // listViewItem2.SubItems.Add(str1);
              // listViewItem2.SubItems.Add(str12);
              if (Globals.dbg)
                Log.WriteToLog(text1 + "," + text3 + "," + text2 + "," + str1 + "," + str2 + "," + str3 + "," + Left);
              checked { ++GetConfig.numprofiles; }
              if (String.Compare(str12, "Yes", false) == 0)
              {
                FrmMain.fmain.profileDisplayNames.Add(str3, text1);
                if (String.Compare(Left, "WMI", false) == 0)
                {
                  FrmMain.fmain.profileList.Add(str3.ToLower(), text2);
                  checked { ++MQTTDB.numWMI; }
                }
                if (String.Compare(Left, "Timer", false) == 0)
                {
                  FrmMain.fmain.profileTimerList.Add(str3, text2);
                  checked { ++MQTTDB.numTimer; }
                }
                // MyProject.Forms.frmLibrary.ManualStartProfiles.Add(str3.ToLower(), text2);
                FrmMain.fmain.profileASWList.Add(str3.ToLower(), text3);
                if (String.Compare(str1, "Default", false) != 0)
                {
                  FrmMain.fmain.profilePriorityList.Add(str3.ToLower(), str1);
                  FrmMain.fmain.profileCpuDelay.Add(str3.ToLower(), str5);
                }
                FrmMain.fmain.profileNames.Add(str3);
                FrmMain.fmain.profileAswDelay.Add(str3.ToLower(), str4);
                FrmMain.fmain.profilePaths.Add(str3, str2);
                FrmMain.fmain.profileMirror.Add(str3.ToLower(), str6);
                FrmMain.fmain.profileAGPS.Add(str3.ToLower(), str7);
                FrmMain.fmain.profileFOV.Add(str3.ToLower(), str9);
                FrmMain.fmain.profileOffsetMipMap.Add(str3.ToLower(), str11);
                FrmMain.fmain.profileForceMipMap.Add(str3.ToLower(), str10);
              }
            }
          }
        }
        Log.WriteToLog(GetConfig.numprofiles.ToString() + " profiles found");
        Log.WriteToLog(num.ToString() + " profiles are disabled");
        Log.WriteToLog("  " + MQTTDB.numWMI.ToString() + " monitored using WMI");
        Log.WriteToLog("  " + MQTTDB.numTimer.ToString() + " monitored using Timer");
      }
      catch (Exception ex)
      {
        Log.WriteToLog("GetProfiles(): " + ex.Message);
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
        new SQLiteCommand(MQTTDB.MQTT_cnn)
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
        Log.WriteToLog("AddProfile: " + ex.Message);
      }
    }

    public static void UpdateProfile(string asw, string ppdp, string path, string name)
    {
      try
      {
        SQLiteCommand sqLiteCommand = new SQLiteCommand(MQTTDB.MQTT_cnn);
        if (asw != null)
        {
          sqLiteCommand.CommandText = "UPDATE profiles SET ASW=" + asw + " WHERE Path = \"" + path + "\"";
          sqLiteCommand.ExecuteNonQuery();
          Log.WriteToLog("Updated '" + name + "'. New ASW setting is '" + asw + "'");
        }
        if (ppdp == null)
          return;
        sqLiteCommand.CommandText = "UPDATE profiles SET PPDP=" + ppdp + " WHERE Path = \"" + path + "\"";
        sqLiteCommand.ExecuteNonQuery();
        Log.WriteToLog("Updated '" + name + "'. New Pixel Density setting is '" + ppdp + "'");
      }
      catch (Exception ex)
      {
        Log.WriteToLog("UpdateProfile: " + ex.Message);
      }
    }

    public static void RemoveProfile(string Path)
    {
      try
      {
        SQLiteCommand sqLiteCommand = new SQLiteCommand(MQTTDB.MQTT_cnn);
        string displayName = MQTTDB.GetDisplayName(Path);
        sqLiteCommand.CommandText = "delete from profiles where path = \"" + Path + "\"";
        sqLiteCommand.ExecuteNonQuery();
        Log.WriteToLog("Profile for '" + displayName + "' has been removed");
        FrmMain.fmain.AddToListboxAndScroll("Profile for '" + displayName + "' has been removed");
      }
      catch (Exception ex)
      {
        Log.WriteToLog("RemoveProfile: " + ex.Message);
      }
    }

    public static void RemoveAllProfiles()
    {
      try
      {
        new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = "delete from profiles"
        }.ExecuteNonQuery();
        Log.WriteToLog("All Profiles have been removed");
        FrmMain.fmain.AddToListboxAndScroll("All Profiles have been removed");
        // MyProject.Forms.frmProfiles.ListView1.Items.Clear(); // Needs ref
        MQTTDB.GetProfiles();
      }
      catch (Exception ex)
      {
        Log.WriteToLog("RemoveAllProfiles: " + ex.Message);
      }
    }

    public static void HideApp(string displayname, string launchfile, string location)
    {
      try
      {
        new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("insert or replace into hiddenApps (ID, DisplayName, LaunchFile, Location) values ((select ID from hiddenApps where LaunchFile = \"" + launchfile + "\" AND DisplayName = \"" + displayname + "\"), \"" + displayname + "\",\"" + launchfile + "\",\"" + location + "\")")
        }.ExecuteNonQuery();
        Log.WriteToLog("App hidden: " + displayname);
      }
      catch (Exception ex)
      {
        Log.WriteToLog("HideApp: " + ex.Message);
      }
    }

    public static void UnHideApp(string displayname)
    {
      try
      {
        new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("DELETE from hiddenApps where DisplayName = \"" + displayname + "\"")
        }.ExecuteNonQuery();
        Log.WriteToLog("App Visible: " + displayname);
      }
      catch (Exception ex)
      {
        Log.WriteToLog("UnHideApp: " + ex.Message);
      }
    }

    public static bool CheckHiddenApp(string launchfile, string displayname, string location)
    {
      object result = new SQLiteCommand(MQTTDB.MQTT_cnn)
      {
        CommandText = ("select * from hiddenApps where DisplayName = \"" + displayname + "\" AND Location = \"" + location + "\" AND LaunchFile = \"" + launchfile + "\"")
      }.ExecuteScalar();
      
      return (result != null && (result is int && (int)result != 0));
    }

    public static object GetHiddenApps()
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(MQTTDB.MQTT_cnn);
      List<string> hiddenApps = new List<string>();
      sqLiteCommand.CommandText = "select DisplayName from hiddenApps";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
            hiddenApps.Add(sqLiteDataReader[0].ToString());
        }
      }
      return (object) hiddenApps;
    }

    public static object GetIgnoredApps()
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(MQTTDB.MQTT_cnn);
      List<string> ignoredApps = new List<string>();
      sqLiteCommand.CommandText = "select FileName from ignoredApps";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
          {
            ignoredApps.Add(Convert.ToString(sqLiteDataReader[0]));
            if (!File.Exists(Convert.ToString(sqLiteDataReader[0])))
              MQTTDB.RemoveIgnoredApp(Convert.ToString(sqLiteDataReader[0]));
          }
        }
      }
      return (object) ignoredApps;
    }

    public static object GetIncludedApps()
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(MQTTDB.MQTT_cnn);
      List<string> includedApps = new List<string>();
      sqLiteCommand.CommandText = "select FileName from includedApps";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
          {
            includedApps.Add(Convert.ToString(sqLiteDataReader[0]));
            if (!File.Exists(Convert.ToString(sqLiteDataReader[0])))
              MQTTDB.RemoveIncludedApp(Convert.ToString(sqLiteDataReader[0]));
          }
        }
      }
      return (object) includedApps;
    }

    public static void RemoveIgnoredApp(string name)
    {
      new SQLiteCommand(MQTTDB.MQTT_cnn)
      {
        CommandText = ("delete from ignoredApps where FileName = \"" + name + "\"")
      }.ExecuteNonQuery();
    }

    public static void RemoveIncludedApp(string name)
    {
      new SQLiteCommand(MQTTDB.MQTT_cnn)
      {
        CommandText = ("delete from includedApps where FileName = \"" + name + "\"")
      }.ExecuteNonQuery();
    }

    public static object GetknownApps()
    {
      SQLiteCommand sqLiteCommand = new SQLiteCommand(MQTTDB.MQTT_cnn);
      List<string> stringList = new List<string>();
      sqLiteCommand.CommandText = "select FileName from knownApps";
      using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
            stringList.Add(Convert.ToString(sqLiteDataReader[0]));
        }
      }
      return (object) stringList;
    }

    public static object GetknownAppDetails(string filename)
    {
      string str = null;
      using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(MQTTDB.MQTT_cnn)
      {
        CommandText = ("select DisplayName, LaunchFile, CompletePath, AssetFile from knownApps where FileName = \"" + filename + "\"")
      }.ExecuteReader())
      {
        if (sqLiteDataReader.HasRows)
        {
          while (sqLiteDataReader.Read())
            str = string.Format("{0},{1},{2},{3}", sqLiteDataReader[0], sqLiteDataReader[1], sqLiteDataReader[2], sqLiteDataReader[3]);
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
        new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("insert into knownApps (FileName, DisplayName, LaunchFile, CompletePath, AssetFile) values (\"" + filename + "\",\"" + displayname + "\",\"" + launchfile + "\",\"" + completepath + "\",\"" + assetfile + "\")")
        }.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Log.WriteToLog("AddKnownApp: " + ex.Message);
      }
    }

    public static void AddIgnoreApp(string filename)
    {
      try
      {
        new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("insert into ignoredApps (FileName) values (\"" + filename + "\")")
        }.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Log.WriteToLog("AddIgnoreApp: " + ex.Message);
      }
    }

    public static void AddIncludedApp(string filename)
    {
      try
      {
        new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("insert into includedApps (FileName) values (\"" + filename + "\")")
        }.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Log.WriteToLog("AddIncludedApp: " + ex.Message);
      }
    }

    public static string GetDisplayName(string path)
    {
      string displayName = null;
      try
      {
        using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("select DisplayName from Profiles where Path = \"" + path + "\" COLLATE NOCASE")
        }.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            if (sqLiteDataReader.Read())
            {
              displayName = Convert.ToString(sqLiteDataReader[0]);
              goto label_10;
            }
          }
        }
      }
      catch (Exception ex)
      {
        Log.WriteToLog("UpdateProfile: " + ex.Message);
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
        new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("insert or replace into LinkPresets (ID, Name, Curve, Encoding, Bitrate, Sharpening, DBR) values ((select ID from LinkPresets where Name = \"" + name + "\"), \"" + name + "\",\"" + curve + "\",\"" + encoding + "\",\"" + bitrate + "\",\"" + sharpening + "\",\"" + dbr + "\")")
        }.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        Log.WriteToLog("AddLinkPreset: " + ex.Message);
      }
    }

    public static string GetLinkPresetValueByName(string name, string value)
    {
      string presetValueByName = null;
      try
      {
        using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("select " + value + " from LinkPresets where Name = \"" + name + "\" COLLATE NOCASE")
        }.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            if (sqLiteDataReader.Read())
            {
              presetValueByName = Convert.ToString(sqLiteDataReader[0]);
              goto label_10;
            }
          }
        }
      }
      catch (Exception ex)
      {
        Log.WriteToLog("GetLinkPresetValueByName: " + ex.Message);
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
      string presetValueByValues = null;
      try
      {
        using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("select Name from LinkPresets where Curve = \"" + curve + "\" AND Encoding = \"" + encoding + "\" AND Bitrate = \"" + bitrate + "\" AND Sharpening = \"" + sharpening + "\" AND DBR = \"" + dbr + "\"")
        }.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            if (sqLiteDataReader.Read())
            {
              presetValueByValues = Convert.ToString(sqLiteDataReader[0]);
              goto label_10;
            }
          }
        }
      }
      catch (Exception ex)
      {
        Log.WriteToLog("GetLinkPresetValueByValues: " + ex.Message);
      }
label_10:
      return presetValueByValues;
    }

    public static string RemoveLinkPresetByName(string name)
    {
      try
      {
        new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = ("delete from LinkPresets where Name = \"" + name + "\"")
        }.ExecuteNonQuery();
        Log.WriteToLog("Link Preset '" + name + "' has been removed");
        FrmMain.fmain.AddToListboxAndScroll("Link Preset '" + name + "' has been removed");
      }
      catch (Exception ex)
      {
        Log.WriteToLog("RemoveLinkPresetValueByName: " + ex.Message);
      }
      return null;
    }

    public static List<string> GetLinkPresetNames()
    {
      List<string> stringList = new List<string>();
      try
      {
        using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(MQTTDB.MQTT_cnn)
        {
          CommandText = "select Name from LinkPresets"
        }.ExecuteReader())
        {
          if (sqLiteDataReader.HasRows)
          {
            while (sqLiteDataReader.Read())
            {
              FrmMain.fmain.ComboBox4.Items.Add(sqLiteDataReader[0]);
              stringList.Add(Convert.ToString(sqLiteDataReader[0]));
            }
          }
        }
        if (!stringList.Contains("GTX 970+"))
        {
          MQTTDB.AddLinkPreset("GTX 970+", "Default", "2016", "300", "Auto", "0");
          FrmMain.fmain.ComboBox4.Items.Add((object) "GTX 970+");
        }
        if (!stringList.Contains("GTX 1070+"))
        {
          MQTTDB.AddLinkPreset("GTX 1070+", "High", "2352", "350", "Auto", "0");
          FrmMain.fmain.ComboBox4.Items.Add((object) "GTX 1070+");
        }
        if (!stringList.Contains("RTX 2070+"))
        {
          MQTTDB.AddLinkPreset("RTX 2070+", "Low", "2912", "400", "Auto", "0");
          FrmMain.fmain.ComboBox4.Items.Add((object) "RTX 2070+");
        }
        if (!stringList.Contains("GTX 1080Ti/RTX 2080+"))
        {
          MQTTDB.AddLinkPreset("GTX 1080Ti/RTX 2080+", "Low", "3648", "450", "Auto", "0");
          FrmMain.fmain.ComboBox4.Items.Add((object) "GTX 1080Ti/RTX 2080+");
        }
      }
      catch (Exception ex)
      {
        Log.WriteToLog("GetLinkPresetCurve: " + ex.Message);
      }
      return stringList;
    }

    public static void CheckDB()
    {
      Log.WriteToLog("Performing database consistency check...");
      FrmMain.fmain.AddToListboxAndScroll("Performing database consistency check...");
      try
      {
        if (MQTTDB.MQTT_cnn.State == ConnectionState.Closed)
        {
          MQTTDB.MQTT_cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\MQTT.db");
          MQTTDB.MQTT_cnn.Open();
        }
        SQLiteCommand sqLiteCommand1 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
                integer1 = Convert.ToInt32(sqLiteDataReader[0]);
                string str1 = Convert.ToString(sqLiteDataReader[1]);
                string str2 = Convert.ToString(sqLiteDataReader[2]);
                if (str2.Contains("\\\\") | str2.Contains("/"))
                {
                  string path = str2.Replace("\\\\", "\\").Replace("/", "\\");
                  if (File.Exists(path))
                  {
                    Log.WriteToLog(str1 + " has incorrect path in knownApps, correcting it");
                    SQLiteCommand sqLiteCommand2 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
          if (Globals.dbg)
            Log.WriteToLog("Table 'knownApps' does not exist yet, ignoring");
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
                integer1 = Convert.ToInt32(sqLiteDataReader[0]);
                string str = Convert.ToString(sqLiteDataReader[1]);
                string path1 = Convert.ToString(sqLiteDataReader[2]);
                if (path1.Contains("\\\\") | path1.Contains("/"))
                {
                  string path2 = path1.Replace("\\\\", "\\").Replace("/", "\\");
                  if (File.Exists(path2))
                  {
                    Log.WriteToLog(str + " has incorrect path in profiles, correcting it");
                    SQLiteCommand sqLiteCommand3 = new SQLiteCommand(MQTTDB.MQTT_cnn);
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
          if (Globals.dbg)
            Log.WriteToLog("Table 'profiles' does not exist!");
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
                int integer2 = Convert.ToInt32(sqLiteDataReader[0]);
                string Left = Convert.ToString(sqLiteDataReader[1]);
                string str = Convert.ToString(sqLiteDataReader[2]);
                if (string.Compare(Left, "0", StringComparison.Ordinal) != 0 & string.Compare(Left, "1", StringComparison.Ordinal) != 0 & string.Compare(Left, "2", StringComparison.Ordinal) != 0)
                {
                  Log.WriteToLog(str + " has incorrect value for 'Mirror' in profiles, correcting it");
                  MyProject.Forms.FrmMain.AddToListboxAndScroll(str + " has incorrect value for 'Mirror' in profiles, correcting it");
                  SQLiteCommand sqLiteCommand4 = new SQLiteCommand(MQTTDB.MQTT_cnn);
                  sqLiteCommand4.CommandText = "UPDATE profiles SET Mirror = '0' WHERE ID = '" + Convert.ToString(integer2) + "'";
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
          if (Globals.dbg)
            Log.WriteToLog("Table 'profiles' does not exist!");
        }
        if (num1 > 0)
        {
          Log.WriteToLog("Fixed " + Convert.ToString(num1) + " problems");
          FrmMain.fmain.AddToListboxAndScroll("Fixed " + Convert.ToString(num1) + " problems");
        }
        if (num1 == 0 & num2 == 0)
        {
          Log.WriteToLog("No issues found");
          MyProject.Forms.FrmMain.AddToListboxAndScroll("No issues found");
        }
        My.MySettings.Default.DBCheck = false;
        My.MySettings.Default.Save();
        MQTTDB.MQTT_cnn.Close();
      }
      catch (Exception ex)
      {
        Exception exception = ex;
        MQTTDB.MQTT_cnn.Close();
        My.MySettings.Default.DBCheck = false;
        My.MySettings.Default.Save();
        Log.WriteToLog("CheckDB: " + exception.Message);
      }
    }

    public static void AddDefaultLinkPresets()
    {
    }
  }
}

