// Decompiled with JetBrains decompiler

using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using OculusTrayTool.My;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool
{
  [DesignerGenerated]
  public partial class FrmIgnoredApps : Form
  {
    

    public FrmIgnoredApps()
    {
      this.Load += new EventHandler(this.FrmIgnoredApps_Load);
      this.InitializeComponent();
    }

    

    

    

    

    







    private void Button1_Click(object sender, EventArgs e) => this.Close();

    private void Button2_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem checkedItem in this.ListView1.CheckedItems)
        {
          OTTDB.RemoveIgnoredApp(Conversions.ToString(checkedItem.Tag));
          OTTDB.AddIncludedApp(Conversions.ToString(checkedItem.Tag));
          Log.WriteToLog("'" + checkedItem.Text + "' is not being ignored anymore");
          MyProject.Forms.FrmMain.AddToListboxAndScroll("'" + checkedItem.Text + "' is not being ignored anymore");
        }
      this.Cursor = Cursors.WaitCursor;
      this.GetIgnoredApps();
      MyProject.Forms.FrmMain.ignoredApps = (List<string>) OTTDB.GetIgnoredApps();
      MyProject.Forms.FrmMain.includedApps = (List<string>) OTTDB.GetIncludedApps();
      MyProject.Forms.frmLibrary.PopulateList();
      this.Cursor = Cursors.Default;
      this.Close();
    }

    private void FrmIgnoredApps_Load(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      frmLibrary.SetDoubleBuffering((Control) this.ListView1, true);
      this.GetIgnoredApps();
      this.Cursor = Cursors.Default;
    }

    private void GetIgnoredApps()
    {
      this.ListView1.Items.Clear();
      List<string> ignoredApps = (List<string>) OTTDB.GetIgnoredApps();

        foreach (string path in ignoredApps)
        {
          if (File.Exists(path))
          {
            JObject jobject = JObject.Parse(File.ReadAllText(path));
            jobject.SelectToken("canonicalName").ToString();
            string text = "";
            string str1 = "";
            string str2 = "";
            List<JToken> list = jobject.Children().ToList<JToken>();

              foreach (JProperty jproperty in list)
              {
                jproperty.CreateReader();
                string name = jproperty.Name;
                if (Operators.CompareString(name, "displayName", false) != 0)
                {
                  if (Operators.CompareString(name, "launchFile", false) != 0)
                  {
                    if (Operators.CompareString(name, "launchParameters", false) == 0)
                      str2 = jproperty.Value.ToString();
                  }
                  else
                  {
                    string fileName = Path.GetFileName(jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\"));
                    str1 = jproperty.Value.ToString().Replace("\\\\", "\\").Replace("/", "\\");
                    if (text.ToLower().EndsWith(".exe") | Operators.CompareString(text.ToLower(), "unknown app", false) == 0)
                      text = Path.GetFileNameWithoutExtension(fileName);
                  }
                }
                else
                  text = jproperty.Value.ToString();
              }

            this.ListView1.Items.Add(new ListViewItem(text)
            {
              SubItems = {
                str2,
                str1
              },
              Tag = (object) path
            });
          }
        }
    }
  }
}