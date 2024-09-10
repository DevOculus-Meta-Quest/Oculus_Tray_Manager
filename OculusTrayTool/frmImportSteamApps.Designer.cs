namespace OculusTrayTool
{
	// Token: 0x02000024 RID: 36
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated]
	public partial class frmImportSteamApps : global::System.Windows.Forms.Form
	{
		// Token: 0x06000357 RID: 855 RVA: 0x00014654 File Offset: 0x00012854
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0001468C File Offset: 0x0001288C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::OculusTrayTool.frmImportSteamApps));
			this.lvwAppList = new global::System.Windows.Forms.ListView();
			this.colInstalled = new global::System.Windows.Forms.ColumnHeader();
			this.colAppId = new global::System.Windows.Forms.ColumnHeader();
			this.colName = new global::System.Windows.Forms.ColumnHeader();
			this.colType = new global::System.Windows.Forms.ColumnHeader();
			this.colGenre = new global::System.Windows.Forms.ColumnHeader();
			this.colPublisher = new global::System.Windows.Forms.ColumnHeader();
			this.colDeveloper = new global::System.Windows.Forms.ColumnHeader();
			this.colExecutable = new global::System.Windows.Forms.ColumnHeader();
			this.colArguments = new global::System.Windows.Forms.ColumnHeader();
			this.colOSList = new global::System.Windows.Forms.ColumnHeader();
			this.colReleaseDate = new global::System.Windows.Forms.ColumnHeader();
			this.colDescription = new global::System.Windows.Forms.ColumnHeader();
			this.colLibraryFolder = new global::System.Windows.Forms.ColumnHeader();
			this.colInstallDir = new global::System.Windows.Forms.ColumnHeader();
			this.cmsApps = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.tsmiLaunchApp = new global::System.Windows.Forms.ToolStripMenuItem();
			this.tsmiOpenFileLocation = new global::System.Windows.Forms.ToolStripMenuItem();
			this.imApps = new global::System.Windows.Forms.ImageList(this.components);
			this.tsApps = new global::System.Windows.Forms.ToolStrip();
			this.tsbRefresh = new global::System.Windows.Forms.ToolStripButton();
			this.tsbImportApps = new global::System.Windows.Forms.ToolStripButton();
			this.tsbRemoveApps = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new global::System.Windows.Forms.ToolStripSeparator();
			this.tsbSelectAll = new global::System.Windows.Forms.ToolStripButton();
			this.tsbClear = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.tsbDownloadAssets = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new global::System.Windows.Forms.ToolStripSeparator();
			this.tsbStartService = new global::System.Windows.Forms.ToolStripButton();
			this.tsbStopService = new global::System.Windows.Forms.ToolStripButton();
			this.tsbRestartService = new global::System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new global::System.Windows.Forms.ToolStripSeparator();
			this.tscbVrManifest = new global::OculusTrayTool.ToolStripCheckBox();
			this.toolStripSeparator5 = new global::System.Windows.Forms.ToolStripSeparator();
			this.tslSearch = new global::System.Windows.Forms.ToolStripLabel();
			this.tstbSearch = new global::OculusTrayTool.ToolStripSpringTextBox();
			this.tsbSearch = new global::System.Windows.Forms.ToolStripButton();
			this.ssApps = new global::System.Windows.Forms.StatusStrip();
			this.tsslHeadsoftLogo = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.cmsApps.SuspendLayout();
			this.tsApps.SuspendLayout();
			this.ssApps.SuspendLayout();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.lvwAppList.CheckBoxes = true;
			this.lvwAppList.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.colInstalled, this.colAppId, this.colName, this.colType, this.colGenre, this.colPublisher, this.colDeveloper, this.colExecutable, this.colArguments, this.colOSList,
				this.colReleaseDate, this.colDescription, this.colLibraryFolder, this.colInstallDir
			});
			this.lvwAppList.ContextMenuStrip = this.cmsApps;
			this.lvwAppList.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.lvwAppList.FullRowSelect = true;
			this.lvwAppList.GridLines = true;
			this.lvwAppList.HideSelection = false;
			this.lvwAppList.Location = new global::System.Drawing.Point(0, 39);
			this.lvwAppList.MultiSelect = false;
			this.lvwAppList.Name = "lvwAppList";
			this.lvwAppList.Size = new global::System.Drawing.Size(636, 283);
			this.lvwAppList.SmallImageList = this.imApps;
			this.lvwAppList.TabIndex = 3;
			this.lvwAppList.UseCompatibleStateImageBehavior = false;
			this.lvwAppList.View = global::System.Windows.Forms.View.Details;
			this.colInstalled.Text = "Installed";
			this.colAppId.Text = "AppId";
			this.colName.Text = "Name";
			this.colType.Text = "Type";
			this.colGenre.Text = "Genre";
			this.colPublisher.Text = "Publisher";
			this.colDeveloper.Text = "Developer";
			this.colExecutable.Text = "Executable";
			this.colArguments.Text = "Arguments";
			this.colOSList.Text = "OSList";
			this.colReleaseDate.Text = "ReleaseDate";
			this.colDescription.Text = "Description";
			this.colLibraryFolder.Text = "LibraryFolder";
			this.colInstallDir.Text = "InstallDir";
			this.cmsApps.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.tsmiLaunchApp, this.tsmiOpenFileLocation });
			this.cmsApps.Name = "cmsApps";
			this.cmsApps.Size = new global::System.Drawing.Size(174, 48);
			this.tsmiLaunchApp.Name = "tsmiLaunchApp";
			this.tsmiLaunchApp.Size = new global::System.Drawing.Size(173, 22);
			this.tsmiLaunchApp.Text = "Launch App";
			this.tsmiOpenFileLocation.Name = "tsmiOpenFileLocation";
			this.tsmiOpenFileLocation.Size = new global::System.Drawing.Size(173, 22);
			this.tsmiOpenFileLocation.Text = "Open File Location";
			this.imApps.ImageStream = (global::System.Windows.Forms.ImageListStreamer)componentResourceManager.GetObject("imApps.ImageStream");
			this.imApps.TransparentColor = global::System.Drawing.Color.Transparent;
			this.imApps.Images.SetKeyName(0, "installed.png");
			this.imApps.Images.SetKeyName(1, "not_installed.png");
			this.tsApps.ImageScalingSize = new global::System.Drawing.Size(32, 32);
			this.tsApps.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.tsbRefresh, this.tsbImportApps, this.tsbRemoveApps, this.toolStripSeparator3, this.tsbSelectAll, this.tsbClear, this.toolStripSeparator1, this.tsbDownloadAssets, this.toolStripSeparator2, this.tsbStartService,
				this.tsbStopService, this.tsbRestartService, this.toolStripSeparator4, this.tscbVrManifest, this.toolStripSeparator5, this.tslSearch, this.tstbSearch, this.tsbSearch
			});
			this.tsApps.Location = new global::System.Drawing.Point(0, 0);
			this.tsApps.Name = "tsApps";
			this.tsApps.Size = new global::System.Drawing.Size(636, 39);
			this.tsApps.TabIndex = 4;
			this.tsApps.Text = "toolStrip1";
			this.tsbRefresh.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRefresh.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbRefresh.Image");
			this.tsbRefresh.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbRefresh.Name = "tsbRefresh";
			this.tsbRefresh.Size = new global::System.Drawing.Size(36, 36);
			this.tsbRefresh.Text = "Refresh App List";
			this.tsbImportApps.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbImportApps.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbImportApps.Image");
			this.tsbImportApps.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbImportApps.Name = "tsbImportApps";
			this.tsbImportApps.Size = new global::System.Drawing.Size(36, 36);
			this.tsbImportApps.Text = "Import Selected Apps";
			this.tsbRemoveApps.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRemoveApps.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbRemoveApps.Image");
			this.tsbRemoveApps.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbRemoveApps.Name = "tsbRemoveApps";
			this.tsbRemoveApps.Size = new global::System.Drawing.Size(36, 36);
			this.tsbRemoveApps.Text = "Remove Selected Apps";
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new global::System.Drawing.Size(6, 39);
			this.tsbSelectAll.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSelectAll.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbSelectAll.Image");
			this.tsbSelectAll.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbSelectAll.Name = "tsbSelectAll";
			this.tsbSelectAll.Size = new global::System.Drawing.Size(36, 36);
			this.tsbSelectAll.Text = "Select All Apps";
			this.tsbClear.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbClear.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbClear.Image");
			this.tsbClear.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbClear.Name = "tsbClear";
			this.tsbClear.Size = new global::System.Drawing.Size(36, 36);
			this.tsbClear.Text = "Clear All Selections";
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(6, 39);
			this.tsbDownloadAssets.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbDownloadAssets.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbDownloadAssets.Image");
			this.tsbDownloadAssets.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbDownloadAssets.Name = "tsbDownloadAssets";
			this.tsbDownloadAssets.Size = new global::System.Drawing.Size(36, 36);
			this.tsbDownloadAssets.Text = "Download Selected Assets";
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new global::System.Drawing.Size(6, 39);
			this.tsbStartService.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbStartService.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbStartService.Image");
			this.tsbStartService.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbStartService.Name = "tsbStartService";
			this.tsbStartService.Size = new global::System.Drawing.Size(36, 36);
			this.tsbStartService.Text = "Start Oculus Service";
			this.tsbStopService.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbStopService.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbStopService.Image");
			this.tsbStopService.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbStopService.Name = "tsbStopService";
			this.tsbStopService.Size = new global::System.Drawing.Size(36, 36);
			this.tsbStopService.Text = "Stop Oculus Service";
			this.tsbRestartService.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRestartService.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbRestartService.Image");
			this.tsbRestartService.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbRestartService.Name = "tsbRestartService";
			this.tsbRestartService.Size = new global::System.Drawing.Size(36, 36);
			this.tsbRestartService.Text = "Restart Oculus Service";
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new global::System.Drawing.Size(6, 39);
			this.tscbVrManifest.BackColor = global::System.Drawing.Color.Transparent;
			this.tscbVrManifest.Checked = false;
			this.tscbVrManifest.Name = "tscbVrManifest";
			this.tscbVrManifest.Size = new global::System.Drawing.Size(86, 36);
			this.tscbVrManifest.Text = "Vr Manifest";
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new global::System.Drawing.Size(6, 39);
			this.tslSearch.Name = "tslSearch";
			this.tslSearch.Size = new global::System.Drawing.Size(45, 36);
			this.tslSearch.Text = "Search:";
			this.tstbSearch.Name = "tstbSearch";
			this.tstbSearch.Size = new global::System.Drawing.Size(92, 39);
			this.tsbSearch.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSearch.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsbSearch.Image");
			this.tsbSearch.ImageTransparentColor = global::System.Drawing.Color.Magenta;
			this.tsbSearch.Name = "tsbSearch";
			this.tsbSearch.Size = new global::System.Drawing.Size(36, 36);
			this.tsbSearch.Text = "Search";
			this.ssApps.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.tsslHeadsoftLogo });
			this.ssApps.Location = new global::System.Drawing.Point(0, 412);
			this.ssApps.Name = "ssApps";
			this.ssApps.Size = new global::System.Drawing.Size(636, 22);
			this.ssApps.TabIndex = 5;
			this.ssApps.Text = "statusStrip1";
			this.tsslHeadsoftLogo.AutoSize = false;
			this.tsslHeadsoftLogo.DisplayStyle = global::System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsslHeadsoftLogo.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("tsslHeadsoftLogo.Image");
			this.tsslHeadsoftLogo.ImageScaling = global::System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsslHeadsoftLogo.IsLink = true;
			this.tsslHeadsoftLogo.Name = "tsslHeadsoftLogo";
			this.tsslHeadsoftLogo.Size = new global::System.Drawing.Size(148, 17);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new global::System.Drawing.Point(0, 322);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(636, 90);
			this.panel1.TabIndex = 6;
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(66, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(500, 90);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(636, 434);
			base.Controls.Add(this.lvwAppList);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.ssApps);
			base.Controls.Add(this.tsApps);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MinimumSize = new global::System.Drawing.Size(652, 473);
			base.Name = "frmImportSteamApps";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Import Steam Apps";
			this.cmsApps.ResumeLayout(false);
			this.tsApps.ResumeLayout(false);
			this.tsApps.PerformLayout();
			this.ssApps.ResumeLayout(false);
			this.ssApps.PerformLayout();
			this.panel1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400010E RID: 270
		private global::System.ComponentModel.IContainer components;
	}
}
