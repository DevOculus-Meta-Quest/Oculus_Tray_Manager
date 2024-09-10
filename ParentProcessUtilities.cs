// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.ParentProcessUtilities
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

#nullable disable
namespace OculusTrayTool
{
  public struct ParentProcessUtilities
  {
    internal IntPtr Reserved1;
    internal IntPtr PebBaseAddress;
    internal IntPtr Reserved2_0;
    internal IntPtr Reserved2_1;
    internal IntPtr UniqueProcessId;
    internal IntPtr InheritedFromUniqueProcessId;

    [DllImport("ntdll.dll")]
    private static extern int NtQueryInformationProcess(
      IntPtr processHandle,
      int processInformationClass,
      ref ParentProcessUtilities processInformation,
      int processInformationLength,
      out int returnLength);

    public static Process GetParentProcess()
    {
      return ParentProcessUtilities.GetParentProcess(Process.GetCurrentProcess().Handle);
    }

    public static Process GetParentProcess(int id)
    {
      return ParentProcessUtilities.GetParentProcess(Process.GetProcessById(id).Handle);
    }

    public static Process GetParentProcess(IntPtr handle)
    {
      ParentProcessUtilities processInformation = new ParentProcessUtilities();
      int error = ParentProcessUtilities.NtQueryInformationProcess(handle, 0, ref processInformation, Marshal.SizeOf<ParentProcessUtilities>(processInformation), out int _);
      if (error != 0)
        throw new Win32Exception(error);
      Process parentProcess;
      try
      {
        parentProcess = Process.GetProcessById(processInformation.InheritedFromUniqueProcessId.ToInt32());
      }
      catch (ArgumentException ex)
      {
        ProjectData.SetProjectError((Exception) ex);
        parentProcess = (Process) null;
        ProjectData.ClearProjectError();
      }
      return parentProcess;
    }
  }
}
