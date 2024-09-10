using System;
using System.IO;

namespace OculusTrayTool
{
	// Token: 0x0200003D RID: 61
	public class OculusNode
	{
		// Token: 0x06000512 RID: 1298 RVA: 0x00028120 File Offset: 0x00026320
		public OculusNode(PlatformType _platform, ulong _appId)
		{
			this.Manifest = null;
			this.AssetManifest = null;
			this.CanonicalName = null;
			this.AssetFileName = null;
			this.IsFlat = false;
			this.HasUserAppPlayTime = false;
			this.IsThirdParty = true;
			this.Tag = null;
			this.m_releaseDate = DateTime.MinValue;
			this.Platform = _platform;
			this.AppId = _appId;
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x00028188 File Offset: 0x00026388
		public OculusNode(PlatformType _platform, ulong _appId, string _name)
		{
			this.Manifest = null;
			this.AssetManifest = null;
			this.CanonicalName = null;
			this.AssetFileName = null;
			this.IsFlat = false;
			this.HasUserAppPlayTime = false;
			this.IsThirdParty = true;
			this.Tag = null;
			this.m_releaseDate = DateTime.MinValue;
			this.Platform = _platform;
			this.AppId = _appId;
			this.Name = _name;
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x000281F8 File Offset: 0x000263F8
		public OculusNode(PlatformType _platform, ulong _appId, string _name, string _executable, string _parameters, string _libraryFolder, string _installDir)
		{
			this.Manifest = null;
			this.AssetManifest = null;
			this.CanonicalName = null;
			this.AssetFileName = null;
			this.IsFlat = false;
			this.HasUserAppPlayTime = false;
			this.IsThirdParty = true;
			this.Tag = null;
			this.m_releaseDate = DateTime.MinValue;
			this.Platform = _platform;
			this.AppId = _appId;
			this.Name = _name;
			this.Executable = _executable;
			this.Parameters = _parameters;
			this.LibraryFolder = _libraryFolder;
			this.InstallDir = _installDir;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0002828C File Offset: 0x0002648C
		public OculusNode(PlatformType _platform, ulong _appId, string _manifest, string _assetManifest, string _name, string _executable, string _parameters, string _libraryFolder, string _installDir, string _canonicalName, string _assetFileName, bool _isFlat, bool _hasUserAppPlayTime, bool _isThirdParty)
		{
			this.Manifest = null;
			this.AssetManifest = null;
			this.CanonicalName = null;
			this.AssetFileName = null;
			this.IsFlat = false;
			this.HasUserAppPlayTime = false;
			this.IsThirdParty = true;
			this.Tag = null;
			this.m_releaseDate = DateTime.MinValue;
			this.Platform = _platform;
			this.AppId = _appId;
			this.Manifest = _manifest;
			this.AssetManifest = _assetManifest;
			this.Name = _name;
			this.Executable = _executable;
			this.Parameters = _parameters;
			this.LibraryFolder = _libraryFolder;
			this.InstallDir = _installDir;
			this.CanonicalName = _canonicalName;
			this.AssetFileName = _assetFileName;
			this.IsFlat = _isFlat;
			this.IsThirdParty = _isThirdParty;
			this.HasUserAppPlayTime = _hasUserAppPlayTime;
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x00028358 File Offset: 0x00026558
		public bool TryGetCanonicalName(string path, ref string _canonicalName)
		{
			_canonicalName = null;
			bool flag = string.IsNullOrEmpty(path);
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				_canonicalName = path.Replace(":", "");
				_canonicalName = _canonicalName.Replace(" ", "");
				_canonicalName = _canonicalName.Replace("\\", "_");
				_canonicalName = _canonicalName.Replace("/", "_");
				_canonicalName = _canonicalName.Replace("'", "_");
				_canonicalName = _canonicalName.Replace(".exe", "");
				flag2 = true;
			}
			return flag2;
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x000283F0 File Offset: 0x000265F0
		public string Icon
		{
			get
			{
				return (this.Platform == PlatformType.Oculus) ? "Resources/IconOculus.png" : "Resources/IconSteam.png";
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x00028416 File Offset: 0x00026616
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x00028420 File Offset: 0x00026620
		public PlatformType Platform { get; set; }

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00028429 File Offset: 0x00026629
		// (set) Token: 0x0600051B RID: 1307 RVA: 0x00028433 File Offset: 0x00026633
		public ulong AppId { get; set; }

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x0002843C File Offset: 0x0002663C
		public string AppIdString
		{
			get
			{
				return (decimal.Compare(new decimal(this.AppId), 0m) != 0) ? this.AppId.ToString() : "";
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0002847A File Offset: 0x0002667A
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x00028484 File Offset: 0x00026684
		public string Name { get; set; }

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0002848D File Offset: 0x0002668D
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x00028497 File Offset: 0x00026697
		public string Type { get; set; }

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x000284A0 File Offset: 0x000266A0
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x000284AA File Offset: 0x000266AA
		public string Genre { get; set; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x000284B3 File Offset: 0x000266B3
		// (set) Token: 0x06000524 RID: 1316 RVA: 0x000284BD File Offset: 0x000266BD
		public string Publisher { get; set; }

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x000284C6 File Offset: 0x000266C6
		// (set) Token: 0x06000526 RID: 1318 RVA: 0x000284D0 File Offset: 0x000266D0
		public string Developer { get; set; }

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x000284D9 File Offset: 0x000266D9
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x000284E3 File Offset: 0x000266E3
		public string Executable { get; set; }

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x000284EC File Offset: 0x000266EC
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x000284F6 File Offset: 0x000266F6
		public string Parameters { get; set; }

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x000284FF File Offset: 0x000266FF
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x00028509 File Offset: 0x00026709
		public string OSList { get; set; }

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x00028512 File Offset: 0x00026712
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x0002851C File Offset: 0x0002671C
		public string Url { get; set; }

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x00028528 File Offset: 0x00026728
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x00028540 File Offset: 0x00026740
		public DateTime ReleaseDate
		{
			get
			{
				return this.m_releaseDate;
			}
			set
			{
				this.m_releaseDate = value;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0002854C File Offset: 0x0002674C
		public string ReleaseDateString
		{
			get
			{
				return (DateTime.Compare(this.m_releaseDate, DateTime.MinValue) == 0) ? null : this.m_releaseDate.ToString("MMM d, yyyy");
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x00028583 File Offset: 0x00026783
		// (set) Token: 0x06000533 RID: 1331 RVA: 0x0002858D File Offset: 0x0002678D
		public string Description { get; set; }

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x00028596 File Offset: 0x00026796
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x000285A0 File Offset: 0x000267A0
		public string LibraryFolder { get; set; }

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x000285A9 File Offset: 0x000267A9
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x000285B3 File Offset: 0x000267B3
		public string InstallDir { get; set; }

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x000285BC File Offset: 0x000267BC
		public string ShortCanonicalName
		{
			get
			{
				string text = null;
				bool isThirdParty = this.IsThirdParty;
				if (isThirdParty)
				{
					bool flag = this.TryGetCanonicalName(this.InstallPath, ref text);
					if (flag)
					{
						return text;
					}
				}
				return this.CanonicalName;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x000285FC File Offset: 0x000267FC
		public string FullPath
		{
			get
			{
				bool flag = this.InstallPath == null || this.Executable == null;
				string text;
				if (flag)
				{
					text = null;
				}
				else
				{
					text = Path.Combine(this.InstallPath, this.Executable);
				}
				return text;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0002863C File Offset: 0x0002683C
		public virtual string InstallPath
		{
			get
			{
				bool flag = this.LibraryFolder == null || this.InstallDir == null;
				string text;
				if (flag)
				{
					text = null;
				}
				else
				{
					text = Path.Combine(this.LibraryFolder, this.InstallDir);
				}
				return text;
			}
		}

		// Token: 0x040001EA RID: 490
		public string Manifest;

		// Token: 0x040001EB RID: 491
		public string AssetManifest;

		// Token: 0x040001EC RID: 492
		public string CanonicalName;

		// Token: 0x040001ED RID: 493
		public string AssetFileName;

		// Token: 0x040001EE RID: 494
		public bool IsFlat;

		// Token: 0x040001EF RID: 495
		public bool HasUserAppPlayTime;

		// Token: 0x040001F0 RID: 496
		public bool IsThirdParty;

		// Token: 0x040001F1 RID: 497
		public object Tag;

		// Token: 0x040001F2 RID: 498
		protected DateTime m_releaseDate;
	}
}
