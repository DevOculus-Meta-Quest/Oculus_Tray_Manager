

using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool.Forms
{

  public partial class frmLoading : Form
  {
    

    public frmLoading()
    {
      this.Load += this.Loading_Load;
      this.FormClosing += this.frmLoading_FormClosing;
      this.InitializeComponent();
    }

    

    private void Loading_Load(object sender, EventArgs e)
    {
      Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
      int x = checked (workingArea.Width - this.Width);
      workingArea = Screen.PrimaryScreen.WorkingArea;
      int y = checked (workingArea.Height - this.Height);
      this.Location = new Point(x, y);
      Win32.AnimateWindow(this.Handle, 500, Win32.AnimateWindowFlags.AW_HOR_NEGATIVE | Win32.AnimateWindowFlags.AW_SLIDE);
    }

    private void frmLoading_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void Label1_Click(object sender, EventArgs e)
    {
      if (!MyProject.Forms.FrmMain.loadingDone)
        return;
      MyProject.Forms.FrmMain.ShowForm();
    }

    private void Label2_Click(object sender, EventArgs e)
    {
      if (!MyProject.Forms.FrmMain.loadingDone)
        return;
      MyProject.Forms.FrmMain.ShowForm();
    }

    private void PictureBox1_Click(object sender, EventArgs e)
    {
      if (!MyProject.Forms.FrmMain.loadingDone)
        return;
      MyProject.Forms.FrmMain.ShowForm();
    }

    public void CloseStartupToast()
    {
      Win32.AnimateWindow(this.Handle, 500, Win32.AnimateWindowFlags.AW_HOR_POSITIVE | Win32.AnimateWindowFlags.AW_HIDE | Win32.AnimateWindowFlags.AW_SLIDE);
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle = createParams.ExStyle | 134217728 | 8;
        return createParams;
      }
    }

    protected override void WndProc(ref Message msg)
    {
      if (msg.Msg == 33)
        msg.Result = (IntPtr) 3;
      else
        base.WndProc(ref msg);
    }
  }
}
