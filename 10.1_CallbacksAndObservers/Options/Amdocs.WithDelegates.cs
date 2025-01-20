using System;
using System.Collections.Generic;
using System.Text;

namespace Callbacks.WithDelegates
{
    /// <summary>
    /// This company holds employies, which can callback the company to report sick, via delegate
    /// </summary>
    public class SomeCompany
    {
        public readonly List<Employee> m_Employees = new List<Employee>();

        public SomeCompany()
        {
            /// Creating 2 employies, passing each a reference to a delegate to this company's report sick method
            Employee employee = new Employee("2-7683454");
            employee.AttachObserver(new ReportSickDelegate(this.reportSick));
            m_Employees.Add(employee);

            employee = new Employee("2-5672378");
            employee.AttachObserver(new ReportSickDelegate(this.reportSick));
            m_Employees.Add(employee);
        }

        private void reportSick(string i_employeeID)
        {
            Console.WriteLine("worker {0} is sick :(", i_employeeID);
        }
    }
}
