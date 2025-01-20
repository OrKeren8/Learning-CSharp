using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    internal class Menu: Item
    {
        private List<Item> Items {  get; set; }
        private string Header { get; set; }
        private readonly List<string> ZeroString = new List<string> { "exit", "go back" };
        private int MenuLevel = 0;
        private readonly List<IObserver> Observers = new List<IObserver>();
        public void Show()
        {
            int maxVal = this.Items.Count;
            Console.WriteLine(this.Header);
            foreach (var item in Items)
            {
                this.printItem(item, index);
            }
            Console.WriteLine($"Please enter your choice (1-{maxVal} or 0 to {this.ZeroString[this.MenuLevel]}");
            string userChoice = this.getValidChoiceFromUser();
            
        }

        private void notifyObservers(Item i_Item)
        {
            foreach (IObserver observer in Observers)
            {
                observer.NotifySelectedItem(i_Item);
            }
        }


    }
}
