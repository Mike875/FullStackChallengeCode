using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Domains;
using Sample.Repositories;
using System.Collections.Generic;

namespace Tests.Unit.Sample.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private static readonly int _TestEmployeeId = 4;

        private static Employee _TestEmployee;

        private static readonly List<Employee> _TestEmployeeList = new List<Employee>()
        {
            new Employee()
            {
                Age = 21,
                FirstName = "Jane",
                Gender = EGender.Female,
                Id = 1,
                LastName = "Doe",
            },
            new Employee()
            {
                Age = 22,
                FirstName = "Elton",
                Gender = EGender.Male,
                Id = 2,
                LastName = "John",
            },
            new Employee()
            {
                Age = 23,
                FirstName = "Jane Jr",
                Gender = EGender.Female,
                Id = 3,
                LastName = "Doe",
            }
        };

        [TestCleanup]
        public static void TestCleanup()
        {
            EmployeeRepository eRep = new EmployeeRepository();

            eRep.Delete(_TestEmployeeId);
        }

        [TestInitialize]
        public static void TestInitialize()
        {
            EmployeeRepository eRep = new EmployeeRepository();

            foreach (Employee e in _TestEmployeeList)
            {
                eRep.Insert(e);
            }

            _TestEmployee = new Employee()
            {
                Age = 20,
                FirstName = "John",
                Gender = EGender.Male,
                Id = _TestEmployeeId,
                LastName = "Smith",
            };

            eRep.Insert(_TestEmployee);
            eRep.Save();
        }

        [TestMethod]
        public static void TestDelete()
        {
            EmployeeRepository eRep = new EmployeeRepository();
            eRep.Delete(_TestEmployeeId);

            Assert.IsNull(eRep.Get(_TestEmployeeId));
        }
    }
}
