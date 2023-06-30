using System;

namespace C8_TemplatePattern
{
    public interface ICaffeineBeverage
    {
        void PrepareRecipe();
        void BoilWater();
        void PourInCup();

    }

    public abstract class CaffeineBeverage
    {
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if(IsCustomerWantsCondiments()) AddCondiments();
        }

        public void BoilWater()
        {
            Console.WriteLine($"Boiling Water");
        }
        public abstract void Brew();

        public void PourInCup()
        {
            Console.WriteLine($"Pouring in cup");
        }
        public abstract void AddCondiments();

        public virtual bool IsCustomerWantsCondiments() => true;
    }

    public class Coffee:CaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine($"Dripping Coffee through filter");
        }
        public override void AddCondiments()
        {
            Console.WriteLine($"Adding Sugar and Milk");
        }
    }

    public class Tea:CaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine($"Steeping the tea");
        }
        public override void AddCondiments()
        {
            Console.WriteLine($"Adding Lemon");
        }
    }

    public class CoffeeWithHook : CaffeineBeverage
    {
        public override void Brew()
        {
            Console.WriteLine($"Dripping Coffee through filter");
        }
        public override void AddCondiments()
        {
            Console.WriteLine($"Adding Sugar and Milk");
        }
        
        public override bool IsCustomerWantsCondiments()
        {
            string answer = GetUserAnswer();
            if (answer.StartsWith("y")) return true;
            else return false;
        }

        private string GetUserAnswer()
        {
            return "nah";
        }
    }
}