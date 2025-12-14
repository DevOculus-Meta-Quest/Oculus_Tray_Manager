

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{

  public partial class frmAddCustomVoice : Form
  {
    
    public int id;
    public string VoiceProfileName;
    public string VoiceProfileGameProfile;

    public frmAddCustomVoice() => this.InitializeComponent();

    

    

    

    




    

    




    




    

    

    

    private void Button2_Click(object sender, EventArgs e)
    {
    }

    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void TextBoxSeconds_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!((int)e.KeyChar != 8 & (int)e.KeyChar != (int) sbyte.MaxValue & (int)e.KeyChar != 44) || !((int)e.KeyChar < 48 | (int)e.KeyChar > 57))
        return;
      e.Handled = true;
    }
  }
}