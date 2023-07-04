using System;

namespace C10_StatePattern.EnumState
{
    public enum MachineStates : int
    {
        Invalid=-1,
        SoldOut,
        NoQuarter,
        HasQuarter,
        Sold,
    }
    
    public class GumballMachine
    {
        private int _count = 0;
        private MachineStates _state = MachineStates.Invalid;

        public GumballMachine(int count)
        {
            _count = count;
            if (count > 0) _state = MachineStates.NoQuarter;
        }

        public void InsertQuarter()
        {
            switch (_state)
            {
                case MachineStates.HasQuarter:
                    Console.WriteLine($"You cannot insert another quarter");
                    break;
                case MachineStates.NoQuarter:
                    Console.WriteLine($"You inserted a quarter");
                    break;
                case MachineStates.SoldOut:
                    Console.WriteLine($"Sold out, cannot accept quarter");
                    break;
                case MachineStates.Sold:
                    Console.WriteLine($"Gumball giving, please wait");
                    break;
            }
        }
        
    }
}