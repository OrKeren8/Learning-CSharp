using System;
using System.Dynamic;
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

        private void insertPiece(Piece? i_Piece)
        {
            Position pos = i_Piece.Value.getPosition();
            if (pos.Row < 0 || pos.Row >= Size || pos.Col < 0 || pos.Col >= Size)
            {
                throw new ArgumentOutOfRangeException("The row or column index is out of bounds.");
            }

            m_Board[pos.Row, pos.Col] = i_Piece;
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
