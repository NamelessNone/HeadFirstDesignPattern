using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace C9_Iterator_Composite_Pattern
{
    public interface IIterator
    {
        bool HasNext();
        MenuItem Next();
    }
    
    public class DinerMenuIterator: IIterator
    {
        private MenuItem[] _items;
        private int position = 0;

        public DinerMenuIterator(MenuItem[] items)
        {
            _items = items;
        }

        public MenuItem Next()
        {
            var menuItem = _items[position];
            position++;
            return menuItem;
        }

        public bool HasNext()
        {
            if (position >= _items.Length || _items[position] == null) return false;
            else return true;
        }
    }
}

namespace C9_Iterator_Composite_Pattern.Composite
{
    public class CompositeIterator: IEnumerator
    {
        private Stack _stack;
        private IEnumerator _startEnumerator;

        public CompositeIterator(IEnumerator startEnumerator)
        {
            _stack = new Stack();
            _stack.Push(startEnumerator);
            _startEnumerator = startEnumerator;

        }

        public bool MoveNext()
        {
            if (_stack.Count <= 0) return false;
            // get iterator from the end of stack
            while (_stack.Count > 0)
            {
                var stackEnd = _stack.Peek() as IEnumerator;
                if (stackEnd.MoveNext()) return true;
                else _stack.Pop();
            }

            return false;


        }

        public Object Current 
        {
            get
            {
                // here is because calling current before movenext will cause Exception,
                // but by the example in the book, we need to do this.
                try
                {
                    var iterator = _stack.Peek() as IEnumerator;
                    if (iterator?.Current is Menu asMenu)
                    {
                        _stack.Push(asMenu.GetEnumerator());
                    }

                    return iterator?.Current;

                }
                catch (Exception e)
                {
                    // Console.WriteLine($"Exception: {e}");
                }

                return null;

            }
        }


        public void Reset()
        {
            // _index = -1;
            _stack.Clear();
            _stack.Push(_startEnumerator);
        }

    }

    public class NullIterator : IEnumerator
    {
        public bool MoveNext() => false;

        public Object Current => null;
        
        public void Reset(){}
    }
}