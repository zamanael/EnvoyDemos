using Envoy.Api.ServerComponent;
using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class FlowsController : ApiController
    {
        private readonly FlowsHelper _flowsHelper;

        public FlowsController()
        {
            _flowsHelper = new FlowsHelper();
        }

        [HttpGet]
        [Route("flows")]
        public IEnumerable<Flow> GetLocations()
        {
            //var client = new RestClient("https://api.envoy.com/v1/flows");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpGet]
        [Route("flows/{id}")]
        public IEnumerable<Flow> GetLocationById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/rest/v1/locations/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
