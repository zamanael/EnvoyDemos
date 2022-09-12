using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class EmployeesController : ApiController
    {
        private readonly EmployeesHelper _employeesHelper;
        private readonly ILog _logger;

        public EmployeesController()
        {
            _employeesHelper = new EmployeesHelper();
            _logger = Logger.GetLogger<EmployeesController>();
        }

        [HttpGet]
        [Route("employees")]
        public async Task<EmployeesResponse> GetEmployeesAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetEmployeesAsync)}()");

                EmployeesResponse employeesResponse = await _employeesHelper.GetEmployeesAsync();

                _logger.Debug($"{nameof(GetEmployeesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{employeesResponse.Serialize()}");

                return employeesResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("employees/{id}")]
        public async Task<EmployeeResponse> GetEmployeeByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetEmployeeByIdAsync)}({nameof(id)}: {id})");

                EmployeeResponse employeeResponse = await _employeesHelper.GetEmployeeByIdAsync(id);

                _logger.Debug($"{nameof(GetEmployeeByIdAsync)}() - " +
                  $"\nResponse: " +
                  $"\n{employeeResponse.Serialize()}");

                return employeeResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
