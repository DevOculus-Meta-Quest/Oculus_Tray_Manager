// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.MigrateSettings
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
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
        XmlNode xmlNode1 = xmlDocument.SelectSingleNode("/Config");
        if (!Information.IsNothing((object) xmlNode1["StartMinimized"]))
        {
          XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/Config/StartMinimized");
          MySettingsProperty.Settings.StartMinimized = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode2.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode2.InnerText, "True", false) == 0;
        }
        if (!Information.IsNothing((object) xmlNode1["StartHomeDelay"]))
        {
          XmlNode xmlNode3 = xmlDocument.SelectSingleNode("/Config/StartHomeDelay");
          MySettingsProperty.Settings.StartHomeDelay = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode3.InnerText, "", false) != 0 ? Conversions.ToInteger(xmlNode3.InnerText) : 3;
        }
        if (!Information.IsNothing((object) xmlNode1["UseVoiceCommands"]))
        {
          XmlNode xmlNode4 = xmlDocument.SelectSingleNode("/Config/UseVoiceCommands");
          MySettingsProperty.Settings.UseVoiceCommands = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode4.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode4.InnerText, "True", false) == 0;
        }
        if (!Information.IsNothing((object) xmlNode1["DisableFrescoPower"]))
        {
          XmlNode xmlNode5 = xmlDocument.SelectSingleNode("/Config/DisableFrescoPower");
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode5.InnerText, "", false) == 0)
          {
            MySettingsProperty.Settings.DisableFrescoPower = false;
          }
          else
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode5.InnerText, "False", false) == 0)
              MySettingsProperty.Settings.DisableFrescoPower = false;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode5.InnerText, "True", false) == 0)
              MySettingsProperty.Settings.DisableFrescoPower = true;
          }
        }
        if (!Information.IsNothing((object) xmlNode1["LibraryPath"]))
        {
          XmlNode xmlNode6 = xmlDocument.SelectSingleNode("/Config/LibraryPath");
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode6.InnerText, "", false) != 0)
          {
            if (Directory.Exists(xmlNode6.InnerText.TrimEnd('\\') + "\\Manifests"))
              MySettingsProperty.Settings.LibraryPath = xmlNode6.InnerText;
          }
        }
        if (!Information.IsNothing((object) xmlNode1["PPDPStartup"]))
        {
          XmlNode xmlNode7 = xmlDocument.SelectSingleNode("/Config/PPDPStartup");
          MySettingsProperty.Settings.PPDPStartup = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode7.InnerText, "", false) != 0 ? xmlNode7.InnerText : "0";
        }
        if (!Information.IsNothing((object) xmlNode1["PowerPlan"]))
        {
          XmlNode xmlNode8 = xmlDocument.SelectSingleNode("/Config/PowerPlan");
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode8.InnerText, "", false) != 0)
            MySettingsProperty.Settings.PowerPlanStart = xmlNode8.InnerText;
        }
        if (!Information.IsNothing((object) xmlNode1["SpoofCPU"]))
        {
          XmlNode xmlNode9 = xmlDocument.SelectSingleNode("/Config/SpoofCPU");
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode9.InnerText, "", false) != 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode9.InnerText, "False", false) == 0)
              MySettingsProperty.Settings.SpoofCPU = false;
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode9.InnerText, "True", false) == 0)
              MySettingsProperty.Settings.SpoofCPU = true;
          }
        }
        if (!Information.IsNothing((object) xmlNode1["StopOVR"]))
        {
          XmlNode xmlNode10 = xmlDocument.SelectSingleNode("/Config/StopOVR");
          MySettingsProperty.Settings.StopOVR = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode10.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode10.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["StartHomeOnServiceStart"]))
        {
          XmlNode xmlNode11 = xmlDocument.SelectSingleNode("/Config/StartHomeOnServiceStart");
          MySettingsProperty.Settings.StartHomeOnServiceStart = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode11.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode11.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["OculusPath"]))
        {
          XmlNode xmlNode12 = xmlDocument.SelectSingleNode("/Config/OculusPath");
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode12.InnerText, "", false) != 0)
          {
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, "", false) == 0)
              MySettingsProperty.Settings.OculusPath = xmlNode12.InnerText;
          }
          else if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MyProject.Forms.FrmMain.OculusPath, "", false) != 0)
            MySettingsProperty.Settings.OculusPath = MyProject.Forms.FrmMain.OculusPath;
        }
        if (!Information.IsNothing((object) xmlNode1["StartOVR"]))
        {
          XmlNode xmlNode13 = xmlDocument.SelectSingleNode("/Config/StartOVR");
          MySettingsProperty.Settings.StartOVR = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode13.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode13.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["OVRServerPriority"]))
          MySettingsProperty.Settings.OVRServerPriority = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlDocument.SelectSingleNode("/Config/OVRServerPriority").InnerText, "False", false) != 0;
        if (!Information.IsNothing((object) xmlNode1["StartHomeOnToolStart"]))
        {
          XmlNode xmlNode14 = xmlDocument.SelectSingleNode("/Config/StartHomeOnToolStart");
          MySettingsProperty.Settings.StartHomeOnToolStart = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode14.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode14.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["CloseHomeOnExit"]))
        {
          XmlNode xmlNode15 = xmlDocument.SelectSingleNode("/Config/CloseHomeOnExit");
          MySettingsProperty.Settings.CloseHomeOnExit = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode15.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode15.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["HideAltTab"]))
        {
          XmlNode xmlNode16 = xmlDocument.SelectSingleNode("/Config/HideAltTab");
          MySettingsProperty.Settings.HideAltTab = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode16.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode16.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["DefaultAudio"]))
        {
          XmlNode xmlNode17 = xmlDocument.SelectSingleNode("/Config/DefaultAudio");
          MySettingsProperty.Settings.DefaultAudio = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode17.InnerText, "", false) != 0 ? xmlNode17.InnerText : "";
        }
        if (!Information.IsNothing((object) xmlNode1["DefaultMic"]))
        {
          XmlNode xmlNode18 = xmlDocument.SelectSingleNode("/Config/DefaultMic");
          MySettingsProperty.Settings.DefaultMic = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode18.InnerText, "", false) != 0 ? xmlNode18.InnerText : "";
        }
        if (!Information.IsNothing((object) xmlNode1["SetRiftAsDefault"]))
        {
          XmlNode xmlNode19 = xmlDocument.SelectSingleNode("/Config/SetRiftAsDefault");
          MySettingsProperty.Settings.SetRiftAsDefault = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode19.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode19.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["SetRiftAudioDefault"]))
        {
          XmlNode xmlNode20 = xmlDocument.SelectSingleNode("/Config/SetRiftAudioDefault");
          MySettingsProperty.Settings.SetRiftAudioDefault = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode20.InnerText, "", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode20.InnerText, "False", false) != 0 ? -1 : 0) : 0;
        }
        if (!Information.IsNothing((object) xmlNode1["SetRiftMicDefault"]))
        {
          XmlNode xmlNode21 = xmlDocument.SelectSingleNode("/Config/SetRiftMicDefault");
          MySettingsProperty.Settings.SetRiftMicDefault = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode21.InnerText, "", false) != 0 ? (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode21.InnerText, "False", false) != 0 ? -1 : 0) : 0;
        }
        if (!Information.IsNothing((object) xmlNode1["UseLocalDebugTool"]))
        {
          XmlNode xmlNode22 = xmlDocument.SelectSingleNode("/Config/UseLocalDebugTool");
          MySettingsProperty.Settings.UseLocalDebugTool = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode22.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode22.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["UseHotKeys"]))
        {
          XmlNode xmlNode23 = xmlDocument.SelectSingleNode("/Config/UseHotKeys");
          MySettingsProperty.Settings.UseHotKeys = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode23.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode23.InnerText, "False", false) != 0;
        }
        if (!Information.IsNothing((object) xmlNode1["ASW"]))
        {
          XmlNode xmlNode24 = xmlDocument.SelectSingleNode("/Config/ASW");
          MySettingsProperty.Settings.ASW = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode24.InnerText, "", false) != 0 ? Conversions.ToInteger(xmlNode24.InnerText) : 0;
        }
        if (!Information.IsNothing((object) xmlNode1["CloseOnX"]))
        {
          XmlNode xmlNode25 = xmlDocument.SelectSingleNode("/Config/CloseOnX");
          MySettingsProperty.Settings.CloseOnX = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode25.InnerText, "", false) != 0 && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(xmlNode25.InnerText, "False", false) != 0;
        }
        xmlDocument.Save(Application.StartupPath + "\\config.xml");
        MySettingsProperty.Settings.Save();
        Log.WriteToLog("Settings migration complete!");
        Log.WriteToMigrateLog("Migration complete! App.config settings below");
        MyProject.Forms.FrmMain.PrintSettings(true);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("Error migrating configurarion parameters: " + e.Message);
        MyProject.Forms.FrmMain.hasError = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog(e.ToString() + stackTrace.ToString());
        Log.WriteToMigrateLog(e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
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
        try
        {
          foreach (XmlElement xmlElement in xmlNodeList)
          {
            try
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
            finally
            {
              IEnumerator enumerator;
              if (enumerator is IDisposable)
                (enumerator as IDisposable).Dispose();
            }
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception e = ex;
        FrmMain.fmain.AddToListboxAndScroll("Error: GetOldProfiles: " + e.Message);
        MyProject.Forms.FrmMain.hasError = true;
        StackTrace stackTrace = new StackTrace(e, true);
        Log.WriteToLog("GetOldProfiles: " + e.ToString() + stackTrace.ToString());
        Log.WriteToMigrateLog("GetOldProfiles: " + e.ToString() + stackTrace.ToString());
        ProjectData.ClearProjectError();
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
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(jobject.SelectToken("appId").ToString(), "", false) == 0)
          {
            string str1 = jobject.SelectToken("canonicalName").ToString();
            string path1 = p + "\\" + str1.Replace("_assets", "") + ".json";
            List<JToken> list = JObject.Parse(File.ReadAllText(path1)).Children().ToList<JToken>();
            if (Globals.dbg)
              Log.WriteToMigrateLog(" - > " + path1);
            string withoutExtension;
            string fileName;
            string path2;
            try
            {
              foreach (JProperty jproperty in list)
              {
                jproperty.CreateReader();
                string name = jproperty.Name;
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "displayName", false) != 0)
                {
                  if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(name, "launchFile", false) == 0)
                  {
                    fileName = Path.GetFileName(jproperty.Value.ToString().Replace("\\\\", "\\"));
                    path2 = jproperty.Value.ToString().Replace("\\\\", "\\");
                    if (Globals.dbg)
                      Log.WriteToMigrateLog("    LaunchFile is '" + fileName + "'");
                    if (Globals.dbg)
                    {
                      Log.WriteToMigrateLog("    completePath is '" + path2 + "'");
                      break;
                    }
                    break;
                  }
                }
                else
                {
                  withoutExtension = jproperty.Value.ToString();
                  if (Globals.dbg)
                    Log.WriteToMigrateLog("    DisplayName is '" + withoutExtension + "'");
                }
              }
            }
            finally
            {
              List<JToken>.Enumerator enumerator;
              enumerator.Dispose();
            }
            if (withoutExtension.ToLower().EndsWith(".exe"))
              withoutExtension = Path.GetFileNameWithoutExtension(fileName);
            if (Globals.dbg)
              Log.WriteToMigrateLog("Looking for match: " + Path.GetFileName(fileName));
            string str2 = "";
            MigrateSettings.oldProfiles.TryGetValue(Path.GetFileName(fileName), out str2);
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "", false) != 0)
            {
              string[] strArray = Strings.Split(str2, ",");
              string ppdp = strArray[0];
              string asw = strArray[1];
              string priority = strArray[2];
              OTTDB.AddProfile(withoutExtension, asw, ppdp, priority, fileName, path2, "WMI", "5", "5", "0", "1", "", "0.00 0.00", "False", "0", "Yes");
            }
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("MigrateThirdPartyApps: " + exception.Message);
        Log.WriteToMigrateLog("MigrateThirdPartyApps: " + exception.Message);
        ProjectData.ClearProjectError();
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
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToMigrateLog("Failed to create database copy: " + exception.Message);
          int num = (int) Interaction.MsgBox((object) ("Failed to create database copy: " + exception.Message), MsgBoxStyle.Critical, (object) "Error copying database");
          FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          ProjectData.ClearProjectError();
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
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToLog("Failed to open database copy: " + exception.Message);
          Log.WriteToMigrateLog("Failed to open database copy: " + exception.Message);
          int num = (int) Interaction.MsgBox((object) ("Failed to open database copy: " + exception.Message), MsgBoxStyle.Critical, (object) "Error opening database");
          FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          ProjectData.ClearProjectError();
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
            string Left = jobject.SelectToken("appId").ToString();
            if (Globals.dbg)
              Log.WriteToMigrateLog("    appId is '" + Left + "'");
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "", false) != 0)
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
                sqLiteCommand.CommandText = "select value from Objects WHERE hashkey='" + Left + "' AND typename='Application'";
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
                ProjectData.SetProjectError(ex);
                Exception exception = ex;
                Log.WriteToLog("Failed to read database entry for appId '" + Left + "': " + exception.Message);
                Log.WriteToMigrateLog("Failed to read database entry for appId '" + Left + "': " + exception.Message);
                int num = (int) Interaction.MsgBox((object) ("Failed to read database entry for appId '" + Left + "': " + exception.Message), MsgBoxStyle.Critical, (object) "Error reading database");
                FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + Left + "': " + exception.Message);
                MyProject.Forms.FrmMain.hasError = true;
                ProjectData.ClearProjectError();
                return;
              }
              string str3 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
              string str4 = "display:name::";
              string str5 = ":display:short:description";
              int num1 = str3.IndexOf(str4);
              int num2 = str3.IndexOf(str5);
              if (num1 > -1 && num2 > -1)
              {
                string displayname = Strings.Mid(str3, checked (num1 + str4.Length + 1), checked (num2 - num1 - str4.Length)).Replace(":", " ").TrimEnd('r').TrimEnd('s').TrimEnd(':').TrimEnd(' ');
                if (Globals.dbg)
                  Log.WriteToMigrateLog("    Appname is '" + displayname + "'");
                if (Globals.dbg)
                  Log.WriteToMigrateLog("Looking for match: " + Path.GetFileName(str2));
                string str6 = "";
                MigrateSettings.oldProfiles.TryGetValue(Path.GetFileName(str2), out str6);
                if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str6, "", false) != 0)
                {
                  string[] strArray = Strings.Split(str6, ",");
                  string ppdp = strArray[0];
                  string asw = strArray[1];
                  string priority = strArray[2];
                  OTTDB.AddProfile(displayname, asw, ppdp, priority, str2, path2, "WMI", "5", "5", "0", "1", "", "0.00 0.00", "False", "0", "Yes");
                }
              }
            }
            else
              Log.WriteToMigrateLog("* Found NO match for appId '" + Left + "'. Manifest file: " + path1);
            checked { ++index; }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToLog("Failed to open manifest file: " + exception.Message);
          Log.WriteToMigrateLog("Failed to open manifest file: " + exception.Message);
          int num = (int) Interaction.MsgBox((object) ("Failed to open manifest file: " + exception.Message), MsgBoxStyle.Critical, (object) "Error reading mainfest");
          FrmMain.fmain.AddToListboxAndScroll("Failed to open manifest file: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          sqLiteCommand.Dispose();
          connection.Close();
          ProjectData.ClearProjectError();
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
        long target;
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
