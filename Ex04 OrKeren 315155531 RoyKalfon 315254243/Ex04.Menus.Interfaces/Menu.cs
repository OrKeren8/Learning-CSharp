using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ex04.Menus.Interfaces
{
    public class Menu: Item
    {
        
        private readonly List<string> ZeroString = new List<string> { "exit", "go back" };

        public Menu(string i_Header): base(i_Header) { }

        public override void Show()
        {
            int index = 1;
            printHeader();
            foreach (var item in Items)
            {
                this.printItem(item, index);
                index++;
            }
            int zeroStringIndex = this.LevelInMenu > 0 ? 1: 0;
            Console.WriteLine($"0. to {this.ZeroString[zeroStringIndex]}");

            int userChoice = this.getValidChoiceFromUser();
            this.notifyObservers(Items[userChoice - 1]);
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
                Console.WriteLine($"Please enter your choice (1-{max} or 0 to {this.ZeroString[this.LevelInMenu]})");
                userChoice = Console.ReadLine();
                parseSuccess = int.TryParse(userChoice, out itemIndex);
                if (parseSuccess && itemIndex<=max)
                {
                   isValid = true;
                }
            }

            return itemIndex;
        }
    }
}
