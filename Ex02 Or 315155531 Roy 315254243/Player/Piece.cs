using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace BackEnd
{
    public enum ePieceDirection
    {
        Down,
        Up,
        KingAnywhere
    }

    public enum ePieceSymbol
    {
        O,
        X,
        //U,
        //K
        //just if king need to check
    }

    public struct Piece
    {
        
        private Position m_Position;
        private bool m_IsKing;
        private ePieceSymbol m_Symbol;
        private ePieceDirection m_PoneDirection;

        public Piece(ePieceSymbol i_Symbol, Position i_Position)
        {
            m_Symbol = i_Symbol;
            m_Position = i_Position;
            m_IsKing = false;
            if(m_Symbol == ePieceSymbol.O)
            {
                m_PoneDirection = ePieceDirection.Down;
            }
            else
            {
                m_PoneDirection= ePieceDirection.Up;
            }
        }

        public ePieceDirection Direction
        {
            get { return m_PoneDirection; }
        }

        public Position position
        {
            get {return m_Position;}
            set { m_Position = value;}
        }
        public bool IsKing
        {
            get { return m_IsKing; }
            
        }

        public ePieceSymbol Symbol
        {
            get { return m_Symbol; }
        }

        public void PromoteToKing()
        {
            m_IsKing = true;
            m_PoneDirection = ePieceDirection.KingAnywhere;
        }
    }
}
