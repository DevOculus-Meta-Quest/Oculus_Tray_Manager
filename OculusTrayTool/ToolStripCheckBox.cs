using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace OculusTrayTool;

[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.StatusStrip)]
public class ToolStripCheckBox : MyCustomToolStripControlHost
{
	public CheckBox CheckBoxControl => base.Control as CheckBox;

	public bool Checked
	{
		get
		{
			return CheckBoxControl.Checked;
		}
		set
		{
			CheckBoxControl.Checked = value;
		}
	}

	public event EventHandler CheckedChanged;

	public ToolStripCheckBox()
		: base(new CheckBox())
	{
		BackColor = Color.Transparent;
	}

	protected override void OnSubscribeControlEvents(Control c)
	{
		base.OnSubscribeControlEvents(c);
		CheckBox checkBox = (CheckBox)c;
		checkBox.CheckedChanged += OnCheckedChanged;
	}

	protected override void OnUnsubscribeControlEvents(Control c)
	{
		base.OnUnsubscribeControlEvents(c);
		CheckBox checkBox = (CheckBox)c;
		checkBox.CheckedChanged -= OnCheckedChanged;
	}

	private void OnCheckedChanged(object sender, EventArgs e)
	{
		CheckedChanged?.Invoke(this, e);
	}
}
