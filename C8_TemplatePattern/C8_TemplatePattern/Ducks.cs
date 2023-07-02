using System;
using System.Collections.ObjectModel;

namespace C8_TemplatePattern
{
    
    
    public class Duck : IComparable<Duck>
    {
        private string _name;
        private int _weight;

        public Duck(string name, int weight)
        {
            _name = name;
            _weight = weight;
        }

        public override string ToString()
        {
            return $"{_name}:{_weight}";
        }
        
        public int CompareTo(Duck otherDuck)
        {
            if (_weight < otherDuck._weight) return -1;
            else if (_weight > otherDuck._weight) return 1;
            else return 0;
        }

    }

    public class MyStringList : Collection<string>
    {
        private string[] _myList;

        public MyStringList(string[] strings)
        {
            _myList = strings;
        }

        public string Get(int index)
        {
            return _myList[index];
        }

        public int Size() => _myList.Length;

        public string Set(int index, string item)
        {
            string oldStr = _myList[index];
            _myList[index] = item;
            return oldStr;
        }

    }
}