// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.Win32
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;
using System.Drawing;
using System.Runtime.InteropServices;

#nullable disable
namespace OculusTrayTool
{
  internal class Win32
  {
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
    public static extern bool GetWindowPlacement(IntPtr hWnd, ref Win32.WINDOWPLACEMENT lpwndpl);

    [DllImport("user32.dll")]
    public static extern bool AnimateWindow(IntPtr hWnd, int time, Win32.AnimateWindowFlags flags);

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
    public static extern bool CreateProcessAsUser(
      [In] IntPtr hToken,
      [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
      string lpCommandLine,
      [In] IntPtr lpProcessAttributes,
      [In] IntPtr lpThreadAttributes,
      [MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
      uint dwCreationFlags,
      [In] IntPtr lpEnvironment,
      [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
      [In] ref Win32.STARTUPINFOW lpStartupInfo,
      out Win32.PROCESS_INFORMATION lpProcessInformation);

    [DllImport("User32.dll")]
    public static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

    [DllImport("User32.dll")]
    public static extern int UnregisterHotKey(IntPtr hwnd, int id);

    [DllImport("user32.dll")]
    public static extern bool HideCaret(IntPtr hWnd);

    [Flags]
    public enum AnimateWindowFlags
    {
      AW_HOR_POSITIVE = 1,
      AW_HOR_NEGATIVE = 2,
      AW_VER_POSITIVE = 4,
      AW_VER_NEGATIVE = 8,
      AW_CENTER = 16, // 0x00000010
      AW_HIDE = 65536, // 0x00010000
      AW_ACTIVATE = 131072, // 0x00020000
      AW_SLIDE = 262144, // 0x00040000
      AW_BLEND = 524288, // 0x00080000
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
  }
}
