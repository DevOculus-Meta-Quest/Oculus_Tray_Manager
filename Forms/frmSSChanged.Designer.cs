using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace MetaQuestTrayTool.Forms
{
    partial class frmSSChanged
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmSSChanged));
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.GroupBox1 = new GroupBox();
      this.CheckBox1 = new CheckBox();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(6, 16);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(250, 36);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Restart any running VR application to apply the new Super Sampling value to it.";
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(214, 64);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(45, 25);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(3, 3);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(260, 55);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CheckBox1.ForeColor = Color.DodgerBlue;
      this.CheckBox1.Location = new Point(12, 68);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.Size = new Size(175, 19);
      this.CheckBox1.TabIndex = 3;
      this.CheckBox1.Text = "Got it, don't show this again";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(267, 95);
      this.Controls.Add(this.CheckBox1);
      this.Controls.Add(this.GroupBox1);
      this.Controls.Add(this.Button1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ssChanged";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Restart Reminder";
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    
    }

        #endregion

    internal Button Button1;
    internal CheckBox CheckBox1;
        internal Label Label1;
        internal GroupBox GroupBox1;
    
    }
}
