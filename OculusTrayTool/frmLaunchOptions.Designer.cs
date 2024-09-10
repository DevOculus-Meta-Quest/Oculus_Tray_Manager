namespace OculusTrayTool
{
	// Token: 0x02000030 RID: 48
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmLaunchOptions : global::System.Windows.Forms.Form
	{
		// Token: 0x0600049E RID: 1182 RVA: 0x00022A28 File Offset: 0x00020C28
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

		// Token: 0x0600049F RID: 1183 RVA: 0x00022A78 File Offset: 0x00020C78
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.GroupBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.GroupBox1.Controls.Add(this.TextBox1);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(321, 65);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.TextBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.TextBox1.Location = new global::System.Drawing.Point(84, 27);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new global::System.Drawing.Size(231, 20);
			this.TextBox1.TabIndex = 1;
			this.Label1.AutoSize = true;
			this.Label1.Location = new global::System.Drawing.Point(15, 30);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(63, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Parameters:";
			this.Button1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(258, 86);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Launch App";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button2.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button2.Location = new global::System.Drawing.Point(12, 86);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 2;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(345, 121);
			base.ControlBox = false;
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.GroupBox1);
			base.Name = "LaunchOptions";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Launch Options";
			base.TopMost = true;
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040001B6 RID: 438
		private global::System.ComponentModel.IContainer components;
	}
}
