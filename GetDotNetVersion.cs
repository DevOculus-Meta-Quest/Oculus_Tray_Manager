// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.GetDotNetVersion
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

#nullable disable
namespace OculusTrayTool
{
  public class GetDotNetVersion
  {
    public static void GetVersion()
    {
      using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
      {
        if (registryKey != null && registryKey.GetValue("Release") != null)
          Log.WriteToLog(".NET Framework Version: " + GetDotNetVersion.CheckFor45PlusVersion(Conversions.ToInteger(registryKey.GetValue("Release"))));
        else
          Log.WriteToLog(".NET Framework Version not detected.");
      }
    }

    private static string CheckFor45PlusVersion(int releaseKey)
    {
      if (releaseKey >= 461308)
        return "4.7.1 or later";
      if (releaseKey >= 46079)
        return "4.7";
      if (releaseKey >= 394802)
        return "4.6.2 or later";
      if (releaseKey >= 394254)
        return "4.6.1";
      if (releaseKey >= 393295)
        return "4.6";
      if (releaseKey >= 379893)
        return "4.5.2";
      if (releaseKey >= 378675)
        return "4.5.1";
      return releaseKey >= 378389 ? "4.5" : "No 4.5 or later version detected";
    }
  }
}
