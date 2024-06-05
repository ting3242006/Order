using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public interface IDiscount
    {
        void ApplyDiscount(List<Item> items);
    }
}
