// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.Resolution
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.ResChanger;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace OculusTrayTool
{
  internal class Resolution
  {
    private static Devmode _oldDevmode;
    private const int EnumCurrentSettings = -1;
    private const int DispChangeSuccessful = 0;
    private const int DispChangeBadmode = -2;
    private const int DispChangeRestart = 1;
    public static bool ResChanged = false;

    [DllImport("User32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool EnumDisplaySettings(
      [MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName,
      [MarshalAs(UnmanagedType.U4)] int iModeNum,
      [In, Out] ref Devmode lpDevMode);

    [DllImport("User32.dll")]
    [return: MarshalAs(UnmanagedType.I4)]
    private static extern int ChangeDisplaySettings([In, Out] ref Devmode lpDevMode, [MarshalAs(UnmanagedType.U4)] uint dwflags);

    public static string[] GetSupportedResolutions()
    {
      List<string> stringList = new List<string>();
      Devmode lpDevMode = new Devmode();
      lpDevMode.dmSize = checked ((ushort) Marshal.SizeOf<Devmode>(lpDevMode));
      int iModeNum = 0;
      string Right = string.Empty;
      while (Resolution.EnumDisplaySettings((string) null, iModeNum, ref lpDevMode))
      {
        string Left = lpDevMode.dmPelsWidth.ToString().Trim() + " x " + lpDevMode.dmPelsHeight.ToString().Trim();
        if (Operators.CompareString(Left, Right, false) != 0)
        {
          if (lpDevMode.dmPelsWidth >= 800U)
            stringList.Add(Left);
          Right = Left;
        }
        checked { ++iModeNum; }
      }
      return stringList.ToArray();
    }

    public static bool ChangeDisplaySettings(int width, int height)
    {
      Resolution._oldDevmode = new Devmode();
      Resolution._oldDevmode.dmSize = checked ((ushort) Marshal.SizeOf<Devmode>(Resolution._oldDevmode));
      Resolution.EnumDisplaySettings((string) null, -1, ref Resolution._oldDevmode);
      Devmode oldDevmode = Resolution._oldDevmode with
      {
        dmPelsWidth = checked ((uint) width),
        dmPelsHeight = checked ((uint) height)
      };
      int num = Resolution.ChangeDisplaySettings(ref oldDevmode, 1U);
      Resolution.ResChanged = false;
      switch (num)
      {
        case -2:
          FrmMain.fmain.AddToListboxAndScroll("Could not change desktop resolution: Mode not supported");
          Log.WriteToLog("Could not change desktop resolution: Mode not supported");
          return false;
        case 0:
          Resolution.ResChanged = true;
          FrmMain.fmain.AddToListboxAndScroll("Resolution change successful");
          Log.WriteToLog("Resolution change successful");
          return true;
        case 1:
          FrmMain.fmain.AddToListboxAndScroll("Could not change desktop resolution: Restart required");
          Log.WriteToLog("Could not change desktop resolution: Restart required");
          return false;
        default:
          FrmMain.fmain.AddToListboxAndScroll("Could not change desktop resolution: Error code = " + Conversions.ToString(num));
          Log.WriteToLog("Could not change desktop resolution: Error code = " + Conversions.ToString(num));
          return false;
      }
    }

    public static void RestoreDisplaySettings()
    {
      Resolution.ChangeDisplaySettings(ref Resolution._oldDevmode, 1U);
    }
  }
}
