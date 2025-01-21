using Ex04.Menus.Interfaces;
using System;
using System.Collections.Generic;



namespace Ex04.Menus.Test
{
    internal class Test: IObserver
    {
        private List<Item> Items { get; set; }

        public Test(List<Item> i_Items)
        {
            this.Items = i_Items;
            foreach (Item item in i_Items)
            {
                item.AttachObserver(this as IObserver);
            }
        }

        public void OnUserSelect(Item i_Item)
        {
            if(i_Item is Menu)
            {
                Console.Clear();
                i_Item.Show();
            }
            else
            {
                this.implementAction((i_Item as Interfaces.Action).ActionType, (i_Item as Interfaces.Action));
                Console.WriteLine();
                i_Item.Prev.Show();
            }
        }

        private void implementAction(eActionTypes i_ActionType, Interfaces.Action I_Action) 
        {
            switch (i_ActionType)
            {
                case eActionTypes.CountLowercaseLetters:
                    this.countLowercaseLetters();
                    break;
                case eActionTypes.ShowCurrentDate:
                    this.showCurrentDate();
                    break;
                case eActionTypes.ShowCurrentDateTime:
                    this.showCurrentDateTime();
                    break;
                case eActionTypes.ShowVersion:
                    this.showVersion();
                    break;
                case eActionTypes.Exit:
                    this.exit(I_Action);
                    break;
                case eActionTypes.Back:
                    this.back(I_Action);
                    break;
            }
        }
        private int countLowercaseLetters()
        {
            int countOfLowerCase = 0;
            Console.WriteLine("Please enter your string: ");
            string userStringInput = Console.ReadLine();
            foreach(char currenChar in userStringInput)
            {
                if (currenChar >= 'a' || currenChar <= 'z')
                {
                    countOfLowerCase++;
                }
            }
            return countOfLowerCase;
        }
        private void showCurrentDate()
        {
            DateTime currentDate = DateTime.Today;
            Console.WriteLine($"Current Date is {currentDate.Day}/{currentDate.Month}/{currentDate.Year}");
        }
        private void showCurrentDateTime()
        {
            DateTime currentDate = DateTime.Today;
            Console.WriteLine($"Current Date is {currentDate.Hour}:{currentDate.Second}/{currentDate.Millisecond}");
        }
        private void showVersion()
        {
            Console.WriteLine("App Version: 25.1.4.5480");
        }

        private void exit(Item i_Item)
        {
            i_Item.Prev.DetachObserver(this as IObserver);
        }

        private void back(Item i_Item)
        {
            Console.Clear();
            i_Item.Prev.Prev.Show();
        }

    }
}
