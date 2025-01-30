using System;
using System.Collections.Generic;
using System.Text;

namespace Reference_And_Value_Types
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Value Types:");
            Console.WriteLine("============");
            ValueTypes();

            Console.WriteLine("");

            Console.WriteLine("Reference Types:");
            Console.WriteLine("================");
            RefernenceTypes();
        }

        private static void ValueTypes()
        {
            StudentStruct sStudent1 = new StudentStruct(25, 3787785, 121);
            StudentStruct sStudent2 = new StudentStruct(25, 3787785, 121);

            // if (sStudent1 == sStudent2) // this line does not compile. no '==' operator is defined
            if (sStudent1.Equals(sStudent2))
            {
                Console.WriteLine("sStudent1.Equals(sStudent2)  (because we are comparing content)");
            }

            StudentStruct sStudent3 = sStudent2;
            sStudent3.m_Age = 27;

            if ((!sStudent3.Equals(sStudent2)) && (sStudent2.m_Age != 27))
            {
                Console.WriteLine("sStudent2.m_Age != 27 \n because sStudent3 is a different memory block then sStudent2");
                Console.WriteLine("!sStudent3.Equals(sStudent2)  (because we are comparing content)");
            }

            celebrateBrithday(sStudent3);

            if (sStudent3.m_Age != 28)
            {
                Console.WriteLine("cStudent2.m_Age != 28 (because we passed copy of the object to the method)");
            }
        }

        private static void celebrateBrithday(StudentStruct i_sStudent)
        {
            i_sStudent.m_Age++;
        }

        private static void RefernenceTypes()
        {
            //Reference Types:
            StudentClass cStudent1 = new StudentClass(25, 3787785, 121);
            StudentClass cStudent2 = new StudentClass(25, 3787785, 121);

            if (!cStudent1.Equals(cStudent2)
                && cStudent1 != cStudent2)
            {
                Console.WriteLine("cStudent1 != cStudent2  (because we are comparing addresses/references and not content)");
            }

            StudentClass cStudent3 = cStudent2;
            cStudent3.m_Age = 27;

            if ((cStudent2 == cStudent3) && (cStudent2.m_Age == 27))
            {
                Console.WriteLine("cStudent2 == cStudent3 (because we are comparing addresses)");
                Console.WriteLine("cStudent2.m_Age == 27 (because cStudent3 references the same memory as student2)");
            }

            celebrateBrithday(cStudent3);

            if ((cStudent2 == cStudent3) && (cStudent2.m_Age == 28))
            {
                Console.WriteLine("cStudent2 == cStudent3 (because we are comparing addresses)");
                Console.WriteLine("cStudent2.m_Age == 28 (because we passed a reference to the method)");
            }
        }

        private static void celebrateBrithday(StudentClass i_cStudent)
        {
            i_cStudent.m_Age++;
        }
    }
}
