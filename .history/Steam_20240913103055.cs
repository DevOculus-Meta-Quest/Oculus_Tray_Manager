// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.Steam
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

#nullable disable
namespace OculusTrayTool
{
  public class Steam
  {
    private const string DEFAULT_USER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
    private const string STEAMAPI_GETAPPLIST_URL = "https://api.steampowered.com/ISteamApps/GetAppList/v2/";
    private const string STEAMAPI_GETAPPDETAILS_URL = "https://store.steampowered.com/api/appdetails?appids={0}&cc=us";
    private const string STEAM_HEADER_URL = "https://steamcdn-a.akamaihd.net/steam/apps/{0}/header.jpg";
    private byte[] VDF_VERSION_OLD;
    private byte[] VDF_VERSION_NEW;
    private byte[] VDF_UNIVERSE;
    private byte[] LAST_APP;
    private string m_steamPath;
    private string m_installPath;
    private List<string> m_configPathList;
    private List<string> m_logPathList;
    private List<string> m_runtimePathList;
    private string m_appDataPath;
    private List<string> m_libraryPathList;
    private Dictionary<ulong, string> m_libraryPathDictionary;

    public Steam(string appDataPath)
    {
      this.VDF_VERSION_OLD = new byte[4]
      {
        (byte) 38,
        (byte) 68,
        (byte) 86,
        (byte) 7
      };
      this.VDF_VERSION_NEW = new byte[4]
      {
        (byte) 39,
        (byte) 68,
        (byte) 86,
        (byte) 7
      };
      this.VDF_UNIVERSE = new byte[4]
      {
        (byte) 1,
        (byte) 0,
        (byte) 0,
        (byte) 0
      };
      this.LAST_APP = new byte[4];
      this.m_steamPath = (string) null;
      this.m_installPath = (string) null;
      this.m_configPathList = (List<string>) null;
      this.m_logPathList = (List<string>) null;
      this.m_runtimePathList = (List<string>) null;
      this.m_appDataPath = (string) null;
      this.m_libraryPathList = (List<string>) null;
      this.m_libraryPathDictionary = (Dictionary<ulong, string>) null;
      this.m_appDataPath = appDataPath;
    }

    public bool TryRefresh()
    {
      if (!this.TryGetSteamPath(ref this.m_steamPath) || !this.TryGetInstallPath(ref this.m_installPath))
        return false;
      if (!this.TryGetOpenVRPathsEntry("config", ref this.m_configPathList))
        this.m_configPathList.Add(Path.Combine(this.m_installPath, "config"));
      if (!this.TryGetOpenVRPathsEntry("log", ref this.m_logPathList))
        this.m_logPathList.Add(Path.Combine(this.m_installPath, "logs"));
      if (!this.TryGetOpenVRPathsEntry("runtime", ref this.m_runtimePathList))
        this.m_runtimePathList.Add(Path.Combine(this.m_installPath, "steamapps\\common\\SteamVR"));
      return this.TryGetLibraryPathList(ref this.m_libraryPathList) && this.TryGetLibraryPathDictionary(ref this.m_libraryPathDictionary);
    }

