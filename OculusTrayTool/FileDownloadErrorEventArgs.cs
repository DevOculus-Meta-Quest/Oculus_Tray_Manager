using System;

namespace OculusTrayTool
{
	// Token: 0x02000015 RID: 21
	public class FileDownloadErrorEventArgs : EventArgs
	{
		// Token: 0x060001A5 RID: 421 RVA: 0x00007F48 File Offset: 0x00006148
		public FileDownloadErrorEventArgs(DownloadFileNode _downloadFile, Exception _error)
		{
			this.DownloadFile = null;
			this.Error = null;
			this.DownloadFile = _downloadFile;
			this.Error = _error;
		}

		// Token: 0x0400003D RID: 61
		public DownloadFileNode DownloadFile;

		// Token: 0x0400003E RID: 62
		public Exception Error;
	}
}
