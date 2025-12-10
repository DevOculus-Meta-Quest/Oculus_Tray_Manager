
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
