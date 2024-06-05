using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    internal class NoDiscount : IDiscount
    {
        public void ApplyDiscount(List<Item> items)
        {
            return;
        }
    }
}
