/** Guy Ronen (C) 2005 **/
using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Program
    {
        public static void Main()
        {
            ModifiersExample staticExample = new ModifiersExample();
            // static and const members are accessed through the class and not through the instance:
            ModifiersExample.s_StaticMember = 1;
            ModifiersExample.SomeStaticMethod();
            int someNumber = ModifiersExample.k_ConstMember;



            Student student = new Student();
            //using the Age property:
            student.Age = 23;
            int age = student.Age;

            //using the int indexer for grades:
            student[2] = 93;
            float grade = student[2];
            Console.WriteLine("the 3rd grade is " + grade);

            //using the string indexer for grades:
            grade = student[".NET"];
            Console.WriteLine("the grade in .NET is " + grade);

            try
            {
                student.Age = 15;
            }
            catch (TooYoungException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }    
}
