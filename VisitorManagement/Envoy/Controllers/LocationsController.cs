using System.Collections.Generic;
using System.Web.Http;
using VisitorManagement.Envoy.Models;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class LocationsController : ApiController
    {
        [HttpGet]
        [Route("locations")]
        public IEnumerable<Location> GetLocations()
        {
            //var client = new RestClient("https://api.envoy.com/rest/v1/locations");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpGet]
        [Route("locations/{id}")]
        public IEnumerable<Location> GetLocationById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/rest/v1/locations/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
