using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace MetaQuestTrayTool.Forms
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
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkLabel1.Location = new System.Drawing.Point(209, 128);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(102, 15);
            this.LinkLabel1.TabIndex = 0;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "Open User Guide";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox1.Location = new System.Drawing.Point(13, 123);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(88, 27);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 2;
            this.PictureBox1.TabStop = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.LinkLabel2);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.GroupBox1.Location = new System.Drawing.Point(13, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(435, 113);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.Location = new System.Drawing.Point(108, 87);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(324, 13);
            this.LinkLabel2.TabIndex = 7;
            this.LinkLabel2.TabStop = true;
            this.LinkLabel2.Text = "https://github.com/DevOculus-Meta-Quest/Oculus_Tray_Manager";
            // 
            // Label7
            // 
            this.Label7.Location = new System.Drawing.Point(7, 87);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(55, 13);
            this.Label7.TabIndex = 6;
            this.Label7.Text = "Website: ";
            // 
            // Label6
            // 
            this.Label6.ForeColor = System.Drawing.Color.Crimson;
            this.Label6.Location = new System.Drawing.Point(103, 65);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(143, 15);
            this.Label6.TabIndex = 5;
            this.Label6.Text = " Eliminater74@gmail.com";
            // 
            // Label5
            // 
            this.Label5.ForeColor = System.Drawing.Color.Crimson;
            this.Label5.Location = new System.Drawing.Point(103, 42);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(100, 15);
            this.Label5.TabIndex = 4;
            this.Label5.Text = " Eliminater74";
            // 
            // Label4
            // 
            this.Label4.ForeColor = System.Drawing.Color.Crimson;
            this.Label4.Location = new System.Drawing.Point(105, 20);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(100, 15);
            this.Label4.TabIndex = 3;
            this.Label4.Text = "Label4";
            // 
            // Label3
            // 
            this.Label3.Location = new System.Drawing.Point(7, 65);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(39, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Email: ";
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(7, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Created by: ";
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(7, 20);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(100, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Meta Quest Tray Tool";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 158);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.LinkLabel1);
            this.Controls.Add(this.PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
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
