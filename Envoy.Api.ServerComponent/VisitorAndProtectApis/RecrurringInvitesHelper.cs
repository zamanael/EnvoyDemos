using Envoy.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Envoy.Api.ServerComponent.VisitorAndProtectApis
{
    public class RecrurringInvitesHelper : BaseHelper
    {
        private const string recurringInvitesUri = "recurring-invites";

        public async Task<InviteResponse> GetRecurringInviteByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{recurringInvitesUri}/{id}");
                return JsonConvert.DeserializeObject<InviteResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<InviteResponse> UpdateRecurringInviteAsync(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/recurring-invites/id");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<InviteResponse> CreateRecurringInviteAsync()
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
