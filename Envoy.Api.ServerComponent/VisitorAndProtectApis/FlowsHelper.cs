using Envoy.Models;
using System.Collections.Generic;

namespace Envoy.Api.ServerComponent.VisitorAndProtectApis
{
    public class FlowsHelper : BaseHelper
    {
        public IEnumerable<Flow> GetLocations()
        {
            //var client = new RestClient("https://api.envoy.com/v1/flows");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

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
