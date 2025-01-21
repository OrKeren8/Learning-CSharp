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
            Menu subMenu1 = new Menu("Letters and Versions", mainMenu);
            Menu subMenu2 = new Menu("Show Current Date/Time", mainMenu);
            Action action1 = new Action("Show Version", subMenu1, eActionTypes.ShowVersion);
            Action action2 = new Action("Count Lowercase Letters", subMenu1, eActionTypes.CountLowercaseLetters);
            Action action3 = new Action("Show Current Time", subMenu2, eActionTypes.ShowCurrentDateTime);
            Action action4 = new Action("Show Current Date", subMenu2, eActionTypes.ShowCurrentDate);

            items.Add(mainMenu);
            items.Add(subMenu1);
            items.Add(subMenu2);
            items.Add(action1);
            items.Add(action2);
            items.Add(action3);
            items.Add(action4);

            return items;
        }
    }
}