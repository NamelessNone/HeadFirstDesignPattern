using System.Runtime.CompilerServices;

namespace C5_Singleton
{
    public class ChocolateBoiler
    {
        private static volatile ChocolateBoiler _instance;

        public static ChocolateBoiler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(Instance)
                    {
                        if (_instance == null) 
                            _instance = new ChocolateBoiler();
                    }
                }
                return _instance;
            }

        }
        
        private bool isEmpty;
        private bool isBoiled;

        private ChocolateBoiler()
        {
            isEmpty = true;
            isBoiled = false;
        }

        public void Fill()
        {
            if (isEmpty)
            {
                isEmpty = false;
                isBoiled = false;
            }
        }

        public void Drain()
        {
            if (!isEmpty && isBoiled)
            {
                isEmpty = true;
            }
        }

        public void Boil()
        {
            if (!isEmpty && !isBoiled)
            {
                isBoiled = true;
            }
        }
    }
}