// Decompiled with JetBrains decompiler

#nullable disable
namespace OculusTrayTool
{
  public class SteamScreenshotNode
  {
    public SteamNode SteamNode;
    public string FullPath;
    public string ThumbnailPath;

    public SteamScreenshotNode(SteamNode _steamNode, string _fullPath, string _thumbnailPath)
    {
      this.SteamNode = (SteamNode) null;
      this.FullPath = (string) null;
      this.ThumbnailPath = (string) null;
      this.SteamNode = _steamNode;
      this.FullPath = _fullPath;
      this.ThumbnailPath = _thumbnailPath;
    }
  }
}
