using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System.Threading.Tasks;
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
        public async Task<EmployeesResponse> GetEmployeesAsync()
        {
            return await _employeesHelper.GetEmployeesAsync();
        }

        [HttpGet]
        [Route("employees/{id}")]
        public async Task<EmployeeResponse> GetEmployeeByIdAsync(int id)
        {
            return await _employeesHelper.GetEmployeeByIdAsync(id);
        }
    }
}
