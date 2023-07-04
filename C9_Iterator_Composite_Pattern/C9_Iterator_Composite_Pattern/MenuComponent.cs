using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace C9_Iterator_Composite_Pattern.Composite
{
    public abstract class MenuComponent
    {

        // 组合方法，增删改
        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public MenuComponent GetChild(int id)
        {
            throw new NotImplementedException();
        }
        
        // 操作方法
        public virtual string Name()      
        {
            throw new NotImplementedException();
        }
        public virtual string Description()
        {
            throw new NotImplementedException();
        }
        public virtual double Price()
        {
            throw new NotImplementedException();
        }
        public virtual bool IsVegetarian()
        {
            throw new NotImplementedException();
        }
        
        public abstract void Print();

        public abstract IEnumerator GetEnumerator();

    }

    public class MenuItem : MenuComponent
    {
        private string _name;
        private string _description;
        private bool _isVegetarian;
        private double _price;
        
        public MenuItem(string name, string desc, bool isVegetarian, double price)
        {
            _name = name;
            _description = desc;
            _isVegetarian = isVegetarian;
            _price = price;
        }
        
        public override string Name()
        {
            return _name;
        }

        public override string Description()
        {
            return _description;
        }

        public override double Price()
        {
            return _price;
        }

        public override bool IsVegetarian()
        {
            return _isVegetarian;
        }

        public override void Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"  {_name}");
            if (_isVegetarian) sb.Append("(v)");
            sb.Append($", {_price}");
            sb.Append($"   -- {_description}");
            Console.WriteLine(sb.ToString());
        }
        
        public override IEnumerator GetEnumerator()=> new NullIterator();
    }


    public class Menu : MenuComponent
    {
        private List<MenuComponent> _menuComponents;
        private string _name;
        private string _description;

        public Menu(string name, string desc)
        {
            _menuComponents = new List<MenuComponent>();
            _name = name;
            _description = desc;
        }

        public void Add(MenuComponent item)
        {
            _menuComponents.Add(item);
        }

        public void Remove(MenuComponent item)
        {
            _menuComponents.Remove(item);
        }

        public MenuComponent GetChild(int id)
        {
            if (id >= _menuComponents.Count - 1)
            {
                throw new Exception($"index out of bound");
                return null;
            }

            return _menuComponents[id];
        }
        
        public override string Name() => _name;
        public override string Description() => _description;
        
        public override void Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\n  {_name}");
            sb.Append($",   -- {_description}");
            sb.Append("\n------------------------------------------");
            Console.WriteLine(sb.ToString());
            
            var iterator = _menuComponents.GetEnumerator();
            do
            {
                var menuItem = iterator.Current;
                menuItem?.Print();
            } while (iterator.MoveNext());
            
        }

        public override IEnumerator GetEnumerator()
        {
            // var enumerators = new IEnumerator[]
            // {
            //     _menuComponents.GetEnumerator(),
            // };

            return new CompositeIterator(_menuComponents.GetEnumerator());
        }
    }
}