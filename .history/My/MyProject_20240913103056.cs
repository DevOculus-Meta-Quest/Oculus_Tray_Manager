// Decompiled with JetBrains decompiler
// Type: OculusTrayTool.My.MyProject
// Assembly: OculusTrayTool, Version=0.87.8.0, Culture=neutral, PublicKeyToken=null
// MVID: E8946A27-16D6-4BF6-9D7B-70CB25A977E0
// Assembly location: C:\Program Files (x86)\Oculus Tray Tool\OculusTrayTool.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace OculusTrayTool.My
{
  [StandardModule]
  [HideModuleName]
  [GeneratedCode("MyTemplate", "11.0.0.0")]
  internal sealed class MyProject
  {
    private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();
    private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();
    private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();
    private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();
    private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

    [HelpKeyword("My.Computer")]
    internal static MyComputer Computer
    {
      [DebuggerHidden] get => MyProject.m_ComputerObjectProvider.GetInstance;
    }

    [HelpKeyword("My.Application")]
    internal static MyApplication Application
    {
      [DebuggerHidden] get => MyProject.m_AppObjectProvider.GetInstance;
    }

    [HelpKeyword("My.User")]
    internal static User User
    {
      [DebuggerHidden] get => MyProject.m_UserObjectProvider.GetInstance;
    }

    [HelpKeyword("My.Forms")]
    internal static MyProject.MyForms Forms
    {
      [DebuggerHidden] get => MyProject.m_MyFormsObjectProvider.GetInstance;
    }

    [HelpKeyword("My.WebServices")]
    internal static MyProject.MyWebServices WebServices
    {
      [DebuggerHidden] get => MyProject.m_MyWebServicesObjectProvider.GetInstance;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
    internal sealed class MyForms
    {
      [ThreadStatic]
      private static Hashtable m_FormBeingCreated;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmAbout m_frmAbout;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmAddCustomVoice m_frmAddCustomVoice;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmAddVoiceProfile m_frmAddVoiceProfile;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmCreateEditProfile m_frmCreateEditProfile;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmDonate m_frmDonate;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmDownloading m_frmDownloading;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmEditAllSelected m_frmEditAllSelected;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmEditVoiceCommand m_frmEditVoiceCommand;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmHomeless m_frmHomeless;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmHomeTrayToast m_frmHomeTrayToast;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmHotKeys m_frmHotKeys;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public FrmIgnoredApps m_FrmIgnoredApps;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmImportSteamApps m_frmImportSteamApps;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmLaunchOptions m_frmLaunchOptions;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmLibrary m_frmLibrary;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmLinkPresets m_frmLinkPresets;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmLoading m_frmLoading;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public FrmMain m_FrmMain;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmMicNotDefaultWarning m_frmMicNotDefaultWarning;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmProcessing m_frmProcessing;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmProfiles m_frmProfiles;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmProperties m_frmProperties;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmRemoveProgress m_frmRemoveProgress;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public FrmSetFallback m_FrmSetFallback;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmSetLibraryPath m_frmSetLibraryPath;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmSSChanged m_frmSSChanged;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmStartupType m_frmStartupType;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmStillRunningToast m_frmStillRunningToast;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmUpdateToast m_frmUpdateToast;
      [EditorBrowsable(EditorBrowsableState.Never)]
      public frmVoiceSettings m_frmVoiceSettings;

      [DebuggerHidden]
      private static T Create__Instance__<T>(T Instance) where T : Form, new()
      {
        if ((object) Instance != null && !Instance.IsDisposed)
          return Instance;
        if (MyProject.MyForms.m_FormBeingCreated != null)
        {
          if (MyProject.MyForms.m_FormBeingCreated.ContainsKey((object) typeof (T)))
            throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate"));
        }
        else
          MyProject.MyForms.m_FormBeingCreated = new Hashtable();
        MyProject.MyForms.m_FormBeingCreated.Add((object) typeof (T), (object) null);
        TargetInvocationException invocationException;
        try
        {
          return new T();
        }
        catch (TargetInvocationException ex) when (
        {
          // ISSUE: unable to correctly present filter
          ProjectData.SetProjectError((Exception) ex);
          invocationException = ex;
          if (invocationException.InnerException != null)
          {
            SuccessfulFiltering;
          }
          else
            throw;
        }
        )
        {
          throw new InvalidOperationException(Utils.GetResourceString("WinForms_SeeInnerException", invocationException.InnerException.Message), invocationException.InnerException);
        }
        finally
        {
          MyProject.MyForms.m_FormBeingCreated.Remove((object) typeof (T));
        }
      }

      [DebuggerHidden]
      private void Dispose__Instance__<T>(ref T instance) where T : Form
      {
        instance.Dispose();
        instance = default (T);
      }

      [DebuggerHidden]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public MyForms()
      {
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override bool Equals(object o) => base.Equals(RuntimeHelpers.GetObjectValue(o));

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override int GetHashCode() => base.GetHashCode();

      [EditorBrowsable(EditorBrowsableState.Never)]
      internal new Type GetType() => typeof (MyProject.MyForms);

      [EditorBrowsable(EditorBrowsableState.Never)]
      public override string ToString() => base.ToString();

      public frmAbout frmAbout
      {
        [DebuggerHidden] get
        {
          this.m_frmAbout = MyProject.MyForms.Create__Instance__<frmAbout>(this.m_frmAbout);
          return this.m_frmAbout;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmAbout)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmAbout>(ref this.m_frmAbout);
        }
      }

      public frmAddCustomVoice frmAddCustomVoice
      {
        [DebuggerHidden] get
        {
          this.m_frmAddCustomVoice = MyProject.MyForms.Create__Instance__<frmAddCustomVoice>(this.m_frmAddCustomVoice);
          return this.m_frmAddCustomVoice;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmAddCustomVoice)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmAddCustomVoice>(ref this.m_frmAddCustomVoice);
        }
      }

      public frmAddVoiceProfile frmAddVoiceProfile
      {
        [DebuggerHidden] get
        {
          this.m_frmAddVoiceProfile = MyProject.MyForms.Create__Instance__<frmAddVoiceProfile>(this.m_frmAddVoiceProfile);
          return this.m_frmAddVoiceProfile;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmAddVoiceProfile)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmAddVoiceProfile>(ref this.m_frmAddVoiceProfile);
        }
      }

      public frmCreateEditProfile frmCreateEditProfile
      {
        [DebuggerHidden] get
        {
          this.m_frmCreateEditProfile = MyProject.MyForms.Create__Instance__<frmCreateEditProfile>(this.m_frmCreateEditProfile);
          return this.m_frmCreateEditProfile;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmCreateEditProfile)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmCreateEditProfile>(ref this.m_frmCreateEditProfile);
        }
      }

      public frmDonate frmDonate
      {
        [DebuggerHidden] get
        {
          this.m_frmDonate = MyProject.MyForms.Create__Instance__<frmDonate>(this.m_frmDonate);
          return this.m_frmDonate;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmDonate)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmDonate>(ref this.m_frmDonate);
        }
      }

      public frmDownloading frmDownloading
      {
        [DebuggerHidden] get
        {
          this.m_frmDownloading = MyProject.MyForms.Create__Instance__<frmDownloading>(this.m_frmDownloading);
          return this.m_frmDownloading;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmDownloading)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmDownloading>(ref this.m_frmDownloading);
        }
      }

      public frmEditAllSelected frmEditAllSelected
      {
        [DebuggerHidden] get
        {
          this.m_frmEditAllSelected = MyProject.MyForms.Create__Instance__<frmEditAllSelected>(this.m_frmEditAllSelected);
          return this.m_frmEditAllSelected;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmEditAllSelected)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmEditAllSelected>(ref this.m_frmEditAllSelected);
        }
      }

      public frmEditVoiceCommand frmEditVoiceCommand
      {
        [DebuggerHidden] get
        {
          this.m_frmEditVoiceCommand = MyProject.MyForms.Create__Instance__<frmEditVoiceCommand>(this.m_frmEditVoiceCommand);
          return this.m_frmEditVoiceCommand;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmEditVoiceCommand)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmEditVoiceCommand>(ref this.m_frmEditVoiceCommand);
        }
      }

      public frmHomeless frmHomeless
      {
        [DebuggerHidden] get
        {
          this.m_frmHomeless = MyProject.MyForms.Create__Instance__<frmHomeless>(this.m_frmHomeless);
          return this.m_frmHomeless;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmHomeless)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmHomeless>(ref this.m_frmHomeless);
        }
      }

      public frmHomeTrayToast frmHomeTrayToast
      {
        [DebuggerHidden] get
        {
          this.m_frmHomeTrayToast = MyProject.MyForms.Create__Instance__<frmHomeTrayToast>(this.m_frmHomeTrayToast);
          return this.m_frmHomeTrayToast;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmHomeTrayToast)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmHomeTrayToast>(ref this.m_frmHomeTrayToast);
        }
      }

      public frmHotKeys frmHotKeys
      {
        [DebuggerHidden] get
        {
          this.m_frmHotKeys = MyProject.MyForms.Create__Instance__<frmHotKeys>(this.m_frmHotKeys);
          return this.m_frmHotKeys;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmHotKeys)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmHotKeys>(ref this.m_frmHotKeys);
        }
      }

      public FrmIgnoredApps FrmIgnoredApps
      {
        [DebuggerHidden] get
        {
          this.m_FrmIgnoredApps = MyProject.MyForms.Create__Instance__<FrmIgnoredApps>(this.m_FrmIgnoredApps);
          return this.m_FrmIgnoredApps;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_FrmIgnoredApps)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<FrmIgnoredApps>(ref this.m_FrmIgnoredApps);
        }
      }

      public frmImportSteamApps frmImportSteamApps
      {
        [DebuggerHidden] get
        {
          this.m_frmImportSteamApps = MyProject.MyForms.Create__Instance__<frmImportSteamApps>(this.m_frmImportSteamApps);
          return this.m_frmImportSteamApps;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmImportSteamApps)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmImportSteamApps>(ref this.m_frmImportSteamApps);
        }
      }

      public frmLaunchOptions frmLaunchOptions
      {
        [DebuggerHidden] get
        {
          this.m_frmLaunchOptions = MyProject.MyForms.Create__Instance__<frmLaunchOptions>(this.m_frmLaunchOptions);
          return this.m_frmLaunchOptions;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmLaunchOptions)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmLaunchOptions>(ref this.m_frmLaunchOptions);
        }
      }

      public frmLibrary frmLibrary
      {
        [DebuggerHidden] get
        {
          this.m_frmLibrary = MyProject.MyForms.Create__Instance__<frmLibrary>(this.m_frmLibrary);
          return this.m_frmLibrary;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmLibrary)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmLibrary>(ref this.m_frmLibrary);
        }
      }

      public frmLinkPresets frmLinkPresets
      {
        [DebuggerHidden] get
        {
          this.m_frmLinkPresets = MyProject.MyForms.Create__Instance__<frmLinkPresets>(this.m_frmLinkPresets);
          return this.m_frmLinkPresets;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmLinkPresets)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmLinkPresets>(ref this.m_frmLinkPresets);
        }
      }

      public frmLoading frmLoading
      {
        [DebuggerHidden] get
        {
          this.m_frmLoading = MyProject.MyForms.Create__Instance__<frmLoading>(this.m_frmLoading);
          return this.m_frmLoading;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmLoading)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmLoading>(ref this.m_frmLoading);
        }
      }

      public FrmMain FrmMain
      {
        [DebuggerHidden] get
        {
          this.m_FrmMain = MyProject.MyForms.Create__Instance__<FrmMain>(this.m_FrmMain);
          return this.m_FrmMain;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_FrmMain)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<FrmMain>(ref this.m_FrmMain);
        }
      }

      public frmMicNotDefaultWarning frmMicNotDefaultWarning
      {
        [DebuggerHidden] get
        {
          this.m_frmMicNotDefaultWarning = MyProject.MyForms.Create__Instance__<frmMicNotDefaultWarning>(this.m_frmMicNotDefaultWarning);
          return this.m_frmMicNotDefaultWarning;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmMicNotDefaultWarning)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmMicNotDefaultWarning>(ref this.m_frmMicNotDefaultWarning);
        }
      }

      public frmProcessing frmProcessing
      {
        [DebuggerHidden] get
        {
          this.m_frmProcessing = MyProject.MyForms.Create__Instance__<frmProcessing>(this.m_frmProcessing);
          return this.m_frmProcessing;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmProcessing)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmProcessing>(ref this.m_frmProcessing);
        }
      }

      public frmProfiles frmProfiles
      {
        [DebuggerHidden] get
        {
          this.m_frmProfiles = MyProject.MyForms.Create__Instance__<frmProfiles>(this.m_frmProfiles);
          return this.m_frmProfiles;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmProfiles)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmProfiles>(ref this.m_frmProfiles);
        }
      }

      public frmProperties frmProperties
      {
        [DebuggerHidden] get
        {
          this.m_frmProperties = MyProject.MyForms.Create__Instance__<frmProperties>(this.m_frmProperties);
          return this.m_frmProperties;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmProperties)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmProperties>(ref this.m_frmProperties);
        }
      }

      public frmRemoveProgress frmRemoveProgress
      {
        [DebuggerHidden] get
        {
          this.m_frmRemoveProgress = MyProject.MyForms.Create__Instance__<frmRemoveProgress>(this.m_frmRemoveProgress);
          return this.m_frmRemoveProgress;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmRemoveProgress)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmRemoveProgress>(ref this.m_frmRemoveProgress);
        }
      }

      public FrmSetFallback FrmSetFallback
      {
        [DebuggerHidden] get
        {
          this.m_FrmSetFallback = MyProject.MyForms.Create__Instance__<FrmSetFallback>(this.m_FrmSetFallback);
          return this.m_FrmSetFallback;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_FrmSetFallback)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<FrmSetFallback>(ref this.m_FrmSetFallback);
        }
      }

      public frmSetLibraryPath frmSetLibraryPath
      {
        [DebuggerHidden] get
        {
          this.m_frmSetLibraryPath = MyProject.MyForms.Create__Instance__<frmSetLibraryPath>(this.m_frmSetLibraryPath);
          return this.m_frmSetLibraryPath;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmSetLibraryPath)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmSetLibraryPath>(ref this.m_frmSetLibraryPath);
        }
      }

      public frmSSChanged frmSSChanged
      {
        [DebuggerHidden] get
        {
          this.m_frmSSChanged = MyProject.MyForms.Create__Instance__<frmSSChanged>(this.m_frmSSChanged);
          return this.m_frmSSChanged;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmSSChanged)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmSSChanged>(ref this.m_frmSSChanged);
        }
      }

      public frmStartupType frmStartupType
      {
        [DebuggerHidden] get
        {
          this.m_frmStartupType = MyProject.MyForms.Create__Instance__<frmStartupType>(this.m_frmStartupType);
          return this.m_frmStartupType;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmStartupType)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmStartupType>(ref this.m_frmStartupType);
        }
      }

      public frmStillRunningToast frmStillRunningToast
      {
        [DebuggerHidden] get
        {
          this.m_frmStillRunningToast = MyProject.MyForms.Create__Instance__<frmStillRunningToast>(this.m_frmStillRunningToast);
          return this.m_frmStillRunningToast;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmStillRunningToast)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmStillRunningToast>(ref this.m_frmStillRunningToast);
        }
      }

      public frmUpdateToast frmUpdateToast
      {
        [DebuggerHidden] get
        {
          this.m_frmUpdateToast = MyProject.MyForms.Create__Instance__<frmUpdateToast>(this.m_frmUpdateToast);
          return this.m_frmUpdateToast;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmUpdateToast)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmUpdateToast>(ref this.m_frmUpdateToast);
        }
      }

      public frmVoiceSettings frmVoiceSettings
      {
        [DebuggerHidden] get
        {
          this.m_frmVoiceSettings = MyProject.MyForms.Create__Instance__<frmVoiceSettings>(this.m_frmVoiceSettings);
          return this.m_frmVoiceSettings;
        }
        [DebuggerHidden] set
        {
          if (value == this.m_frmVoiceSettings)
            return;
          if (value != null)
            throw new ArgumentException("Property can only be set to Nothing");
          this.Dispose__Instance__<frmVoiceSettings>(ref this.m_frmVoiceSettings);
        }
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
    internal sealed class MyWebServices
    {
      [EditorBrowsable(EditorBrowsableState.Never)]
      [DebuggerHidden]
      public override bool Equals(object o) => base.Equals(RuntimeHelpers.GetObjectValue(o));

      [EditorBrowsable(EditorBrowsableState.Never)]
      [DebuggerHidden]
      public override int GetHashCode() => base.GetHashCode();

      [EditorBrowsable(EditorBrowsableState.Never)]
      [DebuggerHidden]
      internal new Type GetType() => typeof (MyProject.MyWebServices);

      [EditorBrowsable(EditorBrowsableState.Never)]
      [DebuggerHidden]
      public override string ToString() => base.ToString();

      [DebuggerHidden]
      private static T Create__Instance__<T>(T instance) where T : new()
      {
        return (object) instance == null ? new T() : instance;
      }

      [DebuggerHidden]
      private void Dispose__Instance__<T>(ref T instance) => instance = default (T);

      [DebuggerHidden]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public MyWebServices()
      {
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [ComVisible(false)]
    internal sealed class ThreadSafeObjectProvider<T> where T : new()
    {
      internal T GetInstance
      {
        [DebuggerHidden] get
        {
          if ((object) MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null)
            MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = new T();
          return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
        }
      }

      [DebuggerHidden]
      [EditorBrowsable(EditorBrowsableState.Never)]
      public ThreadSafeObjectProvider()
      {
      }
    }
  }
}
