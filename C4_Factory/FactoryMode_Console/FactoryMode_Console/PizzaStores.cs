namespace FactoryMode_Console
{
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;

        }

        public abstract Pizza CreatePizza(string pizzaType);
    }

    public class NYPizzaStore : PizzaStore
    {
        // public NYPizzaStore(SimplePizzaFactory factory)
        // {
        //     factory= 
        // }
        
        public override Pizza CreatePizza(string pizzaType)
        {
            Pizza pizza = null;
            var ingredientFactory = new NYPizzaIngredientFactory();

            if (pizzaType.Equals("cheese"))
            {
                pizza = new CheesePizza(ingredientFactory);
                pizza.Name = "New York Style Cheese Pizza";
            }
            else if (pizzaType.Equals("veggie"))
            {
                pizza = new VeggiePizza(ingredientFactory);
                pizza.Name = "New York Style Veggie Pizza";
            }
            else if (pizzaType.Equals("clam"))           
            {
                pizza = new ClamPizza(ingredientFactory);
                pizza.Name = "New York Style Clam Pizza";
            }
            else if (pizzaType.Equals("pepperoni"))           
            {
                pizza = new PepperoniPizza(ingredientFactory);
                pizza.Name = "New York Style Pepperoni Pizza";
            }
            
            return pizza;
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string pizzaType)
        {
            Pizza pizza = null;
            var ingredientFactory = new ChicagoPizzaIngredientFactory();

            if (pizzaType.Equals("cheese"))
            {
                pizza = new CheesePizza(ingredientFactory);
                pizza.Name = "Chicago Style Cheese Pizza";
            }
            else if (pizzaType.Equals("veggie"))
            {
                pizza = new VeggiePizza(ingredientFactory);
                pizza.Name = "Chicago Style Veggie Pizza";
            }
            else if (pizzaType.Equals("clam"))           
            {
                pizza = new ClamPizza(ingredientFactory);
                pizza.Name = "Chicago Style Clam Pizza";
            }
            else if (pizzaType.Equals("pepperoni"))           
            {
                pizza = new PepperoniPizza(ingredientFactory);
                pizza.Name = "Chicago Style Pepperoni Pizza";
            }
            
            return pizza;
        }
    }
}