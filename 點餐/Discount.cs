using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 點餐.Stragedies;
using static 點餐.MenuModel;

namespace 點餐
{
    public class Discount
    {
        public void DiscountOrder(Strategy discountType, List<Item> list)
        {

            list.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("折扣"));

            // 改成策略模式
            IStrategy discountStrategy = GetDiscountStrategy(discountType.method);
            discountStrategy.ApplyDiscountStrategy(list, discountType);

            ShowPanel.NotifyRenderItem(list);
            //Type t = Type.GetType(discountType);

            //IDiscount discount = (IDiscount)Activator.CreateInstance(t); //DiscountFactory.CreateDiscount(discountType);
            //discount.ApplyDiscount(list);

            //ShowPanel.NotifyRenderItem(list);
        }

        // 處理傳入的 discountType
        private IStrategy GetDiscountStrategy(string discountType)
        {
            if (string.IsNullOrEmpty(discountType))
            {
                return new NoStrategy();
            }

            Type strategyType = Type.GetType(discountType);
            if (strategyType == null || !typeof(IStrategy).IsAssignableFrom(strategyType))
            {
                throw new ArgumentException("未知的折扣類型");
            }
            // 拿到 strategyType 便創建相對應的折扣策略對象
            return (IStrategy)Activator.CreateInstance(strategyType);
        }
    }
}
