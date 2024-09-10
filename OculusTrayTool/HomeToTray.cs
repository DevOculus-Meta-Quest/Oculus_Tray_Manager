using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[StandardModule]
internal sealed class HomeToTray
{
	[Flags]
	private enum SHOW_WINDOW
	{
		SW_HIDE = 0,
		SW_SHOWNORMAL = 1,
		SW_NORMAL = 1,
		SW_SHOWMINIMIZED = 2,
		SW_SHOWMAXIMIZED = 3,
		SW_MAXIMIZE = 3,
		SW_SHOWNOACTIVATE = 4,
		SW_SHOW = 5,
		SW_MINIMIZE = 6,
		SW_SHOWMINNOACTIVE = 7,
		SW_SHOWNA = 8,
		SW_RESTORE = 9,
		SW_SHOWDEFAULT = 0xA,
		SW_FORCEMINIMIZE = 0xB,
		SW_MAX = 0xB
	}

	private struct WINDOWPLACEMENT
	{
		public int Length;

		public int flags;

		public int showCmd;

		public POINTAPI ptMinPosition;

		public POINTAPI ptMaxPosition;

		public RECT rcNormalPosition;
	}

	private struct POINTAPI
	{
		public int x;

		public int y;
	}

	private struct RECT
	{
		public int Left;

		public int Top;

		public int Right;

		public int Bottom;
	}

	public static bool HomeIsMinimized = false;

	public static int wHandle;

	private static List<int> MwHandles = new List<int>();

	public static bool ToastShown = false;

	private static Timer CheckHomeMinimzedTimer = new Timer();

	private static bool StartTimer = true;

	private static int c = 0;

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern bool ShowWindow(IntPtr hWnd, SHOW_WINDOW nCmdShow);

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern int GetWindowPlacement(IntPtr hwnd, ref WINDOWPLACEMENT lpwndpl);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern int SetForegroundWindow(int hwnd);

	public static void SendHomeToTrayOnMinimize()
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			WINDOWPLACEMENT lpwndpl = default(WINDOWPLACEMENT);
			foreach (Process process in processesByName)
			{
				if (process.MainWindowHandle.ToInt32() != 0)
				{
					wHandle = process.MainWindowHandle.ToInt32();
				}
				GetWindowPlacement((IntPtr)wHandle, ref lpwndpl);
				if (lpwndpl.showCmd == 2)
				{
					if (Globals.dbg)
					{
						Log.WriteToLog("Oculus Home minimized, sending " + Conversions.ToString(wHandle) + " to tray");
					}
					ShowWindow((IntPtr)wHandle, SHOW_WINDOW.SW_HIDE);
					MyProject.Forms.FrmMain.HometoTrayTimer.Enabled = false;
					HomeIsMinimized = true;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("SendHomeToTrayOnMinimize: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void SendHomeToTrayOnStart()
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName("OculusClient");
			WINDOWPLACEMENT lpwndpl = default(WINDOWPLACEMENT);
			foreach (Process process in processesByName)
			{
				if (process.MainWindowHandle.ToInt32() != 0)
				{
					wHandle = process.MainWindowHandle.ToInt32();
					GetWindowPlacement((IntPtr)wHandle, ref lpwndpl);
					ShowWindow((IntPtr)wHandle, SHOW_WINDOW.SW_HIDE);
					if (Globals.dbg)
					{
						Log.WriteToLog("OculusClient process '" + Conversions.ToString(process.Id) + "' minimized to tray");
					}
					HomeIsMinimized = true;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("SendHomeToTrayOnStart: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void ShowHomeNormal()
	{
		try
		{
			if (Globals.dbg)
			{
				Log.WriteToLog("Restoring Oculus Home");
			}
			ShowWindow((IntPtr)wHandle, SHOW_WINDOW.SW_RESTORE);
			SetForegroundWindow(wHandle);
			HomeIsMinimized = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("ShowHomeNormal: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private static void IsHomeMinimzed(object source, ElapsedEventArgs e)
	{
		FrmMain.fmain.MinimizeHomeWatcher.Stop();
		CheckHomeMinimzedTimer.Stop();
	}
}
