using System;
using C12_CompoundPattern.Properties;

namespace C12_CompoundPattern
{
    public class DuckSimulator
    {
        public static void Main(string[] args)
        {
            DuckSimulator simulator = new DuckSimulator();
            var factory = new CountingDuckFactory();
            simulator.Simulate(factory);

        }

        void Simulate(AbstractDuckFactory factory)
        {

            var redHeadDuck = factory.CreateRedheadDuck();
            var duckCall = factory.CreateDuckCall();
            var rubberDuck = factory.CreateRubberDuck();
            var gooseAdapter = new GooseAdapter(new Goose());
            
            Console.WriteLine($"\nDuck Simulator with composite--Flocks");

            var flock1 = new Flock();
            
            flock1.Add(redHeadDuck);
            flock1.Add(duckCall);
            flock1.Add(rubberDuck);
            flock1.Add(gooseAdapter);

            var flockMallard = new Flock();
            
            var mallardDuck = factory.CreateMallardDuck();
            var mallardDuck2 = factory.CreateMallardDuck();
            var mallardDuck3 = factory.CreateMallardDuck();
            var mallardDuck4 = factory.CreateMallardDuck();
            
            flockMallard.Add(mallardDuck);
            flockMallard.Add(mallardDuck2);
            flockMallard.Add(mallardDuck3);
            flockMallard.Add(mallardDuck4);
            
            //observer
            var quackologist = new Quackologist();
            flock1.RegisterObserver(quackologist);
            
            Console.WriteLine($"\nDuck Simulator: whole flock");
            Simulate(flock1);
            Console.WriteLine($"\nDuck Simulator: mallard flock");
            Simulate(flockMallard);

            Console.WriteLine($"Ducks quacked {QuackCounter.QuackCount()} times");
        }

        void Simulate(IQuackable duck)
        {
            duck.Quack();
        }
        
    }
}