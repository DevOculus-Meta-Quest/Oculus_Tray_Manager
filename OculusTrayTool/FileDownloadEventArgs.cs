using System;

namespace OculusTrayTool
{
	// Token: 0x02000016 RID: 22
	public class FileDownloadEventArgs : EventArgs
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x00007F6E File Offset: 0x0000616E
		public FileDownloadEventArgs(DownloadFileNode _downloadFile)
		{
			this.DownloadFile = null;
			this.DownloadFile = _downloadFile;
		}

		// Token: 0x0400003F RID: 63
		public DownloadFileNode DownloadFile;
	}
}
