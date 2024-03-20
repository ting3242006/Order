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
            // HW : 建立Class 思考如何做到前後端分離
            // HW2: 研究擴充方法 思考如何做到前後端分離
            foreach (Control control in flowLayoutPanel1.Controls)
            {

                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    //string[] parts = checkBox.Text.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    //total += prices[parts[0]];
                    // 雞排飯$70
                    // [0] => 雞排飯
                    // [1] => 70
                    string text = checkBox.Text;
                    //text.Split('$').Last();
                    string number = Regex.Match(text, @"\d+").Value;
                    if (!string.IsNullOrEmpty(number))
                    {
                        total += int.Parse(number);
                    }
                }
            }

            foreach (Control control in flowLayoutPanel2.Controls)
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

            foreach (Control control in flowLayoutPanel3.Controls)
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

            foreach (Control control in flowLayoutPanel4.Controls)
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

            label1.Text = total.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //prices.Add("雞排飯", 80);
            //prices.Add("咖哩飯", 100);
            //prices.Add("排骨飯", 90);
            //prices.Add("雞絲飯", 40);
            //prices.Add("玉米濃湯", 35);
            //prices.Add("滷味", 30);
            //prices.Add("海帶芽", 30);
            //prices.Add("紅茶", 30);
            //prices.Add("綠茶", 30);
            //prices.Add("奶茶", 30);
            //prices.Add("青茶", 30);
            //prices.Add("多多", 30);
            //prices.Add("伯爵蛋糕", 120);
            //prices.Add("草莓鬆餅", 60);
            //prices.Add("抹茶鬆餅", 60);
            //prices.Add("巧克力厚片", 30);

            FlowLayoutPanel mainCoursePanel = flowLayoutPanel1;
            mainCoursePanel.FlowDirection = FlowDirection.TopDown;
            mainCoursePanel.AutoSize = true;

            FlowLayoutPanel sidePanel = flowLayoutPanel2;
            sidePanel.FlowDirection = FlowDirection.TopDown;
            sidePanel.AutoSize = true;

            FlowLayoutPanel drinkPanel = flowLayoutPanel3;
            drinkPanel.FlowDirection = FlowDirection.TopDown;
            drinkPanel.AutoSize = true;

            FlowLayoutPanel dessertPanel = flowLayoutPanel4;
            dessertPanel.FlowDirection = FlowDirection.TopDown;
            dessertPanel.AutoSize = true;

            string[] mainCourses = { "雞排飯90", "咖哩飯100", "排骨飯110", "雞絲飯40" };
            foreach (string course in mainCourses)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = course;
                mainCoursePanel.Controls.Add(checkBox);
            }

            string[] sides = { "玉米濃湯40", "滷味35", "海帶芽30" };
            foreach (string side in sides)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = side;
                sidePanel.Controls.Add(checkBox);
            }

            string[] drinks = { "紅茶30", "綠茶30", "奶茶40", "青茶30", "多多40" };
            foreach (string drink in drinks)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = drink;
                drinkPanel.Controls.Add(checkBox);
            }

            string[] desserts = { "伯爵蛋糕120", "草莓鬆餅70", "抹茶鬆餅70", "巧克力厚片35" };
            foreach (string dessert in desserts)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = dessert;
                dessertPanel.Controls.Add(checkBox);
            }
        }
    }
}
