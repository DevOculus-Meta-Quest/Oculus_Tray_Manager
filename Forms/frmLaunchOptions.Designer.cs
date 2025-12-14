using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace MetaQuestTrayTool.Forms
{
    partial class frmLaunchOptions
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
      this.GroupBox1 = new GroupBox();
      this.TextBox1 = new TextBox();
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Controls.Add(this.TextBox1);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(321, 65);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.TextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.TextBox1.Location = new Point(84, 27);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(231, 20);
      this.TextBox1.TabIndex = 1;
      this.Label1.AutoSize = true;
      this.Label1.Location = new Point(15, 30);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(63, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Parameters:";
      this.Button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(258, 86);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Launch App";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(12, 86);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 23);
      this.Button2.TabIndex = 2;
      this.Button2.Text = "Cancel";
      this.Button2.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(345, 121);
      this.ControlBox = false;
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.Name = "LaunchOptions";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Launch Options";
      this.TopMost = true;
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    
    }

        #endregion

    internal Button Button1;
    internal Button Button2;
        internal GroupBox GroupBox1;
        internal TextBox TextBox1;
        internal Label Label1;
    
    }
}
