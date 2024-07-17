using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐.Stragedies
{
    // 買幾送幾
    public class BuyXgetYfree : IStrategy
    {
        void IStrategy.ApplyDiscountStrategy(List<Item> items, MenuModel.Strategy strategy)
        {
            // LinQ
            Item item = items.FirstOrDefault(x => x.Name == strategy.buyXgetY.mainItem);
            // ? 是如果不符合這條件就不會進這個 BLOCK
            if (item != null)
            {
                int freeQuantity = item.Quantity / strategy.buyXgetY.quantity;
                Item free = new Item($"(贈送){strategy.buyXgetY.mainItem}", 0, freeQuantity);
                items.Add(free);
            }
        }
    }
}
