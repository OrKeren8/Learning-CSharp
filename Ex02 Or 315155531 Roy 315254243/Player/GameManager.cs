using System;
using System.Collections.Generic;

namespace BackEnd
{
    public class GameManager
    {

        private Player m_Player1;
        private Player m_Player2;

        private Board m_Board;

        public GameManager(Player i_Player1, Player i_Player2, uint i_BoardSize) 
        {
            m_Player1 = i_Player1;
            m_Player2 = i_Player2;
            m_Board = new Board(i_BoardSize);
        }

        public Player Player1
        {
            get { return m_Player1; }
        }

        public Player Player2
        {
            get { return m_Player2; }
        }

        public Board getBoard
        {
            get { return m_Board; }
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

        public bool MovePiece(string i_Move)
        {
            //bool isValid = true;
            //if()

        }

    }
}
