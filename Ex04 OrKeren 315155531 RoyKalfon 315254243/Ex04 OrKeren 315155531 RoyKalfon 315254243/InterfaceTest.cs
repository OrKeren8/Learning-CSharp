using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;


namespace Ex04.Menus.Test
{

    internal class InterfaceTest
    {
        public abstract class TestActionObserver: IActionObserver
        {
            public int GetObserverFamilyCode() { return 12;}
            public abstract void OnAction(Ex04.Menus.Interfaces.Item i_Item);

        }

        public class CountLowercaseLetters : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                int countOfLowerCase = 0;
                Console.WriteLine("Please enter your string: ");
                string userStringInput = Console.ReadLine();
                foreach (char currenChar in userStringInput)
                {
                    if (currenChar >= 'a' || currenChar <= 'z')
                    {
                        countOfLowerCase++;
                    }
                }
                Console.WriteLine($"The Amount of letters are: {countOfLowerCase}");
            }
        }

        public class ShowCurrentDate : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine($"Current Date is {currentDate.Day}/{currentDate.Month}/{currentDate.Year}");
            }
        }

        public class ShowCurrentDateTime : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine($"Current Time is {currentDate.Hour}:{currentDate.Second}:{currentDate.Millisecond}");
            }
        }

        public class ShowVersion : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                Console.WriteLine("App Version: 25.1.4.5480");
            }
        }

        public InterfaceTest(Interfaces.Menu i_MainMenu)
        {
            i_MainMenu.Show();
        }
    }
}
