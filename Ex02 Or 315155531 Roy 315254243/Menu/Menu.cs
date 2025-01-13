using System;
using BackEnd;

namespace Menu
{
    public class Menu
    {
        private string m_MenuStr =  "1: Add Player\n" +
                                    "2: Start Game\n" +
                                    "3: Quit";

        private GameManager m_GameManager;
        
        public Menu(GameManager io_GameManager)
        {
            m_GameManager = io_GameManager;
        }
        
        public string MenuStr
        {
            get { return m_MenuStr; }
        }

        private void StartGame()
        {
            m_GameManager.StartNewGame();
        }

        private void Quit()
        {
            m_GameManager.QuitGame();
            Environment.Exit(0);
        }

        public void AddPlayer(int i_ID, string i_Name, bool i_IsPc)
        {
            m_GameManager.AddPlayer(i_ID, i_Name, i_IsPc);
        }

        //public int GetUserSelection()
        //{

        //}

        
    }
}
