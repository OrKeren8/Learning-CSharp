using System;
using System.Collections.Generic;
using System.Text;

namespace Reference_And_Value_Types
{
    class StudentClass // This is a Reference Type.
    {
        public int m_Age = 0;
        public int m_ID = 0;
        public int m_NumOfCourses = 0;

        public StudentClass(int i_Age, int i_ID, int i_NumOfCourses)
        {
            m_Age = i_Age;
            m_ID = i_ID;
            m_NumOfCourses = i_NumOfCourses;
        }
    }

    struct StudentStruct // This is a Value Type.
    {
        public int m_Age;
        public int m_ID;
        public int m_NumOfCourses;

        public StudentStruct(int i_Age, int i_ID, int i_NumOfCourses)
        {
            m_Age = i_Age;
            m_ID = i_ID;
            m_NumOfCourses = i_NumOfCourses;
        }
    }
}
