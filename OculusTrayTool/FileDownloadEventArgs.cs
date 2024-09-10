using System;

namespace OculusTrayTool;

public class FileDownloadEventArgs : EventArgs
{
	public DownloadFileNode DownloadFile;

	public FileDownloadEventArgs(DownloadFileNode _downloadFile)
	{
		DownloadFile = null;
		DownloadFile = _downloadFile;
	}
}
