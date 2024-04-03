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
        public static void AddCheckboxWithNumericUpDown(this FlowLayoutPanel panel, EventHandler checkedChanged, EventHandler valueChanged, params string[] items)
        {
            foreach (string item in items)
            {
                FlowLayoutPanel container = new FlowLayoutPanel();
                container.Width = panel.Width;
                container.Height = 50;
                CheckBox checkbox = new CheckBox();
                checkbox.Text = item;
                checkbox.CheckedChanged += checkedChanged;
                container.Controls.Add(checkbox);

                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Minimum = 0;
                numericUpDown.Maximum = 10;
                numericUpDown.Width = 40;
                numericUpDown.Value = 0;
                numericUpDown.ValueChanged += valueChanged;
                container.Controls.Add(numericUpDown);
                panel.Controls.Add(container);
            }
        }

        public static int GetTotalPrice(this FlowLayoutPanel panel)
        {
            int total = 0;

            for (int i = 0; i < panel.Controls.Count; i++)
            {
                FlowLayoutPanel container = panel.Controls[i] as FlowLayoutPanel;

                if (container != null)
                {
                    CheckBox checkBox = container.Controls[0] as CheckBox;
                    NumericUpDown numericUpDown = container.Controls[1] as NumericUpDown;
                    if (checkBox != null && checkBox.Checked)
                    {
                        int quantity = (int)numericUpDown.Value;
                        int price = checkBox.GetPrice();
                        total += quantity * price;
                    }
                }
            }
            //total += panel.Controls.OfType<CheckBox>().Where(cb => cb.Checked).Sum(cb => cb.GetPrice());
            return total;
        }
    }
}

