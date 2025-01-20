using System;
using System.Collections.Generic;
using System.Text;

namespace Callbacks
{

    public class Employee
    {
        private const float k_FeverThreshold = 37;
        private string m_ID;
        private float m_Fever = 36.7f;
        bool m_Sick = false;

        public Employee(string i_ID)
        {
            this.m_ID = i_ID;
        }

        public float Fever
        {
            get { return m_Fever; }
            set
            {
                if (m_Fever != value)
                {
                    m_Fever = value;
                    doWhenFeverChanged();
                }
            }
        }

        private void doWhenFeverChanged()
        {
            if (!m_Sick && m_Fever > k_FeverThreshold)
            {
                doWhenSick();
            }
            else if (m_Fever <= k_FeverThreshold)
            {
                m_Sick = false;
            }
        }

        private void doWhenSick()
        {
            m_Sick = true;

            /// 1. Take acamol
            /// 2. Drink tea
            /// 3. Go to bed
            /// 4. report sick to who ever cares:
        }
    }
}
