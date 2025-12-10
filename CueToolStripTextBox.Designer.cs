using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Management;

namespace OculusTrayTool
{
    partial class CueToolStripTextBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

protected override void Dispose(bool disposing)
    {
      if (disposing && this.Control != null)
        this.Control.HandleCreated -= new EventHandler(this.OnControlHandleCreated);
      base.Dispose(disposing);
    }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
