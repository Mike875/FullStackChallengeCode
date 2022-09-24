using Sample.Domains;
using Sample.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Sample.Services;

namespace Tests.Unit.Sample.Services
{
    [TestClass]
    public class EmployeeServiceTest
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
            
            foreach(Employee e in _TestEmployeeList)
            {
                eRep.Delete(e.Id);
            }

            eRep.Delete(_TestEmployeeId);

            eRep.Save();
        }

        [TestInitialize]
        public static void TestInitialize()
        {
            EmployeeRepository eRep = new EmployeeRepository();

            foreach(Employee e in _TestEmployeeList)
            {
                eRep.Insert(e);
            }

            eRep.Save();

            _TestEmployee = new Employee()
            {
                Age = 20,
                FirstName = "John",
                Gender = EGender.Male,
                Id = _TestEmployeeId,
                LastName = "Smith",
            };
        }

        [TestMethod]
        public static void TestGetAll()
        {
            List<Employee> employees = EmployeeService.GetAll().ToList();
            Assert.AreEqual(_TestEmployeeList, employees);
        }

        [TestMethod]
        public static void TestGetAllMales()
        {
            List<Employee> employees = EmployeeService
                .GetAll(EEmployeeFilterableColumns.Gender, "Male")
                .ToList();
            
            Assert.AreEqual(_TestEmployeeList.Where(o => o.Gender == EGender.Male), employees);
        }

        [TestMethod]
        public static void TestGetAllJohnFirstName()
        {
            List<Employee> employees = EmployeeService
                .GetAll(EEmployeeFilterableColumns.FirstName, "John")
                .ToList();

            Assert.AreEqual(_TestEmployeeList.Where(o => o.FirstName == "John"), employees);
        }

        [TestMethod]
        public static void TestGetAllJohnLastName()
        {
            List<Employee> employees = EmployeeService
                .GetAll(EEmployeeFilterableColumns.FirstName, "John")
                .ToList();

            Assert.AreEqual(_TestEmployeeList.Where(o => o.LastName == "John"), employees);
        }

        [TestMethod]
        public static void TestSaveNewEmployee()
        {
            EmployeeService.SaveEmployee(_TestEmployee);

            Assert.IsNotNull(EmployeeService.Get(_TestEmployeeId));
        }

        [TestMethod]
        public static void TestSaveExistingEmployee()
        {
            _TestEmployee.LastName = "Doe";

            EmployeeService.SaveEmployee(_TestEmployee);
            
            Assert.AreEqual("Doe", EmployeeService.Get(_TestEmployeeId).LastName);
        }
    }
}
