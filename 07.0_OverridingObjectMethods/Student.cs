using System;
using System.Collections.Generic;
using System.Text;

namespace OverridingObjectMethods
{
    // This is an example for a class that overrides all overridable methods of class System.Object
    public class Student
    {
        public int m_Age = 0;
        public int m_ID = 0;
        public int m_NumOfCourses = 0;
        public string m_Name = string.Empty;

        public Student(int i_ID)
        {
            m_ID = i_ID;
        }

        public Student(string i_Name, int i_Age, int i_ID, int i_NumOfCourses)
        {
            m_Name = i_Name;
            m_Age = i_Age;
            m_ID = i_ID;
            m_NumOfCourses = i_NumOfCourses;
        }

        // Overriding Object.ToString
        public override string ToString()
        {
            return string.Format("Name: {0}\n"+
                "Age: {1}, ID: {2}, Num Of Courses: {3}",
                m_Name, m_Age, m_ID, m_NumOfCourses);
        }

        // Overriding Object.Equals using this.GetHasCode as the logic for comaprison
        public override bool Equals(object obj)
        {
            bool equals = false;
            Student toCompareTo = obj as Student; // does type checking and down casting
            if (toCompareTo != null)
            {
                eqauls = this.GetHashCode() == toCompareTo.GetHashCode();
            }

            return equals;
        }

        // Overriding Object.GetHasCode using m_ID as the logic
        public override int GetHashCode()
        {
            return m_ID.GetHashCode();
        }


        // Using of Object.MemberwiseClone for cloning the object
        public Student Clone()
        {
            return this.MemberwiseClone() as Student;
        }
    }
}
