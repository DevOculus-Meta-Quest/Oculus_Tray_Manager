using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmAddVoiceProfile
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
      this.Label2 = new Label();
      this.ComboBox1 = new ComboBox();
      this.GroupBox1 = new GroupBox();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(10, 22);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(70, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Profile Name:";
      this.TextBox1.ForeColor = Color.DodgerBlue;
      this.TextBox1.Location = new Point(131, 19);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(217, 20);
      this.TextBox1.TabIndex = 1;
      this.Label2.AutoSize = true;
      this.Label2.ForeColor = Color.DodgerBlue;
      this.Label2.Location = new Point(10, 55);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(119, 13);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Load with Game Profile:";
      this.ComboBox1.ForeColor = Color.DodgerBlue;
      this.ComboBox1.FormattingEnabled = true;
      this.ComboBox1.Location = new Point(131, 52);
      this.ComboBox1.Name = "ComboBox1";
      this.ComboBox1.Size = new Size(217, 21);
      this.ComboBox1.TabIndex = 3;
      this.GroupBox1.Controls.Add(this.ComboBox1);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Controls.Add(this.TextBox1);
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(363, 94);
      this.GroupBox1.TabIndex = 4;
      this.GroupBox1.TabStop = false;
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(12, 112);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(75, 23);
      this.Button1.TabIndex = 5;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(300, 112);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(75, 23);
      this.Button2.TabIndex = 6;
      this.Button2.Text = "Save";
      this.Button2.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(387, 146);
      this.ControlBox = false;
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.Name = "frmAddVoiceProfile";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Add Profile";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
    
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.Button2.Click += new EventHandler(this.Button2_Click);
    }

        #endregion

    internal Button Button1;
    internal Button Button2;
        internal Label Label1;
        internal TextBox TextBox1;
        internal Label Label2;
        internal ComboBox ComboBox1;
        internal GroupBox GroupBox1;
    
    }
}