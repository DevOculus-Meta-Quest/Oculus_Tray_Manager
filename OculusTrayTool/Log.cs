using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000056 RID: 86
	[StandardModule]
	internal sealed class Log
	{
		// Token: 0x06000806 RID: 2054 RVA: 0x0004A484 File Offset: 0x00048684
		public static void WriteToLog(string s)
		{
			try
			{
				object obj = Log.lockObject;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					using (StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\ott.log"))
					{
						streamWriter.WriteLine(string.Format("{0}: {1}", DateTime.Now, string.Format(s, new object[0])));
						streamWriter.Flush();
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0004A548 File Offset: 0x00048748
		public static void WriteToMigrateLog(string s)
		{
			try
			{
				object obj = Log.lockObject;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					using (StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\migrate.log"))
					{
						streamWriter.WriteLine(string.Format("{0}: {1}", DateTime.Now, string.Format(s, new object[0])));
						streamWriter.Flush();
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x0004A60C File Offset: 0x0004880C
		public static void WriteToLinkLog(string s)
		{
			try
			{
				object obj = Log.lockObject;
				ObjectFlowControl.CheckForSyncLockOnValueType(obj);
				lock (obj)
				{
					using (StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\AirLinkPatch.log"))
					{
						streamWriter.WriteLine(string.Format("{0}: {1}", DateTime.Now, string.Format(s, new object[0])));
						streamWriter.Flush();
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x04000368 RID: 872
		private static object lockObject = RuntimeHelpers.GetObjectValue(new object());
	}
}
