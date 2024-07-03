using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    internal class NoDiscount : IDiscountStrategy
    {
        public void ApplyDiscount(List<Item> items)
        {
            return;
        }
    }
}
