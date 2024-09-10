namespace OculusTrayTool
{
	// Token: 0x02000023 RID: 35
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class FrmIgnoredApps : global::System.Windows.Forms.Form
	{
		// Token: 0x06000343 RID: 835 RVA: 0x00013CC0 File Offset: 0x00011EC0
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

		// Token: 0x06000344 RID: 836 RVA: 0x00013D10 File Offset: 0x00011F10
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.FrmIgnoredApps));
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.ListView1 = new global::System.Windows.Forms.ListView();
			this.ColumnHeader1 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader2 = new global::System.Windows.Forms.ColumnHeader();
			this.ColumnHeader3 = new global::System.Windows.Forms.ColumnHeader();
			this.Button1 = new global::System.Windows.Forms.Button();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			base.SuspendLayout();
			this.GroupBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.GroupBox1.Controls.Add(this.ListView1);
			this.GroupBox1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(839, 377);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Ignored Apps - Select to include";
			this.ListView1.CheckBoxes = true;
			this.ListView1.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[] { this.ColumnHeader1, this.ColumnHeader2, this.ColumnHeader3 });
			this.ListView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.ListView1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.ListView1.FullRowSelect = true;
			this.ListView1.GridLines = true;
			this.ListView1.Location = new global::System.Drawing.Point(3, 16);
			this.ListView1.Name = "ListView1";
			this.ListView1.Size = new global::System.Drawing.Size(833, 358);
			this.ListView1.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.ListView1.TabIndex = 0;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			this.ListView1.View = global::System.Windows.Forms.View.Details;
			this.ColumnHeader1.Text = "Name";
			this.ColumnHeader1.Width = 158;
			this.ColumnHeader2.Text = "Launch Parameters";
			this.ColumnHeader2.Width = 254;
			this.ColumnHeader3.Text = "Path";
			this.ColumnHeader3.Width = 414;
			this.Button1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.Button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button1.Location = new global::System.Drawing.Point(773, 395);
			this.Button1.Name = "Button1";
			this.Button1.Size = new global::System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 1;
			this.Button1.Text = "Close";
			this.Button1.UseVisualStyleBackColor = true;
			this.Button2.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button2.Location = new global::System.Drawing.Point(15, 395);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(107, 23);
			this.Button2.TabIndex = 2;
			this.Button2.Text = "Include Selected";
			this.Button2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(863, 430);
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.Button1);
			base.Controls.Add(this.GroupBox1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FrmIgnoredApps";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ignored Apps";
			this.GroupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000106 RID: 262
		private global::System.ComponentModel.IContainer components;
	}
}
