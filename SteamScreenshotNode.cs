// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.SteamScreenshotNode
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

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
