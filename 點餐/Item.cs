using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 點餐
{
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int SubTotal { get; set; }
        public string Note { get; set; }

        public Item(string name, int price, int quantity, string note = "")
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Note = note;
            this.SubTotal = price * quantity;
        }
    }
}
