using System.Runtime.InteropServices;

namespace OculusTrayTool.ResChanger;

public struct Pointl
{
	[MarshalAs(UnmanagedType.I4)]
	public int x;

	[MarshalAs(UnmanagedType.I4)]
	public int y;
}
