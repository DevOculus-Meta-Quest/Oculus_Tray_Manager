// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.DownloadFileNode
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

#nullable disable
namespace OculusTrayTool
{
  public class DownloadFileNode : ICloneable
  {
    public string Name;
    private string m_fileName;
    public string Version;
    public string Author;
    public string Category;
    public string Description;
    public string Folder;
    public string SourceUrl;
    public string DestinationFolder;
    public string ExtractionFolder;
    public bool NeedsPostProcessing;
    public long TotalBytes;
    public object Tag;

    public DownloadFileNode(string _sourceUrl, string _destinationFolder)
    {
      this.Name = (string) null;
      this.m_fileName = (string) null;
      this.Version = (string) null;
      this.Author = (string) null;
      this.Category = (string) null;
      this.Description = (string) null;
      this.Folder = (string) null;
      this.SourceUrl = (string) null;
      this.DestinationFolder = (string) null;
      this.ExtractionFolder = (string) null;
      this.NeedsPostProcessing = false;
      this.TotalBytes = 0L;
      this.Tag = (object) null;
      this.SourceUrl = _sourceUrl;
      this.DestinationFolder = _destinationFolder;
      this.FileName = this.GetFileName(this.SourceUrl);
    }

    private string GetFileName(string url)
    {
      return string.IsNullOrEmpty(url) ? url : Path.GetFileName(new Uri(url).GetComponents(UriComponents.Path, UriFormat.SafeUnescaped));
    }

    public string FileName
    {
      get => this.m_fileName;
      set
      {
        this.m_fileName = value;
        this.NeedsPostProcessing = Array.IndexOf<string>(new string[5]
        {
          ".zip",
          ".7zip",
          ".7z",
          ".rar",
          ".exe"
        }, Path.GetExtension(this.FileName)) > -1;
      }
    }

    public string Id
    {
      get
      {
        string s = string.Format("{0}{1}", (object) (this.SourceUrl ?? "").ToLower(), (object) (this.DestinationFolder ?? "").ToLower());
        return new Guid(MD5.Create().ComputeHash(Encoding.Default.GetBytes(s))).ToString();
      }
    }

    public object Clone() => this.MemberwiseClone();
  }
}
