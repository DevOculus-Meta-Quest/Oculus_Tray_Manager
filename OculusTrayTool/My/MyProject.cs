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

namespace OculusTrayTool.My
{
	// Token: 0x02000004 RID: 4
	[StandardModule]
	[HideModuleName]
	[GeneratedCode("MyTemplate", "11.0.0.0")]
	internal sealed class MyProject
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000006 RID: 6 RVA: 0x0000210C File Offset: 0x0000030C
		[HelpKeyword("My.Computer")]
		internal static MyComputer Computer
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_ComputerObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002128 File Offset: 0x00000328
		[HelpKeyword("My.Application")]
		internal static MyApplication Application
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_AppObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002144 File Offset: 0x00000344
		[HelpKeyword("My.User")]
		internal static User User
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_UserObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002160 File Offset: 0x00000360
		[HelpKeyword("My.Forms")]
		internal static MyProject.MyForms Forms
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyFormsObjectProvider.GetInstance;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000217C File Offset: 0x0000037C
		[HelpKeyword("My.WebServices")]
		internal static MyProject.MyWebServices WebServices
		{
			[DebuggerHidden]
			get
			{
				return MyProject.m_MyWebServicesObjectProvider.GetInstance;
			}
		}

		// Token: 0x04000001 RID: 1
		private static readonly MyProject.ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new MyProject.ThreadSafeObjectProvider<MyComputer>();

		// Token: 0x04000002 RID: 2
		private static readonly MyProject.ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new MyProject.ThreadSafeObjectProvider<MyApplication>();

		// Token: 0x04000003 RID: 3
		private static readonly MyProject.ThreadSafeObjectProvider<User> m_UserObjectProvider = new MyProject.ThreadSafeObjectProvider<User>();

		// Token: 0x04000004 RID: 4
		private static MyProject.ThreadSafeObjectProvider<MyProject.MyForms> m_MyFormsObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyForms>();

		// Token: 0x04000005 RID: 5
		private static readonly MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices> m_MyWebServicesObjectProvider = new MyProject.ThreadSafeObjectProvider<MyProject.MyWebServices>();

		// Token: 0x02000063 RID: 99
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
		internal sealed class MyForms
		{
			// Token: 0x060009B6 RID: 2486 RVA: 0x000595AC File Offset: 0x000577AC
			[DebuggerHidden]
			private static T Create__Instance__<T>(T Instance) where T : Form, new()
			{
				bool flag = Instance == null || Instance.IsDisposed;
				if (flag)
				{
					bool flag2 = MyProject.MyForms.m_FormBeingCreated != null;
					if (flag2)
					{
						bool flag3 = MyProject.MyForms.m_FormBeingCreated.ContainsKey(typeof(T));
						if (flag3)
						{
							throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
						}
					}
					else
					{
						MyProject.MyForms.m_FormBeingCreated = new Hashtable();
					}
					MyProject.MyForms.m_FormBeingCreated.Add(typeof(T), null);
					try
					{
						return new T();
					}
					catch (TargetInvocationException ex) when (ex.InnerException != null)
					{
						string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", new string[] { ex.InnerException.Message });
						throw new InvalidOperationException(resourceString, ex.InnerException);
					}
					finally
					{
						MyProject.MyForms.m_FormBeingCreated.Remove(typeof(T));
					}
				}
				return Instance;
			}

			// Token: 0x060009B7 RID: 2487 RVA: 0x000596D4 File Offset: 0x000578D4
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance) where T : Form
			{
				instance.Dispose();
				instance = default(T);
			}

			// Token: 0x060009B8 RID: 2488 RVA: 0x000596EB File Offset: 0x000578EB
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyForms()
			{
			}

			// Token: 0x060009B9 RID: 2489 RVA: 0x000596F8 File Offset: 0x000578F8
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x060009BA RID: 2490 RVA: 0x00059718 File Offset: 0x00057918
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x060009BB RID: 2491 RVA: 0x00059730 File Offset: 0x00057930
			[EditorBrowsable(EditorBrowsableState.Never)]
			internal new Type GetType()
			{
				return typeof(MyProject.MyForms);
			}

