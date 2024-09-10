// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.OculusNode
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;
using System.IO;

#nullable disable
namespace OculusTrayTool
{
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

    public OculusNode(PlatformType _platform, ulong _appId)
    {
      this.Manifest = (string) null;
      this.AssetManifest = (string) null;
      this.CanonicalName = (string) null;
      this.AssetFileName = (string) null;
      this.IsFlat = false;
      this.HasUserAppPlayTime = false;
      this.IsThirdParty = true;
      this.Tag = (object) null;
      this.m_releaseDate = DateTime.MinValue;
      this.Platform = _platform;
      this.AppId = _appId;
    }

    public OculusNode(PlatformType _platform, ulong _appId, string _name)
    {
      this.Manifest = (string) null;
      this.AssetManifest = (string) null;
      this.CanonicalName = (string) null;
      this.AssetFileName = (string) null;
      this.IsFlat = false;
      this.HasUserAppPlayTime = false;
      this.IsThirdParty = true;
      this.Tag = (object) null;
      this.m_releaseDate = DateTime.MinValue;
      this.Platform = _platform;
      this.AppId = _appId;
      this.Name = _name;
    }

    public OculusNode(
      PlatformType _platform,
      ulong _appId,
      string _name,
      string _executable,
      string _parameters,
      string _libraryFolder,
      string _installDir)
    {
      this.Manifest = (string) null;
      this.AssetManifest = (string) null;
      this.CanonicalName = (string) null;
      this.AssetFileName = (string) null;
      this.IsFlat = false;
      this.HasUserAppPlayTime = false;
      this.IsThirdParty = true;
      this.Tag = (object) null;
      this.m_releaseDate = DateTime.MinValue;
      this.Platform = _platform;
      this.AppId = _appId;
      this.Name = _name;
      this.Executable = _executable;
      this.Parameters = _parameters;
      this.LibraryFolder = _libraryFolder;
      this.InstallDir = _installDir;
    }

    public OculusNode(
      PlatformType _platform,
      ulong _appId,
      string _manifest,
      string _assetManifest,
      string _name,
      string _executable,
      string _parameters,
      string _libraryFolder,
      string _installDir,
      string _canonicalName,
      string _assetFileName,
      bool _isFlat,
      bool _hasUserAppPlayTime,
      bool _isThirdParty)
    {
      this.Manifest = (string) null;
      this.AssetManifest = (string) null;
      this.CanonicalName = (string) null;
      this.AssetFileName = (string) null;
      this.IsFlat = false;
      this.HasUserAppPlayTime = false;
      this.IsThirdParty = true;
      this.Tag = (object) null;
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

    public bool TryGetCanonicalName(string path, ref string _canonicalName)
    {
      _canonicalName = (string) null;
      if (string.IsNullOrEmpty(path))
        return false;
      _canonicalName = path.Replace(":", "");
      _canonicalName = _canonicalName.Replace(" ", "");
      _canonicalName = _canonicalName.Replace("\\", "_");
      _canonicalName = _canonicalName.Replace("/", "_");
      _canonicalName = _canonicalName.Replace("'", "_");
      _canonicalName = _canonicalName.Replace(".exe", "");
      return true;
    }

    public string Icon
    {
      get
      {
        return this.Platform == PlatformType.Oculus ? "Resources/IconOculus.png" : "Resources/IconSteam.png";
      }
    }

    public PlatformType Platform { get; set; }

    public ulong AppId { get; set; }

    public string AppIdString
    {
      get => Decimal.Compare(new Decimal(this.AppId), 0M) != 0 ? this.AppId.ToString() : "";
    }

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
      get => this.m_releaseDate;
      set => this.m_releaseDate = value;
    }

    public string ReleaseDateString
    {
      get
      {
        return DateTime.Compare(this.m_releaseDate, DateTime.MinValue) == 0 ? (string) null : this.m_releaseDate.ToString("MMM d, yyyy");
      }
    }

    public string Description { get; set; }

    public string LibraryFolder { get; set; }

    public string InstallDir { get; set; }

    public string ShortCanonicalName
    {
      get
      {
        string _canonicalName = (string) null;
        return this.IsThirdParty && this.TryGetCanonicalName(this.InstallPath, ref _canonicalName) ? _canonicalName : this.CanonicalName;
      }
    }

    public string FullPath
    {
      get
      {
        return this.InstallPath == null || this.Executable == null ? (string) null : Path.Combine(this.InstallPath, this.Executable);
      }
    }

    public virtual string InstallPath
    {
      get
      {
        return this.LibraryFolder == null || this.InstallDir == null ? (string) null : Path.Combine(this.LibraryFolder, this.InstallDir);
      }
    }
  }
}
