using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.VisitorAndProtectApis
{
    public class InvitesHelper : BaseHelper
    {
        private const string invitesUri = "invites";
        private readonly ILog _logger;

        public InvitesHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<InvitesResponse> GetInvitesAsync(string type = "VISITOR", int page = 1, int perPage = 100, string sort = "EXPECTED_ARRIVAL_AT", string order = "ASC")
        {
            try
            {
                _logger.Debug($"{nameof(GetInvitesAsync)}()");

                var responseString = await GetAsync($"{invitesUri}?type={type}&page={page}&perPage={perPage}&sort={sort}&order={order}");
                InvitesResponse invitesResponse = JsonConvert.DeserializeObject<InvitesResponse>(responseString);

                _logger.Debug($"{nameof(GetInvitesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{invitesResponse.Serialize()}");

                return invitesResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<InviteResponse> GetInviteByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(GetInviteByIdAsync)}({nameof(id)}: {id})");

                var responseString = await GetAsync($"{invitesUri}/{id}");
                InviteResponse inviteResponse = JsonConvert.DeserializeObject<InviteResponse>(responseString);

                _logger.Debug($"{nameof(GetInviteByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{inviteResponse.Serialize()}");

                return inviteResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
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
