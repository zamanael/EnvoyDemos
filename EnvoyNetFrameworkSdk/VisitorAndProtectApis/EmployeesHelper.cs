using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.VisitorAndProtectApis
{
    public class EmployeesHelper : BaseHelper
    {
        private const string employeesUri = "employees";
        private readonly ILog _logger;

        public EmployeesHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<EmployeesResponse> GetEmployeesAsync(int page = 1, int perPage = 10, string sort="NAME", string order = "ASC")
        {
            try
            {
                var responseString = await GetAsync($"{employeesUri}?page={page}&perPage={perPage}&sort={sort}&order={order}");
                return JsonConvert.DeserializeObject<EmployeesResponse>(responseString);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<EmployeeResponse> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{employeesUri}/{id}");
                return JsonConvert.DeserializeObject<EmployeeResponse>(responseString);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }
    }
}
