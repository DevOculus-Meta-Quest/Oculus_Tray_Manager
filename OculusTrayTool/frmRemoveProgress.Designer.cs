namespace OculusTrayTool
{
	// Token: 0x02000041 RID: 65
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmRemoveProgress : global::System.Windows.Forms.Form
	{
		// Token: 0x06000578 RID: 1400 RVA: 0x0002CBFC File Offset: 0x0002ADFC
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

		// Token: 0x06000579 RID: 1401 RVA: 0x0002CC4C File Offset: 0x0002AE4C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.ListBox1 = new global::System.Windows.Forms.ListBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.ListBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.ListBox1.FormattingEnabled = true;
			this.ListBox1.Location = new global::System.Drawing.Point(12, 12);
			this.ListBox1.Name = "ListBox1";
			this.ListBox1.Size = new global::System.Drawing.Size(703, 134);
			this.ListBox1.TabIndex = 0;
			this.Button1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(640, 152);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Close";
			this.Button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(727, 185);
			base.ControlBox = false;
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.ListBox1);
			base.Name = "RemoveProgress";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Progress";
			base.ResumeLayout(false);
		}

		// Token: 0x0400020F RID: 527
		private global::System.ComponentModel.IContainer components;
	}
}
