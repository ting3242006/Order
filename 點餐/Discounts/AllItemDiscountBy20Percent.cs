using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class AllItemDiscountBy20Percent : IDiscountStrategy
    {
        public void ApplyDiscount(List<Item> items)
        {
            List<Item> discountItems = new List<Item>();
            foreach (Item item in items)
            {
                Item discountItem = new Item($"(折扣){item.Name}", -(item.Price * item.Quantity * 20 / 100), 1);
                discountItems.Add(discountItem);
            }
            items.AddRange(discountItems);
        }
    }
}
