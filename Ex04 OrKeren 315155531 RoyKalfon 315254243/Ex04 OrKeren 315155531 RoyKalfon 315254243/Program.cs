using Ex04.Menus.Interfaces;
using Ex04.Menus.Events;
using System.Collections.Generic;
using System;
using System.Runtime.CompilerServices;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        static void Main()
        {
            Interfaces.Menu mainMenu =  createMenuInterfaceStyle();
            InterfaceTest firstTest = new InterfaceTest(mainMenu);
            Console.Clear();
            Events.Menu mainMenu2 = createMenuEventStyle();
            EventTest secondTest = new EventTest(mainMenu2);
        }

        static Interfaces.Menu createMenuInterfaceStyle()
        {
            Interfaces.Menu mainMenu = new Interfaces.Menu("Delegates Main Menu Interfaces Style", null, null);
            Interfaces.Menu subMenu1 = new Interfaces.Menu("Letters and Versions", mainMenu, null);
            Interfaces.Menu subMenu2 = new Interfaces.Menu("Show Current Date/Time", mainMenu, null);
            Interfaces.Item action1 = new Interfaces.Item("Show Version", subMenu1, new InterfaceTest.ShowVersion());
            Interfaces.Item action2 = new Interfaces.Item("Count Lowercase Letters", subMenu1, new InterfaceTest.CountLowercaseLetters());
            Interfaces.Item action3 = new Interfaces.Item("Show Current Time", subMenu2, new InterfaceTest.ShowCurrentDateTime());
            Interfaces.Item action4 = new Interfaces.Item("Show Current Date", subMenu2, new InterfaceTest.ShowCurrentDate());

            return mainMenu;
        }

        static Events.Menu createMenuEventStyle()
        {
            Events.Menu mainMenu = new Events.Menu("Delegates Main Menu Events Style", null);
            Events.Menu subMenu1 = new Events.Menu("Letters and Versions", mainMenu);
            Events.Menu subMenu2 = new Events.Menu("Show Current Date/Time", mainMenu);
            
            Events.Item action1 = new Events.Item("Show Version", subMenu1);
            EventTest.ShowVersion showVersionTest = new EventTest.ShowVersion(action1);
            
            Events.Item action2 = new Events.Item("Count Lowercase Letters", subMenu1);
            EventTest.CountLowercaseLetters countLowercaseLettersTest = new EventTest.CountLowercaseLetters(action2);
            
            Events.Item action3 = new Events.Item("Show Current Time", subMenu2);
            EventTest.ShowCurrentDate showCurrentDateTest = new EventTest.ShowCurrentDate(action3);
            
            Events.Item action4 = new Events.Item("Show Current Date", subMenu2);
            EventTest.ShowCurrentDateTime showCurrentDateTimeTest = new EventTest.ShowCurrentDateTime(action4);

            return mainMenu;
        }
    }
}