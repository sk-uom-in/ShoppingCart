// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using SupermarketCheckout.Models;

class Program
{
    static void Main(string[] args)
    {
        var basket = new Basket();
        basket.AddItem(new Item("A99", 50));
        basket.AddItem(new Item("B15", 30));

        var totalPrice = basket.CalculateTotalPrice();
        System.Console.WriteLine($"Total Price: {totalPrice}");
    }
}
