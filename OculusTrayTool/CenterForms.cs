using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[StandardModule]
internal sealed class CenterForms
{
	public static void CenterForm(Form frm, Form parent = null)
	{
		Rectangle rectangle = parent?.RectangleToScreen(parent.ClientRectangle) ?? Screen.FromPoint(frm.Location).WorkingArea;
		checked
		{
			int x = rectangle.Left + unchecked(checked(rectangle.Width - frm.Width) / 2);
			int y = rectangle.Top + unchecked(checked(rectangle.Height - frm.Height) / 2);
			frm.Location = new Point(x, y);
		}
	}
}
