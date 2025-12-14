

using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool.Forms
{

  public partial class frmAbout : Form
  {
    
    private Resizer rs;

    public frmAbout()
    {
      this.Load += this.readme_Load;
      this.rs = new Resizer();
      this.InitializeComponent();
    }

    

    

    

    

    

    

    


    

    [DllImport("user32.dll")]
    private static extern bool HideCaret(IntPtr hWnd);

    private void RichTextBox1_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void readme_Load(object sender, EventArgs e) => this.PictureBox1.Focus();

    private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      string userGuidePath = Path.Combine(Application.StartupPath, "resources", "User Guide.pdf");
      if (!File.Exists(userGuidePath))
        return;
      Process.Start(userGuidePath);
    }

    private void PictureBox1_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.frmDonate.ShowDialog();
      this.Close();
    }

    private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("https://apollyonvr.com");
    }
  }
}
