using System;

namespace OculusTrayTool;

public class FileDownloadErrorEventArgs : EventArgs
{
	public DownloadFileNode DownloadFile;

	public Exception Error;

	public FileDownloadErrorEventArgs(DownloadFileNode _downloadFile, Exception _error)
	{
		DownloadFile = null;
		Error = null;
		DownloadFile = _downloadFile;
		Error = _error;
	}
}
