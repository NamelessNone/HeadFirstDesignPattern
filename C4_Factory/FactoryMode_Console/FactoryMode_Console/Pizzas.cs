using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMode_Console
{
    
    public abstract class Pizza
    {
        protected string name;
        protected Dough dough;
        protected Sauce sauce;
        protected IEnumerable<Veggie> veggies;
        protected Cheese cheese;
        protected Pepperoni pepperoni;
        protected Clam clam;
        // protected List<string> toppings= new List<string>();
        public abstract void Prepare();
        
        public virtual void Bake()
        {
            Console.WriteLine($"Bake for 25 min at 350");
        }

        public virtual void Cut()
        {
            Console.WriteLine($"Cutting pizza into diagonal slices");
        }

        public virtual void Box()
        {
            Console.WriteLine($"Place pizza in official PizzaStore box!");
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Pizza={name}\n");
            sb.Append($"Dough={dough??dough:string.Empty},sauce={sauce??sauce:string.Empty},cheese={cheese??cheese:string.Empty},pepperoni={pepperoni??pepperoni:string.Empty},clam={clam??clam:string.Empty}\n");
            if (veggies != null)
            {
                sb.Append($"Veggies:");
                foreach (var veggie in veggies)
                {
                    sb.Append($"{veggie},");
                }

            }

            return sb.ToString();
        }
    }

    public class CheesePizza : Pizza
    {
        protected IPizzaIngredientFactory _factory;
        public CheesePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _factory = ingredientFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine($"Preparing {name}");
            dough = _factory.CreateDough();
            sauce = _factory.CreateSauce();
            cheese = _factory.CreateCheese();
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class VeggiePizza : Pizza
    {
        protected IPizzaIngredientFactory _factory;
        public VeggiePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _factory = ingredientFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine($"Preparing {name}");
            dough = _factory.CreateDough();
            sauce = _factory.CreateSauce();
            cheese = _factory.CreateCheese();
            veggies = _factory.CreateVeggies();
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class ClamPizza : Pizza
    {
        
        protected IPizzaIngredientFactory _factory;
        public ClamPizza(IPizzaIngredientFactory ingredientFactory)
        {
            _factory = ingredientFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine($"Preparing {name}");
            dough = _factory.CreateDough();
            sauce = _factory.CreateSauce();
            cheese = _factory.CreateCheese();
            clam = _factory.CreateClam();
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class PepperoniPizza : Pizza
    {
        protected IPizzaIngredientFactory _factory;
        public PepperoniPizza(IPizzaIngredientFactory ingredientFactory)
        {
            _factory = ingredientFactory;
        }
        public override void Prepare()
        {
            Console.WriteLine($"Preparing {name}");
            dough = _factory.CreateDough();
            sauce = _factory.CreateSauce();
            cheese = _factory.CreateCheese();
            pepperoni = _factory.CreatePepperoni();
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class GreekPizza : Pizza
    {
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    #region NewYork
    
    public class NYStyleCheesePizza : Pizza
    {
        public NYStyleCheesePizza()
        {
            name = "NY Style Sauce and Cheese Pizza";
            // dough = "Thin Crust Dough";
            // sauce = "Marinara Sauce";
            // toppings.Add("Grated Reggiano Cheese");
        }
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class NYStyleVeggiePizza : Pizza
    {
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class NYStyleClamPizza : Pizza
    {
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class NYStylePepperoniPizza : Pizza
    {
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    #endregion
    
    #region Chicago
    
    public class ChicagoStyleCheesePizza : Pizza
    {
        public ChicagoStyleCheesePizza()
        {
            name = "Chicago Style Sauce and Cheese Pizza";
            // dough = "Extra Thick Crust Dough";
            // sauce = "Plum Tomato Sauce";
            // toppings.Add("Shredded Mozzarella Cheese");
        }
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class ChicagoStyleVeggiePizza : Pizza
    {
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class ChicagoStyleClamPizza : Pizza
    {
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    
    public class ChicagoStylePepperoniPizza : Pizza
    {
        public override void Prepare()
        {
            
        }
        
        public override void Bake()
        {
            
        }
        
        public override void Cut()
        {
            
        }
        
        public override void Box()
        {
            
        }
    }
    #endregion
}
