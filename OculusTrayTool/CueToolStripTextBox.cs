using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

[DesignerGenerated]
public class CueToolStripTextBox : ToolStripTextBox
{
	private IContainer components;

	private static uint ECM_FIRST = 5376u;

	private static uint EM_SETCUEBANNER;

	private string m_cueText;

	private bool m_showCueTextWithFocus;

	[Description("The text value to be displayed as a cue to the user.")]
	[Category("Appearance")]
	[DefaultValue("")]
	[Localizable(true)]
	public string CueText
	{
		get
		{
			return m_cueText;
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (!m_cueText.Equals(value, StringComparison.CurrentCulture))
			{
				m_cueText = value;
				UpdateCue();
				OnCueTextChanged(EventArgs.Empty);
			}
		}
	}

	[Description("Indicates whether the CueText will be displayed even when the control has focus.")]
	[Category("Appearance")]
	[DefaultValue(false)]
	[Localizable(true)]
	public bool ShowCueTextWithFocus
	{
		get
		{
			return m_showCueTextWithFocus;
		}
		set
		{
			if (m_showCueTextWithFocus != value)
			{
				m_showCueTextWithFocus = value;
				UpdateCue();
				OnShowCueTextWithFocusChanged(EventArgs.Empty);
			}
		}
	}

	public event EventHandler CueTextChanged;

	public event EventHandler ShowCueTextWithFocusChanged;

	static CueToolStripTextBox()
	{
		checked
		{
			EM_SETCUEBANNER = (uint)(unchecked((long)ECM_FIRST) + 1L);
		}
	}

	private void InitializeComponent()
	{
		components = new Container();
	}

	public CueToolStripTextBox()
	{
		components = null;
		m_cueText = string.Empty;
		m_showCueTextWithFocus = false;
		if (base.Control != null)
		{
			base.Control.HandleCreated += OnControlHandleCreated;
		}
	}

	public CueToolStripTextBox(string name)
		: base(name)
	{
		components = null;
		m_cueText = string.Empty;
		m_showCueTextWithFocus = false;
		if (base.Control != null)
		{
			base.Control.HandleCreated += OnControlHandleCreated;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && base.Control != null)
		{
			base.Control.HandleCreated -= OnControlHandleCreated;
		}
		base.Dispose(disposing);
	}

	public void OnControlHandleCreated(object sender, EventArgs e)
	{
		UpdateCue();
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, string lParam);

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnCueTextChanged(EventArgs e)
	{
		CueTextChanged?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnShowCueTextWithFocusChanged(EventArgs e)
	{
		ShowCueTextWithFocusChanged?.Invoke(this, e);
	}

	private void UpdateCue()
	{
		if (base.Control != null && base.Control.IsHandleCreated)
		{
			SendMessage(new HandleRef(base.Control, base.Control.Handle), EM_SETCUEBANNER, m_showCueTextWithFocus ? new IntPtr(1) : IntPtr.Zero, m_cueText);
		}
	}
}
