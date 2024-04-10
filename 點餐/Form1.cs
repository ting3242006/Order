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
        // HW : 在不依賴GPT的情況下，重構一版程式碼
        public Form1()
        {
            InitializeComponent();
            SetupTitleLabel();
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
            flowLayoutPanel1.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, "雞排飯90", "咖哩飯100", "排骨飯110", "雞絲飯40");
            flowLayoutPanel2.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, "玉米濃湯40", "滷味35", "海帶芽30");
            flowLayoutPanel3.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, "紅茶30", "綠茶30", "奶茶40", "青茶30", "多多40");
            flowLayoutPanel4.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, "伯爵蛋糕120", "草莓鬆餅70", "抹茶鬆餅70", "巧克力厚片35");
            flowLayoutPanel1.Width = 300;
            flowLayoutPanel2.Width = 300;
            flowLayoutPanel3.Width = 300;
            flowLayoutPanel4.Width = 300;
        }

        private void AddItemToPanel5(string itemName, int itemPrice, int quantity, int subtotal, string note)
        {
            FlowLayoutPanel panel5 = flowLayoutPanel5;

            Label nameLabel = new Label();
            nameLabel.Text = itemName;
            nameLabel.Width = 70;

            Label priceLabel = new Label();
            priceLabel.Text = itemPrice.ToString();
            priceLabel.Width = 40;

            Label quantityLabel = new Label();
            quantityLabel.Text = quantity.ToString();
            quantityLabel.Width = 40;

            Label subtotalLabel = new Label();
            subtotalLabel.Text = subtotal.ToString();
            subtotalLabel.Width = 40;

            Label noteLabel = new Label();
            noteLabel.Text = note;
            noteLabel.Width = 40;

            panel5.Controls.Add(nameLabel);
            panel5.Controls.Add(priceLabel);
            panel5.Controls.Add(quantityLabel);
            panel5.Controls.Add(subtotalLabel);
            panel5.Controls.Add(noteLabel);
        }

        public void CheckedChange(object sender, EventArgs e)
        {

            CheckBox checkBox = (CheckBox)sender;
            Control parent = checkBox.Parent;
            NumericUpDown numericUpDown = parent.Controls[1] as NumericUpDown;
            if (checkBox.Checked)
            {
                numericUpDown.Value = 1;
                SetupTitleLabel();
                ResetAllLabel();
            }
            else
            {
                numericUpDown.Value = 0;
            }
            calculateTotal();
        }
        public void ValueChange(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            Control parent = numericUpDown.Parent;
            CheckBox checkBox = parent.Controls[0] as CheckBox;
            int quantity = (int)numericUpDown.Value;

            if (numericUpDown.Value != 0)
            {
                checkBox.Checked = true;

                if (quantity > 0)
                {
                    ResetAllLabel();
                }
            }
            else
            {
                checkBox.Checked = false;
                ResetAllLabel();
            }
            calculateTotal();
        }

        private void ResetAllLabel()
        {
            flowLayoutPanel5.Controls.Clear();
            SetupTitleLabel();
            CheckPanel(flowLayoutPanel1 as FlowLayoutPanel);
            CheckPanel(flowLayoutPanel2 as FlowLayoutPanel);
            CheckPanel(flowLayoutPanel3 as FlowLayoutPanel);
            CheckPanel(flowLayoutPanel4 as FlowLayoutPanel);
        }

        private void CheckPanel(FlowLayoutPanel panels)
        {
            for (int i = 0; i < panels.Controls.Count; i++)
            {
                FlowLayoutPanel panel = panels.Controls[i] as FlowLayoutPanel;

                CheckBox checkBox = panel.Controls[0] as CheckBox;
                NumericUpDown numericUpDown = panel.Controls[1] as NumericUpDown;
                string itemName = checkBox.Text;
                int itemPrice = checkBox.GetPrice();
                int quantity = (int)numericUpDown.Value;
                int subtotal = 0;
                string note = "-";
                if (quantity > 0)
                {
                    AddItemToPanel5(itemName, itemPrice, quantity, subtotal, note);
                }
            }
        }

        private void SetupTitleLabel()
        {
            FlowLayoutPanel panel5 = flowLayoutPanel5;

            Label nameLabel = new Label();
            nameLabel.Text = "品名";
            nameLabel.Width = 70;
            //nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.Font = new Font(nameLabel.Font, FontStyle.Bold);

            Label priceLabel = new Label();
            priceLabel.Text = "單價";
            priceLabel.Width = 40;
            //priceLabel.TextAlign = ContentAlignment.MiddleCenter;
            priceLabel.Font = new Font(priceLabel.Font, FontStyle.Bold);

            Label quantityLabel = new Label();
            quantityLabel.Text = "數量";
            quantityLabel.Width = 40;
            //quantityLabel.TextAlign = ContentAlignment.MiddleCenter;
            quantityLabel.Font = new Font(quantityLabel.Font, FontStyle.Bold);

            Label subTotalLabel = new Label();
            subTotalLabel.Text = "小計";
            subTotalLabel.Width = 40;
            //subTotalLabel.TextAlign = ContentAlignment.MiddleCenter;
            subTotalLabel.Font = new Font(subTotalLabel.Font, FontStyle.Bold);

            Label noteLabel = new Label();
            noteLabel.Text = "備註";
            noteLabel.Width = 40;
            //noteLabel.TextAlign = ContentAlignment.MiddleCenter;
            noteLabel.Font = new Font(noteLabel.Font, FontStyle.Bold);

            panel5.Controls.Add(nameLabel);
            panel5.Controls.Add(priceLabel);
            panel5.Controls.Add(quantityLabel);
            panel5.Controls.Add(subTotalLabel);
            panel5.Controls.Add(noteLabel);
        }
    }
}