			// Token: 0x060009BC RID: 2492 RVA: 0x0005974C File Offset: 0x0005794C
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x17000343 RID: 835
			// (get) Token: 0x060009BD RID: 2493 RVA: 0x00059764 File Offset: 0x00057964
			// (set) Token: 0x060009DB RID: 2523 RVA: 0x00059A8E File Offset: 0x00057C8E
			public frmAbout frmAbout
			{
				[DebuggerHidden]
				get
				{
					this.m_frmAbout = MyProject.MyForms.Create__Instance__<frmAbout>(this.m_frmAbout);
					return this.m_frmAbout;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmAbout)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmAbout>(ref this.m_frmAbout);
					}
				}
			}

			// Token: 0x17000344 RID: 836
			// (get) Token: 0x060009BE RID: 2494 RVA: 0x0005977F File Offset: 0x0005797F
			// (set) Token: 0x060009DC RID: 2524 RVA: 0x00059ABA File Offset: 0x00057CBA
			public frmAddCustomVoice frmAddCustomVoice
			{
				[DebuggerHidden]
				get
				{
					this.m_frmAddCustomVoice = MyProject.MyForms.Create__Instance__<frmAddCustomVoice>(this.m_frmAddCustomVoice);
					return this.m_frmAddCustomVoice;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmAddCustomVoice)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmAddCustomVoice>(ref this.m_frmAddCustomVoice);
					}
				}
			}

			// Token: 0x17000345 RID: 837
			// (get) Token: 0x060009BF RID: 2495 RVA: 0x0005979A File Offset: 0x0005799A
			// (set) Token: 0x060009DD RID: 2525 RVA: 0x00059AE6 File Offset: 0x00057CE6
			public frmAddVoiceProfile frmAddVoiceProfile
			{
				[DebuggerHidden]
				get
				{
					this.m_frmAddVoiceProfile = MyProject.MyForms.Create__Instance__<frmAddVoiceProfile>(this.m_frmAddVoiceProfile);
					return this.m_frmAddVoiceProfile;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmAddVoiceProfile)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmAddVoiceProfile>(ref this.m_frmAddVoiceProfile);
					}
				}
			}

			// Token: 0x17000346 RID: 838
			// (get) Token: 0x060009C0 RID: 2496 RVA: 0x000597B5 File Offset: 0x000579B5
			// (set) Token: 0x060009DE RID: 2526 RVA: 0x00059B12 File Offset: 0x00057D12
			public frmCreateEditProfile frmCreateEditProfile
			{
				[DebuggerHidden]
				get
				{
					this.m_frmCreateEditProfile = MyProject.MyForms.Create__Instance__<frmCreateEditProfile>(this.m_frmCreateEditProfile);
					return this.m_frmCreateEditProfile;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmCreateEditProfile)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmCreateEditProfile>(ref this.m_frmCreateEditProfile);
					}
				}
			}

			// Token: 0x17000347 RID: 839
			// (get) Token: 0x060009C1 RID: 2497 RVA: 0x000597D0 File Offset: 0x000579D0
			// (set) Token: 0x060009DF RID: 2527 RVA: 0x00059B3E File Offset: 0x00057D3E
			public frmDonate frmDonate
			{
				[DebuggerHidden]
				get
				{
					this.m_frmDonate = MyProject.MyForms.Create__Instance__<frmDonate>(this.m_frmDonate);
					return this.m_frmDonate;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmDonate)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmDonate>(ref this.m_frmDonate);
					}
				}
			}

			// Token: 0x17000348 RID: 840
			// (get) Token: 0x060009C2 RID: 2498 RVA: 0x000597EB File Offset: 0x000579EB
			// (set) Token: 0x060009E0 RID: 2528 RVA: 0x00059B6A File Offset: 0x00057D6A
			public frmDownloading frmDownloading
			{
				[DebuggerHidden]
				get
				{
					this.m_frmDownloading = MyProject.MyForms.Create__Instance__<frmDownloading>(this.m_frmDownloading);
					return this.m_frmDownloading;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmDownloading)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmDownloading>(ref this.m_frmDownloading);
					}
				}
			}

			// Token: 0x17000349 RID: 841
			// (get) Token: 0x060009C3 RID: 2499 RVA: 0x00059806 File Offset: 0x00057A06
			// (set) Token: 0x060009E1 RID: 2529 RVA: 0x00059B96 File Offset: 0x00057D96
			public frmEditAllSelected frmEditAllSelected
			{
				[DebuggerHidden]
				get
				{
					this.m_frmEditAllSelected = MyProject.MyForms.Create__Instance__<frmEditAllSelected>(this.m_frmEditAllSelected);
					return this.m_frmEditAllSelected;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmEditAllSelected)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmEditAllSelected>(ref this.m_frmEditAllSelected);
					}
				}
			}

			// Token: 0x1700034A RID: 842
			// (get) Token: 0x060009C4 RID: 2500 RVA: 0x00059821 File Offset: 0x00057A21
			// (set) Token: 0x060009E2 RID: 2530 RVA: 0x00059BC2 File Offset: 0x00057DC2
			public frmEditVoiceCommand frmEditVoiceCommand
			{
				[DebuggerHidden]
				get
				{
					this.m_frmEditVoiceCommand = MyProject.MyForms.Create__Instance__<frmEditVoiceCommand>(this.m_frmEditVoiceCommand);
					return this.m_frmEditVoiceCommand;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmEditVoiceCommand)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmEditVoiceCommand>(ref this.m_frmEditVoiceCommand);
					}
				}
			}

			// Token: 0x1700034B RID: 843
			// (get) Token: 0x060009C5 RID: 2501 RVA: 0x0005983C File Offset: 0x00057A3C
			// (set) Token: 0x060009E3 RID: 2531 RVA: 0x00059BEE File Offset: 0x00057DEE
			public frmHomeless frmHomeless
			{
				[DebuggerHidden]
				get
				{
					this.m_frmHomeless = MyProject.MyForms.Create__Instance__<frmHomeless>(this.m_frmHomeless);
					return this.m_frmHomeless;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmHomeless)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmHomeless>(ref this.m_frmHomeless);
					}
				}
			}

			// Token: 0x1700034C RID: 844
			// (get) Token: 0x060009C6 RID: 2502 RVA: 0x00059857 File Offset: 0x00057A57
			// (set) Token: 0x060009E4 RID: 2532 RVA: 0x00059C1A File Offset: 0x00057E1A
			public frmHomeTrayToast frmHomeTrayToast
			{
				[DebuggerHidden]
				get
				{
					this.m_frmHomeTrayToast = MyProject.MyForms.Create__Instance__<frmHomeTrayToast>(this.m_frmHomeTrayToast);
					return this.m_frmHomeTrayToast;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmHomeTrayToast)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmHomeTrayToast>(ref this.m_frmHomeTrayToast);
					}
				}
			}

			// Token: 0x1700034D RID: 845
			// (get) Token: 0x060009C7 RID: 2503 RVA: 0x00059872 File Offset: 0x00057A72
			// (set) Token: 0x060009E5 RID: 2533 RVA: 0x00059C46 File Offset: 0x00057E46
			public frmHotKeys frmHotKeys
			{
				[DebuggerHidden]
				get
				{
					this.m_frmHotKeys = MyProject.MyForms.Create__Instance__<frmHotKeys>(this.m_frmHotKeys);
					return this.m_frmHotKeys;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmHotKeys)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmHotKeys>(ref this.m_frmHotKeys);
					}
				}
			}

			// Token: 0x1700034E RID: 846
			// (get) Token: 0x060009C8 RID: 2504 RVA: 0x0005988D File Offset: 0x00057A8D
			// (set) Token: 0x060009E6 RID: 2534 RVA: 0x00059C72 File Offset: 0x00057E72
			public FrmIgnoredApps FrmIgnoredApps
			{
				[DebuggerHidden]
				get
				{
					this.m_FrmIgnoredApps = MyProject.MyForms.Create__Instance__<FrmIgnoredApps>(this.m_FrmIgnoredApps);
					return this.m_FrmIgnoredApps;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_FrmIgnoredApps)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<FrmIgnoredApps>(ref this.m_FrmIgnoredApps);
					}
				}
			}

			// Token: 0x1700034F RID: 847
			// (get) Token: 0x060009C9 RID: 2505 RVA: 0x000598A8 File Offset: 0x00057AA8
			// (set) Token: 0x060009E7 RID: 2535 RVA: 0x00059C9E File Offset: 0x00057E9E
			public frmImportSteamApps frmImportSteamApps
			{
				[DebuggerHidden]
				get
				{
					this.m_frmImportSteamApps = MyProject.MyForms.Create__Instance__<frmImportSteamApps>(this.m_frmImportSteamApps);
					return this.m_frmImportSteamApps;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmImportSteamApps)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmImportSteamApps>(ref this.m_frmImportSteamApps);
					}
				}
			}

			// Token: 0x17000350 RID: 848
			// (get) Token: 0x060009CA RID: 2506 RVA: 0x000598C3 File Offset: 0x00057AC3
			// (set) Token: 0x060009E8 RID: 2536 RVA: 0x00059CCA File Offset: 0x00057ECA
			public frmLaunchOptions frmLaunchOptions
			{
				[DebuggerHidden]
				get
				{
					this.m_frmLaunchOptions = MyProject.MyForms.Create__Instance__<frmLaunchOptions>(this.m_frmLaunchOptions);
					return this.m_frmLaunchOptions;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmLaunchOptions)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmLaunchOptions>(ref this.m_frmLaunchOptions);
					}
				}
			}

			// Token: 0x17000351 RID: 849
			// (get) Token: 0x060009CB RID: 2507 RVA: 0x000598DE File Offset: 0x00057ADE
			// (set) Token: 0x060009E9 RID: 2537 RVA: 0x00059CF6 File Offset: 0x00057EF6
			public frmLibrary frmLibrary
			{
				[DebuggerHidden]
				get
				{
					this.m_frmLibrary = MyProject.MyForms.Create__Instance__<frmLibrary>(this.m_frmLibrary);
					return this.m_frmLibrary;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmLibrary)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmLibrary>(ref this.m_frmLibrary);
					}
				}
			}

			// Token: 0x17000352 RID: 850
			// (get) Token: 0x060009CC RID: 2508 RVA: 0x000598F9 File Offset: 0x00057AF9
			// (set) Token: 0x060009EA RID: 2538 RVA: 0x00059D22 File Offset: 0x00057F22
			public frmLinkPresets frmLinkPresets
			{
				[DebuggerHidden]
				get
				{
					this.m_frmLinkPresets = MyProject.MyForms.Create__Instance__<frmLinkPresets>(this.m_frmLinkPresets);
					return this.m_frmLinkPresets;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmLinkPresets)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmLinkPresets>(ref this.m_frmLinkPresets);
					}
				}
			}

			// Token: 0x17000353 RID: 851
			// (get) Token: 0x060009CD RID: 2509 RVA: 0x00059914 File Offset: 0x00057B14
			// (set) Token: 0x060009EB RID: 2539 RVA: 0x00059D4E File Offset: 0x00057F4E
			public frmLoading frmLoading
			{
				[DebuggerHidden]
				get
				{
					this.m_frmLoading = MyProject.MyForms.Create__Instance__<frmLoading>(this.m_frmLoading);
					return this.m_frmLoading;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmLoading)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmLoading>(ref this.m_frmLoading);
					}
				}
			}

			// Token: 0x17000354 RID: 852
			// (get) Token: 0x060009CE RID: 2510 RVA: 0x0005992F File Offset: 0x00057B2F
			// (set) Token: 0x060009EC RID: 2540 RVA: 0x00059D7A File Offset: 0x00057F7A
			public FrmMain FrmMain
			{
				[DebuggerHidden]
				get
				{
					this.m_FrmMain = MyProject.MyForms.Create__Instance__<FrmMain>(this.m_FrmMain);
					return this.m_FrmMain;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_FrmMain)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<FrmMain>(ref this.m_FrmMain);
					}
				}
			}

			// Token: 0x17000355 RID: 853
			// (get) Token: 0x060009CF RID: 2511 RVA: 0x0005994A File Offset: 0x00057B4A
			// (set) Token: 0x060009ED RID: 2541 RVA: 0x00059DA6 File Offset: 0x00057FA6
			public frmMicNotDefaultWarning frmMicNotDefaultWarning
			{
				[DebuggerHidden]
				get
				{
					this.m_frmMicNotDefaultWarning = MyProject.MyForms.Create__Instance__<frmMicNotDefaultWarning>(this.m_frmMicNotDefaultWarning);
					return this.m_frmMicNotDefaultWarning;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmMicNotDefaultWarning)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmMicNotDefaultWarning>(ref this.m_frmMicNotDefaultWarning);
					}
				}
			}

			// Token: 0x17000356 RID: 854
			// (get) Token: 0x060009D0 RID: 2512 RVA: 0x00059965 File Offset: 0x00057B65
			// (set) Token: 0x060009EE RID: 2542 RVA: 0x00059DD2 File Offset: 0x00057FD2
			public frmProcessing frmProcessing
			{
				[DebuggerHidden]
				get
				{
					this.m_frmProcessing = MyProject.MyForms.Create__Instance__<frmProcessing>(this.m_frmProcessing);
					return this.m_frmProcessing;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmProcessing)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmProcessing>(ref this.m_frmProcessing);
					}
				}
			}

			// Token: 0x17000357 RID: 855
			// (get) Token: 0x060009D1 RID: 2513 RVA: 0x00059980 File Offset: 0x00057B80
			// (set) Token: 0x060009EF RID: 2543 RVA: 0x00059DFE File Offset: 0x00057FFE
			public frmProfiles frmProfiles
			{
				[DebuggerHidden]
				get
				{
					this.m_frmProfiles = MyProject.MyForms.Create__Instance__<frmProfiles>(this.m_frmProfiles);
					return this.m_frmProfiles;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmProfiles)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmProfiles>(ref this.m_frmProfiles);
					}
				}
			}

			// Token: 0x17000358 RID: 856
			// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0005999B File Offset: 0x00057B9B
			// (set) Token: 0x060009F0 RID: 2544 RVA: 0x00059E2A File Offset: 0x0005802A
			public frmProperties frmProperties
			{
				[DebuggerHidden]
				get
				{
					this.m_frmProperties = MyProject.MyForms.Create__Instance__<frmProperties>(this.m_frmProperties);
					return this.m_frmProperties;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmProperties)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmProperties>(ref this.m_frmProperties);
					}
				}
			}

			// Token: 0x17000359 RID: 857
			// (get) Token: 0x060009D3 RID: 2515 RVA: 0x000599B6 File Offset: 0x00057BB6
			// (set) Token: 0x060009F1 RID: 2545 RVA: 0x00059E56 File Offset: 0x00058056
			public frmRemoveProgress frmRemoveProgress
			{
				[DebuggerHidden]
				get
				{
					this.m_frmRemoveProgress = MyProject.MyForms.Create__Instance__<frmRemoveProgress>(this.m_frmRemoveProgress);
					return this.m_frmRemoveProgress;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmRemoveProgress)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmRemoveProgress>(ref this.m_frmRemoveProgress);
					}
				}
			}

			// Token: 0x1700035A RID: 858
			// (get) Token: 0x060009D4 RID: 2516 RVA: 0x000599D1 File Offset: 0x00057BD1
			// (set) Token: 0x060009F2 RID: 2546 RVA: 0x00059E82 File Offset: 0x00058082
			public FrmSetFallback FrmSetFallback
			{
				[DebuggerHidden]
				get
				{
					this.m_FrmSetFallback = MyProject.MyForms.Create__Instance__<FrmSetFallback>(this.m_FrmSetFallback);
					return this.m_FrmSetFallback;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_FrmSetFallback)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<FrmSetFallback>(ref this.m_FrmSetFallback);
					}
				}
			}

			// Token: 0x1700035B RID: 859
			// (get) Token: 0x060009D5 RID: 2517 RVA: 0x000599EC File Offset: 0x00057BEC
			// (set) Token: 0x060009F3 RID: 2547 RVA: 0x00059EAE File Offset: 0x000580AE
			public frmSetLibraryPath frmSetLibraryPath
			{
				[DebuggerHidden]
				get
				{
					this.m_frmSetLibraryPath = MyProject.MyForms.Create__Instance__<frmSetLibraryPath>(this.m_frmSetLibraryPath);
					return this.m_frmSetLibraryPath;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmSetLibraryPath)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmSetLibraryPath>(ref this.m_frmSetLibraryPath);
					}
				}
			}

			// Token: 0x1700035C RID: 860
			// (get) Token: 0x060009D6 RID: 2518 RVA: 0x00059A07 File Offset: 0x00057C07
			// (set) Token: 0x060009F4 RID: 2548 RVA: 0x00059EDA File Offset: 0x000580DA
			public frmSSChanged frmSSChanged
			{
				[DebuggerHidden]
				get
				{
					this.m_frmSSChanged = MyProject.MyForms.Create__Instance__<frmSSChanged>(this.m_frmSSChanged);
					return this.m_frmSSChanged;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmSSChanged)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmSSChanged>(ref this.m_frmSSChanged);
					}
				}
			}

			// Token: 0x1700035D RID: 861
			// (get) Token: 0x060009D7 RID: 2519 RVA: 0x00059A22 File Offset: 0x00057C22
			// (set) Token: 0x060009F5 RID: 2549 RVA: 0x00059F06 File Offset: 0x00058106
			public frmStartupType frmStartupType
			{
				[DebuggerHidden]
				get
				{
					this.m_frmStartupType = MyProject.MyForms.Create__Instance__<frmStartupType>(this.m_frmStartupType);
					return this.m_frmStartupType;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmStartupType)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmStartupType>(ref this.m_frmStartupType);
					}
				}
			}

			// Token: 0x1700035E RID: 862
			// (get) Token: 0x060009D8 RID: 2520 RVA: 0x00059A3D File Offset: 0x00057C3D
			// (set) Token: 0x060009F6 RID: 2550 RVA: 0x00059F32 File Offset: 0x00058132
			public frmStillRunningToast frmStillRunningToast
			{
				[DebuggerHidden]
				get
				{
					this.m_frmStillRunningToast = MyProject.MyForms.Create__Instance__<frmStillRunningToast>(this.m_frmStillRunningToast);
					return this.m_frmStillRunningToast;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmStillRunningToast)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmStillRunningToast>(ref this.m_frmStillRunningToast);
					}
				}
			}

			// Token: 0x1700035F RID: 863
			// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00059A58 File Offset: 0x00057C58
			// (set) Token: 0x060009F7 RID: 2551 RVA: 0x00059F5E File Offset: 0x0005815E
			public frmUpdateToast frmUpdateToast
			{
				[DebuggerHidden]
				get
				{
					this.m_frmUpdateToast = MyProject.MyForms.Create__Instance__<frmUpdateToast>(this.m_frmUpdateToast);
					return this.m_frmUpdateToast;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmUpdateToast)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmUpdateToast>(ref this.m_frmUpdateToast);
					}
				}
			}

			// Token: 0x17000360 RID: 864
			// (get) Token: 0x060009DA RID: 2522 RVA: 0x00059A73 File Offset: 0x00057C73
			// (set) Token: 0x060009F8 RID: 2552 RVA: 0x00059F8A File Offset: 0x0005818A
			public frmVoiceSettings frmVoiceSettings
			{
				[DebuggerHidden]
				get
				{
					this.m_frmVoiceSettings = MyProject.MyForms.Create__Instance__<frmVoiceSettings>(this.m_frmVoiceSettings);
					return this.m_frmVoiceSettings;
				}
				[DebuggerHidden]
				set
				{
					if (value != this.m_frmVoiceSettings)
					{
						if (value != null)
						{
							throw new ArgumentException("Property can only be set to Nothing");
						}
						this.Dispose__Instance__<frmVoiceSettings>(ref this.m_frmVoiceSettings);
					}
				}
			}

			// Token: 0x04000422 RID: 1058
			[ThreadStatic]
			private static Hashtable m_FormBeingCreated;

			// Token: 0x04000423 RID: 1059
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmAbout m_frmAbout;

			// Token: 0x04000424 RID: 1060
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmAddCustomVoice m_frmAddCustomVoice;

			// Token: 0x04000425 RID: 1061
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmAddVoiceProfile m_frmAddVoiceProfile;

			// Token: 0x04000426 RID: 1062
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmCreateEditProfile m_frmCreateEditProfile;

			// Token: 0x04000427 RID: 1063
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmDonate m_frmDonate;

			// Token: 0x04000428 RID: 1064
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmDownloading m_frmDownloading;

			// Token: 0x04000429 RID: 1065
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmEditAllSelected m_frmEditAllSelected;

			// Token: 0x0400042A RID: 1066
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmEditVoiceCommand m_frmEditVoiceCommand;

			// Token: 0x0400042B RID: 1067
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmHomeless m_frmHomeless;

			// Token: 0x0400042C RID: 1068
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmHomeTrayToast m_frmHomeTrayToast;

			// Token: 0x0400042D RID: 1069
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmHotKeys m_frmHotKeys;

			// Token: 0x0400042E RID: 1070
			[EditorBrowsable(EditorBrowsableState.Never)]
			public FrmIgnoredApps m_FrmIgnoredApps;

			// Token: 0x0400042F RID: 1071
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmImportSteamApps m_frmImportSteamApps;

			// Token: 0x04000430 RID: 1072
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmLaunchOptions m_frmLaunchOptions;

			// Token: 0x04000431 RID: 1073
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmLibrary m_frmLibrary;

			// Token: 0x04000432 RID: 1074
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmLinkPresets m_frmLinkPresets;

			// Token: 0x04000433 RID: 1075
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmLoading m_frmLoading;

			// Token: 0x04000434 RID: 1076
			[EditorBrowsable(EditorBrowsableState.Never)]
			public FrmMain m_FrmMain;

			// Token: 0x04000435 RID: 1077
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmMicNotDefaultWarning m_frmMicNotDefaultWarning;

			// Token: 0x04000436 RID: 1078
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmProcessing m_frmProcessing;

			// Token: 0x04000437 RID: 1079
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmProfiles m_frmProfiles;

			// Token: 0x04000438 RID: 1080
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmProperties m_frmProperties;

			// Token: 0x04000439 RID: 1081
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmRemoveProgress m_frmRemoveProgress;

			// Token: 0x0400043A RID: 1082
			[EditorBrowsable(EditorBrowsableState.Never)]
			public FrmSetFallback m_FrmSetFallback;

			// Token: 0x0400043B RID: 1083
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmSetLibraryPath m_frmSetLibraryPath;

			// Token: 0x0400043C RID: 1084
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmSSChanged m_frmSSChanged;

			// Token: 0x0400043D RID: 1085
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmStartupType m_frmStartupType;

			// Token: 0x0400043E RID: 1086
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmStillRunningToast m_frmStillRunningToast;

			// Token: 0x0400043F RID: 1087
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmUpdateToast m_frmUpdateToast;

			// Token: 0x04000440 RID: 1088
			[EditorBrowsable(EditorBrowsableState.Never)]
			public frmVoiceSettings m_frmVoiceSettings;
		}

		// Token: 0x02000064 RID: 100
		[EditorBrowsable(EditorBrowsableState.Never)]
		[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
		internal sealed class MyWebServices
		{
			// Token: 0x060009F9 RID: 2553 RVA: 0x00059FB8 File Offset: 0x000581B8
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override bool Equals(object o)
			{
				return base.Equals(RuntimeHelpers.GetObjectValue(o));
			}

			// Token: 0x060009FA RID: 2554 RVA: 0x00059FD8 File Offset: 0x000581D8
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x060009FB RID: 2555 RVA: 0x00059FF0 File Offset: 0x000581F0
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			internal new Type GetType()
			{
				return typeof(MyProject.MyWebServices);
			}

			// Token: 0x060009FC RID: 2556 RVA: 0x0005A00C File Offset: 0x0005820C
			[EditorBrowsable(EditorBrowsableState.Never)]
			[DebuggerHidden]
			public override string ToString()
			{
				return base.ToString();
			}

			// Token: 0x060009FD RID: 2557 RVA: 0x0005A024 File Offset: 0x00058224
			[DebuggerHidden]
			private static T Create__Instance__<T>(T instance) where T : new()
			{
				bool flag = instance == null;
				T t;
				if (flag)
				{
					t = new T();
				}
				else
				{
					t = instance;
				}
				return t;
			}

			// Token: 0x060009FE RID: 2558 RVA: 0x0005A04D File Offset: 0x0005824D
			[DebuggerHidden]
			private void Dispose__Instance__<T>(ref T instance)
			{
				instance = default(T);
			}

			// Token: 0x060009FF RID: 2559 RVA: 0x000596EB File Offset: 0x000578EB
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public MyWebServices()
			{
			}
		}

		// Token: 0x02000065 RID: 101
		[EditorBrowsable(EditorBrowsableState.Never)]
		[ComVisible(false)]
		internal sealed class ThreadSafeObjectProvider<T> where T : new()
		{
			// Token: 0x17000361 RID: 865
			// (get) Token: 0x06000A00 RID: 2560 RVA: 0x0005A058 File Offset: 0x00058258
			internal T GetInstance
			{
				[DebuggerHidden]
				get
				{
					bool flag = MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue == null;
					if (flag)
					{
						MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue = new T();
					}
					return MyProject.ThreadSafeObjectProvider<T>.m_ThreadStaticValue;
				}
			}

			// Token: 0x06000A01 RID: 2561 RVA: 0x000596EB File Offset: 0x000578EB
			[DebuggerHidden]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public ThreadSafeObjectProvider()
			{
			}

			// Token: 0x04000441 RID: 1089
			[CompilerGenerated]
			[ThreadStatic]
			private static T m_ThreadStaticValue;
		}
	}
}
