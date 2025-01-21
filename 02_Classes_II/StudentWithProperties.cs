using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Student
    {
        private int m_Age = 0;
        private int m_ID = 0;
        private int m_NumOfCourses = 0;
        private readonly List<Grade> r_Grades = new List<Grade>();

        public Student()
        {
            r_Grades.Add(new Grade("Infi1", 85));
            r_Grades.Add(new Grade("Data Structures", 79));
            r_Grades.Add(new Grade("Java", 80));
            r_Grades.Add(new Grade(".NET", 89));
        }

        // The old fashion way for "get":
        public int GetAge()
        {
            return m_Age;
        }

        // The old fashion way for "set":
        public void SetAge(int i_Age)
        {
            if (i_Age > 20)
            {
                m_Age = i_Age;
            }
            else
            {
                throw new TooYoungException(i_Age);
            }
        }

        public int Age
        {
            get { return m_Age; }
            set
            {
                if (value > 20)
                {
                    m_Age = value;
                }
                else
                {
                    throw new TooYoungException(value);
                }
            }
        }

        // an int indexer:
        public float this[int i_Idx]
        {
            get { return r_Grades[i_Idx].Value; }
            set { r_Grades[i_Idx].Value = value; }
        }

        // a read-only string indexer:
        public float this[string i_CourseName]
        {
            get
            {
                float retVal = -1;

                foreach (Grade grade in r_Grades)
                {
                    if (grade.CourseName == i_CourseName)
                    {
                        retVal = grade.Value;
                        break;
                    }
                }

                if (retVal == -1)
                {
                    throw new Exception("No course named " + i_CourseName);
                }

                return retVal;
            }
        }
    }

    public class Grade
    {
        private float m_Value;
        private string m_CourseName;

        public float Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }

        // A read-only property:
        public string CourseName
        {
            get { return m_CourseName; }
        }

        public Grade(string i_CourseName, float i_Grade)
        {
            m_Value = i_Grade;
            m_CourseName = i_CourseName;
        }
    }

    public class TooYoungException : Exception
    {
        public TooYoungException(int i_Age)
            : base("The age " + i_Age + " is too young!")
        { }
    }
}
