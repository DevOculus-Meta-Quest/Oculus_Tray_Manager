using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json.Linq;

namespace OculusTrayTool
{
	// Token: 0x0200005D RID: 93
	public class SteamNode : OculusNode
	{
		// Token: 0x0600092C RID: 2348 RVA: 0x0005484F File Offset: 0x00052A4F
		public SteamNode(ulong _appId)
			: base(PlatformType.Steam, _appId)
		{
			this.ScreenshotList = null;
			this.ScreenshotList = new List<SteamScreenshotNode>();
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0005486D File Offset: 0x00052A6D
		public SteamNode(ulong _appId, string _name)
			: base(PlatformType.Steam, _appId, _name)
		{
			this.ScreenshotList = null;
			this.ScreenshotList = new List<SteamScreenshotNode>();
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0005488C File Offset: 0x00052A8C
		public SteamNode(ulong _appId, string _name, string _url)
			: base(PlatformType.Steam, _appId, _name)
		{
			this.ScreenshotList = null;
			base.Url = _url;
			this.ScreenshotList = new List<SteamScreenshotNode>();
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x000548B4 File Offset: 0x00052AB4
		public SteamNode(ulong _appId, string _name, string _type, string _publisher, string _developer, string _executable, string _parameters, string _oslist, string _libraryFolder, string _installDir)
			: base(PlatformType.Steam, _appId, _name, _executable, _parameters, _libraryFolder, _installDir)
		{
			this.ScreenshotList = null;
			base.Publisher = _publisher;
			base.Developer = _developer;
			base.Type = _type;
			base.OSList = _oslist;
			base.TryGetCanonicalName(base.FullPath, ref this.CanonicalName);
			this.ScreenshotList = new List<SteamScreenshotNode>();
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x0005491C File Offset: 0x00052B1C
		public bool TryParseAppDetails(string appDetailsText)
		{
			JObject jobject = JObject.Parse(appDetailsText);
			bool flag = (bool)jobject[base.AppId.ToString()]["success"];
			bool flag2 = !flag;
			bool flag3;
			if (flag2)
			{
				flag3 = false;
			}
			else
			{
				JToken jtoken = jobject[base.AppId.ToString()]["data"];
				base.Name = (string)jtoken["name"];
				base.AppId = ulong.Parse((string)jtoken["steam_appid"]);
				base.Type = (string)jtoken["type"];
				base.Description = (string)jtoken["detailed_description"];
				base.Genre = ((jtoken["genres"] != null) ? ((string)jtoken["genres"][0]["description"]) : null);
				base.Developer = ((jtoken["developers"] != null) ? ((string)jtoken["developers"][0]) : null);
				base.Publisher = ((jtoken["publishers"] != null) ? ((string)jtoken["publishers"][0]) : null);
				string text = (string)jtoken["release_date"]["date"];
				bool flag4 = !DateTime.TryParseExact(text, "MMM d, yyyy", null, DateTimeStyles.None, out this.m_releaseDate);
				if (flag4)
				{
					DateTime.TryParseExact(text, "MMM yyyy", null, DateTimeStyles.None, out this.m_releaseDate);
				}
				bool flag5 = (bool)jtoken["platforms"]["windows"];
				bool flag6 = flag5;
				if (flag6)
				{
					base.OSList = "windows";
				}
				JToken jtoken2 = jtoken["screenshots"];
				bool flag7 = jtoken2 != null;
				if (flag7)
				{
					try
					{
						foreach (JToken jtoken3 in ((IEnumerable<JToken>)jtoken2))
						{
							SteamScreenshotNode steamScreenshotNode = new SteamScreenshotNode(this, (string)jtoken3["path_full"], (string)jtoken3["path_thumbnail"]);
							this.ScreenshotList.Add(steamScreenshotNode);
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
				flag3 = true;
			}
			return flag3;
		}

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000931 RID: 2353 RVA: 0x00054BA4 File Offset: 0x00052DA4
		public override string InstallPath
		{
			get
			{
				bool flag = base.LibraryFolder == null || base.InstallDir == null;
				string text;
				if (flag)
				{
					text = null;
				}
				else
				{
					string text2 = Path.Combine(base.LibraryFolder, "steamapps\\common");
					text = Path.Combine(text2, base.InstallDir);
				}
				return text;
			}
		}

		// Token: 0x040003E4 RID: 996
		public List<SteamScreenshotNode> ScreenshotList;
	}
}
