// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.GetGames
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
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
          Log.WriteToLog("Updating list of Steam games..");
        List<SteamNode> steamList = (List<SteamNode>) null;
        if (!Globals.oculus.TryRefresh() || !Globals.steam.TryRefresh() || !Globals.steam.TryGetVRManifest(ref steamList))
          return;
        if (!Globals.steam.TryGetAppInfo(steamList, true, true))
          return;
        try
        {
          foreach (SteamNode steamNode in steamList)
          {
            if (steamNode.Executable != null)
            {
              if (Globals.dbg)
                Log.WriteToLog("GetSteamGames: Name: " + steamNode.Name + " Executable: " + Path.GetFileName(steamNode.Executable.Replace("/", "\\")) + " Full path: " + steamNode.LibraryFolder + "\\steamapps\\common\\" + steamNode.InstallDir + "\\" + steamNode.Executable.Replace("/", "\\"));
              string key = steamNode.LibraryFolder + "\\steamapps\\common\\" + steamNode.InstallDir + "\\" + steamNode.Executable.Replace("/", "\\");
              if (!MyProject.Forms.FrmMain.AllAppsList.ContainsKey(key))
              {
                MyProject.Forms.FrmMain.AllAppsList.Add(key, steamNode.Name);
                MyProject.Forms.frmProfiles.GameList.Add(steamNode.Name, key);
                if (Globals.dbg)
                  Log.WriteToLog("GetSteamGames: All Apps List: Added Steam App '" + steamNode.Name + "' with path '" + key + "'");
              }
              if (!GetGames.steamGameList.Contains(steamNode.Name))
              {
                GetGames.steamGameList.Add(steamNode.Name);
                if (Globals.dbg)
                  Log.WriteToLog("GetSteamGames: Steam Game List: Added Steam App '" + steamNode.Name + "'");
              }
            }
          }
        }
        catch (Exception ex)
        {
             // Log error ?
             Log.WriteToLog("GetSteamGames loop error: " + ex.Message);
        }
        
        Log.WriteToLog("Found " + GetGames.steamGameList.Count.ToString() + " Steam VR Apps");
        
        foreach (string steamGame in GetGames.steamGameList)
             Log.WriteToLog("Steam VR App '" + steamGame.ToString() + "' added to available games list");
      }
      catch (Exception ex)
      {
        Log.WriteToLog("GetSteamGames: " + ex.Message);
      }
    }

    public static void GetThirdPartyApps(string p)
    {
      Log.WriteToLog("Parsing Third-Party Manifests in " + p);
      string oculusPath = OculusTrayTool.My.MySettings.Default.OculusPath;
      string assetPath = Path.Combine(oculusPath, "CoreData\\Software\\StoreAssets");
      string str1 = "";
      string otherAssetPath = "";
      if (!string.IsNullOrEmpty(OculusTrayTool.My.MySettings.Default.LibraryPath) && !string.IsNullOrWhiteSpace(OculusTrayTool.My.MySettings.Default.LibraryPath))
        otherAssetPath = Path.Combine(OculusTrayTool.My.MySettings.Default.LibraryPath.Split(',')[0], "Software\\StoreAssets");
      else
        str1 = oculusPath;
      string[] files = Directory.GetFiles(p, "*.json");
      for (int index = 0; index < files.Length; index++)
      {
        string str2 = files[index];
        try
        {
          if (!str2.Contains("_assets.json"))
          {
            if (!FrmMain.fmain.includedApps.Contains(str2) && FrmMain.fmain.ignoredApps.Contains(str2))
            {
              if (Globals.dbg)
              {
                Log.WriteToLog("GetThirdPartyApps: " + str2 + " is on the ignore list");
                continue;
              }
              else
              {
                JObject jobject = JObject.Parse(File.ReadAllText(str2));
                string canonName = "";
                string withoutExtension = "";
                string fileName = "";
                string str3 = "";
                string displayNameAssetFile = "";
                List<JProperty> list = jobject.Properties().ToList();

                foreach (JProperty jproperty in list)
                {
                    if (jproperty.Name == "canonicalName") canonName = jproperty.Value.ToString();
                    else if (jproperty.Name == "displayName") withoutExtension = jproperty.Value.ToString();
                    else if (jproperty.Name == "launchFile") fileName = jproperty.Value.ToString();
                    else if (jproperty.Name == "launchParameters") str3 = jproperty.Value.ToString();
                    else if (jproperty.Name == "files") displayNameAssetFile = jproperty.Value.ToString();
                }

                if (!(bool)jobject.SelectToken("thirdParty"))
                {
                    if (Globals.dbg)
                        Log.WriteToLog("GetThirdPartyApps:  -> App is not a VR app, adding to ignore list");
                    OTTDB.AddIgnoreApp(str2);
                    FrmMain.fmain.ignoredApps.Add(str2);
                    continue;
                }
                if (Globals.dbg)
                  Log.WriteToLog("GetThirdPartyApps: Looking for '" + withoutExtension + "' in Steam game list");
                if (GetGames.steamGameList.Contains(withoutExtension))
                {
                  GetGames.AddThirdPartyGameToList(assetPath, otherAssetPath, str2, GetGames.steamGameList, displayNameAssetFile, withoutExtension, fileName, str3, canonName);
                }
                else
                {
                  if (Globals.dbg)
                    Log.WriteToLog("GetThirdPartyApps: '" + withoutExtension + "' not found in Steam game list, checking Oculus database");
                  StringBuilder stringBuilder = new StringBuilder();
                  SQLiteConnection connection = new SQLiteConnection();
                  if (connection.State == ConnectionState.Closed)
                  {
                    connection = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
                    connection.Open();
                  }
                  try
                  {
                    SQLiteCommand sqLiteCommand = new SQLiteCommand(connection);
                    sqLiteCommand.CommandText = "select value from Objects WHERE hashkey=\"" + canonName + "_LocalAppState\" AND typename='LocalApplicationState'";
                    if (Globals.dbg)
                      Log.WriteToLog("GetThirdPartyApps:  -> Looking for entry: " + canonName + "_LocalAppState");
                    using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
                    {
                      if (reader.HasRows)
                      {
                        if (Globals.dbg)
                          Log.WriteToLog("GetThirdPartyApps:  -> Reading entry for " + canonName + "_LocalAppState");
                        while (reader.Read())
                        {
                          byte[] bytes = GetGames.GetBytes(reader);
                          stringBuilder.Append(Encoding.Default.GetString(bytes));
                        }
                      }
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    Log.WriteToLog("GetThirdPartyApps:  -> Failed to read database entry for appId '" + canonName + "': " + exception.Message);
                    FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + canonName + "': " + exception.Message);
                    ProjectData.ClearProjectError();
                    continue;
                  }
                  if (!FrmMain.fmain.includedApps.Contains(str2) && stringBuilder.ToString().Contains("FLAT"))
                  {
                    if (Globals.dbg)
                      Log.WriteToLog("GetThirdPartyApps:  -> App does not appear to be a VR app, ignoring");
                    if (!FrmMain.fmain.ignoredApps.Contains(str2))
                    {
                      if (Globals.dbg)
                        Log.WriteToLog("GetThirdPartyApps:  -> App is not a VR app, adding to ignore list");
                      OTTDB.AddIgnoreApp(str2);
                      FrmMain.fmain.ignoredApps.Add(str2);
                      continue;
                    }
                    else
                      continue;
                  }
                  else
                  {
                    if (stringBuilder.Length > 0)
                      GetGames.AddThirdPartyGameToList(assetPath, otherAssetPath, str2, GetGames.steamGameList, displayNameAssetFile, withoutExtension, fileName, str3, canonName);
                    if (stringBuilder.Length == 0)
                    {
                      if (Globals.dbg)
                        Log.WriteToLog("GetThirdPartyApps:  -> Not found, looking for secondary entry: " + canonName + ": UserAppPlayTime");
                      using (SQLiteDataReader sqLiteDataReader = new SQLiteCommand(connection)
                      {
                        CommandText = ("select value from Objects WHERE hashkey LIKE \"%" + canonName + "%\" AND typename='UserAppPlayTime'")
                      }.ExecuteReader())
                      {
                        if (sqLiteDataReader.HasRows)
                        {
                          if (Globals.dbg)
                            Log.WriteToLog("GetThirdPartyApps:  -> Found entry for " + canonName + ": UserAppPlayTime");
                          GetGames.AddThirdPartyGameToList(assetPath, otherAssetPath, str2, GetGames.steamGameList, displayNameAssetFile, withoutExtension, fileName, str3, canonName);
                        }
                        else if (!FrmMain.fmain.includedApps.Contains(str2))
                        {
                          if (Globals.dbg)
                            Log.WriteToLog("GetThirdPartyApps:  -> App does not appear to be a VR app or has been uninstalled, ignoring");
                          if (!FrmMain.fmain.ignoredApps.Contains(str2))
                          {
                          continue;
                          GetGames.AddThirdPartyGameToList(assetPath, otherAssetPath, str2, GetGames.steamGameList, displayNameAssetFile, withoutExtension, fileName, str3, canonName);
                      }
                    }
                  }
                }
              }
            }
          }
          else
            continue;
        }
        catch (Exception ex)
        {
          Log.WriteToLog("GetThirdPartyApps: Failed to open manifest file: " + ex.Message);
          continue;
        }

      }
    }

    private static void AddThirdPartyGameToList(
      string assetPath,
      string otherAssetPath,
      string manifest,
      List<string> steamGameList,
      string displayNameAssetFile,
      string DisplayName,
      string LaunchFile,
      string completePath,
      string canonName)
    {
      if (!FrmMain.fmain.AllAppsList.ContainsKey(completePath))
      {
        FrmMain.fmain.AllAppsList.Add(completePath, DisplayName);
        if (Globals.dbg)
          Log.WriteToLog("AddThirdPartyGameToList: All Apps List: Added Steam App '" + DisplayName + "' with path '" + completePath + "'");
      }
      if (Globals.dbg)
        Log.WriteToLog("AddThirdPartyGameToList: Game found, checking for hidden attribute");
      if (!OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Both"))
      {
        if (Globals.dbg)
          Log.WriteToLog("AddThirdPartyGameToList: Game is not hidden");
        if (!MyProject.Forms.frmProfiles.GameList.ContainsKey(DisplayName))
        {
          if (!FrmMain.fmain.profilePaths.ContainsKey(completePath))
          {
            MyProject.Forms.frmProfiles.GameList.Add(DisplayName, completePath);
            Log.WriteToLog("Third-Party App '" + DisplayName + "' added to available games list");
          }
          else
            Log.WriteToLog("Third-Party App '" + DisplayName + "' has a profile, NOT added");
        }
        if (!GetGames.manifesDictionary.ContainsKey(DisplayName))
          GetGames.manifesDictionary.Add(DisplayName, manifest);
        if (File.Exists(assetPath + "\\" + canonName + "_assets\\cover_landscape_image.jpg"))
        {
          if (GetGames.assetPaths.ContainsKey(DisplayName))
            return;
          GetGames.assetPaths.Add(DisplayName, assetPath + "\\" + canonName + "_assets");
          if (Globals.dbg)
            Log.WriteToLog("Added " + assetPath + "\\" + canonName + "_assets as asset path for '" + DisplayName + "'");
        }
        else if (File.Exists(otherAssetPath + "\\" + canonName + "_assets\\cover_landscape_image.jpg"))
        {
          if (!GetGames.assetPaths.ContainsKey(DisplayName))
          {
            GetGames.assetPaths.Add(DisplayName, otherAssetPath + "\\" + canonName + "_assets");
            if (Globals.dbg)
              Log.WriteToLog("Added " + otherAssetPath + "\\" + canonName + "_assets as asset path for '" + DisplayName + "'");
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
        Log.WriteToLog("AddThirdPartyGameToList: Game is hidden");
    }

    public static void GetFiles(string p)
    {
      try
      {
        SQLiteConnection connection = new SQLiteConnection();
        string[] strArray = OculusTrayTool.My.MySettings.Default.LibraryPath.Split(',');
        string oculusPath = OculusTrayTool.My.MySettings.Default.OculusPath;
        string str1 = "";
        string str2 = "";
        string str3 = Path.Combine(oculusPath, "CoreData\\Software\\StoreAssets");
        if (!string.IsNullOrEmpty(OculusTrayTool.My.MySettings.Default.LibraryPath) && !string.IsNullOrWhiteSpace(OculusTrayTool.My.MySettings.Default.LibraryPath))
          str2 = Path.Combine(strArray[0], "Software\\StoreAssets");
        else
          str1 = oculusPath;
        if (Globals.dbg)
          Log.WriteToLog("GetApps: Looking for Oculus database");
        if (File.Exists(Application.StartupPath + "\\data.sqlite"))
        {
          if (Globals.dbg)
            Log.WriteToLog("GetApps: Opening database copy");
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
            Log.WriteToLog("GetApps: Failed to open database copy: " + ex.Message);
            MessageBox.Show("Failed to open database copy: " + ex.Message, "Error opening database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + ex.Message);
            FrmMain.fmain.hasError = true;
            return;
          }
          Log.WriteToLog("Parsing Manifests in " + p);
          SQLiteCommand sqLiteCommand = new SQLiteCommand(connection);
          string[] files = Directory.GetFiles(p, "*.mini");
          int index = 0;
          while (index < files.Length)
          {
            string str4 = files[index];
            try
            {
              if (!FrmMain.fmain.includedApps.Contains(str4) && FrmMain.fmain.ignoredApps.Contains(str4.Replace(".mini", "")))
              {
                if (Globals.dbg)
                {
                  Log.WriteToLog("GetApps: " + str4 + " is on the ignore list");
                  continue;
                }
                else
                  continue;
              }
              else
              {
                if (Globals.dbg)
                  Log.WriteToLog("GetApps: Opening " + str4);
                JObject jobject = JObject.Parse(File.ReadAllText(str4));
                string appId = jobject.SelectToken("appId").ToString();
                if (!string.IsNullOrEmpty(appId))
                {
                  if (Globals.dbg)
                    Log.WriteToLog("    appId is '" + Left + "'");
                  string str5 = jobject.SelectToken("canonicalName").ToString();
                  if (Globals.dbg)
                    Log.WriteToLog("    canonicalName is '" + str5 + "'");
                  string launchfile = jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
                  if (Globals.dbg)
                    Log.WriteToLog("    launchfile is '" + launchfile + "'");
                  string str6 = p.Replace("\\Manifests", "") + "\\Software\\" + str5.Replace("/", "\\").Replace("\\\\", "\\") + "\\" + launchfile.Replace("/", "\\").Replace("\\\\", "\\");
                  if (Globals.dbg)
                    Log.WriteToLog("    completePath is '" + str6 + "'");
                  StringBuilder stringBuilder = new StringBuilder();
                  try
                  {
                    sqLiteCommand.CommandText = "select value from Objects WHERE hashkey='" + appId + "' AND typename='Application'";
                    using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
                    {
                      if (reader.HasRows)
                      {
                        while (reader.Read())
                        {
                          byte[] bytes = GetGames.GetBytes(reader);
                          stringBuilder.Append(Encoding.Default.GetString(bytes));
                        }
                      }
                      else
                        continue;
                    }
                  }
                  catch (Exception ex)
                  {
                    ProjectData.SetProjectError(ex);
                    Exception exception = ex;
                    Log.WriteToLog("GetApps:  -> Failed to read database entry for appId '" + appId + "': " + exception.Message);
                    FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + appId + "': " + exception.Message);
                    FrmMain.fmain.hasError = true;
                    ProjectData.ClearProjectError();
                    return;
                  }
                  if (stringBuilder.ToString().Contains("FLAT") && !FrmMain.fmain.includedApps.Contains(str4))
                  {
                    if (!FrmMain.fmain.ignoredApps.Contains(str4))
                    {
                      if (Globals.dbg)
                        Log.WriteToLog("GetApps:  ->  App does not appear to be a VR app, adding to ignore list");
                      OTTDB.AddIgnoreApp(str4);
                      FrmMain.fmain.ignoredApps.Add(str4);
                      continue;
                    }
                    else
                      continue;
                  }
                  else
                  {
                    string str7 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
                    string str8 = "display:name::";
                    string str9 = ":display:short:description";
                    int num1 = str7.IndexOf(str8);
                    int num2 = str7.IndexOf(str9);
                    if (num1 > -1 && num2 > -1)
                    {
                      string str10 = str7.Substring(checked (num1 + str8.Length), checked (num2 - num1 - str8.Length)).Replace(":", " ").TrimEnd(':').TrimEnd(' ');
                      string str11 = str10.Remove(checked (str10.Length - 1));
                      if (Globals.dbg)
                        Log.WriteToLog("    Appname is '" + str11 + "'");
                      if (!string.IsNullOrEmpty(str11) && !string.IsNullOrEmpty(str6))
                      {
                        if (!FrmMain.fmain.AllAppsList.ContainsKey(str6))
                        {
                          FrmMain.fmain.AllAppsList.Add(str6, str11);
                          if (Globals.dbg)
                            Log.WriteToLog("All Apps List: Added Oculus Store App '" + str11 + "' with path '" + str6 + "'");
                        }
                        if (!OTTDB.CheckHiddenApp(launchfile, str11, "Both"))
                        {
                          if (!MyProject.Forms.frmProfiles.GameList.ContainsKey(str11))
                          {
                            if (!FrmMain.fmain.profilePaths.ContainsKey(str6))
                            {
                              MyProject.Forms.frmProfiles.GameList.Add(str11, str6);
                              Log.WriteToLog("Oculus Store App '" + str11 + "' added to available games list");
                            }
                            else
                              Log.WriteToLog("Oculus Store App '" + str11 + "' has a profile, NOT added");
                          }
                          if (!GetGames.manifesDictionary.ContainsKey(str11))
                            GetGames.manifesDictionary.Add(str11, str4);
                          if (File.Exists(str3 + "\\" + str5 + "_assets\\cover_landscape_image.jpg"))
                          {
                            if (!GetGames.assetPaths.ContainsKey(str11))
                            {
                              GetGames.assetPaths.Add(str11, str3 + "\\" + str5 + "_assets");
                              if (Globals.dbg)
                                Log.WriteToLog("Added " + str3 + "\\" + str5 + "_assets as asset path for '" + str11 + "'");
                            }
                          }
                          else if (File.Exists(str2 + "\\" + str5 + "_assets\\cover_landscape_image.jpg"))
                          {
                            if (!GetGames.assetPaths.ContainsKey(str11))
                            {
                              GetGames.assetPaths.Add(str11, str2 + "\\" + str5 + "_assets");
                              if (Globals.dbg)
                                Log.WriteToLog("Added " + str2 + "\\" + str5 + "_assets as asset path for '" + str11 + "'");
                            }
                          }
                          else
                          {
                            Log.WriteToLog("GetFiles(): Warning: Could not find asset path for '" + str11 + "' in ");
                            Log.WriteToLog(" -> " + str3 + "\\" + str5 + "_assets");
                            Log.WriteToLog(" -> " + str2 + "\\" + str5 + "_assets");
                          }
                        }
                      }
                    }
                  }
                }
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Log.WriteToLog("GetApps:  -> Failed to open manifest file: " + ex.Message);
              ProjectData.ClearProjectError();
              continue;
            }
            checked { ++index; }
          }
          sqLiteCommand.Dispose();
          connection.Close();
          if (Globals.dbg)
            Log.WriteToLog("GetApps: Connection closed");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetApps: " + ex.Message);
        ProjectData.ClearProjectError();
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
        while (GetGames.InlineAssignHelper<long>(ref target, reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0L)
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
