using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace OculusTrayTool.My
{
  [StandardModule]
  [HideModuleName]
  [GeneratedCode("MyTemplate", "11.0.0.0")]
  internal sealed class MyProject
  {
    private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();
    private static readonly ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();


    internal static MyComputer Computer
    {
      [DebuggerHidden]
      get
      {
        return MyProject.m_ComputerObjectProvider.GetInstance();
      }
    }

    internal static MyForms Forms
    {
      [DebuggerHidden]
      get
      {
        return MyProject.m_MyFormsObjectProvider.GetInstance();
      }
    }
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class MyForms
    {
      public FrmMain FrmMain
      {
        [DebuggerHidden]
        get
        {
          this.m_FrmMain = MyForms.Create__Instance__<FrmMain>(this.m_FrmMain);
          return this.m_FrmMain;
        }
        [DebuggerHidden]
        set
        {
          if (value == this.m_FrmMain)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<FrmMain>(ref this.m_FrmMain);
        }
      }
      private FrmMain m_FrmMain;

      public frmProfiles frmProfiles
      {
        [DebuggerHidden]
        get
        {
          this.m_frmProfiles = MyForms.Create__Instance__<frmProfiles>(this.m_frmProfiles);
          return this.m_frmProfiles;
        }
        [DebuggerHidden]
        set
        {
            if (value == this.m_frmProfiles) return;
            if (value != null) throw new ArgumentException("Property can only be set to Nothing");
            this.Dispose__Instance__<frmProfiles>(ref this.m_frmProfiles);
        }
      }
      private frmProfiles m_frmProfiles;
      
      public frmLibrary frmLibrary
      {
        [DebuggerHidden]
        get
        {
            this.m_frmLibrary = MyForms.Create__Instance__<frmLibrary>(this.m_frmLibrary);
            return this.m_frmLibrary;
        }
        [DebuggerHidden]
        set
        {
            if (value == this.m_frmLibrary) return;
            if (value != null) throw new ArgumentException("Property can only be set to Nothing");
            this.Dispose__Instance__<frmLibrary>(ref this.m_frmLibrary);
        }
      }
      private frmLibrary m_frmLibrary;

      public frmMicNotDefaultWarning frmMicNotDefaultWarning
      {
          [DebuggerHidden]
          get
          {
              this.m_frmMicNotDefaultWarning = MyForms.Create__Instance__<frmMicNotDefaultWarning>(this.m_frmMicNotDefaultWarning);
              return this.m_frmMicNotDefaultWarning;
          }
          [DebuggerHidden]
          set
          {
              if (value == this.m_frmMicNotDefaultWarning) return;
              if (value != null) throw new ArgumentException("Property can only be set to Nothing");
              this.Dispose__Instance__<frmMicNotDefaultWarning>(ref this.m_frmMicNotDefaultWarning);
          }
      }
      private frmMicNotDefaultWarning m_frmMicNotDefaultWarning;

      public FrmSetFallback FrmSetFallback
      {
          [DebuggerHidden]
          get
          {
              this.m_FrmSetFallback = MyForms.Create__Instance__<FrmSetFallback>(this.m_FrmSetFallback);
              return this.m_FrmSetFallback;
          }
          [DebuggerHidden]
          set
          {
              if (value == this.m_FrmSetFallback) return;
              if (value != null) throw new ArgumentException("Property can only be set to Nothing");
              this.Dispose__Instance__<FrmSetFallback>(ref this.m_FrmSetFallback);
          }
      }
      private FrmSetFallback m_FrmSetFallback;



      [DebuggerHidden]
      private static T Create__Instance__<T>(T Instance) where T : Form, new()
      {
        if ((object) Instance != null && !Instance.IsDisposed)
          return Instance;
        
        if (MyForms.m_FormBeingCreated == null)
          MyForms.m_FormBeingCreated = new System.Collections.Hashtable();
          
        if (MyForms.m_FormBeingCreated.ContainsKey((object) typeof (T)))
            throw new InvalidOperationException("Recursive form creation.");

        MyForms.m_FormBeingCreated.Add((object) typeof (T), (object) null);
        try
        {
          return new T();
        }
        catch (System.Reflection.TargetInvocationException ex)
        {
          throw new InvalidOperationException("Failed to create form: " + ex.InnerException.Message, ex.InnerException);
        }
        finally
        {
          MyForms.m_FormBeingCreated.Remove((object) typeof (T));
        }
      }

      [DebuggerHidden]
      private void Dispose__Instance__<T>(ref T instance) where T : Form
      {
        instance.Dispose();
        instance = default (T);
      }
      
      [ThreadStatic]
      private static System.Collections.Hashtable m_FormBeingCreated;

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals(object o) => base.Equals(o);
      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() => base.GetHashCode();
      [EditorBrowsable(EditorBrowsableState.Never)]
      internal new System.Type GetType() => typeof (MyForms);
      [EditorBrowsable(EditorBrowsableState.Never)]
      public override string ToString() => base.ToString();
    }
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ComVisible(false)]
    internal sealed class ThreadSafeObjectProvider<T> where T : new()
    {
      internal T GetInstance()
      {
         if (m_Value == null) m_Value = new T();
         return m_Value;
      }
      
      [ThreadStatic]
      private static T m_Value;
    }
  }
}
