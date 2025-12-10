// Decompiled with JetBrains decompiler

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmProcessing : Form
  {
    
    

    

    

    public frmProcessing()
    {
      this.components = (IContainer) null;
      this.InitializeComponent();
    }

    private void frmProcessing_Load(object sender, EventArgs e)
    {
    }

    public void UpdateProgressBar(int percent, string message)
    {
      if (this.progressBar1.InvokeRequired)
      {
        this.Invoke((Delegate) new frmProcessing.UpdateProgressBarDelegate(this.UpdateProgressBar), (object) percent, (object) message);
      }
      else
      {
        this.progressBar1.Message = message;
        this.progressBar1.Value = MathTools.Clamp<int>(percent, 0, 100);
      }
    }

    protected override bool ShowWithoutActivation => true;

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

    public delegate void UpdateProgressBarDelegate(int percent, string message);
  }
}