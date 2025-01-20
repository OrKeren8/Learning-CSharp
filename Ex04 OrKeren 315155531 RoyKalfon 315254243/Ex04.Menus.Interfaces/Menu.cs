using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ex04.Menus.Interfaces
{
    internal class Menu: Item
    {
        private List<Item> Items { get; set; } = new List<Item> { new Item("exitOrBack") };
        private readonly List<string> ZeroString = new List<string> { "exit", "go back" };
        private int MenuLevel = 0;
        private readonly List<IObserver> Observers = new List<IObserver>();
        public void Show()
        {
            int index = 1;
            Console.WriteLine(this.Header);
            foreach (var item in Items)
            {
                this.printItem(item, index);
                index++;
            }
            int userChoice = this.getValidChoiceFromUser();
            this.notifyObservers(Items[userChoice]);
        }

        private void notifyObservers(Item i_Item)
        {
            foreach (IObserver observer in Observers)
            {
                observer.NotifySelectedItem(i_Item);
            }
        }

        private void printItem(Item i_Item, int i_Index)
        {
            Console.WriteLine($"{i_Index}. {i_Item.Header}");
        }

        private int getValidChoiceFromUser()
        {
            string userChoice;
            int itemIndex = 0;
            int max = this.Items.Count;
            bool isValid = false, parseSuccess = false;
            
            while (!(isValid  && parseSuccess))
            {
                Console.WriteLine($"Please enter your choice (1-{max} or 0 to {this.ZeroString[this.MenuLevel]}");
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
