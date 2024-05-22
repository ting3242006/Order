using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐
{
    internal class EventHandlers
    {
        public static event EventHandler<FlowLayoutPanel> RenderPanel;

        public static void Notify(FlowLayoutPanel panel)
        {
            RenderPanel.Invoke(null, panel);

        }
    }
}
