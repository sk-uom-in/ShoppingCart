using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketCheckout.Models;
using SupermarketCheckout.Services;



namespace SupermarketCheckout.Models
{
    // Basket to contain multiple items and special offers
    public class Basket
    {
        private List<Item> items = new List<Item>();
        private List<SpecialOffer> specialOffers = new List<SpecialOffer>();

        // To add an item to the basket
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        // To add a special offer to the basket
        public void AddSpecialOffer(SpecialOffer offer)
        {
            specialOffers.Add(offer);
        }

        // To calculate the total price of all items in the basket after applying special offers
        public int CalculateTotalPrice()
        {
            int total = items.Sum(item => item.Price);
            foreach(var offer in specialOffers)
            {
                total -= offer.CalculateDiscount(items);
            }
            return total;
        }
    }
}
