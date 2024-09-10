using System;
using System.Runtime.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x0200005C RID: 92
	public class DataDownloadEventArgs : EventArgs
	{
		// Token: 0x0600092B RID: 2347 RVA: 0x00054832 File Offset: 0x00052A32
		public DataDownloadEventArgs(string _fileName, object _tag)
		{
			this.FileName = _fileName;
			this.Tag = RuntimeHelpers.GetObjectValue(_tag);
		}

		// Token: 0x040003E2 RID: 994
		public string FileName;

		// Token: 0x040003E3 RID: 995
		public object Tag;
	}
}
