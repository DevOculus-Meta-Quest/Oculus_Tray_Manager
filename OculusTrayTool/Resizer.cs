#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool;

public class Resizer
{
	private struct ControlInfo
	{
		public string name;

		public string parentName;

		public int originalHeight;

		public int originalWidth;

		public float originalFontSize;
	}

	private Dictionary<string, ControlInfo> ctrlDict;

	public Resizer()
	{
		ctrlDict = new Dictionary<string, ControlInfo>();
	}

	public void FindAllControls(Control thisCtrl)
	{
		foreach (Control control in thisCtrl.Controls)
		{
			try
			{
				if (!Information.IsNothing(control.Parent) && (control is Label || control is ComboBox || control is Button || control is CheckBox || control is ListBox || control is RichTextBox || control is DotNetBarTabcontrol) && ((Operators.CompareString(control.Name, "Label8", TextCompare: false) != 0) & (Operators.CompareString(control.Name, "Button2", TextCompare: false) != 0) & (Operators.CompareString(control.Name, "LabelPropertiesFilename", TextCompare: false) != 0) & (Operators.CompareString(control.Name, "LabelProperties", TextCompare: false) != 0) & (Operators.CompareString(control.Name, "LabelProperties2", TextCompare: false) != 0)))
				{
					ControlInfo value = default(ControlInfo);
					value.name = control.Name;
					value.parentName = control.Parent.Name;
					value.originalFontSize = control.Font.Size;
					value.originalHeight = control.Height;
					value.originalWidth = control.Width;
					ctrlDict.Add(value.name, value);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Debug.Print(ex2.Message);
				ProjectData.ClearProjectError();
			}
			if (control.Controls.Count > 0)
			{
				FindAllControls(control);
			}
		}
	}

	public void ResizeAllControls(Control thisCtrl, float Ratio)
	{
		foreach (Control control in thisCtrl.Controls)
		{
			try
			{
				if (!Information.IsNothing(control.Parent))
				{
					ControlInfo value = default(ControlInfo);
					bool flag = false;
					try
					{
						if (ctrlDict.TryGetValue(control.Name, out value))
						{
							Font font = control.Font;
							control.Font = new Font(font.FontFamily, Ratio, font.Style);
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			if (control.Controls.Count > 0)
			{
				ResizeAllControls(control, Ratio);
			}
		}
	}
}
