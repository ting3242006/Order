using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class Discount
    {
        public void DiscountOrder(string discountType, List<Item> list)
        {

            list.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("折扣"));

            // 看小算盤專案 DESIGN PATTERN 架構來復現在這個專案
            // Simple Factory Design Pattern
            // 抽象\工廠\其他六個
            // 開八個類別
            // ShowPanel.NotifyRenderItem(list);
            Type t = Type.GetType(discountType);

            IDiscount discount = (IDiscount)Activator.CreateInstance(t); //DiscountFactory.CreateDiscount(discountType);
            discount.ApplyDiscount(list);

            ShowPanel.NotifyRenderItem(list);
        }
    }
}
