using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class RibRiceThreeFor300Discount : IDiscount
    {
        public void ApplyDiscount(List<Item> items)
        {
            Item RibRiceItem = items.FirstOrDefault(x => x.Name == "排骨飯");
            if (RibRiceItem != null)
            {
                int discountCount = RibRiceItem.Quantity / 3;

                if (discountCount > 0)
                {
                    Item free = new Item("(折扣)排骨飯", -30, discountCount);
                    items.Add(free);
                }
            }
        }

    }
}
