using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class CurryRiceBuyTwoGetStrawberryPancakeDiscount : IDiscount
    {
        public void ApplyDiscount(List<Item> items)
        {
            Item curryRiceItem = items.FirstOrDefault(x => x.Name == "咖哩飯");
            if (curryRiceItem != null)
            {
                int freeCount = curryRiceItem.Quantity;
                if (freeCount / 2 > 0)
                {
                    Item free = new Item("(贈送)草莓鬆餅", 0, freeCount / 2);
                    items.Add(free);
                }
            }
        }
    }
}
