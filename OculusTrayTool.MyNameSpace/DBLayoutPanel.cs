using System.ComponentModel;
using System.Windows.Forms;

namespace OculusTrayTool.MyNameSpace;

public class DBLayoutPanel : TableLayoutPanel
{
	public DBLayoutPanel()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}

	public DBLayoutPanel(IContainer container)
	{
		container.Add(this);
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
	}
}
