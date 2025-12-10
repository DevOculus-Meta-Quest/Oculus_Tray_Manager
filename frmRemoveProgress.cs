
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
  public partial class frmRemoveProgress : Form
  {
    

    public frmRemoveProgress()
    {
      this.Load += this.RemoveProgress_Load;
      this.InitializeComponent();
    }

    


    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void RemoveProgress_Load(object sender, EventArgs e)
    {
      CenterForms.CenterForm((Form) this, (Form) MyProject.Forms.frmLibrary);
    }
  }
}