using System.Windows.Forms;

namespace OculusTrayTool;

public class MyCustomToolStripControlHost : ToolStripControlHost
{
	public MyCustomToolStripControlHost()
		: base(new Control())
	{
	}

	public MyCustomToolStripControlHost(Control c)
		: base(c)
	{
	}
}
