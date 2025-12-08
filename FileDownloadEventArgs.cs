// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.FileDownloadEventArgs
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;

#nullable disable
namespace OculusTrayTool
{
  public class FileDownloadEventArgs : EventArgs
  {
    public DownloadFileNode DownloadFile;

    public FileDownloadEventArgs(DownloadFileNode _downloadFile)
    {
      this.DownloadFile = (DownloadFileNode) null;
      this.DownloadFile = _downloadFile;
    }
  }
}
