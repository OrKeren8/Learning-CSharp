using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BackEnd
{
    public class GameManager
    {
        private Player m_Player1;
        private Player m_Player2;
        public Player CurrPlayer { get; private set; }
        public Player LastPlayer { get; private set; }
        public Move LastMove { get; private set; }
        public Board GameBoard { get; private set; }

        public GameManager(Player i_Player1, Player i_Player2, int i_BoardSize)
        {
            Player1 = i_Player1;
            Player2 = i_Player2;
            GameBoard = new Board(i_BoardSize);
            CurrPlayer = Player1;
            LastPlayer = Player2;
        }

        public Player Player1
        {
            get { return m_Player1; }
            private set { m_Player1 = value; }
        }

        public Player Player2
        {
            get { return m_Player2; }
            private set { m_Player2 = value; }
        }

        public void EndGameRound()
        {
            updatePlayersPoints();
        }

        public void StartNewRound(int i_BoardSize)
        {
            GameBoard = new Board(i_BoardSize);
            CurrPlayer = Player1;
            LastPlayer = Player2;
            LastMove = new Move();
        }

        public void AddPlayer(Player i_Player)
        {
            Console.WriteLine("GameManager: new player was added");
        }
        
        private bool isAnotherMoveAfterEat()
        {
            return (CurrPlayer.PieceSymbol == LastPlayer.PieceSymbol);
        }

        private void updatePlayersPoints()
        {
            int player1Points = GameBoard.GetNumOfPiecesBySymbol(Player1.PieceSymbol) +
                                GameBoard.GetNumOfPiecesBySymbol(Player1.KingPieceSymbol) * 4;
            int player2Points = GameBoard.GetNumOfPiecesBySymbol(Player2.PieceSymbol) +
                                GameBoard.GetNumOfPiecesBySymbol(Player2.KingPieceSymbol) * 4;

            int player1AdditionalPoints = player1Points - player2Points;
            if(player1AdditionalPoints > 0) 
            {
                m_Player1.Points += player1AdditionalPoints;
            }
            else
            {
                m_Player2.Points += Math.Abs(player1AdditionalPoints);
            }
        }

        public bool MovePiece(Move i_Move)
        {
            bool anotherMove, isValidMove;

            if (CurrPlayer.IsPc)
            {
                if (isAnotherMoveAfterEat())
                {
                    getRandomMove(LastMove.DestinationPos, out i_Move);
                }
                else
                {
                    getRandomMove(null, out i_Move);
                }
            }

            if (!isAnotherMoveAfterEat())
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
