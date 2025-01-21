using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    class Student
    {
        public static void Main()
        {
            Student s = new Student(2222);
            Student s1 = new Student(4444);
            Console.WriteLine(s);

            List<Student> students = new List<Student>();
            students.Add(s);
            students.Add(s1);

            if (s.GetType == typeof(Student))
            {
                Console.WriteLine("s.GetType == typeof(Student)");
            }

            

            //foreach (Student student in students)
            //{
            //    if (student.ID == 4444)
            //    {
            //        Console.WriteLine("Found student with ID 4444");
            //        break;
            //    }
            //}

            if(students.IndexOf(new Student(4444)))
            {
                Console.WriteLine("Found student with ID 4444");
            }

        }

        public Student(int i_ID)
        {
            m_ID = i_ID;    
        }

        List<Courses> m_Courses;

        private string m_FirstName = "Guy";

        public string FirstName
        {
            get { return m_FirstName; }
            set { m_FirstName = value; }
        }

        private string m_LastName = "Ronen";

        public string LastName
        {
            get { return m_LastName; }
            set { m_LastName = value; }
        }

        private int m_ID;

        public int ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        private int m_Age;

        public int Age
        {
            get { return m_Age; }
            set { m_Age = value; }
        }

        public override string ToString()
        {
            string toString = string.Format("First Name: {0}\nLast Name: {1}", m_FirstName, m_LastName);
            return toString;
        }

        public override bool Equals(object obj)
        {
            bool retVal = false;

            Student compareTo = obj as Student;
            if (compareTo != null)
            {
                retVal = m_ID.Equals(compareTo.ID);
            }

            return retVal;
        }

        public override int GetHashCode()
        {
            return m_ID.GetHashCode();
        }

        public Student Clone()
        {
            Student retVal = null;

            retVal = this.MemberwiseClone();

            retVal.m_Courses = m_Courses.Clone();

            return retVal;
        }

    }
}
