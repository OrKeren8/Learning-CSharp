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
            Console.Clear();
            i_Item.Show();
        }

    }
}
