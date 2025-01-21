using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class Item
    {
        public string Header { get; private set; }
        internal List<Item> Items { get; set; } = new List<Item> { };
        public Menu Prev { get; private set; } = null;

        public event Action m_OnActionDelegates;

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

        internal void notifyObservers()
        {
            if (this.m_OnActionDelegates != null)
            {
                this.m_OnActionDelegates.Invoke();
            }
        }

        public virtual void Show() { }
    }
}