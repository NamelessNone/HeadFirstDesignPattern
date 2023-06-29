using System.Collections.Generic;

namespace FactoryMode_Console
{
    public interface IPizzaIngredientFactory
    {
        Dough CreateDough();
        Sauce CreateSauce();
        Cheese CreateCheese();
        IEnumerable<Veggie> CreateVeggies();
        Pepperoni CreatePepperoni();
        Clam CreateClam();
    }
    
    
    public class NYPizzaIngredientFactory: IPizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public Sauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public Cheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public IEnumerable<Veggie> CreateVeggies()
        {
            var result = new List<Veggie>()
            {
                new Garlic(),
                new Mushroom(),
                new Onion(),
                new RedPepper()
            };
            return result;
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Clam CreateClam()
        {
            return new FreshClams();
        }
    }
    
    
    public class ChicagoPizzaIngredientFactory: IPizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThickCrustDough();
        }

        public Sauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public Cheese CreateCheese()
        {
            return new MozzarellaCheese();
        }

        public IEnumerable<Veggie> CreateVeggies()
        {
            var result = new List<Veggie>()
            {
                new EggPlant(),
                new Spinach(),
                new BlackOlives(),
            };
            return result;
        }

        public Pepperoni CreatePepperoni()
        {
            return new SlicedPepperoni();
        }

        public Clam CreateClam()
        {
            return new FrozenClams();
        }
    }
    
}