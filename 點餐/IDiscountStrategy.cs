using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    // 定義一個抽象的折扣接口
    public interface IDiscountStrategy
    {
        void ApplyDiscount(List<Item> items);
    }
}
