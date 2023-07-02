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