// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.SteamNode
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#nullable disable
namespace OculusTrayTool
{
  public class SteamNode : OculusNode
  {
    public List<SteamScreenshotNode> ScreenshotList;

    public SteamNode(ulong _appId)
      : base(PlatformType.Steam, _appId)
    {
      this.ScreenshotList = (List<SteamScreenshotNode>) null;
      this.ScreenshotList = new List<SteamScreenshotNode>();
    }

    public SteamNode(ulong _appId, string _name)
      : base(PlatformType.Steam, _appId, _name)
    {
      this.ScreenshotList = (List<SteamScreenshotNode>) null;
      this.ScreenshotList = new List<SteamScreenshotNode>();
    }

    public SteamNode(ulong _appId, string _name, string _url)
      : base(PlatformType.Steam, _appId, _name)
    {
      this.ScreenshotList = (List<SteamScreenshotNode>) null;
      this.Url = _url;
      this.ScreenshotList = new List<SteamScreenshotNode>();
    }

    public SteamNode(
      ulong _appId,
      string _name,
      string _type,
      string _publisher,
      string _developer,
      string _executable,
      string _parameters,
      string _oslist,
      string _libraryFolder,
      string _installDir)
      : base(PlatformType.Steam, _appId, _name, _executable, _parameters, _libraryFolder, _installDir)
    {
      this.ScreenshotList = (List<SteamScreenshotNode>) null;
      this.Publisher = _publisher;
      this.Developer = _developer;
      this.Type = _type;
      this.OSList = _oslist;
      this.TryGetCanonicalName(this.FullPath, ref this.CanonicalName);
      this.ScreenshotList = new List<SteamScreenshotNode>();
    }

    public bool TryParseAppDetails(string appDetailsText)
    {
      JObject jobject = JObject.Parse(appDetailsText);
      if (!(bool) jobject[this.AppId.ToString()][(object) "success"])
        return false;
      JToken jtoken1 = jobject[this.AppId.ToString()][(object) "data"];
      this.Name = (string) jtoken1[(object) "name"];
      this.AppId = ulong.Parse((string) jtoken1[(object) "steam_appid"]);
      this.Type = (string) jtoken1[(object) "type"];
      this.Description = (string) jtoken1[(object) "detailed_description"];
      this.Genre = jtoken1[(object) "genres"] != null ? (string) jtoken1[(object) "genres"][(object) 0][(object) "description"] : (string) null;
      this.Developer = jtoken1[(object) "developers"] != null ? (string) jtoken1[(object) "developers"][(object) 0] : (string) null;
      this.Publisher = jtoken1[(object) "publishers"] != null ? (string) jtoken1[(object) "publishers"][(object) 0] : (string) null;
      string s = (string) jtoken1[(object) "release_date"][(object) "date"];
      if (!DateTime.TryParseExact(s, "MMM d, yyyy", (IFormatProvider) null, DateTimeStyles.None, out this.m_releaseDate))
        DateTime.TryParseExact(s, "MMM yyyy", (IFormatProvider) null, DateTimeStyles.None, out this.m_releaseDate);
      if ((bool) jtoken1[(object) "platforms"][(object) "windows"])
        this.OSList = "windows";
      JToken jtoken2 = jtoken1[(object) "screenshots"];
      if (jtoken2 != null)
      {
        try
        {
          foreach (JToken jtoken3 in (IEnumerable<JToken>) jtoken2)
            this.ScreenshotList.Add(new SteamScreenshotNode(this, (string) jtoken3[(object) "path_full"], (string) jtoken3[(object) "path_thumbnail"]));
        }
        finally
        {
          IEnumerator<JToken> enumerator;
          enumerator?.Dispose();
        }
      }
      return true;
    }

    public override string InstallPath
    {
      get
      {
        return this.LibraryFolder == null || this.InstallDir == null ? (string) null : Path.Combine(Path.Combine(this.LibraryFolder, "steamapps\\common"), this.InstallDir);
      }
    }
  }
}
