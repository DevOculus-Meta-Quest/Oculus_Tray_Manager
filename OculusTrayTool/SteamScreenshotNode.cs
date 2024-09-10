namespace OculusTrayTool;

public class SteamScreenshotNode
{
	public SteamNode SteamNode;

	public string FullPath;

	public string ThumbnailPath;

	public SteamScreenshotNode(SteamNode _steamNode, string _fullPath, string _thumbnailPath)
	{
		SteamNode = null;
		FullPath = null;
		ThumbnailPath = null;
		SteamNode = _steamNode;
		FullPath = _fullPath;
		ThumbnailPath = _thumbnailPath;
	}
}
