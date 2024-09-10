namespace OculusTrayTool
{
	// Token: 0x0200001E RID: 30
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmDownloading : global::System.Windows.Forms.Form
	{
		// Token: 0x0600027A RID: 634 RVA: 0x0000DE2C File Offset: 0x0000C02C
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

		// Token: 0x0600027B RID: 635 RVA: 0x0000DE7C File Offset: 0x0000C07C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.Label1.Anchor = global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.Label1.Location = new global::System.Drawing.Point(4, 15);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(252, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Updating Database:  0%";
			this.Label1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(258, 41);
			base.ControlBox = false;
			base.Controls.Add(this.Label1);
			this.ForeColor = global::System.Drawing.Color.DodgerBlue;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "frmDownloading";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			base.ResumeLayout(false);
		}

		// Token: 0x040000AD RID: 173
		private global::System.ComponentModel.IContainer components;
	}
}
