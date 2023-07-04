using System;

namespace C10_StatePattern.InterfaceSM
{

    public class GumballMachine
    {
        public void SetState(IState state){}
    }
    
    
    public interface IState
    {
        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void Dispense();
    }
    
    

    public class NoQuarterState : IState
    {
        private GumballMachine _machine;

        public NoQuarterState(GumballMachine machine)
        {
            _machine = machine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine($"You Inserted a Quarter");
            _machine.SetState();
        }
        public void EjectQuarter();
        public void TurnCrank();
        public void Dispense();
    }
}