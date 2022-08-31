using System.Collections.Generic;
using System.Web.Http;
using VisitorManagement.Envoy.Models;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class SpacesController : ApiController
    {
        [HttpGet]
        [Route("spaces")]
        public IEnumerable<Space> GetSpaces()
        {
            //var client = new RestClient("https://api.envoy.com/v1/spaces?type=DESK&page=1&perPage=250");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpGet]
        [Route("spaces/{id}")]
        public IEnumerable<Space> GetSpaceById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/spaces/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
