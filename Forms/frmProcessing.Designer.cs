using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace MetaQuestTrayTool.Forms
{
    partial class frmProcessing
    {
        private System.ComponentModel.IContainer components = null;
        internal TextProgressBar progressBar1;

protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

        #region Windows Form Designer generated code

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
      this.Controls.Add(this.progressBar1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "frmProcessing";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Processing";
      this.TopMost = true;
      this.ResumeLayout(false);
    
    }

        #endregion

    
    }
}
