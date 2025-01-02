using System;

namespace BackEnd
{
    public enum ePlayerType
    {
        White,
        Black
    }

    public struct Player
    {
        private string m_Name;
        public readonly bool IsPc; //in order to match property naming style
        private readonly ePlayerType m_PlayerType;

        public string Name
        {
            get { return m_Name; }
        }

        //constructor
        public Player(string i_Name, bool i_IsPc, ePlayerType i_PlayerType)
        {
            m_Name = i_Name;
            IsPc = i_IsPc;
            m_PlayerType = i_PlayerType;
        }

        public ePlayerType PlayerType
        {
            get { return m_PlayerType; }
        }
    }
}
