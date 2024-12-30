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
        public uint Size { get; private set; }


        public Board(uint i_Size)
        {
            Size = i_Size;
            m_Board = new Piece?[i_Size, i_Size];
            initBoard(i_Size);
        }
        public string GetRowSymbols(uint i_Row)
        {
            StringBuilder rowOfSymbols = new StringBuilder(new string(' ', (int)Size));

            for (int i = 0; i < Size; i++)
            {
                if(m_Board[i_Row, i] != null)
                {
                    rowOfSymbols.Insert(i, m_Board[i_Row, i].Value.Symbol.ToString());
                }
            }

            return rowOfSymbols.ToString();
        }

        private List<Move> getAllPonesEatMovements(ePieceSymbol i_Symbol)
        {
            ///this function will check all the moves a specific pone can do
            ///and return them as a list
            List<Piece> piecesList = getAllPieces(i_Symbol); 
            List<Move> avaliableEatingMoves = new List<Move>();

            foreach (Piece piece in piecesList) 
            {
                avaliableEatingMoves.Concat(getSinglePoneEatMovements(piece));
            }

            return avaliableEatingMoves;
        }

        private List<Move> getSinglePoneEatMovements(Piece i_Piece)
        {
            ///this function returns all the eating moves a specific piece can do
            List<Move> moves = new List<Move>();
            
            switch (i_Piece.Direction) 
            {
                case ePieceDirection.KingAnywhere:
                    moves.Concat(getUpperEatingMoves(i_Piece));
                    moves.Concat(getDownEatingMoves(i_Piece));
                    break;
                case ePieceDirection.Up:
                    moves.Concat(getUpperEatingMoves(i_Piece));
                    break;
                case ePieceDirection.Down:
                    moves.Concat(getDownEatingMoves(i_Piece));
                    break;
            }

            return moves;
        }



        private void getUpperEatingMoves(Piece i_Piece, out List<Move> o_EatMoves, out List<Move> o_RegularMoves)
        {
            ///this function get all valid moves a piece can do
            List<Move> eatMoves = new List<Move>();
            List<Move> regularMoves = new List<Move>();

            Position upperLeftPos = new Position(i_Piece.position.Row - 1, i_Piece.position.Col - 1); //we will have bug here because the inoputs are uint and we can have -1 here
            Position afterUpperLeftPos = new Position(upperLeftPos.Row - 1, upperLeftPos.Col - 1);
            Position upperRighPos = new Position(i_Piece.position.Row - 1, i_Piece.position.Col + 1);
            Position afterUpperRightPos = new Position(upperRighPos.Row - 1, upperRighPos.Col + 1);

            //check if there is a valid move to the up left
            if (!checkIfPositionFree(upperLeftPos) &&
                (getPeiceFromBoard(upperLeftPos) != null) &&
                (getPeiceFromBoard(upperLeftPos).Value.Symbol != i_Piece.Symbol) &&
                checkIfPositionFree(afterUpperLeftPos))
            {
                eatMoves.Add(new Move(i_Piece.position, afterUpperLeftPos));
            }
            else if (checkIfPositionFree(upperLeftPos))
            {
                regularMoves.Add(new Move(i_Piece.position, upperLeftPos));
            }

            //check if there is a valid move to the up right
            if (!checkIfPositionFree(upperRighPos) &&
                (getPeiceFromBoard(upperRighPos) != null) &&
                (getPeiceFromBoard(upperRighPos).Value.Symbol != i_Piece.Symbol) &&
                checkIfPositionFree(afterUpperRightPos))
            {
                eatMoves.Add(new Move(i_Piece.position, afterUpperRightPos));
            }
            else if (checkIfPositionFree(upperRighPos))
            {
                regularMoves.Add(new Move(i_Piece.position, upperRighPos));
            }
        }

        private void getDownEatingMoves(Piece i_Piece, out List<Move> o_EatMoves, out List<Move> o_RegularMoves)
        {
            ///this function get all valid moves a piece can do
            List<Move> eatMoves = new List<Move>();
            List<Move> regularMoves = new List<Move>();
            Position downLeftPos = new Position(i_Piece.position.Row + 1, i_Piece.position.Col - 1); 
            Position afterDownLeftPos = new Position(downLeftPos.Row + 1, downLeftPos.Col - 1);
            Position downRighPos = new Position(i_Piece.position.Row + 1, i_Piece.position.Col + 1);
            Position afterDownRightPos = new Position(downRighPos.Row + 1, downRighPos.Col + 1);

            //check if there is a valid move to the down left
            if (!checkIfPositionFree(downLeftPos) &&
                (getPeiceFromBoard(downLeftPos) != null) &&
                (getPeiceFromBoard(downLeftPos).Value.Symbol != i_Piece.Symbol) &&
                checkIfPositionFree(afterDownLeftPos))
            {
                eatMoves.Add(new Move(i_Piece.position, afterDownLeftPos));
            }
            else if(checkIfPositionFree(downLeftPos))
            {
                regularMoves.Add(new Move(i_Piece.position, downLeftPos));
            }

            //check if there is a valid move to the down right
            if (!checkIfPositionFree(downRighPos) &&
                (getPeiceFromBoard(downRighPos) != null) &&
                (getPeiceFromBoard(downRighPos).Value.Symbol != i_Piece.Symbol) &&
                checkIfPositionFree(afterDownRightPos))
            {
                eatMoves.Add(new Move(i_Piece.position, afterDownRightPos));
            }
            else if(checkIfPositionFree(downRighPos))
            {
                regularMoves.Add(new Move(i_Piece.position, downRighPos));
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


        public bool MovePiece(Position i_StartPos, Position i_DestinationPos)
        {
            /*this function checks if a pone can move inside the board
             * if it cant, false will return from the function and nothing will happen
             */
            bool isValidMove = true;

            isValidMove = checkMove(i_StartPos, i_DestinationPos);
            if (isValidMove) 
            {
                Piece? nullablePiece;
                isValidMove = extractPeiceFromBoard(i_StartPos, out nullablePiece);
                if (isValidMove)
                {
                    Piece piece = (Piece)nullablePiece;
                    piece.position = i_DestinationPos;
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

            List<Move> eatingMovents = getAllPonesEatMovements(i_PieceSymbol);

            if (!eatingMovents.Contains(move))//if there is no eating move check the regular one
            {
                isValid &= checkIfPositionInBoard(move.StartPos);
                isValid &= checkIfPositionInBoard(move.DestinationPos);
                if (isValid)
                {
                    isValid &= checkIfPositionFree(move.DestinationPos);
                    isValid &= !checkIfPositionFree(move.StartPos);
                    if (isValid)
                    {
                        isValid &= checkMoveDirection(i_StartPos, i_DestinationPos);
                    }
                }
            }

            return isValid;
        }

        private bool checkMoveDirection(Position i_StartPos, Position i_DestinationPos)
        {   
            ///this function checks if pone move is legal, 
            ///legal move should be in distance of 1 and in the move firection of the piece
            //need to add option if he move it so he can eat it
            bool isValid = true;

            Piece piece = (Piece)m_Board[i_StartPos.Row, i_StartPos.Col];

            if (piece.IsKing)
            {
                isValid &= checkCloseEnoughMovingToKing(i_StartPos, i_DestinationPos);
            }
            else
            {
                if(piece.Symbol == 'O')
                {
                    if(!(((i_StartPos.Row == i_DestinationPos.Row + 1) && (i_StartPos.Col == i_DestinationPos.Col + 1))||((i_StartPos.Row == i_DestinationPos.Row + 1) && (i_StartPos.Col == i_DestinationPos.Col - 1))))
                    {
                        isValid = false;
                    }
                }
                else
                {
                    if (!(((i_StartPos.Row == i_DestinationPos.Row - 1) && (i_StartPos.Col == i_DestinationPos.Col + 1)) ||((i_StartPos.Row == i_DestinationPos.Row + 1) && (i_StartPos.Col == i_DestinationPos.Col - 1))))
                    {
                        isValid = false;
                    }
                }

            }
            return isValid;
           
        }

        private bool checkCloseEnoughMovingToKing(Position i_StartPos, Position i_DestinationPos)
        { 
            bool isValid = true;
            int counterOfCheckTests = 0;

            if(!((i_StartPos.Row == i_DestinationPos.Row + 1) && (i_StartPos.Col == i_DestinationPos.Col + 1)))
            {
                counterOfCheckTests++;
            }
            else if(!((i_StartPos.Row == i_DestinationPos.Row + 1) && (i_StartPos.Col == i_DestinationPos.Col - 1)))
            {
                counterOfCheckTests++;
            }
            else if (!((i_StartPos.Row == i_DestinationPos.Row - 1) && (i_StartPos.Col == i_DestinationPos.Col + 1)))
            {
                counterOfCheckTests++;
            }
            else if (!((i_StartPos.Row == i_DestinationPos.Row - 1) && (i_StartPos.Col == i_DestinationPos.Col - 1)))
            {
                counterOfCheckTests++;
            }
            if (counterOfCheckTests == 4)
            {
                isValid = false;
            }

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

        private void initBoard(uint i_Size)
        {
            m_Board = new Piece?[i_Size, i_Size];

            for (uint i = 0; i < (i_Size / 2) - 1; i++)
            {
                for (uint j = 0; j < i_Size; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 != 0)
                        {
                            insertPiece(new Piece('O', new Position(i, j)));
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            insertPiece(new Piece('O', new Position(i, j)));
                        }
                    }
                }
            }
            for (uint i = i_Size-1; i > (i_Size / 2); i--)
            {
                for (uint j = 0; j < i_Size; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            insertPiece(new Piece('X', new Position(i, j)));
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            insertPiece(new Piece('X', new Position(i, j)));
                        }
                    }
                }
            }
        }
    }
}
