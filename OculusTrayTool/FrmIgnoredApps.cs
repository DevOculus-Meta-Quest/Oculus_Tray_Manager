using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;

namespace OculusTrayTool;

[DesignerGenerated]
public class FrmIgnoredApps : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ListView1")]
	internal virtual ListView ListView1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ColumnHeader1")]
	internal virtual ColumnHeader ColumnHeader1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ColumnHeader2")]
	internal virtual ColumnHeader ColumnHeader2
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ColumnHeader3")]
	internal virtual ColumnHeader ColumnHeader3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button1
	{
		[CompilerGenerated]
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button1_Click;
			Button button = _Button1;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button1 = value;
			button = _Button1;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	internal virtual Button Button2
	{
		[CompilerGenerated]
		get
		{
			return _Button2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button2_Click;
			Button button = _Button2;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button2 = value;
			button = _Button2;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	public FrmIgnoredApps()
	{
		base.Load += FrmIgnoredApps_Load;
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.FrmIgnoredApps));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ListView1 = new System.Windows.Forms.ListView();
		this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		base.SuspendLayout();
		this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox1.Controls.Add(this.ListView1);
		this.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(839, 377);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Ignored Apps - Select to include";
		this.ListView1.CheckBoxes = true;
		this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3] { this.ColumnHeader1, this.ColumnHeader2, this.ColumnHeader3 });
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.ListView1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		this.ListView1.Location = new System.Drawing.Point(3, 16);
		this.ListView1.Name = "ListView1";
		this.ListView1.Size = new System.Drawing.Size(833, 358);
		this.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
		this.ListView1.TabIndex = 0;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ColumnHeader1.Text = "Name";
		this.ColumnHeader1.Width = 158;
		this.ColumnHeader2.Text = "Launch Parameters";
		this.ColumnHeader2.Width = 254;
		this.ColumnHeader3.Text = "Path";
		this.ColumnHeader3.Width = 414;
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(773, 395);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(75, 23);
		this.Button1.TabIndex = 1;
		this.Button1.Text = "Close";
		this.Button1.UseVisualStyleBackColor = true;
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(15, 395);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(107, 23);
		this.Button2.TabIndex = 2;
		this.Button2.Text = "Include Selected";
		this.Button2.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(863, 430);
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.Button1);
		base.Controls.Add(this.GroupBox1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.Name = "FrmIgnoredApps";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Ignored Apps";
		this.GroupBox1.ResumeLayout(false);
		base.ResumeLayout(false);
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		foreach (ListViewItem checkedItem in ListView1.CheckedItems)
		{
			OTTDB.RemoveIgnoredApp(Conversions.ToString(checkedItem.Tag));
			OTTDB.AddIncludedApp(Conversions.ToString(checkedItem.Tag));
			Log.WriteToLog("'" + checkedItem.Text + "' is not being ignored anymore");
			MyProject.Forms.FrmMain.AddToListboxAndScroll("'" + checkedItem.Text + "' is not being ignored anymore");
		}
		Cursor = Cursors.WaitCursor;
		GetIgnoredApps();
		MyProject.Forms.FrmMain.ignoredApps = (List<string>)OTTDB.GetIgnoredApps();
		MyProject.Forms.FrmMain.includedApps = (List<string>)OTTDB.GetIncludedApps();
		MyProject.Forms.frmLibrary.PopulateList();
		Cursor = Cursors.Default;
		Close();
	}

	private void FrmIgnoredApps_Load(object sender, EventArgs e)
	{
		Cursor = Cursors.WaitCursor;
		frmLibrary.SetDoubleBuffering(ListView1, value: true);
		GetIgnoredApps();
		Cursor = Cursors.Default;
	}

	private void GetIgnoredApps()
	{
		ListView1.Items.Clear();
		List<string> list = (List<string>)OTTDB.GetIgnoredApps();
		foreach (string item in list)
		{
			if (!File.Exists(item))
			{
				continue;
			}
			string json = File.ReadAllText(item);
			JObject jObject = JObject.Parse(json);
			string text = jObject.SelectToken("canonicalName").ToString();
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			List<JToken> list2 = jObject.Children().ToList();
			foreach (JProperty item2 in list2)
			{
				item2.CreateReader();
				switch (item2.Name)
				{
				case "displayName":
					text2 = item2.Value.ToString();
					break;
				case "launchFile":
					text3 = Path.GetFileName(item2.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
					text4 = item2.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
					if (text2.ToLower().EndsWith(".exe") | (Operators.CompareString(text2.ToLower(), "unknown app", TextCompare: false) == 0))
					{
						text2 = Path.GetFileNameWithoutExtension(text3);
					}
					break;
				case "launchParameters":
					text5 = item2.Value.ToString();
					break;
				}
			}
			ListViewItem listViewItem = new ListViewItem(text2);
			listViewItem.SubItems.Add(text5);
			listViewItem.SubItems.Add(text4);
			listViewItem.Tag = item;
			ListView1.Items.Add(listViewItem);
		}
	}
}
