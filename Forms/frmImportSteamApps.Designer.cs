using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool.Forms
{
    partial class frmImportSteamApps
    {
        private System.ComponentModel.IContainer components = null;

protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

        #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof (frmImportSteamApps));
      this.lvwAppList = new ListView();
      this.colInstalled = new ColumnHeader();
      this.colAppId = new ColumnHeader();
      this.colName = new ColumnHeader();
      this.colType = new ColumnHeader();
      this.colGenre = new ColumnHeader();
      this.colPublisher = new ColumnHeader();
      this.colDeveloper = new ColumnHeader();
      this.colExecutable = new ColumnHeader();
      this.colArguments = new ColumnHeader();
      this.colOSList = new ColumnHeader();
      this.colReleaseDate = new ColumnHeader();
      this.colDescription = new ColumnHeader();
      this.colLibraryFolder = new ColumnHeader();
      this.colInstallDir = new ColumnHeader();
      this.cmsApps = new ContextMenuStrip(this.components);
      this.tsmiLaunchApp = new ToolStripMenuItem();
      this.tsmiOpenFileLocation = new ToolStripMenuItem();
      this.imApps = new ImageList(this.components);
      this.tsApps = new ToolStrip();
      this.tsbRefresh = new ToolStripButton();
      this.tsbImportApps = new ToolStripButton();
      this.tsbRemoveApps = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.tsbSelectAll = new ToolStripButton();
      this.tsbClear = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.tsbDownloadAssets = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.tsbStartService = new ToolStripButton();
      this.tsbStopService = new ToolStripButton();
      this.tsbRestartService = new ToolStripButton();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.tscbVrManifest = new ToolStripCheckBox();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.tslSearch = new ToolStripLabel();
      this.tstbSearch = new ToolStripSpringTextBox();
      this.tsbSearch = new ToolStripButton();
      this.ssApps = new StatusStrip();
      this.tsslHeadsoftLogo = new ToolStripStatusLabel();
      this.panel1 = new Panel();
      this.pictureBox1 = new PictureBox();
      this.cmsApps.SuspendLayout();
      this.tsApps.SuspendLayout();
      this.ssApps.SuspendLayout();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.lvwAppList.CheckBoxes = true;
      this.lvwAppList.Columns.AddRange(new ColumnHeader[14]
      {
        this.colInstalled,
        this.colAppId,
        this.colName,
        this.colType,
        this.colGenre,
        this.colPublisher,
        this.colDeveloper,
        this.colExecutable,
        this.colArguments,
        this.colOSList,
        this.colReleaseDate,
        this.colDescription,
        this.colLibraryFolder,
        this.colInstallDir
      });
      this.lvwAppList.ContextMenuStrip = this.cmsApps;
      this.lvwAppList.Dock = DockStyle.Fill;
      this.lvwAppList.FullRowSelect = true;
      this.lvwAppList.GridLines = true;
      this.lvwAppList.HideSelection = false;
      this.lvwAppList.Location = new Point(0, 39);
      this.lvwAppList.MultiSelect = false;
      this.lvwAppList.Name = "lvwAppList";
      this.lvwAppList.Size = new Size(636, 283);
      this.lvwAppList.SmallImageList = this.imApps;
      this.lvwAppList.TabIndex = 3;
      this.lvwAppList.UseCompatibleStateImageBehavior = false;
      this.lvwAppList.View = View.Details;
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
      this.cmsApps.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.tsmiLaunchApp,
        (ToolStripItem) this.tsmiOpenFileLocation
      });
      this.cmsApps.Name = "cmsApps";
      this.cmsApps.Size = new Size(174, 48);
      this.tsmiLaunchApp.Name = "tsmiLaunchApp";
      this.tsmiLaunchApp.Size = new Size(173, 22);
      this.tsmiLaunchApp.Text = "Launch App";
      this.tsmiOpenFileLocation.Name = "tsmiOpenFileLocation";
      this.tsmiOpenFileLocation.Size = new Size(173, 22);
      this.tsmiOpenFileLocation.Text = "Open File Location";
      this.imApps.ImageStream = (ImageListStreamer) resources.GetObject("imApps.ImageStream");
      this.imApps.TransparentColor = Color.Transparent;
      this.imApps.Images.SetKeyName(0, "installed.png");
      this.imApps.Images.SetKeyName(1, "not_installed.png");
      this.tsApps.ImageScalingSize = new Size(32, 32);
      this.tsApps.Items.AddRange(new ToolStripItem[18]
      {
        (ToolStripItem) this.tsbRefresh,
        (ToolStripItem) this.tsbImportApps,
        (ToolStripItem) this.tsbRemoveApps,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.tsbSelectAll,
        (ToolStripItem) this.tsbClear,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.tsbDownloadAssets,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.tsbStartService,
        (ToolStripItem) this.tsbStopService,
        (ToolStripItem) this.tsbRestartService,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.tscbVrManifest,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.tslSearch,
        (ToolStripItem) this.tstbSearch,
        (ToolStripItem) this.tsbSearch
      });
      this.tsApps.Location = new Point(0, 0);
      this.tsApps.Name = "tsApps";
      this.tsApps.Size = new Size(636, 39);
      this.tsApps.TabIndex = 4;
      this.tsApps.Text = "toolStrip1";
      this.tsbRefresh.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbRefresh.Image = (System.Drawing.Image)resources.GetObject("tsbRefresh.Image");
      this.tsbRefresh.ImageTransparentColor = Color.Magenta;
      this.tsbRefresh.Name = "tsbRefresh";
      this.tsbRefresh.Size = new Size(36, 36);
      this.tsbRefresh.Text = "Refresh App List";
      this.tsbImportApps.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbImportApps.Image = (System.Drawing.Image)resources.GetObject("tsbImportApps.Image");
      this.tsbImportApps.ImageTransparentColor = Color.Magenta;
      this.tsbImportApps.Name = "tsbImportApps";
      this.tsbImportApps.Size = new Size(36, 36);
      this.tsbImportApps.Text = "Import Selected Apps";
      this.tsbRemoveApps.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbRemoveApps.Image = (System.Drawing.Image)resources.GetObject("tsbRemoveApps.Image");
      this.tsbRemoveApps.ImageTransparentColor = Color.Magenta;
      this.tsbRemoveApps.Name = "tsbRemoveApps";
      this.tsbRemoveApps.Size = new Size(36, 36);
      this.tsbRemoveApps.Text = "Remove Selected Apps";
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 39);
      this.tsbSelectAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbSelectAll.Image = (System.Drawing.Image)resources.GetObject("tsbSelectAll.Image");
      this.tsbSelectAll.ImageTransparentColor = Color.Magenta;
      this.tsbSelectAll.Name = "tsbSelectAll";
      this.tsbSelectAll.Size = new Size(36, 36);
      this.tsbSelectAll.Text = "Select All Apps";
      this.tsbClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbClear.Image = (System.Drawing.Image)resources.GetObject("tsbClear.Image");
      this.tsbClear.ImageTransparentColor = Color.Magenta;
      this.tsbClear.Name = "tsbClear";
      this.tsbClear.Size = new Size(36, 36);
      this.tsbClear.Text = "Clear All Selections";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 39);
      this.tsbDownloadAssets.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbDownloadAssets.Image = (System.Drawing.Image)resources.GetObject("tsbDownloadAssets.Image");
      this.tsbDownloadAssets.ImageTransparentColor = Color.Magenta;
      this.tsbDownloadAssets.Name = "tsbDownloadAssets";
      this.tsbDownloadAssets.Size = new Size(36, 36);
      this.tsbDownloadAssets.Text = "Download Selected Assets";
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 39);
      this.tsbStartService.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbStartService.Image = (System.Drawing.Image)resources.GetObject("tsbStartService.Image");
      this.tsbStartService.ImageTransparentColor = Color.Magenta;
      this.tsbStartService.Name = "tsbStartService";
      this.tsbStartService.Size = new Size(36, 36);
      this.tsbStartService.Text = "Start Oculus Service";
      this.tsbStopService.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbStopService.Image = (System.Drawing.Image)resources.GetObject("tsbStopService.Image");
      this.tsbStopService.ImageTransparentColor = Color.Magenta;
      this.tsbStopService.Name = "tsbStopService";
      this.tsbStopService.Size = new Size(36, 36);
      this.tsbStopService.Text = "Stop Oculus Service";
      this.tsbRestartService.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbRestartService.Image = (System.Drawing.Image)resources.GetObject("tsbRestartService.Image");
      this.tsbRestartService.ImageTransparentColor = Color.Magenta;
      this.tsbRestartService.Name = "tsbRestartService";
      this.tsbRestartService.Size = new Size(36, 36);
      this.tsbRestartService.Text = "Restart Oculus Service";
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(6, 39);
      this.tscbVrManifest.BackColor = Color.Transparent;
      this.tscbVrManifest.Checked = false;
      this.tscbVrManifest.Name = "tscbVrManifest";
      this.tscbVrManifest.Size = new Size(86, 36);
      this.tscbVrManifest.Text = "Vr Manifest";
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(6, 39);
      this.tslSearch.Name = "tslSearch";
      this.tslSearch.Size = new Size(45, 36);
      this.tslSearch.Text = "Search:";
      this.tstbSearch.Name = "tstbSearch";
      this.tstbSearch.Size = new Size(92, 39);
      this.tsbSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbSearch.Image = (System.Drawing.Image)resources.GetObject("tsbSearch.Image");
      this.tsbSearch.ImageTransparentColor = Color.Magenta;
      this.tsbSearch.Name = "tsbSearch";
      this.tsbSearch.Size = new Size(36, 36);
      this.tsbSearch.Text = "Search";
      this.ssApps.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.tsslHeadsoftLogo
      });
      this.ssApps.Location = new Point(0, 412);
      this.ssApps.Name = "ssApps";
      this.ssApps.Size = new Size(636, 22);
      this.ssApps.TabIndex = 5;
      this.ssApps.Text = "statusStrip1";
      this.tsslHeadsoftLogo.AutoSize = false;
      this.tsslHeadsoftLogo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsslHeadsoftLogo.Image = (System.Drawing.Image)resources.GetObject("tsslHeadsoftLogo.Image");
      this.tsslHeadsoftLogo.ImageScaling = ToolStripItemImageScaling.None;
      this.tsslHeadsoftLogo.IsLink = true;
      this.tsslHeadsoftLogo.Name = "tsslHeadsoftLogo";
      this.tsslHeadsoftLogo.Size = new Size(148, 17);
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 322);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(636, 90);
      this.panel1.TabIndex = 6;
      this.pictureBox1.Cursor = Cursors.Hand;
      this.pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(66, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(500, 90);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(636, 434);
      this.Controls.Add(this.lvwAppList);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.ssApps);
      this.Controls.Add(this.tsApps);
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MinimumSize = new Size(652, 473);
      this.Name = "frmImportSteamApps";
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Import Steam Apps";
      this.cmsApps.ResumeLayout(false);
      this.tsApps.ResumeLayout(false);
      this.tsApps.PerformLayout();
      this.ssApps.ResumeLayout(false);
      this.ssApps.PerformLayout();
      this.panel1.ResumeLayout(false);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    
      this.lvwAppList.ColumnClick += new ColumnClickEventHandler(this.lvwAppList_ColumnClick);
      this.tsbImportApps.Click += new EventHandler(this.tsbImportApps_Click);
      this.tsbDownloadAssets.Click += new EventHandler(this.tsbDownloadAssets_Click);
      this.tsmiOpenFileLocation.Click += new EventHandler(this.tsmiOpenFileLocation_Click);
      this.tsmiLaunchApp.Click += new EventHandler(this.tsmiLaunchApp_Click);
      this.tsbRemoveApps.Click += new EventHandler(this.tsbRemoveApps_Click);
      this.tsbRefresh.Click += new EventHandler(this.tsbRefresh_Click);
      this.tsbSelectAll.Click += new EventHandler(this.tsbSelectAll_Click);
      this.tsbClear.Click += new EventHandler(this.tsbClear_Click);
      this.tsbStartService.Click += new EventHandler(this.tsbStartService_Click);
      this.tsbStopService.Click += new EventHandler(this.tsbStopService_Click);
      this.tscbVrManifest.CheckedChanged += new EventHandler(this.tscbVrManifest_CheckedChanged);
      this.tsbSearch.Click += new EventHandler(this.tsbSearch_Click);
      this.tsbRestartService.Click += new EventHandler(this.tsbRestartService_Click);
      this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
      this.tsslHeadsoftLogo.Click += new EventHandler(this.tsslHeadsoftLogo_Click);
    }

        #endregion

    internal ListView lvwAppList;
    internal ToolStripButton tsbImportApps;
    internal ToolStripButton tsbDownloadAssets;
    internal ToolStripMenuItem tsmiOpenFileLocation;
    internal ToolStripMenuItem tsmiLaunchApp;
    internal ToolStripButton tsbRemoveApps;
    internal ToolStripButton tsbRefresh;
    internal ToolStripButton tsbSelectAll;
    internal ToolStripButton tsbClear;
    internal ToolStripButton tsbStartService;
    internal ToolStripButton tsbStopService;
    internal ToolStripCheckBox tscbVrManifest;
    internal ToolStripButton tsbSearch;
    internal ToolStripButton tsbRestartService;
    internal PictureBox pictureBox1;
    internal ToolStripStatusLabel tsslHeadsoftLogo;
        internal ColumnHeader colInstalled;
        internal ColumnHeader colAppId;
        internal ColumnHeader colName;
        internal ColumnHeader colType;
        internal ColumnHeader colGenre;
        internal ColumnHeader colPublisher;
        internal ColumnHeader colDeveloper;
        internal ColumnHeader colExecutable;
        internal ColumnHeader colArguments;
        internal ColumnHeader colOSList;
        internal ColumnHeader colReleaseDate;
        internal ColumnHeader colDescription;
        internal ColumnHeader colLibraryFolder;
        internal ColumnHeader colInstallDir;
        internal ToolStrip tsApps;
        internal ToolStripSeparator toolStripSeparator3;
        internal ToolStripSeparator toolStripSeparator1;
        internal ToolStripSeparator toolStripSeparator2;
        internal ToolStripSeparator toolStripSeparator4;
        internal ToolStripSeparator toolStripSeparator5;
        internal ToolStripLabel tslSearch;
        internal ToolStripSpringTextBox tstbSearch;
        internal StatusStrip ssApps;
        internal Panel panel1;
        internal ContextMenuStrip cmsApps;
        internal ImageList imApps;
    
    }
}
