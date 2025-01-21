using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;


namespace Ex04.Menus.Test
{

    internal class Test
    {
        public abstract class TestActionObserver: IActionObserver
        {
            public int GetObserverFamilyCode() { return 12;}
            public abstract void OnAction(Ex04.Menus.Interfaces.Item i_Item);

        }

        public class Exit : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                i_Item.Prev.DetachObserver(this);
            }
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
                i_Item.Prev.Show();
            }
        }

        public class ShowCurrentDate : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine($"Current Date is {currentDate.Day}/{currentDate.Month}/{currentDate.Year}");
                i_Item.Prev.Show();
            }
        }

        public class ShowCurrentDateTime : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine($"Current Time is {currentDate.Hour}:{currentDate.Second}:{currentDate.Millisecond}");
                i_Item.Prev.Show();
            }
        }

        public class ShowVersion : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                Console.WriteLine("App Version: 25.1.4.5480");
                i_Item.Prev.Show();
            }
        }

        public class Back : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                Console.Clear();
                i_Item.Prev.Prev.Show();
            }
        }

        public class Show : TestActionObserver
        {
            public override void OnAction(Ex04.Menus.Interfaces.Item i_Item)
            {
                Console.Clear();
                i_Item.Show();

            }
        }

        public Test(List<Menu> i_MainMenus)
        {
            foreach(Menu menu in i_MainMenus)
            {
                menu.Show();
            }
        }
    }
}
