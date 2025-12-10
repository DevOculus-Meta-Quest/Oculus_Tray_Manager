// Decompiled with JetBrains decompiler

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class frmEditVoiceCommand : Form
  {
    

    public frmEditVoiceCommand() => this.InitializeComponent();

    

    

    

    

    

    

    







    private void Button2_Click(object sender, EventArgs e) => this.Close();

    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.TextBoxPhrase.Text.EndsWith(";"))
        this.TextBoxPhrase.Text = this.TextBoxPhrase.Text.TrimEnd(';');
      this.TextBoxPhrase.Text = this.TextBoxPhrase.Text.Replace(";;", ";");
      if (Operators.CompareString(this.LabelAction.Text, "Enable Voice Control", false) == 0)
        MySettingsProperty.Settings.StartVoice = this.TextBoxPhrase.Text;
      if (Operators.CompareString(this.LabelAction.Text, "Disable Voice Control", false) == 0)
        MySettingsProperty.Settings.StopVoice = this.TextBoxPhrase.Text;
      if (Operators.CompareString(this.LabelAction.Text, "Set Pixel Density", false) == 0)
      {
        MySettingsProperty.Settings.SetPD = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.SetPDEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Disable ASW", false) == 0)
      {
        MySettingsProperty.Settings.DisableASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.DisableASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Enable ASW", false) == 0)
      {
        MySettingsProperty.Settings.EnableASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.EnableASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "45 fps, ASW On", false) == 0)
      {
        MySettingsProperty.Settings.LockASWOn = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.LockASWOnEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show ASW Status", false) == 0)
      {
        MySettingsProperty.Settings.ShowASW = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowASWEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Pixel Density", false) == 0)
      {
        MySettingsProperty.Settings.ShowPD = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowPDEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Performance", false) == 0)
      {
        MySettingsProperty.Settings.ShowPerf = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowPerfEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Latency Timing", false) == 0)
      {
        MySettingsProperty.Settings.ShowLatency = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowLatencyEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Application Render Timing", false) == 0)
      {
        MySettingsProperty.Settings.ShowApplicationRender = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowApplicationRenderEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Compositor Render Timing", false) == 0)
      {
        MySettingsProperty.Settings.ShowCompositorRender = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowCompositorRenderEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Show Version Info", false) == 0)
      {
        MySettingsProperty.Settings.ShowVersion = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.ShowVersionEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Close Overlay", false) == 0)
      {
        MySettingsProperty.Settings.Close = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.CloseEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      if (Operators.CompareString(this.LabelAction.Text, "Launch SteamVR", false) == 0)
      {
        MySettingsProperty.Settings.LaunchSteam = this.TextBoxPhrase.Text;
        MySettingsProperty.Settings.LaunchSteamEnabled = Conversions.ToBoolean(this.ComboEnabled.Text);
      }
      MySettingsProperty.Settings.Save();
      MyProject.Forms.FrmMain.LoadVoiceSettings();
      MyProject.Forms.frmVoiceSettings.VoicechangeMade = true;
      this.Close();
    }
  }
}