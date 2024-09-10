using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OculusTrayTool
{
	// Token: 0x02000033 RID: 51
	public class KeyboardHook
	{
		// Token: 0x060004C5 RID: 1221
		[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		private static extern int SetWindowsHookEx(int idHook, KeyboardHook.KBDLLHookProc HookProc, IntPtr hInstance, int wParam);

		// Token: 0x060004C6 RID: 1222
		[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		private static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

		// Token: 0x060004C7 RID: 1223
		[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		private static extern bool UnhookWindowsHookEx(int idHook);

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060004C8 RID: 1224 RVA: 0x00022F40 File Offset: 0x00021140
		// (remove) Token: 0x060004C9 RID: 1225 RVA: 0x00022F74 File Offset: 0x00021174
		public static event KeyboardHook.KeyDownEventHandler KeyDown;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060004CA RID: 1226 RVA: 0x00022FA8 File Offset: 0x000211A8
		// (remove) Token: 0x060004CB RID: 1227 RVA: 0x00022FDC File Offset: 0x000211DC
		public static event KeyboardHook.KeyUpEventHandler KeyUp;

		// Token: 0x060004CC RID: 1228 RVA: 0x00023010 File Offset: 0x00021210
		private int KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
		{
			bool flag = nCode == 0;
			checked
			{
				if (flag)
				{
					bool flag2 = wParam == (IntPtr)256 || wParam == (IntPtr)260;
					if (flag2)
					{
						KeyboardHook.KeyDownEventHandler keyDownEvent = KeyboardHook.KeyDownEvent;
						if (keyDownEvent != null)
						{
							KeyboardHook.KeyDownEventHandler keyDownEventHandler = keyDownEvent;
							KeyboardHook.KBDLLHOOKSTRUCT kbdllhookstruct;
							object obj = Marshal.PtrToStructure(lParam, kbdllhookstruct.GetType());
							keyDownEventHandler((Keys)((obj != null) ? ((KeyboardHook.KBDLLHOOKSTRUCT)obj) : default(KeyboardHook.KBDLLHOOKSTRUCT)).vkCode);
						}
					}
					else
					{
						flag2 = wParam == (IntPtr)257 || wParam == (IntPtr)261;
						if (flag2)
						{
							KeyboardHook.KeyUpEventHandler keyUpEvent = KeyboardHook.KeyUpEvent;
							if (keyUpEvent != null)
							{
								KeyboardHook.KeyUpEventHandler keyUpEventHandler = keyUpEvent;
								KeyboardHook.KBDLLHOOKSTRUCT kbdllhookstruct;
								object obj2 = Marshal.PtrToStructure(lParam, kbdllhookstruct.GetType());
								keyUpEventHandler((Keys)((obj2 != null) ? ((KeyboardHook.KBDLLHOOKSTRUCT)obj2) : default(KeyboardHook.KBDLLHOOKSTRUCT)).vkCode);
							}
						}
					}
				}
				return KeyboardHook.CallNextHookEx((int)IntPtr.Zero, nCode, wParam, lParam);
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x0002311C File Offset: 0x0002131C
		public KeyboardHook()
		{
			this.KBDLLHookProcDelegate = new KeyboardHook.KBDLLHookProc(this.KeyboardProc);
			this.HHookID = IntPtr.Zero;
			this.HHookID = (IntPtr)KeyboardHook.SetWindowsHookEx(13, this.KBDLLHookProcDelegate, (IntPtr)Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32(), 0);
			bool flag = this.HHookID == IntPtr.Zero;
			if (flag)
			{
				throw new Exception("Could not set keyboard hook");
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x000231A8 File Offset: 0x000213A8
		protected override void Finalize()
		{
			bool flag = !(this.HHookID == IntPtr.Zero);
			if (flag)
			{
				KeyboardHook.UnhookWindowsHookEx((int)this.HHookID);
			}
			base.Finalize();
		}

		// Token: 0x040001BF RID: 447
		private const int WH_KEYBOARD_LL = 13;

		// Token: 0x040001C0 RID: 448
		private const int HC_ACTION = 0;

		// Token: 0x040001C1 RID: 449
		private const int WM_KEYDOWN = 256;

		// Token: 0x040001C2 RID: 450
		private const int WM_KEYUP = 257;

		// Token: 0x040001C3 RID: 451
		private const int WM_SYSKEYDOWN = 260;

		// Token: 0x040001C4 RID: 452
		private const int WM_SYSKEYUP = 261;

		// Token: 0x040001C5 RID: 453
		private KeyboardHook.KBDLLHookProc KBDLLHookProcDelegate;

		// Token: 0x040001C6 RID: 454
		private IntPtr HHookID;

		// Token: 0x0200007A RID: 122
		private struct KBDLLHOOKSTRUCT
		{
			// Token: 0x0400047D RID: 1149
			public uint vkCode;

			// Token: 0x0400047E RID: 1150
			public uint scanCode;

			// Token: 0x0400047F RID: 1151
			public KeyboardHook.KBDLLHOOKSTRUCTFlags flags;

			// Token: 0x04000480 RID: 1152
			public uint time;

			// Token: 0x04000481 RID: 1153
			public UIntPtr dwExtraInfo;
		}

		// Token: 0x0200007B RID: 123
		[Flags]
		private enum KBDLLHOOKSTRUCTFlags : uint
		{
			// Token: 0x04000483 RID: 1155
			LLKHF_EXTENDED = 1U,
			// Token: 0x04000484 RID: 1156
			LLKHF_INJECTED = 16U,
			// Token: 0x04000485 RID: 1157
			LLKHF_ALTDOWN = 32U,
			// Token: 0x04000486 RID: 1158
			LLKHF_UP = 128U
		}

		// Token: 0x0200007C RID: 124
		// (Invoke) Token: 0x06000A45 RID: 2629
		public delegate void KeyDownEventHandler(Keys Key);

		// Token: 0x0200007D RID: 125
		// (Invoke) Token: 0x06000A49 RID: 2633
		public delegate void KeyUpEventHandler(Keys Key);

		// Token: 0x0200007E RID: 126
		// (Invoke) Token: 0x06000A4D RID: 2637
		private delegate int KBDLLHookProc(int nCode, IntPtr wParam, IntPtr lParam);
	}
}
