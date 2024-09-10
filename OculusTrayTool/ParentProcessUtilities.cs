using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

public struct ParentProcessUtilities
{
	internal IntPtr Reserved1;

	internal IntPtr PebBaseAddress;

	internal IntPtr Reserved2_0;

	internal IntPtr Reserved2_1;

	internal IntPtr UniqueProcessId;

	internal IntPtr InheritedFromUniqueProcessId;

	[DllImport("ntdll.dll")]
	private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, ref ParentProcessUtilities processInformation, int processInformationLength, out int returnLength);

	public static Process GetParentProcess()
	{
		return GetParentProcess(Process.GetCurrentProcess().Handle);
	}

	public static Process GetParentProcess(int id)
	{
		Process processById = Process.GetProcessById(id);
		return GetParentProcess(processById.Handle);
	}

	public static Process GetParentProcess(IntPtr handle)
	{
		ParentProcessUtilities processInformation = default(ParentProcessUtilities);
		int returnLength;
		int num = NtQueryInformationProcess(handle, 0, ref processInformation, Marshal.SizeOf(processInformation), out returnLength);
		if (num != 0)
		{
			throw new Win32Exception(num);
		}
		Process result;
		try
		{
			result = Process.GetProcessById(processInformation.InheritedFromUniqueProcessId.ToInt32());
		}
		catch (ArgumentException ex)
		{
			ProjectData.SetProjectError(ex);
			ArgumentException ex2 = ex;
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
