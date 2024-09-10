using System;
using System.IO;

namespace OculusTrayTool;

public class OculusNode
{
	public string Manifest;

	public string AssetManifest;

	public string CanonicalName;

	public string AssetFileName;

	public bool IsFlat;

	public bool HasUserAppPlayTime;

	public bool IsThirdParty;

	public object Tag;

	protected DateTime m_releaseDate;

	public string Icon => (Platform == PlatformType.Oculus) ? "Resources/IconOculus.png" : "Resources/IconSteam.png";

	public PlatformType Platform { get; set; }

	public ulong AppId { get; set; }

	public string AppIdString => (decimal.Compare(new decimal(AppId), 0m) != 0) ? AppId.ToString() : "";

	public string Name { get; set; }

	public string Type { get; set; }

	public string Genre { get; set; }

	public string Publisher { get; set; }

	public string Developer { get; set; }

	public string Executable { get; set; }

	public string Parameters { get; set; }

	public string OSList { get; set; }

	public string Url { get; set; }

	public DateTime ReleaseDate
	{
		get
		{
			return m_releaseDate;
		}
		set
		{
			m_releaseDate = value;
		}
	}

	public string ReleaseDateString => (DateTime.Compare(m_releaseDate, DateTime.MinValue) == 0) ? null : m_releaseDate.ToString("MMM d, yyyy");

	public string Description { get; set; }

	public string LibraryFolder { get; set; }

	public string InstallDir { get; set; }

	public string ShortCanonicalName
	{
		get
		{
			string _canonicalName = null;
			if (IsThirdParty && TryGetCanonicalName(InstallPath, ref _canonicalName))
			{
				return _canonicalName;
			}
			return CanonicalName;
		}
	}

	public string FullPath
	{
		get
		{
			if (InstallPath == null || Executable == null)
			{
				return null;
			}
			return Path.Combine(InstallPath, Executable);
		}
	}

	public virtual string InstallPath
	{
		get
		{
			if (LibraryFolder == null || InstallDir == null)
			{
				return null;
			}
			return Path.Combine(LibraryFolder, InstallDir);
		}
	}

	public OculusNode(PlatformType _platform, ulong _appId)
	{
		Manifest = null;
		AssetManifest = null;
		CanonicalName = null;
		AssetFileName = null;
		IsFlat = false;
		HasUserAppPlayTime = false;
		IsThirdParty = true;
		Tag = null;
		m_releaseDate = DateTime.MinValue;
		Platform = _platform;
		AppId = _appId;
	}

	public OculusNode(PlatformType _platform, ulong _appId, string _name)
	{
		Manifest = null;
		AssetManifest = null;
		CanonicalName = null;
		AssetFileName = null;
		IsFlat = false;
		HasUserAppPlayTime = false;
		IsThirdParty = true;
		Tag = null;
		m_releaseDate = DateTime.MinValue;
		Platform = _platform;
		AppId = _appId;
		Name = _name;
	}

	public OculusNode(PlatformType _platform, ulong _appId, string _name, string _executable, string _parameters, string _libraryFolder, string _installDir)
	{
		Manifest = null;
		AssetManifest = null;
		CanonicalName = null;
		AssetFileName = null;
		IsFlat = false;
		HasUserAppPlayTime = false;
		IsThirdParty = true;
		Tag = null;
		m_releaseDate = DateTime.MinValue;
		Platform = _platform;
		AppId = _appId;
		Name = _name;
		Executable = _executable;
		Parameters = _parameters;
		LibraryFolder = _libraryFolder;
		InstallDir = _installDir;
	}

	public OculusNode(PlatformType _platform, ulong _appId, string _manifest, string _assetManifest, string _name, string _executable, string _parameters, string _libraryFolder, string _installDir, string _canonicalName, string _assetFileName, bool _isFlat, bool _hasUserAppPlayTime, bool _isThirdParty)
	{
		Manifest = null;
		AssetManifest = null;
		CanonicalName = null;
		AssetFileName = null;
		IsFlat = false;
		HasUserAppPlayTime = false;
		IsThirdParty = true;
		Tag = null;
		m_releaseDate = DateTime.MinValue;
		Platform = _platform;
		AppId = _appId;
		Manifest = _manifest;
		AssetManifest = _assetManifest;
		Name = _name;
		Executable = _executable;
		Parameters = _parameters;
		LibraryFolder = _libraryFolder;
		InstallDir = _installDir;
		CanonicalName = _canonicalName;
		AssetFileName = _assetFileName;
		IsFlat = _isFlat;
		IsThirdParty = _isThirdParty;
		HasUserAppPlayTime = _hasUserAppPlayTime;
	}

	public bool TryGetCanonicalName(string path, ref string _canonicalName)
	{
		_canonicalName = null;
		if (string.IsNullOrEmpty(path))
		{
			return false;
		}
		_canonicalName = path.Replace(":", "");
		_canonicalName = _canonicalName.Replace(" ", "");
		_canonicalName = _canonicalName.Replace("\\", "_");
		_canonicalName = _canonicalName.Replace("/", "_");
		_canonicalName = _canonicalName.Replace("'", "_");
		_canonicalName = _canonicalName.Replace(".exe", "");
		return true;
	}
}
