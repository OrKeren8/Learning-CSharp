using System;
using BackEnd;

namespace UI
{
    public class Menu
    {
        public enum eMenuSelect
        {
            AddPlayer = 1,
            StartGame = 2,
            Quit = 3
        }

        private string m_MenuStr =  "1: Enter Your Name\n" +
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

        public void StartGame()
        {
            m_GameManager.Restart();
        }

        public void Quit()
        {
            m_GameManager.QuitGame();
            Environment.Exit(0);
        }

        public void AddPlayer(Player i_Player)
        {
            m_GameManager.AddPlayer(i_Player);
        }

        //public int GetUserSelection()
        //{

        //}


    }
}
