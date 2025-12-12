using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class frmLibrary
    {
        private System.ComponentModel.IContainer components = null;
        internal ToolStripMenuItem ReEnableAppToolStripMenuItem;
        internal ToolStripMenuItem ShowAppInLibraryAndProfilesToolStripMenuItem;
        internal ToolStripMenuItem ToolStripMenuItem3;
        internal ToolStripMenuItem ToolStripMenuItem2;
        internal ToolStripSeparator ToolStripSeparator2;
        internal ToolStripMenuItem ToolStripMenuItem4;
        internal ToolStripMenuItem ToolStripMenuItem5;
        internal ToolStripMenuItem ToolStripMenuItem6;
        internal ToolStripSeparator ToolStripSeparator3;
        internal ToolStripMenuItem ToolStripMenuItem7;
        internal ToolStripMenuItem ToolStripMenuItem8;
        internal ToolStripSeparator ToolStripSeparator1;
        internal ToolStripMenuItem ToolStripMenuItem1;
        internal ToolStripMenuItem ToolStripMenuItem9;
        internal ToolStripMenuItem RemoveProfileToolStripMenuItem;
        internal GroupBox GroupBox1;
        internal TextBox TextBox1;
        internal Button Button2;
        internal Label Label6;
        internal GroupBox GroupBox2;
        internal MenuStrip MenuStrip1;
        internal ToolStripMenuItem OptionsToolStripMenuItem;
        internal ToolStripMenuItem AddSteamVRToolStripMenuItem;
        internal ToolStripMenuItem ShowToolStripMenuItem;
        internal ToolStripMenuItem ShowRemoved3rdPartyAppsToolStripMenuItem;
        internal ToolStripMenuItem ShowIgnoredAppsToolStripMenuItem;
        internal ToolStripMenuItem RefreshLibraryToolStripMenuItem;
        internal ToolStripMenuItem SortingToolStripMenuItem;
        internal ToolStripMenuItem AscendingToolStripMenuItem;
        internal ToolStripMenuItem DescendingToolStripMenuItem;
        internal global::OculusTrayTool.DotNetBarTabcontrol DotNetBarTabcontrol1;
        internal TabPage TabPage1;
        internal PictureBox PicturePlay;
        internal ListView ListView1;
        internal ContextMenuStrip ContextMenuStrip2;
        internal ContextMenuStrip ContextMenuStrip1;
        internal ToolTip ToolTip1;

protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

        #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmLibrary));
      this.ContextMenuStrip2 = new ContextMenuStrip(this.components);
      this.ReEnableAppToolStripMenuItem = new ToolStripMenuItem();
      this.ShowAppInLibraryAndProfilesToolStripMenuItem = new ToolStripMenuItem();
      this.ContextMenuStrip1 = new ContextMenuStrip(this.components);
      this.ToolStripMenuItem3 = new ToolStripMenuItem();
      this.ToolStripMenuItem2 = new ToolStripMenuItem();
      this.ToolStripSeparator2 = new ToolStripSeparator();
      this.ToolStripMenuItem4 = new ToolStripMenuItem();
      this.ToolStripMenuItem5 = new ToolStripMenuItem();
      this.ToolStripMenuItem6 = new ToolStripMenuItem();
      this.ToolStripSeparator3 = new ToolStripSeparator();
      this.ToolStripMenuItem7 = new ToolStripMenuItem();
      this.ToolStripMenuItem8 = new ToolStripMenuItem();
      this.ToolStripSeparator1 = new ToolStripSeparator();
      this.ToolStripMenuItem1 = new ToolStripMenuItem();
      this.ToolStripMenuItem9 = new ToolStripMenuItem();
      this.RemoveProfileToolStripMenuItem = new ToolStripMenuItem();
      this.ToolTip1 = new ToolTip(this.components);
      this.GroupBox1 = new GroupBox();
      this.TextBox1 = new TextBox();
      this.Button2 = new Button();
      this.Label6 = new Label();
      this.GroupBox2 = new GroupBox();
      this.MenuStrip1 = new MenuStrip();
      this.OptionsToolStripMenuItem = new ToolStripMenuItem();
      this.AddSteamVRToolStripMenuItem = new ToolStripMenuItem();
      this.ShowToolStripMenuItem = new ToolStripMenuItem();
      this.ShowRemoved3rdPartyAppsToolStripMenuItem = new ToolStripMenuItem();
      this.ShowIgnoredAppsToolStripMenuItem = new ToolStripMenuItem();
      this.RefreshLibraryToolStripMenuItem = new ToolStripMenuItem();
      this.SortingToolStripMenuItem = new ToolStripMenuItem();
      this.AscendingToolStripMenuItem = new ToolStripMenuItem();
      this.DescendingToolStripMenuItem = new ToolStripMenuItem();
      this.DotNetBarTabcontrol1 = new global::OculusTrayTool.DotNetBarTabcontrol();
      this.TabPage1 = new TabPage();
      this.PicturePlay = new PictureBox();
      this.ListView1 = new ListView();
      this.ContextMenuStrip2.SuspendLayout();
      this.ContextMenuStrip1.SuspendLayout();
      this.MenuStrip1.SuspendLayout();
      this.DotNetBarTabcontrol1.SuspendLayout();
      this.TabPage1.SuspendLayout();
      ((ISupportInitialize) this.PicturePlay).BeginInit();
      this.SuspendLayout();
      this.ContextMenuStrip2.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.ReEnableAppToolStripMenuItem,
        (ToolStripItem) this.ShowAppInLibraryAndProfilesToolStripMenuItem
      });
      this.ContextMenuStrip2.Name = "ContextMenuStrip2";
      this.ContextMenuStrip2.Size = new Size(246, 48);
      this.ReEnableAppToolStripMenuItem.Enabled = false;
      this.ReEnableAppToolStripMenuItem.Name = "ReEnableAppToolStripMenuItem";
      this.ReEnableAppToolStripMenuItem.Size = new Size(245, 22);
      this.ReEnableAppToolStripMenuItem.Text = "Re-Enable App";
      this.ReEnableAppToolStripMenuItem.Visible = false;
      this.ShowAppInLibraryAndProfilesToolStripMenuItem.Name = "ShowAppInLibraryAndProfilesToolStripMenuItem";
      this.ShowAppInLibraryAndProfilesToolStripMenuItem.Size = new Size(245, 22);
      this.ShowAppInLibraryAndProfilesToolStripMenuItem.Text = "Show App in Library and Profiles";
      this.ContextMenuStrip1.Items.AddRange(new ToolStripItem[13]
      {
        (ToolStripItem) this.ToolStripMenuItem3,
        (ToolStripItem) this.ToolStripMenuItem2,
        (ToolStripItem) this.ToolStripSeparator2,
        (ToolStripItem) this.ToolStripMenuItem4,
        (ToolStripItem) this.ToolStripMenuItem5,
        (ToolStripItem) this.ToolStripMenuItem6,
        (ToolStripItem) this.ToolStripSeparator3,
        (ToolStripItem) this.ToolStripMenuItem7,
        (ToolStripItem) this.ToolStripMenuItem8,
        (ToolStripItem) this.ToolStripSeparator1,
        (ToolStripItem) this.ToolStripMenuItem1,
        (ToolStripItem) this.ToolStripMenuItem9,
        (ToolStripItem) this.RemoveProfileToolStripMenuItem
      });
      this.ContextMenuStrip1.Name = "ContextMenuStrip1";
      this.ContextMenuStrip1.Size = new Size(242, 242);
      this.ToolStripMenuItem3.Image = (Image) (System.Drawing.Image)global::OculusTrayTool.My.Resources.Resources.refresh_16;
      this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
      this.ToolStripMenuItem3.Size = new Size(241, 22);
      this.ToolStripMenuItem3.Text = "Replace Icons";
      this.ToolStripMenuItem3.Visible = false;
      this.ToolStripMenuItem2.Image = (Image) (System.Drawing.Image)global::OculusTrayTool.My.Resources.Resources.Icon_View;
      this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
      this.ToolStripMenuItem2.Size = new Size(241, 22);
      this.ToolStripMenuItem2.Text = "Show Properties";
      this.ToolStripSeparator2.Name = "ToolStripSeparator2";
      this.ToolStripSeparator2.Size = new Size(238, 6);
      this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
      this.ToolStripMenuItem4.Size = new Size(241, 22);
      this.ToolStripMenuItem4.Text = "Hide App in Library";
      this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
      this.ToolStripMenuItem5.Size = new Size(241, 22);
      this.ToolStripMenuItem5.Text = "Hide App in Library and Profiles";
      this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
      this.ToolStripMenuItem6.Size = new Size(241, 22);
      this.ToolStripMenuItem6.Text = "Ignore App";
      this.ToolStripSeparator3.Name = "ToolStripSeparator3";
      this.ToolStripSeparator3.Size = new Size(238, 6);
      this.ToolStripMenuItem7.Image = (System.Drawing.Image)resources.GetObject("ToolStripMenuItem7.Image");
      this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
      this.ToolStripMenuItem7.Size = new Size(241, 22);
      this.ToolStripMenuItem7.Text = "Launch App";
      this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
      this.ToolStripMenuItem8.Size = new Size(241, 22);
      this.ToolStripMenuItem8.Text = "Launch App with options..";
      this.ToolStripSeparator1.Name = "ToolStripSeparator1";
      this.ToolStripSeparator1.Size = new Size(238, 6);
      this.ToolStripMenuItem1.Image = (Image) (System.Drawing.Image)global::OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
      this.ToolStripMenuItem1.Size = new Size(241, 22);
      this.ToolStripMenuItem1.Text = "Create Profile...";
      this.ToolStripMenuItem9.Image = (Image) (System.Drawing.Image)global::OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
      this.ToolStripMenuItem9.Size = new Size(241, 22);
      this.ToolStripMenuItem9.Text = "Edit Profile...";
      this.RemoveProfileToolStripMenuItem.Image = (Image) (System.Drawing.Image)global::OculusTrayTool.My.Resources.Resources.Icon_Delete;
      this.RemoveProfileToolStripMenuItem.Name = "RemoveProfileToolStripMenuItem";
      this.RemoveProfileToolStripMenuItem.Size = new Size(241, 22);
      this.RemoveProfileToolStripMenuItem.Text = "Remove Profile";
      this.ToolTip1.AutoPopDelay = 10000;
      this.ToolTip1.InitialDelay = 200;
      this.ToolTip1.ReshowDelay = 100;
      this.GroupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox1.Location = new Point(12, 30);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(1000, 5);
      this.GroupBox1.TabIndex = 14;
      this.GroupBox1.TabStop = false;
      this.TextBox1.Location = new Point(68, 44);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.Size = new Size(149, 20);
      this.TextBox1.TabIndex = 20;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(223, 43);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(48, 22);
      this.Button2.TabIndex = 21;
      this.Button2.Text = "Go";
      this.Button2.UseVisualStyleBackColor = true;
      this.Label6.AutoSize = true;
      this.Label6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label6.ForeColor = Color.DodgerBlue;
      this.Label6.Location = new Point(13, 47);
      this.Label6.Name = "Label6";
      this.Label6.Size = new Size(49, 15);
      this.Label6.TabIndex = 22;
      this.Label6.Text = "Search:";
      this.GroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.GroupBox2.Location = new Point(12, 71);
      this.GroupBox2.Name = "GroupBox2";
      this.GroupBox2.Size = new Size(1000, 5);
      this.GroupBox2.TabIndex = 15;
      this.GroupBox2.TabStop = false;
      this.MenuStrip1.AutoSize = false;
      this.MenuStrip1.BackColor = Color.Transparent;
      this.MenuStrip1.Dock = DockStyle.None;
      this.MenuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.OptionsToolStripMenuItem,
        (ToolStripItem) this.SortingToolStripMenuItem
      });
      this.MenuStrip1.Location = new Point(9, 3);
      this.MenuStrip1.Name = "MenuStrip1";
      this.MenuStrip1.Size = new Size(152, 25);
      this.MenuStrip1.TabIndex = 33;
      this.MenuStrip1.Text = "MenuStrip1";
      this.OptionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.AddSteamVRToolStripMenuItem,
        (ToolStripItem) this.ShowToolStripMenuItem,
        (ToolStripItem) this.ShowRemoved3rdPartyAppsToolStripMenuItem,
        (ToolStripItem) this.ShowIgnoredAppsToolStripMenuItem,
        (ToolStripItem) this.RefreshLibraryToolStripMenuItem
      });
      this.OptionsToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem";
      this.OptionsToolStripMenuItem.Size = new Size(61, 21);
      this.OptionsToolStripMenuItem.Text = "Options";
      this.AddSteamVRToolStripMenuItem.BackColor = Color.White;
      this.AddSteamVRToolStripMenuItem.Enabled = false;
      this.AddSteamVRToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.AddSteamVRToolStripMenuItem.Name = "AddSteamVRToolStripMenuItem";
      this.AddSteamVRToolStripMenuItem.Size = new Size(236, 22);
      this.AddSteamVRToolStripMenuItem.Text = "Add SteamVR";
      this.ShowToolStripMenuItem.BackColor = Color.White;
      this.ShowToolStripMenuItem.CheckOnClick = true;
      this.ShowToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.ShowToolStripMenuItem.Name = "ShowToolStripMenuItem";
      this.ShowToolStripMenuItem.Size = new Size(236, 22);
      this.ShowToolStripMenuItem.Text = "Show Hidden 3rd Party Apps";
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.BackColor = Color.White;
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.CheckOnClick = true;
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Enabled = false;
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Name = "ShowRemoved3rdPartyAppsToolStripMenuItem";
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Size = new Size(236, 22);
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Text = "Show Removed 3rd Party Apps";
      this.ShowRemoved3rdPartyAppsToolStripMenuItem.Visible = false;
      this.ShowIgnoredAppsToolStripMenuItem.BackColor = Color.White;
      this.ShowIgnoredAppsToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.ShowIgnoredAppsToolStripMenuItem.Name = "ShowIgnoredAppsToolStripMenuItem";
      this.ShowIgnoredAppsToolStripMenuItem.Size = new Size(236, 22);
      this.ShowIgnoredAppsToolStripMenuItem.Text = "Show Ignored Apps";
      this.RefreshLibraryToolStripMenuItem.BackColor = Color.White;
      this.RefreshLibraryToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.RefreshLibraryToolStripMenuItem.Name = "RefreshLibraryToolStripMenuItem";
      this.RefreshLibraryToolStripMenuItem.Size = new Size(236, 22);
      this.RefreshLibraryToolStripMenuItem.Text = "Refresh Library";
      this.SortingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.AscendingToolStripMenuItem,
        (ToolStripItem) this.DescendingToolStripMenuItem
      });
      this.SortingToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.SortingToolStripMenuItem.Name = "SortingToolStripMenuItem";
      this.SortingToolStripMenuItem.Size = new Size(57, 21);
      this.SortingToolStripMenuItem.Text = "Sorting";
      this.AscendingToolStripMenuItem.BackColor = Color.White;
      this.AscendingToolStripMenuItem.CheckOnClick = true;
      this.AscendingToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.AscendingToolStripMenuItem.Name = "AscendingToolStripMenuItem";
      this.AscendingToolStripMenuItem.Size = new Size(136, 22);
      this.AscendingToolStripMenuItem.Text = "Ascending";
      this.DescendingToolStripMenuItem.BackColor = Color.White;
      this.DescendingToolStripMenuItem.CheckOnClick = true;
      this.DescendingToolStripMenuItem.ForeColor = Color.DodgerBlue;
      this.DescendingToolStripMenuItem.Name = "DescendingToolStripMenuItem";
      this.DescendingToolStripMenuItem.Size = new Size(136, 22);
      this.DescendingToolStripMenuItem.Text = "Descending";
      this.DotNetBarTabcontrol1.Alignment = TabAlignment.Left;
      this.DotNetBarTabcontrol1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.DotNetBarTabcontrol1.Controls.Add(this.TabPage1);
      this.DotNetBarTabcontrol1.ItemSize = new Size(43, 85);
      this.DotNetBarTabcontrol1.Location = new Point(12, 82);
      this.DotNetBarTabcontrol1.Multiline = true;
      this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
      this.DotNetBarTabcontrol1.SelectedIndex = 0;
      this.DotNetBarTabcontrol1.Size = new Size(1011, 488);
      this.DotNetBarTabcontrol1.SizeMode = TabSizeMode.Fixed;
      this.DotNetBarTabcontrol1.TabIndex = 24;
      this.TabPage1.BackColor = Color.White;
      this.TabPage1.Controls.Add(this.PicturePlay);
      this.TabPage1.Controls.Add(this.ListView1);
      this.TabPage1.Location = new Point(89, 4);
      this.TabPage1.Name = "TabPage1";
      this.TabPage1.Padding = new Padding(3);
      this.TabPage1.Size = new Size(918, 480);
      this.TabPage1.TabIndex = 0;
      this.TabPage1.Text = "Library";
      this.PicturePlay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.PicturePlay.BackColor = Color.Transparent;
      this.PicturePlay.BackgroundImageLayout = ImageLayout.None;
      this.PicturePlay.ContextMenuStrip = this.ContextMenuStrip1;
      this.PicturePlay.Location = new Point(683, 0);
      this.PicturePlay.Name = "PicturePlay";
      this.PicturePlay.Size = new Size(250, 90);
      this.PicturePlay.TabIndex = 1;
      this.PicturePlay.TabStop = false;
      this.PicturePlay.Visible = false;
      this.ListView1.BorderStyle = BorderStyle.None;
      this.ListView1.ContextMenuStrip = this.ContextMenuStrip2;
      this.ListView1.Dock = DockStyle.Fill;
      this.ListView1.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ListView1.ForeColor = Color.DodgerBlue;
      this.ListView1.HideSelection = false;
      this.ListView1.Location = new Point(3, 3);
      this.ListView1.MultiSelect = false;
      this.ListView1.Name = "ListView1";
      this.ListView1.Size = new Size(912, 474);
      this.ListView1.TabIndex = 3;
      this.ListView1.UseCompatibleStateImageBehavior = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(1024, 584);
      this.Controls.Add(this.MenuStrip1);
      this.Controls.Add(this.DotNetBarTabcontrol1);
      this.Controls.Add(this.GroupBox2);
      this.Controls.Add(this.Label6);
      this.Controls.Add(this.Button2);
      this.Controls.Add(this.TextBox1);
      this.Controls.Add(this.GroupBox1);
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MainMenuStrip = this.MenuStrip1;
      this.MinimumSize = new Size(1040, 623);
      this.Name = "frmLibrary";
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Game Library";
      this.ContextMenuStrip2.ResumeLayout(false);
      this.ContextMenuStrip1.ResumeLayout(false);
      this.MenuStrip1.ResumeLayout(false);
      this.MenuStrip1.PerformLayout();
      this.DotNetBarTabcontrol1.ResumeLayout(false);
      this.TabPage1.ResumeLayout(false);
      ((ISupportInitialize) this.PicturePlay).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    
    }

        #endregion

    
    }
}