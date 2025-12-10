
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
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
            string[] strArray = Strings.Split(Conversions.ToString(checkedItem.Tag), ",");
            string str1 = strArray[0];
            string text1 = strArray[1];
            string text2 = strArray[2];
            string text3 = strArray[4];
            string text4 = strArray[3];
            string path1 = strArray[5];
            string str2 = strArray[6];
            string str3 = strArray[7];
            string Left1 = strArray[8];
            if (Operators.CompareString(Left1, "Default", false) == 0)
              Left1 = "0";
            if (Operators.CompareString(Left1, "Minimized", false) == 0)
              Left1 = "1";
            if (Operators.CompareString(Left1, "Forced", false) == 0)
              Left1 = "2";
            string Left2 = strArray[9];
            if (Operators.CompareString(Left2, "On", false) == 0)
              Left2 = Conversions.ToString(1);
            if (Operators.CompareString(Left2, "Off", false) == 0)
              Left2 = Conversions.ToString(0);
            string text5 = strArray[10];
            string str4 = strArray[11];
            string str5 = strArray[12];
            string str6 = strArray[13];
            string str7 = strArray[14];
            if (Operators.CompareString(this.ComboSS.Text, "", false) != 0)
              text1 = this.ComboSS.Text;
            if (Operators.CompareString(this.ComboASW.Text, "", false) != 0)
              text2 = this.ComboASW.Text;
            Decimal num;
            if (Operators.CompareString(this.NumericUpDown1.Text, "", false) != 0)
            {
              num = this.NumericUpDown1.Value;
              str2 = num.ToString();
            }
            if (Operators.CompareString(this.ComboCPU.Text, "", false) != 0)
              text3 = this.ComboCPU.Text;
            if (Operators.CompareString(this.NumericUpDown2.Text, "", false) != 0)
            {
              num = this.NumericUpDown2.Value;
              str3 = num.ToString();
            }
            if (Operators.CompareString(this.ComboMethod.Text, "", false) != 0)
              text4 = this.ComboMethod.Text;
            int selectedIndex;
            if (Operators.CompareString(this.ComboMirror.Text, "", false) != 0)
            {
              selectedIndex = this.ComboMirror.SelectedIndex;
              Left1 = selectedIndex.ToString();
            }
            if (Operators.CompareString(this.ComboAGPS.Text, "", false) != 0)
            {
              selectedIndex = this.ComboAGPS.SelectedIndex;
              Left2 = selectedIndex.ToString();
            }
            if (Operators.CompareString(this.TextBoxComment.Text, "", false) != 0)
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
            OTTDB.AddProfile(displayname, asw, ppdp, priority, fileName, path2, method, aswdelay, cpudelay, mirror, agps, comment, fov, text6, text7, text8);
          }
        OTTDB.GetProfiles();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("Update all selected profiles: " + ex.Message);
        ProjectData.ClearProjectError();
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