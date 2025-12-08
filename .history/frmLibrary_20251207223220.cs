// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmLibrary
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmLibrary : Form
  {
    private IContainer components;
    private ImageList imageListLarge;
    public static ImageList icons = new ImageList();
    private ImageList ImgListOverlay;
    private string steam_assets;
    private string backupPath;
    private bool changeMade;
    private List<string> steamExes;
    private Resizer rs;
    private bool isReading;
    private bool scrapeDone;
    private bool libraryLoaded;
    public Dictionary<string, string> ManualStartProfiles;
    private bool removeOK;
    public int LocalDBVersion;
    public int IconsLocalDBVersion;
    private Thread GetIcons;
    public SQLiteConnection Steamcnn;
    public SQLiteConnection Iconscnn;
    private int offset;


    private int dbCount;
    private bool isSearch;
    private bool lvShrunk;
    private string selectedLink;
    private int ShrinkSize;
    private ListView lvToShrink;
    private bool NoIconSet;
    private bool BrowseForIcons;
    private SQLiteConnection cnn;
    private List<string> IconGameList;
    public List<string> DisplayNameList;
    private ListView _ListView1;
    private ToolTip _ToolTip1;
    private ContextMenuStrip _ContextMenuStrip1;
    private ToolStripMenuItem _ToolStripMenuItem3;
    private ToolStripMenuItem _ToolStripMenuItem2;
    private ToolStripMenuItem _ToolStripMenuItem4;
    private ToolStripMenuItem _ToolStripMenuItem7;
    private ToolStripMenuItem _ToolStripMenuItem8;
    private PictureBox _PicturePlay;
    private ContextMenuStrip _ContextMenuStrip2;
    private ToolStripMenuItem _ReEnableAppToolStripMenuItem;
    private GroupBox _GroupBox1;
    private TextBox _TextBox1;
    private Button _Button2;
    private Label _Label6;
    private ToolStripMenuItem _ToolStripMenuItem1;
    private ToolStripMenuItem _ToolStripMenuItem9;
    private ToolStripSeparator _ToolStripSeparator1;
    private ToolStripSeparator _ToolStripSeparator2;
    private GroupBox _GroupBox2;
    private ToolStripMenuItem _ShowAppInLibraryAndProfilesToolStripMenuItem;
    private DotNetBarTabcontrol _DotNetBarTabcontrol1;
    private TabPage _TabPage1;
    private MenuStrip _MenuStrip1;
    private ToolStripMenuItem _OptionsToolStripMenuItem;
    private ToolStripMenuItem _AddSteamVRToolStripMenuItem;
    private ToolStripMenuItem _ShowToolStripMenuItem;
    private ToolStripMenuItem _ShowRemoved3rdPartyAppsToolStripMenuItem;
    private ToolStripMenuItem _SortingToolStripMenuItem;
    private ToolStripMenuItem _AscendingToolStripMenuItem;
    private ToolStripMenuItem _DescendingToolStripMenuItem;
    private ToolStripMenuItem _RefreshLibraryToolStripMenuItem;
    private ToolStripMenuItem _ShowIgnoredAppsToolStripMenuItem;
    private ToolStripMenuItem _ToolStripMenuItem5;
    private ToolStripMenuItem _ToolStripMenuItem6;
    private ToolStripSeparator _ToolStripSeparator3;
    private ToolStripMenuItem _RemoveProfileToolStripMenuItem;

    public frmLibrary()
    {
      this.FormClosing += new FormClosingEventHandler(this.Library_FormClosing);
      this.Load += new EventHandler(this.Library_Load);
      this.ResizeBegin += new EventHandler(this.Library_ResizeBegin);
      this.imageListLarge = new ImageList();
      this.ImgListOverlay = new ImageList()
      {
        ImageSize = new Size(64, 64)
      };
      this.steam_assets = Application.StartupPath + "\\SteamVRAssets";
      this.backupPath = Application.StartupPath + "\\backup";
      this.changeMade = false;
      this.steamExes = new List<string>();
      this.rs = new Resizer();
      this.isReading = false;
      this.scrapeDone = false;
      this.libraryLoaded = false;
      this.ManualStartProfiles = new Dictionary<string, string>();
      this.removeOK = false;
      this.Client = new WebClient();
      this.Steamcnn = new SQLiteConnection();
      this.Iconscnn = new SQLiteConnection();
      this.offset = 0;
      this.isSearch = false;
      this.lvShrunk = false;
      this.ShrinkSize = 0;
      this.NoIconSet = false;
      this.BrowseForIcons = false;
      this.cnn = new SQLiteConnection();
      this.IconGameList = new List<string>();
      this.DisplayNameList = new List<string>();
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
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

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmLibrary));
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
      this.DotNetBarTabcontrol1 = new DotNetBarTabcontrol();
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
      this.ToolStripMenuItem3.Image = (Image) OculusTrayTool.My.Resources.Resources.refresh_16;
      this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
      this.ToolStripMenuItem3.Size = new Size(241, 22);
      this.ToolStripMenuItem3.Text = "Replace Icons";
      this.ToolStripMenuItem3.Visible = false;
      this.ToolStripMenuItem2.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_View;
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
      this.ToolStripMenuItem7.Image = (Image) componentResourceManager.GetObject("ToolStripMenuItem7.Image");
      this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
      this.ToolStripMenuItem7.Size = new Size(241, 22);
      this.ToolStripMenuItem7.Text = "Launch App";
      this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
      this.ToolStripMenuItem8.Size = new Size(241, 22);
      this.ToolStripMenuItem8.Text = "Launch App with options..";
      this.ToolStripSeparator1.Name = "ToolStripSeparator1";
      this.ToolStripSeparator1.Size = new Size(238, 6);
      this.ToolStripMenuItem1.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
      this.ToolStripMenuItem1.Size = new Size(241, 22);
      this.ToolStripMenuItem1.Text = "Create Profile...";
      this.ToolStripMenuItem9.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Edit;
      this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
      this.ToolStripMenuItem9.Size = new Size(241, 22);
      this.ToolStripMenuItem9.Text = "Edit Profile...";
      this.RemoveProfileToolStripMenuItem.Image = (Image) OculusTrayTool.My.Resources.Resources.Icon_Delete;
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
      this.DotNetBarTabcontrol1.Controls.Add((Control) this.TabPage1);
      this.DotNetBarTabcontrol1.ItemSize = new Size(43, 85);
      this.DotNetBarTabcontrol1.Location = new Point(12, 82);
      this.DotNetBarTabcontrol1.Multiline = true;
      this.DotNetBarTabcontrol1.Name = "DotNetBarTabcontrol1";
      this.DotNetBarTabcontrol1.SelectedIndex = 0;
      this.DotNetBarTabcontrol1.Size = new Size(1011, 488);
      this.DotNetBarTabcontrol1.SizeMode = TabSizeMode.Fixed;
      this.DotNetBarTabcontrol1.TabIndex = 24;
      this.TabPage1.BackColor = Color.White;
      this.TabPage1.Controls.Add((Control) this.PicturePlay);
      this.TabPage1.Controls.Add((Control) this.ListView1);
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
      this.Controls.Add((Control) this.MenuStrip1);
      this.Controls.Add((Control) this.DotNetBarTabcontrol1);
      this.Controls.Add((Control) this.GroupBox2);
      this.Controls.Add((Control) this.Label6);
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.TextBox1);
      this.Controls.Add((Control) this.GroupBox1);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.MenuStrip1;
      this.MinimumSize = new Size(1040, 623);
      this.Name = nameof (frmLibrary);
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

    internal virtual ListView ListView1
    {
      get => _ListView1;
      set
      {
        if (_ListView1 != null)
             _ListView1.MouseMove -= ListView1_MouseMove;
        _ListView1 = value;
        if (_ListView1 != null)
             _ListView1.MouseMove += ListView1_MouseMove;
      }
    }

    internal virtual ToolTip ToolTip1
    {
      get => _ToolTip1;
      set => _ToolTip1 = value;
    }

    internal virtual ContextMenuStrip ContextMenuStrip1
    {
      get => _ContextMenuStrip1;
      set
      {
        if (_ContextMenuStrip1 != null)
        {
          _ContextMenuStrip1.Opening -= ContextMenuStrip1_Opening;
          _ContextMenuStrip1.MouseLeave -= ContextMenuStrip1_MouseLeave;
        }
        _ContextMenuStrip1 = value;
        if (_ContextMenuStrip1 != null)
        {
          _ContextMenuStrip1.Opening += ContextMenuStrip1_Opening;
          _ContextMenuStrip1.MouseLeave += ContextMenuStrip1_MouseLeave;
        }
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem3
    {
      get => _ToolStripMenuItem3;
      set => _ToolStripMenuItem3 = value;
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem2
    {
      get => _ToolStripMenuItem2;
      set
      {
        if (_ToolStripMenuItem2 != null)
          _ToolStripMenuItem2.Click -= ToolStripMenuItem2_Click;
        _ToolStripMenuItem2 = value;
        if (_ToolStripMenuItem2 != null)
          _ToolStripMenuItem2.Click += ToolStripMenuItem2_Click;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem4
    {
      get => _ToolStripMenuItem4;
      set
      {
        if (_ToolStripMenuItem4 != null)
          _ToolStripMenuItem4.Click -= ToolStripMenuItem4_Click;
        _ToolStripMenuItem4 = value;
        if (_ToolStripMenuItem4 != null)
          _ToolStripMenuItem4.Click += ToolStripMenuItem4_Click;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem7
    {
      get => _ToolStripMenuItem7;
      set
      {
        if (_ToolStripMenuItem7 != null)
          _ToolStripMenuItem7.Click -= ToolStripMenuItem7_Click;
        _ToolStripMenuItem7 = value;
        if (_ToolStripMenuItem7 != null)
          _ToolStripMenuItem7.Click += ToolStripMenuItem7_Click;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem8
    {
      get => _ToolStripMenuItem8;
      set
      {
        if (_ToolStripMenuItem8 != null)
          _ToolStripMenuItem8.Click -= ToolStripMenuItem8_Click;
        _ToolStripMenuItem8 = value;
        if (_ToolStripMenuItem8 != null)
          _ToolStripMenuItem8.Click += ToolStripMenuItem8_Click;
      }
    }

    internal virtual PictureBox PicturePlay
    {
      get => _PicturePlay;
      set
      {
        if (_PicturePlay != null)
          _PicturePlay.MouseUp -= PicturePlay_MouseUp;
        _PicturePlay = value;
        if (_PicturePlay != null)
          _PicturePlay.MouseUp += PicturePlay_MouseUp;
      }
    }

    internal virtual ContextMenuStrip ContextMenuStrip2
    {
      get => _ContextMenuStrip2;
      set
      {
        if (_ContextMenuStrip2 != null)
          _ContextMenuStrip2.Opening -= ContextMenuStrip2_Opening;
        _ContextMenuStrip2 = value;
        if (_ContextMenuStrip2 != null)
          _ContextMenuStrip2.Opening += ContextMenuStrip2_Opening;
      }
    }

    internal virtual ToolStripMenuItem ReEnableAppToolStripMenuItem
    {
      get => _ReEnableAppToolStripMenuItem;
      set => _ReEnableAppToolStripMenuItem = value;
    }

    internal virtual GroupBox GroupBox1
    {
      get => _GroupBox1;
      set => _GroupBox1 = value;
    }

    internal virtual TextBox TextBox1
    {
      get => _TextBox1;
      set
      {
        if (_TextBox1 != null)
          _TextBox1.KeyDown -= TextBox1_KeyDown;
        _TextBox1 = value;
        if (_TextBox1 != null)
          _TextBox1.KeyDown += TextBox1_KeyDown;
      }
    }

    internal virtual Button Button2
    {
      get => _Button2;
      set
      {
        if (_Button2 != null)
           _Button2.Click -= Button2_Click;
        _Button2 = value;
        if (_Button2 != null)
           _Button2.Click += Button2_Click;
      }
    }

    internal virtual Label Label6
    {
      get => _Label6;
      set => _Label6 = value;
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem1
    {
      get => _ToolStripMenuItem1;
      set
      {
        if (_ToolStripMenuItem1 != null)
          _ToolStripMenuItem1.Click -= ToolStripMenuItem1_Click;
        _ToolStripMenuItem1 = value;
        if (_ToolStripMenuItem1 != null)
          _ToolStripMenuItem1.Click += ToolStripMenuItem1_Click;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem9
    {
      get => _ToolStripMenuItem9;
      set
      {
        if (_ToolStripMenuItem9 != null)
          _ToolStripMenuItem9.Click -= ToolStripMenuItem9_Click;
        _ToolStripMenuItem9 = value;
        if (_ToolStripMenuItem9 != null)
          _ToolStripMenuItem9.Click += ToolStripMenuItem9_Click;
      }
    }

    internal virtual ToolStripSeparator ToolStripSeparator1
    {
      get => _ToolStripSeparator1;
      set => _ToolStripSeparator1 = value;
    }

    internal virtual ToolStripSeparator ToolStripSeparator2
    {
      get => _ToolStripSeparator2;
      set => _ToolStripSeparator2 = value;
    }

    internal virtual GroupBox GroupBox2
    {
      get => _GroupBox2;
      set => _GroupBox2 = value;
    }

    internal virtual ToolStripMenuItem ShowAppInLibraryAndProfilesToolStripMenuItem
    {
      get => _ShowAppInLibraryAndProfilesToolStripMenuItem;
      set
      {
        if (_ShowAppInLibraryAndProfilesToolStripMenuItem != null)
          _ShowAppInLibraryAndProfilesToolStripMenuItem.Click -= ShowAppInLibraryAndProfilesToolStripMenuItem_Click;
        _ShowAppInLibraryAndProfilesToolStripMenuItem = value;
        if (_ShowAppInLibraryAndProfilesToolStripMenuItem != null)
           _ShowAppInLibraryAndProfilesToolStripMenuItem.Click += ShowAppInLibraryAndProfilesToolStripMenuItem_Click;
      }
    }

    internal virtual DotNetBarTabcontrol DotNetBarTabcontrol1
    {
      get => _DotNetBarTabcontrol1;
      set => _DotNetBarTabcontrol1 = value;
    }

    internal virtual TabPage TabPage1
    {
      get => _TabPage1;
      set => _TabPage1 = value;
    }

    internal virtual MenuStrip MenuStrip1
    {
      get => _MenuStrip1;
      set => _MenuStrip1 = value;
    }

    internal virtual ToolStripMenuItem OptionsToolStripMenuItem
    {
      get => _OptionsToolStripMenuItem;
      set => _OptionsToolStripMenuItem = value;
    }

    internal virtual ToolStripMenuItem AddSteamVRToolStripMenuItem
    {
      get => _AddSteamVRToolStripMenuItem;
      set
      {
        if (_AddSteamVRToolStripMenuItem != null)
          _AddSteamVRToolStripMenuItem.Click -= AddSteamVRToolStripMenuItem_Click;
        _AddSteamVRToolStripMenuItem = value;
        if (_AddSteamVRToolStripMenuItem != null)
          _AddSteamVRToolStripMenuItem.Click += AddSteamVRToolStripMenuItem_Click;
      }
    }

    internal virtual ToolStripMenuItem ShowToolStripMenuItem
    {
      get => _ShowToolStripMenuItem;
      set
      {
        if (_ShowToolStripMenuItem != null)
          _ShowToolStripMenuItem.Click -= ShowToolStripMenuItem_Click;
        _ShowToolStripMenuItem = value;
        if (_ShowToolStripMenuItem != null)
          _ShowToolStripMenuItem.Click += ShowToolStripMenuItem_Click;
      }
    }

    internal virtual ToolStripMenuItem ShowRemoved3rdPartyAppsToolStripMenuItem
    {
      get => _ShowRemoved3rdPartyAppsToolStripMenuItem;
      set => _ShowRemoved3rdPartyAppsToolStripMenuItem = value;
    }

    internal virtual ToolStripMenuItem SortingToolStripMenuItem
    {
      get => _SortingToolStripMenuItem;
      set => _SortingToolStripMenuItem = value;
    }

    internal virtual ToolStripMenuItem AscendingToolStripMenuItem
    {
      get => _AscendingToolStripMenuItem;
      set
      {
        if (_AscendingToolStripMenuItem != null)
          _AscendingToolStripMenuItem.Click -= AscendingToolStripMenuItem_Click;
        _AscendingToolStripMenuItem = value;
        if (_AscendingToolStripMenuItem != null)
          _AscendingToolStripMenuItem.Click += AscendingToolStripMenuItem_Click;
      }
    }

    internal virtual ToolStripMenuItem DescendingToolStripMenuItem
    {
      get => _DescendingToolStripMenuItem;
      set
      {
        if (_DescendingToolStripMenuItem != null)
          _DescendingToolStripMenuItem.Click -= DescendingToolStripMenuItem_Click;
        _DescendingToolStripMenuItem = value;
        if (_DescendingToolStripMenuItem != null)
          _DescendingToolStripMenuItem.Click += DescendingToolStripMenuItem_Click;
      }
    }

    internal virtual ToolStripMenuItem RefreshLibraryToolStripMenuItem
    {
      get => _RefreshLibraryToolStripMenuItem;
      set
      {
        if (_RefreshLibraryToolStripMenuItem != null)
          _RefreshLibraryToolStripMenuItem.Click -= RefreshLibraryToolStripMenuItem_Click;
        _RefreshLibraryToolStripMenuItem = value;
        if (_RefreshLibraryToolStripMenuItem != null)
          _RefreshLibraryToolStripMenuItem.Click += RefreshLibraryToolStripMenuItem_Click;
      }
    }

    internal virtual ToolStripMenuItem ShowIgnoredAppsToolStripMenuItem
    {
      get => _ShowIgnoredAppsToolStripMenuItem;
      set
      {
        if (_ShowIgnoredAppsToolStripMenuItem != null)
          _ShowIgnoredAppsToolStripMenuItem.Click -= ShowIgnoredAppsToolStripMenuItem_Click;
        _ShowIgnoredAppsToolStripMenuItem = value;
        if (_ShowIgnoredAppsToolStripMenuItem != null)
          _ShowIgnoredAppsToolStripMenuItem.Click += ShowIgnoredAppsToolStripMenuItem_Click;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem5
    {
      get => _ToolStripMenuItem5;
      set
      {
        if (_ToolStripMenuItem5 != null)
          _ToolStripMenuItem5.Click -= ToolStripMenuItem5_Click;
        _ToolStripMenuItem5 = value;
        if (_ToolStripMenuItem5 != null)
          _ToolStripMenuItem5.Click += ToolStripMenuItem5_Click;
      }
    }

    internal virtual ToolStripMenuItem ToolStripMenuItem6
    {
      get => _ToolStripMenuItem6;
      set
      {
        if (_ToolStripMenuItem6 != null)
          _ToolStripMenuItem6.Click -= ToolStripMenuItem6_Click;
        _ToolStripMenuItem6 = value;
        if (_ToolStripMenuItem6 != null)
          _ToolStripMenuItem6.Click += ToolStripMenuItem6_Click;
      }
    }

    internal virtual ToolStripSeparator ToolStripSeparator3
    {
      get => _ToolStripSeparator3;
      set => _ToolStripSeparator3 = value;
    }

    internal virtual ToolStripMenuItem RemoveProfileToolStripMenuItem
    {
      get => _RemoveProfileToolStripMenuItem;
      set
      {
        if (_RemoveProfileToolStripMenuItem != null)
          _RemoveProfileToolStripMenuItem.Click -= RemoveProfileToolStripMenuItem_Click;
        _RemoveProfileToolStripMenuItem = value;
        if (_RemoveProfileToolStripMenuItem != null)
          _RemoveProfileToolStripMenuItem.Click += RemoveProfileToolStripMenuItem_Click;
      }
    }

    [field: AccessedThroughProperty("Client")]
    private WebClient Client { get; set; }

    private static string ByteArrayToString(byte[] ba)
    {
      return BitConverter.ToString(ba).Replace("-", "");
    }

    private static byte[] GetBytes(SQLiteDataReader reader)
    {
      byte[] buffer = new byte[2048];
      long fieldOffset = 0;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        long target;
        while (frmLibrary.InlineAssignHelper<long>(ref target, reader.GetBytes(0, fieldOffset, buffer, 0, buffer.Length)) > 0L)
        {
          memoryStream.Write(buffer, 0, checked ((int) target));
          checked { fieldOffset += target; }
        }
        return memoryStream.ToArray();
      }
    }

    private static T InlineAssignHelper<T>(ref T target, T value)
    {
      target = value;
      return value;
    }

    public static void SetDoubleBuffering(Control control, bool value)
    {
      typeof (Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) control, (object) value, (object[]) null);
    }

    private void GetOculusLibrary(string p)
    {
      frmLibrary.SetDoubleBuffering((Control) this.ListView1, true);
      this.PicturePlay.Visible = false;
      if (Globals.dbg)
        Log.WriteToLog("Entering GetOculusLibrary");
      if (System.IO.File.Exists(Application.StartupPath + "\\data.sqlite"))
      {
        if (Globals.dbg)
          Log.WriteToLog("Opening database copy");
        try
        {
          if (this.cnn.State == ConnectionState.Closed)
          {
            this.cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
            this.cnn.Open();
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToLog("Failed to open database copy: " + exception.Message);
          int num = (int) Interaction.MsgBox((object) ("Failed to open database copy: " + exception.Message), MsgBoxStyle.Critical, (object) "Error opening database");
          FrmMain.fmain.AddToListboxAndScroll("Failed to open database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          ProjectData.ClearProjectError();
          return;
        }
        if (Globals.dbg)
          Log.WriteToLog("Parsing Manifests in " + p);
        SQLiteCommand sqLiteCommand = new SQLiteCommand(this.cnn);
        this.ListView1.BeginUpdate();
        string[] files = Directory.GetFiles(p, "*.mini");
        int index1 = 0;
        while (index1 < files.Length)
        {
          string path = files[index1];
          JObject jobject = JObject.Parse(System.IO.File.ReadAllText(path));
          string str1 = p.Replace("\\Manifests", "") + "\\Software";
          string str2 = jobject.SelectToken("canonicalName").ToString();
          string Left = jobject.SelectToken("appId").ToString();
          string str3 = str1 + "\\" + str2 + "\\" + jobject.SelectToken("launchFile").ToString().Replace("/", "\\");
          string str4 = MySettingsProperty.Settings.OculusPath.TrimEnd('\\') + "\\CoreData\\Software\\StoreAssets\\" + str2 + "_assets";
          string str5 = str4 + "\\small_landscape_image.jpg";
          if (!System.IO.File.Exists(str5))
          {
            Log.WriteToLog("Could not find game icon '" + str5 + "', looking in the other library paths");
            string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
            int index2 = 0;
            while (index2 < strArray.Length)
            {
              str4 = strArray[index2].TrimEnd('\\') + "\\Software\\StoreAssets\\" + str2 + "_assets";
              str5 = str4 + "\\small_landscape_image.jpg";
              if (System.IO.File.Exists(str5))
              {
                Log.WriteToLog("Found game icon at '" + str5 + "'");
                break;
              }
              checked { ++index2; }
            }
          }
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left, "", false) != 0)
          {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
              sqLiteCommand.CommandText = "Select value from Objects WHERE hashkey='" + Left + "' AND typename='Application'";
              using (SQLiteDataReader reader = sqLiteCommand.ExecuteReader())
              {
                if (reader.HasRows)
                {
                  while (reader.Read())
                  {
                    byte[] bytes = frmLibrary.GetBytes(reader);
                    stringBuilder.Append(Encoding.Default.GetString(bytes));
                  }
                }
                else
                  goto label_44;
              }
            }
            catch (Exception ex)
            {
              ProjectData.SetProjectError(ex);
              Exception exception = ex;
              Log.WriteToLog("Failed to read database entry for appId '" + Left + "': " + exception.Message);
              FrmMain.fmain.AddToListboxAndScroll("Failed to read database entry for appId '" + Left + "': " + exception.Message);
              MyProject.Forms.FrmMain.hasError = true;
              ProjectData.ClearProjectError();
              return;
            }
            string str6 = Regex.Replace(stringBuilder.ToString(), "[^A-Za-z0-9\\-/]", ":").Replace(":::", ":").Replace("::", ":");
            string str7 = "display:name::";
            string str8 = Conversions.ToInteger(MyProject.Forms.FrmMain.OculusAppVersion) < 118 ? ":grouping" : ":display:short:description";
            int num1 = str6.IndexOf(str7);
            int num2 = str6.IndexOf(str8);
            if (num1 > -1 && num2 > -1)
            {
              string str9 = str6.Substring(checked (num1 + str7.Length), checked (num2 - num1 - str7.Length)).Replace(":", " ").TrimEnd(':').TrimEnd(' ');
              string text = str9.Remove(checked (str9.Length - 1));
              if (this.ListView1.FindItemWithText(text) == null)
              {
                if (System.IO.File.Exists(str5))
                {
                  using (Image image = Image.FromFile(str5))
                    this.imageListLarge.Images.Add(str3, image);
                }
                else
                  this.imageListLarge.Images.Add(str3, (Image) OculusTrayTool.My.Resources.Resources.removed_app);
                this.ListView1.Items.Add(new ListViewItem(text, str3)
                {
                  Tag = (object) (Path.GetFileName(str3) + "," + str4 + "," + path.Replace(".mini", "") + "," + str3),
                  ForeColor = !(this.ManualStartProfiles.ContainsKey(str3) | this.ManualStartProfiles.ContainsKey(str3.ToLower())) ? (!this.DisplayNameList.Contains(text.ToLower()) ? Color.Red : Color.Blue) : Color.Green
                });
                if (!this.IconGameList.Contains(text))
                  this.IconGameList.Add(text);
              }
            }
          }
label_44:
          checked { ++index1; }
        }
        this.ListView1.Sorting = SortOrder.Ascending;
        this.ListView1.Sort();
        this.ListView1.EndUpdate();
        sqLiteCommand.Dispose();
        this.cnn.Close();
        if (Globals.dbg)
          Log.WriteToLog("Connection closed");
        if (Globals.dbg)
          Log.WriteToLog("Exiting GetOculusLibrary");
      }
    }

    private void GetThirdPartyApps(string p)
    {
      if (Globals.dbg)
        Log.WriteToLog("Entering GetThirdPartyApps");
      
      List<string> steamGameList = new List<string>();
      PicturePlay.Visible = false;
      ListView1.BeginUpdate();

      // Read SteamVR Manifest
      if (!string.IsNullOrEmpty(MyProject.Forms.FrmMain.SteamPath))
      {
        string path = Path.Combine(MyProject.Forms.FrmMain.SteamPath, "config\\steamapps.vrmanifest");
        if (System.IO.File.Exists(path))
        {
          if (Globals.dbg) Log.WriteToLog("Found Steam VR manifest: " + path);
          try
          {
            string json = System.IO.File.ReadAllText(path);
            JObject jobject = JObject.Parse(json);
            JToken applications = jobject["applications"];
            if (applications != null)
            {
              foreach (JToken app in applications)
              {
                string name = app["strings"]?["en_us"]?["name"]?.ToString();
                if (!string.IsNullOrEmpty(name) && !steamGameList.Contains(name))
                {
                  steamGameList.Add(name);
                  if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps: Steam game '" + name + "' added to list");
                }
              }
            }
          }
          catch (Exception ex)
          {
            Log.WriteToLog("Error parsing Steam VR manifest: " + ex.Message);
          }
        }
        else
        {
          Log.WriteToLog("Could not locate Steam VR manifest");
        }
      }

      // Process JSON files
      try
      {
        string[] files = Directory.GetFiles(p, "*.json");
        foreach (string file in files)
        {
          try
          {
            if (file.Contains("_assets.json")) continue;

            if (Globals.dbg) Log.WriteToLog("Opening " + file);
            string json = System.IO.File.ReadAllText(file);
            JObject jobject = JObject.Parse(json);

            bool isThirdParty = (bool?)jobject["thirdParty"] ?? false;
            string canonName = (string)jobject["canonicalName"];
            string displayName = (string)jobject["displayName"];
            string launchFile = (string)jobject["launchFile"];
            string fullPath = launchFile?.Replace("\\\\", "\\").Replace("/", "\\");
            string fileName = fullPath != null ? Path.GetFileName(fullPath) : null;

            if (!isThirdParty)
            {
              if (Globals.dbg) Log.WriteToLog("'" + displayName + "' is not thirdParty, ignoring for now");
              continue;
            }

            if (steamGameList.Contains(displayName))
            {
              if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + displayName + "' to Library view");
              AddThirdPartyGameToLibrary(p, steamGameList, canonName, displayName, fileName, fullPath);
            }
            else
            {
              Log.WriteToLog("'" + displayName + "' not found in Steam game list, getting info from the Oculus Database");
              
              if (cnn.State == ConnectionState.Closed)
              {
                cnn = new SQLiteConnection("Data Source=" + Application.StartupPath + "\\data.sqlite");
                cnn.Open();
              }

              StringBuilder sb = new StringBuilder();
              using (SQLiteCommand cmd = new SQLiteCommand(cnn))
              {
                cmd.CommandText = "select value from Objects WHERE hashkey='" + canonName + "_LocalAppState' AND typename='LocalApplicationState'";
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                  while (reader.Read())
                  {
                    byte[] bytes = GetBytes(reader);
                    sb.Append(Encoding.Default.GetString(bytes));
                  }
                }

                string dbContent = sb.ToString();
                if (dbContent.Contains("FLAT"))
                {
                  if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
                }
                else if (!string.IsNullOrEmpty(dbContent))
                {
                   if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + displayName + "' to Library view");
                   AddThirdPartyGameToLibrary(p, steamGameList, canonName, displayName, fileName, fullPath);
                }
                else
                {
                   if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps:  -> Not found, looking for secondary entry: " + canonName + ": UserAppPlayTime");
                   cmd.CommandText = "select value from Objects WHERE hashkey LIKE \"%" + canonName + "%\" AND typename='UserAppPlayTime'";
                   using (SQLiteDataReader reader2 = cmd.ExecuteReader())
                   {
                     if (reader2.HasRows)
                     {
                       if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps:  -> Found entry for " + canonName + ": UserAppPlayTime");
                       if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps: Adding '" + displayName + "' to Library view");
                       AddThirdPartyGameToLibrary(p, steamGameList, canonName, displayName, fileName, fullPath);
                     }
                     else if (MyProject.Forms.FrmMain.includedApps.Contains(file))
                     {
                        AddThirdPartyGameToLibrary(p, steamGameList, canonName, displayName, fileName, fullPath);
                     }
                     else
                     {
                        if (Globals.dbg) Log.WriteToLog("GetThirdPartyLibraryApps:  -> App does not appear to be a VR app, ignoring");
                     }
                   }
                }
              }
              // Close connection after each db check to match legacy behavior? 
              // The original closed it at label 111.
              // But it makes sense to keep it open?
              // I'll close it here to be safe and match assumed legacy behavior of "transient connection"
              if (cnn.State == ConnectionState.Open) cnn.Close();
            }
          }
          catch (Exception ex)
          {
            ProjectData.SetProjectError(ex);
            Log.WriteToLog("Error processing file " + file + ": " + ex.Message);
            ProjectData.ClearProjectError();
          }
        }
      }
      catch (Exception ex)
      {
         ProjectData.SetProjectError(ex);
         Log.WriteToLog("Error in GetThirdPartyApps: " + ex.Message);
         ProjectData.ClearProjectError();
      }

      ListView1.EndUpdate();
      if (cnn.State == ConnectionState.Open) cnn.Close();
      if (Globals.dbg) Log.WriteToLog("Exiting GetThirdPartyApps");
    }

    private void AddThirdPartyGameToLibrary(
      string p,
      List<string> steamGameList,
      string canonName,
      string DisplayName,
      string LaunchFile,
      string fullpath)
    {
      try
      {
        if (this.IconGameList.Contains(DisplayName))
        {
          if (!Globals.dbg)
            return;
          Log.WriteToLog("AddThirdPartyGameToLibrary: '" + DisplayName + "' has already been added to the library, skipping");
        }
        else
        {
          bool flag = false;
          string str1 = p + "\\" + canonName + ".json";
          string str2 = MySettingsProperty.Settings.OculusPath.TrimEnd('\\') + "\\CoreData\\Software\\StoreAssets\\" + canonName + "_assets";
          string str3 = str2 + "\\small_landscape_image.jpg";
          if (System.IO.File.Exists(str3))
          {
            flag = true;
            if (Globals.dbg)
              Log.WriteToLog("Game icon for '" + DisplayName + "' found: " + str3);
          }
          else
          {
            string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
            int index = 0;
            while (index < strArray.Length)
            {
              str2 = strArray[index].TrimEnd('\\') + "\\Software\\StoreAssets\\" + canonName + "_assets";
              str3 = str2 + "\\small_landscape_image.jpg";
              if (System.IO.File.Exists(str3))
              {
                flag = true;
                if (Globals.dbg)
                {
                  Log.WriteToLog("Game icon for '" + DisplayName + "' found: " + str3);
                  break;
                }
                break;
              }
              checked { ++index; }
            }
          }
          if (!flag)
          {
            Log.WriteToLog("Could not locate local icon for '" + DisplayName + "'");
            str3 = "Default Unknown";
          }
          if (DisplayName.ToLower().EndsWith(".exe") | Microsoft.VisualBasic.CompilerServices.Operators.CompareString(DisplayName.ToLower(), "unknown app", false) == 0)
            DisplayName = Path.GetFileNameWithoutExtension(LaunchFile);
          if (Globals.dbg)
          {
            Log.WriteToLog("    App is thirdParty");
            Log.WriteToLog("    DisplayName: '" + DisplayName + "'");
            Log.WriteToLog("    LaunchFile: '" + LaunchFile + "'");
            Log.WriteToLog("    FullPath: '" + fullpath + "'");
            Log.WriteToLog("    assetsPath: '" + str2 + "'");
            Log.WriteToLog("    iconFile: '" + str3 + "'");
          }
          string str4 = Path.GetFileName(LaunchFile) + "," + str2 + "," + str1 + ",3rdParty," + LaunchFile;
          if (!OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Library") & !OTTDB.CheckHiddenApp(LaunchFile, DisplayName, "Both"))
          {
            if (Globals.dbg)
              Log.WriteToLog("    Hidden: False");
            if (System.IO.File.Exists(str3))
            {
              using (Image image = Image.FromFile(str3))
              {
                if (Globals.dbg)
                  Log.WriteToLog("AddThirdPartyGameToLibrary: Adding '" + DisplayName + "' (" + LaunchFile + ") to library with '" + str3 + "'");
                this.imageListLarge.Images.Add(LaunchFile, image);
              }
            }
            else
            {
              if (Globals.dbg)
                Log.WriteToLog("AddThirdPartyGameToLibrary: Adding '" + DisplayName + "' (" + LaunchFile + ") to library with [???] icon");
              this.imageListLarge.Images.Add(LaunchFile, (Image) OculusTrayTool.My.Resources.Resources.removed_app);
            }
            this.ListView1.Items.Add(new ListViewItem(DisplayName, LaunchFile)
            {
              Tag = (object) str4,
              ForeColor = !(this.ManualStartProfiles.ContainsKey(fullpath) | this.ManualStartProfiles.ContainsKey(fullpath.ToLower())) ? (!this.DisplayNameList.Contains(DisplayName.ToLower()) ? Color.Red : Color.Blue) : Color.Green
            });
            if (!this.IconGameList.Contains(DisplayName))
              this.IconGameList.Add(DisplayName);
          }
          else if (Globals.dbg)
            Log.WriteToLog("    Hidden: True");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("AddThirdPartyGameToLibrary: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void Library_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.changeMade && Process.GetProcessesByName("OculusClient").Length > 0)
      {
        int num = (int) Interaction.MsgBox((object) "You may need to restart oculus Home to see the new icons in VR.", MsgBoxStyle.Information, (object) "Oculus Tray Tool");
      }
      MySettingsProperty.Settings.LibraryWindowLocation = this.Location;
      MySettingsProperty.Settings.LibraryWindowSize = this.Size;
      MySettingsProperty.Settings.Save();
      if (e.CloseReason != CloseReason.UserClosing)
        return;
      e.Cancel = true;
      this.Hide();
    }

    private void Library_Load(object sender, EventArgs e) => this.LoadLibrary();

    public void LoadLibrary()
    {
      Control.CheckForIllegalCrossThreadCalls = false;
      Log.WriteToLog("Opening Library");
      this.changeMade = false;
      if (MySettingsProperty.Settings.LibraryWindowLocation != new Point())
      {
        if (Globals.dbg)
          Log.WriteToLog("Setting Library GUI location to " + MySettingsProperty.Settings.LibraryWindowLocation.ToString());
        this.Location = MySettingsProperty.Settings.LibraryWindowLocation;
      }
      else
      {
        this.CenterToScreen();
        MySettingsProperty.Settings.LibraryWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      Point location = this.Location;
      int num1 = location.X < 0 ? 1 : 0;
      location = this.Location;
      int num2 = location.Y < 0 ? 1 : 0;
      if ((num1 | num2) != 0)
      {
        if (Globals.dbg)
          Log.WriteToLog("Library GUI location has negative number, adjusting");
        this.CenterToScreen();
        MySettingsProperty.Settings.LibraryWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      this.Size = MySettingsProperty.Settings.LibraryWindowSize;
      this.rs.FindAllControls((Control) this);
      this.rs.ResizeAllControls((Control) this, (float) MyProject.Forms.FrmMain.TrackBar1.Value);
      this.imageListLarge.ColorDepth = ColorDepth.Depth32Bit;
      this.ImgListOverlay.ColorDepth = ColorDepth.Depth32Bit;
      this.ImgListOverlay.Images.Add((Image) OculusTrayTool.My.Resources.Resources.play2);
      this.PicturePlay.Visible = false;
      frmLibrary.icons.Images.Clear();
      frmLibrary.icons.ColorDepth = ColorDepth.Depth32Bit;
      frmLibrary.icons.ImageSize = new Size(250, 90);
      if (!this.libraryLoaded)
      {
        Log.WriteToLog("Library not loaded");
        this.PopulateList();
      }
      else if (Globals.dbg)
        Log.WriteToLog("Library already loaded, proceeding");
    }

    private object GenerateSHA256Hash(string filename)
    {
      using (FileStream inputStream = System.IO.File.OpenRead(filename))
        return (object) BitConverter.ToString(new SHA256Managed().ComputeHash((Stream) inputStream)).Replace("-", string.Empty).ToLower();
    }

    public void PopulateList()
    {
      this.Cursor = Cursors.WaitCursor;
      if (Globals.dbg)
        Log.WriteToLog("Loading Library view");
      this.PicturePlay.Visible = false;
      this.ListView1.Items.Clear();
      this.imageListLarge.Images.Clear();
      this.imageListLarge.ImageSize = new Size(250, 90);
      this.ListView1.LargeImageList = this.imageListLarge;
      this.ListView1.View = View.LargeIcon;
      this.ContextMenuStrip1.Visible = true;
      this.ContextMenuStrip1.Close();
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests"))
        this.GetOculusLibrary(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
        this.GetOculusLibrary(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
        this.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0)
      {
        string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
        int index = 0;
        while (index < strArray.Length)
        {
          string str = strArray[index];
          if (Directory.Exists(str.TrimEnd('\\') + "\\Manifests"))
            this.GetOculusLibrary(str.TrimEnd('\\') + "\\Manifests");
          if (Directory.Exists(str.TrimEnd('\\') + "\\CoreData\\Manifests"))
            this.GetThirdPartyApps(str.TrimEnd('\\') + "\\CoreData\\Manifests");
          checked { ++index; }
        }
      }
      MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
      MyProject.Forms.frmProfiles.GameList.Clear();
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests"))
        GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests"))
        GetGames.GetFiles(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\Software\\Manifests");
      if (Directory.Exists(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests"))
        GetGames.GetThirdPartyApps(MyProject.Forms.FrmMain.OculusPath.TrimEnd('\\') + "\\CoreData\\Manifests");
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MySettingsProperty.Settings.LibraryPath, "", false) != 0)
      {
        string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
        int index = 0;
        while (index < strArray.Length)
        {
          string str = strArray[index];
          if (Directory.Exists(str.TrimEnd('\\') + "\\Manifests"))
            GetGames.GetFiles(str.TrimEnd('\\') + "\\Manifests");
          if (Directory.Exists(str.TrimEnd('\\') + "\\CoreData\\Manifests"))
            GetGames.GetThirdPartyApps(str.TrimEnd('\\') + "\\CoreData\\Manifests");
          checked { ++index; }
        }
      }
      this.libraryLoaded = true;
      this.Cursor = Cursors.Default;
    }

    private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count == 0)
        return;
      if (this.ListView1.SelectedItems.Count > 0 & this.PicturePlay.Visible)
      {
        if (this.ListView1.SelectedItems[0].ForeColor == Color.Red)
        {
          this.ToolStripMenuItem1.Visible = true;
          this.ToolStripMenuItem9.Visible = false;
          this.RemoveProfileToolStripMenuItem.Visible = false;
        }
        if (this.ListView1.SelectedItems[0].ForeColor == Color.Green)
        {
          this.ToolStripMenuItem1.Visible = false;
          this.ToolStripMenuItem9.Visible = true;
          this.RemoveProfileToolStripMenuItem.Visible = true;
        }
        if (Conversions.ToBoolean(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, (Type) null, "contains", new object[1]
        {
          (object) "3rdParty"
        }, (string[]) null, (Type[]) null, (bool[]) null)))
        {
          this.ToolStripMenuItem2.Visible = true;
          this.ToolStripMenuItem4.Visible = true;
          this.ToolStripMenuItem5.Visible = true;
          this.ToolStripMenuItem7.Visible = true;
          this.ToolStripMenuItem8.Visible = true;
        }
        else if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, (Type) null, "contains", new object[1]
        {
          (object) "hidden"
        }, (string[]) null, (Type[]) null, (bool[]) null))))
        {
          this.ToolStripMenuItem2.Visible = true;
          this.ToolStripMenuItem4.Visible = false;
          this.ToolStripMenuItem5.Visible = false;
          this.ToolStripMenuItem7.Visible = true;
          this.ToolStripMenuItem8.Visible = true;
        }
        if (!this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked)
          return;
        this.ToolStripMenuItem2.Visible = false;
        this.ToolStripMenuItem4.Visible = false;
        this.ToolStripMenuItem5.Visible = false;
        this.ToolStripMenuItem7.Visible = false;
        this.ToolStripMenuItem8.Visible = false;
      }
      else
      {
        this.ToolStripMenuItem1.Visible = false;
        this.ToolStripMenuItem2.Visible = false;
        this.ToolStripMenuItem4.Visible = false;
        this.ToolStripMenuItem5.Visible = false;
        this.ToolStripMenuItem7.Visible = false;
        this.ToolStripMenuItem8.Visible = false;
      }
    }

    private void CreateManifest(
      string canonicalName,
      string displayName,
      string files,
      string launchFile,
      string path)
    {
      StringWriter stringWriter = new StringWriter(new StringBuilder());
      using (JsonWriter jsonWriter = (JsonWriter) new JsonTextWriter((TextWriter) stringWriter))
      {
        jsonWriter.Formatting = Formatting.Indented;
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName(nameof (canonicalName));
        jsonWriter.WriteValue(canonicalName);
        jsonWriter.WritePropertyName(nameof (displayName));
        jsonWriter.WriteValue(displayName);
        jsonWriter.WritePropertyName(nameof (files));
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName(files);
        jsonWriter.WriteValue("");
        jsonWriter.WriteEndObject();
        jsonWriter.WritePropertyName("firewallExceptionsRequired");
        jsonWriter.WriteValue(false);
        jsonWriter.WritePropertyName("isCore");
        jsonWriter.WriteValue(false);
        jsonWriter.WritePropertyName(nameof (launchFile));
        jsonWriter.WriteValue(launchFile);
        jsonWriter.WritePropertyName("launchParameters");
        jsonWriter.WriteValue("");
        jsonWriter.WritePropertyName("manifestVersion");
        jsonWriter.WriteValue(0);
        jsonWriter.WritePropertyName("packageType");
        jsonWriter.WriteValue("APP");
        jsonWriter.WritePropertyName("thirdParty");
        jsonWriter.WriteValue(true);
        jsonWriter.WritePropertyName("version");
        jsonWriter.WriteValue("1");
        jsonWriter.WritePropertyName("versionCode");
        jsonWriter.WriteValue(1);
        jsonWriter.WriteEndObject();
      }
      StreamWriter streamWriter = new StreamWriter(path + "\\" + canonicalName + ".json");
      streamWriter.Write((object) stringWriter);
      streamWriter.Close();
    }

    private void CreateAssetManifest(
      string canonicalName,
      string color,
      Dictionary<string, string> files,
      string parameters,
      string path)
    {
      StringWriter stringWriter = new StringWriter(new StringBuilder());
      using (JsonWriter jsonWriter = (JsonWriter) new JsonTextWriter((TextWriter) stringWriter))
      {
        jsonWriter.Formatting = Formatting.Indented;
        jsonWriter.WriteStartObject();
        jsonWriter.WritePropertyName("dominantColor");
        jsonWriter.WriteValue(color);
        jsonWriter.WritePropertyName(nameof (files));
        jsonWriter.WriteStartObject();
        try
        {
          foreach (KeyValuePair<string, string> file in files)
          {
            jsonWriter.WritePropertyName(file.Key);
            jsonWriter.WriteValue(file.Value);
          }
        }
        finally
        {
          Dictionary<string, string>.Enumerator enumerator;
          enumerator.Dispose();
        }
        jsonWriter.WriteEndObject();
        jsonWriter.WritePropertyName("packageType");
        jsonWriter.WriteValue("ASSET_BUNDLE");
        jsonWriter.WritePropertyName("isCore");
        jsonWriter.WriteValue(false);
        jsonWriter.WritePropertyName("appId");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName(nameof (canonicalName));
        jsonWriter.WriteValue(canonicalName);
        jsonWriter.WritePropertyName("launchFile");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName("launchParameters");
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(parameters, "", false) == 0)
          jsonWriter.WriteNull();
        else
          jsonWriter.WriteValue(parameters);
        jsonWriter.WritePropertyName("launchFile2D");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName("launchParameters2D");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName("version");
        jsonWriter.WriteValue("1");
        jsonWriter.WritePropertyName("versionCode");
        jsonWriter.WriteValue(1);
        jsonWriter.WritePropertyName("redistributables");
        jsonWriter.WriteNull();
        jsonWriter.WritePropertyName("firewallExceptionsRequired");
        jsonWriter.WriteValue(false);
        jsonWriter.WritePropertyName("thirdParty");
        jsonWriter.WriteValue(true);
        jsonWriter.WritePropertyName("manifestVersion");
        jsonWriter.WriteValue(0);
        jsonWriter.WriteEndObject();
      }
      StreamWriter streamWriter = new StreamWriter(path + "\\" + canonicalName + ".json");
      streamWriter.Write((object) stringWriter);
      streamWriter.Close();
    }

    private void ToolStripMenuItem2_Click(object sender, EventArgs e)
    {
      string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
      if (!System.IO.File.Exists(strArray[2]))
        return;
      MyProject.Forms.frmProperties.RichTextBox1.Text = JToken.Parse(System.IO.File.ReadAllText(strArray[2])).ToString(Formatting.Indented);
      MyProject.Forms.frmProperties.TextBox1.Text = strArray[2];
      MyProject.Forms.frmProperties.fname = strArray[2];
      this.rs.FindAllControls((Control) MyProject.Forms.frmProperties);
      this.rs.ResizeAllControls((Control) MyProject.Forms.frmProperties, (float) MyProject.Forms.FrmMain.TrackBar1.Value);
      if (Conversions.ToBoolean(Microsoft.VisualBasic.CompilerServices.Operators.NotObject(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, (Type) null, "contains", new object[1]
      {
        (object) "3rdParty"
      }, (string[]) null, (Type[]) null, (bool[]) null))))
        MyProject.Forms.frmProperties.Button1.Enabled = false;
      else
        MyProject.Forms.frmProperties.Button1.Enabled = true;
      int num = (int) MyProject.Forms.frmProperties.ShowDialog();
    }

    private void ToolStripMenuItem4_Click(object sender, EventArgs e)
    {
      OTTDB.HideApp(this.ListView1.SelectedItems[0].Text, Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",")[0], "Library");
      this.PopulateList();
    }

    private void ToolStripMenuItem5_Click(object sender, EventArgs e)
    {
      OTTDB.HideApp(this.ListView1.SelectedItems[0].Text, Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",")[0], "Both");
      this.PopulateList();
    }

    private void ToolStripMenuItem7_Click(object sender, EventArgs e) => this.LaunchApp();

    private void LaunchApp()
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
        if (!System.IO.File.Exists(strArray[2]))
          return;
        string str1 = "";
        string str2 = "";
        List<string> stringList = new List<string>();
        List<string> appInfo = this.GetAppInfo(strArray[2], "");
        int num1 = checked (appInfo.Count - 1);
        int num2 = 0;
        while (num2 <= num1)
        {
          str1 = appInfo[0];
          str2 = appInfo[1];
          checked { ++num2; }
        }
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "", false) != 0 & System.IO.File.Exists(str1))
        {
          MyProject.Forms.FrmMain.ManualStart = true;
          if (!MyProject.Forms.FrmMain.HomeIsRunning)
          {
            RunCommand.StartHome();
            Thread.Sleep(3000);
          }
          if (this.ManualStartProfiles.ContainsKey(str1.ToLower()))
          {
            Log.WriteToLog("Applying profile for " + OTTDB.GetDisplayName(str1));
            this.ApplyProfile(str1.TrimStart().TrimEnd());
          }
          else
            Log.WriteToLog("No profile found for '" + str1 + "'");
          Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
          if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "", false) != 0)
            Log.WriteToLog(" -> " + str1.TrimStart().TrimEnd() + " " + str2.TrimStart().TrimEnd());
          else
            Log.WriteToLog(" -> " + str1.TrimStart().TrimEnd());
          this.Cursor = Cursors.Default;
          Process.Start(str1, str2);
          if (Globals.dbg)
            Log.WriteToLog("Adding Worker AppWatchWorker");
          BackgroundWorker backgroundWorker = new BackgroundWorker();
          backgroundWorker.DoWork += new DoWorkEventHandler(MyProject.Forms.FrmMain.AppWork);
          backgroundWorker.RunWorkerAsync();
          if (Globals.dbg)
            Log.WriteToLog("Worker started");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("LaunchApp(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void ApplyProfile(string appName)
    {
      string ss = "";
      string displayName = appName; // Default to appName if not found
      try
      {
        if (!this.ManualStartProfiles.TryGetValue(appName.ToLower(), out ss))
          return;
        new Thread((ThreadStart) ([SpecialName] () => RunCommand.Run_debug_tool(ss))).Start();
        Log.WriteToLog("Manual game launch detected: " + displayName + " (" + appName + ")");
        Log.WriteToLog(displayName + ": Super Sampling @ " + ss);
        if (Globals.dbg)
          Log.WriteToLog(MyProject.Forms.FrmMain.runningApp + ": Super Sampling @ " + ss);
        FrmMain.fmain.AddToListboxAndScroll("Game launch detected: " + displayName);
        string str1 = "";
        if (MyProject.Forms.FrmMain.profileCpuDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str1))
        {
          System.Timers.Timer timer = new System.Timers.Timer();
          timer.AutoReset = false;
          timer.Interval = (double) checked (Conversions.ToInteger(str1) * 1000);
          timer.Elapsed += new ElapsedEventHandler(MyProject.Forms.FrmMain.ApplyCpuPrioTick);
          timer.Start();
          Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + str1 + " seconds");
          FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying CPU Priority in " + str1 + " seconds");
        }
        string str2 = "";
        if (MyProject.Forms.FrmMain.profileAswDelay.TryGetValue(MyProject.Forms.FrmMain.runningApp, out str2))
        {
          System.Timers.Timer timer = new System.Timers.Timer();
          timer.AutoReset = false;
          timer.Interval = (double) checked (Conversions.ToInteger(str2) * 1000);
          timer.Elapsed += new ElapsedEventHandler(MyProject.Forms.FrmMain.ApplyAswTick);
          timer.Start();
          Log.WriteToLog(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + str2 + " seconds");
          FrmMain.fmain.AddToListboxAndScroll(MyProject.Forms.FrmMain.runningapp_displayname + ": Applying ASW setting in " + str2 + " seconds");
        }
        string Left2 = "";
        if (MyProject.Forms.FrmMain.profileMirror.TryGetValue(MyProject.Forms.FrmMain.runningApp, out Left2) && Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Left2, "1", false) == 0)
        {
          System.Timers.Timer timer = new System.Timers.Timer();
          timer.AutoReset = false;
          timer.Interval = 2000.0;
          timer.Elapsed += new ElapsedEventHandler(FrmMain.fmain.ApplyMirrorTick);
          timer.Start();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("ApplyProfile(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private List<string> GetAppInfo(string jFile, string customParms)
    {
      List<string> appInfo;
      try
      {
        List<string> stringList = new List<string>();
        string str1 = "";
        JObject jobject = (JObject) JToken.Parse(System.IO.File.ReadAllText(jFile));
        string str2 = (string) jobject.SelectToken("canonicalName");
        string str3 = ((string) jobject.SelectToken("launchFile")).Replace("/", "\\").Replace("\\\\", "\\");
        string str4 = Microsoft.VisualBasic.CompilerServices.Operators.CompareString(customParms, "", false) != 0 ? customParms : (string) jobject.SelectToken("launchParameters");
        if (this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
          str1 = str3.Replace("/", "\\").Replace("\\\\", "\\");
        if (!this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty"))
        {
          string[] strArray = Strings.Split(MySettingsProperty.Settings.LibraryPath, ",");
          int index = 0;
          while (index < strArray.Length)
          {
            string str5 = strArray[index];
            if (System.IO.File.Exists(str5 + "\\Software\\" + str2 + "\\" + str3))
            {
              str1 = str5 + "\\Software\\" + str2 + "\\" + str3;
              break;
            }
            checked { ++index; }
          }
        }
        stringList.Add(str1);
        stringList.Add(str4);
        appInfo = stringList;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("GetAppInfo(): " + ex.Message);
        ProjectData.ClearProjectError();
      }
      return appInfo;
    }

    private void ListView1_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if (this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked || this.ShowToolStripMenuItem.Checked || this.ListView1.Items.Count == 0)
          return;
        ListViewItem itemAt = this.ListView1.GetItemAt(e.X, e.Y);
        try
        {
          foreach (ListViewItem listViewItem in this.ListView1.Items)
          {
            if (listViewItem != itemAt)
              listViewItem.Selected = false;
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
        if (itemAt != null)
        {
          itemAt.Selected = true;
          itemAt.EnsureVisible();
          ListViewHitTestInfo listViewHitTestInfo = this.ListView1.HitTest(e.X, e.Y);
          PictureBox picturePlay1 = this.PicturePlay;
          int left1 = this.ListView1.Left;
          Rectangle bounds = listViewHitTestInfo.Item.Bounds;
          int left2 = bounds.Left;
          int num1 = checked (left1 + left2 + 21);
          picturePlay1.Left = num1;
          PictureBox picturePlay2 = this.PicturePlay;
          int top1 = this.ListView1.Top;
          bounds = listViewHitTestInfo.Item.Bounds;
          int top2 = bounds.Top;
          int num2 = checked (top1 + top2 + 2);
          picturePlay2.Top = num2;
          string[] source = Strings.Split(Conversions.ToString(itemAt.Tag), ",");
          this.PicturePlay.Image = this.CreateOverlay(this.imageListLarge.Images[source[checked (((IEnumerable<string>) source).Count<string>() - 1)]]);
          this.PicturePlay.Visible = true;
          this.PicturePlay.Select();
        }
        else
          this.PicturePlay.Visible = false;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private Image CreateOverlay(Image im)
    {
      int width1 = this.ImgListOverlay.Images[0].Width;
      int height1 = this.ImgListOverlay.Images[0].Height;
      Bitmap bitmap = new Bitmap(width1, height1);
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        graphics.DrawImage(this.ImgListOverlay.Images[0], 0, 0, width1, height1);
      bitmap.MakeTransparent(Color.Red);
      int width2 = im.Width;
      int height2 = im.Height;
      Bitmap overlay = new Bitmap(width2, height2);
      int x = checked (width2 - width1) / 2;
      int y = checked (height2 - height1) / 2;
      using (Graphics graphics = Graphics.FromImage((Image) overlay))
      {
        graphics.DrawImage(im, 0, 0, width2, height2);
        graphics.DrawImage((Image) bitmap, x, y, width1, height1);
      }
      this.PicturePlay.Image = (Image) overlay;
      bitmap.Dispose();
      return (Image) overlay;
    }

    private void ToolStripMenuItem8_Click(object sender, EventArgs e)
    {
      string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
      if (System.IO.File.Exists(strArray[2]))
      {
        string str1 = "";
        string str2 = "";
        List<string> stringList = new List<string>();
        List<string> appInfo = this.GetAppInfo(strArray[2], "");
        int num1 = checked (appInfo.Count - 1);
        int num2 = 0;
        while (num2 <= num1)
        {
          str1 = appInfo[0];
          str2 = appInfo[1];
          checked { ++num2; }
        }
        MyProject.Forms.frmLaunchOptions.TextBox1.Text = str2;
        int num3 = (int) MyProject.Forms.frmLaunchOptions.ShowDialog();
        if (MyProject.Forms.frmLaunchOptions.optionsCanceled || !(Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str1, "", false) != 0 & System.IO.File.Exists(str1)))
          return;
        MyProject.Forms.FrmMain.ManualStart = true;
        Log.WriteToLog("Launching " + this.ListView1.SelectedItems[0].Text);
        Log.WriteToLog(" -> " + str1.TrimStart().TrimEnd() + " " + MyProject.Forms.frmLaunchOptions.TextBox1.Text.TrimStart().TrimEnd());
        this.ApplyProfile(str1.TrimStart().TrimEnd());
        Process.Start(str1, MyProject.Forms.frmLaunchOptions.TextBox1.Text);
        MyProject.Forms.frmLaunchOptions.Close();
      }
    }

    private void PicturePlay_MouseUp(object sender, MouseEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count <= 0 || e.Button != MouseButtons.Left)
        return;
      this.LaunchApp();
    }

    private void ContextMenuStrip2_Opening(object sender, CancelEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count == 0 || this.ListView1.SelectedItems.Count <= 0)
        return;
      if (Conversions.ToBoolean(NewLateBinding.LateGet(this.ListView1.SelectedItems[0].Tag, (Type) null, "contains", new object[1]
      {
        (object) "hidden"
      }, (string[]) null, (Type[]) null, (bool[]) null)))
        this.ShowAppInLibraryAndProfilesToolStripMenuItem.Visible = true;
      else
        this.ShowAppInLibraryAndProfilesToolStripMenuItem.Visible = false;
    }

    private void Button2_Click(object sender, EventArgs e) => this.SearchForApp();

    private void TextBox1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SearchForApp();
    }

    private void SearchForApp()
    {
      if (this.DotNetBarTabcontrol1.SelectedIndex != 0)
        return;
      ListViewItem itemWithText = this.ListView1.FindItemWithText(this.TextBox1.Text);
      if (itemWithText != null)
      {
        itemWithText.Selected = true;
        this.ListView1.Focus();
        this.ListView1.SelectedItems[0].EnsureVisible();
      }
    }

    private void ToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
      frmCreateEditProfile createEditProfile = new frmCreateEditProfile();
      string str = !this.ListView1.SelectedItems[0].Tag.ToString().Contains("3rdParty") ? strArray[3] : JObject.Parse(System.IO.File.ReadAllText(strArray[2])).SelectToken("launchFile").ToString();
      createEditProfile.TextDisplayName.Text = this.ListView1.SelectedItems[0].Text;
      createEditProfile.ComboSS.Text = "0";
      createEditProfile.ComboASW.Text = "Auto";
      createEditProfile.ComboCPU.Text = "Normal";
      createEditProfile.ComboMethod.Text = "WMI";
      createEditProfile.pLaunchfile = strArray[0].Replace("\\\\", "\\").Replace("/", "\\");
      createEditProfile.pPath = str.Replace("\\\\", "\\").Replace("/", "\\");
      createEditProfile.TextBoxPath.Text = str.Replace("\\\\", "\\").Replace("/", "\\");
      createEditProfile.NumericUpDown1.Value = 5M;
      createEditProfile.NumericUpDown2.Value = 5M;
      createEditProfile.ComboMirror.SelectedIndex = 0;
      createEditProfile.ComboAGPS.SelectedIndex = 1;
      createEditProfile.Button1.Enabled = true;
      int num = (int) createEditProfile.ShowDialog((IWin32Window) this);
      if (createEditProfile.CreateCancel)
        return;
      this.PicturePlay.Visible = false;
      this.PopulateList();
    }

    private void ToolStripMenuItem9_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.ListView1.SelectedItems.Count == 0)
          return;
        if (Globals.dbg)
          Log.WriteToLog("Editing Profile: '" + this.ListView1.SelectedItems[0].Text + "'");
        if (Globals.dbg)
          Log.WriteToLog(Conversions.ToString(Microsoft.VisualBasic.CompilerServices.Operators.ConcatenateObject((object) " Tag: ", this.ListView1.SelectedItems[0].Tag)));
        string[] strArray = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",");
        if (Globals.dbg)
          Log.WriteToLog(" Reading " + strArray[2].Replace("\\\\", "\\").Replace("/", "\\"));
        string str1 = JObject.Parse(System.IO.File.ReadAllText(strArray[2].Replace("\\\\", "\\").Replace("/", "\\"))).SelectToken("launchFile").ToString();
        if (Globals.dbg)
          Log.WriteToLog(" Json Launchfile: " + str1);
        string str2 = strArray[3];
        if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "3rdParty", false) == 0)
          str2 = str1.Replace("\\\\", "\\").Replace("/", "\\");
        if (Globals.dbg)
          Log.WriteToLog(" Path: " + str2);
        if (MyProject.Forms.FrmMain.profilePaths.TryGetValue(str2, out str1))
          str1 = str2;
        string str3 = str1.Replace("\\\\", "\\").Replace("/", "\\");
        if (Globals.dbg)
          Log.WriteToLog(" Launchfile: " + str3);
        frmCreateEditProfile createEditProfile = new frmCreateEditProfile();
        string str4 = "";
        string str5 = "";
        string str6 = "";
        string str7 = "";
        string str8 = "";
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        if (this.ManualStartProfiles.TryGetValue(str3.ToLower(), out str6))
          createEditProfile.ComboSS.Text = str6;
        if (MyProject.Forms.FrmMain.profileASWList.TryGetValue(str3, out str5))
          createEditProfile.ComboASW.Text = str5;
        if (MyProject.Forms.FrmMain.profileDisplayNames.TryGetValue(str3, out str4))
          createEditProfile.TextDisplayName.Text = str4;
        if (MyProject.Forms.FrmMain.profilePriorityList.TryGetValue(str3, out str8))
          createEditProfile.ComboCPU.Text = str8;
        createEditProfile.ComboMethod.Text = !MyProject.Forms.FrmMain.profileTimerList.TryGetValue(str3, out str7) ? "WMI" : "Timer";
        Dictionary<string, string> profileAswDelay = MyProject.Forms.FrmMain.profileAswDelay;
        string key1 = str3;
        string str9 = Conversions.ToString(num1);
        ref string local1 = ref str9;
        int num5 = profileAswDelay.TryGetValue(key1, out local1) ? 1 : 0;
        int integer1 = Conversions.ToInteger(str9);
        if (num5 != 0)
          createEditProfile.NumericUpDown1.Value = new Decimal(integer1);
        Dictionary<string, string> profileCpuDelay = MyProject.Forms.FrmMain.profileCpuDelay;
        string key2 = str3;
        string str10 = Conversions.ToString(num2);
        ref string local2 = ref str10;
        int num6 = profileCpuDelay.TryGetValue(key2, out local2) ? 1 : 0;
        int integer2 = Conversions.ToInteger(str10);
        if (num6 != 0)
          createEditProfile.NumericUpDown2.Value = new Decimal(integer2);
        Dictionary<string, string> profileMirror = MyProject.Forms.FrmMain.profileMirror;
        string lower1 = str3.ToLower();
        str10 = Conversions.ToString(num3);
        ref string local3 = ref str10;
        if (profileMirror.TryGetValue(lower1, out local3))
          createEditProfile.ComboMirror.SelectedIndex = num3;
        Dictionary<string, string> profileAgps = MyProject.Forms.FrmMain.profileAGPS;
        string lower2 = str3.ToLower();
        str10 = Conversions.ToString(num4);
        ref string local4 = ref str10;
        if (profileAgps.TryGetValue(lower2, out local4))
          createEditProfile.ComboAGPS.SelectedIndex = num4;
        createEditProfile.pLaunchfile = Path.GetFileName(str3);
        createEditProfile.pPath = str3;
        createEditProfile.TextBoxPath.Text = str3;
        createEditProfile.Button1.Enabled = true;
        int num7 = (int) createEditProfile.ShowDialog((IWin32Window) this);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("Could not edit profile: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void ContextMenuStrip1_MouseLeave(object sender, EventArgs e)
    {
      this.ContextMenuStrip1.Close();
      this.ListView1.Focus();
    }

    private void Library_ResizeBegin(object sender, EventArgs e)
    {
      this.PicturePlay.Visible = false;
    }

    private void ShowAppInLibraryAndProfilesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OTTDB.UnHideApp(this.ListView1.SelectedItems[0].Text);
      this.ShowToolStripMenuItem.Checked = false;
      this.PopulateList();
    }

    public void ImagelistAddItem(string name, Image img)
    {
      try
      {
        frmLibrary.icons.Images.Add(name, img);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        ProjectData.ClearProjectError();
      }
    }

    private int GetCount(SQLiteConnection sqConnection, string Table)
    {
      return (int) Convert.ToInt16(RuntimeHelpers.GetObjectValue(new SQLiteCommand("SELECT COUNT(*) From " + Table, sqConnection).ExecuteScalar()));
    }

    public void ClearListview(ListView lv)
    {
      if (lv.InvokeRequired)
      {
        frmLibrary.ClearListview_delegate method = new frmLibrary.ClearListview_delegate(this.ClearListview);
        lv.BeginInvoke((Delegate) method, (object) lv);
      }
      else
        lv.Items.Clear();
    }

    private void AddSteamVRToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(MyProject.Forms.FrmMain.steamvr, "", false) == 0)
      {
        int num1 = (int) Interaction.MsgBox((object) "Could not locate Steam VR path", MsgBoxStyle.Critical, (object) "Error");
      }
      else
      {
        string canonicalName = MyProject.Forms.FrmMain.steamvr.Replace(" ", "").Replace("\\", "_").Replace(":", "") + "bin_win32_assets";
        string path = MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Software\\StoreAssets\\" + canonicalName;
        Dictionary<string, string> files1 = new Dictionary<string, string>();
        if (!Directory.Exists(path))
        {
          Log.WriteToLog("Creating " + path);
          Directory.CreateDirectory(path);
        }
        try
        {
          string[] files2 = Directory.GetFiles(this.steam_assets);
          int index = 0;
          while (index < files2.Length)
          {
            string str1 = files2[index];
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(str1), ".bat", false) != 0 & Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(str1), ".exe", false) != 0)
            {
              Log.WriteToLog("Copying " + Path.GetFileName(str1) + " -> " + path);
              System.IO.File.Copy(str1, path + "\\" + Path.GetFileName(str1), true);
              Log.WriteToLog("Generating hash for " + Path.GetFileName(str1));
              string str2 = Conversions.ToString(this.GenerateSHA256Hash(str1));
              files1.Add(Path.GetFileName(str1), str2);
            }
            if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(Path.GetExtension(str1), ".bat", false) == 0)
              System.IO.File.Copy(str1, MyProject.Forms.FrmMain.steamvr + Path.GetFileName(str1), true);
            checked { ++index; }
          }
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToLog("Exception occurred when copying files: " + exception.Message);
          int num2 = (int) Interaction.MsgBox((object) ("Exception occurred when copying files: " + exception.Message));
          ProjectData.ClearProjectError();
          return;
        }
        this.CreateManifest(canonicalName.Replace("_assets", ""), "SteamVR", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.steamvr + "SteamVR.bat", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
        this.CreateAssetManifest(canonicalName, "#060404", files1, "", MyProject.Forms.FrmMain.OculusPath + "\\CoreData\\Manifests");
        this.PopulateList();
        if (Interaction.MsgBox((object) "You need to restart the Oculus Service for SteamVR to be visible in Oculus Home. Restart it now?", MsgBoxStyle.YesNo | MsgBoxStyle.Information, (object) "Restart Required") == MsgBoxResult.Yes)
        {
          MyProject.Forms.FrmMain.StopOVR();
          MyProject.Forms.FrmMain.StartOVR();
        }
      }
    }

    private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.ShowToolStripMenuItem.Checked)
      {
        this.PicturePlay.Visible = false;
        this.isReading = true;
        this.ShowRemoved3rdPartyAppsToolStripMenuItem.Checked = false;
        this.isReading = false;
        this.ListView1.Items.Clear();
        this.imageListLarge.Images.Clear();
        this.imageListLarge.ImageSize = new Size(250, 90);
        this.ListView1.LargeImageList = this.imageListLarge;
        this.ListView1.View = View.LargeIcon;
        try
        {
          foreach (object hiddenApp in (IEnumerable) OTTDB.GetHiddenApps())
          {
            string str = Conversions.ToString(hiddenApp);
            this.imageListLarge.Images.Add(str, (Image) OculusTrayTool.My.Resources.Resources.removed_app);
            this.ListView1.Items.Add(new ListViewItem(str, str)
            {
              Tag = (object) (str + ",hidden")
            });
          }
        }
        finally
        {
          IEnumerator enumerator;
          if (enumerator is IDisposable)
            (enumerator as IDisposable).Dispose();
        }
      }
      else
        this.RefreshLibrary();
    }

    private void AscendingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.AscendingToolStripMenuItem.Checked)
        return;
      this.DescendingToolStripMenuItem.Checked = false;
      this.ListView1.Sorting = this.DotNetBarTabcontrol1.SelectedIndex != 0 ? SortOrder.None : SortOrder.Ascending;
    }

    private void DescendingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!this.DescendingToolStripMenuItem.Checked)
        return;
      this.AscendingToolStripMenuItem.Checked = false;
      this.ListView1.Sorting = this.DotNetBarTabcontrol1.SelectedIndex != 0 ? SortOrder.None : SortOrder.Descending;
    }

    private void RefreshLibraryToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.RefreshLibrary();
    }

    private void RefreshLibrary()
    {
      Log.WriteToLog("Refreshing Library");
      try
      {
        if (this.cnn.State == ConnectionState.Open)
          this.cnn.Close();
        if (System.IO.File.Exists(Application.StartupPath + "\\data.sqlite"))
        {
          System.IO.File.Delete(Application.StartupPath + "\\data.sqlite");
          if (Globals.dbg)
            Log.WriteToLog("Database copy deleted");
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Failed to delete database copy: " + exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Failed to delete database copy: " + exception.Message));
        FrmMain.fmain.AddToListboxAndScroll("Failed to delete database copy: " + exception.Message);
        MyProject.Forms.FrmMain.hasError = true;
        ProjectData.ClearProjectError();
        return;
      }
      if (Globals.dbg)
        Log.WriteToLog("Looking for Oculus database");
      if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite"))
      {
        if (Globals.dbg)
          Log.WriteToLog("Database found, making a copy");
        try
        {
          System.IO.File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Oculus\\sessions\\_oaf\\data.sqlite", Application.StartupPath + "\\data.sqlite", true);
        }
        catch (Exception ex)
        {
          ProjectData.SetProjectError(ex);
          Exception exception = ex;
          Log.WriteToLog("Failed to create database copy: " + exception.Message);
          int num = (int) Interaction.MsgBox((object) ("Failed to create database copy: " + exception.Message), MsgBoxStyle.Critical, (object) "Error copying database");
          FrmMain.fmain.AddToListboxAndScroll("Failed to create database copy: " + exception.Message);
          MyProject.Forms.FrmMain.hasError = true;
          ProjectData.ClearProjectError();
          return;
        }
      }
      this.IconGameList.Clear();
      this.libraryLoaded = false;
      this.LoadLibrary();
    }

    private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(e.Link.LinkData.ToString());
    }

    private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start(e.Link.LinkData.ToString());
    }

    private void ShowIgnoredAppsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) MyProject.Forms.FrmIgnoredApps.ShowDialog((IWin32Window) this);
    }

    private void ToolStripMenuItem6_Click(object sender, EventArgs e)
    {
      if (this.ListView1.SelectedItems.Count <= 0)
        return;
      string str = Strings.Split(Conversions.ToString(this.ListView1.SelectedItems[0].Tag), ",")[2];
      string text = this.ListView1.SelectedItems[0].Text;
      OTTDB.AddIgnoreApp(str);
      OTTDB.RemoveIncludedApp(str);
      MyProject.Forms.FrmMain.ignoredApps = (List<string>) OTTDB.GetIgnoredApps();
      MyProject.Forms.FrmMain.includedApps = (List<string>) OTTDB.GetIncludedApps();
      MyProject.Forms.FrmMain.ignoredApps.Add(str);
      this.PopulateList();
      Log.WriteToLog("'" + text + "' is now being ignored");
      MyProject.Forms.FrmMain.AddToListboxAndScroll("'" + text + "' is now being ignored");
    }

    private void RemoveProfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.DeleteProfile();
    }

    private void DeleteProfile()
    {
      if (this.ListView1.SelectedItems.Count <= 0)
        return;
      ListViewItem selectedItem = this.ListView1.SelectedItems[0];
      string[] strArray = Strings.Split(Conversions.ToString(selectedItem.Tag), ",");
      if (Globals.dbg)
        Log.WriteToLog(" Reading " + strArray[2].Replace("\\\\", "\\").Replace("/", "\\"));
      string str1 = JObject.Parse(System.IO.File.ReadAllText(strArray[2].Replace("\\\\", "\\").Replace("/", "\\"))).SelectToken("launchFile").ToString();
      if (Globals.dbg)
        Log.WriteToLog(" Json Launchfile: " + str1);
      string str2 = strArray[3];
      if (Microsoft.VisualBasic.CompilerServices.Operators.CompareString(str2, "3rdParty", false) == 0)
        str2 = str1.Replace("\\\\", "\\").Replace("/", "\\");
      if (Globals.dbg)
        Log.WriteToLog(" Path: " + str2);
      if (MyProject.Forms.FrmMain.profilePaths.TryGetValue(str2, out str1))
        str1 = str2;
      string Path = str1.Replace("\\\\", "\\").Replace("/", "\\");
      if (Interaction.MsgBox((object) ("Remove profile for '" + selectedItem.Text + "'?"), MsgBoxStyle.YesNo | MsgBoxStyle.Question, (object) "Confirm") == MsgBoxResult.Yes)
      {
        OTTDB.RemoveProfile(Path);
        OTTDB.GetProfiles();
        if (OTTDB.numWMI > 0)
          MyProject.Forms.FrmMain.CreateWatcher();
        if (OTTDB.numTimer > 0)
          MyProject.Forms.FrmMain.pTimer.Start();
      }
      MyProject.Forms.frmCreateEditProfile.ComboBox1.Items.Clear();
      this.PopulateList();
    }

    public delegate void ImagelistAddItem_delegate(string name, Image img);

    public delegate void ListViewAddItemSteam_delegate(string name, string tag);

    public delegate void ClearListview_delegate(ListView lv);

  }
}
