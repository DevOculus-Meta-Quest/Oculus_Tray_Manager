using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmHomeless
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
    private void InitializeComponent()
    {
      this.GroupBox1 = new GroupBox();
      this.BtnBrowseMusic = new Button();
      this.TextBox1 = new TextBox();
      this.BtnColor = new Button();
      this.ComboMusic = new ComboBox();
      this.NumericVolume = new NumericUpDown();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.ColorDialog1 = new ColorDialog();
      this.CheckBox1 = new CheckBox();
      this.GroupBox1.SuspendLayout();
      this.NumericVolume.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add(this.CheckBox1);
      this.GroupBox1.Controls.Add(this.BtnBrowseMusic);
      this.GroupBox1.Controls.Add(this.TextBox1);
      this.GroupBox1.Controls.Add(this.BtnColor);
      this.GroupBox1.Controls.Add(this.ComboMusic);
      this.GroupBox1.Controls.Add(this.NumericVolume);
      this.GroupBox1.Controls.Add(this.Label3);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(348, 133);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.BtnBrowseMusic.FlatStyle = FlatStyle.Flat;
      this.BtnBrowseMusic.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnBrowseMusic.Location = new Point(258, 44);
      this.BtnBrowseMusic.Name = "BtnBrowseMusic";
      this.BtnBrowseMusic.Size = new Size(71, 23);
      this.BtnBrowseMusic.TabIndex = 8;
      this.BtnBrowseMusic.Text = "Add More";
      this.BtnBrowseMusic.UseVisualStyleBackColor = true;
      this.TextBox1.Location = new Point(131, 17);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.ReadOnly = true;
      this.TextBox1.Size = new Size(121, 20);
      this.TextBox1.TabIndex = 7;
      this.BtnColor.FlatStyle = FlatStyle.Flat;
      this.BtnColor.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnColor.Location = new Point(258, 15);
      this.BtnColor.Name = "BtnColor";
      this.BtnColor.Size = new Size(71, 23);
      this.BtnColor.TabIndex = 6;
      this.BtnColor.Text = "Pick color";
      this.BtnColor.UseVisualStyleBackColor = true;
      this.ComboMusic.BackColor = Color.AliceBlue;
      this.ComboMusic.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboMusic.DropDownWidth = 200;
      this.ComboMusic.FlatStyle = FlatStyle.Popup;
      this.ComboMusic.FormattingEnabled = true;
      this.ComboMusic.Items.AddRange(new object[1]
      {
        (object) "None"
      });
      this.ComboMusic.Location = new Point(131, 46);
      this.ComboMusic.Name = "ComboMusic";
      this.ComboMusic.Size = new Size(121, 21);
      this.ComboMusic.Sorted = true;
      this.ComboMusic.TabIndex = 4;
      this.NumericVolume.Location = new Point(132, 79);
      this.NumericVolume.Name = "NumericVolume";
      this.NumericVolume.Size = new Size(120, 20);
      this.NumericVolume.TabIndex = 3;
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new Point(16, 81);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(103, 15);
      this.Label3.TabIndex = 2;
      this.Label3.Text = "Music volume %: ";
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new Point(15, 49);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(112, 15);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Background music:";
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new Point(16, 20);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(109, 15);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Background color: ";
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(12, 151);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(55, 25);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(305, 151);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(55, 25);
      this.Button2.TabIndex = 2;
      this.Button2.Text = "OK";
      this.Button2.UseVisualStyleBackColor = true;
      this.ColorDialog1.FullOpen = true;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Location = new Point(16, 105);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.RightToLeft = RightToLeft.Yes;
      this.CheckBox1.Size = new Size(130, 17);
      this.CheckBox1.TabIndex = 9;
      this.CheckBox1.Text = "   :Automatically patch";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(368, 183);
      this.ControlBox = false;
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = "frmHomeless";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Configure Oculus Homeless";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.NumericVolume.EndInit();
      this.ResumeLayout(false);
    
      this.ComboMusic.SelectedIndexChanged += new EventHandler(this.ComboMusic_SelectedIndexChanged);
      this.Button1.Click += new EventHandler(this.Button1_Click);
      this.Button2.Click += new EventHandler(this.Button2_Click);
      this.BtnColor.Click += new EventHandler(this.Button3_Click);
      this.BtnBrowseMusic.Click += new EventHandler(this.BtnBrowseMusic_Click);
      this.CheckBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
    }

        #endregion

    internal ComboBox ComboMusic;
    internal Button Button1;
    internal Button Button2;
    internal Button BtnColor;
    internal Button BtnBrowseMusic;
    internal CheckBox CheckBox1;
        internal GroupBox GroupBox1;
        internal TextBox TextBox1;
        internal NumericUpDown NumericVolume;
        internal Label Label3;
        internal Label Label2;
        internal Label Label1;
        internal ColorDialog ColorDialog1;
    
    }
}