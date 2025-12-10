// Decompiled with JetBrains decompiler

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
