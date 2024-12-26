
using System;

namespace Player
{
    public class Player
    {
        private string m_Name;
        private int m_ID;

        public string Name
        {
            get { return m_Name; }
            private set { m_Name = value; }
        }

        public int ID
        {
            get { return m_ID; }
            private set { m_ID = value; }
        }

        //constructor
        public Player(string i_Name, int i_ID)
        {
            Name = i_Name;
            ID = i_ID;
        }

        public void Play()
        {

        }
    }
}
