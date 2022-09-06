using Envoy.Models;
using System.Collections.Generic;

namespace Envoy.Api.ServerComponent.VisitorAndProtectApis
{
    public class RecrurringInvitesHelper : BaseHelper
    {
        public IEnumerable<Invite> GetRecurringInviteById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/recurring-invites/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> UpdateRecurringInvite(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/recurring-invites/id");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> CreateRecurringInvite()
        {
            //var client = new RestClient("https://api.envoy.com/v1/recurring-invites");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
