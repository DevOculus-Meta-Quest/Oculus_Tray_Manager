// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmProcessing
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmProcessing : Form
  {
    private IContainer components;
    private TextProgressBar progressBar1;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.progressBar1 = new TextProgressBar();
      this.SuspendLayout();
      this.progressBar1.Dock = DockStyle.Fill;
      this.progressBar1.Location = new Point(0, 0);
      this.progressBar1.Message = (string) null;
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(300, 52);
      this.progressBar1.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(300, 52);
      this.ControlBox = false;
      this.Controls.Add((Control) this.progressBar1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (frmProcessing);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Processing";
      this.TopMost = true;
      this.ResumeLayout(false);
    }

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
