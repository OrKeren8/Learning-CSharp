using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{

    public interface IObserver
    {
        void NotifySelectedItem(Item i_Item);
    }

    public abstract class Item
    {
        public string Header { get; private set; }
        internal readonly List<IObserver> Observers = new List<IObserver>();
        internal List<Item> Items { get; set; } = new List<Item> {};

        public Item(string i_Header)
        {
            this.Header = i_Header;
        }

        public void AddItem(Item i_Item)
        {
            this.Items.Add(i_Item);
        }

        public void AttachObserver(IObserver i_Observer)
        {
            this.Observers.Add(i_Observer);
        }

        public void DetachObserver(IObserver i_Observer)
        {
            this.Observers.Remove(i_Observer);
        }

        public abstract void Show();

    }
}
