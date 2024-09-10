namespace OculusTrayTool
{
	// Token: 0x0200004A RID: 74
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmSetLibraryPath : global::System.Windows.Forms.Form
	{
		// Token: 0x06000595 RID: 1429 RVA: 0x0002D7EC File Offset: 0x0002B9EC
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

		// Token: 0x06000596 RID: 1430 RVA: 0x0002D83C File Offset: 0x0002BA3C
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.frmSetLibraryPath));
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.Label1 = new global::System.Windows.Forms.Label();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.FolderBrowserDialog1 = new global::System.Windows.Forms.FolderBrowserDialog();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(394, 97);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.Label1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Label1.Location = new global::System.Drawing.Point(6, 17);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(382, 77);
			this.Label1.TabIndex = 0;
			this.Label1.Text = componentResourceManager.GetString("Label1.Text");
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(150, 124);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(127, 29);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Browse...";
			this.Button1.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 15f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(418, 165);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.GroupBox1);
			this.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SetLibraryPath";
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Set Library Path";
			this.GroupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x0400023E RID: 574
		private global::System.ComponentModel.IContainer components;
	}
}
