using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.ResChanger;

namespace OculusTrayTool
{
	// Token: 0x02000048 RID: 72
	internal class Resolution
	{
		// Token: 0x0600058A RID: 1418
		[DllImport("User32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumDisplaySettings([MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, [MarshalAs(UnmanagedType.U4)] int iModeNum, [In] [Out] ref Devmode lpDevMode);

		// Token: 0x0600058B RID: 1419
		[DllImport("User32.dll")]
		[return: MarshalAs(UnmanagedType.I4)]
		private static extern int ChangeDisplaySettings([In] [Out] ref Devmode lpDevMode, [MarshalAs(UnmanagedType.U4)] uint dwflags);

		// Token: 0x0600058C RID: 1420 RVA: 0x0002D50C File Offset: 0x0002B70C
		public static string[] GetSupportedResolutions()
		{
			List<string> list = new List<string>();
			Devmode devmode = default(Devmode);
			checked
			{
				devmode.dmSize = (ushort)Marshal.SizeOf<Devmode>(devmode);
				int num = 0;
				string text = string.Empty;
				while (Resolution.EnumDisplaySettings(null, num, ref devmode))
				{
					string text2 = devmode.dmPelsWidth.ToString().Trim() + " x " + devmode.dmPelsHeight.ToString().Trim();
					bool flag = Operators.CompareString(text2, text, false) != 0;
					if (flag)
					{
						bool flag2 = unchecked((ulong)devmode.dmPelsWidth) >= 800UL;
						if (flag2)
						{
							list.Add(text2);
						}
						text = text2;
					}
					num++;
				}
				return list.ToArray();
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0002D5C8 File Offset: 0x0002B7C8
		public static bool ChangeDisplaySettings(int width, int height)
		{
			Resolution._oldDevmode = default(Devmode);
			checked
			{
				Resolution._oldDevmode.dmSize = (ushort)Marshal.SizeOf<Devmode>(Resolution._oldDevmode);
				Resolution.EnumDisplaySettings(null, -1, ref Resolution._oldDevmode);
				Devmode oldDevmode = Resolution._oldDevmode;
				oldDevmode.dmPelsWidth = (uint)width;
				oldDevmode.dmPelsHeight = (uint)height;
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
				}
				FrmMain.fmain.AddToListboxAndScroll("Could not change desktop resolution: Error code = " + Conversions.ToString(num));
				Log.WriteToLog("Could not change desktop resolution: Error code = " + Conversions.ToString(num));
				return false;
			}
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0002D6E3 File Offset: 0x0002B8E3
		public static void RestoreDisplaySettings()
		{
			Resolution.ChangeDisplaySettings(ref Resolution._oldDevmode, 1U);
		}

		// Token: 0x04000234 RID: 564
		private static Devmode _oldDevmode;

		// Token: 0x04000235 RID: 565
		private const int EnumCurrentSettings = -1;

		// Token: 0x04000236 RID: 566
		private const int DispChangeSuccessful = 0;

		// Token: 0x04000237 RID: 567
		private const int DispChangeBadmode = -2;

		// Token: 0x04000238 RID: 568
		private const int DispChangeRestart = 1;

		// Token: 0x04000239 RID: 569
		public static bool ResChanged = false;
	}
}
