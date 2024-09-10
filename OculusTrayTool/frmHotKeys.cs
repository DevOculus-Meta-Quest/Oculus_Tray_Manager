using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;

namespace OculusTrayTool;

[DesignerGenerated]
public class frmHotKeys : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ListView1")]
	private ListView _ListView1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ComboFunction")]
	private ComboBox _ComboFunction;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ContextMenuStrip1")]
	private ContextMenuStrip _ContextMenuStrip1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DeleteHotKeyToolStripMenuItem")]
	private ToolStripMenuItem _DeleteHotKeyToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CheckBox1")]
	private CheckBox _CheckBox1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button4")]
	private Button _Button4;

	public List<string> KeyList;

	public List<string> FunctionList;

	public Dictionary<int, string> HotKeyList;

	private bool isCapture;

	internal virtual ListView ListView1
	{
		[CompilerGenerated]
		get
		{
			return _ListView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseEventHandler value2 = ListView1_MouseMove;
			MouseEventHandler value3 = ListView1_MouseDown;
			ListView listView = _ListView1;
			if (listView != null)
			{
				listView.MouseMove -= value2;
				listView.MouseDown -= value3;
			}
			_ListView1 = value;
			listView = _ListView1;
			if (listView != null)
			{
				listView.MouseMove += value2;
				listView.MouseDown += value3;
			}
		}
	}

	[field: AccessedThroughProperty("ColumnHeader1")]
	internal virtual ColumnHeader ColumnHeader1
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

	[field: AccessedThroughProperty("GroupBox3")]
	internal virtual GroupBox GroupBox3
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("GroupBox1")]
	internal virtual GroupBox GroupBox1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual ComboBox ComboFunction
	{
		[CompilerGenerated]
		get
		{
			return _ComboFunction;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyPressEventHandler value2 = ComboFunction_KeyPress;
			ComboBox comboFunction = _ComboFunction;
			if (comboFunction != null)
			{
				comboFunction.KeyPress -= value2;
			}
			_ComboFunction = value;
			comboFunction = _ComboFunction;
			if (comboFunction != null)
			{
				comboFunction.KeyPress += value2;
			}
		}
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

	internal virtual ContextMenuStrip ContextMenuStrip1
	{
		[CompilerGenerated]
		get
		{
			return _ContextMenuStrip1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			CancelEventHandler value2 = ContextMenuStrip1_Opening;
			ContextMenuStrip contextMenuStrip = _ContextMenuStrip1;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening -= value2;
			}
			_ContextMenuStrip1 = value;
			contextMenuStrip = _ContextMenuStrip1;
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Opening += value2;
			}
		}
	}

	internal virtual ToolStripMenuItem DeleteHotKeyToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _DeleteHotKeyToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = DeleteHotKeyToolStripMenuItem_Click;
			ToolStripMenuItem deleteHotKeyToolStripMenuItem = _DeleteHotKeyToolStripMenuItem;
			if (deleteHotKeyToolStripMenuItem != null)
			{
				deleteHotKeyToolStripMenuItem.Click -= value2;
			}
			_DeleteHotKeyToolStripMenuItem = value;
			deleteHotKeyToolStripMenuItem = _DeleteHotKeyToolStripMenuItem;
			if (deleteHotKeyToolStripMenuItem != null)
			{
				deleteHotKeyToolStripMenuItem.Click += value2;
			}
		}
	}

	internal virtual CheckBox CheckBox1
	{
		[CompilerGenerated]
		get
		{
			return _CheckBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = CheckBox1_CheckedChanged;
			CheckBox checkBox = _CheckBox1;
			if (checkBox != null)
			{
				checkBox.CheckedChanged -= value2;
			}
			_CheckBox1 = value;
			checkBox = _CheckBox1;
			if (checkBox != null)
			{
				checkBox.CheckedChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("Label1")]
	internal virtual Label Label1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
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

	internal virtual Button Button3
	{
		[CompilerGenerated]
		get
		{
			return _Button3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button3_Click;
			Button button = _Button3;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button3 = value;
			button = _Button3;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ToolTip1")]
	internal virtual ToolTip ToolTip1
	{
		get; [MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	internal virtual Button Button4
	{
		[CompilerGenerated]
		get
		{
			return _Button4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler value2 = Button4_Click;
			Button button = _Button4;
			if (button != null)
			{
				button.Click -= value2;
			}
			_Button4 = value;
			button = _Button4;
			if (button != null)
			{
				button.Click += value2;
			}
		}
	}

	public frmHotKeys()
	{
		base.KeyDown += frmHotKeys_KeyDown;
		KeyList = new List<string>();
		FunctionList = new List<string>();
		HotKeyList = new Dictionary<int, string>();
		isCapture = false;
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OculusTrayTool.frmHotKeys));
		this.ListView1 = new System.Windows.Forms.ListView();
		this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
		this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
		this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.DeleteHotKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Button3 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.ComboFunction = new System.Windows.Forms.ComboBox();
		this.Button1 = new System.Windows.Forms.Button();
		this.CheckBox1 = new System.Windows.Forms.CheckBox();
		this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
		this.Button4 = new System.Windows.Forms.Button();
		this.ContextMenuStrip1.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		base.SuspendLayout();
		this.ListView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.ColumnHeader1, this.ColumnHeader3 });
		this.ListView1.ContextMenuStrip = this.ContextMenuStrip1;
		this.ListView1.FullRowSelect = true;
		this.ListView1.GridLines = true;
		this.ListView1.HideSelection = false;
		this.ListView1.Location = new System.Drawing.Point(13, 154);
		this.ListView1.MultiSelect = false;
		this.ListView1.Name = "ListView1";
		this.ListView1.Size = new System.Drawing.Size(294, 166);
		this.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
		this.ListView1.TabIndex = 12;
		this.ListView1.UseCompatibleStateImageBehavior = false;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ColumnHeader1.Text = "Function";
		this.ColumnHeader1.Width = 121;
		this.ColumnHeader3.Text = "Key";
		this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.DeleteHotKeyToolStripMenuItem });
		this.ContextMenuStrip1.Name = "ContextMenuStrip1";
		this.ContextMenuStrip1.Size = new System.Drawing.Size(150, 26);
		this.DeleteHotKeyToolStripMenuItem.Name = "DeleteHotKeyToolStripMenuItem";
		this.DeleteHotKeyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
		this.DeleteHotKeyToolStripMenuItem.Text = "Delete HotKey";
		this.GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox3.Controls.Add(this.Label1);
		this.GroupBox3.Controls.Add(this.Button3);
		this.GroupBox3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox3.Location = new System.Drawing.Point(12, 70);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(294, 49);
		this.GroupBox3.TabIndex = 11;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Press 'Capture' then a key to bind";
		this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.Label1.Location = new System.Drawing.Point(6, 24);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(221, 18);
		this.Label1.TabIndex = 14;
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button3.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button3.Location = new System.Drawing.Point(233, 19);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(55, 23);
		this.Button3.TabIndex = 16;
		this.Button3.Text = "Capture";
		this.Button3.UseVisualStyleBackColor = true;
		this.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Button2.Enabled = false;
		this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button2.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button2.Location = new System.Drawing.Point(268, 125);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(38, 23);
		this.Button2.TabIndex = 15;
		this.Button2.Text = "Add";
		this.ToolTip1.SetToolTip(this.Button2, "Add selected Function and Key binding");
		this.Button2.UseVisualStyleBackColor = true;
		this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.GroupBox1.Controls.Add(this.ComboFunction);
		this.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.GroupBox1.Location = new System.Drawing.Point(12, 12);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(294, 52);
		this.GroupBox1.TabIndex = 9;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Select Function for the hotkey";
		this.ComboFunction.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.ComboFunction.FormattingEnabled = true;
		this.ComboFunction.Items.AddRange(new object[15]
		{
			"ASW 45", "ASW Auto", "ASW Off", "Close HUD", "Exit running VR app", "HUD Application Render", "HUD ASW Mode", "HUD Compositor Render", "HUD Latency", "HUD Performance",
			"HUD Pixel Density", "Next ASW Mode", "Next HUD", "Previous ASW Mode", "Previous HUD"
		});
		this.ComboFunction.Location = new System.Drawing.Point(6, 19);
		this.ComboFunction.Name = "ComboFunction";
		this.ComboFunction.Size = new System.Drawing.Size(276, 21);
		this.ComboFunction.Sorted = true;
		this.ComboFunction.TabIndex = 0;
		this.Button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
		this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.Button1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button1.Location = new System.Drawing.Point(261, 326);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(45, 23);
		this.Button1.TabIndex = 8;
		this.Button1.Text = "OK";
		this.Button1.UseVisualStyleBackColor = true;
		this.CheckBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.CheckBox1.AutoSize = true;
		this.CheckBox1.ForeColor = System.Drawing.Color.DodgerBlue;
		this.CheckBox1.Location = new System.Drawing.Point(11, 330);
		this.CheckBox1.Name = "CheckBox1";
		this.CheckBox1.Size = new System.Drawing.Size(187, 17);
		this.CheckBox1.TabIndex = 13;
		this.CheckBox1.Text = "Voice Confirmation for ASW Mode";
		this.CheckBox1.UseVisualStyleBackColor = true;
		this.Button4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.Button4.Enabled = false;
		this.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.Button4.ForeColor = System.Drawing.Color.DodgerBlue;
		this.Button4.Location = new System.Drawing.Point(12, 125);
		this.Button4.Name = "Button4";
		this.Button4.Size = new System.Drawing.Size(48, 23);
		this.Button4.TabIndex = 16;
		this.Button4.Text = "Delete";
		this.ToolTip1.SetToolTip(this.Button4, "Add selected Function and Key binding");
		this.Button4.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		base.ClientSize = new System.Drawing.Size(319, 361);
		base.Controls.Add(this.Button4);
		base.Controls.Add(this.Button2);
		base.Controls.Add(this.CheckBox1);
		base.Controls.Add(this.ListView1);
		base.Controls.Add(this.GroupBox3);
		base.Controls.Add(this.GroupBox1);
		base.Controls.Add(this.Button1);
		this.ForeColor = System.Drawing.Color.DodgerBlue;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.KeyPreview = true;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(335, 400);
		base.Name = "frmHotKeys";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "Configure Hot Keys";
		this.ContextMenuStrip1.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		string text = "";
		checked
		{
			int num = ListView1.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				text = text + ListView1.Items[i].Text + "," + ListView1.Items[i].SubItems[1].Text + ";";
			}
			text = text.TrimEnd(';');
			MySettingsProperty.Settings.HotKeyCombos = text;
			MySettingsProperty.Settings.Save();
			GetConfig.GetHotKeys();
			Close();
		}
	}

	private void DeleteHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
	{
		DeleteHotKey();
	}

	private void DeleteHotKey()
	{
		checked
		{
			if (ListView1.SelectedItems.Count > 0)
			{
				ListView1.Items.RemoveAt(ListView1.SelectedIndices[0]);
				KeyList.Clear();
				FunctionList.Clear();
				string text = "";
				int num = ListView1.Items.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					KeyList.Add(ListView1.Items[i].SubItems[1].Text);
					FunctionList.Add(ListView1.Items[i].Text);
					text = text + ListView1.Items[i].Text + "," + ListView1.Items[i].SubItems[1].Text + ";";
				}
				text = text.TrimEnd(';');
				MySettingsProperty.Settings.HotKeyCombos = text;
				MySettingsProperty.Settings.Save();
			}
		}
	}

	private void ListView1_MouseMove(object sender, MouseEventArgs e)
	{
		ListViewItem itemAt = ListView1.GetItemAt(e.X, e.Y);
		foreach (ListViewItem item in ListView1.Items)
		{
			if (itemAt != null)
			{
				itemAt.Selected = true;
			}
			else
			{
				item.Selected = false;
			}
		}
	}

	private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0)
		{
			ContextMenuStrip1.Enabled = true;
		}
		else
		{
			ContextMenuStrip1.Enabled = false;
		}
	}

	private void CheckBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (CheckBox1.Checked)
		{
			MySettingsProperty.Settings.HotKeyVoiceConfirmation = true;
		}
		else
		{
			MySettingsProperty.Settings.HotKeyVoiceConfirmation = false;
		}
		MySettingsProperty.Settings.Save();
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(ComboFunction.Text, "", TextCompare: false) == 0)
		{
			return;
		}
		if (!FunctionList.Contains(ComboFunction.Text))
		{
			if (!KeyList.Contains(Label1.Text))
			{
				KeyList.Add(Label1.Text);
				FunctionList.Add(ComboFunction.Text);
				ListViewItem listViewItem = new ListViewItem();
				listViewItem = ListView1.Items.Add(ComboFunction.Text);
				listViewItem.SubItems.Add(Label1.Text);
			}
			else
			{
				Interaction.MsgBox("The selected key is already bound. You can right-click a keybinding in the list to remove it.", MsgBoxStyle.Exclamation, "Error");
			}
		}
		else
		{
			Interaction.MsgBox("The selected function is already bound. You can right-click a keybinding in the list to remove it.", MsgBoxStyle.Exclamation, "Error");
		}
		isCapture = false;
		Label1.Text = "";
		ComboFunction.Text = "";
		Button3.Enabled = true;
	}

	private void frmHotKeys_KeyDown(object sender, KeyEventArgs e)
	{
		if (isCapture)
		{
			Label1.Text = e.KeyCode.ToString().ToUpper();
			Button3.Enabled = true;
			Button2.Enabled = true;
			isCapture = false;
		}
	}

	private void ComboFunction_KeyPress(object sender, KeyPressEventArgs e)
	{
		e.Handled = true;
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		isCapture = true;
		Button3.Enabled = false;
		Button2.Enabled = false;
		Label1.Text = "Press any key to bind";
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		DeleteHotKey();
		Button4.Enabled = false;
	}

	private void ListView1_MouseDown(object sender, MouseEventArgs e)
	{
		if (ListView1.SelectedItems.Count > 0)
		{
			Button4.Enabled = true;
		}
		else
		{
			Button4.Enabled = false;
		}
	}
}
