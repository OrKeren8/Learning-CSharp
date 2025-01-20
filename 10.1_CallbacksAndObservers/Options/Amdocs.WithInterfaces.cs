using System;
using System.Collections.Generic;
using System.Text;

namespace Callbacks.WithIinterfaces
{
    /// <summary>
    /// This company holds employies, which can callback the company to report sick,
    /// by referencing it back as IReportSickListener
    /// </summary>
    public class Amdocs : ISicknessObserver
    {
        public readonly List<Employee> m_Employees = new List<Employee>();

        public Amdocs()
        {
            /// Creating 2 employies, passing each a reference to this company, as IReportSickListener
            Employee employee = new Employee("1-2345450");
            employee.AttachObserver(this as ISicknessObserver);
            m_Employees.Add(employee);

            employee = new Employee("1-3454560");
            employee.AttachObserver(this as ISicknessObserver);
            m_Employees.Add(employee);
        }

        public void ReportSick(string i_EmployeeID)
        {
            Console.WriteLine("worker {0} is sick :(", i_EmployeeID);
        }
    }
}
