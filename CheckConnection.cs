// Decompiled with JetBrains decompiler

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
