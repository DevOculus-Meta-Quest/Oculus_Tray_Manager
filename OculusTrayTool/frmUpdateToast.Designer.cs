namespace OculusTrayTool
{
	// Token: 0x0200004D RID: 77
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmUpdateToast : global::System.Windows.Forms.Form
	{
		// Token: 0x060005C5 RID: 1477 RVA: 0x0002E8FC File Offset: 0x0002CAFC
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

		// Token: 0x060005C6 RID: 1478 RVA: 0x0002E94C File Offset: 0x0002CB4C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.Timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.Timer2 = new global::System.Windows.Forms.Timer(this.components);
			this.PictureBox2 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox2).BeginInit();
			base.SuspendLayout();
			this.Label1.AutoSize = true;
			this.Label1.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = global::System.Drawing.Color.White;
			this.Label1.Location = new global::System.Drawing.Point(53, 13);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(111, 17);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Oculus Tray Tool";
			this.Label2.AutoSize = true;
			this.Label2.Font = new global::System.Drawing.Font("Segoe UI", 9.75f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = global::System.Drawing.Color.DarkGray;
			this.Label2.Location = new global::System.Drawing.Point(53, 30);
			this.Label2.Name = "Label2";
			this.Label2.Size = new global::System.Drawing.Size(117, 17);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Update Available!";
			this.Timer1.Interval = 3000;
			this.Timer2.Interval = 50;
			this.PictureBox2.Image = global::OculusTrayTool.My.Resources.Resources.App_Blue_32;
			this.PictureBox2.Location = new global::System.Drawing.Point(15, 18);
			this.PictureBox2.Name = "PictureBox2";
			this.PictureBox2.Size = new global::System.Drawing.Size(32, 29);
			this.PictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox2.TabIndex = 4;
			this.PictureBox2.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSize = true;
			this.BackColor = global::System.Drawing.Color.Black;
			base.ClientSize = new global::System.Drawing.Size(259, 63);
			base.ControlBox = false;
			base.Controls.Add(this.PictureBox2);
			base.Controls.Add(this.Label2);
			base.Controls.Add(this.Label1);
			this.DoubleBuffered = true;
			this.ForeColor = global::System.Drawing.Color.DodgerBlue;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "UpdateToast";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Loading";
			((global::System.ComponentModel.ISupportInitialize)this.PictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000250 RID: 592
		private global::System.ComponentModel.IContainer components;
	}
}
