namespace OculusTrayTool
{
	// Token: 0x0200002E RID: 46
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmHomeTrayToast : global::System.Windows.Forms.Form
	{
		// Token: 0x06000405 RID: 1029 RVA: 0x0001BC34 File Offset: 0x00019E34
		[global::System.Diagnostics.DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				bool flag = disposing && this.components != null;
				if (flag)
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x0001BC84 File Offset: 0x00019E84
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.PictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.Timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.Timer2 = new global::System.Windows.Forms.Timer(this.components);
			this.ToolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).BeginInit();
			base.SuspendLayout();
			this.Label2.AutoSize = true;
			this.Label2.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = global::System.Drawing.Color.DarkGray;
			this.Label2.Location = new global::System.Drawing.Point(53, 30);
			this.Label2.Name = "Label2";
			this.Label2.Size = new global::System.Drawing.Size(173, 17);
			this.Label2.TabIndex = 8;
			this.Label2.Text = "Home is minimized to tray";
			this.Label1.AutoSize = true;
			this.Label1.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = global::System.Drawing.Color.White;
			this.Label1.Location = new global::System.Drawing.Point(53, 13);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(111, 17);
			this.Label1.TabIndex = 7;
			this.Label1.Text = "Oculus Tray Tool";
			this.PictureBox1.Image = global::OculusTrayTool.My.Resources.Resources.App_Blue_32;
			this.PictureBox1.Location = new global::System.Drawing.Point(15, 18);
			this.PictureBox1.Name = "PictureBox1";
			this.PictureBox1.Size = new global::System.Drawing.Size(32, 29);
			this.PictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox1.TabIndex = 6;
			this.PictureBox1.TabStop = false;
			this.Timer1.Interval = 50;
			this.Timer2.Interval = 2500;
			this.ToolTip1.AutomaticDelay = 50;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = global::System.Drawing.Color.Black;
			base.ClientSize = new global::System.Drawing.Size(259, 63);
			base.ControlBox = false;
			base.Controls.Add(this.Label2);
			base.Controls.Add(this.Label1);
			base.Controls.Add(this.PictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmHomeTrayToast";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "HomeTrayToast";
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000168 RID: 360
		private global::System.ComponentModel.IContainer components;
	}
}
