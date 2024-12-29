using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace BackEnd
{
    public struct Piece
    {
        
        private Position m_Position;
        private bool m_IsKing;
        private char m_Symbol;

        public Piece(char i_Symbol, Position i_Position)
        {
            m_Symbol = i_Symbol;
            m_Position = i_Position;
            m_IsKing = false;
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

        public char Symbol
        {
            get { return m_Symbol; }
        }

        public void PromoteToKing()
        {

        }
    }
}
