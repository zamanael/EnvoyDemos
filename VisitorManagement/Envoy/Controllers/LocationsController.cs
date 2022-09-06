using Envoy.Api.ServerComponent.CoreApis;
using Envoy.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class LocationsController : ApiController
    {
        private readonly LocationsHelper _locationsHelper;

        public LocationsController()
        {
            _locationsHelper = new LocationsHelper();
        }

        [HttpGet]
        [Route("locations")]
        public async Task<LocationResponse> GetLocationsAsync()
        {
            return await _locationsHelper.GetLocationsAsync();
        }

        [HttpGet]
        [Route("locations/{id}")]
        public async Task<LocationResponse> GetLocationByIdAsync(int id)
        {
            return await _locationsHelper.GetLocationByIdAsync(id);
        }
    }
}
