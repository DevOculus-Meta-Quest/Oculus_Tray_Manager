using System;
using System.Runtime.CompilerServices;

namespace OculusTrayTool;

public class DataDownloadEventArgs : EventArgs
{
	public string FileName;

	public object Tag;

	public DataDownloadEventArgs(string _fileName, object _tag)
	{
		FileName = _fileName;
		Tag = RuntimeHelpers.GetObjectValue(_tag);
	}
}
