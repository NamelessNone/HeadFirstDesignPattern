using System;
using C10_StatePattern.InterfaceSM;

namespace C10_StatePattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            InterfaceSMTest();
        }

        public static void InterfaceSMTest()
        {
            GumballMachine fsm = new GumballMachine(5);
            Console.WriteLine($"{fsm}");
            fsm.InsertQuarter();
            Console.WriteLine($"{fsm}");
            fsm.TurnCrank();
            
            
            fsm.InsertQuarter();
            fsm.TurnCrank();
            fsm.InsertQuarter();
            fsm.TurnCrank();
            Console.WriteLine($"{fsm}");
        }
    }
}