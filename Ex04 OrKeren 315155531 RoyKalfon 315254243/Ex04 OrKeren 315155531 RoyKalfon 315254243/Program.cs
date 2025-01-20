using Ex04.Menus.Interfaces;
using System.Collections.Generic;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        static void Main()
        {
            List<Item> items = createMenu();
            Test firstTest = new Test(items);
            items[0].Show();
        }

        static List<Item> createMenu()
        {
            List<Item> items = new List<Item>();
            
            Menu mainMenu = new Menu("Delegates Main Menu", null);
            items.Add(mainMenu);
            
            Menu subMenu1 = new Menu("Letters and Versions", mainMenu);
            items.Add(subMenu1);
            
            Menu subMenu2 = new Menu("Show Current Date/Time", mainMenu);
            items.Add(subMenu2);
            
            

            return items;
        }
    }
}