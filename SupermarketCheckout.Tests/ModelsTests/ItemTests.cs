using NUnit.Framework;
using SupermarketCheckout.Models;

namespace SupermarketCheckout.Tests.ModelTests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        public void Item_Initialization_CorrectlyAssignsProperties()
        {
            // Arrange & Act
            var item = new Item("A99", 50);
            
            // Assert
            Assert.AreEqual("A99", item.SKU);
            Assert.AreEqual(50, item.Price);
        }
    }
}
