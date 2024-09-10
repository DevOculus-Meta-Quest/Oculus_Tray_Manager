namespace OculusTrayTool
{
	// Token: 0x02000040 RID: 64
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmProperties : global::System.Windows.Forms.Form
	{
		// Token: 0x06000560 RID: 1376 RVA: 0x0002C158 File Offset: 0x0002A358
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

		// Token: 0x06000561 RID: 1377 RVA: 0x0002C1A8 File Offset: 0x0002A3A8
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.frmProperties));
			this.RichTextBox1 = new global::System.Windows.Forms.RichTextBox();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.LabelProperties = new global::System.Windows.Forms.Label();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.CheckBox1 = new global::System.Windows.Forms.CheckBox();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.LabelProperties2 = new global::System.Windows.Forms.Label();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.RichTextBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.RichTextBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.RichTextBox1.Location = new global::System.Drawing.Point(12, 124);
			this.RichTextBox1.Name = "RichTextBox1";
			this.RichTextBox1.Size = new global::System.Drawing.Size(660, 360);
			this.RichTextBox1.TabIndex = 0;
			this.RichTextBox1.Text = "";
			this.GroupBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.GroupBox1.Controls.Add(this.LabelProperties);
			this.GroupBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(660, 87);
			this.GroupBox1.TabIndex = 1;
			this.GroupBox1.TabStop = false;
			this.LabelProperties.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.LabelProperties.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.LabelProperties.Location = new global::System.Drawing.Point(6, 12);
			this.LabelProperties.Name = "LabelProperties";
			this.LabelProperties.Size = new global::System.Drawing.Size(647, 72);
			this.LabelProperties.TabIndex = 0;
			this.LabelProperties.Text = componentResourceManager.GetString("LabelProperties.Text");
			this.LabelProperties.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.Button1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(597, 493);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(75, 25);
			this.Button1.TabIndex = 2;
			this.Button1.Text = "Verify file";
			this.Button1.UseVisualStyleBackColor = true;
			this.CheckBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Checked = true;
			this.CheckBox1.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.CheckBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.CheckBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.CheckBox1.Location = new global::System.Drawing.Point(452, 497);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new global::System.Drawing.Size(143, 19);
			this.CheckBox1.TabIndex = 3;
			this.CheckBox1.Text = "Backup before saving";
			this.CheckBox1.UseVisualStyleBackColor = true;
			this.Button2.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Button2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button2.Location = new global::System.Drawing.Point(12, 493);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(75, 25);
			this.Button2.TabIndex = 4;
			this.Button2.Text = "Close";
			this.Button2.UseVisualStyleBackColor = true;
			this.LabelProperties2.AutoSize = true;
			this.LabelProperties2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.LabelProperties2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.LabelProperties2.Location = new global::System.Drawing.Point(12, 103);
			this.LabelProperties2.Name = "LabelProperties2";
			this.LabelProperties2.Size = new global::System.Drawing.Size(65, 15);
			this.LabelProperties2.TabIndex = 5;
			this.LabelProperties2.Text = "Filename: ";
			this.TextBox1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.TextBox1.Location = new global::System.Drawing.Point(76, 105);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new global::System.Drawing.Size(626, 13);
			this.TextBox1.TabIndex = 7;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(684, 525);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.LabelProperties2);
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.CheckBox1);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.GroupBox1);
			base.Controls.Add(this.RichTextBox1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(700, 564);
			base.Name = "Properties";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "App Properties";
			this.GroupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000205 RID: 517
		private global::System.ComponentModel.IContainer components;
	}
}
