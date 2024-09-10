using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace OculusTrayTool
{
	// Token: 0x02000061 RID: 97
	internal class Win32
	{
		// Token: 0x060009AB RID: 2475
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowPlacement(IntPtr hWnd, ref Win32.WINDOWPLACEMENT lpwndpl);

		// Token: 0x060009AC RID: 2476
		[DllImport("user32.dll")]
		public static extern bool AnimateWindow(IntPtr hWnd, int time, Win32.AnimateWindowFlags flags);

		// Token: 0x060009AD RID: 2477
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x060009AE RID: 2478
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x060009AF RID: 2479
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint WTSGetActiveConsoleSessionId();

		// Token: 0x060009B0 RID: 2480
		[DllImport("Wtsapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WTSQueryUserToken(uint SessionId, ref IntPtr phToken);

		// Token: 0x060009B1 RID: 2481
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseHandle([In] IntPtr hObject);

		// Token: 0x060009B2 RID: 2482
		[DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUserW", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateProcessAsUser([In] IntPtr hToken, [MarshalAs(UnmanagedType.LPWStr)] [In] string lpApplicationName, string lpCommandLine, [In] IntPtr lpProcessAttributes, [In] IntPtr lpThreadAttributes, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles, uint dwCreationFlags, [In] IntPtr lpEnvironment, [MarshalAs(UnmanagedType.LPWStr)] [In] string lpCurrentDirectory, [In] ref Win32.STARTUPINFOW lpStartupInfo, out Win32.PROCESS_INFORMATION lpProcessInformation);

		// Token: 0x060009B3 RID: 2483
		[DllImport("User32.dll")]
		public static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

		// Token: 0x060009B4 RID: 2484
		[DllImport("User32.dll")]
		public static extern int UnregisterHotKey(IntPtr hwnd, int id);

		// Token: 0x060009B5 RID: 2485
		[DllImport("user32.dll")]
		public static extern bool HideCaret(IntPtr hWnd);

		// Token: 0x04000418 RID: 1048
		public const int WS_EX_NOACTIVATE = 134217728;

		// Token: 0x04000419 RID: 1049
		public const int WS_EX_TOPMOST = 8;

		// Token: 0x0400041A RID: 1050
		public const int WM_MOUSEACTIVATE = 33;

		// Token: 0x0400041B RID: 1051
		public const int MA_NOACTIVATE = 3;

		// Token: 0x0400041C RID: 1052
		public const int SW_HIDE = 0;

		// Token: 0x0400041D RID: 1053
		public const int SW_NORMAL = 1;

		// Token: 0x0400041E RID: 1054
		public const int SW_SHOWMINIMIZED = 2;

		// Token: 0x0400041F RID: 1055
		public const int SW_RESTORE = 9;

		// Token: 0x020000A0 RID: 160
		[Flags]
		public enum AnimateWindowFlags
		{
			// Token: 0x04000543 RID: 1347
			AW_HOR_POSITIVE = 1,
			// Token: 0x04000544 RID: 1348
			AW_HOR_NEGATIVE = 2,
			// Token: 0x04000545 RID: 1349
			AW_VER_POSITIVE = 4,
			// Token: 0x04000546 RID: 1350
			AW_VER_NEGATIVE = 8,
			// Token: 0x04000547 RID: 1351
			AW_CENTER = 16,
			// Token: 0x04000548 RID: 1352
			AW_HIDE = 65536,
			// Token: 0x04000549 RID: 1353
			AW_ACTIVATE = 131072,
			// Token: 0x0400054A RID: 1354
			AW_SLIDE = 262144,
			// Token: 0x0400054B RID: 1355
			AW_BLEND = 524288
		}

		// Token: 0x020000A1 RID: 161
		public struct SECURITY_ATTRIBUTES
		{
			// Token: 0x0400054C RID: 1356
			public uint nLength;

			// Token: 0x0400054D RID: 1357
			public IntPtr lpSecurityDescriptor;

			// Token: 0x0400054E RID: 1358
			[MarshalAs(UnmanagedType.Bool)]
			public bool bInheritHandle;
		}

		// Token: 0x020000A2 RID: 162
		public struct STARTUPINFOW
		{
			// Token: 0x0400054F RID: 1359
			public uint cb;

			// Token: 0x04000550 RID: 1360
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpReserved;

			// Token: 0x04000551 RID: 1361
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpDesktop;

			// Token: 0x04000552 RID: 1362
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpTitle;

			// Token: 0x04000553 RID: 1363
			public uint dwX;

			// Token: 0x04000554 RID: 1364
			public uint dwY;

			// Token: 0x04000555 RID: 1365
			public uint dwXSize;

			// Token: 0x04000556 RID: 1366
			public uint dwYSize;

			// Token: 0x04000557 RID: 1367
			public uint dwXCountChars;

			// Token: 0x04000558 RID: 1368
			public uint dwYCountChars;

			// Token: 0x04000559 RID: 1369
			public uint dwFillAttribute;

			// Token: 0x0400055A RID: 1370
			public uint dwFlags;

			// Token: 0x0400055B RID: 1371
			public ushort wShowWindow;

			// Token: 0x0400055C RID: 1372
			public ushort cbReserved2;

			// Token: 0x0400055D RID: 1373
			public IntPtr lpReserved2;

			// Token: 0x0400055E RID: 1374
			public IntPtr hStdInput;

			// Token: 0x0400055F RID: 1375
			public IntPtr hStdOutput;

			// Token: 0x04000560 RID: 1376
			public IntPtr hStdError;
		}

		// Token: 0x020000A3 RID: 163
		public struct PROCESS_INFORMATION
		{
			// Token: 0x04000561 RID: 1377
			public IntPtr hProcess;

			// Token: 0x04000562 RID: 1378
			public IntPtr hThread;

			// Token: 0x04000563 RID: 1379
			public uint dwProcessId;

			// Token: 0x04000564 RID: 1380
			public uint dwThreadId;
		}

		// Token: 0x020000A4 RID: 164
		public struct WINDOWPLACEMENT
		{
			// Token: 0x04000565 RID: 1381
			public int length;

			// Token: 0x04000566 RID: 1382
			public int flags;

			// Token: 0x04000567 RID: 1383
			public int showCmd;

			// Token: 0x04000568 RID: 1384
			public Point ptMinPosition;

			// Token: 0x04000569 RID: 1385
			public Point ptMaxPosition;

			// Token: 0x0400056A RID: 1386
			public Rectangle rcNormalPosition;
		}
	}
}
