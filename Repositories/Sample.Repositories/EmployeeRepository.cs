using Sample.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Sample.Repositories
{
    public interface IEmployeeRepository
    {
        void Delete(int employeeId);

        Employee Get(int employeeId);

        IEnumerable<Employee> GetAll();

        IEnumerable<Employee> GetAll(EEmployeeFilterableColumns filter, string filterValue);

        void Insert(Employee employee);

        void Save();

        void Update(Employee employee);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private bool _Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_Disposed)
            {
                if (disposing)
                {
                    BusinessDBContextSingleton.Instance().BusinessDBContext.Dispose();
                }
            }
            _Disposed = true;
        }

        public void Delete(int employeeId)
        {
            Employee employee = BusinessDBContextSingleton.Instance()
                .BusinessDBContext
                .Employees
                .Find(employeeId);
            BusinessDBContextSingleton.Instance()
                .BusinessDBContext
                .Employees
                .Remove(employee);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Employee Get(int employeeId)
        {
            return BusinessDBContextSingleton.Instance()
                .BusinessDBContext
                .Employees
                .FirstOrDefault(o => o.Id == employeeId);
        }

        public IEnumerable<Employee> GetAll()
        {
            return BusinessDBContextSingleton.Instance()
                .BusinessDBContext
                .Employees;
        }

        public IEnumerable<Employee> GetAll(EEmployeeFilterableColumns filter, string filterValue)
        {
            switch (filter)
            {
                case EEmployeeFilterableColumns.FirstName:
                    return BusinessDBContextSingleton.Instance()
                        .BusinessDBContext
                        .Employees
                        .Where(o => o.FirstName == filterValue);
                
                case EEmployeeFilterableColumns.Gender:
                    return BusinessDBContextSingleton.Instance()
                        .BusinessDBContext
                        .Employees
                        .Where(o => o.Gender.ToString() == filterValue);

                case EEmployeeFilterableColumns.LastName:
                    return BusinessDBContextSingleton.Instance()
                        .BusinessDBContext
                        .Employees
                        .Where(o => o.LastName == filterValue);

                default:
                    return null;
            }
        }

        public void Insert(Employee employee)
        {
            BusinessDBContextSingleton.Instance()
                .BusinessDBContext
                .Employees
                .Add(employee);
        }

        public void Save()
        {
            BusinessDBContextSingleton.Instance()
                .BusinessDBContext
                .SaveChanges();
        }

        public void Update(Employee employee)
        {
            BusinessDBContextSingleton.Instance()
                .BusinessDBContext
                .Entry(employee)
                .State = EntityState.Modified;
        }
    }
}
