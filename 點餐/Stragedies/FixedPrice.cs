using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐.Stragedies
{
    internal class FixedPrice : IStrategy
    {
        public void ApplyDiscountStrategy(List<Item> items, MenuModel.Strategy strategy)
        {
            Item item = items.FirstOrDefault(x => x.Name == strategy.fixedPrice.mainItem);
            if (item != null)
            {
                int discountCount = item.Quantity / strategy.fixedPrice.quantity;

                if (discountCount > 0)
                {
                    Item discountItem = new Item($"(折扣){item.Name}", strategy.fixedPrice.price, discountCount);
                    items.Add(discountItem);
                }
            }
        }
    }
}
