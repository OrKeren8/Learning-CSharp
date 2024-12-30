using System;
using System.Collections.Generic;
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

        private List<Move> getPonesEatMovements(char i_Symbol)
        {
            ///this function will check all the moves a specific pone can do
            ///and return them as a list
            List<Piece> piecesList = getAllPieces(i_Symbol); 
            List<Move> avaliableEatingMoves = new List<Move>();

            foreach (Piece piece in piecesList) 
            {
                avaliableEatingMoves.Add(getSinglePoneEatMovements(piece));
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
                    moves.Add(getUpperEatingMoves(i_Piece));
                    moves.Add(getDownEatingMoves(i_Piece));
                    break;
                case ePieceDirection.Up:
                    moves.Add(getUpperEatingMoves(i_Piece));
                    break;
                case ePieceDirection.Down:
                    moves.Add(getDownEatingMoves(i_Piece));
                    break;
            }

            return moves;
        }

        private List<Move> i_PigetUpperEatingMoves(Piece i_Piece)
        {
            ///this function get all the eating moves a piece can do to all the pieces above it
            List<Move> moves = new List<Move>();
            Position upperLeftPos = new Position(i_Piece.position.Row - 1, i_Piece.position.Col - 1); //we will have bug here because the inoputs are uint and we can have -1 here
            Position afterUpperLeftPos = new Position(upperLeftPos.Row - 1, upperLeftPos.Col - 1);
            Position upperRighPos = new Position(i_Piece.position.Row - 1, i_Piece.position.Col + 1);
            Position afterUpperRightPos = new Position(upperRighPos.Row - 1, upperRighPos.Col - 1);


            if (checkIfPositionInBoard(upperLeftPos) &&
                !checkIfPositionFree(upperLeftPos) &&
                checkIfPositionFree(afterUpperLeftPos))
            {

            }
        }

        private List<Piece> getAllPieces(char i_Symbol)
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

        private bool checkMove(Position i_StartPos, Position i_DestinationPos)
        {
            bool isValid = true;

            isValid &= checkIfPositionInBoard(i_StartPos);
            isValid &= checkIfPositionInBoard(i_DestinationPos);
            if (isValid)
            {
                isValid &= checkIfPositionFree(i_DestinationPos);
                isValid &= !checkIfPositionFree(i_StartPos);
                if (isValid)
                {
                    isValid &= checkMoveDirection(i_StartPos, i_DestinationPos);
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
            bool isFree;

            if (!checkIfPositionInBoard(i_Pos))
            {
                throw new Exception("Postion is not exist");
            }
            isFree = (m_Board[i_Pos.Row, i_Pos.Col] == null);

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
