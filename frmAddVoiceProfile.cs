
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
  public partial class frmAddVoiceProfile : Form
  {
    

    public frmAddVoiceProfile() => this.InitializeComponent();

    

    

    

    

    



    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void Button2_Click(object sender, EventArgs e)
    {
      MyProject.Forms.frmAddCustomVoice.VoiceProfileName = this.TextBox1.Text;
      MyProject.Forms.frmAddCustomVoice.VoiceProfileGameProfile = this.ComboBox1.Text;
      int num = (int) MyProject.Forms.frmAddCustomVoice.ShowDialog();
      this.Close();
    }
  }
}