using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OculusTrayTool;

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

	public string FileName
	{
		get
		{
			return m_fileName;
		}
		set
		{
			m_fileName = value;
			NeedsPostProcessing = Array.IndexOf(new string[5] { ".zip", ".7zip", ".7z", ".rar", ".exe" }, Path.GetExtension(FileName)) > -1;
		}
	}

	public string Id
	{
		get
		{
			string s = string.Format("{0}{1}", (SourceUrl ?? "").ToLower(), (DestinationFolder ?? "").ToLower());
			MD5 mD = MD5.Create();
			byte[] b = mD.ComputeHash(Encoding.Default.GetBytes(s));
			return new Guid(b).ToString();
		}
	}

	public DownloadFileNode(string _sourceUrl, string _destinationFolder)
	{
		Name = null;
		m_fileName = null;
		Version = null;
		Author = null;
		Category = null;
		Description = null;
		Folder = null;
		SourceUrl = null;
		DestinationFolder = null;
		ExtractionFolder = null;
		NeedsPostProcessing = false;
		TotalBytes = 0L;
		Tag = null;
		SourceUrl = _sourceUrl;
		DestinationFolder = _destinationFolder;
		FileName = GetFileName(SourceUrl);
	}

	private string GetFileName(string url)
	{
		if (string.IsNullOrEmpty(url))
		{
			return url;
		}
		Uri uri = new Uri(url);
		string components = uri.GetComponents(UriComponents.Path, UriFormat.SafeUnescaped);
		return Path.GetFileName(components);
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clone
		return this.Clone();
	}
}
