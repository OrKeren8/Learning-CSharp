using System;
using System.Collections.Generic;

namespace BackEnd
{
    public class GameManager
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player CurrPlayer { get; private set;}
        public Player LastPlayer { get; private set; }
        private Move LastMove { get; set; }
        public Board GameBoard { get; private set; }

        public GameManager(Player i_Player1, Player i_Player2, int i_BoardSize) 
        {
            Player1 = i_Player1;
            Player2 = i_Player2;
            GameBoard = new Board(i_BoardSize);
            CurrPlayer = Player1;
            LastPlayer = Player2;
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


            if(GameBoard.checkIfDontSameGroupMembers(CurrPlayer.PieceSymbol, LastPlayer.PieceSymbol))
            {
                isValidMove = GameBoard.MovePiece(i_Move, CurrPlayer.PieceSymbol, out anotherMove, null);
            }
            else
            {
                isValidMove = GameBoard.MovePiece(i_Move, CurrPlayer.PieceSymbol, out anotherMove, LastMove.DestinationPos);
            }
            if (isValidMove)
            {
                LastMove = i_Move;
                LastPlayer = CurrPlayer;
                if(anotherMove)
                {
                    CurrPlayer = (CurrPlayer.PieceSymbol == Player1.PieceSymbol) ? Player1 : Player2;
                }
                else
                {
                    CurrPlayer = (CurrPlayer.PieceSymbol == Player1.PieceSymbol) ? Player2 : Player1;
                }
            }

            return isValidMove;
        }

        
    }

}
