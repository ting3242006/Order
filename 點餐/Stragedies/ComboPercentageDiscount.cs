using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐.Stragedies
{
    internal class ComboPercentageDiscount : IStrategy
    {
        public void ApplyDiscountStrategy(List<Item> items, MenuModel.Strategy strategy)
        {
            Item mainItem = items.FirstOrDefault(x => x.Name == strategy.comboPercentageDiscount.mainItem);
            Item subItem = items.FirstOrDefault(x => x.Name == strategy.comboPercentageDiscount.subItem);

            if (mainItem != null && subItem != null)
            {
                // 找到可折扣的數量，即兩者數量的最小值
                int discountQuantity = Math.Min(mainItem.Quantity, subItem.Quantity);
                if (discountQuantity > 0)
                {
                    // 計算折扣金額
                    float discountRate = strategy.comboPercentageDiscount.discountRate;
                    float itemsAmount = mainItem.Price + subItem.Price;
                    float discountAmount = itemsAmount * discountRate * discountQuantity;

                    // 創建折扣商品項目
                    Item discountItem = new Item($"(折扣){strategy.comboPercentageDiscount.mainItem}搭{strategy.comboPercentageDiscount.subItem}", -1 * ((int)itemsAmount - (int)discountAmount), discountQuantity);

                    // 將折扣商品項目添加到清單中
                    items.Add(discountItem);
                }
            }
        }
    }
}
