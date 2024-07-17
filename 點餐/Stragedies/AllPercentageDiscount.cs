using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐.Stragedies
{
    internal class AllPercentageDiscount : IStrategy
    {
        void IStrategy.ApplyDiscountStrategy(List<Item> items, MenuModel.Strategy strategy)
        {
            List<Item> discountItems = new List<Item>();
            foreach (var item in items)
            {
                float discountAmount = item.Price * item.Quantity * (1 - strategy.allPercentageDiscount.discountRate);
                Item discountItem = new Item($"(折扣){item.Name}", (int)-discountAmount, 1);
                discountItems.Add(discountItem);
            }
            items.AddRange(discountItems);
        }
    }
}
