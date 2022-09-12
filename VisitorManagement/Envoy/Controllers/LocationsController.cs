using CardAccess.Logging;
using EnvoyNetFrameworkSdk.CoreApis;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.Core;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class LocationsController : ApiController
    {
        private readonly LocationsHelper _locationsHelper;
        private readonly ILog _logger;

        public LocationsController()
        {
            _locationsHelper = new LocationsHelper();
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        [HttpGet]
        [Route("locations")]
        public async Task<LocationsResponse> GetLocationsAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetLocationsAsync)}()");

                LocationsResponse locationsResponse = await _locationsHelper.GetLocationsAsync();

                _logger.Debug($"{nameof(GetLocationsAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{locationsResponse.Serialize()}");

                return locationsResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("locations/{id}")]
        public async Task<LocationResponse> GetLocationByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetLocationByIdAsync)}({nameof(id)}: {id})");

                LocationResponse locationResponse = await _locationsHelper.GetLocationByIdAsync(id);

                _logger.Debug($"{nameof(GetLocationByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{locationResponse.Serialize()}");

                return locationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
