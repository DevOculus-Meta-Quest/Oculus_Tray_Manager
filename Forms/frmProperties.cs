

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool.Forms
{

  public partial class frmProperties : Form
  {
    
    public string fname;

    public frmProperties()
    {
      this.Load += this.Properties_Load;
      this.InitializeComponent();
    }

    

    

    


    


    

    

    private void Button2_Click(object sender, EventArgs e) => this.Close();

    private void FormatText(string searchstring, FontStyle style)
    {
      for (int start = this.RichTextBox1.Find(searchstring, 0, RichTextBoxFinds.MatchCase); start != -1; start = this.RichTextBox1.Find(searchstring, checked (start + searchstring.Length), RichTextBoxFinds.MatchCase))
      {
        this.RichTextBox1.Select(start, searchstring.Length);
        this.RichTextBox1.SelectionFont = new Font(this.RichTextBox1.Font, style);
        this.RichTextBox1.SelectionColor = Color.DodgerBlue;
      }
      this.RichTextBox1.Select(0, 0);
    }

    private void Properties_Load(object sender, EventArgs e)
    {
      this.FormatText("displayName", FontStyle.Bold);
      this.FormatText("launchFile", FontStyle.Bold);
      this.FormatText("launchParameters", FontStyle.Bold);
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    private void Button1_Click(object sender, EventArgs e)
    {
      if (this.CheckBox1.Checked)
      {
        string str = ".BKP_" + DateTime.Now.ToString("yyyyMMddHHmmss");
        try 
        {
             File.Copy(this.fname, this.fname + str, true);
             Log.WriteToLog("Backup made: " + this.fname + " -> " + this.fname + str);
        }
        catch (Exception ex)
        {
             Log.WriteToLog("Backup failed: " + ex.Message);
        }
      }
      
      if (!frmProperties.IsValidJson(this.RichTextBox1.Text))
          return;

      if (MessageBox.Show("JSON formatting looks OK, do you want to save this file?", "Meta Quest Tray Tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      using (StreamWriter streamWriter = new StreamWriter(this.fname))
      {
          streamWriter.Write(this.RichTextBox1.Text);
      }
      Log.WriteToLog(this.fname + " was edited");
    }

    private static bool IsValidJson(string strInput)
    {
      strInput = strInput.Trim();
      if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || (strInput.StartsWith("[") && strInput.EndsWith("]")))
      {
        try
        {
          JToken.Parse(strInput);
          return true;
        }
        catch (JsonReaderException ex)
        {
          MessageBox.Show(ex.Message, "JSON validation failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          return false;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString(), "JSON validation failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
          return false;
        }
      }
      return false;
    }
  }
}
