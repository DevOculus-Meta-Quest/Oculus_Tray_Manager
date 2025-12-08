// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmHomeless
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public class frmHomeless : Form
  {
    private IContainer components;

    public frmHomeless() => this.InitializeComponent();

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
      this.GroupBox1 = new GroupBox();
      this.BtnBrowseMusic = new Button();
      this.TextBox1 = new TextBox();
      this.BtnColor = new Button();
      this.ComboMusic = new ComboBox();
      this.NumericVolume = new NumericUpDown();
      this.Label3 = new Label();
      this.Label2 = new Label();
      this.Label1 = new Label();
      this.Button1 = new Button();
      this.Button2 = new Button();
      this.ColorDialog1 = new ColorDialog();
      this.CheckBox1 = new CheckBox();
      this.GroupBox1.SuspendLayout();
      this.NumericVolume.BeginInit();
      this.SuspendLayout();
      this.GroupBox1.Controls.Add((Control) this.CheckBox1);
      this.GroupBox1.Controls.Add((Control) this.BtnBrowseMusic);
      this.GroupBox1.Controls.Add((Control) this.TextBox1);
      this.GroupBox1.Controls.Add((Control) this.BtnColor);
      this.GroupBox1.Controls.Add((Control) this.ComboMusic);
      this.GroupBox1.Controls.Add((Control) this.NumericVolume);
      this.GroupBox1.Controls.Add((Control) this.Label3);
      this.GroupBox1.Controls.Add((Control) this.Label2);
      this.GroupBox1.Controls.Add((Control) this.Label1);
      this.GroupBox1.ForeColor = Color.DodgerBlue;
      this.GroupBox1.Location = new Point(12, 12);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new Size(348, 133);
      this.GroupBox1.TabIndex = 0;
      this.GroupBox1.TabStop = false;
      this.BtnBrowseMusic.FlatStyle = FlatStyle.Flat;
      this.BtnBrowseMusic.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnBrowseMusic.Location = new Point(258, 44);
      this.BtnBrowseMusic.Name = "BtnBrowseMusic";
      this.BtnBrowseMusic.Size = new Size(71, 23);
      this.BtnBrowseMusic.TabIndex = 8;
      this.BtnBrowseMusic.Text = "Add More";
      this.BtnBrowseMusic.UseVisualStyleBackColor = true;
      this.TextBox1.Location = new Point(131, 17);
      this.TextBox1.Name = "TextBox1";
      this.TextBox1.ReadOnly = true;
      this.TextBox1.Size = new Size(121, 20);
      this.TextBox1.TabIndex = 7;
      this.BtnColor.FlatStyle = FlatStyle.Flat;
      this.BtnColor.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.BtnColor.Location = new Point(258, 15);
      this.BtnColor.Name = "BtnColor";
      this.BtnColor.Size = new Size(71, 23);
      this.BtnColor.TabIndex = 6;
      this.BtnColor.Text = "Pick color";
      this.BtnColor.UseVisualStyleBackColor = true;
      this.ComboMusic.BackColor = Color.AliceBlue;
      this.ComboMusic.DropDownStyle = ComboBoxStyle.DropDownList;
      this.ComboMusic.DropDownWidth = 200;
      this.ComboMusic.FlatStyle = FlatStyle.Popup;
      this.ComboMusic.FormattingEnabled = true;
      this.ComboMusic.Items.AddRange(new object[1]
      {
        (object) "None"
      });
      this.ComboMusic.Location = new Point(131, 46);
      this.ComboMusic.Name = "ComboMusic";
      this.ComboMusic.Size = new Size(121, 21);
      this.ComboMusic.Sorted = true;
      this.ComboMusic.TabIndex = 4;
      this.NumericVolume.Location = new Point(132, 79);
      this.NumericVolume.Name = "NumericVolume";
      this.NumericVolume.Size = new Size(120, 20);
      this.NumericVolume.TabIndex = 3;
      this.Label3.AutoSize = true;
      this.Label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label3.Location = new Point(16, 81);
      this.Label3.Name = "Label3";
      this.Label3.Size = new Size(103, 15);
      this.Label3.TabIndex = 2;
      this.Label3.Text = "Music volume %: ";
      this.Label2.AutoSize = true;
      this.Label2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label2.Location = new Point(15, 49);
      this.Label2.Name = "Label2";
      this.Label2.Size = new Size(112, 15);
      this.Label2.TabIndex = 1;
      this.Label2.Text = "Background music:";
      this.Label1.AutoSize = true;
      this.Label1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Label1.Location = new Point(16, 20);
      this.Label1.Name = "Label1";
      this.Label1.Size = new Size(109, 15);
      this.Label1.TabIndex = 0;
      this.Label1.Text = "Background color: ";
      this.Button1.FlatStyle = FlatStyle.Flat;
      this.Button1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button1.ForeColor = Color.DodgerBlue;
      this.Button1.Location = new Point(12, 151);
      this.Button1.Name = "Button1";
      this.Button1.Size = new Size(55, 25);
      this.Button1.TabIndex = 1;
      this.Button1.Text = "Cancel";
      this.Button1.UseVisualStyleBackColor = true;
      this.Button2.FlatStyle = FlatStyle.Flat;
      this.Button2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Button2.ForeColor = Color.DodgerBlue;
      this.Button2.Location = new Point(305, 151);
      this.Button2.Name = "Button2";
      this.Button2.Size = new Size(55, 25);
      this.Button2.TabIndex = 2;
      this.Button2.Text = "OK";
      this.Button2.UseVisualStyleBackColor = true;
      this.ColorDialog1.FullOpen = true;
      this.CheckBox1.AutoSize = true;
      this.CheckBox1.Location = new Point(16, 105);
      this.CheckBox1.Name = "CheckBox1";
      this.CheckBox1.RightToLeft = RightToLeft.Yes;
      this.CheckBox1.Size = new Size(130, 17);
      this.CheckBox1.TabIndex = 9;
      this.CheckBox1.Text = "   :Automatically patch";
      this.CheckBox1.UseVisualStyleBackColor = true;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(368, 183);
      this.ControlBox = false;
      this.Controls.Add((Control) this.Button2);
      this.Controls.Add((Control) this.Button1);
      this.Controls.Add((Control) this.GroupBox1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Name = nameof (frmHomeless);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Configure Oculus Homeless";
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.NumericVolume.EndInit();
      this.ResumeLayout(false);
    }

    [field: AccessedThroughProperty("GroupBox1")]
    internal virtual GroupBox GroupBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual ComboBox ComboMusic
    {
      get => this._ComboMusic;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.ComboMusic_SelectedIndexChanged);
        ComboBox comboMusic1 = this._ComboMusic;
        if (comboMusic1 != null)
          comboMusic1.SelectedIndexChanged -= eventHandler;
        this._ComboMusic = value;
        ComboBox comboMusic2 = this._ComboMusic;
        if (comboMusic2 == null)
          return;
        comboMusic2.SelectedIndexChanged += eventHandler;
      }
    }

    [field: AccessedThroughProperty("NumericVolume")]
    internal virtual NumericUpDown NumericVolume { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label3")]
    internal virtual Label Label3 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label2")]
    internal virtual Label Label2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("Label1")]
    internal virtual Label Label1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button Button1
    {
      get => this._Button1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button1_Click);
        Button button1_1 = this._Button1;
        if (button1_1 != null)
          button1_1.Click -= eventHandler;
        this._Button1 = value;
        Button button1_2 = this._Button1;
        if (button1_2 == null)
          return;
        button1_2.Click += eventHandler;
      }
    }

    internal virtual Button Button2
    {
      get => this._Button2;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button2_Click);
        Button button2_1 = this._Button2;
        if (button2_1 != null)
          button2_1.Click -= eventHandler;
        this._Button2 = value;
        Button button2_2 = this._Button2;
        if (button2_2 == null)
          return;
        button2_2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("ColorDialog1")]
    internal virtual ColorDialog ColorDialog1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button BtnColor
    {
      get => this._BtnColor;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Button3_Click);
        Button btnColor1 = this._BtnColor;
        if (btnColor1 != null)
          btnColor1.Click -= eventHandler;
        this._BtnColor = value;
        Button btnColor2 = this._BtnColor;
        if (btnColor2 == null)
          return;
        btnColor2.Click += eventHandler;
      }
    }

    [field: AccessedThroughProperty("TextBox1")]
    internal virtual TextBox TextBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    internal virtual Button BtnBrowseMusic
    {
      get => this._BtnBrowseMusic;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.BtnBrowseMusic_Click);
        Button btnBrowseMusic1 = this._BtnBrowseMusic;
        if (btnBrowseMusic1 != null)
          btnBrowseMusic1.Click -= eventHandler;
        this._BtnBrowseMusic = value;
        Button btnBrowseMusic2 = this._BtnBrowseMusic;
        if (btnBrowseMusic2 == null)
          return;
        btnBrowseMusic2.Click += eventHandler;
      }
    }

    internal virtual CheckBox CheckBox1
    {
      get => this._CheckBox1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.CheckBox1_CheckedChanged);
        CheckBox checkBox1_1 = this._CheckBox1;
        if (checkBox1_1 != null)
          checkBox1_1.CheckedChanged -= eventHandler;
        this._CheckBox1 = value;
        CheckBox checkBox1_2 = this._CheckBox1;
        if (checkBox1_2 == null)
          return;
        checkBox1_2.CheckedChanged += eventHandler;
      }
    }

    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void Button3_Click(object sender, EventArgs e)
    {
      if (this.ColorDialog1.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.TextBox1.BackColor = this.ColorDialog1.Color;
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      try
      {
        this.Cursor = Cursors.WaitCursor;
        Color backColor = this.TextBox1.BackColor;
        float num1 = (float) Math.Round((double) backColor.R / (double) byte.MaxValue, 2);
        float num2 = (float) Math.Round((double) backColor.G / (double) byte.MaxValue, 2);
        float num3 = (float) Math.Round((double) backColor.B / (double) byte.MaxValue, 2);
        string str = num1.ToString().Replace(",", ".") + " " + num2.ToString().Replace(",", ".") + " " + num3.ToString().Replace(",", ".");
        StreamWriter streamWriter1 = new StreamWriter(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_color.txt");
        streamWriter1.WriteLine(str);
        streamWriter1.Close();
        Log.WriteToLog("Homeless background color set to " + str);
        if (Operators.CompareString(this.ComboMusic.Text, "None", false) != 0)
        {
          if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + this.ComboMusic.Text))
          {
            StreamWriter streamWriter2 = new StreamWriter(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
            streamWriter2.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData).ToString().Replace("\\", "\\\\") + "\\\\OculusTrayTool\\\\Music\\\\" + this.ComboMusic.Text + "," + Conversions.ToString(Decimal.Multiply(this.NumericVolume.Value, 10M)));
            streamWriter2.Close();
            Log.WriteToLog("Homeless background music set to " + this.ComboMusic.Text);
            Log.WriteToLog("Homeless background volume set to " + Conversions.ToString(this.NumericVolume.Value) + "%");
          }
        }
        else if (File.Exists(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt"))
        {
          File.Delete(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\background_music.txt");
          Log.WriteToLog("Homeless background music disabled");
        }
        MySettingsProperty.Settings.HomlessColor = str;
        MySettingsProperty.Settings.HomelessVolume = Convert.ToInt32(Decimal.Multiply(this.NumericVolume.Value, 10M));
        MySettingsProperty.Settings.Save();
        if (Process.GetProcessesByName("OculusClient").Length > 0)
        {
          Process[] processesByName = Process.GetProcessesByName("Home2-Win64-Shipping");
          if (processesByName.Length > 0)
          {
            Log.WriteToLog("Killing Home2-Win64-Shipping.exe");
            Process[] processArray = processesByName;
            int index = 0;
            while (index < processArray.Length)
            {
              Process process = processArray[index];
              process.Kill();
              process.WaitForExit();
              checked { ++index; }
            }
          }
          Thread.Sleep(1000);
          if (Process.GetProcessesByName("Home2-Win64-Shipping").Length == 0)
          {
            Log.WriteToLog("Restarting Home2-Win64-Shipping.exe");
            Process.Start(MyProject.Forms.FrmMain.OculusPath + "Support\\oculus-worlds\\Home2\\Binaries\\Win64\\Home2-Win64-Shipping.exe");
          }
        }
        this.Cursor = Cursors.Default;
        this.Close();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Could save settings: " + exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Could save settings: " + exception.Message), MsgBoxStyle.Critical, (object) "Error saving settings");
        ProjectData.ClearProjectError();
      }
    }

    private void BtnBrowseMusic_Click(object sender, EventArgs e)
    {
      try
      {
        if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
        {
          Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
          Log.WriteToLog("Created " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
        }
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Multiselect = true;
        openFileDialog.Filter = "MP3 Music (*.mp3)|*.mp3";
        if (openFileDialog.ShowDialog() != DialogResult.OK)
          return;
        string text = this.ComboMusic.Text;
        string[] fileNames = openFileDialog.FileNames;
        int index1 = 0;
        while (index1 < fileNames.Length)
        {
          string str = fileNames[index1];
          File.Copy(str, Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music\\" + Path.GetFileName(str).Replace(" ", ""));
          Log.WriteToLog("Copied " + str + " to " + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music");
          checked { ++index1; }
        }
        if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music"))
        {
          this.ComboMusic.Items.Clear();
          string[] files = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\OculusTrayTool\\Music", "*.mp3");
          int index2 = 0;
          while (index2 < files.Length)
          {
            this.ComboMusic.Items.Add((object) Path.GetFileName(files[index2]));
            checked { ++index2; }
          }
        }
        this.ComboMusic.Items.Add((object) "None");
        this.ComboMusic.Text = text;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLog("Could not add music file: " + exception.Message);
        int num = (int) Interaction.MsgBox((object) ("Could not add music file: " + exception.Message), MsgBoxStyle.Critical, (object) "Error adding music");
        ProjectData.ClearProjectError();
      }
    }

    private void ComboMusic_SelectedIndexChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.HomelessMusic = this.ComboMusic.Text;
      MySettingsProperty.Settings.Save();
    }

    private void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
      MySettingsProperty.Settings.HomelessAutoPatch = this.CheckBox1.Checked;
      MySettingsProperty.Settings.Save();
    }
  }
}
