using System;

namespace OculusTrayTool
{
	// Token: 0x02000014 RID: 20
	public class FileDownloadProgressChangedEventArgs : EventArgs
	{
		// Token: 0x060001A4 RID: 420 RVA: 0x00007EE8 File Offset: 0x000060E8
		public FileDownloadProgressChangedEventArgs(DownloadFileNode _downloadFile)
		{
			this.DownloadFile = null;
			this.CurrentBytesReceived = 0L;
			this.CurrentTotalBytesToReceive = 0L;
			this.CurrentProgressPercentage = 0;
			this.TotalBytesReceived = 0L;
			this.TotalBytesToReceive = 0L;
			this.TotalProgressPercentage = 0;
			this.DownloadSpeed = 0.0;
			this.DownloadFile = _downloadFile;
		}

		// Token: 0x04000035 RID: 53
		public DownloadFileNode DownloadFile;

		// Token: 0x04000036 RID: 54
		public long CurrentBytesReceived;

		// Token: 0x04000037 RID: 55
		public long CurrentTotalBytesToReceive;

		// Token: 0x04000038 RID: 56
		public int CurrentProgressPercentage;

		// Token: 0x04000039 RID: 57
		public long TotalBytesReceived;

		// Token: 0x0400003A RID: 58
		public long TotalBytesToReceive;

		// Token: 0x0400003B RID: 59
		public int TotalProgressPercentage;

		// Token: 0x0400003C RID: 60
		public double DownloadSpeed;
	}
}
