using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace OculusTrayTool
{
	// Token: 0x02000013 RID: 19
	public class FileDownloader : IDisposable
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000184 RID: 388 RVA: 0x000071EC File Offset: 0x000053EC
		// (remove) Token: 0x06000185 RID: 389 RVA: 0x00007224 File Offset: 0x00005424
		public event EventHandler<FileDownloadProgressChangedEventArgs> FileDownloadProgressChanged;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000186 RID: 390 RVA: 0x0000725C File Offset: 0x0000545C
		// (remove) Token: 0x06000187 RID: 391 RVA: 0x00007294 File Offset: 0x00005494
		public event EventHandler<FileDownloadErrorEventArgs> FileDownloadError;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000188 RID: 392 RVA: 0x000072CC File Offset: 0x000054CC
		// (remove) Token: 0x06000189 RID: 393 RVA: 0x00007304 File Offset: 0x00005504
		public event EventHandler<FileDownloadEventArgs> FileDownloadStarted;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x0600018A RID: 394 RVA: 0x0000733C File Offset: 0x0000553C
		// (remove) Token: 0x0600018B RID: 395 RVA: 0x00007374 File Offset: 0x00005574
		public event EventHandler<FileDownloadEventArgs> FileDownloadCancelled;

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x0600018C RID: 396 RVA: 0x000073AC File Offset: 0x000055AC
		// (remove) Token: 0x0600018D RID: 397 RVA: 0x000073E4 File Offset: 0x000055E4
		public event EventHandler<FileDownloadEventArgs> FileDownloadCompleted;

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600018E RID: 398 RVA: 0x0000741C File Offset: 0x0000561C
		// (remove) Token: 0x0600018F RID: 399 RVA: 0x00007454 File Offset: 0x00005654
		public event EventHandler<EventArgs> AllFilesDownloadCompleted;

		// Token: 0x06000190 RID: 400 RVA: 0x0000748C File Offset: 0x0000568C
		public FileDownloader(List<DownloadFileNode> downloadFileList)
		{
			this.m_webClient = null;
			this.m_downloadFileList = null;
			this.m_fileIndex = 0;
			this.m_totalBytesReceived = 0L;
			this.m_totalBytesToReceive = 0L;
			this.m_lastBytesReceived = 0L;
			this.m_speedStopwatch = null;
			this.m_speedSampleIndex = 0;
			this.m_speedSampleArray = null;
			this.m_downloadSpeed = 0.0;
			this.m_disposed = false;
			try
			{
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			}
			catch (Exception ex)
			{
			}
			this.m_speedStopwatch = new Stopwatch();
			this.m_speedSampleArray = new double[11];
			this.m_downloadFileList = new List<DownloadFileNode>();
			this.m_downloadFileList.AddRange(downloadFileList);
			try
			{
				foreach (DownloadFileNode downloadFileNode in downloadFileList)
				{
					long num = 0L;
					bool flag = this.TryGetUrlContentLength(downloadFileNode, ref num);
					if (flag)
					{
						downloadFileNode.TotalBytes = num;
						ref long ptr = ref this.m_totalBytesToReceive;
						this.m_totalBytesToReceive = checked(ptr + num);
					}
				}
			}
			finally
			{
				List<DownloadFileNode>.Enumerator enumerator;
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x000075BC File Offset: 0x000057BC
		public bool Start()
		{
			return this.TryDownload();
		}

		// Token: 0x06000192 RID: 402 RVA: 0x000075D4 File Offset: 0x000057D4
		public bool Cancel()
		{
			object downloadFileList = this.m_downloadFileList;
			lock (downloadFileList)
			{
				bool flag2 = this.m_webClient == null;
				if (flag2)
				{
					return false;
				}
				this.m_webClient.CancelAsync();
				this.m_downloadFileList.Clear();
			}
			return true;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00007644 File Offset: 0x00005844
		private bool TryDownload()
		{
			bool flag = this.AreAllFileDownloadCompleted();
			bool flag2;
			if (flag)
			{
				flag2 = false;
			}
			else
			{
				object downloadFileList = this.m_downloadFileList;
				lock (downloadFileList)
				{
					DownloadFileNode downloadFileNode = this.m_downloadFileList[this.m_fileIndex];
					flag2 = this.TryDownloadData(downloadFileNode);
				}
			}
			return flag2;
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000076B0 File Offset: 0x000058B0
		private bool AreAllFileDownloadCompleted()
		{
			object downloadFileList = this.m_downloadFileList;
			bool flag2;
			lock (downloadFileList)
			{
				flag2 = this.m_downloadFileList.Count == 0 || this.m_fileIndex >= this.m_downloadFileList.Count;
			}
			return flag2;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x00007718 File Offset: 0x00005918
		private void UpdateDownloadSpeed(DownloadProgressChangedEventArgs e)
		{
			this.m_speedStopwatch.Stop();
			double num = Math.Max(this.m_speedStopwatch.Elapsed.TotalMilliseconds, 1.0);
			checked
			{
				long num2 = e.BytesReceived - this.m_lastBytesReceived;
				this.m_lastBytesReceived = e.BytesReceived;
				double num3 = (double)num2 / (num / 1000.0);
				this.m_speedSampleArray[this.m_speedSampleIndex % 10] = num3;
				ref int ptr = ref this.m_speedSampleIndex;
				this.m_speedSampleIndex = ptr + 1;
				double num4 = 0.0;
				for (int i = 0; i < this.m_speedSampleArray.Length; i++)
				{
					unchecked
					{
						num4 += this.m_speedSampleArray[i];
					}
				}
				this.m_downloadSpeed = num4 / (double)this.m_speedSampleArray.Length;
				this.m_speedStopwatch.Reset();
				this.m_speedStopwatch.Start();
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000077FC File Offset: 0x000059FC
		private bool TryGetUrlContentLength(DownloadFileNode downloadFileNode, ref long contentLength)
		{
			contentLength = 0L;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(downloadFileNode.SourceUrl);
				httpWebRequest.Referer = this.GetParentUriString(downloadFileNode.SourceUrl);
				httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
				using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
				{
					contentLength = httpWebResponse.ContentLength;
					return true;
				}
			}
			catch (Exception ex)
			{
			}
			return false;
		}

		// Token: 0x06000197 RID: 407 RVA: 0x00007894 File Offset: 0x00005A94
		private bool TryDownloadData(DownloadFileNode downloadFileNode)
		{
			try
			{
				bool flag = this.m_webClient != null;
				if (flag)
				{
					this.m_webClient.Dispose();
					this.m_webClient = null;
				}
				Uri uri = new Uri(downloadFileNode.SourceUrl);
				this.m_webClient = new WebClient();
				this.m_webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
				this.m_webClient.DownloadDataCompleted += this.OnDownloadDataCompleted;
				this.m_webClient.DownloadProgressChanged += this.OnDownloadProgressChanged;
				this.m_webClient.DownloadDataAsync(uri, downloadFileNode);
				EventHandler<FileDownloadEventArgs> fileDownloadStartedEvent = this.FileDownloadStartedEvent;
				if (fileDownloadStartedEvent != null)
				{
					fileDownloadStartedEvent(this, new FileDownloadEventArgs(downloadFileNode));
				}
				return true;
			}
			catch (Exception ex)
			{
				EventHandler<FileDownloadErrorEventArgs> fileDownloadErrorEvent = this.FileDownloadErrorEvent;
				if (fileDownloadErrorEvent != null)
				{
					fileDownloadErrorEvent(this, new FileDownloadErrorEventArgs(downloadFileNode, ex));
				}
			}
			return false;
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00007994 File Offset: 0x00005B94
		private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			DownloadFileNode downloadFileNode = (DownloadFileNode)e.UserState;
			bool flag = downloadFileNode.TotalBytes == 0L;
			checked
			{
				if (flag)
				{
					downloadFileNode.TotalBytes = e.TotalBytesToReceive;
					ref long ptr = ref this.m_totalBytesToReceive;
					this.m_totalBytesToReceive = ptr + e.TotalBytesToReceive;
				}
				this.UpdateDownloadSpeed(e);
				FileDownloadProgressChangedEventArgs fileDownloadProgressChangedEventArgs = new FileDownloadProgressChangedEventArgs(downloadFileNode);
				fileDownloadProgressChangedEventArgs.CurrentBytesReceived = e.BytesReceived;
				fileDownloadProgressChangedEventArgs.CurrentTotalBytesToReceive = e.TotalBytesToReceive;
				fileDownloadProgressChangedEventArgs.CurrentProgressPercentage = e.ProgressPercentage;
				fileDownloadProgressChangedEventArgs.TotalBytesReceived = this.m_totalBytesReceived + e.BytesReceived;
				fileDownloadProgressChangedEventArgs.TotalBytesToReceive = this.m_totalBytesToReceive;
				fileDownloadProgressChangedEventArgs.TotalProgressPercentage = MathTools.Clamp<int>((int)Math.Round(unchecked((double)fileDownloadProgressChangedEventArgs.TotalBytesReceived / (double)this.m_totalBytesToReceive * 100.0)), 0, 100);
				fileDownloadProgressChangedEventArgs.DownloadSpeed = this.m_downloadSpeed;
				EventHandler<FileDownloadProgressChangedEventArgs> fileDownloadProgressChangedEvent = this.FileDownloadProgressChangedEvent;
				if (fileDownloadProgressChangedEvent != null)
				{
					fileDownloadProgressChangedEvent(this, fileDownloadProgressChangedEventArgs);
				}
			}
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00007A80 File Offset: 0x00005C80
		private void OnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			WebClient webClient = (WebClient)sender;
			DownloadFileNode downloadFileNode = (DownloadFileNode)e.UserState;
			checked
			{
				try
				{
					bool flag = e.Error != null;
					if (flag)
					{
						EventHandler<FileDownloadErrorEventArgs> fileDownloadErrorEvent = this.FileDownloadErrorEvent;
						if (fileDownloadErrorEvent != null)
						{
							fileDownloadErrorEvent(this, new FileDownloadErrorEventArgs(downloadFileNode, e.Error));
						}
					}
					else
					{
						bool cancelled = e.Cancelled;
						if (cancelled)
						{
							EventHandler<FileDownloadEventArgs> fileDownloadCancelledEvent = this.FileDownloadCancelledEvent;
							if (fileDownloadCancelledEvent != null)
							{
								fileDownloadCancelledEvent(this, new FileDownloadEventArgs(downloadFileNode));
							}
						}
						else
						{
							bool flag2 = e.Result == null;
							if (!flag2)
							{
								bool flag3 = !Directory.Exists(downloadFileNode.DestinationFolder);
								if (flag3)
								{
									Directory.CreateDirectory(downloadFileNode.DestinationFolder);
								}
								string text = Path.Combine(downloadFileNode.DestinationFolder, downloadFileNode.FileName);
								File.WriteAllBytes(text, e.Result);
								FileInfo fileInfo = new FileInfo(text);
								long length = fileInfo.Length;
								bool flag4 = length == 0L;
								if (flag4)
								{
									File.Delete(text);
								}
								else
								{
									EventHandler<FileDownloadEventArgs> fileDownloadCompletedEvent = this.FileDownloadCompletedEvent;
									if (fileDownloadCompletedEvent != null)
									{
										fileDownloadCompletedEvent(this, new FileDownloadEventArgs(downloadFileNode));
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					EventHandler<FileDownloadErrorEventArgs> fileDownloadErrorEvent2 = this.FileDownloadErrorEvent;
					if (fileDownloadErrorEvent2 != null)
					{
						fileDownloadErrorEvent2(this, new FileDownloadErrorEventArgs(downloadFileNode, ex));
					}
				}
				finally
				{
					bool flag5 = webClient != null;
					if (flag5)
					{
						webClient.Dispose();
						webClient = null;
					}
					ref long ptr = ref this.m_totalBytesReceived;
					this.m_totalBytesReceived = ptr + downloadFileNode.TotalBytes;
					ref int ptr2 = ref this.m_fileIndex;
					this.m_fileIndex = ptr2 + 1;
					bool flag6 = this.AreAllFileDownloadCompleted();
					if (flag6)
					{
						EventHandler<EventArgs> allFilesDownloadCompletedEvent = this.AllFilesDownloadCompletedEvent;
						if (allFilesDownloadCompletedEvent != null)
						{
							allFilesDownloadCompletedEvent(this, EventArgs.Empty);
						}
					}
					else
					{
						this.TryDownload();
					}
				}
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00007C70 File Offset: 0x00005E70
		private string GetParentUriString(string url)
		{
			Uri uri = new Uri(url);
			return uri.AbsoluteUri.Remove(checked(uri.AbsoluteUri.Length - uri.Segments[uri.Segments.Length - 1].Length - uri.Query.Length));
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00007CC4 File Offset: 0x00005EC4
		public static string FormatSizeBinary(long size)
		{
			return FileDownloader.FormatSizeBinary(size, 2);
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00007CE0 File Offset: 0x00005EE0
		public static string FormatSizeBinary(long size, int decimals)
		{
			string[] array = new string[] { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB", "ZiB", "YiB" };
			double num = (double)size;
			int num2 = 0;
			checked
			{
				while (num >= 1024.0 && num2 < array.Length)
				{
					num /= 1024.0;
					num2++;
				}
				return string.Format("{0} {1}", Math.Round(num, decimals), array[num2]);
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00007D90 File Offset: 0x00005F90
		public static string FormatSizeDecimal(long size)
		{
			return FileDownloader.FormatSizeDecimal(size, 2);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x00007DAC File Offset: 0x00005FAC
		public static string FormatSizeDecimal(long size, int decimals)
		{
			string[] array = new string[] { "B", "kB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
			double num = (double)size;
			int num2 = 0;
			checked
			{
				while (num >= 1000.0 && num2 < array.Length)
				{
					num /= 1000.0;
					num2++;
				}
				return string.Format("{0} {1}", Math.Round(num, decimals), array[num2]);
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00007E5A File Offset: 0x0000605A
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00007E6C File Offset: 0x0000606C
		protected virtual void Dispose(bool disposing)
		{
			bool flag = !this.m_disposed;
			if (flag)
			{
				if (disposing)
				{
					this.Cancel();
				}
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x00007E98 File Offset: 0x00006098
		public int FileIndex
		{
			get
			{
				return this.m_fileIndex;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00007EB0 File Offset: 0x000060B0
		public int FileCount
		{
			get
			{
				return this.m_downloadFileList.Count;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00007ED0 File Offset: 0x000060D0
		public double DownloadSpeed
		{
			get
			{
				return this.m_downloadSpeed;
			}
		}

		// Token: 0x04000021 RID: 33
		private const int DEFAULT_DECIMALS = 2;

		// Token: 0x04000022 RID: 34
		private const int DEFAULT_SPEED_SAMPLES = 10;

		// Token: 0x04000023 RID: 35
		private const string DEFAULT_USER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

		// Token: 0x04000024 RID: 36
		private WebClient m_webClient;

		// Token: 0x04000025 RID: 37
		private List<DownloadFileNode> m_downloadFileList;

		// Token: 0x04000026 RID: 38
		private int m_fileIndex;

		// Token: 0x04000027 RID: 39
		private long m_totalBytesReceived;

		// Token: 0x04000028 RID: 40
		private long m_totalBytesToReceive;

		// Token: 0x04000029 RID: 41
		private long m_lastBytesReceived;

		// Token: 0x0400002A RID: 42
		private Stopwatch m_speedStopwatch;

		// Token: 0x0400002B RID: 43
		private int m_speedSampleIndex;

		// Token: 0x0400002C RID: 44
		private double[] m_speedSampleArray;

		// Token: 0x0400002D RID: 45
		private double m_downloadSpeed;

		// Token: 0x04000034 RID: 52
		private bool m_disposed;
	}
}
