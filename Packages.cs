// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.Packages
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic.CompilerServices;
using OculusTrayTool.My;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

#nullable disable
namespace OculusTrayTool
{
  [StandardModule]
  internal sealed class Packages
  {
    public static object CheckPackage(string cmd, string app)
    {
      int num = 0;
      try
      {
        using (Runspace runspace = RunspaceFactory.CreateRunspace())
        {
          runspace.Open();
          using (Pipeline pipeline = runspace.CreatePipeline())
          {
            pipeline.Commands.AddScript(cmd);
            Collection<PSObject> collection = pipeline.Invoke();
            num = collection.Count;
            if (num != 0 & Operators.CompareString(app, "", false) != 0)
            {
              try
              {
                foreach (PSObject psObject in collection)
                  Log.WriteToLinkLog(app + " is installed in: " + psObject.Members["Source"].Value.ToString());
              }
              finally
              {
                IEnumerator<PSObject> enumerator;
                enumerator?.Dispose();
              }
            }
          }
          runspace.Close();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLinkLog("CheckPackage: " + exception.Message);
        MyProject.Forms.FrmMain.AddToListboxAndScroll(exception.Message);
        ProjectData.ClearProjectError();
      }
      return (object) num;
    }

    public static object CheckCode(string cmd)
    {
      try
      {
        using (Runspace runspace = RunspaceFactory.CreateRunspace())
        {
          runspace.Open();
          using (Pipeline pipeline = runspace.CreatePipeline())
          {
            pipeline.Commands.AddScript(cmd);
            Collection<PSObject> collection = pipeline.Invoke();
            IEnumerator<PSObject> enumerator;
            if (collection.Count != 0)
            {
              try
              {
                enumerator = collection.GetEnumerator();
                if (enumerator.MoveNext())
                  return (object) enumerator.Current.ToString();
              }
              finally
              {
                enumerator?.Dispose();
              }
            }
          }
          runspace.Close();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Log.WriteToLinkLog("CheckPackage: " + exception.Message);
        MyProject.Forms.FrmMain.AddToListboxAndScroll(exception.Message);
        ProjectData.ClearProjectError();
      }
      return (object) "0";
    }
  }
}
