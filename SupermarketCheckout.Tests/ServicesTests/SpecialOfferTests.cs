using NUnit.Framework;
using SupermarketCheckout.Models;
using SupermarketCheckout.Services;
using System.Collections.Generic;

namespace SupermarketCheckout.Tests.ServiceTests
{
    [TestFixture]
    public class SpecialOfferTests
    {
        [Test]
        public void CalculateDiscount_AppliesThreeFor130OfferCorrectly()
        {
            // Arrange
            var items = new List<Item>
            {
                // Should trigger the "3 for 130" offer
                new Item("A99", 50),
                new Item("A99", 50),
                new Item("A99", 50) 
                
            };
            var offer = new SpecialOffer(SpecialOfferType.FixedPrice, "A99", 3, fixedPrice: 130);

            // Act
            var discount = offer.CalculateDiscount(items);

            // Assert
            var expectedDiscount = (items.Count * 50) - 130; 
            Assert.AreEqual(expectedDiscount, discount);
        }

        [Test]
        public void CalculateDiscount_AppliesTwoFor45OfferCorrectly()
        {
            // Arrange
            var items = new List<Item>
            {
                new Item("B15", 30),
                new Item("B15", 30) 
            };
            var offer = new SpecialOffer(SpecialOfferType.FixedPrice, "B15", 2, fixedPrice: 45);

            // Act
            var discount = offer.CalculateDiscount(items);

            // Assert
            var expectedDiscount = (items.Count * 30) - 45; 
            Assert.AreEqual(expectedDiscount, discount);
        }
        [Test]
        public void CalculateDiscount_AppliesOffersCorrectlyWithMixedItemsAndMultipleQuantities()
        {
            // Arrange
            var basket = new Basket();
            // Eligible for "3 for 130" offer twice
            basket.AddItem(new Item("A99", 50));
            basket.AddItem(new Item("A99", 50));
            basket.AddItem(new Item("A99", 50));
            basket.AddItem(new Item("A99", 50));
            basket.AddItem(new Item("A99", 50));
            basket.AddItem(new Item("A99", 50));
            // Eligible for "2 for 45" offer once
            basket.AddItem(new Item("B15", 30));
            basket.AddItem(new Item("B15", 30));
            // Not eligible for any offer
            basket.AddItem(new Item("C40", 60));
            basket.AddItem(new Item("T34", 99));

            // Offers
            basket.AddSpecialOffer(new SpecialOffer(SpecialOfferType.FixedPrice, "A99", 3, fixedPrice: 130));
            basket.AddSpecialOffer(new SpecialOffer(SpecialOfferType.FixedPrice, "B15", 2, fixedPrice: 45));

            // Act
            var totalPrice = basket.CalculateTotalPrice();

            // Assert
            var expectedPrice = 2 * 130 + 45 + 60 + 99;    
            Assert.AreEqual(expectedPrice, totalPrice);
        }
        [Test]
    public void CalculateDiscount_OfferNotMeetingRequiredQuantity_ReturnsNoDiscount()
    {
        // Arrange - Only 2 items when 3 are needed for the offer
        var items = new List<Item>
        {
            new Item("A99", 50),
            new Item("A99", 50)
        };
        var offer = new SpecialOffer(SpecialOfferType.FixedPrice, "A99", 3, fixedPrice: 130);

        // Act
        var discount = offer.CalculateDiscount(items);

        // Assert
        Assert.AreEqual(0, discount, "Expected no discount when the required quantity is not met.");
    }
    [Test]
    public void CalculateDiscount_OfferAppliesMultipleTimesWithLeftoverItems()
    {
        // Arrange: 7 items, where "3 for 130" can apply twice, leaving 1 item at full price
        var items = new List<Item>
        {
            new Item("A99", 50),
            new Item("A99", 50),
            new Item("A99", 50),
            new Item("A99", 50),
            new Item("A99", 50),
            new Item("A99", 50),
            new Item("A99", 50)
        };
        var offer = new SpecialOffer(SpecialOfferType.FixedPrice, "A99", 3, fixedPrice: 130);

        // Act
        var discount = offer.CalculateDiscount(items);

        // Assert: Expect discount for 6 items as part of the offer, 1 item at full price
        var expectedDiscount = ((items.Count - 1) * 50) - (2 * 130); 
        Assert.AreEqual(expectedDiscount, discount);
    }
    [Test]
    public void CalculateTotalPrice_ItemsWithNoOffers_CorrectTotalPrice()
    {
        // Arrange: Items without any special offers
        var basket = new Basket();
        basket.AddItem(new Item("C40", 60));
        basket.AddItem(new Item("T34", 99));

        // Act
        var totalPrice = basket.CalculateTotalPrice();

        // Assert
        Assert.AreEqual(159, totalPrice, "Expected total price to equal the sum of item prices without offers.");
    }

    }
}
