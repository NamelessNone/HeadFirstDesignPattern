using System.Xml;
using C9_Iterator_Composite_Pattern.Composite;

namespace C9_Iterator_Composite_Pattern
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TestWaitressComposite();
        }

        public static void TestWaitressComposite()
        {
            var pancakeHouseMenu = new Menu("PANCAKE HOUSE MENU", "Breakfast");
            pancakeHouseMenu.Add(new Composite.MenuItem("K&B's Pancake Breakfast", "Pancakes with scrambled eggs and toast", true, 2.99));
            pancakeHouseMenu.Add(new Composite.MenuItem("Regular Pancake Breakfast","Pancakes with fried eggs, sausage", true, 2.99));
            var dinerMenu = new Menu("DINER MENU", "Lunch");
            dinerMenu.Add(new Composite.MenuItem("Vagetaian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat",
                true, 2.99));
            dinerMenu.Add(new Composite.MenuItem("BLT", " Bacon with lettuce & tomato on whole wheat", true, 2.99));
            var cafeMenu = new Menu("CAFE MENU", "Dinner");
            cafeMenu.Add(new Composite.MenuItem("Veggie Burger and Air Fries",
                "Veggie burger on a whole wheat bun, lettuce, tomato and fries",
                true, 3.99));
            cafeMenu.Add(new Composite.MenuItem("Soup of the day", "A cup of the soup of the day, with a side salad",
                false, 3.69));
            var dessertMenu = new Menu("DESSERT MENU", "Dessrt of course!");

            var allMenus = new Menu("ALL MENUS", "parent of all menu");
            allMenus.Add(pancakeHouseMenu);
            allMenus.Add(dinerMenu);
            allMenus.Add(cafeMenu);

            dinerMenu.Add(new Composite.MenuItem(
                "Pasta", "Spaghetti with Marinara Sauce", true, 3.89));
            
            dessertMenu.Add(new Composite.MenuItem(
                "Apple pie", "Apple pie with a flakey crust, topped with vanilla ice cream", true, 1.59));
            dinerMenu.Add(dessertMenu);

            var waitress = new C9_Iterator_Composite_Pattern.Composite.Waitress(allMenus);
            // waitress.PrintMenu();
            waitress.PrintVegMenu();
            // waitress.PrintMenuEnumerator();
        }
    }
}