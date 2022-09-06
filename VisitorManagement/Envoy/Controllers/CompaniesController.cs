using Envoy.Api.ServerComponent.CoreApis;
using Envoy.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class CompaniesController : ApiController
    {
        private readonly CompaniesHelper _companiesHelper;

        public CompaniesController()
        {
            _companiesHelper = new CompaniesHelper();
        }


        [HttpGet]
        [Route("companies")]
        public async Task<CompanyResponse> GetCompaniesAsync()
        {
            return await _companiesHelper.GetCompaniesAsync();
        }
    }
}
