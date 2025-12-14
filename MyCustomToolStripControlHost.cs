
using System.Windows.Forms;

#nullable disable
namespace MetaQuestTrayTool
{
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
}
