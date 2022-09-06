using Envoy.Models;
using System.Collections.Generic;

namespace Envoy.Api.ServerComponent.CoreApis
{
    public class LocationsHelper : BaseHelper
    {
        public IEnumerable<Location> GetLocations()
        {
            //var client = new RestClient("https://api.envoy.com/rest/v1/locations");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

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
