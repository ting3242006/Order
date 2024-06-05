using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐
{
    internal class ShowPanel
    {
        // 5/15 HW: 要挪到ShowPanel類別
        public static void AddItemToPanel5(FlowLayoutPanel panel, string itemName, int itemPrice, int quantity, int subtotal, string note)
        {
            FlowLayoutPanel flowpanel = new FlowLayoutPanel();
            flowpanel.Width = 400;
            flowpanel.Height = 20;

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

            flowpanel.Controls.Add(nameLabel);
            flowpanel.Controls.Add(priceLabel);
            flowpanel.Controls.Add(quantityLabel);
            flowpanel.Controls.Add(subtotalLabel);
            flowpanel.Controls.Add(noteLabel);

            panel.Controls.Add(flowpanel);
        }

        // 5/15 HW: ShowPanel要做的事情

        public static void NotifyRenderItem(List<Item> list)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Width = 400;
            panel.Height = 800;
            SetupTitleLabel(panel);

            foreach (Item item in list)
            {
                AddItemToPanel5(panel, item.Name, item.Price, item.Quantity, item.SubTotal, "-");
            }
            EventHandlers.Notify(panel);
        }



        public static void SetupTitleLabel(FlowLayoutPanel panel5)
        {
            Label nameLabel = new Label();
            nameLabel.Text = "品名";
            nameLabel.Width = 70;
            nameLabel.Font = new Font(nameLabel.Font, FontStyle.Bold);

            Label priceLabel = new Label();
            priceLabel.Text = "單價";
            priceLabel.Width = 40;
            priceLabel.Font = new Font(priceLabel.Font, FontStyle.Bold);

            Label quantityLabel = new Label();
            quantityLabel.Text = "數量";
            quantityLabel.Width = 40;
            quantityLabel.Font = new Font(quantityLabel.Font, FontStyle.Bold);

            Label subTotalLabel = new Label();
            subTotalLabel.Text = "小計";
            subTotalLabel.Width = 40;
            subTotalLabel.Font = new Font(subTotalLabel.Font, FontStyle.Bold);

            Label noteLabel = new Label();
            noteLabel.Text = "備註";
            noteLabel.Width = 40;
            noteLabel.Font = new Font(noteLabel.Font, FontStyle.Bold);

            panel5.Controls.Add(nameLabel);
            panel5.Controls.Add(priceLabel);
            panel5.Controls.Add(quantityLabel);
            panel5.Controls.Add(subTotalLabel);
            panel5.Controls.Add(noteLabel);
        }
    }
}
