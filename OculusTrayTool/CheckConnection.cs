using System;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[StandardModule]
internal sealed class CheckConnection
{
	public static bool HaveiConnection;

	public static bool CheckForInternetConnection()
	{
		bool result;
		try
		{
			using WebClient webClient = new WebClient();
			using (webClient.OpenRead("http://www.google.com"))
			{
				HaveiConnection = true;
				result = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			HaveiConnection = false;
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
