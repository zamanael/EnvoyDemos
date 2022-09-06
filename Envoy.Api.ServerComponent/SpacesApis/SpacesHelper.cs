using Envoy.Models;
using System.Collections.Generic;

namespace Envoy.Api.ServerComponent.SpacesApis
{
    public class SpacesHelper : BaseHelper
    {
        public IEnumerable<Space> GetSpaces()
        {
            //var client = new RestClient("https://api.envoy.com/v1/spaces?type=DESK&page=1&perPage=250");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

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
