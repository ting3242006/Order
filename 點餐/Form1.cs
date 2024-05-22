using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐
{
    public partial class Form1 : Form
    {
        private const int DefaultPanelWidth = 300;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "0";
        }

        // 5/15 HW: 拿掉結帳按鈕 刪除calculateTotal
        private void UpdateTotalPrice()
        {
            int total = Order.GetTotalPrice();
            label1.Text = total.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {




            flowLayoutPanel1.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, "雞排飯$90", "咖哩飯$100", "排骨飯$110", "雞絲飯$40");
            flowLayoutPanel2.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, "玉米濃湯$40", "滷味$35", "海帶芽$30");
            flowLayoutPanel3.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, "紅茶$30", "綠茶$30", "奶茶$40", "青茶$30", "多多$40");
            flowLayoutPanel4.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, "伯爵蛋糕$120", "草莓鬆餅$70", "抹茶鬆餅$70", "巧克力厚片$35");
            SetPanelWidth(flowLayoutPanel1);
            SetPanelWidth(flowLayoutPanel2);
            SetPanelWidth(flowLayoutPanel3);
            SetPanelWidth(flowLayoutPanel4);

            EventHandlers.RenderPanel += UpdatePanel;
        }

        private void UpdatePanel(object sender, FlowLayoutPanel e)
        {
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Controls.Add(e);
        }

        public void CheckedChange(object sender, EventArgs e)
        {

            CheckBox checkBox = (CheckBox)sender;
            Control parent = checkBox.Parent;
            NumericUpDown numericUpDown = parent.Controls[1] as NumericUpDown;

            // 如果數量為1的話，checkbox要打勾
            numericUpDown.Value = checkBox.Checked == true ? 1 : 0;

            UpdateOrder(checkBox.Text, (int)numericUpDown.Value);
            UpdateTotalPrice();
        }
        public void ValueChange(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            Control parent = numericUpDown.Parent;
            CheckBox checkBox = parent.Controls[0] as CheckBox;
            int quantity = (int)numericUpDown.Value;

            // 如果數量不為0，checkbox要打勾
            checkBox.Checked = quantity > 0 ? true : false;

            UpdateOrder(checkBox.Text, (int)numericUpDown.Value);
            UpdateTotalPrice();
        }

        private void UpdateOrder(string itemName, int quantity)
        {
            // 透過 split 切割$ 取得 品名 價格 數量
            string[] parts = itemName.Split('$');
            string name = parts[0].Trim();
            int price = int.Parse(parts[1].Trim());

            Item item = new Item(name, price, quantity);
            Order.AddOrder(item);

            //ShowPanel.NotifyRenderItem(flowLayoutPanel5);

            // 5/15 HW: 拿掉以下兩個方法
            UpdateTotalPrice();
        }

        private void SetPanelWidth(FlowLayoutPanel panel)
        {
            panel.Width = DefaultPanelWidth;
        }
    }
}
