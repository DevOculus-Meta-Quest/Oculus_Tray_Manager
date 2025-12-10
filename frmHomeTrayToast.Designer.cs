using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmHomeTrayToast
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
      this.components = (IContainer) new System.ComponentModel.Container();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.PictureBox1 = new PictureBox();
      this.Timer1 = new Timer(this.components);
      this.Timer2 = new Timer(this.components);
      this.ToolTip1 = new ToolTip(this.components);
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.SuspendLayout();
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label2.ForeColor = Color.DarkGray;
      this.Label2.Location = new Point(53, 30);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(173, 17);
      this.Label2.TabIndex = 8;
      this.Label2.Text = "Home is minimized to tray";
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Segoe UI", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.Label1.ForeColor = Color.White;
      this.Label1.Location = new Point(53, 13);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(111, 17);
      this.Label1.TabIndex = 7;
      this.Label1.Text = "Oculus Tray Tool";
      this.PictureBox1.Image = (Image) (System.Drawing.Image)OculusTrayTool.My.Resources.Resources.App_Blue_32;
      this.PictureBox1.Location = new Point(15, 18);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(32, 29);
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 6;
      this.PictureBox1.TabStop = false;
      this.Timer1.Interval = 50;
      this.Timer2.Interval = 2500;
      this.ToolTip1.AutomaticDelay = 50;
      this.AutoScaleDimensions = new SizeF(96f, 96f);
      this.AutoScaleMode = AutoScaleMode.Dpi;
      this.BackColor = Color.Black;
      this.ClientSize = new Size(259, 63);
      this.ControlBox = false;
      this.Controls.Add(this.Label2);
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.PictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "frmHomeTrayToast";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "HomeTrayToast";
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    
    }

        #endregion

    internal Label Label2;
    internal Label Label1;
    internal PictureBox PictureBox1;
    internal Timer Timer1;
    internal Timer Timer2;
        internal ToolTip ToolTip1;
    
    }
}