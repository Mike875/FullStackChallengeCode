using Sample.Domains;
using Sample.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> GetAll()
        {
            return EmployeeService.GetAll();
        }

        public IEnumerable<Employee> GetAll(EEmployeeFilterableColumns filter, string filterValues)
        {
            return EmployeeService.GetAll(filter, filterValues);
        }

        public IHttpActionResult Save(Employee employee)
        {
            try
            {
                EmployeeService.SaveEmployee(employee);
                return Ok();
            }
            catch
            {
                return BadRequest("Unable to save employee. Contact administrator");
            }
        }
    }
}