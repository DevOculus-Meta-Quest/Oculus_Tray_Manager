namespace OculusTrayTool
{
	// Token: 0x02000025 RID: 37
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmMicNotDefaultWarning : global::System.Windows.Forms.Form
	{
		// Token: 0x060003C8 RID: 968 RVA: 0x00016B9C File Offset: 0x00014D9C
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

		// Token: 0x060003C9 RID: 969 RVA: 0x00016BEC File Offset: 0x00014DEC
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.frmMicNotDefaultWarning));
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.CheckBox1 = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.Label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.Location = new global::System.Drawing.Point(12, 9);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(380, 71);
			this.Label1.TabIndex = 0;
			this.Label1.Text = componentResourceManager.GetString("Label1.Text");
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.Location = new global::System.Drawing.Point(334, 83);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(58, 23);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Close";
			this.Button1.UseVisualStyleBackColor = true;
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Location = new global::System.Drawing.Point(15, 87);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new global::System.Drawing.Size(127, 17);
			this.CheckBox1.TabIndex = 2;
			this.CheckBox1.Text = "Don't show this again";
			this.CheckBox1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(404, 118);
			base.ControlBox = false;
			base.Controls.Add(this.CheckBox1);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.Label1);
			this.ForeColor = global::System.Drawing.Color.DodgerBlue;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "frmMicNotDefaultWarning";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Oculus Tray Tool";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400013A RID: 314
		private global::System.ComponentModel.IContainer components;
	}
}
