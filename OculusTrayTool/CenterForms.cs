using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x0200000A RID: 10
	[StandardModule]
	internal sealed class CenterForms
	{
		// Token: 0x06000153 RID: 339 RVA: 0x00006190 File Offset: 0x00004390
		public static void CenterForm(Form frm, Form parent = null)
		{
			bool flag = parent != null;
			Rectangle rectangle;
			if (flag)
			{
				rectangle = parent.RectangleToScreen(parent.ClientRectangle);
			}
			else
			{
				rectangle = Screen.FromPoint(frm.Location).WorkingArea;
			}
			checked
			{
				int num = rectangle.Left + (rectangle.Width - frm.Width) / 2;
				int num2 = rectangle.Top + (rectangle.Height - frm.Height) / 2;
				frm.Location = new Point(num, num2);
			}
		}
	}
}
