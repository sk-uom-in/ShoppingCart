using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketCheckout.Models;
using SupermarketCheckout.Services;

namespace SupermarketCheckout.Services
{
    public interface ISpecialOffer
    {
        bool AppliesTo(Item item);
        int CalculateDiscount(IEnumerable<Item> items);
    }

}