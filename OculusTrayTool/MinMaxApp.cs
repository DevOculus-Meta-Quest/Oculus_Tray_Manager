using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[StandardModule]
internal sealed class MinMaxApp
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

	public static int wHandle;

	public static bool ToastShown = false;

	public static int SetMirrorRetry = 0;

	public static int MinimizeCount = 0;

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern bool ShowWindow(IntPtr hWnd, SHOW_WINDOW nCmdShow);

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern int GetWindowPlacement(IntPtr hwnd, ref WINDOWPLACEMENT lpwndpl);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern int SetForegroundWindow(int hwnd);

	public static void MinimizeApp(string app)
	{
		checked
		{
			try
			{
				if (MinimizeCount == 2)
				{
					if (Globals.dbg)
					{
						Log.WriteToLog(app + " has been minimized twice, exiting");
					}
					FrmMain.fmain.mirrorTimer.Enabled = false;
					return;
				}
				if ((SetMirrorRetry >= 5) & (MinimizeCount == 0))
				{
					Log.WriteToLog("MinimizeApp: " + app + ": Re-tried " + Conversions.ToString(SetMirrorRetry) + " times then gave up. Check the process in Task Manager and verify the .exe path and name.");
					FrmMain.fmain.mirrorTimer.Enabled = false;
					return;
				}
				bool flag = false;
				Process[] processesByName = Process.GetProcessesByName(app);
				WINDOWPLACEMENT lpwndpl = default(WINDOWPLACEMENT);
				foreach (Process process in processesByName)
				{
					if (process.MainWindowHandle.ToInt32() != 0)
					{
						wHandle = process.MainWindowHandle.ToInt32();
						GetWindowPlacement((IntPtr)wHandle, ref lpwndpl);
						ShowWindow((IntPtr)wHandle, SHOW_WINDOW.SW_SHOWMINIMIZED);
						Log.WriteToLog("MinimizeApp: " + app + ": Minimized to taskbar");
						FrmMain.fmain.AddToListboxAndScroll(app + ": Minimized to taskbar");
						flag = true;
						MinimizeCount++;
						break;
					}
				}
				if (!flag)
				{
					Log.WriteToLog("MinimizeApp: " + app + ": Sleeping 1 second and re-trying");
					Thread.Sleep(1000);
					SetMirrorRetry++;
					MinimizeApp(app);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Log.WriteToLog("MinimizeApp: " + app + ": " + ex2.Message);
				FrmMain.fmain.AddToListboxAndScroll("MinimizeApp: " + app + ": " + ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void MaximizeApp(string app)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName(app);
			WINDOWPLACEMENT lpwndpl = default(WINDOWPLACEMENT);
			foreach (Process process in processesByName)
			{
				if (process.MainWindowHandle.ToInt32() != 0)
				{
					wHandle = process.MainWindowHandle.ToInt32();
					GetWindowPlacement((IntPtr)wHandle, ref lpwndpl);
					ShowWindow((IntPtr)wHandle, SHOW_WINDOW.SW_SHOWMAXIMIZED);
					break;
				}
				MaximizeApp(app);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("MaximizeApp: " + app + ": " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void ShowDefault(string app)
	{
		try
		{
			Process[] processesByName = Process.GetProcessesByName(app);
			WINDOWPLACEMENT lpwndpl = default(WINDOWPLACEMENT);
			foreach (Process process in processesByName)
			{
				if (process.MainWindowHandle.ToInt32() != 0)
				{
					wHandle = process.MainWindowHandle.ToInt32();
					GetWindowPlacement((IntPtr)wHandle, ref lpwndpl);
					ShowWindow((IntPtr)wHandle, SHOW_WINDOW.SW_SHOWDEFAULT);
					Log.WriteToLog(app + ": Window default");
					break;
				}
				ShowDefault(app);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Log.WriteToLog("ShowDefault: " + app + ": " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}
}
