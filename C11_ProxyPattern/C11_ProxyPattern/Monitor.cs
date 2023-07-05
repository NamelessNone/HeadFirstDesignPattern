using System;

namespace C11_ProxyPattern
{
    public class GumballMonitor
    {
        private GumballMachine _machine;

        public GumballMonitor(GumballMachine machine)
        {
            _machine = machine;
        }

        public void Report()
        {
            Console.WriteLine($"Gumball Machine: {_machine.Location}");
            Console.WriteLine($"Current Inventory: {_machine.Count} Gumballs");
            Console.WriteLine($"Current State: {_machine.GetState()}");
        }
    }
}