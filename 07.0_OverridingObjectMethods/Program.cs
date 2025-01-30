using System;
using System.Collections.Generic;
using System.Text;

namespace OverridingObjectMethods
{
    public class Program
    {
        public static void Main()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Stud1", 22, 34434444, 120));
            students.Add(new Student("Stud2", 24, 34534545, 122));
            students.Add(new Student("Stud3", 25, 67867875, 121));

            // "IndexOf" uses the overriden "Equals" method for comparing objects in the list
            int idxOf34434444 = students.IndexOf(new Student(34434444));
            if (idxOf34434444 != -1)
            {
                Console.WriteLine(students[idxOf34434444]);
            }

            Student clonedStud = students[0].Clone();

            Type typeOfStud = clonedStud.GetType();

        }
    }
}
