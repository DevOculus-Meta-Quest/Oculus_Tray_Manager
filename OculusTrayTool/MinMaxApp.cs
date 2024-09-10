using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000039 RID: 57
	[StandardModule]
	internal sealed class MinMaxApp
	{
		// Token: 0x060004F0 RID: 1264
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, MinMaxApp.SHOW_WINDOW nCmdShow);

		// Token: 0x060004F1 RID: 1265
		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetWindowPlacement(IntPtr hwnd, ref MinMaxApp.WINDOWPLACEMENT lpwndpl);

		// Token: 0x060004F2 RID: 1266
		[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int SetForegroundWindow(int hwnd);

		// Token: 0x060004F3 RID: 1267 RVA: 0x00025A34 File Offset: 0x00023C34
		public static void MinimizeApp(string app)
		{
			checked
			{
				try
				{
					bool flag = MinMaxApp.MinimizeCount == 2;
					if (flag)
					{
						bool dbg = Globals.dbg;
						if (dbg)
						{
							Log.WriteToLog(app + " has been minimized twice, exiting");
						}
						FrmMain.fmain.mirrorTimer.Enabled = false;
					}
					else
					{
						bool flag2 = (MinMaxApp.SetMirrorRetry >= 5) & (MinMaxApp.MinimizeCount == 0);
						if (flag2)
						{
							Log.WriteToLog(string.Concat(new string[]
							{
								"MinimizeApp: ",
								app,
								": Re-tried ",
								Conversions.ToString(MinMaxApp.SetMirrorRetry),
								" times then gave up. Check the process in Task Manager and verify the .exe path and name."
							}));
							FrmMain.fmain.mirrorTimer.Enabled = false;
						}
						else
						{
							bool flag3 = false;
							foreach (Process process in Process.GetProcessesByName(app))
							{
								bool flag4 = process.MainWindowHandle.ToInt32() != 0;
								if (flag4)
								{
									MinMaxApp.wHandle = process.MainWindowHandle.ToInt32();
									MinMaxApp.WINDOWPLACEMENT windowplacement;
									MinMaxApp.GetWindowPlacement((IntPtr)MinMaxApp.wHandle, ref windowplacement);
									MinMaxApp.ShowWindow((IntPtr)MinMaxApp.wHandle, MinMaxApp.SHOW_WINDOW.SW_SHOWMINIMIZED);
									Log.WriteToLog("MinimizeApp: " + app + ": Minimized to taskbar");
									FrmMain.fmain.AddToListboxAndScroll(app + ": Minimized to taskbar");
									flag3 = true;
									MinMaxApp.MinimizeCount++;
									break;
								}
							}
							bool flag5 = !flag3;
							if (flag5)
							{
								Log.WriteToLog("MinimizeApp: " + app + ": Sleeping 1 second and re-trying");
								Thread.Sleep(1000);
								MinMaxApp.SetMirrorRetry++;
								MinMaxApp.MinimizeApp(app);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Log.WriteToLog("MinimizeApp: " + app + ": " + ex.Message);
					FrmMain.fmain.AddToListboxAndScroll("MinimizeApp: " + app + ": " + ex.Message);
				}
			}
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00025C58 File Offset: 0x00023E58
		public static void MaximizeApp(string app)
		{
			try
			{
				foreach (Process process in Process.GetProcessesByName(app))
				{
					bool flag = process.MainWindowHandle.ToInt32() != 0;
					if (flag)
					{
						MinMaxApp.wHandle = process.MainWindowHandle.ToInt32();
						MinMaxApp.WINDOWPLACEMENT windowplacement;
						MinMaxApp.GetWindowPlacement((IntPtr)MinMaxApp.wHandle, ref windowplacement);
						MinMaxApp.ShowWindow((IntPtr)MinMaxApp.wHandle, MinMaxApp.SHOW_WINDOW.SW_SHOWMAXIMIZED);
						break;
					}
					MinMaxApp.MaximizeApp(app);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("MaximizeApp: " + app + ": " + ex.Message);
			}
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00025D24 File Offset: 0x00023F24
		public static void ShowDefault(string app)
		{
			try
			{
				foreach (Process process in Process.GetProcessesByName(app))
				{
					bool flag = process.MainWindowHandle.ToInt32() != 0;
					if (flag)
					{
						MinMaxApp.wHandle = process.MainWindowHandle.ToInt32();
						MinMaxApp.WINDOWPLACEMENT windowplacement;
						MinMaxApp.GetWindowPlacement((IntPtr)MinMaxApp.wHandle, ref windowplacement);
						MinMaxApp.ShowWindow((IntPtr)MinMaxApp.wHandle, MinMaxApp.SHOW_WINDOW.SW_SHOWDEFAULT);
						Log.WriteToLog(app + ": Window default");
						break;
					}
					MinMaxApp.ShowDefault(app);
				}
			}
			catch (Exception ex)
			{
				Log.WriteToLog("ShowDefault: " + app + ": " + ex.Message);
			}
		}

		// Token: 0x040001D6 RID: 470
		public static int wHandle;

		// Token: 0x040001D7 RID: 471
		public static bool ToastShown = false;

		// Token: 0x040001D8 RID: 472
		public static int SetMirrorRetry = 0;

		// Token: 0x040001D9 RID: 473
		public static int MinimizeCount = 0;

		// Token: 0x0200007F RID: 127
		[Flags]
		private enum SHOW_WINDOW
		{
			// Token: 0x04000488 RID: 1160
			SW_HIDE = 0,
			// Token: 0x04000489 RID: 1161
			SW_SHOWNORMAL = 1,
			// Token: 0x0400048A RID: 1162
			SW_NORMAL = 1,
			// Token: 0x0400048B RID: 1163
			SW_SHOWMINIMIZED = 2,
			// Token: 0x0400048C RID: 1164
			SW_SHOWMAXIMIZED = 3,
			// Token: 0x0400048D RID: 1165
			SW_MAXIMIZE = 3,
			// Token: 0x0400048E RID: 1166
			SW_SHOWNOACTIVATE = 4,
			// Token: 0x0400048F RID: 1167
			SW_SHOW = 5,
			// Token: 0x04000490 RID: 1168
			SW_MINIMIZE = 6,
			// Token: 0x04000491 RID: 1169
			SW_SHOWMINNOACTIVE = 7,
			// Token: 0x04000492 RID: 1170
			SW_SHOWNA = 8,
			// Token: 0x04000493 RID: 1171
			SW_RESTORE = 9,
			// Token: 0x04000494 RID: 1172
			SW_SHOWDEFAULT = 10,
			// Token: 0x04000495 RID: 1173
			SW_FORCEMINIMIZE = 11,
			// Token: 0x04000496 RID: 1174
			SW_MAX = 11
		}

		// Token: 0x02000080 RID: 128
		private struct WINDOWPLACEMENT
		{
			// Token: 0x04000497 RID: 1175
			public int Length;

			// Token: 0x04000498 RID: 1176
			public int flags;

			// Token: 0x04000499 RID: 1177
			public int showCmd;

			// Token: 0x0400049A RID: 1178
			public MinMaxApp.POINTAPI ptMinPosition;

			// Token: 0x0400049B RID: 1179
			public MinMaxApp.POINTAPI ptMaxPosition;

			// Token: 0x0400049C RID: 1180
			public MinMaxApp.RECT rcNormalPosition;
		}

		// Token: 0x02000081 RID: 129
		private struct POINTAPI
		{
			// Token: 0x0400049D RID: 1181
			public int x;

			// Token: 0x0400049E RID: 1182
			public int y;
		}

		// Token: 0x02000082 RID: 130
		private struct RECT
		{
			// Token: 0x0400049F RID: 1183
			public int Left;

			// Token: 0x040004A0 RID: 1184
			public int Top;

			// Token: 0x040004A1 RID: 1185
			public int Right;

			// Token: 0x040004A2 RID: 1186
			public int Bottom;
		}
	}
}
