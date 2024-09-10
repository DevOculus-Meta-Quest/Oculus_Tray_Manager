namespace OculusTrayTool
{
	// Token: 0x0200002F RID: 47
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmLibrary : global::System.Windows.Forms.Form
	{
		// Token: 0x0600041D RID: 1053 RVA: 0x0001C3E0 File Offset: 0x0001A5E0
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

		// Token: 0x0600041E RID: 1054 RVA: 0x0001C430 File Offset: 0x0001A630
		[global::System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.frmLibrary));
			this.ContextMenuStrip2 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.ReEnableAppToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ShowAppInLibraryAndProfilesToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ContextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripMenuItem3 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItem4 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem5 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem6 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItem7 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem8 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem9 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.RemoveProfileToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ToolTip1 = new global::System.Windows.Forms.ToolTip(this.components);
			this.GroupBox1 = new global::System.Windows.Forms.GroupBox();
			this.TextBox1 = new global::System.Windows.Forms.TextBox();
			this.Button2 = new global::System.Windows.Forms.Button();
			this.Label6 = new global::System.Windows.Forms.Label();
			this.GroupBox2 = new global::System.Windows.Forms.GroupBox();
			this.MenuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.OptionsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.AddSteamVRToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ShowToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ShowRemoved3rdPartyAppsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.ShowIgnoredAppsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.RefreshLibraryToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.SortingToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.AscendingToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.DescendingToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.DotNetBarTabcontrol1 = new global::OculusTrayTool.DotNetBarTabcontrol();
			this.TabPage1 = new global::System.Windows.Forms.TabPage();
			this.PicturePlay = new global::System.Windows.Forms.PictureBox();
			this.ListView1 = new global::System.Windows.Forms.ListView();
			this.ContextMenuStrip2.SuspendLayout();
			this.ContextMenuStrip1.SuspendLayout();
			this.MenuStrip1.SuspendLayout();
			this.DotNetBarTabcontrol1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.PicturePlay).BeginInit();
			base.SuspendLayout();
			this.ContextMenuStrip2.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.ReEnableAppToolStripMenuItem, this.ShowAppInLibraryAndProfilesToolStripMenuItem });
			this.ContextMenuStrip2.Name = "ContextMenuStrip2";
			this.ContextMenuStrip2.Size = new global::System.Drawing.Size(246, 48);
			this.ReEnableAppToolStripMenuItem.Enabled = false;
			this.ReEnableAppToolStripMenuItem.Name = "ReEnableAppToolStripMenuItem";
			this.ReEnableAppToolStripMenuItem.Size = new global::System.Drawing.Size(245, 22);
			this.ReEnableAppToolStripMenuItem.Text = "Re-Enable App";
			this.ReEnableAppToolStripMenuItem.Visible = false;
			this.ShowAppInLibraryAndProfilesToolStripMenuItem.Name = "ShowAppInLibraryAndProfilesToolStripMenuItem";
			this.ShowAppInLibraryAndProfilesToolStripMenuItem.Size = new global::System.Drawing.Size(245, 22);
			this.ShowAppInLibraryAndProfilesToolStripMenuItem.Text = "Show App in Library and Profiles";
			this.ContextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.ToolStripMenuItem3, this.ToolStripMenuItem2, this.ToolStripSeparator2, this.ToolStripMenuItem4, this.ToolStripMenuItem5, this.ToolStripMenuItem6, this.ToolStripSeparator3, this.ToolStripMenuItem7, this.ToolStripMenuItem8, this.ToolStripSeparator1,
				this.ToolStripMenuItem1, this.ToolStripMenuItem9, this.RemoveProfileToolStripMenuItem
			});
			this.ContextMenuStrip1.Name = "ContextMenuStrip1";
			this.ContextMenuStrip1.Size = new global::System.Drawing.Size(242, 242);
			this.ToolStripMenuItem3.Image = global::OculusTrayTool.My.Resources.Resources.refresh_16;
			this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
			this.ToolStripMenuItem3.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem3.Text = "Replace Icons";
			this.ToolStripMenuItem3.Visible = false;
			this.ToolStripMenuItem2.Image = global::OculusTrayTool.My.Resources.Resources.Icon_View;
			this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
			this.ToolStripMenuItem2.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem2.Text = "Show Properties";
			this.ToolStripSeparator2.Name = "ToolStripSeparator2";
			this.ToolStripSeparator2.Size = new global::System.Drawing.Size(238, 6);
			this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
			this.ToolStripMenuItem4.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem4.Text = "Hide App in Library";
			this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
			this.ToolStripMenuItem5.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem5.Text = "Hide App in Library and Profiles";
			this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
			this.ToolStripMenuItem6.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem6.Text = "Ignore App";
			this.ToolStripSeparator3.Name = "ToolStripSeparator3";
			this.ToolStripSeparator3.Size = new global::System.Drawing.Size(238, 6);
			this.ToolStripMenuItem7.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("ToolStripMenuItem7.Image");
			this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
			this.ToolStripMenuItem7.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem7.Text = "Launch App";
			this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
			this.ToolStripMenuItem8.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem8.Text = "Launch App with options..";
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new global::System.Drawing.Size(238, 6);
			this.ToolStripMenuItem1.Image = global::OculusTrayTool.My.Resources.Resources.Icon_Edit;
			this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
			this.ToolStripMenuItem1.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem1.Text = "Create Profile...";
			this.ToolStripMenuItem9.Image = global::OculusTrayTool.My.Resources.Resources.Icon_Edit;
			this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
			this.ToolStripMenuItem9.Size = new global::System.Drawing.Size(241, 22);
			this.ToolStripMenuItem9.Text = "Edit Profile...";
			this.RemoveProfileToolStripMenuItem.Image = global::OculusTrayTool.My.Resources.Resources.Icon_Delete;
			this.RemoveProfileToolStripMenuItem.Name = "RemoveProfileToolStripMenuItem";
			this.RemoveProfileToolStripMenuItem.Size = new global::System.Drawing.Size(241, 22);
			this.RemoveProfileToolStripMenuItem.Text = "Remove Profile";
			this.ToolTip1.AutoPopDelay = 10000;
			this.ToolTip1.InitialDelay = 200;
			this.ToolTip1.ReshowDelay = 100;
			this.GroupBox1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.GroupBox1.Location = new global::System.Drawing.Point(12, 30);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new global::System.Drawing.Size(1000, 5);
			this.GroupBox1.TabIndex = 14;
			this.GroupBox1.TabStop = false;
			this.TextBox1.Location = new global::System.Drawing.Point(68, 44);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new global::System.Drawing.Size(149, 20);
			this.TextBox1.TabIndex = 20;
			this.Button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.Button2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Button2.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Button2.Location = new global::System.Drawing.Point(223, 43);
			this.Button2.Name = "Button2";
			this.Button2.Size = new global::System.Drawing.Size(48, 22);
			this.Button2.TabIndex = 21;
			this.Button2.Text = "Go";
			this.Button2.UseVisualStyleBackColor = true;
			this.Label6.AutoSize = true;
			this.Label6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Label6.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.Label6.Location = new global::System.Drawing.Point(13, 47);
			this.Label6.Name = "Label6";
			this.Label6.Size = new global::System.Drawing.Size(49, 15);
			this.Label6.TabIndex = 22;
			this.Label6.Text = "Search:";
			this.GroupBox2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.GroupBox2.Location = new global::System.Drawing.Point(12, 71);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new global::System.Drawing.Size(1000, 5);
			this.GroupBox2.TabIndex = 15;
			this.GroupBox2.TabStop = false;
			this.MenuStrip1.AutoSize = false;
			this.MenuStrip1.BackColor = global::System.Drawing.Color.Transparent;
			this.MenuStrip1.Dock = global::System.Windows.Forms.DockStyle.None;
			this.MenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.OptionsToolStripMenuItem, this.SortingToolStripMenuItem });
			this.MenuStrip1.Location = new global::System.Drawing.Point(9, 3);
			this.MenuStrip1.Name = "MenuStrip1";
			this.MenuStrip1.Size = new global::System.Drawing.Size(152, 25);
			this.MenuStrip1.TabIndex = 33;
			this.MenuStrip1.Text = "MenuStrip1";
			this.OptionsToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.AddSteamVRToolStripMenuItem, this.ShowToolStripMenuItem, this.ShowRemoved3rdPartyAppsToolStripMenuItem, this.ShowIgnoredAppsToolStripMenuItem, this.RefreshLibraryToolStripMenuItem });
			this.OptionsToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
			this.OptionsToolStripMenuItem.Size = new global::System.Drawing.Size(61, 21);
			this.OptionsToolStripMenuItem.Text = "Options";
			this.AddSteamVRToolStripMenuItem.BackColor = global::System.Drawing.Color.White;
			this.AddSteamVRToolStripMenuItem.Enabled = false;
			this.AddSteamVRToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.AddSteamVRToolStripMenuItem.Name = "AddSteamVRToolStripMenuItem";
			this.AddSteamVRToolStripMenuItem.Size = new global::System.Drawing.Size(236, 22);
			this.AddSteamVRToolStripMenuItem.Text = "Add SteamVR";
			this.ShowToolStripMenuItem.BackColor = global::System.Drawing.Color.White;
			this.ShowToolStripMenuItem.CheckOnClick = true;
			this.ShowToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
			this.ShowToolStripMenuItem.Size = new global::System.Drawing.Size(236, 22);
			this.ShowToolStripMenuItem.Text = "Show Hidden 3rd Party Apps";
			this.ShowRemoved3rdPartyAppsToolStripMenuItem.BackColor = global::System.Drawing.Color.White;
			this.ShowRemoved3rdPartyAppsToolStripMenuItem.CheckOnClick = true;
			this.ShowRemoved3rdPartyAppsToolStripMenuItem.Enabled = false;
			this.ShowRemoved3rdPartyAppsToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.ShowRemoved3rdPartyAppsToolStripMenuItem.Name = "ShowRemoved3rdPartyAppsToolStripMenuItem";
			this.ShowRemoved3rdPartyAppsToolStripMenuItem.Size = new global::System.Drawing.Size(236, 22);
			this.ShowRemoved3rdPartyAppsToolStripMenuItem.Text = "Show Removed 3rd Party Apps";
			this.ShowRemoved3rdPartyAppsToolStripMenuItem.Visible = false;
			this.ShowIgnoredAppsToolStripMenuItem.BackColor = global::System.Drawing.Color.White;
			this.ShowIgnoredAppsToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.ShowIgnoredAppsToolStripMenuItem.Name = "ShowIgnoredAppsToolStripMenuItem";
			this.ShowIgnoredAppsToolStripMenuItem.Size = new global::System.Drawing.Size(236, 22);
			this.ShowIgnoredAppsToolStripMenuItem.Text = "Show Ignored Apps";
			this.RefreshLibraryToolStripMenuItem.BackColor = global::System.Drawing.Color.White;
			this.RefreshLibraryToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.RefreshLibraryToolStripMenuItem.Name = "RefreshLibraryToolStripMenuItem";
			this.RefreshLibraryToolStripMenuItem.Size = new global::System.Drawing.Size(236, 22);
			this.RefreshLibraryToolStripMenuItem.Text = "Refresh Library";
			this.SortingToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.AscendingToolStripMenuItem, this.DescendingToolStripMenuItem });
			this.SortingToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.SortingToolStripMenuItem.Name = "SortingToolStripMenuItem";
			this.SortingToolStripMenuItem.Size = new global::System.Drawing.Size(57, 21);
			this.SortingToolStripMenuItem.Text = "Sorting";
			this.AscendingToolStripMenuItem.BackColor = global::System.Drawing.Color.White;
			this.AscendingToolStripMenuItem.CheckOnClick = true;
			this.AscendingToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.AscendingToolStripMenuItem.Name = "AscendingToolStripMenuItem";
			this.AscendingToolStripMenuItem.Size = new global::System.Drawing.Size(136, 22);
			this.AscendingToolStripMenuItem.Text = "Ascending";
			this.DescendingToolStripMenuItem.BackColor = global::System.Drawing.Color.White;
			this.DescendingToolStripMenuItem.CheckOnClick = true;
			this.DescendingToolStripMenuItem.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.DescendingToolStripMenuItem.Name = "DescendingToolStripMenuItem";
			this.DescendingToolStripMenuItem.Size = new global::System.Drawing.Size(136, 22);
			this.DescendingToolStripMenuItem.Text = "Descending";
			this.DotNetBarTabcontrol1.Alignment = global::System.Windows.Forms.TabAlignment.Left;
			this.DotNetBarTabcontrol1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.DotNetBarTabcontrol1.Controls.Add(this.TabPage1);
			this.DotNetBarTabcontrol1.ItemSize = new global::System.Drawing.Size(43, 85);
			this.DotNetBarTabcontrol1.Location = new global::System.Drawing.Point(12, 82);
			this.DotNetBarTabcontrol1.Multiline = true;
			this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
			this.DotNetBarTabcontrol1.SelectedIndex = 0;
			this.DotNetBarTabcontrol1.Size = new global::System.Drawing.Size(1011, 488);
			this.DotNetBarTabcontrol1.SizeMode = global::System.Windows.Forms.TabSizeMode.Fixed;
			this.DotNetBarTabcontrol1.TabIndex = 24;
			this.TabPage1.BackColor = global::System.Drawing.Color.White;
			this.TabPage1.Controls.Add(this.PicturePlay);
			this.TabPage1.Controls.Add(this.ListView1);
			this.TabPage1.Location = new global::System.Drawing.Point(89, 4);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new global::System.Drawing.Size(918, 480);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Library";
			this.PicturePlay.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.PicturePlay.BackColor = global::System.Drawing.Color.Transparent;
			this.PicturePlay.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			this.PicturePlay.ContextMenuStrip = this.ContextMenuStrip1;
			this.PicturePlay.Location = new global::System.Drawing.Point(683, 0);
			this.PicturePlay.Name = "PicturePlay";
			this.PicturePlay.Size = new global::System.Drawing.Size(250, 90);
			this.PicturePlay.TabIndex = 1;
			this.PicturePlay.TabStop = false;
			this.PicturePlay.Visible = false;
			this.ListView1.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.ListView1.ContextMenuStrip = this.ContextMenuStrip2;
			this.ListView1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.ListView1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ListView1.ForeColor = global::System.Drawing.Color.DodgerBlue;
			this.ListView1.HideSelection = false;
			this.ListView1.Location = new global::System.Drawing.Point(3, 3);
			this.ListView1.MultiSelect = false;
			this.ListView1.Name = "ListView1";
			this.ListView1.Size = new global::System.Drawing.Size(912, 474);
			this.ListView1.TabIndex = 3;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1024, 584);
			base.Controls.Add(this.MenuStrip1);
			base.Controls.Add(this.DotNetBarTabcontrol1);
			base.Controls.Add(this.GroupBox2);
			base.Controls.Add(this.Label6);
			base.Controls.Add(this.Button2);
			base.Controls.Add(this.TextBox1);
			base.Controls.Add(this.GroupBox1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.MenuStrip1;
			this.MinimumSize = new global::System.Drawing.Size(1040, 623);
			base.Name = "frmLibrary";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game Library";
			this.ContextMenuStrip2.ResumeLayout(false);
			this.ContextMenuStrip1.ResumeLayout(false);
			this.MenuStrip1.ResumeLayout(false);
			this.MenuStrip1.PerformLayout();
			this.DotNetBarTabcontrol1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.PicturePlay).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400016F RID: 367
		private global::System.ComponentModel.IContainer components;
	}
}
