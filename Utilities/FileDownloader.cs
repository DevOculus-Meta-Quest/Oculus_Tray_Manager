

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;

#nullable disable
namespace MetaQuestTrayTool
{
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

    public event EventHandler<FileDownloadProgressChangedEventArgs> FileDownloadProgressChanged;

    public event EventHandler<FileDownloadErrorEventArgs> FileDownloadError;

    public event EventHandler<FileDownloadEventArgs> FileDownloadStarted;

    public event EventHandler<FileDownloadEventArgs> FileDownloadCancelled;

    public event EventHandler<FileDownloadEventArgs> FileDownloadCompleted;

    public event EventHandler<EventArgs> AllFilesDownloadCompleted;

    public FileDownloader(List<DownloadFileNode> downloadFileList)
    {
      this.m_webClient = (WebClient) null;
      this.m_downloadFileList = (List<DownloadFileNode>) null;
      this.m_fileIndex = 0;
      this.m_totalBytesReceived = 0L;
      this.m_totalBytesToReceive = 0L;
      this.m_lastBytesReceived = 0L;
      this.m_speedStopwatch = (Stopwatch) null;
      this.m_speedSampleIndex = 0;
      this.m_speedSampleArray = (double[]) null;
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
      this.m_downloadFileList.AddRange((IEnumerable<DownloadFileNode>) downloadFileList);

        foreach (DownloadFileNode downloadFile in downloadFileList)
        {
          long contentLength = 0;
          if (this.TryGetUrlContentLength(downloadFile, ref contentLength))
          {
            downloadFile.TotalBytes = contentLength;
            this.m_totalBytesToReceive += contentLength;
          }
        }


    }

    public bool Start() => this.TryDownload();

    public bool Cancel()
    {
      lock ((object) this.m_downloadFileList)
      {
        if (this.m_webClient == null)
          return false;
        this.m_webClient.CancelAsync();
        this.m_downloadFileList.Clear();
      }
      return true;
    }

    private bool TryDownload()
    {
      if (this.AreAllFileDownloadCompleted())
        return false;
      lock ((object) this.m_downloadFileList)
        return this.TryDownloadData(this.m_downloadFileList[this.m_fileIndex]);
    }

    private bool AreAllFileDownloadCompleted()
    {
      lock ((object) this.m_downloadFileList)
        return this.m_downloadFileList.Count == 0 || this.m_fileIndex >= this.m_downloadFileList.Count;
    }

    private void UpdateDownloadSpeed(DownloadProgressChangedEventArgs e)
    {
      this.m_speedStopwatch.Stop();
      double num1 = Math.Max(this.m_speedStopwatch.Elapsed.TotalMilliseconds, 1.0);
      long num2 = checked (e.BytesReceived - this.m_lastBytesReceived);
      this.m_lastBytesReceived = e.BytesReceived;
      this.m_speedSampleArray[this.m_speedSampleIndex % 10] = (double) num2 / (num1 / 1000.0);
      this.m_speedSampleIndex++;
      double num4 = 0.0;
      int index = 0;
      while (index < this.m_speedSampleArray.Length)
      {
        num4 += this.m_speedSampleArray[index];
        checked { ++index; }
      }
      this.m_downloadSpeed = num4 / (double) this.m_speedSampleArray.Length;
      this.m_speedStopwatch.Reset();
      this.m_speedStopwatch.Start();
    }

    private bool TryGetUrlContentLength(DownloadFileNode downloadFileNode, ref long contentLength)
    {
      contentLength = 0L;
      try
      {
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(downloadFileNode.SourceUrl);
        httpWebRequest.Referer = this.GetParentUriString(downloadFileNode.SourceUrl);
        httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        using (HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse())
        {
          contentLength = response.ContentLength;
          return true;
        }
      }
      catch (Exception ex)
      {
      }
      return false;
    }

