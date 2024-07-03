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

            // 改成策略模式
            IDiscountStrategy discountStrategy = GetDiscountStrategy(discountType);
            discountStrategy.ApplyDiscount(list);

            ShowPanel.NotifyRenderItem(list);
            //Type t = Type.GetType(discountType);

            //IDiscount discount = (IDiscount)Activator.CreateInstance(t); //DiscountFactory.CreateDiscount(discountType);
            //discount.ApplyDiscount(list);

            //ShowPanel.NotifyRenderItem(list);
        }

        // 處理傳入的 discountType
        private IDiscountStrategy GetDiscountStrategy(string discountType)
        {
            if (string.IsNullOrEmpty(discountType))
            {
                return new NoDiscount();
            }

            Type strategyType = Type.GetType(discountType);
            if (strategyType == null || !typeof(IDiscountStrategy).IsAssignableFrom(strategyType))
            {
                throw new ArgumentException("未知的折扣類型");
            }
            // 拿到 strategyType 便創建相對應的折扣策略對象
            return (IDiscountStrategy)Activator.CreateInstance(strategyType);
        }
    }
}
