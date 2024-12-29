using System;
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

        public bool MovePiece(Position i_StartPos, Position i_DestinationPos)
        {
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
                    isValidMove = insertIfCanPiece(piece);
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
        { //need to add option if he move it so he can eat it
            bool isValid = true;
            if (m_Board[i_StartPos.Row, i_StartPos.Col].Value.IsKing)
            {
                if(!checkCloseEnoughMovingToKing(i_StartPos, i_DestinationPos))
                {
                    isValid = false;
                }
            }
            else
            {
                if(m_Board[i_StartPos.Row, i_StartPos.Col].Value.Symbol == 'O')
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

        private bool insertIfCanPiece(Piece i_Piece)
        {
            bool canInsert = true;
            Position pos = i_Piece.position;

            canInsert = checkIfPositionInBoard(pos);
            if (canInsert)
            {
                m_Board[pos.Row, pos.Col] = i_Piece;
            }

            return canInsert;
        }

        private bool extractPeiceFromBoard(Position i_Pos, out Piece? o_Piece)
        {
            bool isPieceExist = false;

            o_Piece = m_Board[i_Pos.Row, i_Pos.Col];
            if (o_Piece != null)
            {
                
                m_Board[i_Pos.Row, i_Pos.Col] = null;
                isPieceExist = true;
            }

            return isPieceExist;
        }

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
                            insertIfCanPiece(new Piece('O', new Position(i, j)));
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            insertIfCanPiece(new Piece('O', new Position(i, j)));
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
                            insertIfCanPiece(new Piece('X', new Position(i, j)));
                        }
                    }
                    else
                    {
                        if (j % 2 != 0)
                        {
                            insertIfCanPiece(new Piece('X', new Position(i, j)));
                        }
                    }
                }
            }
        }
    }
}
