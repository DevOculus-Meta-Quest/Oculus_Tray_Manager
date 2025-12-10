using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmRemoveProgress
    {
        private System.ComponentModel.IContainer components = null;

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

    private void InitializeComponent()
    {
      this.ListBox1 = new ListBox();
      this.Button1 = new Button();
      this.SuspendLayout();
      this.ListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.ListBox1.FormattingEnabled = true;
      this.ListBox1.Location = new Point(12, 12);
      this.ListBox1.Name = "ListBox1";
      this.ListBox1.Size = new Size(703, 134);
      this.ListBox1.TabIndex = 0;
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(640, 152);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(727, 185);
      this.ControlBox = false;
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.ListBox1);
      this.Name = "RemoveProgress";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Progress";
      this.ResumeLayout(false);
    
    }

        #endregion

    internal Button Button1;
        internal ListBox ListBox1;
    
    }
}