

using System;
using System.Net;

#nullable disable
namespace MetaQuestTrayTool
{

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
        CheckConnection.HaveiConnection = false;
        flag = false;
      }
      return flag;
    }
  }
}
