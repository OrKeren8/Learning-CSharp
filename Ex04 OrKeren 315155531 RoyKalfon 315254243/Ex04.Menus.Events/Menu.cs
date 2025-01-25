using System.Collections.Generic;
using System;

namespace Ex04.Menus.Events
{
    public class Menu : Item
    {
        private readonly List<string> r_ZeroString = new List<string> { "exit", "go back" };
        public Menu(string i_Header, Menu i_Prev) : base(i_Header, i_Prev){}

        public override void Show()
        {
            printHeader();
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.printItem(this.Items[i], i+1);
            }
            int zeroStringIndex = (this.Prev != null) ? 1 : 0;
            Console.WriteLine($"0. to {this.r_ZeroString[zeroStringIndex]}");
            int userChoice = this.getValidChoiceFromUser();
            if(userChoice == 0)
            {
                if(this.Prev != null)
                {
                    this.goBack();
                }
            }
            else
            {
                userChoice = userChoice - 1;
                if(Items[userChoice] is Events.Menu)
                {
                    Console.WriteLine();
                    Items[userChoice].Show();
                }

                else
                {
                    Items[userChoice].NotifyObservers(); //only when item is from action type
                    Console.WriteLine();
                    this.Show();
                }
            }

            Console.WriteLine();
        }

        private void printItem(Item i_Item, int i_Index)
        {
            Console.WriteLine($"{i_Index}. {i_Item.Header}");
        }

        private void printHeader()
        {
            Console.WriteLine($"** {this.Header} **");
            Console.WriteLine("-----------------------------");
        }

        private int getValidChoiceFromUser()
        {
            int itemIndex = 0;
            int max = this.Items.Count;
            bool isValid = false, parseSuccess = false;

            while (!(isValid && parseSuccess))
            {
                int zeroStringIndex = (this.Prev != null) ? 1 : 0;
                Console.WriteLine($"Please enter your choice (1-{max} or 0 to {this.r_ZeroString[zeroStringIndex]})");
                string userChoice = Console.ReadLine();
                parseSuccess = int.TryParse(userChoice, out itemIndex);
                if (parseSuccess && itemIndex <= max)
                {
                    isValid = true;
                }
            }

            return itemIndex;
        }

        private void goBack()
        {
            Console.Clear();
            this.Prev.Show();
        }
    }
}
