using System;

namespace C7_AdaptarPattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestPoultry();
        }

        public static void TestPoultry()
        {
            IDuck duck = new MallardDuck();
            ITurkey turkey = new WildTurkey();
            IDuck turkeyAdapter = new TurkeyAdapter(turkey);
            
            Console.WriteLine($"\nturkey says:");
            turkey.Gobble();
            turkey.Fly();
            
            Console.WriteLine($"\nduck says:");
            TestDuck(duck);
            
            Console.WriteLine($"\nturkey Adapter says:");
            TestDuck(turkeyAdapter);
        }

        public static void TestDuck(IDuck duck)
        {
            duck.Quack();
            duck.Fly();
        }
    }
}