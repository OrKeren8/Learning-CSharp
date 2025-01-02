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
        
        private bool isAnotherMoveAfterEat()
        {
            return (CurrPlayer.PieceSymbol == LastPlayer.PieceSymbol);
        }

        public bool MovePiece(Move? i_Move)
        {
            bool anotherMove, isValidMove;
            Move move;

            if (CurrPlayer.IsPc)
            {
                if (isAnotherMoveAfterEat())
                {
                    getRandomMove(LastMove.DestinationPos, out move);
                }
                else
                {
                    getRandomMove(LastMove.DestinationPos, out move);
                }
            }
            else
            {
                move = i_Move.Value;
            }

            if (!isAnotherMoveAfterEat())
            {
                isValidMove = GameBoard.MovePiece(move, CurrPlayer.PieceSymbol, out anotherMove, null);
            }
            else
            {
                isValidMove = GameBoard.MovePiece(move, CurrPlayer.PieceSymbol, out anotherMove, LastMove.DestinationPos);
            }
            if (isValidMove)
            {
                LastMove = move;
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
        private bool getRandomMove(Position? i_FromPos, out Move o_RandomMove)
        {
            bool isSucceed = false;
            o_RandomMove = new Move();
            List<Move> eatingMoves = new List<Move>();
            List<Move> regularMoves = new List<Move>();

            if (i_FromPos.HasValue)
            {
                Piece? fromPiece = GameBoard.GetPeiceFromBoard(i_FromPos.Value);
                if (fromPiece.HasValue)
                {
                    GameBoard.GetSinglePoneMovements(fromPiece.Value, eatingMoves, regularMoves);
                    isSucceed = eatingMoves.Count>0 || regularMoves.Count>0 ? true : false;
                }
            }
            else
            {
                GameBoard.GetAllPonesMovements(CurrPlayer.PieceSymbol, eatingMoves, regularMoves);
                isSucceed = eatingMoves.Count > 0 || regularMoves.Count > 0 ? true : false;
            }
            if (isSucceed)
            {
                o_RandomMove = (eatingMoves.Count>0)? getRandomItemFromList(eatingMoves) : getRandomItemFromList(regularMoves);
            }

            return isSucceed;
        }

        private T getRandomItemFromList<T>(List<T> i_List)
        {
            Random random = new Random();

            return i_List[random.Next(i_List.Count)];
        }

    }

}
