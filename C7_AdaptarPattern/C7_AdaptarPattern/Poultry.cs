using System;

namespace C7_AdaptarPattern
{
    public interface IDuck
    {
        void Quack();
        void Fly();
    }


    
    public class MallardDuck: IDuck
    {
        public void Quack()
        {
            Console.WriteLine($"Quack");
        }

        public void Fly()
        {
            Console.WriteLine($"I'm flying");
        }
    }
    
    public interface ITurkey
    {
        void Gobble();
        void Fly();
    }

    public class WildTurkey : ITurkey
    {
        public void Gobble()
        {
            Console.WriteLine($"Gobble Gobble");
        }

        public void Fly()
        {
            Console.WriteLine($"I'm flying a short distance");
        }
    }

    public class TurkeyAdapter : IDuck
    {
        private ITurkey _turkey;

        public TurkeyAdapter(ITurkey turkey)
        {
            _turkey = turkey;
        }

        public void Quack()
        {
            _turkey.Gobble();
        }

        public void Fly()
        {
            //因为飞得近，多飞几下
            for (int i = 0; i < 5; i++)
            {
                _turkey.Fly();
            }
        }
    }
}