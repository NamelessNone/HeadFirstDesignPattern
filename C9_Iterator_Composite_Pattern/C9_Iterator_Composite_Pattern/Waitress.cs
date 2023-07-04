using System;


namespace C9_Iterator_Composite_Pattern
{
    public class Waitress
    {

        private void PrintMenu(IIterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem item = iterator.Next();
                Console.WriteLine($"{item.Name},{item.Price}--{item.Description}");
            }
        }
    }


}

namespace C9_Iterator_Composite_Pattern.Composite
{
    public class Waitress
    {
        private MenuComponent _allMenus;

        public Waitress(MenuComponent allMenus)
        {
            _allMenus = allMenus;
        }

        public void PrintMenu()
        {
            _allMenus.Print();
        }

        public void PrintVegMenu()
        {
            var iterator = _allMenus.GetEnumerator();
            var steps = 0;
            Console.WriteLine($"\n --- VEGETABLE MENU --- \n");
            while (iterator.MoveNext())
            {
                steps++;
                // Console.WriteLine($"iterator is moving: {steps}steps");
                try
                {
                    if (iterator.Current is MenuComponent)
                    {
                        var component = iterator.Current as MenuComponent;
                        if(component!=null && component.IsVegetarian())
                            component.Print();
                    }
                }
                catch (Exception e)
                {
                    
                }

            }
        }

        public void PrintMenuEnumerator()
        {
            var iterator = _allMenus.GetEnumerator();
            var steps = 0;
            Console.WriteLine($"\n --- MENU --- \n");
            while (iterator.MoveNext())
            {
                steps++;
                Console.WriteLine($"iterator is moving: {steps}steps");
                var component = iterator.Current as MenuComponent;
                component?.Print();
            }
        }
    }
}