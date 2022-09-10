using EnvoyNetFrameworkSdk.Models.Core;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.CoreApis
{
    public class LocationsHelper : BaseHelper
    {
        private const string locationsUri = "locations";

        public async Task<LocationsResponse> GetLocationsAsync()
        {
            try
            {
                var responseString = await GetAsync(locationsUri);
                return JsonConvert.DeserializeObject<LocationsResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<LocationResponse> GetLocationByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{locationsUri}/{id}");
                return JsonConvert.DeserializeObject<LocationResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }
    }
}
