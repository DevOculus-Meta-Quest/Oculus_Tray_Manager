
using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace OculusTrayTool
{
  public class DataDownloadEventArgs : EventArgs
  {
    public string FileName;
    public object Tag;

    public DataDownloadEventArgs(string _fileName, object _tag)
    {
      this.FileName = _fileName;
      this.Tag = RuntimeHelpers.GetObjectValue(_tag);
    }
  }
}
