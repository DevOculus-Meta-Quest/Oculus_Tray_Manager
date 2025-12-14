

using MetaQuestTrayTool.My;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool.Forms
{

  public partial class frmEditAllSelected : Form
  {
    

    public frmEditAllSelected() => this.InitializeComponent();

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    


    

    



    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    private void Button2_Click(object sender, EventArgs e) => this.Close();

    private void Button1_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      try
      {
        foreach (ListViewItem checkedItem in MyProject.Forms.frmProfiles.ListView1.CheckedItems)
          {
            string[] strArray = Convert.ToString(checkedItem.Tag).Split(',');
            string str1 = strArray[0];
            string text1 = strArray[1];
            string text2 = strArray[2];
            string text3 = strArray[4];
            string text4 = strArray[3];
            string path1 = strArray[5];
            string str2 = strArray[6];
            string str3 = strArray[7];
            string Left1 = strArray[8];
            if (String.Equals(Left1, "Default", StringComparison.OrdinalIgnoreCase))
              Left1 = "0";
            if (String.Equals(Left1, "Minimized", StringComparison.OrdinalIgnoreCase))
              Left1 = "1";
            if (String.Equals(Left1, "Forced", StringComparison.OrdinalIgnoreCase))
              Left1 = "2";
            string Left2 = strArray[9];
            if (String.Equals(Left2, "On", StringComparison.OrdinalIgnoreCase))
              Left2 = Convert.ToString(1);
            if (String.Equals(Left2, "Off", StringComparison.OrdinalIgnoreCase))
              Left2 = Convert.ToString(0);
            string text5 = strArray[10];
            string str4 = strArray[11];
            string str5 = strArray[12];
            string str6 = strArray[13];
            string str7 = strArray[14];
            if (!String.Equals(this.ComboSS.Text, "", StringComparison.Ordinal))
              text1 = this.ComboSS.Text;
            if (!String.Equals(this.ComboASW.Text, "", StringComparison.Ordinal))
              text2 = this.ComboASW.Text;
            Decimal num;
            if (!String.Equals(this.NumericUpDown1.Text, "", StringComparison.Ordinal))
            {
              num = this.NumericUpDown1.Value;
              str2 = num.ToString();
            }
            if (!String.Equals(this.ComboCPU.Text, "", StringComparison.Ordinal))
              text3 = this.ComboCPU.Text;
            if (!String.Equals(this.NumericUpDown2.Text, "", StringComparison.Ordinal))
            {
              num = this.NumericUpDown2.Value;
              str3 = num.ToString();
            }
            if (!String.Equals(this.ComboMethod.Text, "", StringComparison.Ordinal))
              text4 = this.ComboMethod.Text;
            int selectedIndex;
            if (!String.Equals(this.ComboMirror.Text, "", StringComparison.Ordinal))
            {
              selectedIndex = this.ComboMirror.SelectedIndex;
              Left1 = selectedIndex.ToString();
            }
            if (!String.Equals(this.ComboAGPS.Text, "", StringComparison.Ordinal))
            {
              selectedIndex = this.ComboAGPS.SelectedIndex;
              Left2 = selectedIndex.ToString();
            }
            if (!String.Equals(this.TextBoxComment.Text, "", StringComparison.Ordinal))
              text5 = this.TextBoxComment.Text;
            string displayname = str1;
            string asw = text2;
            string ppdp = text1;
            string priority = text3;
            string fileName = Path.GetFileName(path1);
            string path2 = path1;
            string method = text4;
            string aswdelay = str2;
            string cpudelay = str3;
            string mirror = Left1;
            string agps = Left2;
            string comment = text5;
            num = this.NumericUpDown3.Value;
            string str8 = num.ToString();
            num = this.NumericUpDown4.Value;
            string str9 = num.ToString();
            string fov = str8 + " " + str9;
            string text6 = this.ComboBox8.Text;
            string text7 = this.ComboBox9.Text;
            string text8 = this.ComboBoxEnabled.Text;
            MQTTDB.AddProfile(displayname, asw, ppdp, priority, fileName, path2, method, aswdelay, cpudelay, mirror, agps, comment, fov, text6, text7, text8);
          }
        MQTTDB.GetProfiles();
      }
      catch (Exception ex)
      {
        Log.WriteToLog("Update all selected profiles: " + ex.Message);
      }
      this.Cursor = Cursors.Default;
      this.Close();
    }

    private void ComboSS_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
      {
          e.Handled = true;
      }
      if ((e.KeyChar == '.') && ((sender as ComboBox).Text.IndexOf('.') > -1))
      {
          e.Handled = true;
      }
    }
  }
}