    private bool TryDownloadData(DownloadFileNode downloadFileNode)
    {
      try
      {
        if (this.m_webClient != null)
        {
          this.m_webClient.Dispose();
          this.m_webClient = (WebClient) null;
        }
        Uri address = new Uri(downloadFileNode.SourceUrl);
        this.m_webClient = new WebClient();
        this.m_webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
        this.m_webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(this.OnDownloadDataCompleted);
        this.m_webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.OnDownloadProgressChanged);
        this.m_webClient.DownloadDataAsync(address, (object) downloadFileNode);
        EventHandler<FileDownloadEventArgs> downloadStartedEvent = this.FileDownloadStarted;
        if (downloadStartedEvent != null)
          downloadStartedEvent((object) this, new FileDownloadEventArgs(downloadFileNode));
        return true;
      }
      catch (Exception ex)
      {
        Exception _error = ex;
        EventHandler<FileDownloadErrorEventArgs> downloadErrorEvent = this.FileDownloadError;
        if (downloadErrorEvent != null)
          downloadErrorEvent((object) this, new FileDownloadErrorEventArgs(downloadFileNode, _error));
      }
      return false;
    }

    private void OnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
      DownloadFileNode userState = (DownloadFileNode) e.UserState;
      if (userState.TotalBytes == 0L)
      {
        userState.TotalBytes = e.TotalBytesToReceive;
        this.m_totalBytesToReceive += e.TotalBytesToReceive;
      }
      this.UpdateDownloadSpeed(e);
      FileDownloadProgressChangedEventArgs e1 = new FileDownloadProgressChangedEventArgs(userState)
      {
        CurrentBytesReceived = e.BytesReceived,
        CurrentTotalBytesToReceive = e.TotalBytesToReceive,
        CurrentProgressPercentage = e.ProgressPercentage,
        TotalBytesReceived = checked (this.m_totalBytesReceived + e.BytesReceived),
        TotalBytesToReceive = this.m_totalBytesToReceive
      };
      e1.TotalProgressPercentage = MathTools.Clamp<int>(checked ((int) Math.Round(unchecked ((double) e1.TotalBytesReceived / (double) this.m_totalBytesToReceive * 100.0))), 0, 100);
      e1.DownloadSpeed = this.m_downloadSpeed;
      EventHandler<FileDownloadProgressChangedEventArgs> progressChangedEvent = this.FileDownloadProgressChanged;
      if (progressChangedEvent == null)
        return;
      progressChangedEvent((object) this, e1);
    }

    private void OnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
      WebClient webClient = (WebClient) sender;
      DownloadFileNode userState = (DownloadFileNode) e.UserState;
      try
      {
        if (e.Error != null)
        {
          EventHandler<FileDownloadErrorEventArgs> downloadErrorEvent = this.FileDownloadError;
          if (downloadErrorEvent == null)
            return;
          downloadErrorEvent((object) this, new FileDownloadErrorEventArgs(userState, e.Error));
        }
        else if (e.Cancelled)
        {
          EventHandler<FileDownloadEventArgs> downloadCancelledEvent = this.FileDownloadCancelled;
          if (downloadCancelledEvent == null)
            return;
          downloadCancelledEvent((object) this, new FileDownloadEventArgs(userState));
        }
        else
        {
          if (e.Result == null)
            return;
          if (!Directory.Exists(userState.DestinationFolder))
            Directory.CreateDirectory(userState.DestinationFolder);
          string str = Path.Combine(userState.DestinationFolder, userState.FileName);
          System.IO.File.WriteAllBytes(str, e.Result);
          if (new FileInfo(str).Length == 0L)
          {
            System.IO.File.Delete(str);
          }
          else
          {
            EventHandler<FileDownloadEventArgs> downloadCompletedEvent = this.FileDownloadCompleted;
            if (downloadCompletedEvent != null)
              downloadCompletedEvent((object) this, new FileDownloadEventArgs(userState));
          }
        }
      }
      catch (Exception ex)
      {
        Exception _error = ex;
        EventHandler<FileDownloadErrorEventArgs> downloadErrorEvent = this.FileDownloadError;
        if (downloadErrorEvent != null)
          downloadErrorEvent((object) this, new FileDownloadErrorEventArgs(userState, _error));
      }
      finally
      {
        webClient?.Dispose();
        this.m_totalBytesReceived += userState.TotalBytes;
        this.m_fileIndex++;
        if (this.AreAllFileDownloadCompleted())
        {
          EventHandler<EventArgs> downloadCompletedEvent = this.AllFilesDownloadCompleted;
          if (downloadCompletedEvent != null)
            downloadCompletedEvent((object) this, EventArgs.Empty);
        }
        else
          this.TryDownload();
      }
    }

    private string GetParentUriString(string url)
    {
      Uri uri = new Uri(url);
      return uri.AbsoluteUri.Remove(checked (uri.AbsoluteUri.Length - uri.Segments[uri.Segments.Length - 1].Length - uri.Query.Length));
    }

    public static string FormatSizeBinary(long size) => FileDownloader.FormatSizeBinary(size, 2);

    public static string FormatSizeBinary(long size, int decimals)
    {
      string[] strArray = new string[9]
      {
        "B",
        "KiB",
        "MiB",
        "GiB",
        "TiB",
        "PiB",
        "EiB",
        "ZiB",
        "YiB"
      };
      double num = (double) size;
      int index = 0;
      while (num >= 1024.0 && index < strArray.Length)
      {
        num /= 1024.0;
        checked { ++index; }
      }
      return string.Format("{0} {1}", (object) Math.Round(num, decimals), (object) strArray[index]);
    }

    public static string FormatSizeDecimal(long size) => FileDownloader.FormatSizeDecimal(size, 2);

    public static string FormatSizeDecimal(long size, int decimals)
    {
      string[] strArray = new string[9]
      {
        "B",
        "kB",
        "MB",
        "GB",
        "TB",
        "PB",
        "EB",
        "ZB",
        "YB"
      };
      double num = (double) size;
      int index = 0;
      while (num >= 1000.0 && index < strArray.Length)
      {
        num /= 1000.0;
        checked { ++index; }
      }
      return string.Format("{0} {1}", (object) Math.Round(num, decimals), (object) strArray[index]);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.m_disposed || !disposing)
        return;
      this.Cancel();
    }

    public int FileIndex => this.m_fileIndex;

    public int FileCount => this.m_downloadFileList.Count;

    public double DownloadSpeed => this.m_downloadSpeed;
  }
}
