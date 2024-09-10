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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool.My;

[StandardModule]
[HideModuleName]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class MyProject
{
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

		public frmAbout frmAbout
		{
			[DebuggerHidden]
			get
			{
				m_frmAbout = Create__Instance__(m_frmAbout);
				return m_frmAbout;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmAbout)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmAbout);
				}
			}
		}

		public frmAddCustomVoice frmAddCustomVoice
		{
			[DebuggerHidden]
			get
			{
				m_frmAddCustomVoice = Create__Instance__(m_frmAddCustomVoice);
				return m_frmAddCustomVoice;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmAddCustomVoice)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmAddCustomVoice);
				}
			}
		}

		public frmAddVoiceProfile frmAddVoiceProfile
		{
			[DebuggerHidden]
			get
			{
				m_frmAddVoiceProfile = Create__Instance__(m_frmAddVoiceProfile);
				return m_frmAddVoiceProfile;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmAddVoiceProfile)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmAddVoiceProfile);
				}
			}
		}

		public frmCreateEditProfile frmCreateEditProfile
		{
			[DebuggerHidden]
			get
			{
				m_frmCreateEditProfile = Create__Instance__(m_frmCreateEditProfile);
				return m_frmCreateEditProfile;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmCreateEditProfile)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmCreateEditProfile);
				}
			}
		}

		public frmDonate frmDonate
		{
			[DebuggerHidden]
			get
			{
				m_frmDonate = Create__Instance__(m_frmDonate);
				return m_frmDonate;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmDonate)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmDonate);
				}
			}
		}

		public frmDownloading frmDownloading
		{
			[DebuggerHidden]
			get
			{
				m_frmDownloading = Create__Instance__(m_frmDownloading);
				return m_frmDownloading;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmDownloading)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmDownloading);
				}
			}
		}

		public frmEditAllSelected frmEditAllSelected
		{
			[DebuggerHidden]
			get
			{
				m_frmEditAllSelected = Create__Instance__(m_frmEditAllSelected);
				return m_frmEditAllSelected;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmEditAllSelected)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmEditAllSelected);
				}
			}
		}

		public frmEditVoiceCommand frmEditVoiceCommand
		{
			[DebuggerHidden]
			get
			{
				m_frmEditVoiceCommand = Create__Instance__(m_frmEditVoiceCommand);
				return m_frmEditVoiceCommand;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmEditVoiceCommand)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmEditVoiceCommand);
				}
			}
		}

		public frmHomeless frmHomeless
		{
			[DebuggerHidden]
			get
			{
				m_frmHomeless = Create__Instance__(m_frmHomeless);
				return m_frmHomeless;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmHomeless)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmHomeless);
				}
			}
		}

		public frmHomeTrayToast frmHomeTrayToast
		{
			[DebuggerHidden]
			get
			{
				m_frmHomeTrayToast = Create__Instance__(m_frmHomeTrayToast);
				return m_frmHomeTrayToast;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmHomeTrayToast)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmHomeTrayToast);
				}
			}
		}

		public frmHotKeys frmHotKeys
		{
			[DebuggerHidden]
			get
			{
				m_frmHotKeys = Create__Instance__(m_frmHotKeys);
				return m_frmHotKeys;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmHotKeys)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmHotKeys);
				}
			}
		}

		public FrmIgnoredApps FrmIgnoredApps
		{
			[DebuggerHidden]
			get
			{
				m_FrmIgnoredApps = Create__Instance__(m_FrmIgnoredApps);
				return m_FrmIgnoredApps;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_FrmIgnoredApps)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmIgnoredApps);
				}
			}
		}

		public frmImportSteamApps frmImportSteamApps
		{
			[DebuggerHidden]
			get
			{
				m_frmImportSteamApps = Create__Instance__(m_frmImportSteamApps);
				return m_frmImportSteamApps;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmImportSteamApps)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmImportSteamApps);
				}
			}
		}

		public frmLaunchOptions frmLaunchOptions
		{
			[DebuggerHidden]
			get
			{
				m_frmLaunchOptions = Create__Instance__(m_frmLaunchOptions);
				return m_frmLaunchOptions;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmLaunchOptions)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmLaunchOptions);
				}
			}
		}

		public frmLibrary frmLibrary
		{
			[DebuggerHidden]
			get
			{
				m_frmLibrary = Create__Instance__(m_frmLibrary);
				return m_frmLibrary;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmLibrary)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmLibrary);
				}
			}
		}

		public frmLinkPresets frmLinkPresets
		{
			[DebuggerHidden]
			get
			{
				m_frmLinkPresets = Create__Instance__(m_frmLinkPresets);
				return m_frmLinkPresets;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmLinkPresets)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmLinkPresets);
				}
			}
		}

		public frmLoading frmLoading
		{
			[DebuggerHidden]
			get
			{
				m_frmLoading = Create__Instance__(m_frmLoading);
				return m_frmLoading;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmLoading)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmLoading);
				}
			}
		}

		public FrmMain FrmMain
		{
			[DebuggerHidden]
			get
			{
				m_FrmMain = Create__Instance__(m_FrmMain);
				return m_FrmMain;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_FrmMain)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmMain);
				}
			}
		}

		public frmMicNotDefaultWarning frmMicNotDefaultWarning
		{
			[DebuggerHidden]
			get
			{
				m_frmMicNotDefaultWarning = Create__Instance__(m_frmMicNotDefaultWarning);
				return m_frmMicNotDefaultWarning;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmMicNotDefaultWarning)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmMicNotDefaultWarning);
				}
			}
		}

		public frmProcessing frmProcessing
		{
			[DebuggerHidden]
			get
			{
				m_frmProcessing = Create__Instance__(m_frmProcessing);
				return m_frmProcessing;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmProcessing)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmProcessing);
				}
			}
		}

		public frmProfiles frmProfiles
		{
			[DebuggerHidden]
			get
			{
				m_frmProfiles = Create__Instance__(m_frmProfiles);
				return m_frmProfiles;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmProfiles)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmProfiles);
				}
			}
		}

		public frmProperties frmProperties
		{
			[DebuggerHidden]
			get
			{
				m_frmProperties = Create__Instance__(m_frmProperties);
				return m_frmProperties;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmProperties)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmProperties);
				}
			}
		}

		public frmRemoveProgress frmRemoveProgress
		{
			[DebuggerHidden]
			get
			{
				m_frmRemoveProgress = Create__Instance__(m_frmRemoveProgress);
				return m_frmRemoveProgress;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmRemoveProgress)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmRemoveProgress);
				}
			}
		}

		public FrmSetFallback FrmSetFallback
		{
			[DebuggerHidden]
			get
			{
				m_FrmSetFallback = Create__Instance__(m_FrmSetFallback);
				return m_FrmSetFallback;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_FrmSetFallback)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_FrmSetFallback);
				}
			}
		}

		public frmSetLibraryPath frmSetLibraryPath
		{
			[DebuggerHidden]
			get
			{
				m_frmSetLibraryPath = Create__Instance__(m_frmSetLibraryPath);
				return m_frmSetLibraryPath;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmSetLibraryPath)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmSetLibraryPath);
				}
			}
		}

		public frmSSChanged frmSSChanged
		{
			[DebuggerHidden]
			get
			{
				m_frmSSChanged = Create__Instance__(m_frmSSChanged);
				return m_frmSSChanged;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmSSChanged)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmSSChanged);
				}
			}
		}

		public frmStartupType frmStartupType
		{
			[DebuggerHidden]
			get
			{
				m_frmStartupType = Create__Instance__(m_frmStartupType);
				return m_frmStartupType;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmStartupType)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmStartupType);
				}
			}
		}

		public frmStillRunningToast frmStillRunningToast
		{
			[DebuggerHidden]
			get
			{
				m_frmStillRunningToast = Create__Instance__(m_frmStillRunningToast);
				return m_frmStillRunningToast;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmStillRunningToast)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmStillRunningToast);
				}
			}
		}

		public frmUpdateToast frmUpdateToast
		{
			[DebuggerHidden]
			get
			{
				m_frmUpdateToast = Create__Instance__(m_frmUpdateToast);
				return m_frmUpdateToast;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmUpdateToast)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmUpdateToast);
				}
			}
		}

		public frmVoiceSettings frmVoiceSettings
		{
			[DebuggerHidden]
			get
			{
				m_frmVoiceSettings = Create__Instance__(m_frmVoiceSettings);
				return m_frmVoiceSettings;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_frmVoiceSettings)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_frmVoiceSettings);
				}
			}
		}

		[DebuggerHidden]
		private static T Create__Instance__<T>(T Instance) where T : Form, new()
		{
			if (Instance == null || Instance.IsDisposed)
			{
				if (m_FormBeingCreated != null)
				{
					if (m_FormBeingCreated.ContainsKey(typeof(T)))
					{
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate"));
					}
				}
				else
				{
					m_FormBeingCreated = new Hashtable();
				}
				m_FormBeingCreated.Add(typeof(T), null);
				try
				{
					return new T();
				}
				catch (TargetInvocationException ex) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					ProjectData.SetProjectError(ex);
					return ex.InnerException != null;
				}).Invoke())
				{
					string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", ex.InnerException.Message);
					throw new InvalidOperationException(resourceString, ex.InnerException);
				}
				finally
				{
					m_FormBeingCreated.Remove(typeof(T));
				}
			}
			return Instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T>(ref T instance) where T : Form
		{
			instance.Dispose();
			instance = null;
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyForms()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal new Type GetType()
		{
			return typeof(MyForms);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class MyWebServices
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		internal new Type GetType()
		{
			return typeof(MyWebServices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T Create__Instance__<T>(T instance) where T : new()
		{
			if (instance == null)
			{
				return new T();
			}
			return instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T>(ref T instance)
		{
			instance = default(T);
		}

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
		[CompilerGenerated]
		[ThreadStatic]
		private static T m_ThreadStaticValue;

		internal T GetInstance
		{
			[DebuggerHidden]
			get
			{
				if (m_ThreadStaticValue == null)
				{
					m_ThreadStaticValue = new T();
				}
				return m_ThreadStaticValue;
			}
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ThreadSafeObjectProvider()
		{
		}
	}

	private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();

	private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();

	private static readonly ThreadSafeObjectProvider<User> m_UserObjectProvider = new ThreadSafeObjectProvider<User>();

	private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

	private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();

	[HelpKeyword("My.Computer")]
	internal static MyComputer Computer
	{
		[DebuggerHidden]
		get
		{
			return m_ComputerObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.Application")]
	internal static MyApplication Application
	{
		[DebuggerHidden]
		get
		{
			return m_AppObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.User")]
	internal static User User
	{
		[DebuggerHidden]
		get
		{
			return m_UserObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.Forms")]
	internal static MyForms Forms
	{
		[DebuggerHidden]
		get
		{
			return m_MyFormsObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static MyWebServices WebServices
	{
		[DebuggerHidden]
		get
		{
			return m_MyWebServicesObjectProvider.GetInstance;
		}
	}
}
