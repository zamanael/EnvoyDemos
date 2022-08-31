using Envoy.Api.ServerComponent;
using Envoy.Models;
using System.Collections.Generic;
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
        public IEnumerable<Company> GetCompanies()
        {
            return _companiesHelper.GetCompanies();
        }
    }
}
