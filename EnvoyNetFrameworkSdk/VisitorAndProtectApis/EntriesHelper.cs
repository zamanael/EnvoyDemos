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

        public async Task<EntryResponse> GetEntriesAsync(int page = 1, int perPage = 30, string sort = "SIGNED_IN_AT", string order = "DESC")
        {
            try
            {
                var responseString = await GetAsync($"{entriesUri}?page={page}&perPage={perPage}&sort={sort}&order={order}");
                return JsonConvert.DeserializeObject<EntryResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<EntryResponse> GetEntryByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{entriesUri}/{id}");
                return JsonConvert.DeserializeObject<EntryResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
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
