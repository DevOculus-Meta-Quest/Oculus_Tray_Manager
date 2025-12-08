// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.FileDownloadErrorEventArgs
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;

#nullable disable
namespace OculusTrayTool
{
  public class FileDownloadErrorEventArgs : EventArgs
  {
    public DownloadFileNode DownloadFile;
    public Exception Error;

    public FileDownloadErrorEventArgs(DownloadFileNode _downloadFile, Exception _error)
    {
      this.DownloadFile = (DownloadFileNode) null;
      this.Error = (Exception) null;
      this.DownloadFile = _downloadFile;
      this.Error = _error;
    }
  }
}
