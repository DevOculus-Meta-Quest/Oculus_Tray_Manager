// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.KeyboardHook
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  public class KeyboardHook
  {
    private const int WH_KEYBOARD_LL = 13;
    private const int HC_ACTION = 0;
    private const int WM_KEYDOWN = 256;
    private const int WM_KEYUP = 257;
    private const int WM_SYSKEYDOWN = 260;
    private const int WM_SYSKEYUP = 261;
    private KeyboardHook.KBDLLHookProc KBDLLHookProcDelegate;
    private IntPtr HHookID;

    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern int SetWindowsHookEx(
      int idHook,
      KeyboardHook.KBDLLHookProc HookProc,
      IntPtr hInstance,
      int wParam);

    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    private static extern bool UnhookWindowsHookEx(int idHook);

    public static event KeyboardHook.KeyDownEventHandler KeyDown;

    public static event KeyboardHook.KeyUpEventHandler KeyUp;

    private int KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
      if (nCode == 0)
      {
        IntPtr num = wParam;
        KeyboardHook.KBDLLHOOKSTRUCT kbdllhookstruct;
        if (num == (IntPtr) 256 || num == (IntPtr) 260)
        {
          // ISSUE: reference to a compiler-generated field
          KeyboardHook.KeyDownEventHandler keyDownEvent = KeyboardHook.KeyDownEvent;
          if (keyDownEvent != null)
          {
            KeyboardHook.KeyDownEventHandler downEventHandler = keyDownEvent;
            object structure = Marshal.PtrToStructure(lParam, kbdllhookstruct.GetType());
            int vkCode = checked ((int) (unchecked (structure != null) ? (KeyboardHook.KBDLLHOOKSTRUCT) structure : new KeyboardHook.KBDLLHOOKSTRUCT()).vkCode);
            downEventHandler((Keys) vkCode);
          }
        }
        else if (num == (IntPtr) 257 || num == (IntPtr) 261)
        {
          // ISSUE: reference to a compiler-generated field
          KeyboardHook.KeyUpEventHandler keyUpEvent = KeyboardHook.KeyUpEvent;
          if (keyUpEvent != null)
          {
            KeyboardHook.KeyUpEventHandler keyUpEventHandler = keyUpEvent;
            object structure = Marshal.PtrToStructure(lParam, kbdllhookstruct.GetType());
            int vkCode = checked ((int) (unchecked (structure != null) ? (KeyboardHook.KBDLLHOOKSTRUCT) structure : new KeyboardHook.KBDLLHOOKSTRUCT()).vkCode);
            keyUpEventHandler((Keys) vkCode);
          }
        }
      }
      return KeyboardHook.CallNextHookEx((int) IntPtr.Zero, nCode, wParam, lParam);
    }

    public KeyboardHook()
    {
      this.KBDLLHookProcDelegate = new KeyboardHook.KBDLLHookProc(this.KeyboardProc);
      this.HHookID = IntPtr.Zero;
      this.HHookID = (IntPtr) KeyboardHook.SetWindowsHookEx(13, this.KBDLLHookProcDelegate, (IntPtr) Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32(), 0);
      if (this.HHookID == IntPtr.Zero)
        throw new Exception("Could not set keyboard hook");
    }

    ~KeyboardHook()
    {
      if (!(this.HHookID == IntPtr.Zero))
        KeyboardHook.UnhookWindowsHookEx((int) this.HHookID);
      // ISSUE: explicit finalizer call
      base.Finalize();
    }

    private struct KBDLLHOOKSTRUCT
    {
      public uint vkCode;
      public uint scanCode;
      public KeyboardHook.KBDLLHOOKSTRUCTFlags flags;
      public uint time;
      public UIntPtr dwExtraInfo;
    }

    [Flags]
    private enum KBDLLHOOKSTRUCTFlags : uint
    {
      LLKHF_EXTENDED = 1,
      LLKHF_INJECTED = 16, // 0x00000010
      LLKHF_ALTDOWN = 32, // 0x00000020
      LLKHF_UP = 128, // 0x00000080
    }

    public delegate void KeyDownEventHandler(Keys Key);

    public delegate void KeyUpEventHandler(Keys Key);

    private delegate int KBDLLHookProc(int nCode, IntPtr wParam, IntPtr lParam);
  }
}
