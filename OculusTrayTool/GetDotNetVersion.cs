using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace OculusTrayTool;

public class GetDotNetVersion
{
	public static void GetVersion()
	{
		using RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\");
		if (registryKey != null && registryKey.GetValue("Release") != null)
		{
			Log.WriteToLog(".NET Framework Version: " + CheckFor45PlusVersion(Conversions.ToInteger(registryKey.GetValue("Release"))));
		}
		else
		{
			Log.WriteToLog(".NET Framework Version not detected.");
		}
	}

	private static string CheckFor45PlusVersion(int releaseKey)
	{
		if (releaseKey >= 461308)
		{
			return "4.7.1 or later";
		}
		if (releaseKey >= 46079)
		{
			return "4.7";
		}
		if (releaseKey >= 394802)
		{
			return "4.6.2 or later";
		}
		if (releaseKey >= 394254)
		{
			return "4.6.1";
		}
		if (releaseKey >= 393295)
		{
			return "4.6";
		}
		if (releaseKey >= 379893)
		{
			return "4.5.2";
		}
		if (releaseKey >= 378675)
		{
			return "4.5.1";
		}
		if (releaseKey >= 378389)
		{
			return "4.5";
		}
		return "No 4.5 or later version detected";
	}
}
