using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Ex04.Menus.Interfaces
{
    public class Menu: Item
    {
        
        private readonly List<string> ZeroString = new List<string> { "exit", "go back" };

        public Menu(string i_Header, Menu i_Prev): base(i_Header, i_Prev) 
        {
            var (existOrBack, existOrBackStr) = this.Prev == null ? (eActionTypes.Exit, this.ZeroString[0]) : (eActionTypes.Back, this.ZeroString[1]);
            new Action(existOrBackStr, this, existOrBack);

        }

        public override void Show()
        {
            printHeader();
            for(int i=1; i<this.Items.Count; i++ )
            {
                this.printItem(this.Items[i], i);

            }
            
            int zeroStringIndex = (this.Prev != null) ? 1: 0;
            Console.WriteLine($"0. to {this.ZeroString[zeroStringIndex]}");

            int userChoice = this.getValidChoiceFromUser();
            this.notifyObservers(Items[userChoice]);
        }

        private void notifyObservers(Item i_Item)
        {
            foreach (IObserver observer in Observers)
            {
                observer.OnUserSelect(i_Item);
            }
        }

        private void printItem(Item i_Item, int i_Index)
        {
            Console.WriteLine($"{i_Index}. {i_Item.Header}");
        }

        private void printHeader()
        {
            Console.WriteLine($"** {this.Header} **");
            Console.WriteLine("------------------------");
        }

        private int getValidChoiceFromUser()
        {
            string userChoice;
            int itemIndex = 0;
            int max = this.Items.Count;
            bool isValid = false, parseSuccess = false;
            
            while (!(isValid  && parseSuccess))
            {
                int zeroStringIndex = (this.Prev != null) ? 1 : 0;
                Console.WriteLine($"Please enter your choice (1-{max} or 0 to {this.ZeroString[zeroStringIndex]})");
                userChoice = Console.ReadLine();
                parseSuccess = int.TryParse(userChoice, out itemIndex);
                if (parseSuccess && itemIndex<=max)
                {
                   isValid = true;
                }
            }

            return itemIndex;
        }

        public virtual void DetachObserver(IObserver i_Observer)
        {
           foreach (Item item in this.Items)
           {
                item.DetachObserver(i_Observer);
           }
            
        }
    }
}
