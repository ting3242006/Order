using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    // 這邊看不太懂
    public class DiscountContext
    {
        private IDiscountStrategy _strategy;

        public DiscountContext(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ApplyDiscount(List<Item> items)
        {
            _strategy.ApplyDiscount(items);
        }
    }
}
