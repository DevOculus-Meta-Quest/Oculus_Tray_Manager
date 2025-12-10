
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmDownloading : Form
  {
    

    public frmDownloading()
    {
      this.Load += new EventHandler(this.frmDownloading_Load);
      this.InitializeComponent();
    }

    

    public void UpdateLabel(string text)
    {
      if (this.Label1.InvokeRequired)
      {
        this.Label1.BeginInvoke((Delegate) new frmDownloading.UpdateLabel_delegate(this.UpdateLabel), (object) text);
      }
      else
      {
        this.Label1.Text = text;
        this.Label1.Update();
      }
    }

    private void frmDownloading_Load(object sender, EventArgs e)
    {
      frmDownloading.CenterForm((Form) this, (Form) MyProject.Forms.frmLibrary);
    }

    public static void CenterForm(Form frm, Form parent = null)
    {
      Rectangle rectangle = parent == null ? Screen.FromPoint(frm.Location).WorkingArea : parent.RectangleToScreen(parent.ClientRectangle);
      int x = checked (rectangle.Left + unchecked (checked (rectangle.Width - frm.Width) / 2));
      int y = checked (rectangle.Top + unchecked (checked (rectangle.Height - frm.Height) / 2));
      frm.Location = new Point(x, y);
    }

    public delegate void UpdateLabel_delegate(string text);
  }
}