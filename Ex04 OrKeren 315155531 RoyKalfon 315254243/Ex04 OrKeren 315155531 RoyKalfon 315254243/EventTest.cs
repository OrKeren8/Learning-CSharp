﻿using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;


namespace Ex04.Menus.Test
{
   /* interface TestActionObserver
    {
        void OnAction(Events.Item i_Item);
    }*/

    public class EventTest
    {
        public class BaseAction
        {
            public BaseAction(Events.Item i_Action) 
            {
                i_Action.m_OnActionDelegates += new System.Action<Events.Item>(this.OnAction);
                
            }

            public virtual void OnAction(Events.Item i_Item) { }
        }
            
        public class CountLowercaseLetters : BaseAction
        {
            
            public CountLowercaseLetters(Events.Item i_Action): base(i_Action) { }
            public override void OnAction(Events.Item i_Item)
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

        public class ShowCurrentDate : BaseAction
        {
            public ShowCurrentDate(Events.Item i_Action): base(i_Action) { }

            public override void OnAction(Events.Item i_Item)
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine($"Current Date is {currentDate.Day}/{currentDate.Month}/{currentDate.Year}");
                i_Item.Prev.Show();
            }
        }

        public class ShowCurrentDateTime : BaseAction
        {
            public ShowCurrentDateTime(Events.Item i_Action) : base(i_Action) { }
            public override void OnAction(Events.Item i_Item)
            {
                DateTime currentDate = DateTime.Now;
                Console.WriteLine($"Current Time is {currentDate.Hour}:{currentDate.Second}:{currentDate.Millisecond}");
                i_Item.Prev.Show();
            }
        }

        public class ShowVersion : BaseAction
        {
            public ShowVersion(Events.Item i_Action) : base(i_Action) { }
            public override void OnAction(Events.Item i_Item)
            {
                Console.WriteLine("App Version: 25.1.4.5480");
                i_Item.Prev.Show();
            }
        }
        public class Show : BaseAction
        {
            public Show(Events.Item i_Action) : base(i_Action) { }

            public override void OnAction(Events.Item i_Item)
            {
                Console.Clear();
                i_Item.Show();

            }
        }

        public EventTest(Events.Menu i_MainMenus)
        {
            i_MainMenus.Show();
        }
    }
}
