// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.MinMaxApp
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class MinMaxApp
  {
    public static int wHandle;
    public static bool ToastShown = false;
    public static int SetMirrorRetry = 0;
    public static int MinimizeCount = 0;

    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, MinMaxApp.SHOW_WINDOW nCmdShow);

    [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int GetWindowPlacement(IntPtr hwnd, ref MinMaxApp.WINDOWPLACEMENT lpwndpl);

    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int SetForegroundWindow(int hwnd);

    public static void MinimizeApp(string app)
    {
      try
      {
        if (MinMaxApp.MinimizeCount == 2)
        {
          if (Globals.dbg)
            Log.WriteToLog(app + " has been minimized twice, exiting");
          FrmMain.fmain.mirrorTimer.Enabled = false;
        }
        else if (MinMaxApp.SetMirrorRetry >= 5 & MinMaxApp.MinimizeCount == 0)
        {
          Log.WriteToLog("MinimizeApp: " + app + ": Re-tried " + Conversions.ToString(MinMaxApp.SetMirrorRetry) + " times then gave up. Check the process in Task Manager and verify the .exe path and name.");
          FrmMain.fmain.mirrorTimer.Enabled = false;
        }
        else
        {
          bool flag = false;
          Process[] processesByName = Process.GetProcessesByName(app);
          int index = 0;
          while (index < processesByName.Length)
          {
            Process process = processesByName[index];
            IntPtr mainWindowHandle = process.MainWindowHandle;
            if (mainWindowHandle.ToInt32() != 0)
            {
              mainWindowHandle = process.MainWindowHandle;
              MinMaxApp.wHandle = mainWindowHandle.ToInt32();
              MinMaxApp.WINDOWPLACEMENT lpwndpl;
              MinMaxApp.GetWindowPlacement((IntPtr) MinMaxApp.wHandle, ref lpwndpl);
              MinMaxApp.ShowWindow((IntPtr) MinMaxApp.wHandle, MinMaxApp.SHOW_WINDOW.SW_SHOWMINIMIZED);
              Log.WriteToLog("MinimizeApp: " + app + ": Minimized to taskbar");
              FrmMain.fmain.AddToListboxAndScroll(app + ": Minimized to taskbar");
              flag = true;
              checked { ++MinMaxApp.MinimizeCount; }
              break;
            }
            checked { ++index; }
          }
          if (!flag)
          {
            Log.WriteToLog("MinimizeApp: " + app + ": Sleeping 1 second and re-trying");
            Thread.Sleep(1000);
            checked { ++MinMaxApp.SetMirrorRetry; }
            MinMaxApp.MinimizeApp(app);
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("MinimizeApp: " + app + ": " + exception.Message);
        FrmMain.fmain.AddToListboxAndScroll("MinimizeApp: " + app + ": " + exception.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void MaximizeApp(string app)
    {
      try
      {
        Process[] processesByName = Process.GetProcessesByName(app);
        int index = 0;
        while (index < processesByName.Length)
        {
          Process process = processesByName[index];
          IntPtr mainWindowHandle = process.MainWindowHandle;
          if (mainWindowHandle.ToInt32() != 0)
          {
            mainWindowHandle = process.MainWindowHandle;
            MinMaxApp.wHandle = mainWindowHandle.ToInt32();
            MinMaxApp.WINDOWPLACEMENT lpwndpl;
            MinMaxApp.GetWindowPlacement((IntPtr) MinMaxApp.wHandle, ref lpwndpl);
            MinMaxApp.ShowWindow((IntPtr) MinMaxApp.wHandle, MinMaxApp.SHOW_WINDOW.SW_SHOWMAXIMIZED);
            break;
          }
          MinMaxApp.MaximizeApp(app);
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("MaximizeApp: " + app + ": " + exception.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void ShowDefault(string app)
    {
      try
      {
        Process[] processesByName = Process.GetProcessesByName(app);
        int index = 0;
        while (index < processesByName.Length)
        {
          Process process = processesByName[index];
          IntPtr mainWindowHandle = process.MainWindowHandle;
          if (mainWindowHandle.ToInt32() != 0)
          {
            mainWindowHandle = process.MainWindowHandle;
            MinMaxApp.wHandle = mainWindowHandle.ToInt32();
            MinMaxApp.WINDOWPLACEMENT lpwndpl;
            MinMaxApp.GetWindowPlacement((IntPtr) MinMaxApp.wHandle, ref lpwndpl);
            MinMaxApp.ShowWindow((IntPtr) MinMaxApp.wHandle, MinMaxApp.SHOW_WINDOW.SW_SHOWDEFAULT);
            Log.WriteToLog(app + ": Window default");
            break;
          }
          MinMaxApp.ShowDefault(app);
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("ShowDefault: " + app + ": " + exception.Message);
        ProjectData.ClearProjectError();
      }
    }

    [Flags]
    private enum SHOW_WINDOW
    {
      SW_HIDE = 0,
      SW_SHOWNORMAL = 1,
      SW_NORMAL = SW_SHOWNORMAL, // 0x00000001
      SW_SHOWMINIMIZED = 2,
      SW_SHOWMAXIMIZED = SW_SHOWMINIMIZED | SW_NORMAL, // 0x00000003
      SW_MAXIMIZE = SW_SHOWMAXIMIZED, // 0x00000003
      SW_SHOWNOACTIVATE = 4,
      SW_SHOW = SW_SHOWNOACTIVATE | SW_NORMAL, // 0x00000005
      SW_MINIMIZE = SW_SHOWNOACTIVATE | SW_SHOWMINIMIZED, // 0x00000006
      SW_SHOWMINNOACTIVE = SW_MINIMIZE | SW_NORMAL, // 0x00000007
      SW_SHOWNA = 8,
      SW_RESTORE = SW_SHOWNA | SW_NORMAL, // 0x00000009
      SW_SHOWDEFAULT = SW_SHOWNA | SW_SHOWMINIMIZED, // 0x0000000A
      SW_FORCEMINIMIZE = SW_SHOWDEFAULT | SW_NORMAL, // 0x0000000B
      SW_MAX = SW_FORCEMINIMIZE, // 0x0000000B
    }

    private struct WINDOWPLACEMENT
    {
      public int Length;
      public int flags;
      public int showCmd;
      public MinMaxApp.POINTAPI ptMinPosition;
      public MinMaxApp.POINTAPI ptMaxPosition;
      public MinMaxApp.RECT rcNormalPosition;
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
  }
}
