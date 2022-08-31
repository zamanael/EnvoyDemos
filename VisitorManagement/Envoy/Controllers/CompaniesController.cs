using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class CompaniesController : ApiController
    {
        [HttpGet]
        [Route("companies")]
        public IEnumerable<Company> GetCompanies()
        {
            //var client = new RestClient("https://api.envoy.com/rest/v1/companies");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
