using System;
using System.Collections.Generic;

namespace C12_CompoundPattern
{
    public interface IQuackable : IQuackObservable
    {
        void Quack();
    }

    public class MallardDuck : IQuackable
    {
        private Observable _observable;

        public MallardDuck()
        {
            _observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine($"Quack");
            NotifyObservers();
        }

        public void NotifyObservers() => _observable.NotifyObservers();
        public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);


    }
    
    public class RedHeadDuck : IQuackable
    {
        private Observable _observable;

        public RedHeadDuck()
        {
            _observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine($"Quack");
            NotifyObservers();
        }
        public void NotifyObservers() => _observable.NotifyObservers();
        public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);
    }
    
    public class DuckCall : IQuackable
    {
        private Observable _observable;

        public DuckCall()
        {
            _observable = new Observable(this);
        }
        public void Quack()
        {
            // 鸭鸣器不是很逼真
            Console.WriteLine($"Kwak");
            NotifyObservers();
        }
        
        public void NotifyObservers() => _observable.NotifyObservers();
        public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);
    }
    
    public class RubberDuck : IQuackable
    {
        private Observable _observable;

        public RubberDuck()
        {
            _observable = new Observable(this);
        }
        public void Quack()
        {
            Console.WriteLine($"Squeak");
            NotifyObservers();
        }
        
        public void NotifyObservers() => _observable.NotifyObservers();
        public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);
    }




    public class GooseAdapter : IQuackable
    {
        private IHonkable _goose;
        
        private Observable _observable;
        
        public GooseAdapter(IHonkable goose)
        {
            _goose = goose;
            _observable = new Observable(this);
        }
        public void Quack()
        {
            _goose.Honk();
            NotifyObservers();
        }
        
        public void NotifyObservers() => _observable.NotifyObservers();
        public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);
    }


    // Decorator Pattern
    public class QuackCounter : IQuackable
    {
        private IQuackable _quackable;
        private static int _numberOfQuackable;

        public QuackCounter(IQuackable quackable)
        {
            _quackable = quackable;
        }
        
        public void Quack()
        {
            _quackable.Quack();
            _numberOfQuackable++;
            // 里面的鸭子Notify了，这里就不管了
        }

        public static int QuackCount() => _numberOfQuackable;
        
        public void NotifyObservers() => _quackable.NotifyObservers();
        public void RegisterObserver(IObserver observer) => _quackable.RegisterObserver(observer);
    }
    
    // Composite Pattern
    public class Flock : IQuackable
    {
        private List<IQuackable> _quackables= new List<IQuackable>();

        public void Add(IQuackable quackable)
        {
            _quackables.Add(quackable);
        }

        public void Quack()
        {
            var iterator = _quackables.GetEnumerator();
            while (iterator.MoveNext())
            {
                iterator.Current?.Quack();
            }
            // 同理，里面的鸭子们通知了
        }

        public void NotifyObservers()
        {
            foreach (var quackable in _quackables)
            {
                quackable.NotifyObservers();
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            foreach (var quackable in _quackables)
            {
                quackable.RegisterObserver(observer);
            }
        } 
    }
    
}