using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace MetaQuestTrayTool
{
    partial class CueToolStripTextBox
    {
        private System.ComponentModel.IContainer components = null;

protected override void Dispose(bool disposing)
    {
      if (disposing && this.Control != null)
        this.Control.HandleCreated -= new EventHandler(this.OnControlHandleCreated);
      base.Dispose(disposing);
    }

        #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      this.components = (IContainer) null;
      this.m_cueText = string.Empty;
      this.m_showCueTextWithFocus = false;
      if (this.Control == null)
        return;
      this.Control.HandleCreated += new EventHandler(this.OnControlHandleCreated);
    
    }

        #endregion

    
    }
}
