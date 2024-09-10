namespace OculusTrayTool
{
	// Token: 0x02000026 RID: 38
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmProcessing : global::System.Windows.Forms.Form
	{
		// Token: 0x060003D3 RID: 979 RVA: 0x00016F60 File Offset: 0x00015160
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x00016F98 File Offset: 0x00015198
		private void InitializeComponent()
		{
			this.progressBar1 = new global::OculusTrayTool.TextProgressBar();
			base.SuspendLayout();
			this.progressBar1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.progressBar1.Location = new global::System.Drawing.Point(0, 0);
			this.progressBar1.Message = null;
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(300, 52);
			this.progressBar1.TabIndex = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(300, 52);
			base.ControlBox = false;
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmProcessing";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Processing";
			base.TopMost = true;
			base.ResumeLayout(false);
		}

		// Token: 0x0400013E RID: 318
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400013F RID: 319
		private global::OculusTrayTool.TextProgressBar progressBar1;
	}
}
