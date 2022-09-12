using CardAccess.Logging;
using EnvoyNetFrameworkSdk.CoreApis;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.Core;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class CompaniesController : ApiController
    {
        private readonly CompaniesHelper _companiesHelper;
        private readonly ILog _logger;

        public CompaniesController()
        {
            _companiesHelper = new CompaniesHelper();
            _logger = Logger.GetLogger<CompaniesController>();
        }


        [HttpGet]
        [Route("companies")]
        public async Task<CompanyResponse> GetCompaniesAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetCompaniesAsync)}()");

                CompanyResponse companyResponse = await _companiesHelper.GetCompaniesAsync();

                _logger.Debug($"{nameof(GetCompaniesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{companyResponse.Serialize()}");

                return companyResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
