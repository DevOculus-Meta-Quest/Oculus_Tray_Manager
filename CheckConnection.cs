// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.CheckConnection
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Net;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class CheckConnection
  {
    public static bool HaveiConnection;

    public static bool CheckForInternetConnection()
    {
      bool flag;
      try
      {
        using (WebClient webClient = new WebClient())
        {
          using (webClient.OpenRead("http://www.google.com"))
          {
            CheckConnection.HaveiConnection = true;
            flag = true;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        CheckConnection.HaveiConnection = false;
        flag = false;
        ProjectData.ClearProjectError();
      }
      return flag;
    }
  }
}
