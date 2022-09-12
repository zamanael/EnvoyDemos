using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.Core;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.CoreApis
{
    public class CompaniesHelper : BaseHelper
    {
        private const string companiesUri = "companies";
        private readonly ILog _logger;

        public CompaniesHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<CompanyResponse> GetCompaniesAsync()
        {
            try
            {
                _logger.Debug($"{nameof(GetCompaniesAsync)}()");

                var responseString = await GetAsync(companiesUri);
                CompanyResponse companyResponse = JsonConvert.DeserializeObject<CompanyResponse>(responseString);

                _logger.Debug($"{nameof(GetCompaniesAsync)}() - " +
                  $"\nResponse: " +
                  $"\n{companyResponse.Serialize()}");

                return companyResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }
    }
}
