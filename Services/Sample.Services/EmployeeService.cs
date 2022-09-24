using Sample.Domains;
using Sample.Repositories;
using System.Collections.Generic;

namespace Sample.Services
{
    public class EmployeeService
    {
        private static void SanitizeEmployee(Employee employee)
        {
            employee.FirstName = employee.FirstName.SanitizeSql();
            employee.LastName = employee.LastName.SanitizeSql();
        }

        public static Employee Get(int employeeId)
        {
            return new EmployeeRepository().Get(employeeId);
        }

        public static IEnumerable<Employee> GetAll()
        {
            return new EmployeeRepository().GetAll();
        }

        public static IEnumerable<Employee> GetAll(EEmployeeFilterableColumns filter, string filterValue)
        {
            return new EmployeeRepository().GetAll(filter, filterValue);
        }

        public static void SaveEmployee(Employee employee)
        {
            EmployeeRepository eRep = new EmployeeRepository();

            SanitizeEmployee(employee);

            if (eRep.Get(employee.Id) == null)
            {
                eRep.Insert(employee);
            }
            else
            {
                eRep.Update(employee);
            }

            eRep.Save();
        }
    }
}
