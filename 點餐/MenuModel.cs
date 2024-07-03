using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    internal class MenuModel
    {

        public Menu[] Menus { get; set; }
        public Strategy[] Strategies { get; set; }


        public class Menu
        {
            public string Type { get; set; }
            public Item[] Items { get; set; }
        }

        public class Item
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class Strategy
        {
            public string id { get; set; }
            public string name { get; set; }
            public string method { get; set; }
            public Buyxgety buyXgetY { get; set; }
            public Buyygetz buyYgetZ { get; set; }
            public Fixedprice fixedPrice { get; set; }
            public Comboprice comboPrice { get; set; }
            public Allpercentagediscount allPercentageDiscount { get; set; }
            public Combopercentagediscount comboPercentageDiscount { get; set; }
        }

        public class Buyxgety
        {
            public string mainItem { get; set; }
            public int quantity { get; set; }
            public string subItem { get; set; }
            public int subQuantity { get; set; }
            public int price { get; set; }
            public int discountRate { get; set; }
        }

        public class Buyygetz
        {
            public string mainItem { get; set; }
            public int quantity { get; set; }
            public string subItem { get; set; }
            public int subQuantity { get; set; }
            public int price { get; set; }
            public int discountRate { get; set; }
        }

        public class Fixedprice
        {
            public string mainItem { get; set; }
            public int quantity { get; set; }
            public string subItem { get; set; }
            public int subQuantity { get; set; }
            public int price { get; set; }
            public int discountRate { get; set; }
        }

        public class Comboprice
        {
            public string mainItem { get; set; }
            public int quantity { get; set; }
            public string subItem { get; set; }
            public int subQuantity { get; set; }
            public int price { get; set; }
            public int discountRate { get; set; }
        }

        public class Allpercentagediscount
        {
            public string mainItem { get; set; }
            public int quantity { get; set; }
            public string subItem { get; set; }
            public int subQuantity { get; set; }
            public int price { get; set; }
            public float discountRate { get; set; }
        }

        public class Combopercentagediscount
        {
            public string mainItem { get; set; }
            public int quantity { get; set; }
            public string subItem { get; set; }
            public int subQuantity { get; set; }
            public int price { get; set; }
            public float discountRate { get; set; }
        }

    }
}
// 這裡要補