using Envoy.Api.ServerComponent.CoreApis;
using Envoy.Models;
using System.Collections.Generic;
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
        public IEnumerable<Location> GetLocations()
        {
            return _locationsHelper.GetLocations();
        }

        [HttpGet]
        [Route("locations/{id}")]
        public IEnumerable<Location> GetLocationById(int id)
        {
            return _locationsHelper.GetLocationById(id);
        }
    }
}
