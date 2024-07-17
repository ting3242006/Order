using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐.Stragedies
{
    internal class ComboPrice : IStrategy
    {
        public void ApplyDiscountStrategy(List<Item> items, MenuModel.Strategy strategy)
        {
            Item mainItem = items.FirstOrDefault(x => x.Name == strategy.comboPrice.mainItem);
            Item subItem = items.FirstOrDefault(x => x.Name == strategy.comboPrice.subItem);

            if (mainItem != null && subItem != null)
            {
                // 計算可以享受套餐價格的數量（取最小值）
                int comboQuantity = Math.Min(mainItem.Quantity, subItem.Quantity);
                int comboPrice = mainItem.Price + subItem.Price;

                if (comboQuantity > 0)
                {
                    Item comboItem = new Item($"(折扣){mainItem.Name} 搭 {subItem.Name}", -1 * (comboPrice - strategy.comboPrice.price), comboQuantity);
                    items.Add(comboItem);
                }
            }
        }
    }
}
