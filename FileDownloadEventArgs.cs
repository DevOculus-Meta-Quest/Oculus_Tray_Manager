
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
