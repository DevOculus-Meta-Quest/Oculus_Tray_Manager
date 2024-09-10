using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace OculusTrayTool;

internal class Win32
{
	[Flags]
	public enum AnimateWindowFlags
	{
		AW_HOR_POSITIVE = 1,
		AW_HOR_NEGATIVE = 2,
		AW_VER_POSITIVE = 4,
		AW_VER_NEGATIVE = 8,
		AW_CENTER = 0x10,
		AW_HIDE = 0x10000,
		AW_ACTIVATE = 0x20000,
		AW_SLIDE = 0x40000,
		AW_BLEND = 0x80000
	}

	public struct SECURITY_ATTRIBUTES
	{
		public uint nLength;

		public IntPtr lpSecurityDescriptor;

		[MarshalAs(UnmanagedType.Bool)]
		public bool bInheritHandle;
	}

	public struct STARTUPINFOW
	{
		public uint cb;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpReserved;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpDesktop;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpTitle;

		public uint dwX;

		public uint dwY;

		public uint dwXSize;

		public uint dwYSize;

		public uint dwXCountChars;

		public uint dwYCountChars;

		public uint dwFillAttribute;

		public uint dwFlags;

		public ushort wShowWindow;

		public ushort cbReserved2;

		public IntPtr lpReserved2;

		public IntPtr hStdInput;

		public IntPtr hStdOutput;

		public IntPtr hStdError;
	}

	public struct PROCESS_INFORMATION
	{
		public IntPtr hProcess;

		public IntPtr hThread;

		public uint dwProcessId;

		public uint dwThreadId;
	}

	public struct WINDOWPLACEMENT
	{
		public int length;

		public int flags;

		public int showCmd;

		public Point ptMinPosition;

		public Point ptMaxPosition;

		public Rectangle rcNormalPosition;
	}

	public const int WS_EX_NOACTIVATE = 134217728;

	public const int WS_EX_TOPMOST = 8;

	public const int WM_MOUSEACTIVATE = 33;

	public const int MA_NOACTIVATE = 3;

	public const int SW_HIDE = 0;

	public const int SW_NORMAL = 1;

	public const int SW_SHOWMINIMIZED = 2;

	public const int SW_RESTORE = 9;

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

	[DllImport("user32.dll")]
	public static extern bool AnimateWindow(IntPtr hWnd, int time, AnimateWindowFlags flags);

	[DllImport("user32.dll")]
	public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetForegroundWindow(IntPtr hWnd);

	[DllImport("kernel32.dll", SetLastError = true)]
	public static extern uint WTSGetActiveConsoleSessionId();

	[DllImport("Wtsapi32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSQueryUserToken(uint SessionId, ref IntPtr phToken);

	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseHandle([In] IntPtr hObject);

	[DllImport("advapi32.dll", EntryPoint = "CreateProcessAsUserW", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateProcessAsUser([In] IntPtr hToken, [In][MarshalAs(UnmanagedType.LPWStr)] string lpApplicationName, string lpCommandLine, [In] IntPtr lpProcessAttributes, [In] IntPtr lpThreadAttributes, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles, uint dwCreationFlags, [In] IntPtr lpEnvironment, [In][MarshalAs(UnmanagedType.LPWStr)] string lpCurrentDirectory, [In] ref STARTUPINFOW lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

	[DllImport("User32.dll")]
	public static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

	[DllImport("User32.dll")]
	public static extern int UnregisterHotKey(IntPtr hwnd, int id);

	[DllImport("user32.dll")]
	public static extern bool HideCaret(IntPtr hWnd);
}
