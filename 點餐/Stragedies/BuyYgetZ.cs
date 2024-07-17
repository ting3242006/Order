using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐.Stragedies
{
    internal class BuyYgetZ : IStrategy
    {
        public void ApplyDiscountStrategy(List<Item> items, MenuModel.Strategy strategy)
        {
            Item item = items.FirstOrDefault(x => x.Name == strategy.buyYgetZ.mainItem);
            if (item != null)
            {
                int freeCount = item.Quantity;
                if (freeCount / strategy.buyYgetZ.quantity > 0)
                {
                    Item free = new Item($"(贈送){strategy.buyYgetZ.subItem}", 0, freeCount / strategy.buyYgetZ.quantity);
                    items.Add(free);
                }
            }
        }
    }
}
