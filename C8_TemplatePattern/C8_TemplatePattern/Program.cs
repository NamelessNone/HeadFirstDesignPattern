using System;

namespace C8_TemplatePattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var coffeeHook = new CoffeeWithHook();
            Console.WriteLine($"\nMaking Coffee ...");
            coffeeHook.PrepareRecipe();
        }
    }
}