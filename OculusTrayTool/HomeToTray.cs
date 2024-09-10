using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool
{
	// Token: 0x0200002D RID: 45
	[StandardModule]
	internal sealed class HomeToTray
	{
		// Token: 0x060003FD RID: 1021
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, HomeToTray.SHOW_WINDOW nCmdShow);

		// Token: 0x060003FE RID: 1022
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetWindowPlacement(IntPtr hwnd, ref HomeToTray.WINDOWPLACEMENT lpwndpl);

		// Token: 0x060003FF RID: 1023
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int SetForegroundWindow(int hwnd);

		// Token: 0x06000400 RID: 1024 RVA: 0x0001B950 File Offset: 0x00019B50
		public static void SendHomeToTrayOnMinimize()
		{
			try
			{
				foreach (Process process in Process.GetProcessesByName("OculusClient"))
				{
					bool flag = process.MainWindowHandle.ToInt32() != 0;
					if (flag)
					{
						HomeToTray.wHandle = process.MainWindowHandle.ToInt32();
					}
					HomeToTray.WINDOWPLACEMENT windowplacement;
					HomeToTray.GetWindowPlacement((IntPtr)HomeToTray.wHandle, ref windowplacement);
					bool flag2 = windowplacement.showCmd == 2;
					if (flag2)
					{
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToLog("Oculus Home minimized, sending " + Conversions.ToString(HomeToTray.wHandle) + " to tray");
						}
						HomeToTray.ShowWindow((IntPtr)HomeToTray.wHandle, HomeToTray.SHOW_WINDOW.SW_HIDE);
						MyProject.Forms.FrmMain.HometoTrayTimer.Enabled = false;
						HomeToTray.HomeIsMinimized = true;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("SendHomeToTrayOnMinimize: " + ex.Message);
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x0001BA6C File Offset: 0x00019C6C
		public static void SendHomeToTrayOnStart()
		{
			try
			{
				foreach (Process process in Process.GetProcessesByName("OculusClient"))
				{
					bool flag = process.MainWindowHandle.ToInt32() != 0;
					if (flag)
					{
						HomeToTray.wHandle = process.MainWindowHandle.ToInt32();
						HomeToTray.WINDOWPLACEMENT windowplacement;
						HomeToTray.GetWindowPlacement((IntPtr)HomeToTray.wHandle, ref windowplacement);
						HomeToTray.ShowWindow((IntPtr)HomeToTray.wHandle, HomeToTray.SHOW_WINDOW.SW_HIDE);
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToLog("OculusClient process '" + Conversions.ToString(process.Id) + "' minimized to tray");
						}
						HomeToTray.HomeIsMinimized = true;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("SendHomeToTrayOnStart: " + ex.Message);
			}
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x0001BB64 File Offset: 0x00019D64
		public static void ShowHomeNormal()
		{
			try
			{
				bool dbg = Globals.dbg;
				if (dbg)
				{
					Log.WriteToLog("Restoring Oculus Home");
				}
				HomeToTray.ShowWindow((IntPtr)HomeToTray.wHandle, HomeToTray.SHOW_WINDOW.SW_RESTORE);
				HomeToTray.SetForegroundWindow(HomeToTray.wHandle);
				HomeToTray.HomeIsMinimized = false;
			}
			catch (Exception ex)
			{
				Log.WriteToLog("ShowHomeNormal: " + ex.Message);
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0001BBE4 File Offset: 0x00019DE4
		private static void IsHomeMinimzed(object source, ElapsedEventArgs e)
		{
			FrmMain.fmain.MinimizeHomeWatcher.Stop();
			HomeToTray.CheckHomeMinimzedTimer.Stop();
		}

		// Token: 0x04000161 RID: 353
		public static bool HomeIsMinimized = false;

		// Token: 0x04000162 RID: 354
		public static int wHandle;

		// Token: 0x04000163 RID: 355
		private static List<int> MwHandles = new List<int>();

		// Token: 0x04000164 RID: 356
		public static bool ToastShown = false;

		// Token: 0x04000165 RID: 357
		private static Timer CheckHomeMinimzedTimer = new Timer();

		// Token: 0x04000166 RID: 358
		private static bool StartTimer = true;

		// Token: 0x04000167 RID: 359
		private static int c = 0;

		// Token: 0x02000071 RID: 113
		[Flags]
		private enum SHOW_WINDOW
		{
			// Token: 0x0400045B RID: 1115
			SW_HIDE = 0,
			// Token: 0x0400045C RID: 1116
			SW_SHOWNORMAL = 1,
			// Token: 0x0400045D RID: 1117
			SW_NORMAL = 1,
			// Token: 0x0400045E RID: 1118
			SW_SHOWMINIMIZED = 2,
			// Token: 0x0400045F RID: 1119
			SW_SHOWMAXIMIZED = 3,
			// Token: 0x04000460 RID: 1120
			SW_MAXIMIZE = 3,
			// Token: 0x04000461 RID: 1121
			SW_SHOWNOACTIVATE = 4,
			// Token: 0x04000462 RID: 1122
			SW_SHOW = 5,
			// Token: 0x04000463 RID: 1123
			SW_MINIMIZE = 6,
			// Token: 0x04000464 RID: 1124
			SW_SHOWMINNOACTIVE = 7,
			// Token: 0x04000465 RID: 1125
			SW_SHOWNA = 8,
			// Token: 0x04000466 RID: 1126
			SW_RESTORE = 9,
			// Token: 0x04000467 RID: 1127
			SW_SHOWDEFAULT = 10,
			// Token: 0x04000468 RID: 1128
			SW_FORCEMINIMIZE = 11,
			// Token: 0x04000469 RID: 1129
			SW_MAX = 11
		}

		// Token: 0x02000072 RID: 114
		private struct WINDOWPLACEMENT
		{
			// Token: 0x0400046A RID: 1130
			public int Length;

			// Token: 0x0400046B RID: 1131
			public int flags;

			// Token: 0x0400046C RID: 1132
			public int showCmd;

			// Token: 0x0400046D RID: 1133
			public HomeToTray.POINTAPI ptMinPosition;

			// Token: 0x0400046E RID: 1134
			public HomeToTray.POINTAPI ptMaxPosition;

			// Token: 0x0400046F RID: 1135
			public HomeToTray.RECT rcNormalPosition;
		}

		// Token: 0x02000073 RID: 115
		private struct POINTAPI
		{
			// Token: 0x04000470 RID: 1136
			public int x;

			// Token: 0x04000471 RID: 1137
			public int y;
		}

		// Token: 0x02000074 RID: 116
		private struct RECT
		{
			// Token: 0x04000472 RID: 1138
			public int Left;

			// Token: 0x04000473 RID: 1139
			public int Top;

			// Token: 0x04000474 RID: 1140
			public int Right;

			// Token: 0x04000475 RID: 1141
			public int Bottom;
		}
	}
}
