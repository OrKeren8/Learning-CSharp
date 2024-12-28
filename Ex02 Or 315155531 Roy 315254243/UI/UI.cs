using BackEnd;
using System;
using Utils;

namespace UI
{
    public class UI
    {
        private Menu m_Menu;
        private GameManager m_GameManager;

        

        public UI ()
        {
            m_GameManager = new GameManager();
            m_Menu = new Menu(m_GameManager);
        }

        public void GameMainLoop()
        {
            bool isContinueGame = true;
            while (isContinueGame == true)
            {
                printMenu();
                Menu.eMenuSelect userSelection = getUserSelection();
                switch (userSelection)
                {
                    case Menu.eMenuSelect.AddPlayer:
                        Player player = getPlayerFromUser();
                        m_Menu.AddPlayer(player);
                        break;
                    case Menu.eMenuSelect.StartGame:
                        m_Menu.StartGame();
                        break;
                    case Menu.eMenuSelect.Quit:
                        m_Menu.Quit();
                        break;

                }
                   
            }

        }
        
        private void printMenu()
        {
            Console.WriteLine(m_Menu.MenuStr);
        }

        private Player getPlayerFromUser()
        {
            string playerName = " ";

            while (!StringValidator.IsValidName(playerName))
            {
                Console.WriteLine("Please enter player's name");
                playerName = Console.ReadLine();
            }
            return new Player(playerName, i_IsPc:false);
        }
        
        private Menu.eMenuSelect getUserSelection()
        {
            Menu.eMenuSelect userSelection;
            int userIntChoice;
            string userChoice;
            
            Console.WriteLine("Enter Choice");
            userChoice = Console.ReadLine();
            while(!StringValidator.ToIntRange(Enums.GetMinValue<Menu.eMenuSelect>(),
                                        Enums.GetMaxValue<Menu.eMenuSelect>(),
                                        userChoice,
                                        out userIntChoice))
            {
                Console.WriteLine("Enter Choice");
                userChoice = Console.ReadLine();
            }

            userSelection = (Menu.eMenuSelect)userIntChoice;
            return userSelection;
        }
    }
}
