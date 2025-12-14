

using MetaQuestTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool.Forms
{

  public partial class frmUpdateToast : Form
  {
    

    public frmUpdateToast()
    {
      this.Load += this.UpdateToast_Load;
      this.Click += this.UpdateToast_Click;
      this.InitializeComponent();
    }

    

    private void UpdateToast_Load(object sender, EventArgs e)
    {
      Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
      int x = checked (workingArea.Width - this.Width);
      workingArea = Screen.PrimaryScreen.WorkingArea;
      int y = checked (workingArea.Height - this.Height);
      this.Location = new Point(x, y);
      this.Timer1.Enabled = true;
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      this.Timer1.Enabled = false;
      this.Timer2.Enabled = true;
    }

    private void Timer2_Tick(object sender, EventArgs e)
    {
      this.Opacity -= 0.06;
      if (this.Opacity != 0.0 || !Globals.dbg)
        return;
      Log.WriteToLog("Timer expired");
    }

    private void UpdateToast_Click(object sender, EventArgs e)
    {
      MyProject.Forms.FrmMain.DotNetBarTabcontrol1.SelectedIndex = 6;
      MyProject.Forms.FrmMain.WindowState = FormWindowState.Normal;
      this.Close();
      this.Dispose();
    }

    private void Label1_Click(object sender, EventArgs e)
    {
      MyProject.Forms.FrmMain.DotNetBarTabcontrol1.SelectedIndex = 6;
      MyProject.Forms.FrmMain.WindowState = FormWindowState.Normal;
      this.Close();
      this.Dispose();
    }

    private void Label2_Click(object sender, EventArgs e)
    {
      MyProject.Forms.FrmMain.DotNetBarTabcontrol1.SelectedIndex = 6;
      MyProject.Forms.FrmMain.WindowState = FormWindowState.Normal;
      this.Close();
      this.Dispose();
    }

    private void PictureBox1_Click(object sender, EventArgs e)
    {
      MyProject.Forms.FrmMain.DotNetBarTabcontrol1.SelectedIndex = 6;
      MyProject.Forms.FrmMain.WindowState = FormWindowState.Normal;
      this.Close();
      this.Dispose();
    }
  }
}
