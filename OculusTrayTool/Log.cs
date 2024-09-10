using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[StandardModule]
internal sealed class Log
{
	private static object lockObject = RuntimeHelpers.GetObjectValue(new object());

	public static void WriteToLog(string s)
	{
		try
		{
			object obj = lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				using StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\ott.log");
				streamWriter.WriteLine($"{DateTime.Now}: {string.Format(s)}");
				streamWriter.Flush();
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void WriteToMigrateLog(string s)
	{
		try
		{
			object obj = lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				using StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\migrate.log");
				streamWriter.WriteLine($"{DateTime.Now}: {string.Format(s)}");
				streamWriter.Flush();
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void WriteToLinkLog(string s)
	{
		try
		{
			object obj = lockObject;
			ObjectFlowControl.CheckForSyncLockOnValueType(obj);
			bool lockTaken = false;
			try
			{
				Monitor.Enter(obj, ref lockTaken);
				using StreamWriter streamWriter = File.AppendText(Application.StartupPath + "\\AirLinkPatch.log");
				streamWriter.WriteLine($"{DateTime.Now}: {string.Format(s)}");
				streamWriter.Flush();
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(obj);
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}
}
