using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool.Forms
{
    partial class frmLinkPresets
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
      this.Label1 = new Label();
      this.TextBox1 = new TextBox();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1 = new GroupBox();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(12, 28);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(47, 15);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Name: ";
      this.TextBox1.Location = new Point(65, 25);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(228, 21);
      this.TextBox1.TabIndex = 1;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(12, 83);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 2;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(218, 83);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 23);
      this.Button2.TabIndex = 3;
      this.Button2.Text = "OK";
      this.Button2.UseVisualStyleBackColor = true;
      this.GroupBox1.Location = new Point(5, 67);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(299, 10);
      this.GroupBox1.TabIndex = 4;
      this.GroupBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(310, 118);
      this.ControlBox = false;
      this.Controls.Add(this.GroupBox1);
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.TextBox1);
      this.Controls.Add(this.Label1);
      this.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = "frmLinkPresets";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Add Preset";
      this.ResumeLayout(false);
      this.PerformLayout();
    
    }

        #endregion

    internal Button Button1;
    internal Button Button2;
        internal Label Label1;
        internal TextBox TextBox1;
        internal GroupBox GroupBox1;
        internal Font Font;
    
    }
}
