using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.Core;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.CoreApis
{
    public class LocationsHelper : BaseHelper
    {
        private const string locationsUri = "locations";
        private readonly ILog _logger;

        public LocationsHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<LocationsResponse> GetLocationsAsync()
        {
            try
            {
                _logger.Debug($"{nameof(GetLocationsAsync)}()");

                var responseString = await GetAsync(locationsUri);
                LocationsResponse locationsResponse = JsonConvert.DeserializeObject<LocationsResponse>(responseString);

                _logger.Debug($"{nameof(GetLocationsAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{locationsResponse.Serialize()}");

                return locationsResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<LocationResponse> GetLocationByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(GetLocationByIdAsync)}({nameof(id)}: {id})");

                var responseString = await GetAsync($"{locationsUri}/{id}");
                LocationResponse locationResponse = JsonConvert.DeserializeObject<LocationResponse>(responseString);

                _logger.Debug($"{nameof(GetLocationByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{locationResponse.Serialize()}");

                return locationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }
    }
}
