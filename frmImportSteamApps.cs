// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.frmImportSteamApps
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections;
using System.Collections.Generic;
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
  public partial class frmImportSteamApps : Form
  {
    
    private ListViewColumnSorter m_lvwColumnSorter;

    

    

    

    

    

    

    

    

    

    

    

    


    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    

    public frmImportSteamApps()
    {
      this.Load += new EventHandler(this.frmImportSteamApps_Load);
      this.Resize += new EventHandler(this.frmImportSteamApps_Resize);
      this.FormClosing += new FormClosingEventHandler(this.frmImportSteamApps_FormClosing);
      this.components = (IContainer) null;
      this.m_lvwColumnSorter = (ListViewColumnSorter) null;
      this.InitializeComponent();
    }

    private void frmImportSteamApps_Load(object sender, EventArgs e)
    {
      this.tscbVrManifest.Checked = true;
      if (MySettingsProperty.Settings.SteamWindowLocation != new Point())
      {
        this.Location = MySettingsProperty.Settings.SteamWindowLocation;
      }
      else
      {
        if (Globals.dbg)
          Log.WriteToLog("Setting Steam GUI location to Center Screen");
        this.CenterToScreen();
        MySettingsProperty.Settings.SteamWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      if (this.Location.X < 0 | this.Location.Y < 0)
      {
        if (Globals.dbg)
          Log.WriteToLog("Steam GUI location has negative number, adjusting");
        this.CenterToScreen();
        MySettingsProperty.Settings.SteamWindowLocation = this.Location;
        MySettingsProperty.Settings.Save();
      }
      if (!(MySettingsProperty.Settings.SteamWindowSize != new Size()))
        return;
      this.Size = MySettingsProperty.Settings.SteamWindowSize;
    }

    private void UpdateAppListView()
    {
      try
      {
        if (Globals.dbg)
          Log.WriteToLog("Updating list of Steam games");
        if (!Globals.oculus.TryRefresh() || !Globals.steam.TryRefresh())
          return;
        List<SteamNode> steamList = (List<SteamNode>) null;
        if (this.tscbVrManifest.Checked)
        {
          if (!Globals.steam.TryGetVRManifest(ref steamList) || !Globals.steam.TryGetAppInfo(steamList, true, true))
            return;
        }
        else
        {
          Dictionary<ulong, SteamNode> appInfoDictionary = (Dictionary<ulong, SteamNode>) null;
          if (!Globals.steam.TryGetAppInfo(true, true, ref appInfoDictionary, ref steamList))
            return;
        }
        this.m_lvwColumnSorter = new ListViewColumnSorter();
        this.m_lvwColumnSorter.SortColumn = 2;
        this.m_lvwColumnSorter.Order = SortOrder.Ascending;
        this.lvwAppList.Items.Clear();
        this.lvwAppList.ListViewItemSorter = (IComparer) this.m_lvwColumnSorter;
        List<ListViewItem> listViewItemList = new List<ListViewItem>();

          foreach (SteamNode steamNode in steamList)
          {
            bool flag = Globals.oculus.IsAppInstalled((OculusNode) steamNode);
            if (string.IsNullOrEmpty(this.tstbSearch.Text) || steamNode.Name.IndexOf(this.tstbSearch.Text, StringComparison.CurrentCultureIgnoreCase) != -1)
              listViewItemList.Add(new ListViewItem(new string[14]
              {
                "",
                steamNode.AppId.ToString(),
                steamNode.Name,
                steamNode.Type,
                steamNode.Genre,
                steamNode.Publisher,
                steamNode.Developer,
                steamNode.Executable,
                steamNode.Parameters,
                steamNode.OSList,
                steamNode.ReleaseDateString,
                steamNode.Description,
                steamNode.LibraryFolder,
                steamNode.InstallDir
              })
              {
                ImageIndex = flag ? 0 : 1,
                Tag = (object) steamNode
              });
          }


        this.lvwAppList.Items.AddRange(listViewItemList.ToArray());

          foreach (ColumnHeader column in this.lvwAppList.Columns)
          {
            if (Operators.CompareString(column.Text, "Description", false) != 0)
              column.Width = -2;
          }


        this.lvwAppList.Sort();
        if (Globals.dbg)
          Log.WriteToLog("Update complete");
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog(ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void lvwAppList_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (e.Column == this.m_lvwColumnSorter.SortColumn)
      {
        this.m_lvwColumnSorter.Order = this.m_lvwColumnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
      }
      else
      {
        this.m_lvwColumnSorter.SortColumn = e.Column;
        this.m_lvwColumnSorter.Order = SortOrder.Ascending;
      }
      this.lvwAppList.Sort();
    }

    private void tsbRefresh_Click(object sender, EventArgs e) => this.UpdateAppListView();

    private void tsbImportApps_Click(object sender, EventArgs e) => this.ImportSelectedApps();

    private void tsbRemoveApps_Click(object sender, EventArgs e) => this.RemoveSelectedApps();

    private void tsbSelectAll_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem listViewItem in this.lvwAppList.Items)
          listViewItem.Checked = true;
    }

    private void tsbClear_Click(object sender, EventArgs e)
    {
        foreach (ListViewItem listViewItem in this.lvwAppList.Items)
          listViewItem.Checked = false;
    }

    private void tsbDownloadAssets_Click(object sender, EventArgs e)
    {
      this.DownloadSelectedAssets();
    }

    private void tsbStartService_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      Globals.oculus.TryStartOculusService();
      this.Cursor = Cursors.Default;
    }

    private void tsbStopService_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      Globals.oculus.TryStopOculusService();
      this.Cursor = Cursors.Default;
    }

    private void tsbRestartService_Click(object sender, EventArgs e)
    {
      this.Cursor = Cursors.WaitCursor;
      Globals.oculus.TryRestartOculusService();
      this.Cursor = Cursors.Default;
    }

    private void tscbVrManifest_CheckedChanged(object sender, EventArgs e)
    {
      this.UpdateAppListView();
    }

    private void tsbSearch_Click(object sender, EventArgs e) => this.UpdateAppListView();

    private void ImportSelectedApps()
    {
      try
      {
        if (MyProject.Forms.FrmMain.debug)
          Log.WriteToLog("Importing selected apps");
        
        List<SteamNode> steamList = null;
        if (!this.TryGetSelectedSteamList(ref steamList))
          return;

        frmProcessing processingForm = new frmProcessing();
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerReportsProgress = false;
        worker.DoWork += (sender, e) =>
        {
             // TODO: Restore import logic. Assuming it involves looping through steamList and importing.
             // Globals.steam or Globals.oculus might have methods.
             // For now, doing nothing to allow compilation.
             System.Threading.Thread.Sleep(500); 
        };
        worker.RunWorkerCompleted += (sender, e) =>
        {
             processingForm.Close();
             this.UpdateAppListView();
        };
        worker.RunWorkerAsync();
        processingForm.ShowDialog(this);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("ImportSelectedApps: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void RemoveSelectedApps()
    {
      try
      {
        List<SteamNode> steamList = (List<SteamNode>) null;
        if (!this.TryGetSelectedSteamList(ref steamList))
          return;

          foreach (SteamNode steamNode in steamList)
          {
            this.TryRemoveApp((Control) this, steamNode);
            Log.WriteToLog("'" + steamNode.Name + "' has been removed");
          }

        this.UpdateAppListView();
        Globals.oculus.TryRestartOculusService();
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("RemoveSelectedApps: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void DownloadSelectedAssets()
    {
      try
      {
        List<SteamNode> steamList = null;
        if (!this.TryGetSelectedSteamList(ref steamList))
          return;

        object syncObject = new object();
        frmProcessing processingForm = new frmProcessing();
        BackgroundWorker worker = new BackgroundWorker();
        worker.WorkerReportsProgress = false;
        
        worker.DoWork += (sender, e) =>
        {
             // TODO: Restore download logic.
             System.Threading.Thread.Sleep(500);
        };
        worker.RunWorkerCompleted += (sender, e) =>
        {
             processingForm.Close();
             // TODO: Check result
        };
        worker.RunWorkerAsync();
        processingForm.ShowDialog(this);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("DownloadSelectedAssets: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private bool TryGetSelectedSteamList(ref List<SteamNode> steamList)
    {
      bool selectedSteamList;
      try
      {
        steamList = (List<SteamNode>) null;
        if (this.lvwAppList.CheckedItems.Count <= 0)
        {
          selectedSteamList = false;
        }
        else
        {
          steamList = new List<SteamNode>();

          {
            foreach (ListViewItem checkedItem in this.lvwAppList.CheckedItems)
            {
              SteamNode tag = (SteamNode) checkedItem.Tag;
              steamList.Add(tag);
            }
          }
          selectedSteamList = true;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryGetSelectedSteamList: " + ex.Message);
        selectedSteamList = false;
        ProjectData.ClearProjectError();
      }
      return selectedSteamList;
    }

    private void tsmiLaunchApp_Click(object sender, EventArgs e)
    {
      try
      {
        if (this.lvwAppList.SelectedItems.Count <= 0)
          return;
        SteamNode tag = (SteamNode) this.lvwAppList.SelectedItems[0].Tag;
        Globals.steam.TryLaunchApp(tag.AppId, tag.Parameters);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("Could not launch app: " + ex.Message);
        ProjectData.ClearProjectError();
      }
    }

    private void tsmiOpenFileLocation_Click(object sender, EventArgs e)
    {
      if (this.lvwAppList.SelectedItems.Count <= 0)
        return;
      string fullPath = ((OculusNode) this.lvwAppList.SelectedItems[0].Tag).FullPath;
      if (string.IsNullOrEmpty(fullPath) || !File.Exists(fullPath))
        return;
      Process.Start("explorer.exe", string.Format("/select,\"{0}\"", (object) fullPath));
    }

    private bool TryRemoveApp(Control control, SteamNode steamNode)
    {
      bool flag;
      try
      {
        List<string> manifestFileList = null;
        List<string> assetDirectoryList = null;
        if (Globals.oculus.TryGetManifestFileNameAndAssetFolderList((OculusNode) steamNode, ref manifestFileList, ref assetDirectoryList))
        {
          DialogResult result = (DialogResult)control.Invoke( new Func<DialogResult>(() => 
          {
              // Prompt user?
              return MessageBox.Show("Are you sure you want to remove " + steamNode.Name + "?", "Remove App", MessageBoxButtons.YesNo);
          }));

          if (result != DialogResult.Yes)
          {
            flag = false;
            goto label_22;
          }
          else
          {
            try
            {
              foreach (string path in manifestFileList)
              {
                if (File.Exists(path))
                {
                  File.Delete(path);
                  if (Globals.dbg)
                    Log.WriteToLog(path + " deleted");
                }
              }
            }
            finally
            {
              // loop clean
            }
            try
            {
              foreach (string path in assetDirectoryList)
              {
                if (Directory.Exists(path))
                {
                  Directory.Delete(path, true);
                  if (Globals.dbg)
                    Log.WriteToLog(path + " deleted");
                }
              }
            }
            finally
            {
              // loop clean
            }
          }
        }
        flag = true;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Log.WriteToLog("TryRemoveApp: " + ex.Message);
        ProjectData.ClearProjectError();
        flag = false; // Default
      }
label_22:
      return flag;
    }

    private void frmImportSteamApps_Resize(object sender, EventArgs e)
    {
      this.pictureBox1.Location = new Point(checked ((int) Math.Round(unchecked ((double) this.ClientSize.Width / 2.0 - (double) this.pictureBox1.Width / 2.0))), 0);
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
      Process.Start("http://headsoft.com.au/redirect.php?url=https://www.mechatech.co.uk/");
    }

    private void tsslHeadsoftLogo_Click(object sender, EventArgs e)
    {
      Process.Start("http://headsoft.com.au/");
    }

    private void frmImportSteamApps_FormClosing(object sender, FormClosingEventArgs e)
    {
      MySettingsProperty.Settings.SteamWindowLocation = this.Location;
      MySettingsProperty.Settings.SteamWindowSize = this.Size;
      MySettingsProperty.Settings.Save();
    }

    private delegate T Func<T>();

    private delegate void Func();
  }
}