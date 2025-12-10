using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmDownloading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        internal Label Label1;

protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
    private void InitializeComponent()
    {
      this.Label1 = new Label();
      this.SuspendLayout();
      this.Label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
      this.Label1.Location = new Point(4, 15);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(252, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Updating Database:  0%";
      this.Label1.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(258, 41);
      this.ControlBox = false;
      this.Controls.Add(this.Label1);
      this.ForeColor = Color.DodgerBlue;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "frmDownloading";
      this.StartPosition = FormStartPosition.CenterParent;
      this.ResumeLayout(false);
    
    }

        #endregion

    
    }
}