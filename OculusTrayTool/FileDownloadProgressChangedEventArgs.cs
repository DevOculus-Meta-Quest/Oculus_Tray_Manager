using System;

namespace OculusTrayTool;

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
		DownloadFile = null;
		CurrentBytesReceived = 0L;
		CurrentTotalBytesToReceive = 0L;
		CurrentProgressPercentage = 0;
		TotalBytesReceived = 0L;
		TotalBytesToReceive = 0L;
		TotalProgressPercentage = 0;
		DownloadSpeed = 0.0;
		DownloadFile = _downloadFile;
	}
}
