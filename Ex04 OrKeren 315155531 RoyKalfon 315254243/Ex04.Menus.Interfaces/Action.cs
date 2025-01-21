using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ex04.Menus.Interfaces
{
    public class Action : Item
    {
        public Action(string i_Header, Menu i_Prev, IActionObserver i_ActionObserver) : base(i_Header, i_Prev, i_ActionObserver) { }

        public override void Show() { }
    }
}
