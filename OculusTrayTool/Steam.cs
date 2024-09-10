using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool;

public class Steam
{
	private enum ValueType
	{
		Section = 0,
		String = 1,
		Int32 = 2,
		Int64 = 7,
		EndSection = 8
	}

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

	public string SteamPath => m_steamPath;

	public string InstallPath => m_installPath;

	public List<string> ConfigPathList => m_configPathList;

	public List<string> LogPathList => m_logPathList;

	public List<string> RuntimePathList => m_runtimePathList;

	public string AppDataPath => m_appDataPath;

	public List<string> LibraryFolderList => m_libraryPathList;

	public Dictionary<ulong, string> LibraryFolderDictionary => m_libraryPathDictionary;

	public Steam(string appDataPath)
	{
		VDF_VERSION_OLD = new byte[4] { 38, 68, 86, 7 };
		VDF_VERSION_NEW = new byte[4] { 39, 68, 86, 7 };
		VDF_UNIVERSE = new byte[4] { 1, 0, 0, 0 };
		LAST_APP = new byte[4];
		m_steamPath = null;
		m_installPath = null;
		m_configPathList = null;
		m_logPathList = null;
		m_runtimePathList = null;
		m_appDataPath = null;
		m_libraryPathList = null;
		m_libraryPathDictionary = null;
		m_appDataPath = appDataPath;
	}

	public bool TryRefresh()
	{
		if (!TryGetSteamPath(ref m_steamPath))
		{
			return false;
		}
		if (!TryGetInstallPath(ref m_installPath))
		{
			return false;
		}
		if (!TryGetOpenVRPathsEntry("config", ref m_configPathList))
		{
			m_configPathList.Add(Path.Combine(m_installPath, "config"));
		}
		if (!TryGetOpenVRPathsEntry("log", ref m_logPathList))
		{
			m_logPathList.Add(Path.Combine(m_installPath, "logs"));
		}
		if (!TryGetOpenVRPathsEntry("runtime", ref m_runtimePathList))
		{
			m_runtimePathList.Add(Path.Combine(m_installPath, "steamapps\\common\\SteamVR"));
		}
		if (!TryGetLibraryPathList(ref m_libraryPathList))
		{
			return false;
		}
		if (!TryGetLibraryPathDictionary(ref m_libraryPathDictionary))
		{
			return false;
		}
		return true;
	}

