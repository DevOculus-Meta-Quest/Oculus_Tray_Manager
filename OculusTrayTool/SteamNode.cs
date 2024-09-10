using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool;

public class SteamNode : OculusNode
{
	public List<SteamScreenshotNode> ScreenshotList;

	public override string InstallPath
	{
		get
		{
			if (base.LibraryFolder == null || base.InstallDir == null)
			{
				return null;
			}
			string path = Path.Combine(base.LibraryFolder, "steamapps\\common");
			return Path.Combine(path, base.InstallDir);
		}
	}

	public SteamNode(ulong _appId)
		: base(PlatformType.Steam, _appId)
	{
		ScreenshotList = null;
		ScreenshotList = new List<SteamScreenshotNode>();
	}

	public SteamNode(ulong _appId, string _name)
		: base(PlatformType.Steam, _appId, _name)
	{
		ScreenshotList = null;
		ScreenshotList = new List<SteamScreenshotNode>();
	}

	public SteamNode(ulong _appId, string _name, string _url)
		: base(PlatformType.Steam, _appId, _name)
	{
		ScreenshotList = null;
		base.Url = _url;
		ScreenshotList = new List<SteamScreenshotNode>();
	}

	public SteamNode(ulong _appId, string _name, string _type, string _publisher, string _developer, string _executable, string _parameters, string _oslist, string _libraryFolder, string _installDir)
		: base(PlatformType.Steam, _appId, _name, _executable, _parameters, _libraryFolder, _installDir)
	{
		ScreenshotList = null;
		base.Publisher = _publisher;
		base.Developer = _developer;
		base.Type = _type;
		base.OSList = _oslist;
		TryGetCanonicalName(base.FullPath, ref CanonicalName);
		ScreenshotList = new List<SteamScreenshotNode>();
	}

	public bool TryParseAppDetails(string appDetailsText)
	{
		JObject jObject = JObject.Parse(appDetailsText);
		if (!(bool)jObject[base.AppId.ToString()]["success"])
		{
			return false;
		}
		JToken jToken = jObject[base.AppId.ToString()]["data"];
		base.Name = (string)jToken["name"];
		base.AppId = ulong.Parse((string)jToken["steam_appid"]);
		base.Type = (string)jToken["type"];
		base.Description = (string)jToken["detailed_description"];
		base.Genre = ((jToken["genres"] != null) ? ((string)jToken["genres"][0]["description"]) : null);
		base.Developer = ((jToken["developers"] != null) ? ((string)jToken["developers"][0]) : null);
		base.Publisher = ((jToken["publishers"] != null) ? ((string)jToken["publishers"][0]) : null);
		string s = (string)jToken["release_date"]["date"];
		if (!DateTime.TryParseExact(s, "MMM d, yyyy", null, DateTimeStyles.None, out m_releaseDate))
		{
			DateTime.TryParseExact(s, "MMM yyyy", null, DateTimeStyles.None, out m_releaseDate);
		}
		if ((bool)jToken["platforms"]["windows"])
		{
			base.OSList = "windows";
		}
		JToken jToken2 = jToken["screenshots"];
		if (jToken2 != null)
		{
			foreach (JToken item2 in (IEnumerable<JToken>)jToken2)
			{
				SteamScreenshotNode item = new SteamScreenshotNode(this, (string)item2["path_full"], (string)item2["path_thumbnail"]);
				ScreenshotList.Add(item);
			}
		}
		return true;
	}
}
