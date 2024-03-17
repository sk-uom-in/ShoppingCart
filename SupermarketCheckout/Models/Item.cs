using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketCheckout.Models
{
    // Item to represent a product in the supermarket
    public class Item
    {
        // SKU is the unique identifier for the item (e.g. A99, B15, C40, etc.) , remember shark tank sku is stock keeping unit
        // Price is the price of the item (in pence or cents, etc.)
        public string SKU { get; set; }
        public int Price { get; set; } 

        public Item(string sku, int price)
        {
            SKU = sku;
            Price = price;
        }
    }

}