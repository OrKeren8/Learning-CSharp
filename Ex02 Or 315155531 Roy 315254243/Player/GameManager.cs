using System;

namespace BackEnd
{
    public class GameManager
    {

        public void Restart()
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
