using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Singleton
{

    class Program
    {
    }

    class Courses
    {
        private readonly List<Course> m_Courses = new List<Course>();

        public Course GetCourse(int i_Idx)
        {
            return m_Courses[i_Idx];
        }

        public Course GetCourse(int i_ID)
        {
            Course retVal = null;

            foreach (Course course in m_Courses)
            {
                if (course.ID == i_ID)
                {
                    retVal = course;
                    break;
                }
            }

            return retVal;
        }

        public Course GetCourse(string i_Name)
        {
            Course retVal = null;

            foreach (Course course in m_Courses)
            {
                if (course.ID == i_Name)
                {
                    retVal = course;
                    break;
                }
            }

            return retVal;
        }

    }

    class Course
    {
        protected string m_Name;

		public string Name
		{
			get { return m_Name;}
			set
			{
				if(m_Name != value)
				{
					m_Name = value;
				}
			}
		}

        protected int m_ID;

		public int ID
		{
			get { return m_ID;}
			set
			{
				if(m_ID != value)
				{
					m_ID = value;
				}
			}
		}

    }







    /// <summary>
    /// This class demonstrates the use of the <see cref="Settings"/> singleton class
    /// </summary>
    public class Program1
    {
        static void Main(string[] args)
        {
            Settings.Instance.Load(); // using the single instance

            string lastLoginUserName = Settings.Instance["LastLoginUserName"] as string;

            if (lastLoginUserName != null)
            {
                Console.WriteLine("Welcome {0}!", lastLoginUserName);
            }

            // new to C# 2.0
            // note the "?" attached to the DateTime type and see next comment.
            DateTime? lastLoginDate = Settings.Instance.LastLoginDate;

            // You can ask "!= null" on a "DateTime?"
            // You can not as "!= null" on a DateTime.
            if (lastLoginDate != null)
            {
                Console.WriteLine("You last logged in on: " + lastLoginDate);
            }

            Settings.Instance.Save();
        }
    }
}
