// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.Oculus
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

#nullable disable
namespace OculusTrayTool
{
  public class Oculus
  {
    private const string OCULUS_SERVICE_NAME = "Oculus VR Runtime Service";
    private const int OCULUS_SERVICE_TIMEOUT = 10000;
    private string m_oculusPath;
    private string m_appDataPath;
    private List<string> m_softwarePathList;
    private string m_databasePath;
    private List<FileInfo> m_manifestFileList;
    private List<DirectoryInfo> m_assetDirectoryList;
    private Steam m_steam;

    public Oculus(string appDataPath, Steam steam)
    {
      this.m_oculusPath = (string) null;
      this.m_appDataPath = (string) null;
      this.m_softwarePathList = (List<string>) null;
      this.m_databasePath = (string) null;
      this.m_manifestFileList = (List<FileInfo>) null;
      this.m_assetDirectoryList = (List<DirectoryInfo>) null;
      this.m_steam = (Steam) null;
      this.m_appDataPath = appDataPath;
      this.m_steam = steam;
    }

    public bool TryRefresh()
    {
      return this.TryGetOculusPath(ref this.m_oculusPath) && this.TryGetOculusSoftwarePathList(ref this.m_softwarePathList) && this.TryGetManifestFileNameAndAssetFolderList(ref this.m_manifestFileList, ref this.m_assetDirectoryList) && this.TryCopyAppDatabase();
    }

