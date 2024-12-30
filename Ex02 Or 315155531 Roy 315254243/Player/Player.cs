
using System;

namespace BackEnd
{
    public struct Player
    {
        private string m_Name;
        private readonly bool m_IsPc;
        private readonly ePieceSymbol m_PieceSymbol;

        public string Name
        {
            get { return m_Name; }
        }

        //constructor
        public Player(string i_Name, bool i_IsPc, ePieceSymbol i_PieceSymbol)
        {
            m_Name = i_Name;
            m_IsPc = i_IsPc;
            m_PieceSymbol = i_PieceSymbol;
        }

        public void Play()
        {

        }
    }
}
