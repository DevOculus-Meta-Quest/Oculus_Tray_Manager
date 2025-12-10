using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmMicNotDefaultWarning
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmMicNotDefaultWarning));
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.CheckBox1 = new CheckBox();
      this.SuspendLayout();
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new Point(12, 9);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(380, 71);
      this.Label1.TabIndex = 0;
      this.Label1.Text = resources.GetString("Label1.Text");
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Location = new Point(334, 83);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(58, 23);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Close";
      this.Button1.UseVisualStyleBackColor = true;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Location = new Point(15, 87);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.Size = new Size((int) sbyte.MaxValue, 17);
      this.CheckBox1.TabIndex = 2;
      this.CheckBox1.Text = "Don't show this again";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(404, 118);
      this.ControlBox = false;
      this.Controls.Add(this.CheckBox1);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.Label1);
      this.ForeColor = Color.DodgerBlue;
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Name = "frmMicNotDefaultWarning";
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Oculus Tray Tool";
      this.ResumeLayout(false);
      this.PerformLayout();
    
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.CheckBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
    }

        #endregion

    internal Button Button1;
    internal CheckBox CheckBox1;
        internal Label Label1;
    
    }
}