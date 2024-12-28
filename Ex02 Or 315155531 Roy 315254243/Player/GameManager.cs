using System;

namespace BackEnd
{
    public class GameManager
    {

        Player player1;
        Player player2;

        public GameManager(Player i_Player1, Player i_Player2) 
        {
            player1 = i_Player1;
            player2 = i_Player2;
        }

        public void Start()
        {
            Console.WriteLine("GameManager: restarting game");
        }

        public void QuitGame()
        {
            Console.WriteLine("GameManager: quitting game");
        }

        public void StartGame()
        {
            Console.WriteLine("GameManager: start game");
        }

        public void AddPlayer(Player i_Player)
        {
            Console.WriteLine("GameManager: new player was added");
        }
    }
}
