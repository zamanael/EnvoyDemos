using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.VisitorAndProtectApis
{
    public class RecrurringInvitesHelper : BaseHelper
    {
        private const string recurringInvitesUri = "recurring-invites";
        private readonly ILog _logger;

        public RecrurringInvitesHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<RecurringInviteResponse> GetRecurringInviteByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(GetRecurringInviteByIdAsync)}({nameof(id)}: {id})");

                var responseString = await GetAsync($"{recurringInvitesUri}/{id}");
                RecurringInviteResponse recurringInviteResponse = JsonConvert.DeserializeObject<RecurringInviteResponse>(responseString);

                _logger.Debug($"{nameof(GetRecurringInviteByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{recurringInviteResponse.Serialize()}");

                return recurringInviteResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
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
