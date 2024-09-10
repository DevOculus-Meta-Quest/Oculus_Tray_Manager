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

namespace OculusTrayTool
{
	// Token: 0x0200005A RID: 90
	public class Steam
	{
		// Token: 0x060008F3 RID: 2291 RVA: 0x00052264 File Offset: 0x00050464
		public Steam(string appDataPath)
		{
			this.VDF_VERSION_OLD = new byte[] { 38, 68, 86, 7 };
			this.VDF_VERSION_NEW = new byte[] { 39, 68, 86, 7 };
			byte[] array = new byte[4];
			array[0] = 1;
			this.VDF_UNIVERSE = array;
			this.LAST_APP = new byte[4];
			this.m_steamPath = null;
			this.m_installPath = null;
			this.m_configPathList = null;
			this.m_logPathList = null;
			this.m_runtimePathList = null;
			this.m_appDataPath = null;
			this.m_libraryPathList = null;
			this.m_libraryPathDictionary = null;
			this.m_appDataPath = appDataPath;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00052304 File Offset: 0x00050504
		public bool TryRefresh()
		{
			bool flag = !this.TryGetSteamPath(ref this.m_steamPath);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				bool flag3 = !this.TryGetInstallPath(ref this.m_installPath);
				if (flag3)
				{
					flag2 = false;
				}
				else
				{
					bool flag4 = !this.TryGetOpenVRPathsEntry("config", ref this.m_configPathList);
					if (flag4)
					{
						this.m_configPathList.Add(Path.Combine(this.m_installPath, "config"));
					}
					bool flag5 = !this.TryGetOpenVRPathsEntry("log", ref this.m_logPathList);
					if (flag5)
					{
						this.m_logPathList.Add(Path.Combine(this.m_installPath, "logs"));
					}
					bool flag6 = !this.TryGetOpenVRPathsEntry("runtime", ref this.m_runtimePathList);
					if (flag6)
					{
						this.m_runtimePathList.Add(Path.Combine(this.m_installPath, "steamapps\\common\\SteamVR"));
					}
					bool flag7 = !this.TryGetLibraryPathList(ref this.m_libraryPathList);
					if (flag7)
					{
						flag2 = false;
					}
					else
					{
						bool flag8 = !this.TryGetLibraryPathDictionary(ref this.m_libraryPathDictionary);
						flag2 = !flag8;
					}
				}
			}
			return flag2;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00052428 File Offset: 0x00050628
		private bool TryGetSteamPath(ref string steamPath)
		{
			steamPath = null;
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam", false);
				bool flag = registryKey == null;
				if (flag)
				{
					return false;
				}
				steamPath = Conversions.ToString(registryKey.GetValue("SteamPath"));
				bool flag2 = string.IsNullOrEmpty(steamPath);
				if (flag2)
				{
					return false;
				}
				steamPath = steamPath.Replace("/", "\\");
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetSteamPath: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x000524D0 File Offset: 0x000506D0
		private bool TryGetInstallPath(ref string installPath)
		{
			installPath = null;
			try
			{
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
				RegistryKey registryKey2 = registryKey.OpenSubKey("Software\\Valve\\Steam", false);
				bool flag = registryKey2 == null;
				if (flag)
				{
					return false;
				}
				installPath = Conversions.ToString(registryKey2.GetValue("InstallPath"));
				bool flag2 = string.IsNullOrEmpty(installPath);
				if (flag2)
				{
					return false;
				}
				installPath = installPath.Replace("/", "\\");
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetInstallPath: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00052584 File Offset: 0x00050784
		public bool TryGetLibraryPathList(ref List<string> libraryFolderList)
		{
			libraryFolderList = new List<string>();
			try
			{
				libraryFolderList.Add(this.m_steamPath);
				string text = Path.Combine(this.m_steamPath, "steamapps\\libraryfolders.vdf");
				StreamReader streamReader = new StreamReader(text);
				while (streamReader.Peek() != -1)
				{
					string text2 = streamReader.ReadLine();
					bool flag = text2.ToLower().Contains("\"path\"");
					if (flag)
					{
						text2 = text2.Replace("\"path\"", "");
						text2 = text2.Replace("\"", "");
						text2 = text2.Replace("\\\\", "\\");
						libraryFolderList.Add(text2.Trim());
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetLibraryPathList: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00052678 File Offset: 0x00050878
		public bool TryGetLibraryPathDictionary(ref Dictionary<ulong, string> libraryFolderDictionary)
		{
			libraryFolderDictionary = new Dictionary<ulong, string>();
			try
			{
				try
				{
					foreach (string text in this.m_libraryPathList)
					{
						List<ulong> list = null;
						this.TryGetAppIdList(text, ref list);
						try
						{
							foreach (ulong num in list)
							{
								bool flag = !libraryFolderDictionary.ContainsKey(num);
								if (flag)
								{
									libraryFolderDictionary.Add(num, text);
								}
							}
						}
						finally
						{
							List<ulong>.Enumerator enumerator2;
							((IDisposable)enumerator2).Dispose();
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
				Log.WriteToLog("TryGetLibraryPathDictionary: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0005277C File Offset: 0x0005097C
		public bool TryDisableSafeMode()
		{
			try
			{
				bool flag = this.m_configPathList.Count == 0;
				if (flag)
				{
					return false;
				}
				string text = Path.Combine(this.m_configPathList[0], "steamvr.vrsettings");
				bool flag2 = !File.Exists(text);
				if (flag2)
				{
					return false;
				}
				string text2 = File.ReadAllText(text);
				JObject jobject = JObject.Parse(text2);
				JToken jtoken = jobject["steamvr"];
				bool flag3 = jtoken != null;
				if (flag3)
				{
					jtoken["enableSafeMode"] = false;
				}
				text2 = jobject.ToString();
				File.WriteAllText(text, text2);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryDisableSafeMode: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00052860 File Offset: 0x00050A60
		public bool TryGetAppIdList(string libraryFolder, ref List<ulong> appIdList)
		{
			appIdList = new List<ulong>();
			try
			{
				JObject jobject = new JObject();
				ulong num = 0UL;
				bool flag = this.TryGetSteamACFJson(libraryFolder, ref jobject);
				if (flag)
				{
					bool flag2 = jobject["acf"] == null;
					if (flag2)
					{
						return false;
					}
					try
					{
						foreach (JToken jtoken in ((IEnumerable<JToken>)jobject["acf"]))
						{
							bool flag3 = jtoken["AppState"] == null;
							if (!flag3)
							{
								JToken jtoken2 = jtoken["AppState"];
								string text = (string)jtoken2["appid"];
								bool flag4 = !ulong.TryParse(text, out num);
								if (!flag4)
								{
									appIdList.Add(num);
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
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetAppIdList: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x0005298C File Offset: 0x00050B8C
		public bool TryCopyACFFiles(string destinationPath)
		{
			try
			{
				List<string> list = null;
				bool flag = !this.TryGetLibraryPathList(ref list);
				if (flag)
				{
					return false;
				}
				try
				{
					foreach (string text in list)
					{
						string text2 = Path.Combine(text, "steamapps");
						string[] files = Directory.GetFiles(text2, "*.acf");
						foreach (string text3 in files)
						{
							File.Copy(text3, Path.Combine(destinationPath, Path.GetFileName(text3)), true);
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
				Log.WriteToLog("TryCopyACFFiles: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x00052A8C File Offset: 0x00050C8C
		public bool TryCheckACFFiles(string acfPath, ref List<string> acfFileNameList)
		{
			bool flag = false;
			acfFileNameList = new List<string>();
			try
			{
				string[] files = Directory.GetFiles(acfPath, "*.acf");
				JObject jobject = new JObject();
				ACFReader acfreader = new ACFReader(jobject);
				foreach (string text in files)
				{
					bool flag2 = !acfreader.TryProcessFile(text);
					if (flag2)
					{
						acfFileNameList.Add(Path.GetFileName(text));
					}
				}
				flag = acfFileNameList.Count > 0;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryCheckACFFiles: " + ex.Message);
				return false;
			}
			return flag;
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x00052B54 File Offset: 0x00050D54
		public bool TryGetSteamACFJson(ref JObject acfJson)
		{
			acfJson = new JObject();
			try
			{
				try
				{
					foreach (string text in this.m_libraryPathList)
					{
						this.TryGetSteamACFJson(text, ref acfJson);
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
				Log.WriteToLog("TryGetSteamACFJson: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008FE RID: 2302 RVA: 0x00052BF4 File Offset: 0x00050DF4
		public bool TryGetSteamACFJson(string libraryFolder, ref JObject acfJson)
		{
			try
			{
				string text = Path.Combine(libraryFolder, "steamapps");
				bool flag = !Directory.Exists(text);
				if (flag)
				{
					return false;
				}
				ACFReader acfreader = new ACFReader(acfJson);
				bool flag2 = !acfreader.TryProcessFolder(text);
				if (flag2)
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetSteamACFJson: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x00052C80 File Offset: 0x00050E80
		public bool TryGetOpenVRPathsEntry(string name, ref List<string> valueList)
		{
			bool flag = false;
			valueList = new List<string>();
			try
			{
				string text = null;
				bool flag2 = !this.TryGetOpenVRPathsFileName(ref text);
				if (flag2)
				{
					return false;
				}
				string text2 = File.ReadAllText(text);
				JObject jobject = JObject.Parse(text2);
				JToken jtoken = jobject.SelectToken(name);
				try
				{
					foreach (JToken jtoken2 in jtoken.Values())
					{
						valueList.Add(jtoken2.ToString());
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
				flag = valueList.Count > 0;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetOpenVRPathsEntry: " + ex.Message);
				return false;
			}
			return flag;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x00052D6C File Offset: 0x00050F6C
		public bool TryGetVRManifest(ref List<SteamNode> steamList)
		{
			steamList = new List<SteamNode>();
			string text = Path.Combine(this.m_installPath, "config\\steamapps.vrmanifest");
			bool flag = !File.Exists(text);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				try
				{
					string text2 = File.ReadAllText(text);
					JObject jobject = JObject.Parse(text2);
					JToken jtoken = jobject.SelectToken("applications");
					try
					{
						foreach (JToken jtoken2 in ((IEnumerable<JToken>)jtoken))
						{
							ulong num = 0UL;
							string text3 = jtoken2["app_key"].ToString();
							string text4 = jtoken2["strings"]["en_us"]["name"].ToString();
							string text5 = jtoken2["url"].ToString();
							text3 = text3.Replace("steam.app.", "");
							ulong.TryParse(text3, out num);
							SteamNode steamNode = new SteamNode(num, text4, text5);
							steamList.Add(steamNode);
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
				}
				catch (Exception ex)
				{
					Log.WriteToLog("TryGetVRManifest: " + ex.Message);
					return false;
				}
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00052ED0 File Offset: 0x000510D0
		public void TryGetAppDetails(List<SteamNode> steamList)
		{
			try
			{
				try
				{
					foreach (SteamNode steamNode in steamList)
					{
						string tempPath = Path.GetTempPath();
						string text = Path.Combine(tempPath, string.Format("{0}.json", steamNode.AppId));
						bool flag = !this.TryDownloadAppDetails(steamNode.AppId, text);
						if (!flag)
						{
							string text2 = File.ReadAllText(text);
							bool flag2 = !steamNode.TryParseAppDetails(text2);
							if (flag2)
							{
							}
						}
					}
				}
				finally
				{
					List<SteamNode>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetAppDetails: " + ex.Message);
			}
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00052FAC File Offset: 0x000511AC
		public bool TryGetAppInfo(List<SteamNode> steamList, bool windowsOnly, bool vrOnly)
		{
			try
			{
				Dictionary<ulong, SteamNode> dictionary = null;
				List<SteamNode> list = null;
				bool flag = !this.TryGetAppInfo(windowsOnly, vrOnly, ref dictionary, ref list);
				if (flag)
				{
					return false;
				}
				try
				{
					foreach (SteamNode steamNode in steamList)
					{
						SteamNode steamNode2 = null;
						bool flag2 = dictionary.TryGetValue(steamNode.AppId, out steamNode2);
						if (flag2)
						{
							steamNode.Type = steamNode2.Type;
							steamNode.Publisher = steamNode2.Publisher;
							steamNode.Developer = steamNode2.Developer;
							steamNode.Executable = steamNode2.Executable;
							steamNode.Parameters = steamNode2.Parameters;
							steamNode.OSList = steamNode2.OSList;
							steamNode.LibraryFolder = steamNode2.LibraryFolder;
							steamNode.InstallDir = steamNode2.InstallDir;
							steamNode.CanonicalName = steamNode2.CanonicalName;
						}
					}
				}
				finally
				{
					List<SteamNode>.Enumerator enumerator;
					((IDisposable)enumerator).Dispose();
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetAppInfo: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00053104 File Offset: 0x00051304
		private bool TryGetAppLaunchInfo(JToken appInfoLaunchJToken, bool windowsOnly, bool vrOnly, ref string oslist, ref string executable, ref string arguments, ref string type)
		{
			bool flag = false;
			try
			{
				try
				{
					foreach (JToken jtoken in appInfoLaunchJToken.Values())
					{
						JToken jtoken2 = jtoken["config"];
						bool flag2 = jtoken2 != null;
						if (flag2)
						{
							oslist = (string)jtoken2["oslist"];
						}
						executable = (string)jtoken["executable"];
						arguments = (string)jtoken["arguments"];
						type = (string)jtoken["type"];
						bool flag3 = !windowsOnly || Operators.CompareString(oslist, "windows", false) == 0;
						bool flag4 = !vrOnly || Operators.CompareString(type, "vr", false) == 0 || Operators.CompareString(type, "othervr", false) == 0;
						bool flag5 = jtoken2 != null;
						if (flag5)
						{
							oslist = (string)jtoken2["oslist"];
						}
						bool flag6 = flag3 && flag4 && executable != null;
						if (flag6)
						{
							flag = true;
							break;
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
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetAppLaunchInfo: " + ex.Message);
				return false;
			}
			return flag;
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00053298 File Offset: 0x00051498
		public bool TryGetAppInfo(bool windowsOnly, bool vrOnly, ref Dictionary<ulong, SteamNode> appInfoDictionary, ref List<SteamNode> appInfoList)
		{
			appInfoDictionary = new Dictionary<ulong, SteamNode>();
			appInfoList = new List<SteamNode>();
			try
			{
				JObject jobject = null;
				bool flag = !this.TryReadAppInfo(ref jobject);
				if (flag)
				{
					return false;
				}
				JObject jobject2 = null;
				bool flag2 = !this.TryGetSteamACFJson(ref jobject2);
				if (flag2)
				{
					return false;
				}
				try
				{
					foreach (JToken jtoken in ((IEnumerable<JToken>)jobject2["acf"]))
					{
						bool flag3 = jtoken["AppState"] == null;
						if (!flag3)
						{
							JToken jtoken2 = jtoken["AppState"];
							ulong num = 0UL;
							string text = (string)jtoken2["appid"];
							string text2 = (string)jtoken2["installdir"];
							bool flag4 = !ulong.TryParse(text, out num);
							if (!flag4)
							{
								try
								{
									foreach (JToken jtoken3 in ((IEnumerable<JToken>)jobject["apps"]))
									{
										JToken jtoken4 = jtoken3["appinfo"];
										bool flag5 = jtoken4 == null;
										if (!flag5)
										{
											ulong num2 = (ulong)jtoken4["appid"];
											bool flag6 = num != num2;
											if (!flag6)
											{
												string text3 = null;
												string text4 = null;
												string text5 = null;
												string text6 = null;
												string text7 = null;
												JToken jtoken5 = jtoken4["common"];
												JToken jtoken6 = jtoken4["extended"];
												JToken jtoken7 = jtoken4["config"];
												bool flag7 = jtoken5 == null || jtoken6 == null;
												if (!flag7)
												{
													string text8 = (string)jtoken5["name"];
													text3 = (string)jtoken5["type"];
													string text9 = (string)jtoken6["publisher"];
													string text10 = (string)jtoken6["developer"];
													bool flag8 = jtoken7 == null;
													if (!flag8)
													{
														string text11 = (string)jtoken7["installdir"];
														JToken jtoken8 = jtoken7["launch"];
														bool flag9 = jtoken8 == null;
														if (!flag9)
														{
															bool flag10 = !this.TryGetAppLaunchInfo(jtoken8, windowsOnly, vrOnly, ref text6, ref text4, ref text5, ref text3);
															if (flag10)
															{
																bool flag11 = !this.TryGetAppLaunchInfo(jtoken8, windowsOnly, false, ref text6, ref text4, ref text5, ref text3);
																if (flag11)
																{
																	bool flag12 = !this.TryGetAppLaunchInfo(jtoken8, false, false, ref text6, ref text4, ref text5, ref text3);
																	if (flag12)
																	{
																		continue;
																	}
																}
															}
															this.m_libraryPathDictionary.TryGetValue(num, out text7);
															SteamNode steamNode = new SteamNode(num, text8, text3, text9, text10, text4, text5, text6, text7, text2);
															bool flag13 = appInfoDictionary.ContainsKey(num);
															if (!flag13)
															{
																appInfoDictionary.Add(num, steamNode);
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
									IEnumerator<JToken> enumerator2;
									if (enumerator2 != null)
									{
										enumerator2.Dispose();
									}
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
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetAppInfo: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00053634 File Offset: 0x00051834
		public bool TrySaveAppInfoJson(string fileName)
		{
			try
			{
				JObject jobject = null;
				bool flag = !this.TryReadAppInfo(ref jobject);
				if (flag)
				{
					return false;
				}
				string text = jobject.ToString();
				File.WriteAllText(fileName, text);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TrySaveAppInfoJson: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x000536AC File Offset: 0x000518AC
		public bool TryReadAppInfo(ref JObject appInfoJObject)
		{
			appInfoJObject = new JObject();
			try
			{
				JArray jarray = new JArray();
				appInfoJObject["apps"] = jarray;
				string text = Path.Combine(this.m_steamPath, "appcache\\appinfo.vdf");
				using (FileStream fileStream = File.OpenRead(text))
				{
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						byte[] array = binaryReader.ReadBytes(4);
						byte[] array2 = binaryReader.ReadBytes(4);
						bool flag = this.StartsWith(array, this.VDF_VERSION_OLD);
						bool flag2 = this.StartsWith(array, this.VDF_VERSION_NEW);
						bool flag3 = !flag && !flag2;
						if (flag3)
						{
							return false;
						}
						bool flag4 = !this.StartsWith(array2, this.VDF_UNIVERSE);
						if (flag4)
						{
							return false;
						}
						for (;;)
						{
							int num = this.ReadInt32(binaryReader);
							bool flag5 = num == 0;
							if (flag5)
							{
								break;
							}
							JObject jobject = new JObject();
							jobject["size"] = this.ReadInt32(binaryReader);
							jobject["state"] = this.ReadInt32(binaryReader);
							jobject["lastupdate"] = this.ReadInt32(binaryReader);
							jobject["accesstoken"] = this.ReadInt64(binaryReader);
							jobject["checksum"] = this.ReadString(binaryReader, 20);
							jobject["changenumber"] = this.ReadInt32(binaryReader);
							bool flag6 = flag2;
							if (flag6)
							{
								this.ReadSubSection(binaryReader, jobject, false);
							}
							else
							{
								for (;;)
								{
									byte b = binaryReader.ReadByte();
									bool flag7 = b == 0;
									if (flag7)
									{
										break;
									}
									binaryReader.ReadByte();
									string text2 = this.ReadString(binaryReader);
									this.ReadSubSection(binaryReader, jobject, true);
								}
							}
							jarray.Add(jobject);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryReadAppInfo: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00053930 File Offset: 0x00051B30
		private bool IsNumber(string value)
		{
			bool flag = string.IsNullOrEmpty(value);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				foreach (char c in value)
				{
					bool flag3 = !char.IsNumber(c);
					if (flag3)
					{
						return false;
					}
				}
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0005398C File Offset: 0x00051B8C
		private bool StartsWith(byte[] thisBytes, byte[] thatBytes)
		{
			bool flag = thatBytes.Length > thisBytes.Length;
			checked
			{
				bool flag2;
				if (flag)
				{
					flag2 = false;
				}
				else
				{
					for (int i = 0; i < thatBytes.Length; i++)
					{
						bool flag3 = thisBytes[i] != thatBytes[i];
						if (flag3)
						{
							return false;
						}
					}
					flag2 = true;
				}
				return flag2;
			}
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x000539DC File Offset: 0x00051BDC
		private void ReadSubSection(BinaryReader binaryReader, JToken jToken, bool isRootSection)
		{
			for (;;)
			{
				Steam.ValueType valueType = (Steam.ValueType)binaryReader.ReadByte();
				bool flag = valueType == Steam.ValueType.EndSection;
				if (flag)
				{
					break;
				}
				string text = this.ReadString(binaryReader);
				this.TryReadValue(binaryReader, valueType, text, jToken);
			}
			if (isRootSection)
			{
				binaryReader.ReadByte();
			}
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00053A28 File Offset: 0x00051C28
		private bool TryReadValue(BinaryReader binaryReader, Steam.ValueType valueType, string key, JToken jToken)
		{
			bool flag;
			switch (valueType)
			{
			case Steam.ValueType.Section:
			{
				JObject jobject = new JObject();
				jToken[key] = jobject;
				this.ReadSubSection(binaryReader, jobject, false);
				flag = false;
				break;
			}
			case Steam.ValueType.String:
				jToken[key] = this.ReadString(binaryReader);
				flag = true;
				break;
			case Steam.ValueType.Int32:
				jToken[key] = this.ReadInt32(binaryReader);
				flag = true;
				break;
			default:
				if (valueType != Steam.ValueType.Int64)
				{
					flag = false;
				}
				else
				{
					jToken[key] = this.ReadInt64(binaryReader);
					flag = true;
				}
				break;
			}
			return flag;
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00053AC8 File Offset: 0x00051CC8
		private string ReadString(BinaryReader binaryReader)
		{
			List<byte> list = new List<byte>();
			for (byte b = binaryReader.ReadByte(); b > 0; b = binaryReader.ReadByte())
			{
				list.Add(b);
			}
			return Encoding.UTF8.GetString(list.ToArray());
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00053B14 File Offset: 0x00051D14
		private string ReadString(BinaryReader binaryReader, int charCount)
		{
			byte[] array = binaryReader.ReadBytes(charCount);
			return BitConverter.ToString(array).Replace("-", "");
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x00053B44 File Offset: 0x00051D44
		private int ReadInt32(BinaryReader binaryReader)
		{
			byte[] array = binaryReader.ReadBytes(4);
			return BitConverter.ToInt32(array, 0);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00053B68 File Offset: 0x00051D68
		private long ReadInt64(BinaryReader binaryReader)
		{
			byte[] array = binaryReader.ReadBytes(8);
			return BitConverter.ToInt64(array, 0);
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00053B8C File Offset: 0x00051D8C
		public bool TryDownloadAppHeader(ulong appId, object tag, DownloadProgressChangedEventHandler downloadProgressChanged, EventHandler<DataDownloadEventArgs> downloadComplete)
		{
			string text = string.Format("https://steamcdn-a.akamaihd.net/steam/apps/{0}/header.jpg", appId);
			return Steam.TryDownloadFile(text, RuntimeHelpers.GetObjectValue(tag), downloadProgressChanged, downloadComplete);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00053BC0 File Offset: 0x00051DC0
		public static bool TryDownloadFile(string url, object tag, DownloadProgressChangedEventHandler downloadProgressChanged, EventHandler<DataDownloadEventArgs> downloadComplete)
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
					webClient.DownloadProgressChanged += downloadProgressChanged;
					webClient.DownloadDataCompleted += delegate(object sender, DownloadDataCompletedEventArgs e)
					{
						bool flag2 = e.Result == null || e.Error != null || e.Cancelled;
						if (!flag2)
						{
							object[] array = (object[])e.UserState;
							Uri uri2 = (Uri)array[0];
							object objectValue2 = RuntimeHelpers.GetObjectValue(array[1]);
							object objectValue3 = RuntimeHelpers.GetObjectValue(array[2]);
							string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
							string text2 = Path.Combine(text, Path.GetFileName(uri2.LocalPath));
							bool flag3 = !Directory.Exists(text);
							if (flag3)
							{
								Directory.CreateDirectory(text);
							}
							bool flag4 = File.Exists(text2);
							if (flag4)
							{
								File.Delete(text2);
							}
							File.WriteAllBytes(text2, e.Result);
							bool flag5 = downloadComplete != null;
							if (flag5)
							{
								downloadComplete(null, new DataDownloadEventArgs(text2, RuntimeHelpers.GetObjectValue(objectValue3)));
							}
							object obj2 = objectValue2;
							ObjectFlowControl.CheckForSyncLockOnValueType(obj2);
							lock (obj2)
							{
								Monitor.Pulse(RuntimeHelpers.GetObjectValue(objectValue2));
							}
						}
					};
					Uri uri = new Uri(url);
					object objectValue = RuntimeHelpers.GetObjectValue(new object());
					object obj = objectValue;
					ObjectFlowControl.CheckForSyncLockOnValueType(obj);
					lock (obj)
					{
						webClient.DownloadDataAsync(uri, new object[] { uri, objectValue, tag });
						Monitor.Wait(RuntimeHelpers.GetObjectValue(objectValue));
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryDownloadFile: " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x00053CE0 File Offset: 0x00051EE0
		public static bool TryDownloadFileAsync(string url, object tag, DownloadProgressChangedEventHandler downloadProgressChanged, EventHandler<DataDownloadEventArgs> downloadComplete)
		{
			try
			{
				Uri uri = new Uri(url);
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
					webClient.DownloadProgressChanged += downloadProgressChanged;
					webClient.DownloadDataCompleted += delegate(object sender, DownloadDataCompletedEventArgs e)
					{
						bool flag = e.Result == null || e.Error != null || e.Cancelled;
						if (!flag)
						{
							string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
							string text2 = Path.Combine(text, Path.GetFileName(url));
							bool flag2 = !Directory.Exists(text);
							if (flag2)
							{
								Directory.CreateDirectory(text);
								Log.WriteToLog("Created temporary directory '" + text + "'");
							}
							bool flag3 = File.Exists(text2);
							if (flag3)
							{
								File.Delete(text2);
							}
							File.WriteAllBytes(text2, e.Result);
							bool flag4 = downloadComplete != null;
							if (flag4)
							{
								downloadComplete(null, new DataDownloadEventArgs(text2, RuntimeHelpers.GetObjectValue(tag)));
							}
						}
					};
					webClient.DownloadDataAsync(uri, RuntimeHelpers.GetObjectValue(tag));
				}
				return true;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryDownloadFileAsync: " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00053DBC File Offset: 0x00051FBC
		public static bool TryDownloadAppList(object tag, EventHandler<DataDownloadEventArgs> downloadComplete)
		{
			try
			{
				Uri uri = new Uri("https://api.steampowered.com/ISteamApps/GetAppList/v2/");
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
					webClient.DownloadDataCompleted += delegate(object sender, DownloadDataCompletedEventArgs e)
					{
						bool flag = e.Result == null || e.Error != null || e.Cancelled;
						if (!flag)
						{
							string text = Path.Combine(Path.GetTempPath(), "applist.json");
							bool flag2 = File.Exists(text);
							if (flag2)
							{
								File.Delete(text);
							}
							File.WriteAllBytes(text, e.Result);
							bool flag3 = downloadComplete != null;
							if (flag3)
							{
								downloadComplete(null, new DataDownloadEventArgs(text, RuntimeHelpers.GetObjectValue(tag)));
							}
						}
					};
					webClient.DownloadDataAsync(uri);
				}
				return true;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryDownloadAppList: " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00053E7C File Offset: 0x0005207C
		public bool TryDownloadAppDetails(ulong appId, string fileName)
		{
			try
			{
				Uri uri = new Uri(string.Format("https://store.steampowered.com/api/appdetails?appids={0}&cc=us", appId));
				using (WebClient webClient = new WebClient())
				{
					webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
					byte[] array = webClient.DownloadData(uri);
					File.WriteAllBytes(fileName, array);
				}
				return true;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryDownloadAppDetails: " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00053F28 File Offset: 0x00052128
		public bool TryLaunchApp(ulong appId, string parameters)
		{
			try
			{
				new Process
				{
					StartInfo = 
					{
						WorkingDirectory = this.m_steamPath,
						FileName = Path.Combine(this.m_steamPath, "Steam.exe"),
						Arguments = string.Format("-applaunch {0} {1}", appId, parameters),
						UseShellExecute = false,
						CreateNoWindow = false
					}
				}.Start();
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryLaunchApp: " + ex.Message);
				return false;
			}
			return true;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00053FE8 File Offset: 0x000521E8
		public bool TryInstallDriver(string driverPath, bool removedriver)
		{
			bool flag = false;
			try
			{
				bool flag2 = this.m_installPath == null;
				if (flag2)
				{
					return false;
				}
				string text = Path.Combine(this.m_installPath, "steamapps\\common\\SteamVR\\bin\\win64\\vrpathreg.exe");
				bool flag3 = !File.Exists(text);
				if (flag3)
				{
					return false;
				}
				Process process = new Process();
				process.StartInfo.WorkingDirectory = this.m_installPath;
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
				Log.WriteToLog("TryInstallDriver: " + ex.Message);
				return false;
			}
			return flag;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x000540F8 File Offset: 0x000522F8
		public bool TryGetOpenVRPathsFileName(ref string openvrPathsFileName)
		{
			bool flag = false;
			openvrPathsFileName = null;
			try
			{
				string environmentVariable = Environment.GetEnvironmentVariable("LocalAppData");
				string text = Path.Combine(environmentVariable, "openvr");
				openvrPathsFileName = Path.Combine(text, "openvrpaths.vrpath");
				flag = File.Exists(openvrPathsFileName);
			}
			catch (Exception ex)
			{
				Log.WriteToLog("TryGetOpenVRPathsFileName: " + ex.Message);
				return false;
			}
			return flag;
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x0005417C File Offset: 0x0005237C
		public bool TryUninstall(string driverName)
		{
			bool flag = false;
			try
			{
				List<string> list = null;
				bool flag2 = !this.TryGetOpenVRPathsEntry("external_drivers", ref list);
				if (flag2)
				{
					return false;
				}
				try
				{
					foreach (string text in list)
					{
						bool flag3 = this.TryInstallDriver(text, true);
						if (flag3)
						{
							flag = true;
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
				Log.WriteToLog("TryUninstall: " + ex.Message);
				return false;
			}
			return flag;
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x0005423C File Offset: 0x0005243C
		public bool IsDriverInstalled(string driverName)
		{
			try
			{
				List<string> list = null;
				bool flag = !this.TryGetOpenVRPathsEntry("external_drivers", ref list);
				if (flag)
				{
					return false;
				}
				try
				{
					foreach (string text in list)
					{
						bool flag2 = text.Contains(driverName);
						if (flag2)
						{
							return true;
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
				Log.WriteToLog("IsDriverInstalled: " + ex.Message);
				return false;
			}
			return false;
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x000542F8 File Offset: 0x000524F8
		public bool TryLaunchSteam()
		{
			return this.TryLaunchApp(250820UL, "");
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x0600091A RID: 2330 RVA: 0x0005431C File Offset: 0x0005251C
		public string SteamPath
		{
			get
			{
				return this.m_steamPath;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x00054334 File Offset: 0x00052534
		public string InstallPath
		{
			get
			{
				return this.m_installPath;
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x0600091C RID: 2332 RVA: 0x0005434C File Offset: 0x0005254C
		public List<string> ConfigPathList
		{
			get
			{
				return this.m_configPathList;
			}
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x00054364 File Offset: 0x00052564
		public List<string> LogPathList
		{
			get
			{
				return this.m_logPathList;
			}
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x0005437C File Offset: 0x0005257C
		public List<string> RuntimePathList
		{
			get
			{
				return this.m_runtimePathList;
			}
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x00054394 File Offset: 0x00052594
		public string AppDataPath
		{
			get
			{
				return this.m_appDataPath;
			}
		}

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06000920 RID: 2336 RVA: 0x000543AC File Offset: 0x000525AC
		public List<string> LibraryFolderList
		{
			get
			{
				return this.m_libraryPathList;
			}
		}

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x000543C4 File Offset: 0x000525C4
		public Dictionary<ulong, string> LibraryFolderDictionary
		{
			get
			{
				return this.m_libraryPathDictionary;
			}
		}

		// Token: 0x040003D1 RID: 977
		private const string DEFAULT_USER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

		// Token: 0x040003D2 RID: 978
		private const string STEAMAPI_GETAPPLIST_URL = "https://api.steampowered.com/ISteamApps/GetAppList/v2/";

		// Token: 0x040003D3 RID: 979
		private const string STEAMAPI_GETAPPDETAILS_URL = "https://store.steampowered.com/api/appdetails?appids={0}&cc=us";

		// Token: 0x040003D4 RID: 980
		private const string STEAM_HEADER_URL = "https://steamcdn-a.akamaihd.net/steam/apps/{0}/header.jpg";

		// Token: 0x040003D5 RID: 981
		private byte[] VDF_VERSION_OLD;

		// Token: 0x040003D6 RID: 982
		private byte[] VDF_VERSION_NEW;

		// Token: 0x040003D7 RID: 983
		private byte[] VDF_UNIVERSE;

		// Token: 0x040003D8 RID: 984
		private byte[] LAST_APP;

		// Token: 0x040003D9 RID: 985
		private string m_steamPath;

		// Token: 0x040003DA RID: 986
		private string m_installPath;

		// Token: 0x040003DB RID: 987
		private List<string> m_configPathList;

		// Token: 0x040003DC RID: 988
		private List<string> m_logPathList;

		// Token: 0x040003DD RID: 989
		private List<string> m_runtimePathList;

		// Token: 0x040003DE RID: 990
		private string m_appDataPath;

		// Token: 0x040003DF RID: 991
		private List<string> m_libraryPathList;

		// Token: 0x040003E0 RID: 992
		private Dictionary<ulong, string> m_libraryPathDictionary;

		// Token: 0x02000098 RID: 152
		private enum ValueType
		{
			// Token: 0x0400052A RID: 1322
			Section,
			// Token: 0x0400052B RID: 1323
			String,
			// Token: 0x0400052C RID: 1324
			Int32,
			// Token: 0x0400052D RID: 1325
			Int64 = 7,
			// Token: 0x0400052E RID: 1326
			EndSection
		}
	}
}
