using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

public class FileDownloader : IDisposable
{
	private const int DEFAULT_DECIMALS = 2;

	private const int DEFAULT_SPEED_SAMPLES = 10;

	private const string DEFAULT_USER_AGENT = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

	private WebClient m_webClient;

	private List<DownloadFileNode> m_downloadFileList;

	private int m_fileIndex;

	private long m_totalBytesReceived;

	private long m_totalBytesToReceive;

	private long m_lastBytesReceived;

	private Stopwatch m_speedStopwatch;

	private int m_speedSampleIndex;

	private double[] m_speedSampleArray;

	private double m_downloadSpeed;

	private bool m_disposed;

	public int FileIndex => m_fileIndex;

	public int FileCount => m_downloadFileList.Count;

	public double DownloadSpeed => m_downloadSpeed;

	public event EventHandler<FileDownloadProgressChangedEventArgs> FileDownloadProgressChanged;

	public event EventHandler<FileDownloadErrorEventArgs> FileDownloadError;

	public event EventHandler<FileDownloadEventArgs> FileDownloadStarted;

	public event EventHandler<FileDownloadEventArgs> FileDownloadCancelled;

	public event EventHandler<FileDownloadEventArgs> FileDownloadCompleted;

	public event EventHandler<EventArgs> AllFilesDownloadCompleted;

	public FileDownloader(List<DownloadFileNode> downloadFileList)
	{
		m_webClient = null;
		m_downloadFileList = null;
		m_fileIndex = 0;
		m_totalBytesReceived = 0L;
		m_totalBytesToReceive = 0L;
		m_lastBytesReceived = 0L;
		m_speedStopwatch = null;
		m_speedSampleIndex = 0;
		m_speedSampleArray = null;
		m_downloadSpeed = 0.0;
		m_disposed = false;
		try
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		m_speedStopwatch = new Stopwatch();
		m_speedSampleArray = new double[11];
		m_downloadFileList = new List<DownloadFileNode>();
		m_downloadFileList.AddRange(downloadFileList);
		checked
		{
			foreach (DownloadFileNode downloadFile in downloadFileList)
			{
				long contentLength = 0L;
				if (TryGetUrlContentLength(downloadFile, ref contentLength))
				{
					downloadFile.TotalBytes = contentLength;
					m_totalBytesToReceive += contentLength;
				}
			}
		}
	}

	public bool Start()
	{
		return TryDownload();
	}

	public bool Cancel()
	{
		lock (m_downloadFileList)
		{
			if (m_webClient == null)
			{
				return false;
			}
			m_webClient.CancelAsync();
			m_downloadFileList.Clear();
		}
		return true;
	}

	private bool TryDownload()
	{
		if (AreAllFileDownloadCompleted())
		{
			return false;
		}
		lock (m_downloadFileList)
		{
			DownloadFileNode downloadFileNode = m_downloadFileList[m_fileIndex];
			return TryDownloadData(downloadFileNode);
		}
	}

	private bool AreAllFileDownloadCompleted()
	{
		lock (m_downloadFileList)
		{
			return m_downloadFileList.Count == 0 || m_fileIndex >= m_downloadFileList.Count;
		}
	}

	private void UpdateDownloadSpeed(DownloadProgressChangedEventArgs e)
	{
		m_speedStopwatch.Stop();
		double num = Math.Max(m_speedStopwatch.Elapsed.TotalMilliseconds, 1.0);
		long num2 = checked(e.BytesReceived - m_lastBytesReceived);
		m_lastBytesReceived = e.BytesReceived;
		double num3 = (double)num2 / (num / 1000.0);
		m_speedSampleArray[m_speedSampleIndex % 10] = num3;
		checked
		{
			m_speedSampleIndex++;
			double num4 = 0.0;
			for (int i = 0; i < m_speedSampleArray.Length; i++)
			{
				num4 += m_speedSampleArray[i];
			}
			m_downloadSpeed = num4 / (double)m_speedSampleArray.Length;
			m_speedStopwatch.Reset();
			m_speedStopwatch.Start();
		}
	}

