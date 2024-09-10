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
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool;

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
		m_oculusPath = null;
		m_appDataPath = null;
		m_softwarePathList = null;
		m_databasePath = null;
		m_manifestFileList = null;
		m_assetDirectoryList = null;
		m_steam = null;
		m_appDataPath = appDataPath;
		m_steam = steam;
	}

	public bool TryRefresh()
	{
		if (!TryGetOculusPath(ref m_oculusPath))
		{
			return false;
		}
		if (!TryGetOculusSoftwarePathList(ref m_softwarePathList))
		{
			return false;
		}
		if (!TryGetManifestFileNameAndAssetFolderList(ref m_manifestFileList, ref m_assetDirectoryList))
		{
			return false;
		}
		if (!TryCopyAppDatabase())
		{
			return false;
		}
		return true;
	}

	private bool TryGetOculusPath(ref string oculusPath)
	{
		oculusPath = null;
		bool result;
		try
		{
			RegistryKey registryKey = null;
			registryKey = Registry.LocalMachine.OpenSubKey("Software\\WOW6432Node\\Oculus VR, LLC\\Oculus", writable: false);
			if (registryKey == null)
			{
				registryKey = Registry.LocalMachine.OpenSubKey("Software\\Oculus VR, LLC\\Oculus", writable: false);
				if (registryKey == null)
				{
					result = false;
					goto IL_0094;
				}
			}
			oculusPath = Conversions.ToString(registryKey.GetValue("Base"));
			if (string.IsNullOrEmpty(oculusPath))
			{
				result = false;
				goto IL_0094;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetOculusPath: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0094;
		}
		result = true;
		goto IL_0094;
		IL_0094:
		return result;
	}

	private bool TryGetExplorerUserSid(ref string ownerSid)
	{
		ownerSid = null;
		bool result;
		try
		{
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name = 'explorer.exe'").Get();
			using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectCollection.GetEnumerator();
			if (managementObjectEnumerator.MoveNext())
			{
				ManagementObject managementObject = (ManagementObject)managementObjectEnumerator.Current;
				string[] array = new string[2];
				managementObject.InvokeMethod("GetOwnerSid", array);
				ownerSid = array[0];
				result = true;
				goto IL_0094;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetExplorerUserSid: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0094;
		}
		result = false;
		goto IL_0094;
		IL_0094:
		return result;
	}

	private bool TryGetOculusSoftwarePathList(ref List<string> softwarePathList)
	{
		softwarePathList = new List<string>();
		string ownerSid = null;
		bool result;
		if (!TryGetExplorerUserSid(ref ownerSid))
		{
			result = false;
		}
		else
		{
			try
			{
				string text = Path.Combine(ownerSid, "SOFTWARE\\Oculus VR, LLC\\Oculus\\Libraries");
				RegistryKey registryKey = Registry.Users.OpenSubKey(text, writable: false);
				if (registryKey == null)
				{
					result = false;
					goto IL_01bb;
				}
				string[] subKeyNames = registryKey.GetSubKeyNames();
				string[] array = subKeyNames;
				foreach (string path in array)
				{
					RegistryKey registryKey2 = Registry.Users.OpenSubKey(Path.Combine(text, path), writable: false);
					string text2 = Conversions.ToString(registryKey2.GetValue("Path"));
					if (text2 == null)
					{
						continue;
					}
					string text3 = text2.Substring(text2.LastIndexOf("}")).TrimStart('}');
					string right = text2.Replace(text3, "") + "\\";
					ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Volume");
					foreach (ManagementObject item in managementObjectSearcher.Get())
					{
						if (Operators.CompareString(Conversions.ToString(item["DeviceID"]), right, TextCompare: false) == 0)
						{
							string text4 = Conversions.ToString(item["DriveLetter"]);
							softwarePathList.Add(text4 + text3);
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("TryGetOculusSoftwarePathList: " + ex2.Message);
				result = false;
				ProjectData.ClearProjectError();
				goto IL_01bb;
			}
			result = true;
		}
		goto IL_01bb;
		IL_01bb:
		return result;
	}

	private bool TryGetDatabasePath(ref string databasePath)
	{
		databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite");
		return File.Exists(databasePath);
	}

	public bool IsAppInstalled(OculusNode oculusNode)
	{
		List<string> manifestFileList = null;
		List<string> assetDirectoryList = null;
		return TryGetManifestFileNameAndAssetFolderList(oculusNode, ref manifestFileList, ref assetDirectoryList);
	}

	public bool TryGetManifestFileNameAndAssetFolderList(ref List<FileInfo> manifestFileList, ref List<DirectoryInfo> assetFolderList)
	{
		manifestFileList = new List<FileInfo>();
		assetFolderList = new List<DirectoryInfo>();
		bool result;
		try
		{
			string path = Path.Combine(m_oculusPath, "CoreData\\Manifests");
			string path2 = Path.Combine(m_oculusPath, "CoreData\\Software\\StoreAssets");
			List<FileInfo> list = new List<FileInfo>();
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			list.AddRange(directoryInfo.GetFiles("*.json"));
			directoryInfo = new DirectoryInfo(path2);
			assetFolderList.AddRange(directoryInfo.GetDirectories("*_assets"));
			foreach (string softwarePath in m_softwarePathList)
			{
				string path3 = Path.Combine(softwarePath, "Manifests");
				directoryInfo = new DirectoryInfo(path3);
				list.AddRange(directoryInfo.GetFiles("*.json"));
				string path4 = Path.Combine(softwarePath, "Software\\StoreAssets");
				if (Directory.Exists(path4))
				{
					directoryInfo = new DirectoryInfo(path4);
					assetFolderList.AddRange(directoryInfo.GetDirectories("*_assets"));
				}
			}
			foreach (FileInfo item in list)
			{
				if (!item.Name.Contains("_assets"))
				{
					manifestFileList.Add(item);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetManifestFileNameAndAssetFolderList: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0191;
		}
		result = true;
		goto IL_0191;
		IL_0191:
		return result;
	}

	public bool TryGetManifestFileNameAndAssetFolderList(OculusNode oculusNode, ref List<string> manifestFileList, ref List<string> assetDirectoryList)
	{
		bool flag = false;
		manifestFileList = new List<string>();
		assetDirectoryList = new List<string>();
		bool result;
		try
		{
			string shortCanonicalName = oculusNode.ShortCanonicalName;
			if (shortCanonicalName == null)
			{
				result = false;
				goto IL_0139;
			}
			foreach (FileInfo manifestFile in m_manifestFileList)
			{
				if (manifestFile.Name.StartsWith(shortCanonicalName, ignoreCase: true, Thread.CurrentThread.CurrentCulture))
				{
					manifestFileList.Add(manifestFile.FullName);
				}
			}
			foreach (DirectoryInfo assetDirectory in m_assetDirectoryList)
			{
				if (assetDirectory.Name.StartsWith(shortCanonicalName, ignoreCase: true, Thread.CurrentThread.CurrentCulture))
				{
					assetDirectoryList.Add(assetDirectory.FullName);
				}
			}
			flag = checked(manifestFileList.Count + assetDirectoryList.Count) > 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetManifestFileNameAndAssetFolderList: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0139;
		}
		result = flag;
		goto IL_0139;
		IL_0139:
		return result;
	}

	public bool TryCreateManifest(SteamNode steamNode, SteamLaunchType steamLaunchType)
	{
		bool result;
		try
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game_template.json");
			if (!File.Exists(path))
			{
				result = false;
				goto IL_0218;
			}
			string json = File.ReadAllText(path);
			JObject jObject = JObject.Parse(json);
			string path2 = Path.Combine(m_oculusPath, "CoreData\\Manifests");
			string canonicalName = steamNode.CanonicalName;
			string name = steamNode.Name;
			string path3 = Path.Combine(path2, canonicalName + ".json");
			string text = Path.Combine(m_steam.SteamPath, "Steam.exe");
			jObject["canonicalName"] = canonicalName;
			jObject["displayName"] = name;
			switch (steamLaunchType)
			{
			case SteamLaunchType.Cmd:
				jObject["files"][text] = "";
				jObject["launchFile"] = "cmd.exe";
				jObject["launchParameters"] = $"/c start \"VR\" \"{steamNode.Url}\"";
				break;
			case SteamLaunchType.SteamExe:
				jObject["files"][text] = "";
				jObject["launchFile"] = text;
				jObject["launchParameters"] = $"-applaunch {steamNode.AppId} \"{steamNode.Parameters}\"";
				break;
			case SteamLaunchType.App:
				jObject["files"][steamNode.FullPath] = "";
				jObject["launchFile"] = steamNode.FullPath;
				jObject["launchParameters"] = steamNode.Parameters;
				break;
			}
			json = jObject.ToString();
			File.WriteAllText(path3, json);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryCreateManifest: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0218;
		}
		result = true;
		goto IL_0218;
		IL_0218:
		return result;
	}

	public bool TryCreateAssetManifest(SteamNode steamNode, string bitmapFileName)
	{
		bool result;
		try
		{
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game_assets_template.json");
			if (!File.Exists(path))
			{
				result = false;
				goto IL_03e4;
			}
			string json = File.ReadAllText(path);
			JObject jObject = JObject.Parse(json);
			string text = steamNode.CanonicalName + "_assets";
			string text2 = Path.Combine(Path.Combine(m_oculusPath, "CoreData\\Software\\StoreAssets"), text);
			string path2 = Path.Combine(Path.Combine(m_oculusPath, "CoreData\\Manifests"), text + ".json");
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			string text3 = Path.Combine(text2, "cover_landscape_image.jpg");
			string filename = Path.Combine(text2, "cover_landscape_image_large.png");
			string text4 = Path.Combine(text2, "cover_square_image.jpg");
			string text5 = Path.Combine(text2, "icon_image.jpg");
			string text6 = Path.Combine(text2, "original.jpg");
			string text7 = Path.Combine(text2, "small_landscape_image.jpg");
			string text8 = Path.Combine(text2, "logo_transparent_image.png");
			using (Bitmap original = (Bitmap)Image.FromFile(bitmapFileName))
			{
				using (Bitmap bitmap = new Bitmap(original, new Size(360, 202)))
				{
					bitmap.Save(text3, ImageFormat.Jpeg);
					bitmap.Save(text8, ImageFormat.Png);
				}
				using (Bitmap bitmap2 = new Bitmap(original, new Size(720, 405)))
				{
					bitmap2.Save(filename, ImageFormat.Png);
				}
				using (Bitmap bitmap3 = new Bitmap(original, new Size(360, 202)))
				{
					bitmap3.Save(text4, ImageFormat.Jpeg);
				}
				using (Bitmap bitmap4 = new Bitmap(original, new Size(192, 192)))
				{
					bitmap4.Save(text5, ImageFormat.Jpeg);
				}
				using (Bitmap bitmap5 = new Bitmap(original, new Size(256, 256)))
				{
					bitmap5.Save(text6, ImageFormat.Jpeg);
				}
				using Bitmap bitmap6 = new Bitmap(original, new Size(270, 90));
				bitmap6.Save(text7, ImageFormat.Jpeg);
			}
			string sha256Checksum = GetSha256Checksum(text3);
			string sha256Checksum2 = GetSha256Checksum(text3);
			string sha256Checksum3 = GetSha256Checksum(text4);
			string sha256Checksum4 = GetSha256Checksum(text5);
			string sha256Checksum5 = GetSha256Checksum(text6);
			string sha256Checksum6 = GetSha256Checksum(text7);
			string sha256Checksum7 = GetSha256Checksum(text8);
			jObject["files"]["cover_landscape_image.jpg"] = sha256Checksum;
			jObject["files"]["cover_landscape_image_large.png"] = sha256Checksum2;
			jObject["files"]["cover_square_image.jpg"] = sha256Checksum3;
			jObject["files"]["icon_image.jpg"] = sha256Checksum4;
			jObject["files"]["original.jpg"] = sha256Checksum5;
			jObject["files"]["small_landscape_image.jpg"] = sha256Checksum6;
			jObject["files"]["logo_transparent_image.png"] = sha256Checksum7;
			jObject["canonicalName"] = text;
			json = jObject.ToString();
			File.WriteAllText(path2, json);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryCreateAssetManifest: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_03e4;
		}
		result = true;
		goto IL_03e4;
		IL_03e4:
		return result;
	}

	public bool TryExtractExeIcon(string exeFileName, string iconFileName)
	{
		bool result;
		try
		{
			using Icon icon = Icon.ExtractAssociatedIcon(exeFileName);
			using Bitmap bitmap = icon.ToBitmap();
			bitmap.Save(iconFileName, ImageFormat.Png);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryExtractExeIcon: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0069;
		}
		result = true;
		goto IL_0069;
		IL_0069:
		return result;
	}

	public bool TryDownloadAppHeader(SteamNode steamNode, DownloadProgressChangedEventHandler downloadProgressChanged)
	{
		string tempPath = Path.GetTempPath();
		string text = Path.Combine(tempPath, "icon.png");
		if (m_steam.TryDownloadAppHeader(steamNode.AppId, "header.jpg", downloadProgressChanged, [SpecialName] (object sender, DataDownloadEventArgs e) =>
		{
			TryCreateAssetManifest(steamNode, e.FileName);
		}))
		{
			return true;
		}
		if (!TryExtractExeIcon(steamNode.FullPath, text))
		{
			return false;
		}
		if (!TryCreateAssetManifest(steamNode, text))
		{
			return false;
		}
		return true;
	}

	private string ByteArrayToString(byte[] byteArray)
	{
		return BitConverter.ToString(byteArray).Replace("-", "");
	}

	private byte[] GetByteArray(SQLiteDataReader reader)
	{
		byte[] array = new byte[2049];
		long num = 0L;
		long num2 = 0L;
		using MemoryStream memoryStream = new MemoryStream();
		for (; 0 - ((num == reader.GetBytes(0, num2, array, 0, array.Length)) ? 1 : 0) > 0; num2 = checked(num2 + num))
		{
			memoryStream.Write(array, 0, checked((int)num));
		}
		return memoryStream.ToArray();
	}

	public bool TryGetApps(ref List<OculusNode> allAppList, bool includeThirdParty)
	{
		allAppList = new List<OculusNode>();
		bool result;
		try
		{
			List<OculusNode> appList = new List<OculusNode>();
			string text = null;
			if (includeThirdParty)
			{
				text = Path.Combine(m_oculusPath, "CoreData\\Manifests");
				if (Directory.Exists(text) && TryGetThirdPartyApps(text, ref appList))
				{
					allAppList.AddRange(appList);
				}
			}
			List<string> softwarePathList = null;
			if (!TryGetOculusSoftwarePathList(ref softwarePathList))
			{
				result = false;
				goto IL_0146;
			}
			foreach (string item in softwarePathList)
			{
				text = Path.Combine(item, "Manifests");
				if (Directory.Exists(text) && TryGetApps(text, ref appList))
				{
					allAppList.AddRange(appList);
				}
				if (includeThirdParty)
				{
					text = Path.Combine(item, "CoreData\\Manifests");
					if (Directory.Exists(text) && TryGetThirdPartyApps(text, ref appList))
					{
						allAppList.AddRange(appList);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetApps: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0146;
		}
		result = true;
		goto IL_0146;
		IL_0146:
		return result;
	}

	public bool TryGetApps(string manifestPath, ref List<OculusNode> appList)
	{
		appList = new List<OculusNode>();
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		string text6 = null;
		string text7 = null;
		string text8 = null;
		string assetFileName = null;
		bool flag = false;
		bool hasUserAppPlayTime = false;
		SQLiteConnection sQLiteConnection = new SQLiteConnection($"Data Source={m_databasePath}");
		sQLiteConnection.Open();
		SQLiteCommand sQLiteCommand = null;
		bool result2;
		try
		{
			string path = Path.Combine(m_oculusPath, "CoreData\\Software\\StoreAssets");
			string path2 = ((m_softwarePathList.Count > 0) ? Path.Combine(m_softwarePathList[0], "Software\\StoreAssets") : null);
			string[] files = Directory.GetFiles(manifestPath, "*.mini");
			string[] array = files;
			foreach (string text9 in array)
			{
				string json = File.ReadAllText(text9);
				JObject jObject = JObject.Parse(json);
				string text10 = jObject.SelectToken("appId").ToString();
				ulong result = 0uL;
				if (Operators.CompareString(text10, "", TextCompare: false) == 0)
				{
					continue;
				}
				ulong.TryParse(text10, out result);
				text8 = jObject.SelectToken("canonicalName").ToString();
				text = Path.Combine(manifestPath, text8) + "_assets.json";
				string text11 = jObject.SelectToken("launchFile").ToString().Replace("/", "\\");
				text5 = jObject.SelectToken("launchParameters").ToString();
				text3 = Path.Combine(Path.Combine(Path.GetDirectoryName(manifestPath), "Software"), text8.Replace("/", "\\").Replace("\\\\", "\\"));
				text4 = text11.Replace("/", "\\").Replace("\\\\", "\\");
				text6 = ((Operators.CompareString(text3, "", TextCompare: false) != 0) ? Path.GetDirectoryName(text3) : "");
				text7 = ((Operators.CompareString(text3, "", TextCompare: false) != 0) ? Path.GetFileName(text3) : "");
				StringBuilder stringBuilder = new StringBuilder();
				try
				{
					sQLiteCommand = new SQLiteCommand(sQLiteConnection);
					sQLiteCommand.CommandText = $"select value from Objects WHERE hashkey='{result}' AND typename='Application'";
					using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
					if (sQLiteDataReader.HasRows)
					{
						while (sQLiteDataReader.Read())
						{
							byte[] byteArray = GetByteArray(sQLiteDataReader);
							stringBuilder.Append(Encoding.Default.GetString(byteArray));
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					result2 = false;
					ProjectData.ClearProjectError();
					goto IL_0424;
				}
				finally
				{
					sQLiteCommand.Dispose();
					sQLiteCommand = null;
				}
				string text12 = stringBuilder.ToString();
				string text13 = Regex.Replace(text12, "[^A-Za-z0-9\\-/]", ":");
				text13 = text13.Replace(":::", ":");
				text13 = text13.Replace("::", ":");
				string text14 = "display:name::";
				string value = ":display:short:description";
				int num = text13.IndexOf(text14);
				int num2 = text13.IndexOf(value);
				string text15 = Path.Combine(path, text8 + "_assets\\cover_landscape_image.jpg");
				string text16 = Path.Combine(path2, text8 + "_assets\\cover_landscape_image.jpg");
				flag = text12.Contains("FLAT");
				if (File.Exists(text15))
				{
					assetFileName = text15;
				}
				else if (File.Exists(text16))
				{
					assetFileName = text16;
				}
				if (!File.Exists(text))
				{
					text = null;
				}
				if (num > -1 && num2 > -1)
				{
					text2 = checked(text13.Substring(num + text14.Length, num2 - num - text14.Length - 1));
					text2 = text2.Replace(":", " ").TrimEnd(':', ' ');
					OculusNode item = new OculusNode(PlatformType.Oculus, result, text9, text, text2, text4, text5, text6, text7, text8, assetFileName, flag, hasUserAppPlayTime, _isThirdParty: false);
					appList.Add(item);
				}
			}
		}
		catch (Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			Exception ex4 = ex3;
			result2 = false;
			ProjectData.ClearProjectError();
			goto IL_0424;
		}
		finally
		{
			sQLiteConnection.Close();
			sQLiteConnection = null;
		}
		result2 = true;
		goto IL_0424;
		IL_0424:
		return result2;
	}

	public bool TryGetThirdPartyApps(string manifestPath, ref List<OculusNode> appList)
	{
		appList = new List<OculusNode>();
		string path = Path.Combine(m_oculusPath, "CoreData\\Software\\StoreAssets");
		string path2 = ((m_softwarePathList.Count > 0) ? Path.Combine(m_softwarePathList[0], "Software\\StoreAssets") : null);
		string[] files = Directory.GetFiles(manifestPath, "*.json");
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string parameters = null;
		string libraryFolder = null;
		string installDir = null;
		string text5 = null;
		string assetFileName = null;
		bool flag = false;
		bool flag2 = false;
		StringBuilder stringBuilder = new StringBuilder();
		SQLiteConnection sQLiteConnection = new SQLiteConnection($"Data Source={m_databasePath}");
		SQLiteCommand sQLiteCommand = null;
		sQLiteConnection.Open();
		bool result;
		try
		{
			string[] array = files;
			foreach (string text6 in array)
			{
				if (text6.Contains("_assets.json"))
				{
					continue;
				}
				string json = File.ReadAllText(text6);
				JObject jObject = JObject.Parse(json);
				text5 = jObject.SelectToken("canonicalName").ToString();
				text = Path.Combine(manifestPath, text5) + "_assets.json";
				JEnumerable<JToken> jEnumerable = jObject.Children();
				bool flag3 = (bool)jObject.SelectToken("thirdParty");
				foreach (JProperty item2 in jEnumerable)
				{
					item2.CreateReader();
					if (Operators.CompareString(item2.Name, "displayName", TextCompare: false) == 0)
					{
						text2 = item2.Value.ToString();
					}
					else if (Operators.CompareString(item2.Name, "launchFile", TextCompare: false) == 0)
					{
						string path3 = item2.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
						text4 = Path.GetDirectoryName(path3);
						text3 = Path.GetFileName(path3);
						libraryFolder = ((Operators.CompareString(text4, "", TextCompare: false) != 0) ? Path.GetDirectoryName(text4) : "");
						installDir = ((Operators.CompareString(text4, "", TextCompare: false) != 0) ? Path.GetFileName(text4) : "");
						if (text2.ToLower().EndsWith(".exe") || Operators.CompareString(text2.ToLower(), "unknown app", TextCompare: false) == 0)
						{
							text2 = Path.GetFileNameWithoutExtension(text3);
						}
					}
					else if (Operators.CompareString(item2.Name, "launchParameters", TextCompare: false) == 0)
					{
						parameters = item2.Value.ToString();
						break;
					}
				}
				if (text2 == null || text4 == null)
				{
					continue;
				}
				try
				{
					sQLiteCommand = new SQLiteCommand(sQLiteConnection);
					sQLiteCommand.CommandText = $"select value from Objects WHERE hashkey=\"{text5}_LocalAppState\" AND typename='LocalApplicationState'";
					using SQLiteDataReader sQLiteDataReader = sQLiteCommand.ExecuteReader();
					if (sQLiteDataReader.HasRows)
					{
						while (sQLiteDataReader.Read())
						{
							byte[] byteArray = GetByteArray(sQLiteDataReader);
							stringBuilder.Append(Encoding.Default.GetString(byteArray));
						}
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					result = false;
					ProjectData.ClearProjectError();
					goto IL_04a5;
				}
				finally
				{
					sQLiteCommand.Dispose();
					sQLiteCommand = null;
				}
				string text7 = stringBuilder.ToString();
				string text8 = Path.Combine(path, text5 + "_assets\\cover_landscape_image.jpg");
				string text9 = Path.Combine(path2, text5 + "_assets\\cover_landscape_image.jpg");
				flag = text7.Contains("FLAT");
				flag2 = false;
				if (File.Exists(text8))
				{
					assetFileName = text8;
				}
				else if (File.Exists(text9))
				{
					assetFileName = text9;
				}
				if (!File.Exists(text))
				{
					text = null;
				}
				if (Operators.CompareString(text7, "", TextCompare: false) != 0)
				{
					try
					{
						sQLiteCommand = new SQLiteCommand(sQLiteConnection);
						sQLiteCommand.CommandText = $"select value from Objects WHERE hashkey LIKE \"%{text5}%\" AND typename='UserAppPlayTime'";
						using SQLiteDataReader sQLiteDataReader2 = sQLiteCommand.ExecuteReader();
						flag2 = sQLiteDataReader2.HasRows;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						ProjectData.ClearProjectError();
					}
					finally
					{
						sQLiteCommand.Dispose();
						sQLiteCommand = null;
					}
				}
				OculusNode item = new OculusNode(PlatformType.Oculus, 0uL, text6, text, text2, text3, parameters, libraryFolder, installDir, text5, assetFileName, flag, flag2, _isThirdParty: true);
				appList.Add(item);
			}
		}
		catch (Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			Exception ex6 = ex5;
			result = false;
			ProjectData.ClearProjectError();
			goto IL_04a5;
		}
		finally
		{
			sQLiteConnection.Close();
			sQLiteConnection = null;
		}
		result = true;
		goto IL_04a5;
		IL_04a5:
		return result;
	}

	private string GetSha256Checksum(string path)
	{
		using FileStream inputStream = File.OpenRead(path);
		SHA256Managed sHA256Managed = new SHA256Managed();
		byte[] array = sHA256Managed.ComputeHash(inputStream);
		return BitConverter.ToString(array).Replace("-", string.Empty).ToLower();
	}

	public bool TryStartOculusService()
	{
		bool result;
		try
		{
			using ServiceController serviceController = new ServiceController("Oculus VR Runtime Service");
			if (!serviceController.Status.Equals(ServiceControllerStatus.Stopped) && !serviceController.Status.Equals(ServiceControllerStatus.StopPending))
			{
				result = false;
				goto IL_00b2;
			}
			TimeSpan timeout = TimeSpan.FromMilliseconds(10000.0);
			serviceController.Start();
			serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryStartOculusService: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00b2;
		}
		result = true;
		goto IL_00b2;
		IL_00b2:
		return result;
	}

	public bool TryStopOculusService()
	{
		bool result;
		try
		{
			using ServiceController serviceController = new ServiceController("Oculus VR Runtime Service");
			if (!serviceController.Status.Equals(ServiceControllerStatus.Running) && !serviceController.Status.Equals(ServiceControllerStatus.StartPending))
			{
				result = false;
				goto IL_00b2;
			}
			TimeSpan timeout = TimeSpan.FromMilliseconds(10000.0);
			serviceController.Stop();
			serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryStopOculusService: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00b2;
		}
		result = true;
		goto IL_00b2;
		IL_00b2:
		return result;
	}

	public bool TryRestartOculusService()
	{
		bool result;
		try
		{
			TryStopOculusService();
			TryStartOculusService();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryRestartOculusService: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_003e;
		}
		result = true;
		goto IL_003e;
		IL_003e:
		return result;
	}

	public bool TryLaunchHome()
	{
		bool result;
		try
		{
			Process process = new Process();
			process.StartInfo.WorkingDirectory = m_oculusPath;
			process.StartInfo.FileName = Path.Combine(m_oculusPath, "Support\\oculus-client\\OculusClient.exe");
			process.StartInfo.Arguments = null;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = false;
			process.Start();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryLaunchHome: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0092;
		}
		result = true;
		goto IL_0092;
		IL_0092:
		return result;
	}

	public bool IsHomeRunning()
	{
		bool result = false;
		try
		{
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			result = processesByName.Length > 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("IsHomeRunning: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public bool TrySendHomeMinimized()
	{
		try
		{
			Win32.WINDOWPLACEMENT lpwndpl = default(Win32.WINDOWPLACEMENT);
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				if (!(process.MainWindowHandle == IntPtr.Zero))
				{
					IntPtr mainWindowHandle = process.MainWindowHandle;
					Win32.GetWindowPlacement(process.MainWindowHandle, ref lpwndpl);
					if (lpwndpl.showCmd == 2)
					{
						Win32.ShowWindow(process.MainWindowHandle, 0);
						return true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TrySendHomeMinimized: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public bool TrySendHomeToTray()
	{
		try
		{
			Win32.WINDOWPLACEMENT lpwndpl = default(Win32.WINDOWPLACEMENT);
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				if (!(process.MainWindowHandle == IntPtr.Zero))
				{
					Win32.GetWindowPlacement(process.MainWindowHandle, ref lpwndpl);
					if (lpwndpl.showCmd == 1)
					{
						Win32.ShowWindow(process.MainWindowHandle, 0);
						return true;
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TrySendHomeToTray: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public bool TryRestoreHome()
	{
		bool result;
		try
		{
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			Process[] array = processesByName;
			foreach (Process process in array)
			{
				if (!(process.MainWindowHandle == IntPtr.Zero))
				{
					Win32.ShowWindow(process.MainWindowHandle, 9);
					Win32.SetForegroundWindow(process.MainWindowHandle);
					result = true;
					goto IL_0093;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryRestoreHome: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0093;
		}
		result = false;
		goto IL_0093;
		IL_0093:
		return result;
	}

	public bool TryCopyAppDatabase()
	{
		bool result;
		try
		{
			if (m_appDataPath == null)
			{
				result = false;
				goto IL_007d;
			}
			string databasePath = null;
			if (!TryGetDatabasePath(ref databasePath))
			{
				result = false;
				goto IL_007d;
			}
			string text = Path.Combine(m_appDataPath, "data.sqlite");
			File.Copy(databasePath, text, overwrite: true);
			m_databasePath = text;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryCopyAppDatabase: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_007d;
		}
		result = true;
		goto IL_007d;
		IL_007d:
		return result;
	}
}
