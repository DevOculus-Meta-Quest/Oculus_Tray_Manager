namespace OculusTrayTool
{
	// Token: 0x0200004B RID: 75
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmStartupType : global::System.Windows.Forms.Form
	{
		// Token: 0x060005A1 RID: 1441 RVA: 0x0002DC70 File Offset: 0x0002BE70
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

		// Token: 0x060005A2 RID: 1442 RVA: 0x0002DCC0 File Offset: 0x0002BEC0
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Label1 = new global::System.Windows.Forms.Label();
			this.RadioButton1 = new global::System.Windows.Forms.RadioButton();
			this.RadioButton2 = new global::System.Windows.Forms.RadioButton();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.Label1.AutoSize = true;
			this.Label1.Location = new global::System.Drawing.Point(6, 17);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(395, 15);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Select the method for launching Oculus Tray Tool when Windows starts.";
			this.RadioButton1.AutoSize = true;
			this.RadioButton1.Location = new global::System.Drawing.Point(46, 58);
			this.RadioButton1.Name = "RadioButton1";
			this.RadioButton1.Size = new global::System.Drawing.Size(283, 19);
			this.RadioButton1.TabIndex = 0;
			this.RadioButton1.TabStop = true;
			this.RadioButton1.Text = "Regular startup (UAC should prompt if enabled)";
			this.RadioButton1.UseVisualStyleBackColor = true;
			this.RadioButton2.AutoSize = true;
			this.RadioButton2.Location = new global::System.Drawing.Point(46, 83);
			this.RadioButton2.Name = "RadioButton2";
			this.RadioButton2.Size = new global::System.Drawing.Size(339, 19);
			this.RadioButton2.TabIndex = 1;
			this.RadioButton2.TabStop = true;
			this.RadioButton2.Text = "Scheduled Task (UAC should not prompt, even if enabled)";
			this.RadioButton2.UseVisualStyleBackColor = true;
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.RadioButton2);
			this.GroupBox1.Controls.Add(this.RadioButton1);
			this.GroupBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(414, 123);
			this.GroupBox1.TabIndex = 2;
			this.GroupBox1.TabStop = false;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(351, 141);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 3;
			this.Button1.Text = "OK";
			this.Button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(440, 172);
			base.ControlBox = false;
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.GroupBox1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.Name = "StartupType";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Startup Method";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x04000243 RID: 579
		private global::System.ComponentModel.IContainer components;
	}
}
