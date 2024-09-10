// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmImportSteamApps
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmImportSteamApps : Form
  {
    private IContainer components;
    private ListViewColumnSorter m_lvwColumnSorter;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmImportSteamApps));
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
      this.imApps.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imApps.ImageStream");
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
      this.tsbRefresh.Image = (Image) componentResourceManager.GetObject("tsbRefresh.Image");
      this.tsbRefresh.ImageTransparentColor = Color.Magenta;
      this.tsbRefresh.Name = "tsbRefresh";
      this.tsbRefresh.Size = new Size(36, 36);
      this.tsbRefresh.Text = "Refresh App List";
      this.tsbImportApps.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbImportApps.Image = (Image) componentResourceManager.GetObject("tsbImportApps.Image");
      this.tsbImportApps.ImageTransparentColor = Color.Magenta;
      this.tsbImportApps.Name = "tsbImportApps";
      this.tsbImportApps.Size = new Size(36, 36);
      this.tsbImportApps.Text = "Import Selected Apps";
      this.tsbRemoveApps.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbRemoveApps.Image = (Image) componentResourceManager.GetObject("tsbRemoveApps.Image");
      this.tsbRemoveApps.ImageTransparentColor = Color.Magenta;
      this.tsbRemoveApps.Name = "tsbRemoveApps";
      this.tsbRemoveApps.Size = new Size(36, 36);
      this.tsbRemoveApps.Text = "Remove Selected Apps";
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 39);
      this.tsbSelectAll.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbSelectAll.Image = (Image) componentResourceManager.GetObject("tsbSelectAll.Image");
      this.tsbSelectAll.ImageTransparentColor = Color.Magenta;
      this.tsbSelectAll.Name = "tsbSelectAll";
      this.tsbSelectAll.Size = new Size(36, 36);
      this.tsbSelectAll.Text = "Select All Apps";
      this.tsbClear.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbClear.Image = (Image) componentResourceManager.GetObject("tsbClear.Image");
      this.tsbClear.ImageTransparentColor = Color.Magenta;
      this.tsbClear.Name = "tsbClear";
      this.tsbClear.Size = new Size(36, 36);
      this.tsbClear.Text = "Clear All Selections";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 39);
      this.tsbDownloadAssets.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbDownloadAssets.Image = (Image) componentResourceManager.GetObject("tsbDownloadAssets.Image");
      this.tsbDownloadAssets.ImageTransparentColor = Color.Magenta;
      this.tsbDownloadAssets.Name = "tsbDownloadAssets";
      this.tsbDownloadAssets.Size = new Size(36, 36);
      this.tsbDownloadAssets.Text = "Download Selected Assets";
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 39);
      this.tsbStartService.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbStartService.Image = (Image) componentResourceManager.GetObject("tsbStartService.Image");
      this.tsbStartService.ImageTransparentColor = Color.Magenta;
      this.tsbStartService.Name = "tsbStartService";
      this.tsbStartService.Size = new Size(36, 36);
      this.tsbStartService.Text = "Start Oculus Service";
      this.tsbStopService.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbStopService.Image = (Image) componentResourceManager.GetObject("tsbStopService.Image");
      this.tsbStopService.ImageTransparentColor = Color.Magenta;
      this.tsbStopService.Name = "tsbStopService";
      this.tsbStopService.Size = new Size(36, 36);
      this.tsbStopService.Text = "Stop Oculus Service";
      this.tsbRestartService.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.tsbRestartService.Image = (Image) componentResourceManager.GetObject("tsbRestartService.Image");
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
      this.tsbSearch.Image = (Image) componentResourceManager.GetObject("tsbSearch.Image");
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
      this.tsslHeadsoftLogo.Image = (Image) componentResourceManager.GetObject("tsslHeadsoftLogo.Image");
      this.tsslHeadsoftLogo.ImageScaling = ToolStripItemImageScaling.None;
      this.tsslHeadsoftLogo.IsLink = true;
      this.tsslHeadsoftLogo.Name = "tsslHeadsoftLogo";
      this.tsslHeadsoftLogo.Size = new Size(148, 17);
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Dock = DockStyle.Bottom;
      this.panel1.Location = new Point(0, 322);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(636, 90);
      this.panel1.TabIndex = 6;
      this.pictureBox1.Cursor = Cursors.Hand;
      this.pictureBox1.Image = (Image) componentResourceManager.GetObject("pictureBox1.Image");
      this.pictureBox1.Location = new Point(66, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new Size(500, 90);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(636, 434);
      this.Controls.Add((Control) this.lvwAppList);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.ssApps);
      this.Controls.Add((Control) this.tsApps);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MinimumSize = new Size(652, 473);
      this.Name = nameof (frmImportSteamApps);
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
    }

    internal virtual ListView lvwAppList
    {
      get => this._lvwAppList;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        ColumnClickEventHandler clickEventHandler = new ColumnClickEventHandler(this.lvwAppList_ColumnClick);
        ListView lvwAppList1 = this._lvwAppList;
        if (lvwAppList1 != null)
          lvwAppList1.ColumnClick -= clickEventHandler;
        this._lvwAppList = value;
        ListView lvwAppList2 = this._lvwAppList;
        if (lvwAppList2 == null)
          return;
        lvwAppList2.ColumnClick += clickEventHandler;
      }
    }

    [field: AccessedThroughProperty("colAppId")]
    internal virtual ColumnHeader colAppId { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colName")]
    internal virtual ColumnHeader colName { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colType")]
    internal virtual ColumnHeader colType { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colGenre")]
    internal virtual ColumnHeader colGenre { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colPublisher")]
    internal virtual ColumnHeader colPublisher { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colDeveloper")]
    internal virtual ColumnHeader colDeveloper { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colExecutable")]
    internal virtual ColumnHeader colExecutable { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colArguments")]
    internal virtual ColumnHeader colArguments { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colOSList")]
    internal virtual ColumnHeader colOSList { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colReleaseDate")]
    internal virtual ColumnHeader colReleaseDate { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colDescription")]
    internal virtual ColumnHeader colDescription { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("tsApps")]
    internal virtual ToolStrip tsApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("ssApps")]
    internal virtual StatusStrip ssApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripButton tsbImportApps
    {
      get => this._tsbImportApps;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbImportApps_Click);
        ToolStripButton tsbImportApps1 = this._tsbImportApps;
        if (tsbImportApps1 != null)
          tsbImportApps1.Click -= eventHandler;
        this._tsbImportApps = value;
        ToolStripButton tsbImportApps2 = this._tsbImportApps;
        if (tsbImportApps2 == null)
          return;
        tsbImportApps2.Click += eventHandler;
      }
    }

    internal virtual ToolStripButton tsbDownloadAssets
    {
      get => this._tsbDownloadAssets;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbDownloadAssets_Click);
        ToolStripButton tsbDownloadAssets1 = this._tsbDownloadAssets;
        if (tsbDownloadAssets1 != null)
          tsbDownloadAssets1.Click -= eventHandler;
        this._tsbDownloadAssets = value;
        ToolStripButton tsbDownloadAssets2 = this._tsbDownloadAssets;
        if (tsbDownloadAssets2 == null)
          return;
        tsbDownloadAssets2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("colLibraryFolder")]
    internal virtual ColumnHeader colLibraryFolder { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("colInstallDir")]
    internal virtual ColumnHeader colInstallDir { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("cmsApps")]
    internal virtual ContextMenuStrip cmsApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripMenuItem tsmiOpenFileLocation
    {
      get => this._tsmiOpenFileLocation;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiOpenFileLocation_Click);
        ToolStripMenuItem openFileLocation1 = this._tsmiOpenFileLocation;
        if (openFileLocation1 != null)
          openFileLocation1.Click -= eventHandler;
        this._tsmiOpenFileLocation = value;
        ToolStripMenuItem openFileLocation2 = this._tsmiOpenFileLocation;
        if (openFileLocation2 == null)
          return;
        openFileLocation2.Click += eventHandler;
      }
    }

    internal virtual ToolStripMenuItem tsmiLaunchApp
    {
      get => this._tsmiLaunchApp;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsmiLaunchApp_Click);
        ToolStripMenuItem tsmiLaunchApp1 = this._tsmiLaunchApp;
        if (tsmiLaunchApp1 != null)
          tsmiLaunchApp1.Click -= eventHandler;
        this._tsmiLaunchApp = value;
        ToolStripMenuItem tsmiLaunchApp2 = this._tsmiLaunchApp;
        if (tsmiLaunchApp2 == null)
          return;
        tsmiLaunchApp2.Click += eventHandler;
      }
    }

    internal virtual ToolStripButton tsbRemoveApps
    {
      get => this._tsbRemoveApps;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbRemoveApps_Click);
        ToolStripButton tsbRemoveApps1 = this._tsbRemoveApps;
        if (tsbRemoveApps1 != null)
          tsbRemoveApps1.Click -= eventHandler;
        this._tsbRemoveApps = value;
        ToolStripButton tsbRemoveApps2 = this._tsbRemoveApps;
        if (tsbRemoveApps2 == null)
          return;
        tsbRemoveApps2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("colInstalled")]
    internal virtual ColumnHeader colInstalled { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("imApps")]
    internal virtual ImageList imApps { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripButton tsbRefresh
    {
      get => this._tsbRefresh;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbRefresh_Click);
        ToolStripButton tsbRefresh1 = this._tsbRefresh;
        if (tsbRefresh1 != null)
          tsbRefresh1.Click -= eventHandler;
        this._tsbRefresh = value;
        ToolStripButton tsbRefresh2 = this._tsbRefresh;
        if (tsbRefresh2 == null)
          return;
        tsbRefresh2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("toolStripSeparator3")]
    internal virtual ToolStripSeparator toolStripSeparator3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripButton tsbSelectAll
    {
      get => this._tsbSelectAll;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbSelectAll_Click);
        ToolStripButton tsbSelectAll1 = this._tsbSelectAll;
        if (tsbSelectAll1 != null)
          tsbSelectAll1.Click -= eventHandler;
        this._tsbSelectAll = value;
        ToolStripButton tsbSelectAll2 = this._tsbSelectAll;
        if (tsbSelectAll2 == null)
          return;
        tsbSelectAll2.Click += eventHandler;
      }
    }

    internal virtual ToolStripButton tsbClear
    {
      get => this._tsbClear;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbClear_Click);
        ToolStripButton tsbClear1 = this._tsbClear;
        if (tsbClear1 != null)
          tsbClear1.Click -= eventHandler;
        this._tsbClear = value;
        ToolStripButton tsbClear2 = this._tsbClear;
        if (tsbClear2 == null)
          return;
        tsbClear2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("toolStripSeparator1")]
    internal virtual ToolStripSeparator toolStripSeparator1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("toolStripSeparator2")]
    internal virtual ToolStripSeparator toolStripSeparator2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripButton tsbStartService
    {
      get => this._tsbStartService;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbStartService_Click);
        ToolStripButton tsbStartService1 = this._tsbStartService;
        if (tsbStartService1 != null)
          tsbStartService1.Click -= eventHandler;
        this._tsbStartService = value;
        ToolStripButton tsbStartService2 = this._tsbStartService;
        if (tsbStartService2 == null)
          return;
        tsbStartService2.Click += eventHandler;
      }
    }

    internal virtual ToolStripButton tsbStopService
    {
      get => this._tsbStopService;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbStopService_Click);
        ToolStripButton tsbStopService1 = this._tsbStopService;
        if (tsbStopService1 != null)
          tsbStopService1.Click -= eventHandler;
        this._tsbStopService = value;
        ToolStripButton tsbStopService2 = this._tsbStopService;
        if (tsbStopService2 == null)
          return;
        tsbStopService2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("toolStripSeparator4")]
    internal virtual ToolStripSeparator toolStripSeparator4 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripCheckBox tscbVrManifest
    {
      get => this._tscbVrManifest;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tscbVrManifest_CheckedChanged);
        ToolStripCheckBox tscbVrManifest1 = this._tscbVrManifest;
        if (tscbVrManifest1 != null)
          tscbVrManifest1.CheckedChanged -= eventHandler;
        this._tscbVrManifest = value;
        ToolStripCheckBox tscbVrManifest2 = this._tscbVrManifest;
        if (tscbVrManifest2 == null)
          return;
        tscbVrManifest2.CheckedChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("tstbSearch")]
    internal virtual ToolStripSpringTextBox tstbSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ToolStripButton tsbSearch
    {
      get => this._tsbSearch;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbSearch_Click);
        ToolStripButton tsbSearch1 = this._tsbSearch;
        if (tsbSearch1 != null)
          tsbSearch1.Click -= eventHandler;
        this._tsbSearch = value;
        ToolStripButton tsbSearch2 = this._tsbSearch;
        if (tsbSearch2 == null)
          return;
        tsbSearch2.Click += eventHandler;
      }
    }

    internal virtual ToolStripButton tsbRestartService
    {
      get => this._tsbRestartService;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsbRestartService_Click);
        ToolStripButton tsbRestartService1 = this._tsbRestartService;
        if (tsbRestartService1 != null)
          tsbRestartService1.Click -= eventHandler;
        this._tsbRestartService = value;
        ToolStripButton tsbRestartService2 = this._tsbRestartService;
        if (tsbRestartService2 == null)
          return;
        tsbRestartService2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("tslSearch")]
    internal virtual ToolStripLabel tslSearch { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("toolStripSeparator5")]
    internal virtual ToolStripSeparator toolStripSeparator5 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("panel1")]
    internal virtual Panel panel1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual PictureBox pictureBox1
    {
      get => this._pictureBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.pictureBox1_Click);
        PictureBox pictureBox1_1 = this._pictureBox1;
        if (pictureBox1_1 != null)
          pictureBox1_1.Click -= eventHandler;
        this._pictureBox1 = value;
        PictureBox pictureBox1_2 = this._pictureBox1;
        if (pictureBox1_2 == null)
          return;
        pictureBox1_2.Click += eventHandler;
      }
    }

    internal virtual ToolStripStatusLabel tsslHeadsoftLogo
    {
      get => this._tsslHeadsoftLogo;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.tsslHeadsoftLogo_Click);
        ToolStripStatusLabel tsslHeadsoftLogo1 = this._tsslHeadsoftLogo;
        if (tsslHeadsoftLogo1 != null)
          tsslHeadsoftLogo1.Click -= eventHandler;
        this._tsslHeadsoftLogo = value;
        ToolStripStatusLabel tsslHeadsoftLogo2 = this._tsslHeadsoftLogo;
        if (tsslHeadsoftLogo2 == null)
          return;
        tsslHeadsoftLogo2.Click += eventHandler;
      }
    }

    public frmImportSteamApps()
    {
      this.Load += new EventHandler(this.frmImportSteamApps_Load);
      this.Resize += new EventHandler(this.frmImportSteamApps_Resize);
      this.FormClosing += new FormClosingEventHandler(this.frmImportSteamApps_FormClosing);
      this.components = (IContainer) null;
      this.m_lvwColumnSorter = (ListViewColumnSorter) null;
      this.InitializeComponent();
    }

    private void frmImportSteamApps_Load(object sender, EventArgs e)
    {
      this.tscbVrManifest.Checked = true;
      if (MySettingsProperty.Settings.SteamWindowLocation != new Point())
      {
        this.Location = MySettingsProperty.Settings.SteamWindowLocation;
      }
      else
      {
        if (Globals.dbg)
          Log.WriteToLog("Setting Steam GUI location to Center Screen");
        this.CenterToScreen();
        MySettingsProperty.Settings.SteamWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      if (this.Location.X < 0 | this.Location.Y < 0)
      {
        if (Globals.dbg)
          Log.WriteToLog("Steam GUI location has negative number, adjusting");
        this.CenterToScreen();
        MySettingsProperty.Settings.SteamWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      if (!(MySettingsProperty.Settings.SteamWindowSize != new Size()))
        return;
      this.Size = MySettingsProperty.Settings.SteamWindowSize;
    }

    private void UpdateAppListView()
    {
      try
      {
        if (Globals.dbg)
          Log.WriteToLog("Updating list of Steam games");
        if (!Globals.oculus.TryRefresh() || !Globals.steam.TryRefresh())
          return;
        List<SteamNode> steamList = (List<SteamNode>) null;
        if (this.tscbVrManifest.Checked)
        {
          if (!Globals.steam.TryGetVRManifest(ref steamList) || !Globals.steam.TryGetAppInfo(steamList, true, true))
            return;
        }
        else
        {
          Dictionary<ulong, SteamNode> appInfoDictionary = (Dictionary<ulong, SteamNode>) null;
          if (!Globals.steam.TryGetAppInfo(true, true, ref appInfoDictionary, ref steamList))
            return;
        }
        this.m_lvwColumnSorter = new ListViewColumnSorter();
        this.m_lvwColumnSorter.SortColumn = 2;
        this.m_lvwColumnSorter.Order = SortOrder.Ascending;
        this.lvwAppList.Items.Clear();
        this.lvwAppList.ListViewItemSorter = (IComparer) this.m_lvwColumnSorter;
        List<ListViewItem> listViewItemList = new List<ListViewItem>();
        try
        {
          foreach (SteamNode steamNode in steamList)
          {
            bool flag = Globals.oculus.IsAppInstalled((OculusNode) steamNode);
            if (string.IsNullOrEmpty(this.tstbSearch.Text) || steamNode.Name.IndexOf(this.tstbSearch.Text, StringComparison.CurrentCultureIgnoreCase) != -1)
              listViewItemList.Add(new ListViewItem(new string[14]
              {
                "",
                steamNode.AppId.ToString(),
                steamNode.Name,
                steamNode.Type,
                steamNode.Genre,
                steamNode.Publisher,
                steamNode.Developer,
                steamNode.Executable,
                steamNode.Parameters,
                steamNode.OSList,
                steamNode.ReleaseDateString,
                steamNode.Description,
                steamNode.LibraryFolder,
                steamNode.InstallDir
              })
              {
                ImageIndex = flag ? 0 : 1,
                Tag = (object) steamNode
              });
          }
        }
        finally
        {
          List<SteamNode>.Enumerator enumerator;
          enumerator.Dispose();
        }
        this.lvwAppList.Items.AddRange(listViewItemList.ToArray());
        try
        {
          foreach (ColumnHeader column in this.lvwAppList.Columns)
          {
            if (Operators.CompareString(column.Text, "Description", false) != 0)
              column.Width = -2;
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        this.lvwAppList.Sort();
        if (Globals.dbg)
          Log.WriteToLog("Update complete");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog(ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void lvwAppList_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (e.Column == this.m_lvwColumnSorter.SortColumn)
      {
        this.m_lvwColumnSorter.Order = this.m_lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
      }
      else
      {
        this.m_lvwColumnSorter.SortColumn = e.Column;
        this.m_lvwColumnSorter.Order = SortOrder.Ascending;
      }
      this.lvwAppList.Sort();
    }

    private void tsbRefresh_Click(object sender, EventArgs e) => this.UpdateAppListView();

    private void tsbImportApps_Click(object sender, EventArgs e) => this.ImportSelectedApps();

    private void tsbRemoveApps_Click(object sender, EventArgs e) => this.RemoveSelectedApps();

    private void tsbSelectAll_Click(object sender, EventArgs e)
    {
      try
      {
        foreach (ListViewItem listViewItem in this.lvwAppList.Items)
          listViewItem.Checked = true;
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void tsbClear_Click(object sender, EventArgs e)
    {
      try
      {
        foreach (ListViewItem listViewItem in this.lvwAppList.Items)
          listViewItem.Checked = false;
      }
      finally
      {
        IEnumerator enumerator;
        if (enumerator is IDisposable)
          (enumerator as IDisposable).Dispose();
      }
    }

    private void tsbDownloadAssets_Click(object sender, EventArgs e)
    {
      this.DownloadSelectedAssets();
    }

    private void tsbStartService_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      Globals.oculus.TryStartOculusService();
      this.Cursor = Cursors.Default;
    }

    private void tsbStopService_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      Globals.oculus.TryStopOculusService();
      this.Cursor = Cursors.Default;
    }

    private void tsbRestartService_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      Globals.oculus.TryRestartOculusService();
      this.Cursor = Cursors.Default;
    }

    private void tscbVrManifest_CheckedChanged(object sender, EventArgs e)
    {
      this.UpdateAppListView();
    }

    private void tsbSearch_Click(object sender, EventArgs e) => this.UpdateAppListView();

    private void ImportSelectedApps()
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        frmImportSteamApps._Closure\u0024__189\u002D0 closure1890_1;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        frmImportSteamApps._Closure\u0024__189\u002D0 closure1890_2 = new frmImportSteamApps._Closure\u0024__189\u002D0(closure1890_1);
        // ISSUE: reference to a compiler-generated field
        closure1890_2.\u0024VB\u0024Me = this;
        if (MyProject.Forms.FrmMain.debug)
          Log.WriteToLog("Importing selected apps");
        // ISSUE: reference to a compiler-generated field
        closure1890_2.\u0024VB\u0024Local_steamList = (List<SteamNode>) null;
        // ISSUE: reference to a compiler-generated field
        if (!this.TryGetSelectedSteamList(ref closure1890_2.\u0024VB\u0024Local_steamList))
          return;
        // ISSUE: reference to a compiler-generated field
        closure1890_2.\u0024VB\u0024Local_frmProcessing = new frmProcessing();
        // ISSUE: reference to a compiler-generated field
        closure1890_2.\u0024VB\u0024Local_backgroundWorker = new BackgroundWorker();
        // ISSUE: reference to a compiler-generated field
        closure1890_2.\u0024VB\u0024Local_backgroundWorker.WorkerReportsProgress = false;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        closure1890_2.\u0024VB\u0024Local_backgroundWorker.DoWork += new DoWorkEventHandler(closure1890_2._Lambda\u0024__0);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        closure1890_2.\u0024VB\u0024Local_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(closure1890_2._Lambda\u0024__2);
        // ISSUE: reference to a compiler-generated field
        closure1890_2.\u0024VB\u0024Local_backgroundWorker.RunWorkerAsync();
        // ISSUE: reference to a compiler-generated field
        int num = (int) closure1890_2.\u0024VB\u0024Local_frmProcessing.ShowDialog((IWin32Window) this);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("ImportSelectedApps: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void RemoveSelectedApps()
    {
      try
      {
        List<SteamNode> steamList = (List<SteamNode>) null;
        if (!this.TryGetSelectedSteamList(ref steamList))
          return;
        try
        {
          foreach (SteamNode steamNode in steamList)
          {
            this.TryRemoveApp((Control) this, steamNode);
            Log.WriteToLog("'" + steamNode.Name + "' has been removed");
          }
        }
        finally
        {
          List<SteamNode>.Enumerator enumerator;
          enumerator.Dispose();
        }
        this.UpdateAppListView();
        Globals.oculus.TryRestartOculusService();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("RemoveSelectedApps: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void DownloadSelectedAssets()
    {
      try
      {
        // ISSUE: variable of a compiler-generated type
        frmImportSteamApps._Closure\u0024__191\u002D0 closure1910_1;
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        frmImportSteamApps._Closure\u0024__191\u002D0 closure1910_2 = new frmImportSteamApps._Closure\u0024__191\u002D0(closure1910_1);
        // ISSUE: reference to a compiler-generated field
        closure1910_2.\u0024VB\u0024Me = this;
        // ISSUE: reference to a compiler-generated field
        closure1910_2.\u0024VB\u0024Local_steamList = (List<SteamNode>) null;
        // ISSUE: reference to a compiler-generated field
        if (!this.TryGetSelectedSteamList(ref closure1910_2.\u0024VB\u0024Local_steamList))
          return;
        // ISSUE: reference to a compiler-generated field
        closure1910_2.\u0024VB\u0024Local_syncObject = RuntimeHelpers.GetObjectValue(new object());
        // ISSUE: reference to a compiler-generated field
        closure1910_2.\u0024VB\u0024Local_frmProcessing = new frmProcessing();
        // ISSUE: reference to a compiler-generated field
        closure1910_2.\u0024VB\u0024Local_backgroundWorker = new BackgroundWorker();
        // ISSUE: reference to a compiler-generated field
        closure1910_2.\u0024VB\u0024Local_backgroundWorker.WorkerReportsProgress = false;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        closure1910_2.\u0024VB\u0024Local_backgroundWorker.DoWork += new DoWorkEventHandler(closure1910_2._Lambda\u0024__0);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        closure1910_2.\u0024VB\u0024Local_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(closure1910_2._Lambda\u0024__3);
        // ISSUE: reference to a compiler-generated field
        closure1910_2.\u0024VB\u0024Local_backgroundWorker.RunWorkerAsync();
        // ISSUE: reference to a compiler-generated field
        int num = (int) closure1910_2.\u0024VB\u0024Local_frmProcessing.ShowDialog((IWin32Window) this);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("DownloadSelectedAssets: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private bool TryGetSelectedSteamList(ref List<SteamNode> steamList)
    {
      bool selectedSteamList;
      try
      {
        steamList = (List<SteamNode>) null;
        if (this.lvwAppList.CheckedItems.Count <= 0)
        {
          selectedSteamList = false;
        }
        else
        {
          steamList = new List<SteamNode>();
          try
          {
            foreach (ListViewItem checkedItem in this.lvwAppList.CheckedItems)
            {
              SteamNode tag = (SteamNode) checkedItem.Tag;
              steamList.Add(tag);
            }
          }
          finally
          {
            IEnumerator enumerator;
            if (enumerator is IDisposable)
              (enumerator as IDisposable).Dispose();
          }
          selectedSteamList = true;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetSelectedSteamList: " + ex.Message);
        selectedSteamList = false;
        ProjectData.ClearProjectError();
      }
      return selectedSteamList;
    }

    private void tsmiLaunchApp_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.lvwAppList.SelectedItems.Count <= 0)
          return;
        SteamNode tag = (SteamNode) this.lvwAppList.SelectedItems[0].Tag;
        Globals.steam.TryLaunchApp(tag.AppId, tag.Parameters);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("Could not launch app: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void tsmiOpenFileLocation_Click(object sender, EventArgs e)
    {
      if (this.lvwAppList.SelectedItems.Count <= 0)
        return;
      string fullPath = ((OculusNode) this.lvwAppList.SelectedItems[0].Tag).FullPath;
      if (string.IsNullOrEmpty(fullPath) || !File.Exists(fullPath))
        return;
      Process.Start("explorer.exe", string.Format("/select,\"{0}\"", (object) fullPath));
    }

    private bool TryRemoveApp(Control control, SteamNode steamNode)
    {
      // ISSUE: variable of a compiler-generated type
      frmImportSteamApps._Closure\u0024__195\u002D0 closure1950_1;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      frmImportSteamApps._Closure\u0024__195\u002D0 closure1950_2 = new frmImportSteamApps._Closure\u0024__195\u002D0(closure1950_1);
      // ISSUE: reference to a compiler-generated field
      closure1950_2.\u0024VB\u0024Local_control = control;
      // ISSUE: reference to a compiler-generated field
      closure1950_2.\u0024VB\u0024Local_steamNode = steamNode;
      bool flag;
      try
      {
        List<string> manifestFileList = (List<string>) null;
        List<string> assetDirectoryList = (List<string>) null;
        // ISSUE: reference to a compiler-generated field
        if (Globals.oculus.TryGetManifestFileNameAndAssetFolderList((OculusNode) closure1950_2.\u0024VB\u0024Local_steamNode, ref manifestFileList, ref assetDirectoryList))
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          if (Conversions.ToInteger(closure1950_2.\u0024VB\u0024Local_control.Invoke((Delegate) new frmImportSteamApps.Func<DialogResult>(closure1950_2._Lambda\u0024__0))) != 6)
          {
            flag = false;
            goto label_22;
          }
          else
          {
            try
            {
              foreach (string path in manifestFileList)
              {
                if (File.Exists(path))
                {
                  File.Delete(path);
                  if (Globals.dbg)
                    Log.WriteToLog(path + " deleted");
                }
              }
            }
            finally
            {
              List<string>.Enumerator enumerator;
              enumerator.Dispose();
            }
            try
            {
              foreach (string path in assetDirectoryList)
              {
                if (Directory.Exists(path))
                {
                  Directory.Delete(path, true);
                  if (Globals.dbg)
                    Log.WriteToLog(path + " deleted");
                }
              }
            }
            finally
            {
              List<string>.Enumerator enumerator;
              enumerator.Dispose();
            }
          }
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryRemoveApp: " + ex.Message);
        ProjectData.ClearProjectError();
      }
label_22:
      return flag;
    }

    private void frmImportSteamApps_Resize(object sender, EventArgs e)
    {
      this.pictureBox1.Location = new Point(checked ((int) Math.Round(unchecked ((double) this.ClientSize.Width / 2.0 - (double) this.pictureBox1.Width / 2.0))), 0);
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      Process.Start("http://headsoft.com.au/redirect.php?url=https://www.mechatech.co.uk/");
    }

    private void tsslHeadsoftLogo_Click(object sender, EventArgs e)
    {
      Process.Start("http://headsoft.com.au/");
    }

    private void frmImportSteamApps_FormClosing(object sender, FormClosingEventArgs e)
    {
      MySettingsProperty.Settings.SteamWindowLocation = this.Location;
      MySettingsProperty.Settings.SteamWindowSize = this.Size;
      MySettingsProperty.Settings.Save();
    }

    private delegate T Func<T>();

    private delegate void Func();
  }
}
