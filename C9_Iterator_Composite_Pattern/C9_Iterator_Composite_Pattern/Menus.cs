﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace C9_Iterator_Composite_Pattern
{

    public interface IMenu
    {
        IEnumerator<MenuItem> GetEnumerator();
    }
    public class MenuItem
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

        public string Name => _name;
        public string Description => _description;
        public bool IsVegetarian => _isVegetarian;
        public double Price => _price;

    }
    
    //Lou's Pancake House
    public class PanCakeHouseMenu: IMenu
    {
        private List<MenuItem> _menuItems;

        public PanCakeHouseMenu()
        {
            _menuItems = new List<MenuItem>();
            AddItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99);
            AddItem("Regular Pancake Breakfast","Pancakes with fried eggs, sausage", true, 2.99);
        }

        public void AddItem(string name, string desc, bool isVeg, double price)
        {
            var item = new MenuItem(name, desc, isVeg, price);
            _menuItems.Add(item);
            
            
        }

        // public List<MenuItem> GetItems() => _menuItems;
        public IEnumerator<MenuItem> GetEnumerator() => _menuItems.GetEnumerator();
    }
    
    //Mel's Diner
    public class DinerMenu
    {
        private const int MAX_ITEMS = 6;
        private MenuItem[] _menuItems;

        public DinerMenu()
        {
            _menuItems = new MenuItem[MAX_ITEMS];
            AddItem("Vagetaian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99);
            AddItem("BLT"," Bacon with lettuce & tomato on whole wheat", true, 2.99);
        }
        
        public void AddItem(string name, string desc, bool isVeg, double price)
        {
            var item = new MenuItem(name, desc, isVeg, price);
            if (_menuItems.Length >= MAX_ITEMS)
            {
                Console.WriteLine($"menu is full");
            }
            else
            {
                _menuItems.Append(item);
            }
            
        }
        
        // public MenuItem[] GetItems() => _menuItems;

        // public IIterator CreateIterator()
        // {
        //     return new DinerMenuIterator(_menuItems);
        // }
        public IEnumerator<MenuItem> GetEnumerator() => _menuItems.GetEnumerator() as IEnumerator<MenuItem>;
    }
    
    
    //
    public class CafeMenu: IMenu
    {
        private Hashtable _menuItems = new Hashtable();
        public CafeMenu()
        {
            AddItem("Veggie Burger and Air Fries", "Veggie burger on a whole wheat bun, lettuce, tomato and fries",
                true, 3.99);
            AddItem("Soup of the day", "A cup of the soup of the day, with a side salad", false, 3.69);
        }
        public void AddItem(string name, string desc, bool isVeg, double price)
        {
            var item = new MenuItem(name, desc, isVeg, price);
            _menuItems.Add(item.Name, item);
        }
        // public Hashtable GetItems() => _menuItems;
        public IEnumerator<MenuItem> GetEnumerator() => _menuItems.Values.GetEnumerator() as IEnumerator<MenuItem>;

    }
    
    
}