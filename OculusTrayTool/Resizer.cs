using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace OculusTrayTool
{
	// Token: 0x02000045 RID: 69
	public class Resizer
	{
		// Token: 0x06000585 RID: 1413 RVA: 0x0002D1BF File Offset: 0x0002B3BF
		public Resizer()
		{
			this.ctrlDict = new Dictionary<string, Resizer.ControlInfo>();
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0002D1D4 File Offset: 0x0002B3D4
		public void FindAllControls(Control thisCtrl)
		{
			try
			{
				foreach (object obj in thisCtrl.Controls)
				{
					Control control = (Control)obj;
					try
					{
						bool flag = !Information.IsNothing(control.Parent);
						if (flag)
						{
							bool flag2 = (control is Label) | (control is ComboBox) | (control is Button) | (control is CheckBox) | (control is ListBox) | (control is RichTextBox) | (control is DotNetBarTabcontrol);
							if (flag2)
							{
								bool flag3 = (Operators.CompareString(control.Name, "Label8", false) != 0) & (Operators.CompareString(control.Name, "Button2", false) != 0) & (Operators.CompareString(control.Name, "LabelPropertiesFilename", false) != 0) & (Operators.CompareString(control.Name, "LabelProperties", false) != 0) & (Operators.CompareString(control.Name, "LabelProperties2", false) != 0);
								if (flag3)
								{
									Resizer.ControlInfo controlInfo = default(Resizer.ControlInfo);
									controlInfo.name = control.Name;
									controlInfo.parentName = control.Parent.Name;
									controlInfo.originalFontSize = control.Font.Size;
									controlInfo.originalHeight = control.Height;
									controlInfo.originalWidth = control.Width;
									this.ctrlDict.Add(controlInfo.name, controlInfo);
								}
							}
						}
					}
					catch (Exception ex)
					{
						Debug.Print(ex.Message);
					}
					bool flag4 = control.Controls.Count > 0;
					if (flag4)
					{
						this.FindAllControls(control);
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0002D3D8 File Offset: 0x0002B5D8
		public void ResizeAllControls(Control thisCtrl, float Ratio)
		{
			try
			{
				foreach (object obj in thisCtrl.Controls)
				{
					Control control = (Control)obj;
					try
					{
						bool flag = !Information.IsNothing(control.Parent);
						if (flag)
						{
							Resizer.ControlInfo controlInfo = default(Resizer.ControlInfo);
							try
							{
								bool flag2 = this.ctrlDict.TryGetValue(control.Name, out controlInfo);
								bool flag3 = flag2;
								if (flag3)
								{
									Font font = control.Font;
									control.Font = new Font(font.FontFamily, Ratio, font.Style);
								}
							}
							catch (Exception ex)
							{
							}
						}
					}
					catch (Exception ex2)
					{
					}
					bool flag4 = control.Controls.Count > 0;
					if (flag4)
					{
						this.ResizeAllControls(control, Ratio);
					}
				}
			}
			finally
			{
				IEnumerator enumerator;
				if (enumerator is IDisposable)
				{
					(enumerator as IDisposable).Dispose();
				}
			}
		}

		// Token: 0x04000214 RID: 532
		private Dictionary<string, Resizer.ControlInfo> ctrlDict;

		// Token: 0x02000084 RID: 132
		private struct ControlInfo
		{
			// Token: 0x040004A5 RID: 1189
			public string name;

			// Token: 0x040004A6 RID: 1190
			public string parentName;

			// Token: 0x040004A7 RID: 1191
			public int originalHeight;

			// Token: 0x040004A8 RID: 1192
			public int originalWidth;

			// Token: 0x040004A9 RID: 1193
			public float originalFontSize;
		}
	}
}
