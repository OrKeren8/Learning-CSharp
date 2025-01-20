using System;
using System.Collections.Generic;
using System.Text;

namespace Callbacks
{
    public class Amdocs
    {
        public readonly List<Employee> m_Employees = new List<Employee>();

        public Amdocs()
        {
            /// Creating 2 employies, passing each a reference to this company, as IReportSickListener
            Employee employee = new Employee("1-2345450");
            m_Employees.Add(employee);

            employee = new Employee("1-3454560");
            m_Employees.Add(employee);
        }

        public void ReportSick(string i_EmployeeID)
        {
            Console.WriteLine("worker {0} is sick :(", i_EmployeeID);
        }
    }
}
