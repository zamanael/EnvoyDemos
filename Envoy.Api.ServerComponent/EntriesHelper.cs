using Envoy.Models;
using System.Collections.Generic;

namespace Envoy.Api.ServerComponent
{
    public class EntriesHelper : BaseHelper
    {
        public IEnumerable<Entry> GetEntries()
        {
            //var client = new RestClient("https://api.envoy.com/v1/entries?page=1&perPage=30&sort=SIGNED_IN_AT&order=DESC");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Entry> GetEntryById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/entries/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Entry> UpdateEntry(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/entries/id");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Entry> CreateEntry()
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
