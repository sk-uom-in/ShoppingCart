using NUnit.Framework;
using SupermarketCheckout.Models;
using SupermarketCheckout.Services;
using System.Collections.Generic;

namespace SupermarketCheckout.Tests.ServiceTests
{
    [TestFixture]
    public class BasketTests
    {
        [Test]
        public void Basket_TotalPrice_IsConsistent_RegardlessOfItemAdditionOrder()
        {
            // Basket 1: Items added in mixed order
            var basket1 = new Basket();
            basket1.AddItem(new Item("A99", 50)); 
            basket1.AddItem(new Item("B15", 30)); 
            basket1.AddItem(new Item("C40", 60)); 
            basket1.AddItem(new Item("A99", 50)); 

            // Basket 2: Items added in reverse order
            var basket2 = new Basket();
            basket2.AddItem(new Item("A99", 50)); 
            basket2.AddItem(new Item("C40", 60)); 
            basket2.AddItem(new Item("B15", 30)); 
            basket2.AddItem(new Item("A99", 50)); 

            // Add same offers to both baskets
            var offerA99 = new SpecialOffer(SpecialOfferType.FixedPrice, "A99", 3, fixedPrice: 130);
            var offerB15 = new SpecialOffer(SpecialOfferType.FixedPrice, "B15", 2, fixedPrice: 45);
            basket1.AddSpecialOffer(offerA99);
            basket1.AddSpecialOffer(offerB15);
            basket2.AddSpecialOffer(offerA99);
            basket2.AddSpecialOffer(offerB15);

            // Calculate total price for both baskets
            var totalPrice1 = basket1.CalculateTotalPrice();
            var totalPrice2 = basket2.CalculateTotalPrice();

            // The total price should be the same regardless of the order items were added
            Assert.AreEqual(totalPrice1, totalPrice2);
        }
    }
}
