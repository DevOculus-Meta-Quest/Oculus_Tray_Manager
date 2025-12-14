

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool.Forms
{

  public partial class frmDonate : Form
  {
    

    public frmDonate() => this.InitializeComponent();

    

    





    

    

    

    

    

    

    


    private void PictureBox1_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=V2Q88RWKVSAH6");
    }

    private void PictureBox2_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XV6QUB2VGL298");
    }

    private void PictureBox3_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7A8ME9WUMG9SA");
    }

    private void PictureBox4_Click(object sender, EventArgs e)
    {
      Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=R5D56LX9T8MTY");
    }

    private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("https://Eliminater74.com");
    }
  }
}
