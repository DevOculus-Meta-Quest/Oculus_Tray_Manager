namespace OculusTrayTool
{
	// Token: 0x02000020 RID: 32
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmEditVoiceCommand : global::System.Windows.Forms.Form
	{
		// Token: 0x060002DC RID: 732 RVA: 0x00010A14 File Offset: 0x0000EC14
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

		// Token: 0x060002DD RID: 733 RVA: 0x00010A64 File Offset: 0x0000EC64
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.Label1 = new global::System.Windows.Forms.Label();
			this.TextBoxPhrase = new global::System.Windows.Forms.TextBox();
			this.Label2 = new global::System.Windows.Forms.Label();
			this.LabelAction = new global::System.Windows.Forms.Label();
			this.ComboEnabled = new global::System.Windows.Forms.ComboBox();
			this.Label3 = new global::System.Windows.Forms.Label();
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.Label1.AutoSize = true;
			this.Label1.Location = new global::System.Drawing.Point(15, 30);
			this.Label1.Name = "Label1";
			this.Label1.Size = new global::System.Drawing.Size(40, 13);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Action:";
			this.TextBoxPhrase.Location = new global::System.Drawing.Point(64, 53);
			this.TextBoxPhrase.Name = "TextBoxPhrase";
			this.TextBoxPhrase.Size = new global::System.Drawing.Size(249, 20);
			this.TextBoxPhrase.TabIndex = 3;
			this.Label2.AutoSize = true;
			this.Label2.Location = new global::System.Drawing.Point(15, 56);
			this.Label2.Name = "Label2";
			this.Label2.Size = new global::System.Drawing.Size(43, 13);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Phrase:";
			this.LabelAction.AutoSize = true;
			this.LabelAction.ForeColor = global::System.Drawing.Color.Black;
			this.LabelAction.Location = new global::System.Drawing.Point(61, 30);
			this.LabelAction.Name = "LabelAction";
			this.LabelAction.Size = new global::System.Drawing.Size(37, 13);
			this.LabelAction.TabIndex = 4;
			this.LabelAction.Text = "Action";
			this.ComboEnabled.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboEnabled.FormattingEnabled = true;
			this.ComboEnabled.Items.AddRange(new object[] { "True", "False" });
			this.ComboEnabled.Location = new global::System.Drawing.Point(64, 79);
			this.ComboEnabled.Name = "ComboEnabled";
			this.ComboEnabled.Size = new global::System.Drawing.Size(121, 21);
			this.ComboEnabled.TabIndex = 5;
			this.Label3.AutoSize = true;
			this.Label3.Location = new global::System.Drawing.Point(15, 82);
			this.Label3.Name = "Label3";
			this.Label3.Size = new global::System.Drawing.Size(49, 13);
			this.Label3.TabIndex = 6;
			this.Label3.Text = "Enabled:";
			this.GroupBox1.Controls.Add(this.TextBoxPhrase);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.ComboEnabled);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.LabelAction);
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(334, 132);
			this.GroupBox1.TabIndex = 7;
			this.GroupBox1.TabStop = false;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.Location = new global::System.Drawing.Point(271, 150);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 8;
			this.Button1.Text = "Save";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.Location = new global::System.Drawing.Point(12, 150);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(75, 23);
			this.Button2.TabIndex = 9;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(356, 179);
			base.ControlBox = false;
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.GroupBox1);
			this.ForeColor = global::System.Drawing.Color.DodgerBlue;
			base.Name = "frmEditVoiceCommand";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Voice Command";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000DA RID: 218
		private global::System.ComponentModel.IContainer components;
	}
}
