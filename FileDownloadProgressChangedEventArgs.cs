// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.FileDownloadProgressChangedEventArgs
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;

#nullable disable
namespace OculusTrayTool
{
  public class FileDownloadProgressChangedEventArgs : EventArgs
  {
    public DownloadFileNode DownloadFile;
    public long CurrentBytesReceived;
    public long CurrentTotalBytesToReceive;
    public int CurrentProgressPercentage;
    public long TotalBytesReceived;
    public long TotalBytesToReceive;
    public int TotalProgressPercentage;
    public double DownloadSpeed;

    public FileDownloadProgressChangedEventArgs(DownloadFileNode _downloadFile)
    {
      this.DownloadFile = (DownloadFileNode) null;
      this.CurrentBytesReceived = 0L;
      this.CurrentTotalBytesToReceive = 0L;
      this.CurrentProgressPercentage = 0;
      this.TotalBytesReceived = 0L;
      this.TotalBytesToReceive = 0L;
      this.TotalProgressPercentage = 0;
      this.DownloadSpeed = 0.0;
      this.DownloadFile = _downloadFile;
    }
  }
}
