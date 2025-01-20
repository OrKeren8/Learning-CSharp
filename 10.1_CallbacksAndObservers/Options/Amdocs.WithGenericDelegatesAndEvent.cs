using System;
using System.Collections.Generic;
using System.Text;

namespace Callbacks.WithGenericDelegatesAndEvent
{
    /// <summary>
    /// This company holds employies, which can callback the company to report sick,
    /// via a pre-defined delegate, accessed with 'public event' keyword
    /// </summary>
    public class SomeCompany
    {
        public readonly List<Employee> m_Employees = new List<Employee>();

        public SomeCompany()
        {
            Employee employee = new Employee("3-4565776");
            employee.m_ReportSickDelegates += new Action<string>(this.reportSick);
            m_Employees.Add(employee);

            employee = new Employee("3-2345685");
            /// you can also avoid the explicit creation of the delegate object:
            employee.m_ReportSickDelegates += this.reportSick;
            m_Employees.Add(employee);

            employee = new Employee("3-1231245");
            /// you can also attach an anonymous "inline" method to the delegate:
            employee.m_ReportSickDelegates += 
                (string i_WorkerID) => Console.WriteLine("worker {0} is sick :(", i_WorkerID);

            m_Employees.Add(employee);
        }

        private void reportSick(string i_EmployeeID)
        {
            Console.WriteLine("worker {0} is sick :(", i_EmployeeID);
        }
    }
}
