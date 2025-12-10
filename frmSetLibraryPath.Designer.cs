using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmSetLibraryPath
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmSetLibraryPath));
      this.GroupBox1 = new GroupBox();
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.FolderBrowserDialog1 = new FolderBrowserDialog();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(394, 97);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(6, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(382, 77);
      this.Label1.TabIndex = 0;
      this.Label1.Text = resources.GetString("Label1.Text");
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(150, 124);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size((int) sbyte.MaxValue, 29);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Browse...";
      this.Button1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(7f, 15f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(418, 165);
      this.Controls.Add(this.Button1);
      this.Controls.Add(this.GroupBox1);
      this.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SetLibraryPath";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Set Library Path";
      this.GroupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
    
    }

        #endregion

    internal Button Button1;
        internal GroupBox GroupBox1;
        internal Label Label1;
        internal FolderBrowserDialog FolderBrowserDialog1;
        internal Font Font;
    
    }
}