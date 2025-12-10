using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmLoading
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
      this.Label1 = new Label();
      this.Label2 = new Label();
      this.PictureBox2 = new PictureBox();
      ((ISupportInitialize) this.PictureBox2).BeginInit();
      this.SuspendLayout();
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.White;
      this.Label1.Location = new Point(53, 13);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(111, 17);
      this.Label1.TabIndex = 1;
      this.Label1.Text = "Oculus Tray Tool";
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label2.ForeColor = Color.DarkGray;
      this.Label2.Location = new Point(53, 30);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(166, 17);
      this.Label2.TabIndex = 2;
      this.Label2.Text = "Starting up, please wait...";
      this.PictureBox2.Image = (Image) (System.Drawing.Image)OculusTrayTool.My.Resources.Resources.App_Blue_32;
      this.PictureBox2.Location = new Point(15, 18);
      this.PictureBox2.Name = "PictureBox2";
      this.PictureBox2.Size = new Size(32, 29);
      this.PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox2.TabIndex = 4;
      this.PictureBox2.TabStop = false;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.AutoSize = true;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(259, 63);
      this.ControlBox = false;
      this.Controls.Add(this.PictureBox2);
      this.Controls.Add(this.Label2);
      this.Controls.Add(this.Label1);
      this.ForeColor = Color.DodgerBlue;
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "frmLoading";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.Manual;
      this.Text = "Loading";
      ((ISupportInitialize) this.PictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    
    }

        #endregion

    internal Label Label1;
    internal Label Label2;
        internal PictureBox PictureBox2;
    
    }
}