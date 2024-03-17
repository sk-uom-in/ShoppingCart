using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketCheckout.Models
{
    public class Basket
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public int CalculateTotalPrice()
        {
            return items.Sum(item => item.Price);
        }
    }
}