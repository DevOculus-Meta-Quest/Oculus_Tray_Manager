
using System.Runtime.InteropServices;

#nullable disable
namespace OculusTrayTool.ResChanger
{
  public struct Pointl
  {
    [MarshalAs(UnmanagedType.I4)]
    public int x;
    [MarshalAs(UnmanagedType.I4)]
    public int y;
  }
}
