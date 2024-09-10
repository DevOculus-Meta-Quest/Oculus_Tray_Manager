using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OculusTrayTool
{
	// Token: 0x02000017 RID: 23
	public class DownloadFileNode : ICloneable
	{
		// Token: 0x060001A7 RID: 423 RVA: 0x00007F88 File Offset: 0x00006188
		public DownloadFileNode(string _sourceUrl, string _destinationFolder)
		{
			this.Name = null;
			this.m_fileName = null;
			this.Version = null;
			this.Author = null;
			this.Category = null;
			this.Description = null;
			this.Folder = null;
			this.SourceUrl = null;
			this.DestinationFolder = null;
			this.ExtractionFolder = null;
			this.NeedsPostProcessing = false;
			this.TotalBytes = 0L;
			this.Tag = null;
			this.SourceUrl = _sourceUrl;
			this.DestinationFolder = _destinationFolder;
			this.FileName = this.GetFileName(this.SourceUrl);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000801C File Offset: 0x0000621C
		private string GetFileName(string url)
		{
			bool flag = string.IsNullOrEmpty(url);
			string text;
			if (flag)
			{
				text = url;
			}
			else
			{
				Uri uri = new Uri(url);
				string components = uri.GetComponents(UriComponents.Path, UriFormat.SafeUnescaped);
				text = Path.GetFileName(components);
			}
			return text;
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00008054 File Offset: 0x00006254
		// (set) Token: 0x060001AA RID: 426 RVA: 0x0000806C File Offset: 0x0000626C
		public string FileName
		{
			get
			{
				return this.m_fileName;
			}
			set
			{
				this.m_fileName = value;
				this.NeedsPostProcessing = Array.IndexOf<string>(new string[] { ".zip", ".7zip", ".7z", ".rar", ".exe" }, Path.GetExtension(this.FileName)) > -1;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060001AB RID: 427 RVA: 0x000080C8 File Offset: 0x000062C8
		public string Id
		{
			get
			{
				string text = string.Format("{0}{1}", (this.SourceUrl ?? "").ToLower(), (this.DestinationFolder ?? "").ToLower());
				MD5 md = MD5.Create();
				byte[] array = md.ComputeHash(Encoding.Default.GetBytes(text));
				Guid guid = new Guid(array);
				return guid.ToString();
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000813C File Offset: 0x0000633C
		public object Clone()
		{
			return base.MemberwiseClone();
		}

		// Token: 0x04000040 RID: 64
		public string Name;

		// Token: 0x04000041 RID: 65
		private string m_fileName;

		// Token: 0x04000042 RID: 66
		public string Version;

		// Token: 0x04000043 RID: 67
		public string Author;

		// Token: 0x04000044 RID: 68
		public string Category;

		// Token: 0x04000045 RID: 69
		public string Description;

		// Token: 0x04000046 RID: 70
		public string Folder;

		// Token: 0x04000047 RID: 71
		public string SourceUrl;

		// Token: 0x04000048 RID: 72
		public string DestinationFolder;

		// Token: 0x04000049 RID: 73
		public string ExtractionFolder;

		// Token: 0x0400004A RID: 74
		public bool NeedsPostProcessing;

		// Token: 0x0400004B RID: 75
		public long TotalBytes;

		// Token: 0x0400004C RID: 76
		public object Tag;
	}
}
