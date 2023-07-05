using System;

namespace C12_CompoundPattern
{
    public interface IHonkable
    {
        void Honk();
    }
    
    public class Goose: IHonkable
    {
        public void Honk()
        {
            Console.WriteLine($"Honk");
        }
    }
    
    
}