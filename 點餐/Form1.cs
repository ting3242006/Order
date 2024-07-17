using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 點餐.MenuModel;

namespace 點餐
{
    public partial class Form1 : Form
    {
        private const int DefaultPanelWidth = 300;
        private Discount discount;
        private List<Strategy> strategies;

        public Form1()
        {
            InitializeComponent();
            discount = new Discount();
            strategies = new List<Strategy>();
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
            string path = ConfigurationManager.AppSettings["path"]; // 從配置文件中獲取 Json 路徑
            string json = File.ReadAllText(path, Encoding.UTF8); // 讀取 Json 內容
            MenuModel menuModel = JsonConvert.DeserializeObject<MenuModel>(json); // 反序列化 JSON

            AddMenuItemsToPanel(flowLayoutPanel1, menuModel.Menus);


            //雞排飯買二送一
            //咖哩飯買兩個送草莓鬆餅
            //排骨飯三個300
            //雞絲飯搭滷味70元
            //排骨飯搭奶茶120元
            //排骨飯買三個打85折
            //全場打8折

            List<KeyValueModel> list = new List<KeyValueModel>();

            // 7/3 HW: 動態生成折扣的策略，可以選取使用
            foreach (var stragedy in menuModel.Strategies)
            {
                KeyValueModel key = new KeyValueModel(stragedy.name, stragedy);
                list.Add(key);
            }

            //6/12 HW: 訂折扣方法的 Json 規格
            //List<KeyValueModel> list = new List<KeyValueModel>()
            //{
            //    new KeyValueModel("雞排飯買二送一", "點餐.ChickenRiceBuyTwoGetOneDiscount"),
            //    new KeyValueModel("咖哩飯買兩個送草莓鬆餅", "點餐.CurryRiceBuyTwoGetStrawberryPancakeDiscount"),
            //    new KeyValueModel("排骨飯三個300", "點餐.RibRiceThreeFor300Discount"),
            //    new KeyValueModel("雞絲飯搭滷味70元", "點餐.ChickenRiceWithBraisedFood70Discount"),
            //    new KeyValueModel("排骨飯搭奶茶120元", "點餐.SpareRibsRiceWithMilkTea120Discount"),
            //    new KeyValueModel("全場打8折", "點餐.AllItemDiscountBy20Percent"),
            //    new KeyValueModel("草莓鬆餅搭奶茶9折", "點餐.AllItemDiscountBy20Percent")
            //};

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            Controls.Add(comboBox1);

            EventHandlers.RenderPanel += UpdatePanel;
            //    ShowPanel.NotifyRenderItem(Order.GetOrderItems());
        }



        private void AddMenuItemsToPanel(FlowLayoutPanel panel, 點餐.MenuModel.Menu[] menus)
        {
            panel.Controls.Clear();

            foreach (var menu in menus)
            {
                Label titleLabel = new Label();
                titleLabel.Text = menu.Type;
                FlowLayoutPanel outsidePanel = new FlowLayoutPanel();
                outsidePanel.Height = 200;
                outsidePanel.Controls.Add(titleLabel);

                foreach (var item in menu.Items)
                {

                    FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                    flowLayoutPanel.AddCheckboxWithNumericUpDown(CheckedChange, ValueChange, $"{item.Name}${item.Price}");
                    flowLayoutPanel.Height = 30;

                    outsidePanel.Controls.Add(flowLayoutPanel);
                }
                panel.Controls.Add(outsidePanel);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Strategy discountType = (Strategy)comboBox1.SelectedValue;
            if (discountType != null)
            {
                discount.DiscountOrder(discountType, Order.GetOrderItems());
                UpdateTotalPrice();
            }
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
            Order.AddOrder(item, (Strategy)comboBox1.SelectedValue);

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
