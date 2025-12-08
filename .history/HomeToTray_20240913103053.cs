// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.HomeToTray
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class HomeToTray
  {
    public static bool HomeIsMinimized = false;
    public static int wHandle;
    private static List<int> MwHandles = new List<int>();
    public static bool ToastShown = false;
    private static Timer CheckHomeMinimzedTimer = new Timer();
    private static bool StartTimer = true;
    private static int c = 0;

    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, HomeToTray.SHOW_WINDOW nCmdShow);

    [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int GetWindowPlacement(
      IntPtr hwnd,
      ref HomeToTray.WINDOWPLACEMENT lpwndpl);

    [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
    private static extern int SetForegroundWindow(int hwnd);

    public static void SendHomeToTrayOnMinimize()
    {
      try
      {
        Process[] processesByName = Process.GetProcessesByName("OculusClient");
        int index = 0;
        while (index < processesByName.Length)
        {
          Process process = processesByName[index];
          IntPtr mainWindowHandle = process.MainWindowHandle;
          if (mainWindowHandle.ToInt32() != 0)
          {
            mainWindowHandle = process.MainWindowHandle;
            HomeToTray.wHandle = mainWindowHandle.ToInt32();
          }
          HomeToTray.WINDOWPLACEMENT lpwndpl;
          HomeToTray.GetWindowPlacement((IntPtr) HomeToTray.wHandle, ref lpwndpl);
          if (lpwndpl.showCmd == 2)
          {
            if (Globals.dbg)
              Log.WriteToLog("Oculus Home minimized, sending " + Conversions.ToString(HomeToTray.wHandle) + " to tray");
            HomeToTray.ShowWindow((IntPtr) HomeToTray.wHandle, HomeToTray.SHOW_WINDOW.SW_HIDE);
            MyProject.Forms.FrmMain.HometoTrayTimer.Enabled = false;
            HomeToTray.HomeIsMinimized = true;
            break;
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("SendHomeToTrayOnMinimize: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void SendHomeToTrayOnStart()
    {
      try
      {
        Process[] processesByName = Process.GetProcessesByName("OculusClient");
        int index = 0;
        while (index < processesByName.Length)
        {
          Process process = processesByName[index];
          IntPtr mainWindowHandle = process.MainWindowHandle;
          if (mainWindowHandle.ToInt32() != 0)
          {
            mainWindowHandle = process.MainWindowHandle;
            HomeToTray.wHandle = mainWindowHandle.ToInt32();
            HomeToTray.WINDOWPLACEMENT lpwndpl;
            HomeToTray.GetWindowPlacement((IntPtr) HomeToTray.wHandle, ref lpwndpl);
            HomeToTray.ShowWindow((IntPtr) HomeToTray.wHandle, HomeToTray.SHOW_WINDOW.SW_HIDE);
            if (Globals.dbg)
              Log.WriteToLog("OculusClient process '" + Conversions.ToString(process.Id) + "' minimized to tray");
            HomeToTray.HomeIsMinimized = true;
            break;
          }
          checked { ++index; }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("SendHomeToTrayOnStart: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    public static void ShowHomeNormal()
    {
      try
      {
        if (Globals.dbg)
          Log.WriteToLog("Restoring Oculus Home");
        HomeToTray.ShowWindow((IntPtr) HomeToTray.wHandle, HomeToTray.SHOW_WINDOW.SW_RESTORE);
        HomeToTray.SetForegroundWindow(HomeToTray.wHandle);
        HomeToTray.HomeIsMinimized = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("ShowHomeNormal: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private static void IsHomeMinimzed(object source, ElapsedEventArgs e)
    {
      FrmMain.fmain.MinimizeHomeWatcher.Stop();
      HomeToTray.CheckHomeMinimzedTimer.Stop();
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
      public HomeToTray.POINTAPI ptMinPosition;
      public HomeToTray.POINTAPI ptMaxPosition;
      public HomeToTray.RECT rcNormalPosition;
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
