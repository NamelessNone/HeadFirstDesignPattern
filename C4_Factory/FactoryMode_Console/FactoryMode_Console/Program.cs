using System;

namespace FactoryMode_Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            var pizza1 = nyStore.OrderPizza("cheese");
            Console.WriteLine($"Ethan ordered a {pizza1}\n");

            var pizza2 = chicagoStore.OrderPizza($"cheese");
            Console.WriteLine($"Joel ordered a {pizza2}\n");
        }
    }
}