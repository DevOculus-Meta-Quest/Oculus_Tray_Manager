namespace OculusTrayTool
{
	// Token: 0x02000059 RID: 89
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmSSChanged : global::System.Windows.Forms.Form
	{
		// Token: 0x060008E7 RID: 2279 RVA: 0x00051D84 File Offset: 0x0004FF84
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

		// Token: 0x060008E8 RID: 2280 RVA: 0x00051DD4 File Offset: 0x0004FFD4
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.frmSSChanged));
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.CheckBox1 = new global::System.Windows.Forms.CheckBox();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.Label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Label1.Location = new global::System.Drawing.Point(6, 16);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(250, 36);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Restart any running VR application to apply the new Super Sampling value to it.";
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(214, 64);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(45, 25);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "OK";
			this.Button1.UseVisualStyleBackColor = true;
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.GroupBox1.Location = new global::System.Drawing.Point(3, 3);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(260, 55);
			this.GroupBox1.TabIndex = 2;
			this.GroupBox1.TabStop = false;
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.CheckBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.CheckBox1.Location = new global::System.Drawing.Point(12, 68);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new global::System.Drawing.Size(175, 19);
			this.CheckBox1.TabIndex = 3;
			this.CheckBox1.Text = "Got it, don't show this again";
			this.CheckBox1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(267, 95);
			base.Controls.Add(this.CheckBox1);
			base.Controls.Add(this.GroupBox1);
			base.Controls.Add(this.Button1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ssChanged";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Restart Reminder";
			this.GroupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040003CC RID: 972
		private global::System.ComponentModel.IContainer components;
	}
}
