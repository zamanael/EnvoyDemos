using Envoy.Models;
using System.Collections.Generic;

namespace Envoy.Api.ServerComponent
{
    public class InvitesHelper : BaseHelper
    {
        public IEnumerable<Invite> GetInvites()
        {
            //var client = new RestClient("https://api.envoy.com/v1/invites?type=VISITOR&approvalStatus=PENDING&page=1&perPage=100&sort=EXPECTED_ARRIVAL_AT&order=DESC");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> GetInviteById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/invites/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> UpdateInvite(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/invites/id");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> CreateInvite()
        {
            //var client = new RestClient("https://api.envoy.com/v1/invites");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> DeleteInvite()
        {
            //var client = new RestClient("https://api.envoy.com/v1/invites/id");
            //var request = new RestRequest(Method.DELETE);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
