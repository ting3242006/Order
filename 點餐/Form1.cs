using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐
{
    public partial class Form1 : Form
    {
        // HW : 建立Class 思考如何做到前後端分離
        // HW2: 研究擴充方法 思考如何做到前後端分離
        private Dictionary<string, int> prices = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "0";
            calculateTotal();
        }

        private void calculateTotal()
        {
            int total = 0;

            total += flowLayoutPanel1.GetTotalPrice();
            total += flowLayoutPanel2.GetTotalPrice();
            total += flowLayoutPanel3.GetTotalPrice();
            total += flowLayoutPanel4.GetTotalPrice();

            label1.Text = total.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AddCheckboxWithNumericUpDown("雞排飯90", "咖哩飯100", "排骨飯110", "雞絲飯40");
            flowLayoutPanel2.AddCheckboxWithNumericUpDown("玉米濃湯40", "滷味35", "海帶芽30");
            flowLayoutPanel3.AddCheckboxWithNumericUpDown("紅茶30", "綠茶30", "奶茶40", "青茶30", "多多40");
            flowLayoutPanel4.AddCheckboxWithNumericUpDown("伯爵蛋糕120", "草莓鬆餅70", "抹茶鬆餅70", "巧克力厚片35");
        }
    }
}
