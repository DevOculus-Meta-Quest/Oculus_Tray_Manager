using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.ResChanger;

namespace OculusTrayTool;

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
	private static extern bool EnumDisplaySettings([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, [MarshalAs(UnmanagedType.U4)] int iModeNum, [In][Out] ref Devmode lpDevMode);

	[DllImport("User32.dll")]
	[return: MarshalAs(UnmanagedType.I4)]
	private static extern int ChangeDisplaySettings([In][Out] ref Devmode lpDevMode, [MarshalAs(UnmanagedType.U4)] uint dwflags);

	public static string[] GetSupportedResolutions()
	{
		List<string> list = new List<string>();
		Devmode lpDevMode = default(Devmode);
		lpDevMode.dmSize = checked((ushort)Marshal.SizeOf(lpDevMode));
		int i = 0;
		string right = string.Empty;
		for (; EnumDisplaySettings(null, i, ref lpDevMode); i = checked(i + 1))
		{
			string text = lpDevMode.dmPelsWidth.ToString().Trim() + " x " + lpDevMode.dmPelsHeight.ToString().Trim();
			if (Operators.CompareString(text, right, TextCompare: false) != 0)
			{
				if ((long)lpDevMode.dmPelsWidth >= 800L)
				{
					list.Add(text);
				}
				right = text;
			}
		}
		return list.ToArray();
	}

	public static bool ChangeDisplaySettings(int width, int height)
	{
		_oldDevmode = default(Devmode);
		checked
		{
			_oldDevmode.dmSize = (ushort)Marshal.SizeOf(_oldDevmode);
			EnumDisplaySettings(null, -1, ref _oldDevmode);
			Devmode lpDevMode = _oldDevmode;
			lpDevMode.dmPelsWidth = (uint)width;
			lpDevMode.dmPelsHeight = (uint)height;
			int num = ChangeDisplaySettings(ref lpDevMode, 1u);
			ResChanged = false;
			switch (num)
			{
			case 0:
				ResChanged = true;
				FrmMain.fmain.AddToListboxAndScroll("Resolution change successful");
				Log.WriteToLog("Resolution change successful");
				return true;
			case -2:
				FrmMain.fmain.AddToListboxAndScroll("Could not change desktop resolution: Mode not supported");
				Log.WriteToLog("Could not change desktop resolution: Mode not supported");
				return false;
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
	}

	public static void RestoreDisplaySettings()
	{
		ChangeDisplaySettings(ref _oldDevmode, 1u);
	}
}
