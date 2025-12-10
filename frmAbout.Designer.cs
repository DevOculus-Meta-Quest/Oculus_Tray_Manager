using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmAbout
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
      this.LinkLabel1 = new LinkLabel();
      this.PictureBox1 = new PictureBox();
      this.GroupBox1 = new GroupBox();
      this.LinkLabel2 = new LinkLabel();
      this.Label7 = new Label();
      this.Label6 = new Label();
      this.Label5 = new Label();
      this.Label4 = new Label();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      this.LinkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.LinkLabel1.AutoSize = true;
      this.LinkLabel1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.LinkLabel1.Location = new Point(209, 128);
      this.LinkLabel1.Name = "LinkLabel1";
      this.LinkLabel1.Size = new Size(102, 15);
      this.LinkLabel1.TabIndex = 0;
      this.LinkLabel1.TabStop = true;
      this.LinkLabel1.Text = "Open User Guide";
      this.PictureBox1.Cursor = Cursors.Hand;
      this.PictureBox1.Image = (System.Drawing.Image)resources.GetObject("PictureBox1.Image");
      this.PictureBox1.Location = new Point(13, 123);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(88, 27);
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 2;
      this.PictureBox1.TabStop = false;
      this.GroupBox1.Controls.Add(this.LinkLabel2);
      this.GroupBox1.Controls.Add(this.Label7);
      this.GroupBox1.Controls.Add(this.Label6);
      this.GroupBox1.Controls.Add(this.Label5);
      this.GroupBox1.Controls.Add(this.Label4);
      this.GroupBox1.Controls.Add(this.Label3);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(13, 4);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(305, 113);
      this.GroupBox1.TabIndex = 3;
      this.GroupBox1.TabStop = false;
      this.LinkLabel2.AutoSize = true;
      this.LinkLabel2.Location = new Point(108, 87);
      this.LinkLabel2.Name = "LinkLabel2";
      this.LinkLabel2.Size = new Size(114, 13);
      this.LinkLabel2.TabIndex = 7;
      this.LinkLabel2.TabStop = true;
      this.LinkLabel2.Text = "https://apollyonvr.com";
      this.Label7.Location = new Point(7, 87);
      this.Label7.Name = "Label7";
      this.Label7.Size = new Size(55, 13);
      this.Label7.TabIndex = 6;
      this.Label7.Text = "Website: ";
      this.Label6.ForeColor = Color.Crimson;
      this.Label6.Location = new Point(103, 65);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(143, 15);
      this.Label6.TabIndex = 5;
      this.Label6.Text = " ApollyonVR@gmail.com";
      this.Label5.ForeColor = Color.Crimson;
      this.Label5.Location = new Point(103, 42);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(100, 15);
      this.Label5.TabIndex = 4;
      this.Label5.Text = " ApollyonVR";
      this.Label4.ForeColor = Color.Crimson;
      this.Label4.Location = new Point(105, 20);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(100, 15);
      this.Label4.TabIndex = 3;
      this.Label4.Text = "Label4";
      this.Label3.Location = new Point(7, 65);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(39, 13);
      this.Label3.TabIndex = 2;
      this.Label3.Text = "Email: ";
      this.Label2.Location = new Point(7, 42);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(69, 13);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Created by: ";
      this.Label1.Location = new Point(7, 20);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(100, 13);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Oculus Tray Tool";
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.White;
      this.ClientSize = new Size(330, 158);
      this.Controls.Add(this.GroupBox1);
      this.Controls.Add(this.LinkLabel1);
      this.Controls.Add(this.PictureBox1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAbout";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "About";
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    
    }

        #endregion

    internal LinkLabel LinkLabel1;
    internal PictureBox PictureBox1;
    internal LinkLabel LinkLabel2;
        internal GroupBox GroupBox1;
        internal Label Label7;
        internal Label Label6;
        internal Label Label5;
        internal Label Label4;
        internal Label Label3;
        internal Label Label2;
        internal Label Label1;
    
    }
}