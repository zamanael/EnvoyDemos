using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.VisitorAndProtectApis
{
    public class EntriesHelper : BaseHelper
    {
        private const string entriesUri = "entries";
        private readonly ILog _logger;

        public EntriesHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<EntryResponse> GetEntriesAsync(int page = 1, int perPage = 30, string sort = "SIGNED_IN_AT", string order = "DESC")
        {
            try
            {
                _logger.Debug($"{nameof(GetEntriesAsync)}()");

                var responseString = await GetAsync($"{entriesUri}?page={page}&perPage={perPage}&sort={sort}&order={order}");
                EntryResponse entryResponse = JsonConvert.DeserializeObject<EntryResponse>(responseString);

                _logger.Debug($"{nameof(GetEntriesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{entryResponse.Serialize()}");

                return entryResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<EntryResponse> GetEntryByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(GetEntryByIdAsync)}({nameof(id)}: {id})");

                var responseString = await GetAsync($"{entriesUri}/{id}");
                EntryResponse entryResponse = JsonConvert.DeserializeObject<EntryResponse>(responseString);

                _logger.Debug($"{nameof(GetEntryByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{entryResponse.Serialize()}");

                return entryResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<EntryResponse> UpdateEntryAsync(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/entries/id");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<EntryResponse> CreateEntryAsync()
        {
            //var client = new RestClient("https://api.envoy.com/v1/entries");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
