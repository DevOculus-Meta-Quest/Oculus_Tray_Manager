

using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{

  internal sealed class CenterForms
  {
    public static void CenterForm(Form frm, Form parent = null)
    {
      Rectangle rectangle = parent == null ? Screen.FromPoint(frm.Location).WorkingArea : parent.RectangleToScreen(parent.ClientRectangle);
      int x = checked (rectangle.Left + unchecked (checked (rectangle.Width - frm.Width) / 2));
      int y = checked (rectangle.Top + unchecked (checked (rectangle.Height - frm.Height) / 2));
      frm.Location = new Point(x, y);
    }
  }
}
