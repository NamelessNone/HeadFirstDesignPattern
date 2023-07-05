using System;
using System.Collections.Generic;

namespace C12_CompoundPattern
{
    public interface IQuackObservable
    {
        void RegisterObserver(IObserver observer);
        void NotifyObservers();
    }

    public interface IObserver
    {
        void Update(IQuackObservable quackObservable);
    }


    public class Observable : IQuackObservable
    {
        private List<IObserver> _observers = new List<IObserver>();
        private IQuackObservable _duck;
        public Observable(IQuackObservable duck)
        {
            _duck = duck;
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_duck);
            }
        }
    }

    public class Quackologist : IObserver
    {
        public void Update(IQuackObservable duck)
        {
            Console.WriteLine($"Quackologitst: {duck} just quacked");
        }
    }
}