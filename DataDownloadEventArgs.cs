// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.DataDownloadEventArgs
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

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
