using System;

namespace C10_StatePattern.InterfaceSM
{

    public class GumballMachine
    {
        private IState _soldOutState;
        private IState _noQuarterState;
        private IState _hasQuarterState;
        private IState _soldState;

        private IState _state;
        private int _count = 0;

        public IState SoldOutState => _soldOutState;
        public IState NoQuarterState => _noQuarterState;
        public IState HasQuarterState => _hasQuarterState;
        public IState SoldState => _soldState;

        public int Count => _count;

        public GumballMachine(int numberGumballs)
        {
            _soldOutState = new SoldOutState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuarterState = new HasQuarterState(this);
            _soldState = new SoldState(this);

            _count = numberGumballs;
            _state = numberGumballs > 0 ? _noQuarterState : _soldState;

        }

        public void InsertQuarter()
        {
            _state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            _state.EjectQuarter();
        }

        public void TurnCrank()
        {
            _state.TurnCrank();
            // check the state before dispense
            if (_state == SoldState) _state.Dispense();
        }


        public void SetState(IState state)
        {
            _state = state;
        }

        public void ReleaseBall()
        {
            Console.WriteLine($"A gumball comes rolling out of the slot ...");
            if (_count > 0) _count -= 1;
        }

        public override string ToString()
        {
            return $"Machine with {_count} gumballs, state is {_state.GetType().Name}";

        }
        
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
            _machine.SetState(_machine.HasQuarterState);
        }

        public void EjectQuarter()
        {
            Console.WriteLine($"You have not insert any Quarter");
        }

        public void TurnCrank()
        {
            Console.WriteLine($"You turned, but no quarter");
        }

        public void Dispense()
        {
            Console.WriteLine($"Quarter is needed for dispense");
        }
    }
    
    
    public class HasQuarterState : IState
    {
        private GumballMachine _machine;

        public HasQuarterState(GumballMachine machine)
        {
            _machine = machine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine($"You cannot inserted another quarter");
        }

        public void EjectQuarter()
        {
            Console.WriteLine($"Quarter returned");
            _machine.SetState(_machine.NoQuarterState);
        }

        public void TurnCrank()
        {
            Console.WriteLine($"You turned");
            _machine.SetState(_machine.SoldState);
        }

        public void Dispense()
        {
            Console.WriteLine($"No gumball dispensed");
        }
    }
    
    public class SoldState : IState
    {
        private GumballMachine _machine;

        public SoldState(GumballMachine machine)
        {
            _machine = machine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine($"Gumball on the way, please wait ... ");
        }

        public void EjectQuarter()
        {
            Console.WriteLine($"No quarter to return");
            _machine.SetState(_machine.NoQuarterState);
        }

        public void TurnCrank()
        {
            Console.WriteLine($"You turned, but nothing happens");
            _machine.SetState(_machine.SoldState);
        }

        public void Dispense()
        {
            _machine.ReleaseBall();
            if(_machine.Count>0) _machine.SetState(_machine.NoQuarterState);
            else
            {
                Console.WriteLine($"Out of gumballs");
                _machine.SetState(_machine.SoldOutState);
            }
            
        }
    }
    
    public class SoldOutState : IState
    {
        private GumballMachine _machine;

        public SoldOutState(GumballMachine machine)
        {
            _machine = machine;
        }

        public void InsertQuarter()
        {
            Console.WriteLine($"Sold out, not accepting quarter");
        }

        public void EjectQuarter()
        {
            Console.WriteLine($"No quarter to return");
        }

        public void TurnCrank()
        {
            Console.WriteLine($"You turned, but nothing happens");
        }

        public void Dispense()
        {
            Console.WriteLine($"Nothing to dispense");
        }
    }
    
    
}