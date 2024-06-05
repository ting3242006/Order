using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace 點餐
{
    internal class Order
    {
        private static List<Item> list = new List<Item>();

        // option 是 discountType
        public static void AddOrder(Item item, string option)
        {
            Discount discount = new Discount();
            //新增:如果沒有這個品項，就要新增
            //修改:有此商品，但商品數量改變
            //刪除:商品數量為0時，要刪除該品項

            //bool hasItem = list.Any(x => x.Name == item.Name);
            // 使用 FirstOrDefault 才不會閃退
            Item product = list.FirstOrDefault(x => x.Name == item.Name);

            if (product == null && item.Quantity != 0) // 新增
            {
                list.Add(item);
                discount.DiscountOrder(option, list);
                // discountOrder
                ShowPanel.NotifyRenderItem(list);
                return;
            }

            if (product != null && item.Quantity == 0) // 刪除
            {
                discount.DiscountOrder(option, list);
                list.Remove(product);
                ShowPanel.NotifyRenderItem(list);
                return;
            }

            if (product != null && item.Quantity != 0)   // 修改
            {

                product.Quantity = item.Quantity;
                product.SubTotal = item.Price * item.Quantity;
                discount.DiscountOrder(option, list);
                ShowPanel.NotifyRenderItem(list);
            }

        }

        public static List<Item> GetOrderItems()
        {
            return list;
        }

        public static int GetTotalPrice()
        {
            int total = 0;

            foreach (Item item in list)
            {
                total += item.SubTotal;
            }
            return total;
        }


    }
}
