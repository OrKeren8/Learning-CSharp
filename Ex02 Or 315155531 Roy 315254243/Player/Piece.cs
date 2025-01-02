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
        U,
        K
        //just if king need to check
    }

    public struct Piece
    {
        
        private Position m_Position;
        private bool m_IsKing;
        private ePieceSymbol m_Symbol;
        private ePieceDirection m_PoneDirection;
        private ePlayerType m_Player;

        public Piece(ePieceSymbol i_Symbol, Position i_Position, ePlayerType i_Player)
        {
            m_Symbol = i_Symbol;
            m_Position = i_Position;
            m_IsKing = false;
            m_Player = i_Player;

            switch (m_Symbol)
            {
                case ePieceSymbol.O:
                    m_PoneDirection = ePieceDirection.Down;
                    break;
                case ePieceSymbol.X:
                    m_PoneDirection = ePieceDirection.Up;
                    break;
                default:
                    m_PoneDirection = ePieceDirection.KingAnywhere;
                    break;
            }
        }

        public ePieceDirection Direction
        {
            get { return m_PoneDirection; }
        }

        public ePlayerType Player
        {
            get { return m_Player; }
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
            //m_PoneDirection = ePieceDirection.KingAnywhere;
            if(m_Symbol == ePieceSymbol.O)
            {
                m_Symbol = ePieceSymbol.U;
            }
            else if(m_Symbol == ePieceSymbol.X)
            {
                m_Symbol = ePieceSymbol.K;
            }
            m_PoneDirection = ePieceDirection.KingAnywhere;
        }
    }
}
