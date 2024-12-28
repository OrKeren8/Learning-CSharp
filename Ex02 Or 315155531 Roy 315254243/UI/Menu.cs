using System;
using BackEnd;

namespace UI
{
    public class Menu
    {
        public enum eMenuSelect
        {
            StartGame = 1,
            Quit = 2
        }

        private string m_MenuStr =  "1: Start Game\n" +
                                    "2: Quit";

        public string MenuStr
        {
            get { return m_MenuStr; }
        }       
    }
}