	private bool TryGetUrlContentLength(DownloadFileNode downloadFileNode, ref long contentLength)
	{
		contentLength = 0L;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(downloadFileNode.SourceUrl);
			httpWebRequest.Referer = GetParentUriString(downloadFileNode.SourceUrl);
			httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
			using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			contentLength = httpWebResponse.ContentLength;
			return true;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	private bool TryDownloadData(DownloadFileNode downloadFileNode)
	{
		try
		{
			if (m_webClient != null)
			{
				m_webClient.Dispose();
				m_webClient = null;
			}
			Uri address = new Uri(downloadFileNode.SourceUrl);
			m_webClient = new WebClient();
			m_webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
			m_webClient.DownloadDataCompleted += OnDownloadDataCompleted;
			m_webClient.DownloadProgressChanged += OnDownloadProgressChanged;
			m_webClient.DownloadDataAsync(address, downloadFileNode);
			FileDownloadStarted?.Invoke(this, new FileDownloadEventArgs(downloadFileNode));
			return true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception error = ex;
			FileDownloadError?.Invoke(this, new FileDownloadErrorEventArgs(downloadFileNode, error));
			ProjectData.ClearProjectError();
		}
		return false;
	}

	private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
	{
		DownloadFileNode downloadFileNode = (DownloadFileNode)e.UserState;
		checked
		{
			if (downloadFileNode.TotalBytes == 0)
			{
				downloadFileNode.TotalBytes = e.TotalBytesToReceive;
				m_totalBytesToReceive += e.TotalBytesToReceive;
			}
			UpdateDownloadSpeed(e);
			FileDownloadProgressChangedEventArgs fileDownloadProgressChangedEventArgs = new FileDownloadProgressChangedEventArgs(downloadFileNode);
			fileDownloadProgressChangedEventArgs.CurrentBytesReceived = e.BytesReceived;
			fileDownloadProgressChangedEventArgs.CurrentTotalBytesToReceive = e.TotalBytesToReceive;
			fileDownloadProgressChangedEventArgs.CurrentProgressPercentage = e.ProgressPercentage;
			fileDownloadProgressChangedEventArgs.TotalBytesReceived = m_totalBytesReceived + e.BytesReceived;
			fileDownloadProgressChangedEventArgs.TotalBytesToReceive = m_totalBytesToReceive;
			fileDownloadProgressChangedEventArgs.TotalProgressPercentage = MathTools.Clamp((int)Math.Round((double)fileDownloadProgressChangedEventArgs.TotalBytesReceived / (double)m_totalBytesToReceive * 100.0), 0, 100);
			fileDownloadProgressChangedEventArgs.DownloadSpeed = m_downloadSpeed;
			FileDownloadProgressChanged?.Invoke(this, fileDownloadProgressChangedEventArgs);
		}
	}

	private void OnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
	{
		WebClient webClient = (WebClient)sender;
		DownloadFileNode downloadFileNode = (DownloadFileNode)e.UserState;
		checked
		{
			try
			{
				if (e.Error != null)
				{
					FileDownloadError?.Invoke(this, new FileDownloadErrorEventArgs(downloadFileNode, e.Error));
				}
				else if (e.Cancelled)
				{
					FileDownloadCancelled?.Invoke(this, new FileDownloadEventArgs(downloadFileNode));
				}
				else if (e.Result != null)
				{
					if (!Directory.Exists(downloadFileNode.DestinationFolder))
					{
						Directory.CreateDirectory(downloadFileNode.DestinationFolder);
					}
					string text = Path.Combine(downloadFileNode.DestinationFolder, downloadFileNode.FileName);
					File.WriteAllBytes(text, e.Result);
					FileInfo fileInfo = new FileInfo(text);
					long length = fileInfo.Length;
					if (length == 0)
					{
						File.Delete(text);
					}
					else
					{
						FileDownloadCompleted?.Invoke(this, new FileDownloadEventArgs(downloadFileNode));
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception error = ex;
				FileDownloadError?.Invoke(this, new FileDownloadErrorEventArgs(downloadFileNode, error));
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (webClient != null)
				{
					webClient.Dispose();
					webClient = null;
				}
				m_totalBytesReceived += downloadFileNode.TotalBytes;
				m_fileIndex++;
				if (AreAllFileDownloadCompleted())
				{
					AllFilesDownloadCompleted?.Invoke(this, EventArgs.Empty);
				}
				else
				{
					TryDownload();
				}
			}
		}
	}

	private string GetParentUriString(string url)
	{
		Uri uri = new Uri(url);
		return uri.AbsoluteUri.Remove(checked(uri.AbsoluteUri.Length - uri.Segments[uri.Segments.Length - 1].Length - uri.Query.Length));
	}

	public static string FormatSizeBinary(long size)
	{
		return FormatSizeBinary(size, 2);
	}

	public static string FormatSizeBinary(long size, int decimals)
	{
		string[] array = new string[9] { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB", "ZiB", "YiB" };
		double num = size;
		int num2 = 0;
		while (num >= 1024.0 && num2 < array.Length)
		{
			num /= 1024.0;
			num2 = checked(num2 + 1);
		}
		return $"{Math.Round(num, decimals)} {array[num2]}";
	}

	public static string FormatSizeDecimal(long size)
	{
		return FormatSizeDecimal(size, 2);
	}

	public static string FormatSizeDecimal(long size, int decimals)
	{
		string[] array = new string[9] { "B", "kB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
		double num = size;
		int num2 = 0;
		while (num >= 1000.0 && num2 < array.Length)
		{
			num /= 1000.0;
			num2 = checked(num2 + 1);
		}
		return $"{Math.Round(num, decimals)} {array[num2]}";
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!m_disposed && disposing)
		{
			Cancel();
		}
	}
}
