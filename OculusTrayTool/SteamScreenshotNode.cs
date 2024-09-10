using System;

namespace OculusTrayTool
{
	// Token: 0x0200005E RID: 94
	public class SteamScreenshotNode
	{
		// Token: 0x06000932 RID: 2354 RVA: 0x00054BF0 File Offset: 0x00052DF0
		public SteamScreenshotNode(SteamNode _steamNode, string _fullPath, string _thumbnailPath)
		{
			this.SteamNode = null;
			this.FullPath = null;
			this.ThumbnailPath = null;
			this.SteamNode = _steamNode;
			this.FullPath = _fullPath;
			this.ThumbnailPath = _thumbnailPath;
		}

		// Token: 0x040003E5 RID: 997
		public SteamNode SteamNode;

		// Token: 0x040003E6 RID: 998
		public string FullPath;

		// Token: 0x040003E7 RID: 999
		public string ThumbnailPath;
	}
}
