// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmHotKeys
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmHotKeys : Form
  {
    
    public List<string> KeyList;
    public List<string> FunctionList;
    public Dictionary<int, string> HotKeyList;
    private bool isCapture;

    public frmHotKeys()
    {
      this.KeyDown += new KeyEventHandler(this.frmHotKeys_KeyDown);
      this.KeyList = new List<string>();
      this.FunctionList = new List<string>();
      this.HotKeyList = new Dictionary<int, string>();
      this.isCapture = false;
      this.InitializeComponent();
    }

    

    

    

    






    



    


    private void Button1_Click(object sender, EventArgs e)
    {
      MessageBox.Show("HotKeys OK Clicked");
      string str = "";
      int num = checked (this.ListView1.Items.Count - 1);
      int index = 0;
      while (index <= num)
      {
        str = str + this.ListView1.Items[index].Text + "," + this.ListView1.Items[index].SubItems[1].Text + ";";
        checked { ++index; }
      }
      MySettingsProperty.Settings.HotKeyCombos = str.TrimEnd(';');
      MySettingsProperty.Settings.Save();
      GetConfig.GetHotKeys();
      this.Close();
    }

    private void DeleteHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.DeleteHotKey();
    }

    private void DeleteHotKey()
    {
      if (this.ListView1.SelectedItems.Count <= 0)
        return;
      this.ListView1.Items.RemoveAt(this.ListView1.SelectedIndices[0]);
      this.KeyList.Clear();
      this.FunctionList.Clear();
      string str = "";
      int num = checked (this.ListView1.Items.Count - 1);
      int index = 0;
      while (index <= num)
      {
        this.KeyList.Add(this.ListView1.Items[index].SubItems[1].Text);
        this.FunctionList.Add(this.ListView1.Items[index].Text);
        str = str + this.ListView1.Items[index].Text + "," + this.ListView1.Items[index].SubItems[1].Text + ";";
        checked { ++index; }
      }
      MySettingsProperty.Settings.HotKeyCombos = str.TrimEnd(';');
      MySettingsProperty.Settings.Save();
    }

    private void ListView1_MouseMove(object sender, MouseEventArgs e)
    {
      ListViewItem itemAt = this.ListView1.GetItemAt(e.X, e.Y);
      foreach (ListViewItem listViewItem in this.ListView1.Items)
      {
        if (itemAt != null)
          itemAt.Selected = true;
        else
          listViewItem.Selected = false;
      }
    }

    private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count > 0)
        this.ContextMenuStrip1.Enabled = true;
      else
        this.ContextMenuStrip1.Enabled = false;
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.HotKeyVoiceConfirmation = this.CheckBox1.Checked;
      MySettingsProperty.Settings.Save();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      if (Operators.CompareString(this.ComboFunction.Text, "", false) == 0)
        return;
      if (!this.FunctionList.Contains(this.ComboFunction.Text))
      {
        if (!this.KeyList.Contains(this.Label1.Text))
        {
          this.KeyList.Add(this.Label1.Text);
          this.FunctionList.Add(this.ComboFunction.Text);
          ListViewItem listViewItem = new ListViewItem();
          this.ListView1.Items.Add(this.ComboFunction.Text).SubItems.Add(this.Label1.Text);
        }
        else
        {
          int num1 = (int) Interaction.MsgBox((object) "The selected key is already bound. You can right-click a keybinding in the list to remove it.", MsgBoxStyle.Exclamation, (object) "Error");
        }
      }
      else
      {
        int num2 = (int) Interaction.MsgBox((object) "The selected function is already bound. You can right-click a keybinding in the list to remove it.", MsgBoxStyle.Exclamation, (object) "Error");
      }
      this.isCapture = false;
      this.Label1.Text = "";
      this.ComboFunction.Text = "";
      this.Button3.Enabled = true;
    }

    private void frmHotKeys_KeyDown(object sender, KeyEventArgs e)
    {
      if (!this.isCapture)
        return;
      this.Label1.Text = e.KeyCode.ToString().ToUpper();
      this.Button3.Enabled = true;
      this.Button2.Enabled = true;
      this.isCapture = false;
    }

    private void ComboFunction_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;

    private void Button3_Click(object sender, EventArgs e)
    {
      this.isCapture = true;
      this.Button3.Enabled = false;
      this.Button2.Enabled = false;
      this.Label1.Text = "Press any key to bind";
    }

    private void Button4_Click(object sender, EventArgs e)
    {
      this.DeleteHotKey();
      this.Button4.Enabled = false;
    }

    private void ListView1_MouseDown(object sender, MouseEventArgs e)
    {
      if (this.ListView1.SelectedItems.Count > 0)
        this.Button4.Enabled = true;
      else
        this.Button4.Enabled = false;
    }
  }
}