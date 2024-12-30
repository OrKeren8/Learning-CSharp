using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BackEnd
{
    public class Board
    {
        private Piece?[,] m_Board;
        public int Size { get; private set; }


        public Board(int i_Size)
        {
            Size = i_Size;
            m_Board = new Piece?[i_Size, i_Size];
            initBoard(i_Size);
        }
        public string GetRowSymbols(int i_Row)
        {
            StringBuilder rowOfSymbols = new StringBuilder(new string(' ', Size));

            for (int i = 0; i < Size; i++)
            {
                if(m_Board[i_Row, i] != null)
                {
                    rowOfSymbols.Insert(i, m_Board[i_Row, i].Value.Symbol.ToString());
                }
            }

            return rowOfSymbols.ToString();
        }

        private void getAllPonesMovements(ePieceSymbol i_Symbol, List<Move> o_EatMoves, List<Move> o_RegularMoves)
        {
            ///this function will check all the moves all pieces can do
            ///and return them as a list
            List<Piece> piecesList = getAllPieces(i_Symbol); 

            foreach (Piece piece in piecesList) 
            {
                getSinglePoneMovements(piece, o_EatMoves, o_RegularMoves);
            }
        }

        private void getSinglePoneMovements( Piece i_Piece,
                                                List<Move> o_EatMoves,
                                                List<Move> o_RegularMoves)
        {
            ///this function returns all the eating moves a specific piece can do
            
            switch (i_Piece.Direction) 
            {
                case ePieceDirection.KingAnywhere:
                    appendNextPieceMove(i_Piece, o_EatMoves, o_RegularMoves, new Position(-1, -1));
                    appendNextPieceMove(i_Piece, o_EatMoves, o_RegularMoves, new Position(-1, 1));
                    appendNextPieceMove(i_Piece, o_EatMoves, o_RegularMoves, new Position(1, -1));
                    appendNextPieceMove(i_Piece, o_EatMoves, o_RegularMoves, new Position(1, 1));
                    break;
                case ePieceDirection.Up:
                    appendNextPieceMove(i_Piece, o_EatMoves, o_RegularMoves, new Position(-1, -1));
                    appendNextPieceMove(i_Piece, o_EatMoves, o_RegularMoves, new Position(-1, 1));
                    break;
                case ePieceDirection.Down:
                    appendNextPieceMove(i_Piece, o_EatMoves, o_RegularMoves, new Position(1, -1));
                    appendNextPieceMove(i_Piece, o_EatMoves, o_RegularMoves, new Position(1, 1));
                    break;
            }
        }

        private void appendNextPieceMove(Piece i_Piece,
                                        List<Move> o_EatMoves,
                                        List<Move> o_RegularMoves,
                                        Position i_MoveDelta)
        {
            
            Position newPos = new Position(i_Piece.position.Row + i_MoveDelta.Row, i_Piece.position.Col + i_MoveDelta.Col);
            Position afterNewPosInSameDirection = new Position(newPos.Row + i_MoveDelta.Row, newPos.Col + i_MoveDelta.Col);

            //check if there is a valid move to the desired direction
            if (!checkIfPositionFree(newPos) &&
                (getPeiceFromBoard(newPos) != null) &&
                (getPeiceFromBoard(newPos).Value.Symbol != i_Piece.Symbol) &&
                checkIfPositionFree(afterNewPosInSameDirection))
            {
                o_EatMoves.Add(new Move(i_Piece.position, afterNewPosInSameDirection));
            }
            else if (checkIfPositionFree(newPos))
            {
                o_RegularMoves.Add(new Move(i_Piece.position, newPos));
            }
        }
      
        private List<Piece> getAllPieces(ePieceSymbol i_Symbol)
        {
            List<Piece> allPieces = new List<Piece>();

            foreach (Piece? piece in m_Board)
            {
                if(piece.HasValue && piece.Value.Symbol == i_Symbol)
                {
                    allPieces.Add(piece.Value);
                }
            }

            return allPieces;
        }

        public bool MovePiece(Move i_Move, ePieceSymbol i_PieceSymbol)
        {
            /*this function checks if a pone can move inside the board
             * if it cant, false will return from the function and nothing will happen
             */
            bool isValidMove = true;

            isValidMove = checkMove(i_Move, i_PieceSymbol);

            if (isValidMove) 
            {
                Piece? nullablePiece;
                isValidMove &= extractPeiceFromBoard(i_Move.StartPos, out nullablePiece);
                if (isValidMove)
                {
                    Piece piece = (Piece)nullablePiece;
                    piece.position = i_Move.DestinationPos;
                    isValidMove = insertPiece(piece);
                }
            }

            return isValidMove;
        }

        private bool checkMove(Move move, ePieceSymbol i_PieceSymbol)
        {
            ///this function checks the movment a player wants to play
            ///if there is an option to "eat" an openent piece, this kind of move must be played
            ///otherwise a regular move will be valid and regular move check will occur
            bool isValid = true;
            List<Move> avaliableEatingMoves = new List<Move>();
            List<Move> avaliableRegularMoves = new List<Move>();

            getAllPonesMovements(i_PieceSymbol, avaliableEatingMoves, avaliableRegularMoves);

            if ((avaliableEatingMoves.Count > 0) && !avaliableEatingMoves.Contains(move))
            {
                isValid = false;
            }
            else if (!avaliableRegularMoves.Contains(move))
            {
                isValid = false;
            }
            //TODO: if eat a pone need to play another time
            //TODO: if did not valid move we dont want to calc all the moves again

            return isValid;
        }

        private bool checkIfPositionFree(Position i_Pos)
        {
            ///return false if the position is taken or not exist,
            ///true if the position exist and free from other pieces
            bool isFree;

            isFree = checkIfPositionInBoard(i_Pos);
            isFree &= (m_Board[i_Pos.Row, i_Pos.Col] == null);

            return isFree;
        }

        private bool checkIfPositionInBoard(Position i_Pos)
        {
            bool isValid = true;

            if (i_Pos.Row < 0 || i_Pos.Row >= Size || i_Pos.Col < 0 || i_Pos.Col >= Size)
            {
                isValid = false;
            }

            return isValid;
        }

        private bool insertPiece(Piece i_Piece)
        {
            ///insert a piece in the board
            ///if could not do the action, a false will return
            bool canInsert = true;
            Position pos = i_Piece.position;

            canInsert = checkIfPositionInBoard(pos);
            //need to check if there is a pone in that location already
            if (canInsert)
            {
                m_Board[pos.Row, pos.Col] = i_Piece;
            }

            return canInsert;
        }

        private bool extractPeiceFromBoard(Position i_Pos, out Piece? o_Piece)
        {
            ///this functioin take a pone from the board and return it as an output 
            ///variable, bool for success/fail action will be returned
            ///good for moving a pone in the board or when a pone is eaten
            bool isPieceExist = false;
            
            o_Piece = m_Board[i_Pos.Row, i_Pos.Col];
            if (o_Piece != null)
            {
                
                m_Board[i_Pos.Row, i_Pos.Col] = null;
                isPieceExist = true;
            }

            return isPieceExist;
        }

        private Piece? getPeiceFromBoard(Position i_Pos)
        {
            ///this function returns a copy of a piece or null from the board for read only matters
            Piece? piece = null;

            if (checkIfPositionInBoard(i_Pos))
            {
                piece = m_Board[i_Pos.Row, i_Pos.Col];
            }
            
            return piece;
        }

        /*
        private void InitializeBoard()
        {
            int size = grid.GetLength(0);
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row < (size / 2) - 1 && (row + col) % 2 != 0)
                        grid[row, col] = 'O'; // Player 2
                    else if (row >= (size / 2) + 1 && (row + col) % 2 != 0)
                        grid[row, col] = 'X'; // Player 1
                    else
                        grid[row, col] = ' ';
                }
            }
        }*/

        private void initBoard(int i_Size)
        {
            m_Board = new Piece?[i_Size, i_Size];

            for (int i = 0; i < (i_Size / 2) - 1; i++)
            {
                for (int j = 0; j < i_Size; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 != 0)
                        {
                            insertPiece(new Piece(ePieceSymbol.O, new Position(i, j)));
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            insertPiece(new Piece(ePieceSymbol.O, new Position(i, j)));
                        }
                    }
                }
            }
            for (int i = i_Size-1; i > (i_Size / 2); i--)
            {
                for (int j = 0; j < i_Size; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            insertPiece(new Piece(ePieceSymbol.X, new Position(i, j)));
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            insertPiece(new Piece(ePieceSymbol.X, new Position(i, j)));
                        }
                    }
                }
            }
        }
    }
}