    private bool TryGetSteamPath(ref string steamPath)
    {
      steamPath = (string) null;
      bool steamPath1;
      try
      {
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam", false);
        if (registryKey == null)
        {
          steamPath1 = false;
          goto label_8;
        }
        else
        {
          steamPath = Conversions.ToString(registryKey.GetValue("SteamPath"));
          if (string.IsNullOrEmpty(steamPath))
          {
            steamPath1 = false;
            goto label_8;
          }
          else
            steamPath = steamPath.Replace("/", "\\");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetSteamPath: " + ex.Message);
        steamPath1 = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      steamPath1 = true;
label_8:
      return steamPath1;
    }

    private bool TryGetInstallPath(ref string installPath)
    {
      installPath = (string) null;
      bool installPath1;
      try
      {
        RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("Software\\Valve\\Steam", false);
        if (registryKey == null)
        {
          installPath1 = false;
          goto label_8;
        }
        else
        {
          installPath = Conversions.ToString(registryKey.GetValue("InstallPath"));
          if (string.IsNullOrEmpty(installPath))
          {
            installPath1 = false;
            goto label_8;
          }
          else
            installPath = installPath.Replace("/", "\\");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetInstallPath: " + ex.Message);
        installPath1 = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      installPath1 = true;
label_8:
      return installPath1;
    }

    public bool TryGetLibraryPathList(ref List<string> libraryFolderList)
    {
      libraryFolderList = new List<string>();
      bool libraryPathList;
      try
      {
        libraryFolderList.Add(this.m_steamPath);
        StreamReader streamReader = new StreamReader(Path.Combine(this.m_steamPath, "steamapps\\libraryfolders.vdf"));
        while (streamReader.Peek() != -1)
        {
          string str1 = streamReader.ReadLine();
          if (str1.ToLower().Contains("\"path\""))
          {
            string str2 = str1.Replace("\"path\"", "").Replace("\"", "").Replace("\\\\", "\\");
            libraryFolderList.Add(str2.Trim());
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetLibraryPathList: " + ex.Message);
        libraryPathList = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      libraryPathList = true;
label_8:
      return libraryPathList;
    }

    public bool TryGetLibraryPathDictionary(
      ref Dictionary<ulong, string> libraryFolderDictionary)
    {
      libraryFolderDictionary = new Dictionary<ulong, string>();
      bool libraryPathDictionary;
      try
      {
        try
        {
          foreach (string libraryPath in this.m_libraryPathList)
          {
            List<ulong> appIdList = (List<ulong>) null;
            this.TryGetAppIdList(libraryPath, ref appIdList);
            try
            {
              foreach (ulong key in appIdList)
              {
                if (!libraryFolderDictionary.ContainsKey(key))
                  libraryFolderDictionary.Add(key, libraryPath);
              }
            }
            finally
            {
              List<ulong>.Enumerator enumerator;
              enumerator.Dispose();
            }
          }
        }
        finally
        {
          List<string>.Enumerator enumerator;
          enumerator.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetLibraryPathDictionary: " + ex.Message);
        libraryPathDictionary = false;
        ProjectData.ClearProjectError();
        goto label_14;
      }
      libraryPathDictionary = true;
label_14:
      return libraryPathDictionary;
    }

    public bool TryDisableSafeMode()
    {
      bool flag;
      try
      {
        if (this.m_configPathList.Count == 0)
        {
          flag = false;
          goto label_10;
        }
        else
        {
          string path = Path.Combine(this.m_configPathList[0], "steamvr.vrsettings");
          if (!System.IO.File.Exists(path))
          {
            flag = false;
            goto label_10;
          }
          else
          {
            JObject jobject = JObject.Parse(System.IO.File.ReadAllText(path));
            JToken jtoken = jobject["steamvr"];
            if (jtoken != null)
              jtoken[(object) "enableSafeMode"] = (JToken) false;
            string contents = jobject.ToString();
            System.IO.File.WriteAllText(path, contents);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryDisableSafeMode: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_10;
      }
      flag = true;
label_10:
      return flag;
    }

    public bool TryGetAppIdList(string libraryFolder, ref List<ulong> appIdList)
    {
      appIdList = new List<ulong>();
      bool appIdList1;
      try
      {
        JObject acfJson = new JObject();
        ulong result = 0;
        if (this.TryGetSteamACFJson(libraryFolder, ref acfJson))
        {
          if (acfJson["acf"] == null)
          {
            appIdList1 = false;
            goto label_14;
          }
          else
          {
            try
            {
              foreach (JToken jtoken in (IEnumerable<JToken>) acfJson["acf"])
              {
                if (jtoken[(object) "AppState"] != null && ulong.TryParse((string) jtoken[(object) "AppState"][(object) "appid"], out result))
                  appIdList.Add(result);
              }
            }
            finally
            {
              IEnumerator<JToken> enumerator;
              enumerator?.Dispose();
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetAppIdList: " + ex.Message);
        appIdList1 = false;
        ProjectData.ClearProjectError();
        goto label_14;
      }
      appIdList1 = true;
label_14:
      return appIdList1;
    }

    public bool TryCopyACFFiles(string destinationPath)
    {
      bool flag;
      try
      {
        List<string> libraryFolderList = (List<string>) null;
        if (!this.TryGetLibraryPathList(ref libraryFolderList))
        {
          flag = false;
          goto label_11;
        }
        else
        {
          try
          {
            foreach (string path1 in libraryFolderList)
            {
              string[] files = Directory.GetFiles(Path.Combine(path1, "steamapps"), "*.acf");
              int index = 0;
              while (index < files.Length)
              {
                string str = files[index];
                System.IO.File.Copy(str, Path.Combine(destinationPath, Path.GetFileName(str)), true);
                checked { ++index; }
              }
            }
          }
          finally
          {
            List<string>.Enumerator enumerator;
            enumerator.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryCopyACFFiles: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_11;
      }
      flag = true;
label_11:
      return flag;
    }

    public bool TryCheckACFFiles(string acfPath, ref List<string> acfFileNameList)
    {
      acfFileNameList = new List<string>();
      bool flag1;
      bool flag2;
      try
      {
        string[] files = Directory.GetFiles(acfPath, "*.acf");
        ACFReader acfReader = new ACFReader(new JObject());
        string[] strArray = files;
        int index = 0;
        while (index < strArray.Length)
        {
          string str = strArray[index];
          if (!acfReader.TryProcessFile(str))
            acfFileNameList.Add(Path.GetFileName(str));
          checked { ++index; }
        }
        flag1 = acfFileNameList.Count > 0;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryCheckACFFiles: " + ex.Message);
        flag2 = false;
        ProjectData.ClearProjectError();
        goto label_9;
      }
      flag2 = flag1;
label_9:
      return flag2;
    }

    public bool TryGetSteamACFJson(ref JObject acfJson)
    {
      acfJson = new JObject();
      bool steamAcfJson;
      try
      {
        try
        {
          foreach (string libraryPath in this.m_libraryPathList)
            this.TryGetSteamACFJson(libraryPath, ref acfJson);
        }
        finally
        {
          List<string>.Enumerator enumerator;
          enumerator.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetSteamACFJson: " + ex.Message);
        steamAcfJson = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      steamAcfJson = true;
label_8:
      return steamAcfJson;
    }

    public bool TryGetSteamACFJson(string libraryFolder, ref JObject acfJson)
    {
      bool steamAcfJson;
      try
      {
        string str = Path.Combine(libraryFolder, "steamapps");
        if (!Directory.Exists(str))
        {
          steamAcfJson = false;
          goto label_7;
        }
        else if (!new ACFReader(acfJson).TryProcessFolder(str))
        {
          steamAcfJson = false;
          goto label_7;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetSteamACFJson: " + ex.Message);
        steamAcfJson = false;
        ProjectData.ClearProjectError();
        goto label_7;
      }
      steamAcfJson = true;
label_7:
      return steamAcfJson;
    }

    public bool TryGetOpenVRPathsEntry(string name, ref List<string> valueList)
    {
      valueList = new List<string>();
      bool openVrPathsEntry;
      bool flag;
      try
      {
        string openvrPathsFileName = (string) null;
        if (!this.TryGetOpenVRPathsFileName(ref openvrPathsFileName))
        {
          openVrPathsEntry = false;
          goto label_13;
        }
        else
        {
          JToken source = JObject.Parse(System.IO.File.ReadAllText(openvrPathsFileName)).SelectToken(name);
          try
          {
            foreach (JToken jtoken in (IEnumerable<JToken>) source.Values())
              valueList.Add(jtoken.ToString());
          }
          finally
          {
            IEnumerator<JToken> enumerator;
            enumerator?.Dispose();
          }
          flag = valueList.Count > 0;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetOpenVRPathsEntry: " + ex.Message);
        openVrPathsEntry = false;
        ProjectData.ClearProjectError();
        goto label_13;
      }
      openVrPathsEntry = flag;
label_13:
      return openVrPathsEntry;
    }

    public bool TryGetVRManifest(ref List<SteamNode> steamList)
    {
      steamList = new List<SteamNode>();
      string path = Path.Combine(this.m_installPath, "config\\steamapps.vrmanifest");
      bool vrManifest;
      if (!System.IO.File.Exists(path))
      {
        vrManifest = false;
      }
      else
      {
        try
        {
          JToken jtoken1 = JObject.Parse(System.IO.File.ReadAllText(path)).SelectToken("applications");
          try
          {
            foreach (JToken jtoken2 in (IEnumerable<JToken>) jtoken1)
            {
              ulong result = 0;
              string str = jtoken2[(object) "app_key"].ToString();
              string _name = jtoken2[(object) "strings"][(object) "en_us"][(object) "name"].ToString();
              string _url = jtoken2[(object) "url"].ToString();
              ulong.TryParse(str.Replace("steam.app.", ""), out result);
              SteamNode steamNode = new SteamNode(result, _name, _url);
              steamList.Add(steamNode);
            }
          }
          finally
          {
            IEnumerator<JToken> enumerator;
            enumerator?.Dispose();
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Log.WriteToLog("TryGetVRManifest: " + ex.Message);
          vrManifest = false;
          ProjectData.ClearProjectError();
          goto label_11;
        }
        vrManifest = true;
      }
label_11:
      return vrManifest;
    }

    public void TryGetAppDetails(List<SteamNode> steamList)
    {
      try
      {
        try
        {
          foreach (SteamNode steam in steamList)
          {
            string str = Path.Combine(Path.GetTempPath(), string.Format("{0}.json", (object) steam.AppId));
            if (this.TryDownloadAppDetails(steam.AppId, str))
            {
              string appDetailsText = System.IO.File.ReadAllText(str);
              if (steam.TryParseAppDetails(appDetailsText))
                ;
            }
          }
        }
        finally
        {
          List<SteamNode>.Enumerator enumerator;
          enumerator.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetAppDetails: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public bool TryGetAppInfo(List<SteamNode> steamList, bool windowsOnly, bool vrOnly)
    {
      bool appInfo;
      try
      {
        Dictionary<ulong, SteamNode> appInfoDictionary = (Dictionary<ulong, SteamNode>) null;
        List<SteamNode> appInfoList = (List<SteamNode>) null;
        if (!this.TryGetAppInfo(windowsOnly, vrOnly, ref appInfoDictionary, ref appInfoList))
        {
          appInfo = false;
          goto label_11;
        }
        else
        {
          try
          {
            foreach (SteamNode steam in steamList)
            {
              SteamNode steamNode = (SteamNode) null;
              if (appInfoDictionary.TryGetValue(steam.AppId, out steamNode))
              {
                steam.Type = steamNode.Type;
                steam.Publisher = steamNode.Publisher;
                steam.Developer = steamNode.Developer;
                steam.Executable = steamNode.Executable;
                steam.Parameters = steamNode.Parameters;
                steam.OSList = steamNode.OSList;
                steam.LibraryFolder = steamNode.LibraryFolder;
                steam.InstallDir = steamNode.InstallDir;
                steam.CanonicalName = steamNode.CanonicalName;
              }
            }
          }
          finally
          {
            List<SteamNode>.Enumerator enumerator;
            enumerator.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetAppInfo: " + ex.Message);
        appInfo = false;
        ProjectData.ClearProjectError();
        goto label_11;
      }
      appInfo = true;
label_11:
      return appInfo;
    }

    private bool TryGetAppLaunchInfo(
      JToken appInfoLaunchJToken,
      bool windowsOnly,
      bool vrOnly,
      ref string oslist,
      ref string executable,
      ref string arguments,
      ref string type)
    {
      bool flag1 = false;
      bool appLaunchInfo;
      try
      {
        try
        {
          foreach (JToken jtoken1 in (IEnumerable<JToken>) appInfoLaunchJToken.Values())
          {
            JToken jtoken2 = jtoken1[(object) "config"];
            if (jtoken2 != null)
              oslist = (string) jtoken2[(object) nameof (oslist)];
            executable = (string) jtoken1[(object) nameof (executable)];
            arguments = (string) jtoken1[(object) nameof (arguments)];
            type = (string) jtoken1[(object) nameof (type)];
            bool flag2 = !windowsOnly || Operators.CompareString(oslist, "windows", false) == 0;
            bool flag3 = !vrOnly || Operators.CompareString(type, "vr", false) == 0 || Operators.CompareString(type, "othervr", false) == 0;
            if (jtoken2 != null)
              oslist = (string) jtoken2[(object) nameof (oslist)];
            if (flag2 && flag3 && executable != null)
            {
              flag1 = true;
              break;
            }
          }
        }
        finally
        {
          IEnumerator<JToken> enumerator;
          enumerator?.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetAppLaunchInfo: " + ex.Message);
        appLaunchInfo = false;
        ProjectData.ClearProjectError();
        goto label_15;
      }
      appLaunchInfo = flag1;
label_15:
      return appLaunchInfo;
    }

    public bool TryGetAppInfo(
      bool windowsOnly,
      bool vrOnly,
      ref Dictionary<ulong, SteamNode> appInfoDictionary,
      ref List<SteamNode> appInfoList)
    {
      appInfoDictionary = new Dictionary<ulong, SteamNode>();
      appInfoList = new List<SteamNode>();
      bool appInfo;
      try
      {
        JObject appInfoJObject = (JObject) null;
        if (!this.TryReadAppInfo(ref appInfoJObject))
        {
          appInfo = false;
          goto label_28;
        }
        else
        {
          JObject acfJson = (JObject) null;
          if (!this.TryGetSteamACFJson(ref acfJson))
          {
            appInfo = false;
            goto label_28;
          }
          else
          {
            try
            {
              foreach (JToken jtoken1 in (IEnumerable<JToken>) acfJson["acf"])
              {
                if (jtoken1[(object) "AppState"] != null)
                {
                  JToken jtoken2 = jtoken1[(object) "AppState"];
                  ulong result = 0;
                  string s = (string) jtoken2[(object) "appid"];
                  string _installDir = (string) jtoken2[(object) "installdir"];
                  if (ulong.TryParse(s, out result))
                  {
                    try
                    {
                      foreach (JToken jtoken3 in (IEnumerable<JToken>) appInfoJObject["apps"])
                      {
                        JToken jtoken4 = jtoken3[(object) "appinfo"];
                        if (jtoken4 != null)
                        {
                          ulong num = (ulong) jtoken4[(object) "appid"];
                          if ((long) result == (long) num)
                          {
                            string str = (string) null;
                            string executable = (string) null;
                            string arguments = (string) null;
                            string oslist = (string) null;
                            string _libraryFolder = (string) null;
                            JToken jtoken5 = jtoken4[(object) "common"];
                            JToken jtoken6 = jtoken4[(object) "extended"];
                            JToken jtoken7 = jtoken4[(object) "config"];
                            if (jtoken5 != null && jtoken6 != null)
                            {
                              string _name = (string) jtoken5[(object) "name"];
                              string type = (string) jtoken5[(object) "type"];
                              string _publisher = (string) jtoken6[(object) "publisher"];
                              string _developer = (string) jtoken6[(object) "developer"];
                              if (jtoken7 != null)
                              {
                                str = (string) jtoken7[(object) "installdir"];
                                JToken appInfoLaunchJToken = jtoken7[(object) "launch"];
                                if (appInfoLaunchJToken != null && (this.TryGetAppLaunchInfo(appInfoLaunchJToken, windowsOnly, vrOnly, ref oslist, ref executable, ref arguments, ref type) || this.TryGetAppLaunchInfo(appInfoLaunchJToken, windowsOnly, false, ref oslist, ref executable, ref arguments, ref type) || this.TryGetAppLaunchInfo(appInfoLaunchJToken, false, false, ref oslist, ref executable, ref arguments, ref type)))
                                {
                                  this.m_libraryPathDictionary.TryGetValue(result, out _libraryFolder);
                                  SteamNode steamNode = new SteamNode(result, _name, type, _publisher, _developer, executable, arguments, oslist, _libraryFolder, _installDir);
                                  if (!appInfoDictionary.ContainsKey(result))
                                  {
                                    appInfoDictionary.Add(result, steamNode);
                                    appInfoList.Add(steamNode);
                                  }
                                }
                              }
                            }
                          }
                        }
                      }
                    }
                    finally
                    {
                      IEnumerator<JToken> enumerator;
                      enumerator?.Dispose();
                    }
                  }
                }
              }
            }
            finally
            {
              IEnumerator<JToken> enumerator;
              enumerator?.Dispose();
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetAppInfo: " + ex.Message);
        appInfo = false;
        ProjectData.ClearProjectError();
        goto label_28;
      }
      appInfo = true;
label_28:
      return appInfo;
    }

    public bool TrySaveAppInfoJson(string fileName)
    {
      bool flag;
      try
      {
        JObject appInfoJObject = (JObject) null;
        if (!this.TryReadAppInfo(ref appInfoJObject))
        {
          flag = false;
          goto label_6;
        }
        else
        {
          string contents = appInfoJObject.ToString();
          System.IO.File.WriteAllText(fileName, contents);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TrySaveAppInfoJson: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_6;
      }
      flag = true;
label_6:
      return flag;
    }

    public bool TryReadAppInfo(ref JObject appInfoJObject)
    {
      appInfoJObject = new JObject();
      bool flag1;
      try
      {
        JArray jarray = new JArray();
        appInfoJObject["apps"] = (JToken) jarray;
        using (FileStream input = System.IO.File.OpenRead(Path.Combine(this.m_steamPath, "appcache\\appinfo.vdf")))
        {
          using (BinaryReader binaryReader = new BinaryReader((Stream) input))
          {
            byte[] thisBytes1 = binaryReader.ReadBytes(4);
            byte[] thisBytes2 = binaryReader.ReadBytes(4);
            bool flag2 = this.StartsWith(thisBytes1, this.VDF_VERSION_OLD);
            bool flag3 = this.StartsWith(thisBytes1, this.VDF_VERSION_NEW);
            if (!flag2 && !flag3)
            {
              flag1 = false;
              goto label_21;
            }
            else if (!this.StartsWith(thisBytes2, this.VDF_UNIVERSE))
            {
              flag1 = false;
              goto label_21;
            }
            else
            {
              while (true)
              {
                if (this.ReadInt32(binaryReader) != 0)
                {
                  JObject jobject = new JObject();
                  jobject["size"] = (JToken) this.ReadInt32(binaryReader);
                  jobject["state"] = (JToken) this.ReadInt32(binaryReader);
                  jobject["lastupdate"] = (JToken) this.ReadInt32(binaryReader);
                  jobject["accesstoken"] = (JToken) this.ReadInt64(binaryReader);
                  jobject["checksum"] = (JToken) this.ReadString(binaryReader, 20);
                  jobject["changenumber"] = (JToken) this.ReadInt32(binaryReader);
                  if (flag3)
                  {
                    this.ReadSubSection(binaryReader, (JToken) jobject, false);
                  }
                  else
                  {
                    while (true)
                    {
                      if (binaryReader.ReadByte() != (byte) 0)
                      {
                        int num = (int) binaryReader.ReadByte();
                        this.ReadString(binaryReader);
                        this.ReadSubSection(binaryReader, (JToken) jobject, true);
                      }
                      else
                        break;
                    }
                  }
                  jarray.Add((JToken) jobject);
                }
                else
                  break;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryReadAppInfo: " + ex.Message);
        flag1 = false;
        ProjectData.ClearProjectError();
        goto label_21;
      }
      flag1 = true;
label_21:
      return flag1;
    }

    private bool IsNumber(string value)
    {
      if (string.IsNullOrEmpty(value))
        return false;
      string str = value;
      int index = 0;
      while (index < str.Length)
      {
        if (!char.IsNumber(str[index]))
          return false;
        checked { ++index; }
      }
      return true;
    }

    private bool StartsWith(byte[] thisBytes, byte[] thatBytes)
    {
      if (thatBytes.Length > thisBytes.Length)
        return false;
      int index = 0;
      while (index < thatBytes.Length)
      {
        if ((int) thisBytes[index] != (int) thatBytes[index])
          return false;
        checked { ++index; }
      }
      return true;
    }

    private void ReadSubSection(BinaryReader binaryReader, JToken jToken, bool isRootSection)
    {
      while (true)
      {
        Steam.ValueType valueType = (Steam.ValueType) binaryReader.ReadByte();
        if (valueType != Steam.ValueType.EndSection)
        {
          string key = this.ReadString(binaryReader);
          this.TryReadValue(binaryReader, valueType, key, jToken);
        }
        else
          break;
      }
      if (!isRootSection)
        return;
      int num = (int) binaryReader.ReadByte();
    }

    private bool TryReadValue(
      BinaryReader binaryReader,
      Steam.ValueType valueType,
      string key,
      JToken jToken)
    {
      switch (valueType)
      {
        case Steam.ValueType.Section:
          JObject jobject = new JObject();
          jToken[(object) key] = (JToken) jobject;
          this.ReadSubSection(binaryReader, (JToken) jobject, false);
          return false;
        case Steam.ValueType.String:
          jToken[(object) key] = (JToken) this.ReadString(binaryReader);
          return true;
        case Steam.ValueType.Int32:
          jToken[(object) key] = (JToken) this.ReadInt32(binaryReader);
          return true;
        case Steam.ValueType.Int64:
          jToken[(object) key] = (JToken) this.ReadInt64(binaryReader);
          return true;
        default:
          return false;
      }
    }

    private string ReadString(BinaryReader binaryReader)
    {
      List<byte> byteList = new List<byte>();
      for (byte index = binaryReader.ReadByte(); index > (byte) 0; index = binaryReader.ReadByte())
        byteList.Add(index);
      return Encoding.UTF8.GetString(byteList.ToArray());
    }

    private string ReadString(BinaryReader binaryReader, int charCount)
    {
      return BitConverter.ToString(binaryReader.ReadBytes(charCount)).Replace("-", "");
    }

    private int ReadInt32(BinaryReader binaryReader)
    {
      return BitConverter.ToInt32(binaryReader.ReadBytes(4), 0);
    }

    private long ReadInt64(BinaryReader binaryReader)
    {
      return BitConverter.ToInt64(binaryReader.ReadBytes(8), 0);
    }

    public bool TryDownloadAppHeader(
      ulong appId,
      object tag,
      DownloadProgressChangedEventHandler downloadProgressChanged,
      EventHandler<DataDownloadEventArgs> downloadComplete)
    {
      return Steam.TryDownloadFile(string.Format("https://steamcdn-a.akamaihd.net/steam/apps/{0}/header.jpg", (object) appId), RuntimeHelpers.GetObjectValue(tag), downloadProgressChanged, downloadComplete);
    }

    public static bool TryDownloadFile(
      string url,
      object tag,
      DownloadProgressChangedEventHandler downloadProgressChanged,
      EventHandler<DataDownloadEventArgs> downloadComplete)
    {
      try
      {
        using (WebClient webClient = new WebClient())
        {
          webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
          webClient.DownloadProgressChanged += downloadProgressChanged;
          webClient.DownloadDataCompleted += (DownloadDataCompletedEventHandler) ([SpecialName] (sender, e) =>
          {
            if (e.Result == null || e.Error != null || e.Cancelled)
              return;
            object[] userState = (object[]) e.UserState;
            Uri uri = (Uri) userState[0];
            object objectValue1 = RuntimeHelpers.GetObjectValue(userState[1]);
            object objectValue2 = RuntimeHelpers.GetObjectValue(userState[2]);
            string str1 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            string str2 = Path.Combine(str1, Path.GetFileName(uri.LocalPath));
            if (!Directory.Exists(str1))
              Directory.CreateDirectory(str1);
            if (System.IO.File.Exists(str2))
              System.IO.File.Delete(str2);
            System.IO.File.WriteAllBytes(str2, e.Result);
            if (downloadComplete != null)
              downloadComplete((object) null, new DataDownloadEventArgs(str2, RuntimeHelpers.GetObjectValue(objectValue2)));
            object Expression = objectValue1;
            ObjectFlowControl.CheckForSyncLockOnValueType(Expression);
            bool lockTaken = false;
            try
            {
              Monitor.Enter(Expression, ref lockTaken);
              Monitor.Pulse(RuntimeHelpers.GetObjectValue(objectValue1));
            }
            finally
            {
              if (lockTaken)
                Monitor.Exit(Expression);
            }
          });
          Uri address = new Uri(url);
          object objectValue = RuntimeHelpers.GetObjectValue(new object());
          object Expression1 = objectValue;
          ObjectFlowControl.CheckForSyncLockOnValueType(Expression1);
          bool lockTaken1 = false;
          try
          {
            Monitor.Enter(Expression1, ref lockTaken1);
            webClient.DownloadDataAsync(address, (object) new object[3]
            {
              (object) address,
              objectValue,
              tag
            });
            Monitor.Wait(RuntimeHelpers.GetObjectValue(objectValue));
          }
          finally
          {
            if (lockTaken1)
              Monitor.Exit(Expression1);
          }
        }
        return true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryDownloadFile: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return false;
    }

    public static bool TryDownloadFileAsync(
      string url,
      object tag,
      DownloadProgressChangedEventHandler downloadProgressChanged,
      EventHandler<DataDownloadEventArgs> downloadComplete)
    {
      try
      {
        Uri address = new Uri(url);
        using (WebClient webClient = new WebClient())
        {
          webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
          webClient.DownloadProgressChanged += downloadProgressChanged;
          webClient.DownloadDataCompleted += (DownloadDataCompletedEventHandler) ([SpecialName] (sender, e) =>
          {
            if (e.Result == null || e.Error != null || e.Cancelled)
              return;
            string str1 = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            string str2 = Path.Combine(str1, Path.GetFileName(url));
            if (!Directory.Exists(str1))
            {
              Directory.CreateDirectory(str1);
              Log.WriteToLog("Created temporary directory '" + str1 + "'");
            }
            if (System.IO.File.Exists(str2))
              System.IO.File.Delete(str2);
            System.IO.File.WriteAllBytes(str2, e.Result);
            if (downloadComplete != null)
              downloadComplete((object) null, new DataDownloadEventArgs(str2, RuntimeHelpers.GetObjectValue(tag)));
          });
          webClient.DownloadDataAsync(address, RuntimeHelpers.GetObjectValue(tag));
        }
        return true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryDownloadFileAsync: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return false;
    }

    public static bool TryDownloadAppList(
      object tag,
      EventHandler<DataDownloadEventArgs> downloadComplete)
    {
      try
      {
        Uri address = new Uri("https://api.steampowered.com/ISteamApps/GetAppList/v2/");
        using (WebClient webClient = new WebClient())
        {
          webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
          webClient.DownloadDataCompleted += (DownloadDataCompletedEventHandler) ([SpecialName] (sender, e) =>
          {
            if (e.Result == null || e.Error != null || e.Cancelled)
              return;
            string str = Path.Combine(Path.GetTempPath(), "applist.json");
            if (System.IO.File.Exists(str))
              System.IO.File.Delete(str);
            System.IO.File.WriteAllBytes(str, e.Result);
            if (downloadComplete != null)
              downloadComplete((object) null, new DataDownloadEventArgs(str, RuntimeHelpers.GetObjectValue(tag)));
          });
          webClient.DownloadDataAsync(address);
        }
        return true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryDownloadAppList: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return false;
    }

    public bool TryDownloadAppDetails(ulong appId, string fileName)
    {
      try
      {
        Uri address = new Uri(string.Format("https://store.steampowered.com/api/appdetails?appids={0}&cc=us", (object) appId));
        using (WebClient webClient = new WebClient())
        {
          webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
          byte[] bytes = webClient.DownloadData(address);
          System.IO.File.WriteAllBytes(fileName, bytes);
        }
        return true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryDownloadAppDetails: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return false;
    }

    public bool TryLaunchApp(ulong appId, string parameters)
    {
      bool flag;
      try
      {
        new Process()
        {
          StartInfo = {
            WorkingDirectory = this.m_steamPath,
            FileName = Path.Combine(this.m_steamPath, "Steam.exe"),
            Arguments = string.Format("-applaunch {0} {1}", (object) appId, (object) parameters),
            UseShellExecute = false,
            CreateNoWindow = false
          }
        }.Start();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryLaunchApp: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_4;
      }
      flag = true;
label_4:
      return flag;
    }

    public bool TryInstallDriver(string driverPath, bool removedriver)
    {
      bool flag1;
      bool flag2;
      try
      {
        if (this.m_installPath == null)
        {
          flag1 = false;
          goto label_8;
        }
        else
        {
          string path = Path.Combine(this.m_installPath, "steamapps\\common\\SteamVR\\bin\\win64\\vrpathreg.exe");
          if (!System.IO.File.Exists(path))
          {
            flag1 = false;
            goto label_8;
          }
          else
          {
            Process process = new Process();
            process.StartInfo.WorkingDirectory = this.m_installPath;
            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = string.Format("{0} \"{1}\"", removedriver ? (object) nameof (removedriver) : (object) "adddriver", (object) driverPath);
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            flag2 = process.ExitCode == 0;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryInstallDriver: " + ex.Message);
        flag1 = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      flag1 = flag2;
label_8:
      return flag1;
    }

    public bool TryGetOpenVRPathsFileName(ref string openvrPathsFileName)
    {
      openvrPathsFileName = (string) null;
      bool flag;
      bool openVrPathsFileName;
      try
      {
        string path1 = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), "openvr");
        openvrPathsFileName = Path.Combine(path1, "openvrpaths.vrpath");
        flag = System.IO.File.Exists(openvrPathsFileName);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetOpenVRPathsFileName: " + ex.Message);
        openVrPathsFileName = false;
        ProjectData.ClearProjectError();
        goto label_4;
      }
      openVrPathsFileName = flag;
label_4:
      return openVrPathsFileName;
    }

    public bool TryUninstall(string driverName)
    {
      bool flag1 = false;
      bool flag2;
      try
      {
        List<string> valueList = (List<string>) null;
        if (!this.TryGetOpenVRPathsEntry("external_drivers", ref valueList))
        {
          flag2 = false;
          goto label_11;
        }
        else
        {
          try
          {
            foreach (string driverPath in valueList)
            {
              if (this.TryInstallDriver(driverPath, true))
                flag1 = true;
            }
          }
          finally
          {
            List<string>.Enumerator enumerator;
            enumerator.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryUninstall: " + ex.Message);
        flag2 = false;
        ProjectData.ClearProjectError();
        goto label_11;
      }
      flag2 = flag1;
label_11:
      return flag2;
    }

    public bool IsDriverInstalled(string driverName)
    {
      bool flag;
      try
      {
        List<string> valueList = (List<string>) null;
        if (!this.TryGetOpenVRPathsEntry("external_drivers", ref valueList))
        {
          flag = false;
          goto label_10;
        }
        else
        {
          try
          {
            foreach (string str in valueList)
            {
              if (str.Contains(driverName))
              {
                flag = true;
                goto label_10;
              }
            }
          }
          finally
          {
            List<string>.Enumerator enumerator;
            enumerator.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("IsDriverInstalled: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_10;
      }
      flag = false;
label_10:
      return flag;
    }

    public bool TryLaunchSteam() => this.TryLaunchApp(250820UL, "");

    public string SteamPath => this.m_steamPath;

    public string InstallPath => this.m_installPath;

    public List<string> ConfigPathList => this.m_configPathList;

    public List<string> LogPathList => this.m_logPathList;

    public List<string> RuntimePathList => this.m_runtimePathList;

    public string AppDataPath => this.m_appDataPath;

    public List<string> LibraryFolderList => this.m_libraryPathList;

    public Dictionary<ulong, string> LibraryFolderDictionary => this.m_libraryPathDictionary;

    private enum ValueType
    {
      Section = 0,
      String = 1,
      Int32 = 2,
      Int64 = 7,
      EndSection = 8,
    }
  }
}
