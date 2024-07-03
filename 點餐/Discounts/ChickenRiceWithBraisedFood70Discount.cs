using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class ChickenRiceWithBraisedFood70Discount : IDiscountStrategy
    {
        public void ApplyDiscount(List<Item> items)
        {
            Item chickenRiceItem = items.FirstOrDefault(x => x.Name == "雞絲飯");
            Item braisedFoodItem = items.FirstOrDefault(item => item.Name == "滷味");
            if (chickenRiceItem != null && braisedFoodItem != null)
            {
                int discountQuantity = Math.Min(chickenRiceItem.Quantity, braisedFoodItem.Quantity);
                if (discountQuantity > 0)
                {
                    Item discountItem = new Item("(折扣)雞絲飯搭滷味", -5, discountQuantity);
                    items.Add(discountItem);
                }
            }
        }
    }
}
