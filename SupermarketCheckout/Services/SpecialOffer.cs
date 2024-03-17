using SupermarketCheckout.Models;
using System.Collections.Generic;
using System.Linq;
using SupermarketCheckout.Services;
namespace SupermarketCheckout.Services
{
    public class SpecialOffer
    {
        public SpecialOfferType OfferType { get; set; }
        public string SKU { get; set; } 
        public int RequiredQuantity { get; set; } 
        public int DiscountQuantity { get; set; }
        public int FixedPrice { get; set; } 

        // Constructor to create a special offer
        public SpecialOffer(SpecialOfferType offerType, string sku, int requiredQuantity, int discountQuantity = 0, int fixedPrice = 0)
        {
            OfferType = offerType;
            SKU = sku;
            RequiredQuantity = requiredQuantity;
            DiscountQuantity = discountQuantity;
            FixedPrice = fixedPrice; 
        }

        // To check if the special offer applies to a particular item
        public int CalculateDiscount(IEnumerable<Item> items)
        {
            // Get all items in the basket with the same SKU in the special offer irrespective of the order
            var applicableItems = items.Where(item => item.SKU == SKU);
            var count = applicableItems.Count();
            // If the special offer applies to the item
            switch (OfferType)
            {
                case SpecialOfferType.FixedPrice:
                    // for offers like "3 for 130" and "2 for 45"
                    var groupsFixedPrice = count / RequiredQuantity;
                    // Calculate discount as the difference between what the items would cost without the offer and the offer's fixed price
                    int totalWithoutOffer = count * applicableItems.First().Price;
                    int totalWithOffer = groupsFixedPrice * FixedPrice + (count % RequiredQuantity * applicableItems.First().Price);
                    return totalWithoutOffer - totalWithOffer;
                default:
                    return 0;
            }
        }
    }
}
