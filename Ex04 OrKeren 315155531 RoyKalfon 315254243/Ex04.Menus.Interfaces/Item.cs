using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{

    public interface IActionObserver
    {
        int GetObserverFamilyCode();
        void OnAction(Item i_Item);
    }

    public abstract class Item
    {
        public string Header { get; private set; }
        internal List<IActionObserver> Observers = new List<IActionObserver>();
        internal List<Item> Items { get; set; } = new List<Item> {};
        public Menu Prev {  get; private set; } = null;

        public Item(string i_Header, Menu prev, IActionObserver i_ActionObserver)
        {
            this.Header = i_Header;
            Prev = prev;
            prev?.AddItem(this);
            this.Observers.Add(i_ActionObserver);
        }

        public void AddItem(Item i_Item)
        {
            this.Items.Add(i_Item);
        }

        public void AttachObserver(IActionObserver i_Observer)
        {
            this.Observers.Add(i_Observer);
        }

        public virtual void DetachObserver(IActionObserver i_Observer)
        {
            var observersToRemove = new List<IActionObserver>();

            foreach (var observer in this.Observers)
            {
                if (observer.GetObserverFamilyCode() == i_Observer.GetObserverFamilyCode())
                {
                    observersToRemove.Add(observer);
                }
            }

            foreach (var observer in observersToRemove)
            {
                this.Observers.Remove(observer);
            }
        }

        internal void notifyObservers()
        {
            List<IActionObserver> observersCopy = new List<IActionObserver>(this.Observers);

            foreach (IActionObserver observer in observersCopy)
            {
                observer.OnAction(this);
            }
        }

        public abstract void Show();

    }
}
