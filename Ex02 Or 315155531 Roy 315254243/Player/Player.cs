using System;

namespace BackEnd
{
    public struct Player
    {
        private string m_Name;
        public readonly bool IsPc; //in order to match property naming style
        private readonly ePieceSymbol m_PieceSymbol;

        public string Name
        {
            get { return m_Name; }
        }

        //constructor
        public Player(string i_Name, bool i_IsPc, ePieceSymbol i_PieceSymbol)
        {
            m_Name = i_Name;
            IsPc = i_IsPc;
            m_PieceSymbol = i_PieceSymbol;
        }

        public ePieceSymbol PieceSymbol
        {
            get { return m_PieceSymbol; }
        }
    }
}
