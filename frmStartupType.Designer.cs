using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmStartupType
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
      this.RadioButton1 = new RadioButton();
      this.RadioButton2 = new RadioButton();
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.Location = new Point(6, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(395, 15);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Select the method for launching Oculus Tray Tool when Windows starts.";
      this.RadioButton1.AutoSize = true;
      this.RadioButton1.Location = new Point(46, 58);
      this.RadioButton1.Name = "RadioButton1";
      this.RadioButton1.Size = new Size(283, 19);
      this.RadioButton1.TabIndex = 0;
      this.RadioButton1.TabStop = true;
      this.RadioButton1.Text = "Regular startup (UAC should prompt if enabled)";
      this.RadioButton1.UseVisualStyleBackColor = true;
      this.RadioButton2.AutoSize = true;
      this.RadioButton2.Location = new Point(46, 83);
      this.RadioButton2.Name = "RadioButton2";
      this.RadioButton2.Size = new Size(339, 19);
      this.RadioButton2.TabIndex = 1;
      this.RadioButton2.TabStop = true;
      this.RadioButton2.Text = "Scheduled Task (UAC should not prompt, even if enabled)";
      this.RadioButton2.UseVisualStyleBackColor = true;
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.Controls.Add(this.RadioButton2);
      this.GroupBox1.Controls.Add(this.RadioButton1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(414, 123);
      this.GroupBox1.TabIndex = 2;
      this.GroupBox1.TabStop = false;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(351, 141);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 3;
      this.Button1.Text = "OK";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(440, 172);
      this.ControlBox = false;
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Name = "StartupType";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Select Startup Method";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    
    }

        #endregion

    internal Button Button1;
        internal Label Label1;
        internal RadioButton RadioButton1;
        internal RadioButton RadioButton2;
        internal GroupBox GroupBox1;
        internal Font Font;
    
    }
}