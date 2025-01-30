using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;


namespace Ex04.Menus.Test
{
    public class EventTest
    {
        public class BaseAction
        {
            public BaseAction(Events.Item i_Action) 
            {
                i_Action.OnActionDelegates += new System.Action<Events.Item>(this.Item_Selected);
            }

            public virtual void Item_Selected(Events.Item i_Item) { }
        }
            
        public class CountLowercaseLetters : BaseAction
        {
            public CountLowercaseLetters(Events.Item i_Action): base(i_Action) { }
   
            public override void Item_Selected(Events.Item i_Item)
            {
                int countOfLowerCase = 0;
                Console.WriteLine("Please enter your string: ");
                string userStringInput = Console.ReadLine();
                foreach (char currentChar in userStringInput)
                {
                    if (currentChar >= 'a' || currentChar <= 'z')
                    {
                        countOfLowerCase++;
                    }
                }
                Console.WriteLine($"The Amount of letters are: {countOfLowerCase}");
            }
        }

        public class ShowCurrentDate : BaseAction
        {
            public ShowCurrentDate(Events.Item i_Action): base(i_Action) { }

            public override void Item_Selected(Events.Item i_Item)
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine($"Current Date is {currentDate.Day}/{currentDate.Month}/{currentDate.Year}");
            }
        }

        public class ShowCurrentDateTime : BaseAction
        {
            public ShowCurrentDateTime(Events.Item i_Action) : base(i_Action) { }
            public override void Item_Selected(Events.Item i_Item)
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine($"Current Time is {currentDate.Hour}:{currentDate.Second}:{currentDate.Millisecond}");
            }
        }

        public class ShowVersion : BaseAction
        {
            public ShowVersion(Events.Item i_Action) : base(i_Action) { }
            public override void Item_Selected(Events.Item i_Item)
            {
                Console.WriteLine("App Version: 25.1.4.5480");
            }
        }

        public EventTest(Events.Menu i_MainMenus)
        {
            i_MainMenus.Show();
        }
    }
}
