using Envoy.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Envoy.Api.ServerComponent.VisitorAndProtectApis
{
    public class InvitesHelper : BaseHelper
    {
        private const string invitesUri = "invites";

        public async Task<InviteResponse> GetInvitesAsync(string type = "VISITOR", string approvalStatus = "PENDING", int page = 1, int perPage = 100, string sort = "EXPECTED_ARRIVAL_AT", string order = "DESC")
        {
            try
            {
                var responseString = await GetAsync($"{invitesUri}?type={type}&approvalStatus={approvalStatus}&page={page}&perPage={perPage}&sort={sort}&order={order}");
                return JsonConvert.DeserializeObject<InviteResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<InviteResponse> GetInviteByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{invitesUri}/{id}");
                return JsonConvert.DeserializeObject<InviteResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<InviteResponse> UpdateInviteAsync(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/invites/id");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<InviteResponse> CreateInviteAsync()
        {
            //var client = new RestClient("https://api.envoy.com/v1/invites");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<InviteResponse> DeleteInviteAsync()
        {
            //var client = new RestClient("https://api.envoy.com/v1/invites/id");
            //var request = new RestRequest(Method.DELETE);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
