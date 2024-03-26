using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐
{
    public class OrderManager
    {
        private Dictionary<string, int> prices = new Dictionary<string, int>();

        private List<FlowLayoutPanel> panels = new List<FlowLayoutPanel>();

        public OrderManager(FlowLayoutPanel mainPanel, FlowLayoutPanel sidePanel, FlowLayoutPanel drinkPanel, FlowLayoutPanel dessertPanel)
        {
            panels.Add(mainPanel);
            panels.Add(sidePanel);
            panels.Add(drinkPanel);
            panels.Add(dessertPanel);
        }

        public void LoadMenuItems()
        {
            // 主餐選項
            string[] mainCourses = { "雞排飯90", "咖哩飯100", "排骨飯110", "雞絲飯40" };
            AddItemsToPanel(0, mainCourses);

            // 副餐選項
            string[] sides = { "玉米濃湯40", "滷味35", "海帶芽30" };
            AddItemsToPanel(1, sides);

            // 飲料選項
            string[] drinks = { "紅茶30", "綠茶30", "奶茶40", "青茶30", "多多40" };
            AddItemsToPanel(2, drinks);

            // 甜點選項
            string[] desserts = { "伯爵蛋糕120", "草莓鬆餅70", "抹茶鬆餅70", "巧克力厚片35" };
            AddItemsToPanel(3, desserts);
        }

        private void AddItemsToPanel(int panelIndex, string[] items)
        {
            FlowLayoutPanel panel = panels[panelIndex];
            panel.FlowDirection = FlowDirection.TopDown;
            panel.AutoSize = true;

            foreach (string item in items)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item;
                panel.Controls.Add(checkBox);
            }
        }

        public int CalculateTotal()
        {
            int total = 0;

            foreach (FlowLayoutPanel panel in panels)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is CheckBox checkBox && checkBox.Checked)
                    {
                        string text = checkBox.Text;
                        string number = Regex.Match(text, @"\d+").Value;
                        if (!string.IsNullOrEmpty(number))
                        {
                            total += int.Parse(number);
                        }
                    }
                }
            }
            return total;
        }
    }
}
