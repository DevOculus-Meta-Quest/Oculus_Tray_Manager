using System;
using System.Windows.Forms;

namespace OculusTrayTool
{
	// Token: 0x0200000F RID: 15
	public class MyCustomToolStripControlHost : ToolStripControlHost
	{
		// Token: 0x06000171 RID: 369 RVA: 0x00006D16 File Offset: 0x00004F16
		public MyCustomToolStripControlHost()
			: base(new Control())
		{
		}

		// Token: 0x06000172 RID: 370 RVA: 0x00006D25 File Offset: 0x00004F25
		public MyCustomToolStripControlHost(Control c)
			: base(c)
		{
		}
	}
}
