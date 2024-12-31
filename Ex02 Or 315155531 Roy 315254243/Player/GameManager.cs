using System;
using System.Collections.Generic;

namespace BackEnd
{
    public class GameManager
    {

        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player CurrPlayerTurn { get; private set;}

        public Board GameBoard { get; private set; }

        public GameManager(Player i_Player1, Player i_Player2, int i_BoardSize) 
        {
            Player1 = i_Player1;
            Player2 = i_Player2;
            GameBoard = new Board(i_BoardSize);
            CurrPlayerTurn = Player1;
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

        public bool MovePiece(Move i_Move)
        {
            bool anotherMove, isValidMove;

            isValidMove = GameBoard.MovePiece(i_Move, CurrPlayerTurn.PieceSymbol, out anotherMove);
            if(anotherMove)
            {
                CurrPlayerTurn = (CurrPlayerTurn.PieceSymbol == Player1.PieceSymbol) ? Player1 : Player2;
            }
            else
            {
                CurrPlayerTurn = (CurrPlayerTurn.PieceSymbol == Player1.PieceSymbol) ? Player2 : Player1;
            }

            return isValidMove;
        }
    }
}
