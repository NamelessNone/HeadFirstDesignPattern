using System;

namespace C8_TemplatePattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SortDucks();
        }

        public static void CoffeeHook()
        {
            var coffeeHook = new CoffeeWithHook();
            Console.WriteLine($"\nMaking Coffee ...");
            coffeeHook.PrepareRecipe();
        }

        public static void SortDucks()
        {
            Duck[] ducks = new[]
            {
                new Duck("Daffy", 8),
                new Duck("Dewey", 2),
                new Duck("Howard", 7),
                new Duck("Louie", 2),
                new Duck("Donald", 10),
                new Duck("Huey", 2)
            };
            Console.WriteLine($"\nBefore sorting");
            foreach (var duck in ducks)
            {
                Console.WriteLine($"{duck}");
            }
            
            Array.Sort(ducks);
            
            Console.WriteLine($"\nAfter sorting");
            foreach (var duck in ducks)
            {
                Console.WriteLine($"{duck}");
            }
        }

        public static void TestSublist()
        {
            string[] Ducks = { "Mallard Duck", "RedHead Duck", "Rubber Duck", "Decoy Duck" };
            var ducks = new MyStringList(Ducks);
            
        }
    }
}