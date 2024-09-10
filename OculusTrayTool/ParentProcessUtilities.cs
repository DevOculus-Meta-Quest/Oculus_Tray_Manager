using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OculusTrayTool
{
	// Token: 0x02000035 RID: 53
	public struct ParentProcessUtilities
	{
		// Token: 0x060004D2 RID: 1234
		[DllImport("ntdll.dll")]
		private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, ref ParentProcessUtilities processInformation, int processInformationLength, out int returnLength);

		// Token: 0x060004D3 RID: 1235 RVA: 0x00023600 File Offset: 0x00021800
		public static Process GetParentProcess()
		{
			return ParentProcessUtilities.GetParentProcess(Process.GetCurrentProcess().Handle);
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00023624 File Offset: 0x00021824
		public static Process GetParentProcess(int id)
		{
			Process processById = Process.GetProcessById(id);
			return ParentProcessUtilities.GetParentProcess(processById.Handle);
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00023648 File Offset: 0x00021848
		public static Process GetParentProcess(IntPtr handle)
		{
			ParentProcessUtilities parentProcessUtilities = default(ParentProcessUtilities);
			int num2;
			int num = ParentProcessUtilities.NtQueryInformationProcess(handle, 0, ref parentProcessUtilities, Marshal.SizeOf<ParentProcessUtilities>(parentProcessUtilities), out num2);
			bool flag = num != 0;
			if (flag)
			{
				throw new Win32Exception(num);
			}
			Process process;
			try
			{
				process = Process.GetProcessById(parentProcessUtilities.InheritedFromUniqueProcessId.ToInt32());
			}
			catch (ArgumentException ex)
			{
				process = null;
			}
			return process;
		}

		// Token: 0x040001C9 RID: 457
		internal IntPtr Reserved1;

		// Token: 0x040001CA RID: 458
		internal IntPtr PebBaseAddress;

		// Token: 0x040001CB RID: 459
		internal IntPtr Reserved2_0;

		// Token: 0x040001CC RID: 460
		internal IntPtr Reserved2_1;

		// Token: 0x040001CD RID: 461
		internal IntPtr UniqueProcessId;

		// Token: 0x040001CE RID: 462
		internal IntPtr InheritedFromUniqueProcessId;
	}
}
