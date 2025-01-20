using System;
using System.Collections.Generic;
using System.Text;

namespace Callbacks
{
    public class Program
    {
        public static void Main()
        {
            WithIinterfaces.Amdocs someCompany1 = new WithIinterfaces.Amdocs();
            someCompany1.m_Employees[1].Fever = 38;

            WithDelegates.SomeCompany someCompany2 = new WithDelegates.SomeCompany();
            someCompany2.m_Employees[1].Fever = 38;

            WithGenericDelegatesAndEvent.SomeCompany someCompany3 = new WithGenericDelegatesAndEvent.SomeCompany();
            someCompany3.m_Employees[1].Fever = 38;

            Console.WriteLine("Press enter to continue..");
            Console.ReadLine();
        }
    }
}

