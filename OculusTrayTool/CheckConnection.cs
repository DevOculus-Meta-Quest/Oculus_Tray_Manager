using System;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x0200000B RID: 11
	[StandardModule]
	internal sealed class CheckConnection
	{
		// Token: 0x06000154 RID: 340 RVA: 0x0000620C File Offset: 0x0000440C
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

		// Token: 0x0400000E RID: 14
		public static bool HaveiConnection;
	}
}