	private bool TryGetSteamPath(ref string steamPath)
	{
		steamPath = null;
		bool result;
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam", writable: false);
			if (registryKey == null)
			{
				result = false;
				goto IL_0088;
			}
			steamPath = Conversions.ToString(registryKey.GetValue("SteamPath"));
			if (string.IsNullOrEmpty(steamPath))
			{
				result = false;
				goto IL_0088;
			}
			steamPath = steamPath.Replace("/", "\\");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetSteamPath: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0088;
		}
		result = true;
		goto IL_0088;
		IL_0088:
		return result;
	}

	private bool TryGetInstallPath(ref string installPath)
	{
		installPath = null;
		bool result;
		try
		{
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
			RegistryKey registryKey2 = registryKey.OpenSubKey("Software\\Valve\\Steam", writable: false);
			if (registryKey2 == null)
			{
				result = false;
				goto IL_0096;
			}
			installPath = Conversions.ToString(registryKey2.GetValue("InstallPath"));
			if (string.IsNullOrEmpty(installPath))
			{
				result = false;
				goto IL_0096;
			}
			installPath = installPath.Replace("/", "\\");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetInstallPath: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0096;
		}
		result = true;
		goto IL_0096;
		IL_0096:
		return result;
	}

	public bool TryGetLibraryPathList(ref List<string> libraryFolderList)
	{
		libraryFolderList = new List<string>();
		bool result;
		try
		{
			libraryFolderList.Add(m_steamPath);
			string path = Path.Combine(m_steamPath, "steamapps\\libraryfolders.vdf");
			StreamReader streamReader = new StreamReader(path);
			while (streamReader.Peek() != -1)
			{
				string text = streamReader.ReadLine();
				if (text.ToLower().Contains("\"path\""))
				{
					text = text.Replace("\"path\"", "");
					text = text.Replace("\"", "");
					text = text.Replace("\\\\", "\\");
					libraryFolderList.Add(text.Trim());
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetLibraryPathList: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00d4;
		}
		result = true;
		goto IL_00d4;
		IL_00d4:
		return result;
	}

	public bool TryGetLibraryPathDictionary(ref Dictionary<ulong, string> libraryFolderDictionary)
	{
		libraryFolderDictionary = new Dictionary<ulong, string>();
		bool result;
		try
		{
			foreach (string libraryPath in m_libraryPathList)
			{
				List<ulong> appIdList = null;
				TryGetAppIdList(libraryPath, ref appIdList);
				foreach (ulong item in appIdList)
				{
					if (!libraryFolderDictionary.ContainsKey(item))
					{
						libraryFolderDictionary.Add(item, libraryPath);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetLibraryPathDictionary: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00cb;
		}
		result = true;
		goto IL_00cb;
		IL_00cb:
		return result;
	}

	public bool TryDisableSafeMode()
	{
		bool result;
		try
		{
			if (m_configPathList.Count == 0)
			{
				result = false;
				goto IL_00c3;
			}
			string path = Path.Combine(m_configPathList[0], "steamvr.vrsettings");
			if (!File.Exists(path))
			{
				result = false;
				goto IL_00c3;
			}
			string json = File.ReadAllText(path);
			JObject jObject = JObject.Parse(json);
			JToken jToken = jObject["steamvr"];
			if (jToken != null)
			{
				jToken["enableSafeMode"] = false;
			}
			json = jObject.ToString();
			File.WriteAllText(path, json);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryDisableSafeMode: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00c3;
		}
		result = true;
		goto IL_00c3;
		IL_00c3:
		return result;
	}

	public bool TryGetAppIdList(string libraryFolder, ref List<ulong> appIdList)
	{
		appIdList = new List<ulong>();
		bool result2;
		try
		{
			JObject acfJson = new JObject();
			ulong result = 0uL;
			if (TryGetSteamACFJson(libraryFolder, ref acfJson))
			{
				if (acfJson["acf"] == null)
				{
					result2 = false;
					goto IL_0101;
				}
				foreach (JToken item in (IEnumerable<JToken>)acfJson["acf"])
				{
					if (item["AppState"] != null)
					{
						JToken jToken = item["AppState"];
						string s = (string)jToken["appid"];
						if (ulong.TryParse(s, out result))
						{
							appIdList.Add(result);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetAppIdList: " + ex2.Message);
			result2 = false;
			ProjectData.ClearProjectError();
			goto IL_0101;
		}
		result2 = true;
		goto IL_0101;
		IL_0101:
		return result2;
	}

	public bool TryCopyACFFiles(string destinationPath)
	{
		bool result;
		try
		{
			List<string> libraryFolderList = null;
			if (!TryGetLibraryPathList(ref libraryFolderList))
			{
				result = false;
				goto IL_00d3;
			}
			foreach (string item in libraryFolderList)
			{
				string path = Path.Combine(item, "steamapps");
				string[] files = Directory.GetFiles(path, "*.acf");
				string[] array = files;
				foreach (string text in array)
				{
					File.Copy(text, Path.Combine(destinationPath, Path.GetFileName(text)), overwrite: true);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryCopyACFFiles: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00d3;
		}
		result = true;
		goto IL_00d3;
		IL_00d3:
		return result;
	}

	public bool TryCheckACFFiles(string acfPath, ref List<string> acfFileNameList)
	{
		bool flag = false;
		acfFileNameList = new List<string>();
		bool result;
		try
		{
			string[] files = Directory.GetFiles(acfPath, "*.acf");
			JObject jObject = new JObject();
			ACFReader aCFReader = new ACFReader(jObject);
			string[] array = files;
			foreach (string text in array)
			{
				if (!aCFReader.TryProcessFile(text))
				{
					acfFileNameList.Add(Path.GetFileName(text));
				}
			}
			flag = acfFileNameList.Count > 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryCheckACFFiles: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00a7;
		}
		result = flag;
		goto IL_00a7;
		IL_00a7:
		return result;
	}

	public bool TryGetSteamACFJson(ref JObject acfJson)
	{
		acfJson = new JObject();
		bool result;
		try
		{
			foreach (string libraryPath in m_libraryPathList)
			{
				TryGetSteamACFJson(libraryPath, ref acfJson);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetSteamACFJson: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0075;
		}
		result = true;
		goto IL_0075;
		IL_0075:
		return result;
	}

	public bool TryGetSteamACFJson(string libraryFolder, ref JObject acfJson)
	{
		bool result;
		try
		{
			string text = Path.Combine(libraryFolder, "steamapps");
			if (!Directory.Exists(text))
			{
				result = false;
				goto IL_006d;
			}
			ACFReader aCFReader = new ACFReader(acfJson);
			if (!aCFReader.TryProcessFolder(text))
			{
				result = false;
				goto IL_006d;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetSteamACFJson: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_006d;
		}
		result = true;
		goto IL_006d;
		IL_006d:
		return result;
	}

	public bool TryGetOpenVRPathsEntry(string name, ref List<string> valueList)
	{
		bool flag = false;
		valueList = new List<string>();
		bool result;
		try
		{
			string openvrPathsFileName = null;
			if (!TryGetOpenVRPathsFileName(ref openvrPathsFileName))
			{
				result = false;
				goto IL_00bf;
			}
			string json = File.ReadAllText(openvrPathsFileName);
			JObject jObject = JObject.Parse(json);
			JToken source = jObject.SelectToken(name);
			foreach (JToken item in source.Values())
			{
				valueList.Add(item.ToString());
			}
			flag = valueList.Count > 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetOpenVRPathsEntry: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00bf;
		}
		result = flag;
		goto IL_00bf;
		IL_00bf:
		return result;
	}

	public bool TryGetVRManifest(ref List<SteamNode> steamList)
	{
		steamList = new List<SteamNode>();
		string path = Path.Combine(m_installPath, "config\\steamapps.vrmanifest");
		bool result;
		if (!File.Exists(path))
		{
			result = false;
		}
		else
		{
			try
			{
				string json = File.ReadAllText(path);
				JObject jObject = JObject.Parse(json);
				JToken jToken = jObject.SelectToken("applications");
				foreach (JToken item2 in (IEnumerable<JToken>)jToken)
				{
					ulong result2 = 0uL;
					string text = item2["app_key"].ToString();
					string name = item2["strings"]["en_us"]["name"].ToString();
					string url = item2["url"].ToString();
					text = text.Replace("steam.app.", "");
					ulong.TryParse(text, out result2);
					SteamNode item = new SteamNode(result2, name, url);
					steamList.Add(item);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("TryGetVRManifest: " + ex2.Message);
				result = false;
				ProjectData.ClearProjectError();
				goto IL_0138;
			}
			result = true;
		}
		goto IL_0138;
		IL_0138:
		return result;
	}

	public void TryGetAppDetails(List<SteamNode> steamList)
	{
		try
		{
			foreach (SteamNode steam in steamList)
			{
				string tempPath = Path.GetTempPath();
				string text = Path.Combine(tempPath, $"{steam.AppId}.json");
				if (TryDownloadAppDetails(steam.AppId, text))
				{
					string appDetailsText = File.ReadAllText(text);
					if (steam.TryParseAppDetails(appDetailsText))
					{
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetAppDetails: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public bool TryGetAppInfo(List<SteamNode> steamList, bool windowsOnly, bool vrOnly)
	{
		bool result;
		try
		{
			Dictionary<ulong, SteamNode> appInfoDictionary = null;
			List<SteamNode> appInfoList = null;
			if (!TryGetAppInfo(windowsOnly, vrOnly, ref appInfoDictionary, ref appInfoList))
			{
				result = false;
				goto IL_012c;
			}
			foreach (SteamNode steam in steamList)
			{
				SteamNode value = null;
				if (appInfoDictionary.TryGetValue(steam.AppId, out value))
				{
					steam.Type = value.Type;
					steam.Publisher = value.Publisher;
					steam.Developer = value.Developer;
					steam.Executable = value.Executable;
					steam.Parameters = value.Parameters;
					steam.OSList = value.OSList;
					steam.LibraryFolder = value.LibraryFolder;
					steam.InstallDir = value.InstallDir;
					steam.CanonicalName = value.CanonicalName;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetAppInfo: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_012c;
		}
		result = true;
		goto IL_012c;
		IL_012c:
		return result;
	}

	private bool TryGetAppLaunchInfo(JToken appInfoLaunchJToken, bool windowsOnly, bool vrOnly, ref string oslist, ref string executable, ref string arguments, ref string type)
	{
		bool flag = false;
		bool result;
		try
		{
			foreach (JToken item in appInfoLaunchJToken.Values())
			{
				JToken jToken = item["config"];
				if (jToken != null)
				{
					oslist = (string)jToken["oslist"];
				}
				executable = (string)item["executable"];
				arguments = (string)item["arguments"];
				type = (string)item["type"];
				bool flag2 = !windowsOnly || Operators.CompareString(oslist, "windows", TextCompare: false) == 0;
				bool flag3 = !vrOnly || Operators.CompareString(type, "vr", TextCompare: false) == 0 || Operators.CompareString(type, "othervr", TextCompare: false) == 0;
				if (jToken != null)
				{
					oslist = (string)jToken["oslist"];
				}
				if (flag2 && flag3 && executable != null)
				{
					flag = true;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetAppLaunchInfo: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0152;
		}
		result = flag;
		goto IL_0152;
		IL_0152:
		return result;
	}

	public bool TryGetAppInfo(bool windowsOnly, bool vrOnly, ref Dictionary<ulong, SteamNode> appInfoDictionary, ref List<SteamNode> appInfoList)
	{
		appInfoDictionary = new Dictionary<ulong, SteamNode>();
		appInfoList = new List<SteamNode>();
		bool result;
		try
		{
			JObject appInfoJObject = null;
			if (!TryReadAppInfo(ref appInfoJObject))
			{
				result = false;
				goto IL_033f;
			}
			JObject acfJson = null;
			if (!TryGetSteamACFJson(ref acfJson))
			{
				result = false;
				goto IL_033f;
			}
			foreach (JToken item in (IEnumerable<JToken>)acfJson["acf"])
			{
				if (item["AppState"] == null)
				{
					continue;
				}
				JToken jToken = item["AppState"];
				ulong result2 = 0uL;
				string s = (string)jToken["appid"];
				string installDir = (string)jToken["installdir"];
				if (!ulong.TryParse(s, out result2))
				{
					continue;
				}
				foreach (JToken item2 in (IEnumerable<JToken>)appInfoJObject["apps"])
				{
					JToken jToken2 = item2["appinfo"];
					if (jToken2 == null)
					{
						continue;
					}
					ulong num = (ulong)jToken2["appid"];
					if (result2 != num)
					{
						continue;
					}
					string text = null;
					string text2 = null;
					string text3 = null;
					string text4 = null;
					string text5 = null;
					string executable = null;
					string arguments = null;
					string oslist = null;
					string value = null;
					JToken jToken3 = jToken2["common"];
					JToken jToken4 = jToken2["extended"];
					JToken jToken5 = jToken2["config"];
					if (jToken3 == null || jToken4 == null)
					{
						continue;
					}
					text = (string)jToken3["name"];
					text2 = (string)jToken3["type"];
					text3 = (string)jToken4["publisher"];
					text4 = (string)jToken4["developer"];
					if (jToken5 == null)
					{
						continue;
					}
					text5 = (string)jToken5["installdir"];
					JToken jToken6 = jToken5["launch"];
					if (jToken6 != null && (TryGetAppLaunchInfo(jToken6, windowsOnly, vrOnly, ref oslist, ref executable, ref arguments, ref text2) || TryGetAppLaunchInfo(jToken6, windowsOnly, vrOnly: false, ref oslist, ref executable, ref arguments, ref text2) || TryGetAppLaunchInfo(jToken6, windowsOnly: false, vrOnly: false, ref oslist, ref executable, ref arguments, ref text2)))
					{
						m_libraryPathDictionary.TryGetValue(result2, out value);
						SteamNode steamNode = new SteamNode(result2, text, text2, text3, text4, executable, arguments, oslist, value, installDir);
						if (!appInfoDictionary.ContainsKey(result2))
						{
							appInfoDictionary.Add(result2, steamNode);
							appInfoList.Add(steamNode);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetAppInfo: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_033f;
		}
		result = true;
		goto IL_033f;
		IL_033f:
		return result;
	}

	public bool TrySaveAppInfoJson(string fileName)
	{
		bool result;
		try
		{
			JObject appInfoJObject = null;
			if (!TryReadAppInfo(ref appInfoJObject))
			{
				result = false;
				goto IL_0057;
			}
			string contents = appInfoJObject.ToString();
			File.WriteAllText(fileName, contents);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TrySaveAppInfoJson: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0057;
		}
		result = true;
		goto IL_0057;
		IL_0057:
		return result;
	}

	public bool TryReadAppInfo(ref JObject appInfoJObject)
	{
		appInfoJObject = new JObject();
		bool result;
		try
		{
			JArray jArray = new JArray();
			appInfoJObject["apps"] = jArray;
			string path = Path.Combine(m_steamPath, "appcache\\appinfo.vdf");
			using FileStream input = File.OpenRead(path);
			using BinaryReader binaryReader = new BinaryReader(input);
			byte[] thisBytes = binaryReader.ReadBytes(4);
			byte[] thisBytes2 = binaryReader.ReadBytes(4);
			bool flag = StartsWith(thisBytes, VDF_VERSION_OLD);
			bool flag2 = StartsWith(thisBytes, VDF_VERSION_NEW);
			if (!flag && !flag2)
			{
				result = false;
				goto IL_0227;
			}
			if (!StartsWith(thisBytes2, VDF_UNIVERSE))
			{
				result = false;
				goto IL_0227;
			}
			while (ReadInt32(binaryReader) != 0)
			{
				JObject jObject = new JObject();
				jObject["size"] = ReadInt32(binaryReader);
				jObject["state"] = ReadInt32(binaryReader);
				jObject["lastupdate"] = ReadInt32(binaryReader);
				jObject["accesstoken"] = ReadInt64(binaryReader);
				jObject["checksum"] = ReadString(binaryReader, 20);
				jObject["changenumber"] = ReadInt32(binaryReader);
				if (flag2)
				{
					ReadSubSection(binaryReader, jObject, isRootSection: false);
				}
				else
				{
					while (binaryReader.ReadByte() != 0)
					{
						binaryReader.ReadByte();
						string text = ReadString(binaryReader);
						ReadSubSection(binaryReader, jObject, isRootSection: true);
					}
				}
				jArray.Add(jObject);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryReadAppInfo: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0227;
		}
		result = true;
		goto IL_0227;
		IL_0227:
		return result;
	}

	private bool IsNumber(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return false;
		}
		foreach (char c in value)
		{
			if (!char.IsNumber(c))
			{
				return false;
			}
		}
		return true;
	}

	private bool StartsWith(byte[] thisBytes, byte[] thatBytes)
	{
		if (thatBytes.Length > thisBytes.Length)
		{
			return false;
		}
		for (int i = 0; i < thatBytes.Length; i = checked(i + 1))
		{
			if (thisBytes[i] != thatBytes[i])
			{
				return false;
			}
		}
		return true;
	}

	private void ReadSubSection(BinaryReader binaryReader, JToken jToken, bool isRootSection)
	{
		while (true)
		{
			ValueType valueType = (ValueType)binaryReader.ReadByte();
			if (valueType == ValueType.EndSection)
			{
				break;
			}
			string key = ReadString(binaryReader);
			TryReadValue(binaryReader, valueType, key, jToken);
		}
		if (isRootSection)
		{
			binaryReader.ReadByte();
		}
	}

	private bool TryReadValue(BinaryReader binaryReader, ValueType valueType, string key, JToken jToken)
	{
		switch (valueType)
		{
		case ValueType.Section:
		{
			JObject jToken3 = (JObject)(jToken[key] = new JObject());
			ReadSubSection(binaryReader, jToken3, isRootSection: false);
			return false;
		}
		case ValueType.String:
			jToken[key] = ReadString(binaryReader);
			return true;
		case ValueType.Int32:
			jToken[key] = ReadInt32(binaryReader);
			return true;
		case ValueType.Int64:
			jToken[key] = ReadInt64(binaryReader);
			return true;
		default:
			return false;
		}
	}

	private string ReadString(BinaryReader binaryReader)
	{
		List<byte> list = new List<byte>();
		for (byte b = binaryReader.ReadByte(); b != 0; b = binaryReader.ReadByte())
		{
			list.Add(b);
		}
		return Encoding.UTF8.GetString(list.ToArray());
	}

	private string ReadString(BinaryReader binaryReader, int charCount)
	{
		byte[] array = binaryReader.ReadBytes(charCount);
		return BitConverter.ToString(array).Replace("-", "");
	}

	private int ReadInt32(BinaryReader binaryReader)
	{
		byte[] value = binaryReader.ReadBytes(4);
		return BitConverter.ToInt32(value, 0);
	}

	private long ReadInt64(BinaryReader binaryReader)
	{
		byte[] value = binaryReader.ReadBytes(8);
		return BitConverter.ToInt64(value, 0);
	}

	public bool TryDownloadAppHeader(ulong appId, object tag, DownloadProgressChangedEventHandler downloadProgressChanged, EventHandler<DataDownloadEventArgs> downloadComplete)
	{
		string url = $"https://steamcdn-a.akamaihd.net/steam/apps/{appId}/header.jpg";
		return TryDownloadFile(url, RuntimeHelpers.GetObjectValue(tag), downloadProgressChanged, downloadComplete);
	}

	public static bool TryDownloadFile(string url, object tag, DownloadProgressChangedEventHandler downloadProgressChanged, EventHandler<DataDownloadEventArgs> downloadComplete)
	{
		try
		{
			using (WebClient webClient = new WebClient())
			{
				webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
				webClient.DownloadProgressChanged += downloadProgressChanged;
				webClient.DownloadDataCompleted += [SpecialName] (object sender, DownloadDataCompletedEventArgs e) =>
				{
					if (e.Result == null || e.Error != null || e.Cancelled)
					{
						return;
					}
					object[] array = (object[])e.UserState;
					Uri uri2 = (Uri)array[0];
					object objectValue2 = RuntimeHelpers.GetObjectValue(array[1]);
					object objectValue3 = RuntimeHelpers.GetObjectValue(array[2]);
					string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
					string text2 = Path.Combine(text, Path.GetFileName(uri2.LocalPath));
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					if (File.Exists(text2))
					{
						File.Delete(text2);
					}
					File.WriteAllBytes(text2, e.Result);
					if (downloadComplete != null)
					{
						downloadComplete(null, new DataDownloadEventArgs(text2, RuntimeHelpers.GetObjectValue(objectValue3)));
					}
					object obj2 = objectValue2;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
					bool lockTaken2 = false;
					try
					{
						Monitor.Enter(obj2, ref lockTaken2);
						Monitor.Pulse(RuntimeHelpers.GetObjectValue(objectValue2));
					}
					finally
					{
						if (lockTaken2)
						{
							Monitor.Exit(obj2);
						}
					}
				};
				Uri uri = new Uri(url);
				object objectValue = RuntimeHelpers.GetObjectValue(new object());
				object obj = objectValue;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				bool lockTaken = false;
				try
				{
					Monitor.Enter(obj, ref lockTaken);
					webClient.DownloadDataAsync(uri, new object[3] { uri, objectValue, tag });
					Monitor.Wait(RuntimeHelpers.GetObjectValue(objectValue));
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(obj);
					}
				}
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryDownloadFile: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public static bool TryDownloadFileAsync(string url, object tag, DownloadProgressChangedEventHandler downloadProgressChanged, EventHandler<DataDownloadEventArgs> downloadComplete)
	{
		try
		{
			Uri address = new Uri(url);
			using (WebClient webClient = new WebClient())
			{
				webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
				webClient.DownloadProgressChanged += downloadProgressChanged;
				webClient.DownloadDataCompleted += [SpecialName] (object sender, DownloadDataCompletedEventArgs e) =>
				{
					if (e.Result != null && e.Error == null && !e.Cancelled)
					{
						string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
						string text2 = Path.Combine(text, Path.GetFileName(url));
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
							Log.WriteToLog("Created temporary directory '" + text + "'");
						}
						if (File.Exists(text2))
						{
							File.Delete(text2);
						}
						File.WriteAllBytes(text2, e.Result);
						if (downloadComplete != null)
						{
							downloadComplete(null, new DataDownloadEventArgs(text2, RuntimeHelpers.GetObjectValue(tag)));
						}
					}
				};
				webClient.DownloadDataAsync(address, RuntimeHelpers.GetObjectValue(tag));
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryDownloadFileAsync: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public static bool TryDownloadAppList(object tag, EventHandler<DataDownloadEventArgs> downloadComplete)
	{
		try
		{
			Uri address = new Uri("https://api.steampowered.com/ISteamApps/GetAppList/v2/");
			using (WebClient webClient = new WebClient())
			{
				webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
				webClient.DownloadDataCompleted += [SpecialName] (object sender, DownloadDataCompletedEventArgs e) =>
				{
					if (e.Result != null && e.Error == null && !e.Cancelled)
					{
						string text = Path.Combine(Path.GetTempPath(), "applist.json");
						if (File.Exists(text))
						{
							File.Delete(text);
						}
						File.WriteAllBytes(text, e.Result);
						if (downloadComplete != null)
						{
							downloadComplete(null, new DataDownloadEventArgs(text, RuntimeHelpers.GetObjectValue(tag)));
						}
					}
				};
				webClient.DownloadDataAsync(address);
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryDownloadAppList: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public bool TryDownloadAppDetails(ulong appId, string fileName)
	{
		try
		{
			Uri address = new Uri($"https://store.steampowered.com/api/appdetails?appids={appId}&cc=us");
			using (WebClient webClient = new WebClient())
			{
				webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
				byte[] bytes = webClient.DownloadData(address);
				File.WriteAllBytes(fileName, bytes);
			}
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryDownloadAppDetails: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	public bool TryLaunchApp(ulong appId, string parameters)
	{
		bool result;
		try
		{
			Process process = new Process();
			process.StartInfo.WorkingDirectory = m_steamPath;
			process.StartInfo.FileName = Path.Combine(m_steamPath, "Steam.exe");
			process.StartInfo.Arguments = $"-applaunch {appId} {parameters}";
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = false;
			process.Start();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryLaunchApp: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00a2;
		}
		result = true;
		goto IL_00a2;
		IL_00a2:
		return result;
	}

	public bool TryInstallDriver(string driverPath, bool removedriver)
	{
		bool flag = false;
		bool result;
		try
		{
			if (m_installPath == null)
			{
				result = false;
				goto IL_00f0;
			}
			string text = Path.Combine(m_installPath, "steamapps\\common\\SteamVR\\bin\\win64\\vrpathreg.exe");
			if (!File.Exists(text))
			{
				result = false;
				goto IL_00f0;
			}
			Process process = new Process();
			process.StartInfo.WorkingDirectory = m_installPath;
			process.StartInfo.FileName = text;
			process.StartInfo.Arguments = string.Format("{0} \"{1}\"", removedriver ? "removedriver" : "adddriver", driverPath);
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.Start();
			process.WaitForExit();
			flag = process.ExitCode == 0;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryInstallDriver: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_00f0;
		}
		result = flag;
		goto IL_00f0;
		IL_00f0:
		return result;
	}

	public bool TryGetOpenVRPathsFileName(ref string openvrPathsFileName)
	{
		bool flag = false;
		openvrPathsFileName = null;
		bool result;
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("LocalAppData");
			string path = Path.Combine(environmentVariable, "openvr");
			openvrPathsFileName = Path.Combine(path, "openvrpaths.vrpath");
			flag = File.Exists(openvrPathsFileName);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryGetOpenVRPathsFileName: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0063;
		}
		result = flag;
		goto IL_0063;
		IL_0063:
		return result;
	}

	public bool TryUninstall(string driverName)
	{
		bool flag = false;
		bool result;
		try
		{
			List<string> valueList = null;
			if (!TryGetOpenVRPathsEntry("external_drivers", ref valueList))
			{
				result = false;
				goto IL_0094;
			}
			foreach (string item in valueList)
			{
				if (TryInstallDriver(item, removedriver: true))
				{
					flag = true;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("TryUninstall: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0094;
		}
		result = flag;
		goto IL_0094;
		IL_0094:
		return result;
	}

	public bool IsDriverInstalled(string driverName)
	{
		bool result;
		try
		{
			List<string> valueList = null;
			if (!TryGetOpenVRPathsEntry("external_drivers", ref valueList))
			{
				result = false;
				goto IL_0091;
			}
			foreach (string item in valueList)
			{
				if (!item.Contains(driverName))
				{
					continue;
				}
				result = true;
				goto IL_0091;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("IsDriverInstalled: " + ex2.Message);
			result = false;
			ProjectData.ClearProjectError();
			goto IL_0091;
		}
		result = false;
		goto IL_0091;
		IL_0091:
		return result;
	}

	public bool TryLaunchSteam()
	{
		return TryLaunchApp(250820uL, "");
	}
}
