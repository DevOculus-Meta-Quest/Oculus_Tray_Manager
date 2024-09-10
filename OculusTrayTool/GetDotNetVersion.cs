using System;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace OculusTrayTool
{
	// Token: 0x0200002A RID: 42
	public class GetDotNetVersion
	{
		// Token: 0x060003F0 RID: 1008 RVA: 0x00019C9C File Offset: 0x00017E9C
		public static void GetVersion()
		{
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
			{
				bool flag = registryKey != null && registryKey.GetValue("Release") != null;
				if (flag)
				{
					Log.WriteToLog(".NET Framework Version: " + GetDotNetVersion.CheckFor45PlusVersion(Conversions.ToInteger(registryKey.GetValue("Release"))));
				}
				else
				{
					Log.WriteToLog(".NET Framework Version not detected.");
				}
			}
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00019D30 File Offset: 0x00017F30
		private static string CheckFor45PlusVersion(int releaseKey)
		{
			bool flag = releaseKey >= 461308;
			string text;
			if (flag)
			{
				text = "4.7.1 or later";
			}
			else
			{
				bool flag2 = releaseKey >= 46079;
				if (flag2)
				{
					text = "4.7";
				}
				else
				{
					bool flag3 = releaseKey >= 394802;
					if (flag3)
					{
						text = "4.6.2 or later";
					}
					else
					{
						bool flag4 = releaseKey >= 394254;
						if (flag4)
						{
							text = "4.6.1";
						}
						else
						{
							bool flag5 = releaseKey >= 393295;
							if (flag5)
							{
								text = "4.6";
							}
							else
							{
								bool flag6 = releaseKey >= 379893;
								if (flag6)
								{
									text = "4.5.2";
								}
								else
								{
									bool flag7 = releaseKey >= 378675;
									if (flag7)
									{
										text = "4.5.1";
									}
									else
									{
										bool flag8 = releaseKey >= 378389;
										if (flag8)
										{
											text = "4.5";
										}
										else
										{
											text = "No 4.5 or later version detected";
										}
									}
								}
							}
						}
					}
				}
			}
			return text;
		}
	}
}