    private bool TryGetOculusPath(ref string oculusPath)
    {
      oculusPath = (string) null;
      bool oculusPath1;
      try
      {
        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\WOW6432Node\\Oculus VR, LLC\\Oculus", false);
        if (registryKey == null)
        {
          registryKey = Registry.LocalMachine.OpenSubKey("Software\\Oculus VR, LLC\\Oculus", false);
          if (registryKey == null)
          {
            oculusPath1 = false;
            goto label_8;
          }
        }
        oculusPath = Conversions.ToString(registryKey.GetValue("Base"));
        if (string.IsNullOrEmpty(oculusPath))
        {
          oculusPath1 = false;
          goto label_8;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetOculusPath: " + ex.Message);
        oculusPath1 = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      oculusPath1 = true;
label_8:
      return oculusPath1;
    }

    private bool TryGetExplorerUserSid(ref string ownerSid)
    {
      ownerSid = (string) null;
      bool explorerUserSid;
      try
      {
        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name = 'explorer.exe'").Get().GetEnumerator())
        {
          if (enumerator.MoveNext())
          {
            ManagementObject current = (ManagementObject) enumerator.Current;
            string[] args = new string[2];
            current.InvokeMethod("GetOwnerSid", (object[]) args);
            ownerSid = args[0];
            explorerUserSid = true;
            goto label_9;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetExplorerUserSid: " + ex.Message);
        explorerUserSid = false;
        ProjectData.ClearProjectError();
        goto label_9;
      }
      explorerUserSid = false;
label_9:
      return explorerUserSid;
    }

    private bool TryGetOculusSoftwarePathList(ref List<string> softwarePathList)
    {
      softwarePathList = new List<string>();
      string ownerSid = (string) null;
      bool softwarePathList1;
      if (!this.TryGetExplorerUserSid(ref ownerSid))
      {
        softwarePathList1 = false;
      }
      else
      {
        try
        {
          string str1 = Path.Combine(ownerSid, "SOFTWARE\\Oculus VR, LLC\\Oculus\\Libraries");
          RegistryKey registryKey = Registry.Users.OpenSubKey(str1, false);
          if (registryKey == null)
          {
            softwarePathList1 = false;
            goto label_18;
          }
          else
          {
            string[] subKeyNames = registryKey.GetSubKeyNames();
            int index = 0;
            while (index < subKeyNames.Length)
            {
              string path2 = subKeyNames[index];
              string str2 = Conversions.ToString(Registry.Users.OpenSubKey(Path.Combine(str1, path2), false).GetValue("Path"));
              if (str2 != null)
              {
                string oldValue = str2.Substring(str2.LastIndexOf("}")).TrimStart('}');
                string Right = str2.Replace(oldValue, "") + "\\";
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Volume");
                try
                {
                  foreach (ManagementObject managementObject in managementObjectSearcher.Get())
                  {
                    if (Operators.CompareString(Conversions.ToString(managementObject["DeviceID"]), Right, false) == 0)
                    {
                      string str3 = Conversions.ToString(managementObject["DriveLetter"]);
                      softwarePathList.Add(str3 + oldValue);
                      break;
                    }
                  }
                }
                finally
                {
                  ManagementObjectCollection.ManagementObjectEnumerator objectEnumerator;
                  objectEnumerator?.Dispose();
                }
              }
              checked { ++index; }
            }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Log.WriteToLog("TryGetOculusSoftwarePathList: " + ex.Message);
          softwarePathList1 = false;
          ProjectData.ClearProjectError();
          goto label_18;
        }
        softwarePathList1 = true;
      }
label_18:
      return softwarePathList1;
    }

    private bool TryGetDatabasePath(ref string databasePath)
    {
      databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite");
      return System.IO.File.Exists(databasePath);
    }

    public bool IsAppInstalled(OculusNode oculusNode)
    {
      List<string> manifestFileList = (List<string>) null;
      List<string> assetDirectoryList = (List<string>) null;
      return this.TryGetManifestFileNameAndAssetFolderList(oculusNode, ref manifestFileList, ref assetDirectoryList);
    }

    public bool TryGetManifestFileNameAndAssetFolderList(
      ref List<FileInfo> manifestFileList,
      ref List<DirectoryInfo> assetFolderList)
    {
      manifestFileList = new List<FileInfo>();
      assetFolderList = new List<DirectoryInfo>();
      bool andAssetFolderList;
      try
      {
        string path1 = Path.Combine(this.m_oculusPath, "CoreData\\Manifests");
        string path2 = Path.Combine(this.m_oculusPath, "CoreData\\Software\\StoreAssets");
        List<FileInfo> fileInfoList = new List<FileInfo>();
        DirectoryInfo directoryInfo1 = new DirectoryInfo(path1);
        fileInfoList.AddRange((IEnumerable<FileInfo>) directoryInfo1.GetFiles("*.json"));
        DirectoryInfo directoryInfo2 = new DirectoryInfo(path2);
        assetFolderList.AddRange((IEnumerable<DirectoryInfo>) directoryInfo2.GetDirectories("*_assets"));
        try
        {
          foreach (string softwarePath in this.m_softwarePathList)
          {
            DirectoryInfo directoryInfo3 = new DirectoryInfo(Path.Combine(softwarePath, "Manifests"));
            fileInfoList.AddRange((IEnumerable<FileInfo>) directoryInfo3.GetFiles("*.json"));
            string path3 = Path.Combine(softwarePath, "Software\\StoreAssets");
            if (Directory.Exists(path3))
            {
              DirectoryInfo directoryInfo4 = new DirectoryInfo(path3);
              assetFolderList.AddRange((IEnumerable<DirectoryInfo>) directoryInfo4.GetDirectories("*_assets"));
            }
          }
        }
        finally
        {
          List<string>.Enumerator enumerator;
          enumerator.Dispose();
        }
        try
        {
          foreach (FileInfo fileInfo in fileInfoList)
          {
            if (!fileInfo.Name.Contains("_assets"))
              manifestFileList.Add(fileInfo);
          }
        }
        finally
        {
          List<FileInfo>.Enumerator enumerator;
          enumerator.Dispose();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetManifestFileNameAndAssetFolderList: " + ex.Message);
        andAssetFolderList = false;
        ProjectData.ClearProjectError();
        goto label_16;
      }
      andAssetFolderList = true;
label_16:
      return andAssetFolderList;
    }

    public bool TryGetManifestFileNameAndAssetFolderList(
      OculusNode oculusNode,
      ref List<string> manifestFileList,
      ref List<string> assetDirectoryList)
    {
      manifestFileList = new List<string>();
      assetDirectoryList = new List<string>();
      bool andAssetFolderList;
      bool flag;
      try
      {
        string shortCanonicalName = oculusNode.ShortCanonicalName;
        if (shortCanonicalName == null)
        {
          andAssetFolderList = false;
          goto label_18;
        }
        else
        {
          try
          {
            foreach (FileInfo manifestFile in this.m_manifestFileList)
            {
              if (manifestFile.Name.StartsWith(shortCanonicalName, true, Thread.CurrentThread.CurrentCulture))
                manifestFileList.Add(manifestFile.FullName);
            }
          }
          finally
          {
            List<FileInfo>.Enumerator enumerator;
            enumerator.Dispose();
          }
          try
          {
            foreach (DirectoryInfo assetDirectory in this.m_assetDirectoryList)
            {
              if (assetDirectory.Name.StartsWith(shortCanonicalName, true, Thread.CurrentThread.CurrentCulture))
                assetDirectoryList.Add(assetDirectory.FullName);
            }
          }
          finally
          {
            List<DirectoryInfo>.Enumerator enumerator;
            enumerator.Dispose();
          }
          flag = checked (manifestFileList.Count + assetDirectoryList.Count) > 0;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetManifestFileNameAndAssetFolderList: " + ex.Message);
        andAssetFolderList = false;
        ProjectData.ClearProjectError();
        goto label_18;
      }
      andAssetFolderList = flag;
label_18:
      return andAssetFolderList;
    }

    public bool TryCreateManifest(SteamNode steamNode, SteamLaunchType steamLaunchType)
    {
      bool manifest;
      try
      {
        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game_template.json");
        if (!System.IO.File.Exists(path1))
        {
          manifest = false;
          goto label_10;
        }
        else
        {
          JObject jobject = JObject.Parse(System.IO.File.ReadAllText(path1));
          string path1_1 = Path.Combine(this.m_oculusPath, "CoreData\\Manifests");
          string canonicalName = steamNode.CanonicalName;
          string name = steamNode.Name;
          string path2 = Path.Combine(path1_1, canonicalName + ".json");
          string key = Path.Combine(this.m_steam.SteamPath, "Steam.exe");
          jobject["canonicalName"] = (JToken) canonicalName;
          jobject["displayName"] = (JToken) name;
          switch (steamLaunchType)
          {
            case SteamLaunchType.Cmd:
              jobject["files"][(object) key] = (JToken) "";
              jobject["launchFile"] = (JToken) "cmd.exe";
              jobject["launchParameters"] = (JToken) string.Format("/c start \"VR\" \"{0}\"", (object) steamNode.Url);
              break;
            case SteamLaunchType.SteamExe:
              jobject["files"][(object) key] = (JToken) "";
              jobject["launchFile"] = (JToken) key;
              jobject["launchParameters"] = (JToken) string.Format("-applaunch {0} \"{1}\"", (object) steamNode.AppId, (object) steamNode.Parameters);
              break;
            case SteamLaunchType.App:
              jobject["files"][(object) steamNode.FullPath] = (JToken) "";
              jobject["launchFile"] = (JToken) steamNode.FullPath;
              jobject["launchParameters"] = (JToken) steamNode.Parameters;
              break;
          }
          string contents = jobject.ToString();
          System.IO.File.WriteAllText(path2, contents);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryCreateManifest: " + ex.Message);
        manifest = false;
        ProjectData.ClearProjectError();
        goto label_10;
      }
      manifest = true;
label_10:
      return manifest;
    }

    public bool TryCreateAssetManifest(SteamNode steamNode, string bitmapFileName)
    {
      bool assetManifest;
      try
      {
        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game_assets_template.json");
        if (!System.IO.File.Exists(path1))
        {
          assetManifest = false;
          goto label_42;
        }
        else
        {
          JObject jobject = JObject.Parse(System.IO.File.ReadAllText(path1));
          string path2 = steamNode.CanonicalName + "_assets";
          string str1 = Path.Combine(Path.Combine(this.m_oculusPath, "CoreData\\Software\\StoreAssets"), path2);
          string path3 = Path.Combine(Path.Combine(this.m_oculusPath, "CoreData\\Manifests"), path2 + ".json");
          if (!Directory.Exists(str1))
            Directory.CreateDirectory(str1);
          string str2 = Path.Combine(str1, "cover_landscape_image.jpg");
          string filename = Path.Combine(str1, "cover_landscape_image_large.png");
          string str3 = Path.Combine(str1, "cover_square_image.jpg");
          string str4 = Path.Combine(str1, "icon_image.jpg");
          string str5 = Path.Combine(str1, "original.jpg");
          string str6 = Path.Combine(str1, "small_landscape_image.jpg");
          string str7 = Path.Combine(str1, "logo_transparent_image.png");
          using (Bitmap original = (Bitmap) Image.FromFile(bitmapFileName))
          {
            using (Bitmap bitmap = new Bitmap((Image) original, new Size(360, 202)))
            {
              bitmap.Save(str2, ImageFormat.Jpeg);
              bitmap.Save(str7, ImageFormat.Png);
            }
            using (Bitmap bitmap = new Bitmap((Image) original, new Size(720, 405)))
              bitmap.Save(filename, ImageFormat.Png);
            using (Bitmap bitmap = new Bitmap((Image) original, new Size(360, 202)))
              bitmap.Save(str3, ImageFormat.Jpeg);
            using (Bitmap bitmap = new Bitmap((Image) original, new Size(192, 192)))
              bitmap.Save(str4, ImageFormat.Jpeg);
            using (Bitmap bitmap = new Bitmap((Image) original, new Size(256, 256)))
              bitmap.Save(str5, ImageFormat.Jpeg);
            using (Bitmap bitmap = new Bitmap((Image) original, new Size(270, 90)))
              bitmap.Save(str6, ImageFormat.Jpeg);
          }
          string sha256Checksum1 = this.GetSha256Checksum(str2);
          string sha256Checksum2 = this.GetSha256Checksum(str2);
          string sha256Checksum3 = this.GetSha256Checksum(str3);
          string sha256Checksum4 = this.GetSha256Checksum(str4);
          string sha256Checksum5 = this.GetSha256Checksum(str5);
          string sha256Checksum6 = this.GetSha256Checksum(str6);
          string sha256Checksum7 = this.GetSha256Checksum(str7);
          jobject["files"][(object) "cover_landscape_image.jpg"] = (JToken) sha256Checksum1;
          jobject["files"][(object) "cover_landscape_image_large.png"] = (JToken) sha256Checksum2;
          jobject["files"][(object) "cover_square_image.jpg"] = (JToken) sha256Checksum3;
          jobject["files"][(object) "icon_image.jpg"] = (JToken) sha256Checksum4;
          jobject["files"][(object) "original.jpg"] = (JToken) sha256Checksum5;
          jobject["files"][(object) "small_landscape_image.jpg"] = (JToken) sha256Checksum6;
          jobject["files"][(object) "logo_transparent_image.png"] = (JToken) sha256Checksum7;
          jobject["canonicalName"] = (JToken) path2;
          string contents = jobject.ToString();
          System.IO.File.WriteAllText(path3, contents);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryCreateAssetManifest: " + ex.Message);
        assetManifest = false;
        ProjectData.ClearProjectError();
        goto label_42;
      }
      assetManifest = true;
label_42:
      return assetManifest;
    }

    public bool TryExtractExeIcon(string exeFileName, string iconFileName)
    {
      bool exeIcon;
      try
      {
        using (Icon associatedIcon = Icon.ExtractAssociatedIcon(exeFileName))
        {
          using (Bitmap bitmap = associatedIcon.ToBitmap())
            bitmap.Save(iconFileName, ImageFormat.Png);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryExtractExeIcon: " + ex.Message);
        exeIcon = false;
        ProjectData.ClearProjectError();
        goto label_12;
      }
      exeIcon = true;
label_12:
      return exeIcon;
    }

    public bool TryDownloadAppHeader(
      SteamNode steamNode,
      DownloadProgressChangedEventHandler downloadProgressChanged)
    {
      Oculus oculus = this;
      SteamNode steamNode1 = steamNode;
      string str = Path.Combine(Path.GetTempPath(), "icon.png");
      return this.m_steam.TryDownloadAppHeader(steamNode1.AppId, (object) "header.jpg", downloadProgressChanged, (EventHandler<DataDownloadEventArgs>) ([SpecialName] (sender, e) => oculus.TryCreateAssetManifest(steamNode1, e.FileName))) || this.TryExtractExeIcon(steamNode1.FullPath, str) && this.TryCreateAssetManifest(steamNode1, str);
    }

    private string ByteArrayToString(byte[] byteArray)
    {
      return BitConverter.ToString(byteArray).Replace("-", "");
    }

    private byte[] GetByteArray(SQLiteDataReader reader)
    {
      byte[] buffer = new byte[2049];
      long count = 0;
      long fieldOffset = 0;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        while (-(count == reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length) ? 1 : 0) > 0)
        {
          memoryStream.Write(buffer, 0, checked ((int) count));
          checked { fieldOffset += count; }
        }
        return memoryStream.ToArray();
      }
    }

    public bool TryGetApps(ref List<OculusNode> allAppList, bool includeThirdParty)
    {
      allAppList = new List<OculusNode>();
      bool apps;
      try
      {
        List<OculusNode> appList = new List<OculusNode>();
        if (includeThirdParty)
        {
          string str = Path.Combine(this.m_oculusPath, "CoreData\\Manifests");
          if (Directory.Exists(str) && this.TryGetThirdPartyApps(str, ref appList))
            allAppList.AddRange((IEnumerable<OculusNode>) appList);
        }
        List<string> softwarePathList = (List<string>) null;
        if (!this.TryGetOculusSoftwarePathList(ref softwarePathList))
        {
          apps = false;
          goto label_19;
        }
        else
        {
          try
          {
            foreach (string path1 in softwarePathList)
            {
              string str1 = Path.Combine(path1, "Manifests");
              if (Directory.Exists(str1) && this.TryGetApps(str1, ref appList))
                allAppList.AddRange((IEnumerable<OculusNode>) appList);
              if (includeThirdParty)
              {
                string str2 = Path.Combine(path1, "CoreData\\Manifests");
                if (Directory.Exists(str2) && this.TryGetThirdPartyApps(str2, ref appList))
                  allAppList.AddRange((IEnumerable<OculusNode>) appList);
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
        Log.WriteToLog("TryGetApps: " + ex.Message);
        apps = false;
        ProjectData.ClearProjectError();
        goto label_19;
      }
      apps = true;
label_19:
      return apps;
    }

    public bool TryGetApps(string manifestPath, ref List<OculusNode> appList)
    {
      appList = new List<OculusNode>();
      string _assetFileName = (string) null;
      bool _hasUserAppPlayTime = false;
      SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0}", (object) this.m_databasePath));
      connection.Open();
      SQLiteCommand sqLiteCommand = (SQLiteCommand) null;
      bool apps;
      try
      {
        string path1_1 = Path.Combine(this.m_oculusPath, "CoreData\\Software\\StoreAssets");
        string path1_2 = this.m_softwarePathList.Count > 0 ? Path.Combine(this.m_softwarePathList[0], "Software\\StoreAssets") : (string) null;
        string[] files = Directory.GetFiles(manifestPath, "*.mini");
        int index = 0;
        while (index < files.Length)
        {
          string str1 = files[index];
          JObject jobject = JObject.Parse(System.IO.File.ReadAllText(str1));
          string str2 = jobject.SelectToken("appId").ToString();
          ulong result = 0;
          if (Operators.CompareString(str2, "", false) != 0)
          {
            ulong.TryParse(str2, out result);
            string str3 = jobject.SelectToken("canonicalName").ToString();
            string str4 = Path.Combine(manifestPath, str3) + "_assets.json";
            string str5 = jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
            string _parameters = jobject.SelectToken("launchParameters").ToString();
            string str6 = Path.Combine(Path.Combine(Path.GetDirectoryName(manifestPath), "Software"), str3.Replace("/", "\\").Replace("\\\\", "\\"));
            string _executable = str5.Replace("/", "\\").Replace("\\\\", "\\");
            string directoryName = Operators.CompareString(str6, "", false) != 0 ? Path.GetDirectoryName(str6) : "";
            string fileName = Operators.CompareString(str6, "", false) != 0 ? Path.GetFileName(str6) : "";
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
              sqLiteCommand = new SQLiteCommand(connection);
              sqLiteCommand.CommandText = string.Format("select value from Objects WHERE hashkey='{0}' AND typename='Application'", (object) result);
              using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
              {
                if (reader.HasRows)
                {
                  while (reader.Read())
                  {
                    byte[] byteArray = this.GetByteArray(reader);
                    stringBuilder.Append(Encoding.Default.GetString(byteArray));
                  }
                }
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              apps = false;
              ProjectData.ClearProjectError();
              goto label_27;
            }
            finally
            {
              sqLiteCommand.Dispose();
              sqLiteCommand = (SQLiteCommand) null;
            }
            string input = stringBuilder.ToString();
            string str7 = Regex.Replace(input, "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
            string str8 = "display:name::";
            string str9 = ":display:short:description";
            int num1 = str7.IndexOf(str8);
            int num2 = str7.IndexOf(str9);
            string path1 = Path.Combine(path1_1, str3 + "_assets\\cover_landscape_image.jpg");
            string path2 = Path.Combine(path1_2, str3 + "_assets\\cover_landscape_image.jpg");
            bool _isFlat = input.Contains("FLAT");
            if (System.IO.File.Exists(path1))
              _assetFileName = path1;
            else if (System.IO.File.Exists(path2))
              _assetFileName = path2;
            if (!System.IO.File.Exists(str4))
              str4 = (string) null;
            if (num1 > -1 && num2 > -1)
            {
              string _name = str7.Substring(checked (num1 + str8.Length), checked (num2 - num1 - str8.Length - 1)).Replace(":", " ").TrimEnd(':', ' ');
              OculusNode oculusNode = new OculusNode(PlatformType.Oculus, result, str1, str4, _name, _executable, _parameters, directoryName, fileName, str3, _assetFileName, _isFlat, _hasUserAppPlayTime, false);
              appList.Add(oculusNode);
            }
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        apps = false;
        ProjectData.ClearProjectError();
        goto label_27;
      }
      finally
      {
        connection.Close();
      }
      apps = true;
label_27:
      return apps;
    }

    public bool TryGetThirdPartyApps(string manifestPath, ref List<OculusNode> appList)
    {
      appList = new List<OculusNode>();
      string path1_1 = Path.Combine(this.m_oculusPath, "CoreData\\Software\\StoreAssets");
      string path1_2 = this.m_softwarePathList.Count > 0 ? Path.Combine(this.m_softwarePathList[0], "Software\\StoreAssets") : (string) null;
      string[] files = Directory.GetFiles(manifestPath, "*.json");
      string _name = (string) null;
      string str1 = (string) null;
      string str2 = (string) null;
      string _parameters = (string) null;
      string _libraryFolder = (string) null;
      string _installDir = (string) null;
      string _assetFileName = (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      SQLiteConnection connection = new SQLiteConnection(string.Format("Data Source={0}", (object) this.m_databasePath));
      SQLiteCommand sqLiteCommand = (SQLiteCommand) null;
      connection.Open();
      bool thirdPartyApps;
      try
      {
        string[] strArray = files;
        int index = 0;
        while (index < strArray.Length)
        {
          string str3 = strArray[index];
          if (!str3.Contains("_assets.json"))
          {
            JObject jobject = JObject.Parse(System.IO.File.ReadAllText(str3));
            string str4 = jobject.SelectToken("canonicalName").ToString();
            string str5 = Path.Combine(manifestPath, str4) + "_assets.json";
            JEnumerable<JToken> jenumerable = jobject.Children();
            bool flag = (bool) jobject.SelectToken("thirdParty");
            try
            {
              foreach (JProperty jproperty in jenumerable)
              {
                jproperty.CreateReader();
                if (Operators.CompareString(jproperty.Name, "displayName", false) == 0)
                  _name = jproperty.Value.ToString();
                else if (Operators.CompareString(jproperty.Name, "launchFile", false) == 0)
                {
                  string path = jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
                  str2 = Path.GetDirectoryName(path);
                  str1 = Path.GetFileName(path);
                  _libraryFolder = Operators.CompareString(str2, "", false) != 0 ? Path.GetDirectoryName(str2) : "";
                  _installDir = Operators.CompareString(str2, "", false) != 0 ? Path.GetFileName(str2) : "";
                  if (_name.ToLower().EndsWith(".exe") || Operators.CompareString(_name.ToLower(), "unknown app", false) == 0)
                    _name = Path.GetFileNameWithoutExtension(str1);
                }
                else if (Operators.CompareString(jproperty.Name, "launchParameters", false) == 0)
                {
                  _parameters = jproperty.Value.ToString();
                  break;
                }
              }
            }
            finally
            {
              IEnumerator<JToken> enumerator;
              enumerator?.Dispose();
            }
            if (_name != null && str2 != null)
            {
              try
              {
                sqLiteCommand = new SQLiteCommand(connection);
                sqLiteCommand.CommandText = string.Format("select value from Objects WHERE hashkey=\"{0}_LocalAppState\" AND typename='LocalApplicationState'", (object) str4);
                using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
                {
                  if (reader.HasRows)
                  {
                    while (reader.Read())
                    {
                      byte[] byteArray = this.GetByteArray(reader);
                      stringBuilder.Append(Encoding.Default.GetString(byteArray));
                    }
                  }
                }
              }
              catch (Exception ex)
              {
                ProjectData.SetProjectError(ex);
                thirdPartyApps = false;
                ProjectData.ClearProjectError();
                goto label_48;
              }
              finally
              {
                sqLiteCommand.Dispose();
                sqLiteCommand = (SQLiteCommand) null;
              }
              string Left = stringBuilder.ToString();
              string path1 = Path.Combine(path1_1, str4 + "_assets\\cover_landscape_image.jpg");
              string path2 = Path.Combine(path1_2, str4 + "_assets\\cover_landscape_image.jpg");
              bool _isFlat = Left.Contains("FLAT");
              bool _hasUserAppPlayTime = false;
              if (System.IO.File.Exists(path1))
                _assetFileName = path1;
              else if (System.IO.File.Exists(path2))
                _assetFileName = path2;
              if (!System.IO.File.Exists(str5))
                str5 = (string) null;
              if (Operators.CompareString(Left, "", false) != 0)
              {
                try
                {
                  sqLiteCommand = new SQLiteCommand(connection);
                  sqLiteCommand.CommandText = string.Format("select value from Objects WHERE hashkey LIKE \"%{0}%\" AND typename='UserAppPlayTime'", (object) str4);
                  using (SQLiteDataReader sqLiteDataReader = sqLiteCommand.ExecuteReader())
                    _hasUserAppPlayTime = sqLiteDataReader.HasRows;
                }
                catch (Exception ex)
                {
                  ProjectData.SetProjectError(ex);
                  ProjectData.ClearProjectError();
                }
                finally
                {
                  sqLiteCommand.Dispose();
                  sqLiteCommand = (SQLiteCommand) null;
                }
              }
              OculusNode oculusNode = new OculusNode(PlatformType.Oculus, 0UL, str3, str5, _name, str1, _parameters, _libraryFolder, _installDir, str4, _assetFileName, _isFlat, _hasUserAppPlayTime, true);
              appList.Add(oculusNode);
            }
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        thirdPartyApps = false;
        ProjectData.ClearProjectError();
        goto label_48;
      }
      finally
      {
        connection.Close();
      }
      thirdPartyApps = true;
label_48:
      return thirdPartyApps;
    }

    private string GetSha256Checksum(string path)
    {
      using (FileStream inputStream = System.IO.File.OpenRead(path))
        return BitConverter.ToString(new SHA256Managed().ComputeHash((Stream) inputStream)).Replace("-", string.Empty).ToLower();
    }

    public bool TryStartOculusService()
    {
      bool flag;
      try
      {
        using (ServiceController serviceController = new ServiceController("Oculus VR Runtime Service"))
        {
          if (!serviceController.Status.Equals((object) ServiceControllerStatus.Stopped) && !serviceController.Status.Equals((object) ServiceControllerStatus.StopPending))
          {
            flag = false;
            goto label_10;
          }
          else
          {
            TimeSpan timeout = TimeSpan.FromMilliseconds(10000.0);
            serviceController.Start();
            serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryStartOculusService: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_10;
      }
      flag = true;
label_10:
      return flag;
    }

    public bool TryStopOculusService()
    {
      bool flag;
      try
      {
        using (ServiceController serviceController = new ServiceController("Oculus VR Runtime Service"))
        {
          if (!serviceController.Status.Equals((object) ServiceControllerStatus.Running) && !serviceController.Status.Equals((object) ServiceControllerStatus.StartPending))
          {
            flag = false;
            goto label_10;
          }
          else
          {
            TimeSpan timeout = TimeSpan.FromMilliseconds(10000.0);
            serviceController.Stop();
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryStopOculusService: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_10;
      }
      flag = true;
label_10:
      return flag;
    }

    public bool TryRestartOculusService()
    {
      bool flag;
      try
      {
        this.TryStopOculusService();
        this.TryStartOculusService();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryRestartOculusService: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_4;
      }
      flag = true;
label_4:
      return flag;
    }

    public bool TryLaunchHome()
    {
      bool flag;
      try
      {
        new Process()
        {
          StartInfo = {
            WorkingDirectory = this.m_oculusPath,
            FileName = Path.Combine(this.m_oculusPath, "Support\\oculus-client\\OculusClient.exe"),
            Arguments = ((string) null),
            UseShellExecute = false,
            CreateNoWindow = false
          }
        }.Start();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryLaunchHome: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_4;
      }
      flag = true;
label_4:
      return flag;
    }

    public bool IsHomeRunning()
    {
      bool flag = false;
      try
      {
        flag = Process.GetProcessesByName("OculusClient").Length > 0;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("IsHomeRunning: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return flag;
    }

    public bool TrySendHomeMinimized()
    {
      try
      {
        OculusTrayTool.Win32.WINDOWPLACEMENT lpwndpl = new OculusTrayTool.Win32.WINDOWPLACEMENT();
        Process[] processesByName = Process.GetProcessesByName("OculusClient");
        int index = 0;
        while (index < processesByName.Length)
        {
          Process process = processesByName[index];
          if (!(process.MainWindowHandle == IntPtr.Zero))
          {
            IntPtr mainWindowHandle = process.MainWindowHandle;
            OculusTrayTool.Win32.GetWindowPlacement(process.MainWindowHandle, ref lpwndpl);
            if (lpwndpl.showCmd == 2)
            {
              OculusTrayTool.Win32.ShowWindow(process.MainWindowHandle, 0);
              return true;
            }
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TrySendHomeMinimized: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return false;
    }

    public bool TrySendHomeToTray()
    {
      try
      {
        OculusTrayTool.Win32.WINDOWPLACEMENT lpwndpl = new OculusTrayTool.Win32.WINDOWPLACEMENT();
        Process[] processesByName = Process.GetProcessesByName("OculusClient");
        int index = 0;
        while (index < processesByName.Length)
        {
          Process process = processesByName[index];
          if (!(process.MainWindowHandle == IntPtr.Zero))
          {
            OculusTrayTool.Win32.GetWindowPlacement(process.MainWindowHandle, ref lpwndpl);
            if (lpwndpl.showCmd == 1)
            {
              OculusTrayTool.Win32.ShowWindow(process.MainWindowHandle, 0);
              return true;
            }
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TrySendHomeToTray: " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return false;
    }

    public bool TryRestoreHome()
    {
      bool flag;
      try
      {
        Process[] processesByName = Process.GetProcessesByName("OculusClient");
        int index = 0;
        while (index < processesByName.Length)
        {
          Process process = processesByName[index];
          if (!(process.MainWindowHandle == IntPtr.Zero))
          {
            OculusTrayTool.Win32.ShowWindow(process.MainWindowHandle, 9);
            OculusTrayTool.Win32.SetForegroundWindow(process.MainWindowHandle);
            flag = true;
            goto label_8;
          }
          else
            checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryRestoreHome: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      flag = false;
label_8:
      return flag;
    }

    public bool TryCopyAppDatabase()
    {
      bool flag;
      try
      {
        if (this.m_appDataPath == null)
        {
          flag = false;
          goto label_8;
        }
        else
        {
          string databasePath = (string) null;
          if (!this.TryGetDatabasePath(ref databasePath))
          {
            flag = false;
            goto label_8;
          }
          else
          {
            string destFileName = Path.Combine(this.m_appDataPath, "data.sqlite");
            System.IO.File.Copy(databasePath, destFileName, true);
            this.m_databasePath = destFileName;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryCopyAppDatabase: " + ex.Message);
        flag = false;
        ProjectData.ClearProjectError();
        goto label_8;
      }
      flag = true;
label_8:
      return flag;
    }
  }
}
