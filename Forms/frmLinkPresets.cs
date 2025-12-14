

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

  public partial class frmLinkPresets : Form
  {
    

    public frmLinkPresets() => this.InitializeComponent();

    

    



    

    private void Button2_Click(object sender, EventArgs e)
    {
      if (FrmMain.fmain.ComboBox4.FindString(this.TextBox1.Text) >= 0)
      {
        int num = (int) MessageBox.Show("A Preset with this name already exists", "Preset exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.TextBox1.Text = "";
      }
      else
      {
        FrmMain.fmain.ComboBox4.Items.Add((object) this.TextBox1.Text);
        FrmMain.fmain.ComboBox4.SelectedIndex = checked (FrmMain.fmain.ComboBox4.Items.Count - 1);
        MyProject.Forms.FrmMain.isCopy = false;
      }
      this.Close();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      MyProject.Forms.FrmMain.isCopy = false;
      this.Close();
    }
  }
}
