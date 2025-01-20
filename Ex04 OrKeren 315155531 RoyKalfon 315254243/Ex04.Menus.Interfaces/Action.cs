using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ex04.Menus.Interfaces
{
    public enum eActionTypes
    {
        Exit,
        Back,
        ShowVersion,
        CountLowercaseLetters,
        ShowCurrentDateTime,
        ShowCurrentDate
    }
        
    public class Action : Item
    {
        public eActionTypes ActionType { get; private set; }
        public Action(string i_Header, Menu i_Prev, eActionTypes i_ActionType) : base(i_Header, i_Prev) 
        { 
            this.ActionType = i_ActionType;
        }

        public override void Show() { }

        private void notifyObservers(Item i_Item)
        {
            foreach (IObserver observer in Observers)
            {
                observer.OnUserSelect(i_Item);
            }
        }
    }
}
