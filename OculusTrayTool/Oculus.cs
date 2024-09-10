using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool
{
	// Token: 0x0200003B RID: 59
	public class Oculus
	{
		// Token: 0x060004F6 RID: 1270 RVA: 0x00025E04 File Offset: 0x00024004
		public Oculus(string appDataPath, Steam steam)
		{
			this.m_oculusPath = null;
			this.m_appDataPath = null;
			this.m_softwarePathList = null;
			this.m_databasePath = null;
			this.m_manifestFileList = null;
			this.m_assetDirectoryList = null;
			this.m_steam = null;
			this.m_appDataPath = appDataPath;
			this.m_steam = steam;
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x00025E58 File Offset: 0x00024058
		public bool TryRefresh()
		{
			bool flag = !this.TryGetOculusPath(ref this.m_oculusPath);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				bool flag3 = !this.TryGetOculusSoftwarePathList(ref this.m_softwarePathList);
				if (flag3)
				{
					flag2 = false;
				}
				else
				{
					bool flag4 = !this.TryGetManifestFileNameAndAssetFolderList(ref this.m_manifestFileList, ref this.m_assetDirectoryList);
					if (flag4)
					{
						flag2 = false;
					}
					else
					{
						bool flag5 = !this.TryCopyAppDatabase();
						flag2 = !flag5;
					}
				}
			}
			return flag2;
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00025ED0 File Offset: 0x000240D0
		private bool TryGetOculusPath(ref string oculusPath)
		{
			oculusPath = null;
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\WOW6432Node\\Oculus VR, LLC\\Oculus", false);
				bool flag = registryKey == null;
				if (flag)
				{
					registryKey = Registry.LocalMachine.OpenSubKey("Software\\Oculus VR, LLC\\Oculus", false);
					bool flag2 = registryKey == null;
					if (flag2)
					{
						return false;
					}
				}
				oculusPath = Conversions.ToString(registryKey.GetValue("Base"));
				bool flag3 = string.IsNullOrEmpty(oculusPath);
				if (flag3)
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetOculusPath: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00025F84 File Offset: 0x00024184
		private bool TryGetExplorerUserSid(ref string ownerSid)
		{
			ownerSid = null;
			try
			{
				ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name = 'explorer.exe'").Get();
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator())
				{
					bool flag = enumerator.MoveNext();
					if (flag)
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						string[] array = new string[2];
						managementObject.InvokeMethod("GetOwnerSid", array);
						ownerSid = array[0];
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetExplorerUserSid: " + ex.Message);
				return false;
			}
			return false;
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00026044 File Offset: 0x00024244
		private bool TryGetOculusSoftwarePathList(ref List<string> softwarePathList)
		{
			softwarePathList = new List<string>();
			string text = null;
			bool flag = !this.TryGetExplorerUserSid(ref text);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				try
				{
					string text2 = Path.Combine(text, "SOFTWARE\\Oculus VR, LLC\\Oculus\\Libraries");
					RegistryKey registryKey = Registry.Users.OpenSubKey(text2, false);
					bool flag3 = registryKey == null;
					if (flag3)
					{
						return false;
					}
					string[] subKeyNames = registryKey.GetSubKeyNames();
					foreach (string text3 in subKeyNames)
					{
						RegistryKey registryKey2 = Registry.Users.OpenSubKey(Path.Combine(text2, text3), false);
						string text4 = Conversions.ToString(registryKey2.GetValue("Path"));
						bool flag4 = text4 == null;
						if (!flag4)
						{
							string text5 = text4.Substring(text4.LastIndexOf("}")).TrimStart(new char[] { '}' });
							string text6 = text4.Replace(text5, "") + "\\";
							ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_Volume");
							try
							{
								foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
								{
									ManagementObject managementObject = (ManagementObject)managementBaseObject;
									bool flag5 = Operators.CompareString(Conversions.ToString(managementObject["DeviceID"]), text6, false) == 0;
									if (flag5)
									{
										string text7 = Conversions.ToString(managementObject["DriveLetter"]);
										softwarePathList.Add(text7 + text5);
										break;
									}
								}
							}
							finally
							{
								ManagementObjectCollection.ManagementObjectEnumerator enumerator;
								if (enumerator != null)
								{
									((IDisposable)enumerator).Dispose();
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("TryGetOculusSoftwarePathList: " + ex.Message);
					return false;
				}
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x00026244 File Offset: 0x00024444
		private bool TryGetDatabasePath(ref string databasePath)
		{
			databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite");
			return File.Exists(databasePath);
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x00026270 File Offset: 0x00024470
		public bool IsAppInstalled(OculusNode oculusNode)
		{
			List<string> list = null;
			List<string> list2 = null;
			return this.TryGetManifestFileNameAndAssetFolderList(oculusNode, ref list, ref list2);
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00026294 File Offset: 0x00024494
		public bool TryGetManifestFileNameAndAssetFolderList(ref List<FileInfo> manifestFileList, ref List<DirectoryInfo> assetFolderList)
		{
			manifestFileList = new List<FileInfo>();
			assetFolderList = new List<DirectoryInfo>();
			try
			{
				string text = Path.Combine(this.m_oculusPath, "CoreData\\Manifests");
				string text2 = Path.Combine(this.m_oculusPath, "CoreData\\Software\\StoreAssets");
				List<FileInfo> list = new List<FileInfo>();
				DirectoryInfo directoryInfo = new DirectoryInfo(text);
				list.AddRange(directoryInfo.GetFiles("*.json"));
				directoryInfo = new DirectoryInfo(text2);
				assetFolderList.AddRange(directoryInfo.GetDirectories("*_assets"));
				try
				{
					foreach (string text3 in this.m_softwarePathList)
					{
						string text4 = Path.Combine(text3, "Manifests");
						directoryInfo = new DirectoryInfo(text4);
						list.AddRange(directoryInfo.GetFiles("*.json"));
						string text5 = Path.Combine(text3, "Software\\StoreAssets");
						bool flag = Directory.Exists(text5);
						if (flag)
						{
							directoryInfo = new DirectoryInfo(text5);
							assetFolderList.AddRange(directoryInfo.GetDirectories("*_assets"));
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				try
				{
					foreach (FileInfo fileInfo in list)
					{
						bool flag2 = fileInfo.Name.Contains("_assets");
						if (!flag2)
						{
							manifestFileList.Add(fileInfo);
						}
					}
				}
				finally
				{
					List<FileInfo>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetManifestFileNameAndAssetFolderList: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060004FE RID: 1278 RVA: 0x00026480 File Offset: 0x00024680
		public bool TryGetManifestFileNameAndAssetFolderList(OculusNode oculusNode, ref List<string> manifestFileList, ref List<string> assetDirectoryList)
		{
			bool flag = false;
			manifestFileList = new List<string>();
			assetDirectoryList = new List<string>();
			try
			{
				string shortCanonicalName = oculusNode.ShortCanonicalName;
				bool flag2 = shortCanonicalName == null;
				if (flag2)
				{
					return false;
				}
				try
				{
					foreach (FileInfo fileInfo in this.m_manifestFileList)
					{
						bool flag3 = fileInfo.Name.StartsWith(shortCanonicalName, true, Thread.CurrentThread.CurrentCulture);
						if (flag3)
						{
							manifestFileList.Add(fileInfo.FullName);
						}
					}
				}
				finally
				{
					List<FileInfo>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
				try
				{
					foreach (DirectoryInfo directoryInfo in this.m_assetDirectoryList)
					{
						bool flag4 = directoryInfo.Name.StartsWith(shortCanonicalName, true, Thread.CurrentThread.CurrentCulture);
						if (flag4)
						{
							assetDirectoryList.Add(directoryInfo.FullName);
						}
					}
				}
				finally
				{
					List<DirectoryInfo>.Enumerator enumerator2;
					((IDisposable)enumerator2).Dispose();
				}
				flag = checked(manifestFileList.Count + assetDirectoryList.Count) > 0;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetManifestFileNameAndAssetFolderList: " + ex.Message);
				return false;
			}
			return flag;
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x000265F0 File Offset: 0x000247F0
		public bool TryCreateManifest(SteamNode steamNode, SteamLaunchType steamLaunchType)
		{
			try
			{
				string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game_template.json");
				bool flag = !File.Exists(text);
				if (flag)
				{
					return false;
				}
				string text2 = File.ReadAllText(text);
				JObject jobject = JObject.Parse(text2);
				string text3 = Path.Combine(this.m_oculusPath, "CoreData\\Manifests");
				string canonicalName = steamNode.CanonicalName;
				string name = steamNode.Name;
				string text4 = Path.Combine(text3, canonicalName + ".json");
				string text5 = Path.Combine(this.m_steam.SteamPath, "Steam.exe");
				jobject["canonicalName"] = canonicalName;
				jobject["displayName"] = name;
				switch (steamLaunchType)
				{
				case SteamLaunchType.Cmd:
					jobject["files"][text5] = "";
					jobject["launchFile"] = "cmd.exe";
					jobject["launchParameters"] = string.Format("/c start \"VR\" \"{0}\"", steamNode.Url);
					break;
				case SteamLaunchType.SteamExe:
					jobject["files"][text5] = "";
					jobject["launchFile"] = text5;
					jobject["launchParameters"] = string.Format("-applaunch {0} \"{1}\"", steamNode.AppId, steamNode.Parameters);
					break;
				case SteamLaunchType.App:
					jobject["files"][steamNode.FullPath] = "";
					jobject["launchFile"] = steamNode.FullPath;
					jobject["launchParameters"] = steamNode.Parameters;
					break;
				}
				text2 = jobject.ToString();
				File.WriteAllText(text4, text2);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryCreateManifest: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00026834 File Offset: 0x00024A34
		public bool TryCreateAssetManifest(SteamNode steamNode, string bitmapFileName)
		{
			try
			{
				string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "game_assets_template.json");
				bool flag = !File.Exists(text);
				if (flag)
				{
					return false;
				}
				string text2 = File.ReadAllText(text);
				JObject jobject = JObject.Parse(text2);
				string text3 = steamNode.CanonicalName + "_assets";
				string text4 = Path.Combine(Path.Combine(this.m_oculusPath, "CoreData\\Software\\StoreAssets"), text3);
				string text5 = Path.Combine(Path.Combine(this.m_oculusPath, "CoreData\\Manifests"), text3 + ".json");
				bool flag2 = !Directory.Exists(text4);
				if (flag2)
				{
					Directory.CreateDirectory(text4);
				}
				string text6 = Path.Combine(text4, "cover_landscape_image.jpg");
				string text7 = Path.Combine(text4, "cover_landscape_image_large.png");
				string text8 = Path.Combine(text4, "cover_square_image.jpg");
				string text9 = Path.Combine(text4, "icon_image.jpg");
				string text10 = Path.Combine(text4, "original.jpg");
				string text11 = Path.Combine(text4, "small_landscape_image.jpg");
				string text12 = Path.Combine(text4, "logo_transparent_image.png");
				using (Bitmap bitmap = (Bitmap)Image.FromFile(bitmapFileName))
				{
					using (Bitmap bitmap2 = new Bitmap(bitmap, new Size(360, 202)))
					{
						bitmap2.Save(text6, ImageFormat.Jpeg);
						bitmap2.Save(text12, ImageFormat.Png);
					}
					using (Bitmap bitmap3 = new Bitmap(bitmap, new Size(720, 405)))
					{
						bitmap3.Save(text7, ImageFormat.Png);
					}
					using (Bitmap bitmap4 = new Bitmap(bitmap, new Size(360, 202)))
					{
						bitmap4.Save(text8, ImageFormat.Jpeg);
					}
					using (Bitmap bitmap5 = new Bitmap(bitmap, new Size(192, 192)))
					{
						bitmap5.Save(text9, ImageFormat.Jpeg);
					}
					using (Bitmap bitmap6 = new Bitmap(bitmap, new Size(256, 256)))
					{
						bitmap6.Save(text10, ImageFormat.Jpeg);
					}
					using (Bitmap bitmap7 = new Bitmap(bitmap, new Size(270, 90)))
					{
						bitmap7.Save(text11, ImageFormat.Jpeg);
					}
				}
				string sha256Checksum = this.GetSha256Checksum(text6);
				string sha256Checksum2 = this.GetSha256Checksum(text6);
				string sha256Checksum3 = this.GetSha256Checksum(text8);
				string sha256Checksum4 = this.GetSha256Checksum(text9);
				string sha256Checksum5 = this.GetSha256Checksum(text10);
				string sha256Checksum6 = this.GetSha256Checksum(text11);
				string sha256Checksum7 = this.GetSha256Checksum(text12);
				jobject["files"]["cover_landscape_image.jpg"] = sha256Checksum;
				jobject["files"]["cover_landscape_image_large.png"] = sha256Checksum2;
				jobject["files"]["cover_square_image.jpg"] = sha256Checksum3;
				jobject["files"]["icon_image.jpg"] = sha256Checksum4;
				jobject["files"]["original.jpg"] = sha256Checksum5;
				jobject["files"]["small_landscape_image.jpg"] = sha256Checksum6;
				jobject["files"]["logo_transparent_image.png"] = sha256Checksum7;
				jobject["canonicalName"] = text3;
				text2 = jobject.ToString();
				File.WriteAllText(text5, text2);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryCreateAssetManifest: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x00026CEC File Offset: 0x00024EEC
		public bool TryExtractExeIcon(string exeFileName, string iconFileName)
		{
			try
			{
				using (Icon icon = Icon.ExtractAssociatedIcon(exeFileName))
				{
					using (Bitmap bitmap = icon.ToBitmap())
					{
						bitmap.Save(iconFileName, ImageFormat.Png);
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryExtractExeIcon: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00026D8C File Offset: 0x00024F8C
		public bool TryDownloadAppHeader(SteamNode steamNode, DownloadProgressChangedEventHandler downloadProgressChanged)
		{
			string tempPath = Path.GetTempPath();
			string text = Path.Combine(tempPath, "icon.png");
			bool flag = this.m_steam.TryDownloadAppHeader(steamNode.AppId, "header.jpg", downloadProgressChanged, delegate(object sender, DataDownloadEventArgs e)
			{
				this.TryCreateAssetManifest(steamNode, e.FileName);
			});
			bool flag2;
			if (flag)
			{
				flag2 = true;
			}
			else
			{
				bool flag3 = !this.TryExtractExeIcon(steamNode.FullPath, text);
				if (flag3)
				{
					flag2 = false;
				}
				else
				{
					bool flag4 = !this.TryCreateAssetManifest(steamNode, text);
					flag2 = !flag4;
				}
			}
			return flag2;
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x00026E34 File Offset: 0x00025034
		private string ByteArrayToString(byte[] byteArray)
		{
			return BitConverter.ToString(byteArray).Replace("-", "");
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x00026E5C File Offset: 0x0002505C
		private byte[] GetByteArray(SQLiteDataReader reader)
		{
			byte[] array = new byte[2049];
			long num = 0L;
			long num2 = 0L;
			byte[] array2;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				while (-((num == reader.GetBytes(0, num2, array, 0, array.Length)) > false) > false)
				{
					checked
					{
						memoryStream.Write(array, 0, (int)num);
						num2 += num;
					}
				}
				array2 = memoryStream.ToArray();
			}
			return array2;
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x00026EDC File Offset: 0x000250DC
		public bool TryGetApps(ref List<OculusNode> allAppList, bool includeThirdParty)
		{
			allAppList = new List<OculusNode>();
			try
			{
				List<OculusNode> list = new List<OculusNode>();
				if (includeThirdParty)
				{
					string text = Path.Combine(this.m_oculusPath, "CoreData\\Manifests");
					bool flag = Directory.Exists(text);
					if (flag)
					{
						bool flag2 = this.TryGetThirdPartyApps(text, ref list);
						if (flag2)
						{
							allAppList.AddRange(list);
						}
					}
				}
				List<string> list2 = null;
				bool flag3 = !this.TryGetOculusSoftwarePathList(ref list2);
				if (flag3)
				{
					return false;
				}
				try
				{
					foreach (string text2 in list2)
					{
						string text = Path.Combine(text2, "Manifests");
						bool flag4 = Directory.Exists(text);
						if (flag4)
						{
							bool flag5 = this.TryGetApps(text, ref list);
							if (flag5)
							{
								allAppList.AddRange(list);
							}
						}
						if (includeThirdParty)
						{
							text = Path.Combine(text2, "CoreData\\Manifests");
							bool flag6 = Directory.Exists(text);
							if (flag6)
							{
								bool flag7 = this.TryGetThirdPartyApps(text, ref list);
								if (flag7)
								{
									allAppList.AddRange(list);
								}
							}
						}
					}
				}
				finally
				{
					List<string>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetApps: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x00027064 File Offset: 0x00025264
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
			bool flag = false;
			SQLiteConnection sqliteConnection = new SQLiteConnection(string.Format("Data Source={0}", this.m_databasePath));
			sqliteConnection.Open();
			SQLiteCommand sqliteCommand = null;
			try
			{
				string text8 = Path.Combine(this.m_oculusPath, "CoreData\\Software\\StoreAssets");
				string text9 = ((this.m_softwarePathList.Count > 0) ? Path.Combine(this.m_softwarePathList[0], "Software\\StoreAssets") : null);
				string[] files = Directory.GetFiles(manifestPath, "*.mini");
				foreach (string text10 in files)
				{
					string text11 = File.ReadAllText(text10);
					JObject jobject = JObject.Parse(text11);
					string text12 = jobject.SelectToken("appId").ToString();
					ulong num = 0UL;
					bool flag2 = Operators.CompareString(text12, "", false) == 0;
					if (!flag2)
					{
						ulong.TryParse(text12, out num);
						text6 = jobject.SelectToken("canonicalName").ToString();
						text = Path.Combine(manifestPath, text6) + "_assets.json";
						string text13 = jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
						text3 = jobject.SelectToken("launchParameters").ToString();
						string text14 = Path.Combine(Path.Combine(Path.GetDirectoryName(manifestPath), "Software"), text6.Replace("/", "\\").Replace("\\\\", "\\"));
						text2 = text13.Replace("/", "\\").Replace("\\\\", "\\");
						text4 = ((Operators.CompareString(text14, "", false) != 0) ? Path.GetDirectoryName(text14) : "");
						text5 = ((Operators.CompareString(text14, "", false) != 0) ? Path.GetFileName(text14) : "");
						StringBuilder stringBuilder = new StringBuilder();
						try
						{
							sqliteCommand = new SQLiteCommand(sqliteConnection);
							sqliteCommand.CommandText = string.Format("select value from Objects WHERE hashkey='{0}' AND typename='Application'", num);
							using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
							{
								bool hasRows = sqliteDataReader.HasRows;
								if (hasRows)
								{
									while (sqliteDataReader.Read())
									{
										byte[] byteArray = this.GetByteArray(sqliteDataReader);
										stringBuilder.Append(Encoding.Default.GetString(byteArray));
									}
								}
							}
						}
						catch (Exception ex)
						{
							return false;
						}
						finally
						{
							sqliteCommand.Dispose();
							sqliteCommand = null;
						}
						string text15 = stringBuilder.ToString();
						string text16 = Regex.Replace(text15, "[^A-Za-z0-9\\-/]", ":");
						text16 = text16.Replace(":::", ":");
						text16 = text16.Replace("::", ":");
						string text17 = "display:name::";
						string text18 = ":display:short:description";
						int num2 = text16.IndexOf(text17);
						int num3 = text16.IndexOf(text18);
						string text19 = Path.Combine(text8, text6 + "_assets\\cover_landscape_image.jpg");
						string text20 = Path.Combine(text9, text6 + "_assets\\cover_landscape_image.jpg");
						bool flag3 = text15.Contains("FLAT");
						bool flag4 = File.Exists(text19);
						if (flag4)
						{
							text7 = text19;
						}
						else
						{
							bool flag5 = File.Exists(text20);
							if (flag5)
							{
								text7 = text20;
							}
						}
						bool flag6 = !File.Exists(text);
						if (flag6)
						{
							text = null;
						}
						bool flag7 = num2 > -1 && num3 > -1;
						if (flag7)
						{
							string text21 = checked(text16.Substring(num2 + text17.Length, num3 - num2 - text17.Length - 1));
							text21 = text21.Replace(":", " ").TrimEnd(new char[] { ':', ' ' });
							OculusNode oculusNode = new OculusNode(PlatformType.Oculus, num, text10, text, text21, text2, text3, text4, text5, text6, text7, flag3, flag, false);
							appList.Add(oculusNode);
						}
					}
				}
			}
			catch (Exception ex2)
			{
				return false;
			}
			finally
			{
				sqliteConnection.Close();
				sqliteConnection = null;
			}
			return true;
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x00027514 File Offset: 0x00025714
		public bool TryGetThirdPartyApps(string manifestPath, ref List<OculusNode> appList)
		{
			appList = new List<OculusNode>();
			string text = Path.Combine(this.m_oculusPath, "CoreData\\Software\\StoreAssets");
			string text2 = ((this.m_softwarePathList.Count > 0) ? Path.Combine(this.m_softwarePathList[0], "Software\\StoreAssets") : null);
			string[] files = Directory.GetFiles(manifestPath, "*.json");
			string text3 = null;
			string text4 = null;
			string text5 = null;
			string text6 = null;
			string text7 = null;
			string text8 = null;
			string text9 = null;
			string text10 = null;
			string text11 = null;
			bool flag = false;
			bool flag2 = false;
			StringBuilder stringBuilder = new StringBuilder();
			SQLiteConnection sqliteConnection = new SQLiteConnection(string.Format("Data Source={0}", this.m_databasePath));
			SQLiteCommand sqliteCommand = null;
			sqliteConnection.Open();
			try
			{
				foreach (string text12 in files)
				{
					bool flag3 = text12.Contains("_assets.json");
					if (!flag3)
					{
						string text13 = File.ReadAllText(text12);
						JObject jobject = JObject.Parse(text13);
						text10 = jobject.SelectToken("canonicalName").ToString();
						text3 = Path.Combine(manifestPath, text10) + "_assets.json";
						JEnumerable<JToken> jenumerable = jobject.Children();
						bool flag4 = (bool)jobject.SelectToken("thirdParty");
						try
						{
							foreach (JToken jtoken in jenumerable)
							{
								JProperty jproperty = (JProperty)jtoken;
								jproperty.CreateReader();
								bool flag5 = Operators.CompareString(jproperty.Name, "displayName", false) == 0;
								if (flag5)
								{
									text4 = jproperty.Value.ToString();
								}
								else
								{
									bool flag6 = Operators.CompareString(jproperty.Name, "launchFile", false) == 0;
									if (flag6)
									{
										string text14 = jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
										text6 = Path.GetDirectoryName(text14);
										text5 = Path.GetFileName(text14);
										text8 = ((Operators.CompareString(text6, "", false) != 0) ? Path.GetDirectoryName(text6) : "");
										text9 = ((Operators.CompareString(text6, "", false) != 0) ? Path.GetFileName(text6) : "");
										bool flag7 = text4.ToLower().EndsWith(".exe") || Operators.CompareString(text4.ToLower(), "unknown app", false) == 0;
										if (flag7)
										{
											text4 = Path.GetFileNameWithoutExtension(text5);
										}
									}
									else
									{
										bool flag8 = Operators.CompareString(jproperty.Name, "launchParameters", false) == 0;
										if (flag8)
										{
											text7 = jproperty.Value.ToString();
											break;
										}
									}
								}
							}
						}
						finally
						{
							IEnumerator<JToken> enumerator;
							if (enumerator != null)
							{
								enumerator.Dispose();
							}
						}
						bool flag9 = text4 == null || text6 == null;
						if (!flag9)
						{
							try
							{
								sqliteCommand = new SQLiteCommand(sqliteConnection);
								sqliteCommand.CommandText = string.Format("select value from Objects WHERE hashkey=\"{0}_LocalAppState\" AND typename='LocalApplicationState'", text10);
								using (SQLiteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
								{
									bool hasRows = sqliteDataReader.HasRows;
									if (hasRows)
									{
										while (sqliteDataReader.Read())
										{
											byte[] byteArray = this.GetByteArray(sqliteDataReader);
											stringBuilder.Append(Encoding.Default.GetString(byteArray));
										}
									}
								}
							}
							catch (Exception ex)
							{
								return false;
							}
							finally
							{
								sqliteCommand.Dispose();
								sqliteCommand = null;
							}
							string text15 = stringBuilder.ToString();
							string text16 = Path.Combine(text, text10 + "_assets\\cover_landscape_image.jpg");
							string text17 = Path.Combine(text2, text10 + "_assets\\cover_landscape_image.jpg");
							flag = text15.Contains("FLAT");
							flag2 = false;
							bool flag10 = File.Exists(text16);
							if (flag10)
							{
								text11 = text16;
							}
							else
							{
								bool flag11 = File.Exists(text17);
								if (flag11)
								{
									text11 = text17;
								}
							}
							bool flag12 = !File.Exists(text3);
							if (flag12)
							{
								text3 = null;
							}
							bool flag13 = Operators.CompareString(text15, "", false) != 0;
							if (flag13)
							{
								try
								{
									sqliteCommand = new SQLiteCommand(sqliteConnection);
									sqliteCommand.CommandText = string.Format("select value from Objects WHERE hashkey LIKE \"%{0}%\" AND typename='UserAppPlayTime'", text10);
									using (SQLiteDataReader sqliteDataReader2 = sqliteCommand.ExecuteReader())
									{
										flag2 = sqliteDataReader2.HasRows;
									}
								}
								catch (Exception ex2)
								{
								}
								finally
								{
									sqliteCommand.Dispose();
									sqliteCommand = null;
								}
							}
							OculusNode oculusNode = new OculusNode(PlatformType.Oculus, 0UL, text12, text3, text4, text5, text7, text8, text9, text10, text11, flag, flag2, true);
							appList.Add(oculusNode);
						}
					}
				}
			}
			catch (Exception ex3)
			{
				return false;
			}
			finally
			{
				sqliteConnection.Close();
				sqliteConnection = null;
			}
			return true;
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x00027AA4 File Offset: 0x00025CA4
		private string GetSha256Checksum(string path)
		{
			string text;
			using (FileStream fileStream = File.OpenRead(path))
			{
				SHA256Managed sha256Managed = new SHA256Managed();
				byte[] array = sha256Managed.ComputeHash(fileStream);
				text = BitConverter.ToString(array).Replace("-", string.Empty).ToLower();
			}
			return text;
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00027B04 File Offset: 0x00025D04
		public bool TryStartOculusService()
		{
			try
			{
				using (ServiceController serviceController = new ServiceController("Oculus VR Runtime Service"))
				{
					bool flag = !serviceController.Status.Equals(ServiceControllerStatus.Stopped) && !serviceController.Status.Equals(ServiceControllerStatus.StopPending);
					if (flag)
					{
						return false;
					}
					TimeSpan timeSpan = TimeSpan.FromMilliseconds(10000.0);
					serviceController.Start();
					serviceController.WaitForStatus(ServiceControllerStatus.Running, timeSpan);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryStartOculusService: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00027BE0 File Offset: 0x00025DE0
		public bool TryStopOculusService()
		{
			try
			{
				using (ServiceController serviceController = new ServiceController("Oculus VR Runtime Service"))
				{
					bool flag = !serviceController.Status.Equals(ServiceControllerStatus.Running) && !serviceController.Status.Equals(ServiceControllerStatus.StartPending);
					if (flag)
					{
						return false;
					}
					TimeSpan timeSpan = TimeSpan.FromMilliseconds(10000.0);
					serviceController.Stop();
					serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeSpan);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryStopOculusService: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00027CBC File Offset: 0x00025EBC
		public bool TryRestartOculusService()
		{
			try
			{
				this.TryStopOculusService();
				this.TryStartOculusService();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryRestartOculusService: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00027D18 File Offset: 0x00025F18
		public bool TryLaunchHome()
		{
			try
			{
				new Process
				{
					StartInfo = 
					{
						WorkingDirectory = this.m_oculusPath,
						FileName = Path.Combine(this.m_oculusPath, "Support\\oculus-client\\OculusClient.exe"),
						Arguments = null,
						UseShellExecute = false,
						CreateNoWindow = false
					}
				}.Start();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryLaunchHome: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00027DC8 File Offset: 0x00025FC8
		public bool IsHomeRunning()
		{
			bool flag = false;
			try
			{
				Process[] processesByName = Process.GetProcessesByName("OculusClient");
				flag = processesByName.Length > 0;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("IsHomeRunning: " + ex.Message);
			}
			return flag;
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x00027E28 File Offset: 0x00026028
		public bool TrySendHomeMinimized()
		{
			try
			{
				Win32.WINDOWPLACEMENT windowplacement = default(Win32.WINDOWPLACEMENT);
				Process[] processesByName = Process.GetProcessesByName("OculusClient");
				foreach (Process process in processesByName)
				{
					bool flag = process.MainWindowHandle == IntPtr.Zero;
					if (!flag)
					{
						IntPtr mainWindowHandle = process.MainWindowHandle;
						Win32.GetWindowPlacement(process.MainWindowHandle, ref windowplacement);
						bool flag2 = windowplacement.showCmd == 2;
						if (flag2)
						{
							Win32.ShowWindow(process.MainWindowHandle, 0);
							return true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TrySendHomeMinimized: " + ex.Message);
			}
			return false;
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x00027F00 File Offset: 0x00026100
		public bool TrySendHomeToTray()
		{
			try
			{
				Win32.WINDOWPLACEMENT windowplacement = default(Win32.WINDOWPLACEMENT);
				Process[] processesByName = Process.GetProcessesByName("OculusClient");
				foreach (Process process in processesByName)
				{
					bool flag = process.MainWindowHandle == IntPtr.Zero;
					if (!flag)
					{
						Win32.GetWindowPlacement(process.MainWindowHandle, ref windowplacement);
						bool flag2 = windowplacement.showCmd == 1;
						if (flag2)
						{
							Win32.ShowWindow(process.MainWindowHandle, 0);
							return true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TrySendHomeToTray: " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00027FD0 File Offset: 0x000261D0
		public bool TryRestoreHome()
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("OculusClient");
				foreach (Process process in processesByName)
				{
					bool flag = process.MainWindowHandle == IntPtr.Zero;
					if (!flag)
					{
						Win32.ShowWindow(process.MainWindowHandle, 9);
						Win32.SetForegroundWindow(process.MainWindowHandle);
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryRestoreHome: " + ex.Message);
				return false;
			}
			return false;
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00028084 File Offset: 0x00026284
		public bool TryCopyAppDatabase()
		{
			try
			{
				bool flag = this.m_appDataPath == null;
				if (flag)
				{
					return false;
				}
				string text = null;
				bool flag2 = !this.TryGetDatabasePath(ref text);
				if (flag2)
				{
					return false;
				}
				string text2 = Path.Combine(this.m_appDataPath, "data.sqlite");
				File.Copy(text, text2, true);
				this.m_databasePath = text2;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryCopyAppDatabase: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x040001DE RID: 478
		private const string OCULUS_SERVICE_NAME = "Oculus VR Runtime Service";

		// Token: 0x040001DF RID: 479
		private const int OCULUS_SERVICE_TIMEOUT = 10000;

		// Token: 0x040001E0 RID: 480
		private string m_oculusPath;

		// Token: 0x040001E1 RID: 481
		private string m_appDataPath;

		// Token: 0x040001E2 RID: 482
		private List<string> m_softwarePathList;

		// Token: 0x040001E3 RID: 483
		private string m_databasePath;

		// Token: 0x040001E4 RID: 484
		private List<FileInfo> m_manifestFileList;

		// Token: 0x040001E5 RID: 485
		private List<DirectoryInfo> m_assetDirectoryList;

		// Token: 0x040001E6 RID: 486
		private Steam m_steam;
	}
}
