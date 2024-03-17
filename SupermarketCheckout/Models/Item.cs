using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketCheckout.Models
{
    public class Item
    {
        public string SKU { get; set; }
        public int Price { get; set; } 

        public Item(string sku, int price)
        {
            SKU = sku;
            Price = price;
        }
    }

}