using Ex04.Menus.Interfaces;
using System.Collections.Generic;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        static void Main()
        {
            Menu mainMenu =  createMenu();
            Test firstTest = new Test(new List<Menu> { mainMenu });
        }

        static Menu createMenu()
        {
            var backExistObserver = (new Test.Exit(), new Test.Back());

            Menu mainMenu = new Menu("Delegates Main Menu", null, new Test.Show(), backExistObserver);
            Menu subMenu1 = new Menu("Letters and Versions", mainMenu, new Test.Show(), backExistObserver);
            Menu subMenu2 = new Menu("Show Current Date/Time", mainMenu, new Test.Show(), backExistObserver);
            Action action1 = new Action("Show Version", subMenu1, new Test.ShowVersion());
            Action action2 = new Action("Count Lowercase Letters", subMenu1, new Test.CountLowercaseLetters());
            Action action3 = new Action("Show Current Time", subMenu2, new Test.ShowCurrentDateTime());
            Action action4 = new Action("Show Current Date", subMenu2, new Test.ShowCurrentDate());

            return mainMenu;
        }
    }
}