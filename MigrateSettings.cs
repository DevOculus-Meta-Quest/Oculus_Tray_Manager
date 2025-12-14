
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
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

#nullable disable
namespace OculusTrayTool
{
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
        XmlNode xmlNode1 = xmlDocument.SelectSingleNode("/Config");
        if (xmlNode1["StartMinimized"] != null)
        {
          XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartMinimized");
          MySettingsProperty.Settings.StartMinimized = xmlNode2.InnerText == "True";
        }
        if (xmlNode1["StartHomeDelay"] != null)
        {
          XmlNode xmlNode3 = xmlDocument.SelectSingleNode("/Config/StartHomeDelay");
          MySettingsProperty.Settings.StartHomeDelay = xmlNode3.InnerText != "" ? Convert.ToInt32(xmlNode3.InnerText) : 3;
        }
        if (xmlNode1["UseVoiceCommands"] != null)
        {
          XmlNode xmlNode4 = xmlDocument.SelectSingleNode("/Config/UseVoiceCommands");
          MySettingsProperty.Settings.UseVoiceCommands = xmlNode4.InnerText == "True";
        }
        if (xmlNode1["DisableFrescoPower"] != null)
        {
          XmlNode xmlNode5 = xmlDocument.SelectSingleNode("/Config/DisableFrescoPower");
          if (xmlNode5.InnerText == "")
          {
            MySettingsProperty.Settings.DisableFrescoPower = false;
          }
          else
          {
            if (xmlNode5.InnerText == "False")
              MySettingsProperty.Settings.DisableFrescoPower = false;
            if (xmlNode5.InnerText == "True")
              MySettingsProperty.Settings.DisableFrescoPower = true;
          }
        }
        if (xmlNode1["LibraryPath"] != null)
        {
          XmlNode xmlNode6 = xmlDocument.SelectSingleNode("/Config/LibraryPath");
          if (xmlNode6.InnerText != "")
          {
            if (Directory.Exists(xmlNode6.InnerText.TrimEnd('\\') + "\\Manifests"))
              MySettingsProperty.Settings.LibraryPath = xmlNode6.InnerText;
          }
        }
        if (xmlNode1["PPDPStartup"] != null)
        {
          XmlNode xmlNode7 = xmlDocument.SelectSingleNode("/Config/PPDPStartup");
          MySettingsProperty.Settings.PPDPStartup = xmlNode7.InnerText != "" ? xmlNode7.InnerText : "0";
        }
        if (xmlNode1["PowerPlan"] != null)
        {
          XmlNode xmlNode8 = xmlDocument.SelectSingleNode("/Config/PowerPlan");
          if (xmlNode8.InnerText != "")
            MySettingsProperty.Settings.PowerPlanStart = xmlNode8.InnerText;
        }
        if (xmlNode1["SpoofCPU"] != null)
        {
          XmlNode xmlNode9 = xmlDocument.SelectSingleNode("/Config/SpoofCPU");
          if (xmlNode9.InnerText != "")
          {
            if (xmlNode9.InnerText == "False")
              MySettingsProperty.Settings.SpoofCPU = false;
            if (xmlNode9.InnerText == "True")
              MySettingsProperty.Settings.SpoofCPU = true;
          }
        }
        if (xmlNode1["StopOVR"] != null)
        {
          XmlNode xmlNode10 = xmlDocument.SelectSingleNode("/Config/StopOVR");
          MySettingsProperty.Settings.StopOVR = xmlNode10.InnerText == "False";
        }
        if (xmlNode1["StartHomeOnServiceStart"] != null)
        {
          XmlNode xmlNode11 = xmlDocument.SelectSingleNode("/Config/StartHomeOnServiceStart");
          MySettingsProperty.Settings.StartHomeOnServiceStart = xmlNode11.InnerText == "False";
        }
        if (xmlNode1["OculusPath"] != null)
        {
          XmlNode xmlNode12 = xmlDocument.SelectSingleNode("/Config/OculusPath");
          if (xmlNode12.InnerText != "")
          {
            if (MyProject.Forms.FrmMain.OculusPath == "")
              MySettingsProperty.Settings.OculusPath = xmlNode12.InnerText;
          }
          else if (MyProject.Forms.FrmMain.OculusPath != "")
            MySettingsProperty.Settings.OculusPath = MyProject.Forms.FrmMain.OculusPath;
        }
        if (xmlNode1["StartOVR"] != null)
        {
          XmlNode xmlNode13 = xmlDocument.SelectSingleNode("/Config/StartOVR");
          MySettingsProperty.Settings.StartOVR = xmlNode13.InnerText == "False";
        }
        if (xmlNode1["OVRServerPriority"] != null)
          MySettingsProperty.Settings.OVRServerPriority = xmlDocument.SelectSingleNode("/Config/OVRServerPriority").InnerText != "False";
        if (xmlNode1["StartHomeOnToolStart"] != null)
        {
          XmlNode xmlNode14 = xmlDocument.SelectSingleNode("/Config/StartHomeOnToolStart");
          MySettingsProperty.Settings.StartHomeOnToolStart = xmlNode14.InnerText == "False";
        }
        if (xmlNode1["CloseHomeOnExit"] != null)
        {
          XmlNode xmlNode15 = xmlDocument.SelectSingleNode("/Config/CloseHomeOnExit");
          MySettingsProperty.Settings.CloseHomeOnExit = xmlNode15.InnerText == "False";
        }
        if (xmlNode1["HideAltTab"] != null)
        {
          XmlNode xmlNode16 = xmlDocument.SelectSingleNode("/Config/HideAltTab");
          MySettingsProperty.Settings.HideAltTab = xmlNode16.InnerText == "False";
        }
        if (xmlNode1["DefaultAudio"] != null)
        {
          XmlNode xmlNode17 = xmlDocument.SelectSingleNode("/Config/DefaultAudio");
          MySettingsProperty.Settings.DefaultAudio = xmlNode17.InnerText != "" ? xmlNode17.InnerText : "";
        }
        if (xmlNode1["DefaultMic"] != null)
        {
          XmlNode xmlNode18 = xmlDocument.SelectSingleNode("/Config/DefaultMic");
          MySettingsProperty.Settings.DefaultMic = xmlNode18.InnerText != "" ? xmlNode18.InnerText : "";
        }
        if (xmlNode1["SetRiftAsDefault"] != null)
        {
          XmlNode xmlNode19 = xmlDocument.SelectSingleNode("/Config/SetRiftAsDefault");
          MySettingsProperty.Settings.SetRiftAsDefault = xmlNode19.InnerText == "False";
        }
        if (xmlNode1["SetRiftAudioDefault"] != null)
        {
          XmlNode xmlNode20 = xmlDocument.SelectSingleNode("/Config/SetRiftAudioDefault");
          MySettingsProperty.Settings.SetRiftAudioDefault = xmlNode20.InnerText != "" ? (xmlNode20.InnerText != "False" ? -1 : 0) : 0;
        }
        if (xmlNode1["SetRiftMicDefault"] != null)
        {
          XmlNode xmlNode21 = xmlDocument.SelectSingleNode("/Config/SetRiftMicDefault");
          MySettingsProperty.Settings.SetRiftMicDefault = xmlNode21.InnerText != "" ? (xmlNode21.InnerText != "False" ? -1 : 0) : 0;
        }
        if (xmlNode1["UseLocalDebugTool"] != null)
        {
          XmlNode xmlNode22 = xmlDocument.SelectSingleNode("/Config/UseLocalDebugTool");
          MySettingsProperty.Settings.UseLocalDebugTool = xmlNode22.InnerText == "False";
        }
        if (xmlNode1["UseHotKeys"] != null)
        {
          XmlNode xmlNode23 = xmlDocument.SelectSingleNode("/Config/UseHotKeys");
          MySettingsProperty.Settings.UseHotKeys = xmlNode23.InnerText == "False";
        }
        if (xmlNode1["ASW"] != null)
        {
          XmlNode xmlNode24 = xmlDocument.SelectSingleNode("/Config/ASW");
          MySettingsProperty.Settings.ASW = xmlNode24.InnerText != "" ? Convert.ToInt32(xmlNode24.InnerText) : 0;
        }
        if (xmlNode1["CloseOnX"] != null)
        {
          XmlNode xmlNode25 = xmlDocument.SelectSingleNode("/Config/CloseOnX");
          MySettingsProperty.Settings.CloseOnX = xmlNode25.InnerText == "False";
        }
        xmlDocument.Save(Application.StartupPath + "\\config.xml");
        MySettingsProperty.Settings.Save();
        Log.WriteToLog("Settings migration complete!");
        Log.WriteToMigrateLog("Migration complete! App.config settings below");
        MyProject.Forms.FrmMain.PrintSettings(true);
      }
      catch (Exception ex)
      {
        FrmMain.fmain.AddToListboxAndScroll("Error migrating configurarion parameters: " + e.Message);
        MyProject.Forms.FrmMain.hasError = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        Log.WriteToMigrateLog(e.ToString() + stackTrace.ToString());
      }
    }

    public static void GetOldProfiles()
    {
      try
      {
        if (Globals.dbg)
          Log.WriteToMigrateLog("Entering GetOldProfiles");
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
        foreach (XmlElement xmlElement in xmlNodeList)
        {
          foreach (XmlNode childNode in xmlElement.ChildNodes)
          {
            checked { ++GetConfig.numprofiles; }
            XmlNode xmlNode1 = childNode.SelectSingleNode("name");
            XmlNode xmlNode2 = childNode.SelectSingleNode("PPDP");
            XmlNode xmlNode3 = childNode.SelectSingleNode("ASW");
            XmlNode xmlNode4 = childNode.SelectSingleNode("Priority");
            childNode.SelectSingleNode("displayname");
            MigrateSettings.oldProfiles.Add(xmlNode1.InnerText + ".exe", xmlNode2.InnerText + "," + xmlNode3.InnerText + "," + xmlNode4.InnerText);
            Log.WriteToMigrateLog("Found profile: " + xmlNode1.InnerText + ".exe," + xmlNode2.InnerText + "," + xmlNode3.InnerText + "," + xmlNode4.InnerText);
          }
        }
      }
      catch (Exception ex)
      {
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog("GetOldProfiles: " + e.ToString() + stackTrace.ToString());
        Log.WriteToMigrateLog("GetOldProfiles: " + e.ToString() + stackTrace.ToString());
      }
      finally
      {
      }
    }

    public static void MigrateThirdPartyProfiles(string p)
    {
      try
      {
        Log.WriteToMigrateLog("Migrating third-party profiles");
        string[] files = Directory.GetFiles(p, "*_assets.json");
        int index = 0;
        while (index < files.Length)
        {
          JObject jobject = JObject.Parse(File.ReadAllText(files[index]));
          if (jobject.SelectToken("appId").ToString() == "")
          {
        }
      }
      }
      catch (Exception ex)
      {
        Log.WriteToLog("MigrateThirdPartyApps: " + exception.Message);
        Log.WriteToMigrateLog("MigrateThirdPartyApps: " + exception.Message);
      }
    }

    public static void MigrateHomeProfiles(string p)
    {
      Log.WriteToMigrateLog("Migrating Oculus Native profiles");
      SQLiteConnection connection = new SQLiteConnection();
      if (Globals.dbg)
        Log.WriteToMigrateLog("Looking for Oculus database");
      if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite"))
      {
        if (Globals.dbg)
          Log.WriteToMigrateLog("Database found, making a copy");
        try
        {
          File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", true);
        }
        catch (Exception ex)
        {
          Log.WriteToMigrateLog("Failed to create database copy: " + exception.Message);
          MessageBox.Show("Failed to create database copy: " + exception.Message, "Error copying database", MessageBoxButtons.OK, MessageBoxIcon.Error);
          FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          return;
        }
        if (Globals.dbg)
          Log.WriteToMigrateLog("Opening database copy");
        try
        {
          if (connection.State == ConnectionState.Closed)
          {
            connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
            connection.Open();
          }
        }
        catch (Exception ex)
        {
          Log.WriteToLog("Failed to open database copy: " + exception.Message);
          Log.WriteToMigrateLog("Failed to open database copy: " + exception.Message);
          MessageBox.Show("Failed to open database copy: " + exception.Message, "Error opening database", MessageBoxButtons.OK, MessageBoxIcon.Error);
          FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          return;
        }
        if (Globals.dbg)
          Log.WriteToMigrateLog("Parsing manifests");
        SQLiteCommand sqLiteCommand = new SQLiteCommand(connection);
        try
        {
          string[] files = Directory.GetFiles(p + "\\Manifests", "*.mini");
          int index = 0;
          while (index < files.Length)
          {
            string path1 = files[index];
            if (Globals.dbg)
              Log.WriteToMigrateLog(" -> " + path1);
            JObject jobject = JObject.Parse(File.ReadAllText(path1));
            string appId = jobject.SelectToken("appId").ToString();
            if (Globals.dbg)
              Log.WriteToMigrateLog("    appId is '" + appId + "'");
            if (appId != "")
            {
              string str1 = jobject.SelectToken("canonicalName").ToString();
              if (Globals.dbg)
                Log.WriteToMigrateLog("    canonicalName is '" + str1 + "'");
              string str2 = jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
              if (Globals.dbg)
                Log.WriteToMigrateLog("    launchfile is '" + str2 + "'");
              string path2 = p + "\\Software\\" + str1.Replace("/", "\\").Replace("\\\\", "\\") + "\\" + str2.Replace("/", "\\").Replace("\\\\", "\\");
              if (Globals.dbg)
                Log.WriteToMigrateLog("    completePath is '" + path2 + "'");
              StringBuilder stringBuilder = new StringBuilder();
              try
              {
                sqLiteCommand.CommandText = "select value from Objects WHERE hashkey='" + appId + "' AND typename='Application'";
                using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
                {
                  while (reader.Read())
                  {
                    byte[] bytes = MigrateSettings.GetBytes(reader);
                    stringBuilder.Append(Encoding.Default.GetString(bytes));
                  }
                }
              }
              catch (Exception ex)
              {
                Log.WriteToMigrateLog("Failed to read database entry for appId '" + appId + "': " + exception.Message);
                MessageBox.Show("Failed to read database entry for appId '" + appId + "': " + exception.Message, "Error reading database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + appId + "': " + exception.Message);
                MyProject.Forms.FrmMain.hasError = true;
                return;
              }
              string str3 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
              string str4 = "display:name::";
              string str5 = ":display:short:description";
              int num1 = str3.IndexOf(str4);
              int num2 = str3.IndexOf(str5);
              if (num1 > -1 && num2 > -1)
              {
                string displayname = str3.Substring(checked (num1 + str4.Length), checked (num2 - num1 - str4.Length)).Replace(":", " ").TrimEnd('r').TrimEnd('s').TrimEnd(':').TrimEnd(' ');
                if (Globals.dbg)
                  Log.WriteToMigrateLog("    Appname is '" + displayname + "'");
                if (Globals.dbg)
                  Log.WriteToMigrateLog("Looking for match: " + Path.GetFileName(str2));
                string str6 = "";
                MigrateSettings.oldProfiles.TryGetValue(Path.GetFileName(str2), out str6);
                if (str6 != "")
                {
                  string[] strArray = str6.Split(',');
                  string ppdp = strArray[0];
                  string asw = strArray[1];
                  string priority = strArray[2];
                  OTTDB.AddProfile(displayname, asw, ppdp, priority, str2, path2, "WMI", "5", "5", "0", "1", "", "0.00 0.00", "False", "0", "Yes");
                }
              }
            }
            else
              Log.WriteToMigrateLog("* Found NO match for appId '" + appId + "'. Manifest file: " + path1);
            checked { ++index; }
          }
        }
        catch (Exception ex)
        {
          Log.WriteToMigrateLog("Failed to open manifest file: " + exception.Message);
          MessageBox.Show("Failed to open manifest file: " + exception.Message, "Error reading mainfest", MessageBoxButtons.OK, MessageBoxIcon.Error);
          FrmMain.fmain.AddToListboxAndScroll("Failed to open manifest file: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          sqLiteCommand.Dispose();
          connection.Close();
          return;
        }
        sqLiteCommand.Dispose();
        connection.Close();
        if (Globals.dbg)
          Log.WriteToMigrateLog("Connection closed");
        File.Delete(Application.StartupPath + "\\data.sqlite");
        if (Globals.dbg)
          Log.WriteToMigrateLog("Database copy deleted");
      }
    }

    private static string ByteArrayToString(byte[] ba)
    {
      return BitConverter.ToString(ba).Replace("-", "");
    }

    private static byte[] GetBytes(SQLiteDataReader reader)
    {
      byte[] buffer = new byte[2048];
      long fieldOffset = 0;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        long target = 0;
        while (MigrateSettings.InlineAssignHelper<long>(ref target, reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0L)
        {
          memoryStream.Write(buffer, 0, checked ((int) target));
          checked { fieldOffset += target; }
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
}
