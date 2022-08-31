using System.Collections.Generic;
using System.Web.Http;
using VisitorManagement.Envoy.Models;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class EmployeesController : ApiController
    {
        [HttpGet]
        [Route("employees")]
        public IEnumerable<Employee> GetEmployees()
        {
            //var client = new RestClient("https://api.envoy.com/v1/employees?page=1&perPage=10&sort=NAME&order=ASC");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpGet]
        [Route("employees/{id}")]
        public IEnumerable<Employee> GetEmployeeById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/employees/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
