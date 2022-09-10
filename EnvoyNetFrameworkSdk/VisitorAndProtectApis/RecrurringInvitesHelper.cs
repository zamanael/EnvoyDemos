using EnvoyNetFrameworkSdk.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.VisitorAndProtectApis
{
    public class RecrurringInvitesHelper : BaseHelper
    {
        private const string recurringInvitesUri = "recurring-invites";

        public async Task<RecurringInviteResponse> GetRecurringInviteByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{recurringInvitesUri}/{id}");
                return JsonConvert.DeserializeObject<RecurringInviteResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<RecurringInviteResponse> UpdateRecurringInviteAsync(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/recurring-invites/id");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<RecurringInviteResponse> CreateRecurringInviteAsync()
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
