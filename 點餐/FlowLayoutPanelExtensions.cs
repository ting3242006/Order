using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public static void AddCheckboxWithNumericUpDown(this FlowLayoutPanel panel, params string[] items)
        {
            foreach (string item in items)
            {
                CheckBox checkbox = new CheckBox();
                checkbox.Text = item;
                panel.Controls.Add(checkbox);

                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Minimum = 0;
                numericUpDown.Maximum = 10;
                numericUpDown.Value = 0;
                panel.Controls.Add(numericUpDown);
            }
        }

        public static int GetTotalPrice(this FlowLayoutPanel panel)
        {
            int total = 0;

            for (int i = 0; i < panel.Controls.Count; i += 2)
            {
                CheckBox checkBox = panel.Controls[i] as CheckBox;
                if (checkBox != null && checkBox.Checked)
                {
                    int quantity = (int)(panel.Controls[i + 1] as NumericUpDown).Value;
                    int price = checkBox.GetPrice();
                    total += quantity * price;
                }
            }
            //total += panel.Controls.OfType<CheckBox>().Where(cb => cb.Checked).Sum(cb => cb.GetPrice());
            return total;
        }
    }
}

