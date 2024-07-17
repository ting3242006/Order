using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class StrawberryPancakeWithMilkTea10PercentOff : IDiscountStrategy
    {
        public void ApplyDiscount(List<Item> items)
        {
            Item pancakeItem = items.FirstOrDefault(x => x.Name == "草莓鬆餅");
            Item milkTeaItem = items.FirstOrDefault(x => x.Name == "奶茶");

            if (pancakeItem != null && milkTeaItem != null)
            {

                int discountQuantity = Math.Min(pancakeItem.Quantity, milkTeaItem.Quantity);
                if (discountQuantity > 0)
                {
                    decimal discountRate = 0.9m;
                    decimal discountAmount = (pancakeItem.Price + milkTeaItem.Price) * discountRate * discountQuantity;
                    Item discountItem = new Item("(折扣)草莓鬆餅搭奶茶", -(int)discountAmount, discountQuantity);
                    items.Add(discountItem);
                }
            }
        }
    }
}
