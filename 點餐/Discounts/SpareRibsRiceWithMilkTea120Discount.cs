using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class SpareRibsRiceWithMilkTea120Discount : IDiscountStrategy
    {
        public void ApplyDiscount(List<Item> items)
        {
            Item ribRiceItem = items.FirstOrDefault(x => x.Name == "排骨飯");
            Item milkTeaItem = items.FirstOrDefault(x => x.Name == "奶茶");

            if (ribRiceItem != null && milkTeaItem != null)
            {
                int discountQuantity = Math.Min(ribRiceItem.Quantity, milkTeaItem.Quantity);
                if (discountQuantity > 0)
                {
                    Item discountItem = new Item("(折扣)排骨飯搭奶茶", -30, discountQuantity);
                    items.Add(discountItem);
                }
            }
        }
    }
}
