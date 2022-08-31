using Envoy.Api.ServerComponent;
using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class EmployeesController : ApiController
    {
        private readonly EmployeesHelper _employeesHelper;

        public EmployeesController()
        {
            _employeesHelper = new EmployeesHelper();
        }

        [HttpGet]
        [Route("employees")]
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeesHelper.GetEmployees();
        }

        [HttpGet]
        [Route("employees/{id}")]
        public IEnumerable<Employee> GetEmployeeById(int id)
        {
            return _employeesHelper.GetEmployeeById(id);
        }
    }
}
