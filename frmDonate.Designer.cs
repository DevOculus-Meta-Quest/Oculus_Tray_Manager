using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmDonate
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmDonate));
      this.GroupBox1 = new GroupBox();
      this.GroupBox3 = new GroupBox();
      this.Label5 = new Label();
      this.PictureBox4 = new PictureBox();
      this.Label2 = new Label();
      this.Label4 = new Label();
      this.Label6 = new Label();
      this.Label3 = new Label();
      this.GroupBox4 = new GroupBox();
      this.PictureBox3 = new PictureBox();
      this.PictureBox1 = new PictureBox();
      this.PictureBox2 = new PictureBox();
      this.Label1 = new Label();
      this.LinkLabel1 = new LinkLabel();
      this.GroupBox1.SuspendLayout();
      ((ISupportInitialize) this.PictureBox4).BeginInit();
      ((ISupportInitialize) this.PictureBox3).BeginInit();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      ((ISupportInitialize) this.PictureBox2).BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add(this.GroupBox3);
      this.GroupBox1.Controls.Add(this.Label5);
      this.GroupBox1.Controls.Add(this.PictureBox4);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Controls.Add(this.Label4);
      this.GroupBox1.Controls.Add(this.Label6);
      this.GroupBox1.Controls.Add(this.Label3);
      this.GroupBox1.Controls.Add(this.GroupBox4);
      this.GroupBox1.Controls.Add(this.PictureBox3);
      this.GroupBox1.Controls.Add(this.PictureBox1);
      this.GroupBox1.Controls.Add(this.PictureBox2);
      this.GroupBox1.Controls.Add(this.Label1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(513, 177);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.GroupBox3.Location = new Point(54, 81);
      this.GroupBox3.Name = "GroupBox3";
      this.GroupBox3.Size = new Size(147, 10);
      this.GroupBox3.TabIndex = 15;
      this.GroupBox3.TabStop = false;
      this.Label5.AutoSize = true;
      this.Label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label5.ForeColor = Color.DodgerBlue;
      this.Label5.Location = new Point(415, 138);
      this.Label5.Name = "Label5";
      this.Label5.Size = new Size(50, 15);
      this.Label5.TabIndex = 14;
      this.Label5.Text = "15 Euro";
      this.PictureBox4.Cursor = Cursors.Hand;
      this.PictureBox4.Image = (Image) (System.Drawing.Image)OculusTrayTool.My.Resources.Resources.paypal;
      this.PictureBox4.Location = new Point(396, 113);
      this.PictureBox4.Name = "PictureBox4";
      this.PictureBox4.Size = new Size(87, 23);
      this.PictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox4.TabIndex = 10;
      this.PictureBox4.TabStop = false;
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.ForeColor = Color.DodgerBlue;
      this.Label2.Location = new Point(53, 138);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(43, 15);
      this.Label2.TabIndex = 11;
      this.Label2.Text = "1 Euro";
      this.Label4.AutoSize = true;
      this.Label4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label4.ForeColor = Color.DodgerBlue;
      this.Label4.Location = new Point(297, 138);
      this.Label4.Name = "Label4";
      this.Label4.Size = new Size(50, 15);
      this.Label4.TabIndex = 13;
      this.Label4.Text = "10 Euro";
      this.Label6.AutoSize = true;
      this.Label6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label6.Location = new Point(238, 79);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(51, 15);
      this.Label6.TabIndex = 7;
      this.Label6.Text = "PayPal";
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.ForeColor = Color.DodgerBlue;
      this.Label3.Location = new Point(173, 136);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(43, 15);
      this.Label3.TabIndex = 12;
      this.Label3.Text = "5 Euro";
      this.GroupBox4.Location = new Point(319, 81);
      this.GroupBox4.Name = "GroupBox4";
      this.GroupBox4.Size = new Size(147, 10);
      this.GroupBox4.TabIndex = 3;
      this.GroupBox4.TabStop = false;
      this.PictureBox3.Cursor = Cursors.Hand;
      this.PictureBox3.Image = (Image) (System.Drawing.Image)OculusTrayTool.My.Resources.Resources.paypal;
      this.PictureBox3.Location = new Point(278, 113);
      this.PictureBox3.Name = "PictureBox3";
      this.PictureBox3.Size = new Size(87, 22);
      this.PictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox3.TabIndex = 9;
      this.PictureBox3.TabStop = false;
      this.PictureBox1.Cursor = Cursors.Hand;
      this.PictureBox1.Image = (Image) (System.Drawing.Image)OculusTrayTool.My.Resources.Resources.paypal;
      this.PictureBox1.Location = new Point(31, 113);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(87, 22);
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 7;
      this.PictureBox1.TabStop = false;
      this.PictureBox2.Cursor = Cursors.Hand;
      this.PictureBox2.Image = (Image) (System.Drawing.Image)OculusTrayTool.My.Resources.Resources.paypal;
      this.PictureBox2.Location = new Point(153, 113);
      this.PictureBox2.Name = "PictureBox2";
      this.PictureBox2.Size = new Size(87, 22);
      this.PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox2.TabIndex = 8;
      this.PictureBox2.TabStop = false;
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.DodgerBlue;
      this.Label1.Location = new Point(15, 16);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(491, 34);
      this.Label1.TabIndex = 6;
      this.Label1.Text = "Thanks for donating to support and show your appreciation for this project.  Cheers!";
      this.Label1.TextAlign = ContentAlignment.MiddleCenter;
      this.LinkLabel1.AutoSize = true;
      this.LinkLabel1.Location = new Point(13, 196);
      this.LinkLabel1.Name = "LinkLabel1";
      this.LinkLabel1.Size = new Size(65, 13);
      this.LinkLabel1.TabIndex = 1;
      this.LinkLabel1.TabStop = true;
      this.LinkLabel1.Text = "Visit website";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(534, 221);
      this.Controls.Add(this.LinkLabel1);
      this.Controls.Add(this.GroupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmDonate";
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Donate";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      ((ISupportInitialize) this.PictureBox4).EndInit();
      ((ISupportInitialize) this.PictureBox3).EndInit();
      ((ISupportInitialize) this.PictureBox1).EndInit();
      ((ISupportInitialize) this.PictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    
      this.PictureBox4.Click += new EventHandler(this.PictureBox4_Click);
      this.PictureBox3.Click += new EventHandler(this.PictureBox3_Click);
      this.PictureBox2.Click += new EventHandler(this.PictureBox2_Click);
      this.PictureBox1.Click += new EventHandler(this.PictureBox1_Click);
      this.LinkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
    }

        #endregion

    internal PictureBox PictureBox4;
    internal PictureBox PictureBox3;
    internal PictureBox PictureBox2;
    internal PictureBox PictureBox1;
    internal LinkLabel LinkLabel1;
        internal GroupBox GroupBox1;
        internal GroupBox GroupBox3;
        internal Label Label5;
        internal Label Label2;
        internal Label Label4;
        internal Label Label6;
        internal Label Label3;
        internal GroupBox GroupBox4;
        internal Label Label1;
    
    }
}