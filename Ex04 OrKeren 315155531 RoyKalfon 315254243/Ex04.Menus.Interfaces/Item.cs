using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{

    public interface IObserver
    {
        void OnUserSelect(Item i_Item);
    }

    public abstract class Item
    {
        public string Header { get; private set; }
        internal readonly List<IObserver> Observers = new List<IObserver>();
        internal List<Item> Items { get; set; } = new List<Item> {};
        public Menu Prev {  get; private set; } = null;

        public Item(string i_Header, Menu prev)
        {
            this.Header = i_Header;
            Prev = prev;
            prev?.AddItem(this);
        }

        public void AddItem(Item i_Item)
        {
            this.Items.Add(i_Item);
        }

        public void AttachObserver(IObserver i_Observer)
        {
            this.Observers.Add(i_Observer);
        }

        public virtual void DetachObserver(IObserver i_Observer)
        {
            this.Observers.Remove(i_Observer);
        }

        public abstract void Show();

    }
}
