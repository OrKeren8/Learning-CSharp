using System;
using System.Collections.Generic;
using System.Text;

namespace Orchestra
{
    public abstract class Musician
    {
        #region Members and Props
        #region Members
        private string m_Name;
        private string m_Phone;
        private int m_SeatNumber;
        #endregion Members

        #region Props
        public int SeatNumber
        {
            get { return m_SeatNumber; }
            set { m_SeatNumber = value; }
        }

        public string Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        #endregion Props
        #endregion Members and Props

        #region Methods
        public abstract void Play();
        #endregion Methods
    }
}
