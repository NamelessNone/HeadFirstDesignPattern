namespace FactoryMode_Console
{
    #region dough

    public abstract class Dough
    {
        
    }

    public class ThickCrustDough : Dough
    {
        
    }

    public class ThinCrustDough : Dough {}
    #endregion


    #region sauce

    public abstract class Sauce
    {
        
    }

    public class MarinaraSauce : Sauce
    {
        
    }
    public class PlumTomatoSauce:Sauce{}

    #endregion

    #region cheese

    public abstract class Cheese
    {
        
    }

    public class ReggianoCheese : Cheese
    {
        
    }
    
    public class MozzarellaCheese: Cheese{}

    #endregion


    #region veggie

    public abstract class Veggie
    {
        
    }
    
    public class Garlic:Veggie{}
    public class Onion:Veggie{}
    public class Mushroom:Veggie{}
    public class RedPepper:Veggie{}
    
    public class EggPlant:Veggie{}
    public class Spinach:Veggie{}
    public class BlackOlives:Veggie{}

    #endregion

    
    #region pepper
    public abstract class Pepperoni
    {
        
    }

    public class SlicedPepperoni : Pepperoni
    {
        
    }
    
    #endregion


    #region clam

    public abstract class Clam
    {
        
    }
    
    public class FreshClams:Clam{}
    public class FrozenClams:Clam{}
    
    #endregion

    
    
}