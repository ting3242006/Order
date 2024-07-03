using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class ChickenRiceBuyTwoGetOneDiscount : IDiscountStrategy
    {
        public void ApplyDiscount(List<Item> items)
        {
            Item item = items.FirstOrDefault(x => x.Name == "雞排飯");
            // ? 是如果不符合這條件就不會進這個 BLOCK
            if (item?.Quantity / 2 > 0)
            {
                int ChickenSteakRiceItemQuantity = item.Quantity / 2;
                Item free = new Item("(贈送)雞排飯", 0, ChickenSteakRiceItemQuantity);
                items.Add(free);
            }
        }
    }
}
