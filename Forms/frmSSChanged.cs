

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

  public partial class frmSSChanged : Form
  {
    

    public frmSSChanged() => this.InitializeComponent();

    


    


    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.CheckBox1.Checked)
        MySettingsProperty.Settings.ShowConfirmRestart = false;
      else
        MySettingsProperty.Settings.ShowConfirmRestart = true;
    }
  }
}
