using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐
{
    public static class FlowLayoutPanelExtensions
    {
        public static void AddCheckBoxes(this FlowLayoutPanel panel, params string[] items)
        {
            foreach (string item in items)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item;
                panel.Controls.Add(checkBox);
            }
        }

        public static int GetTotalPrice(this FlowLayoutPanel panel)
        {
            int total = 0;
            total += panel.Controls.OfType<CheckBox>().Where(cb => cb.Checked).Sum(cb => cb.GetPrice());
            return total;
        }
    }
}
