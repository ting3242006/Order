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

        private OrderManager orderManager;
        public Form1()
        {
            InitializeComponent();
            orderManager = new OrderManager(flowLayoutPanel1, flowLayoutPanel2, flowLayoutPanel3, flowLayoutPanel4);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label1.Text = orderManager.CalculateTotal().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderManager.LoadMenuItems();
        }
    }
}
