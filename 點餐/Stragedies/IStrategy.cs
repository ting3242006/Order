using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐.Stragedies
{
    public interface IStrategy
    {
        void ApplyDiscountStrategy(List<Item> items, MenuModel.Strategy strategy);
    }
}
