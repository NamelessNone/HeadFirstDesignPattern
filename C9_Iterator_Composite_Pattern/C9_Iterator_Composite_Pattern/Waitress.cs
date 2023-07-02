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