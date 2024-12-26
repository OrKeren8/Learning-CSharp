
using System;

namespace BackEnd
{
    public struct Player
    {
        private string m_Name;
        private readonly bool m_IsPc;

        public string Name
        {
            get { return m_Name; }
        }

        //constructor
        public Player(string i_Name, bool i_IsPc)
        {
            m_Name = i_Name;
            m_IsPc = i_IsPc;
        }

        public void Play()
        {

        }
    }
}
