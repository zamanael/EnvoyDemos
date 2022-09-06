using Envoy.Api.ServerComponent.VisitorAndProtectApis;
using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class FlowsController : ApiController
    {
        private readonly FlowsHelper _flowsHelper;

        public FlowsController()
        {
            _flowsHelper = new FlowsHelper();
        }

        [HttpGet]
        [Route("flows")]
        public IEnumerable<Flow> GetLocations()
        {
            return _flowsHelper.GetLocations();
        }

        [HttpGet]
        [Route("flows/{id}")]
        public IEnumerable<Flow> GetLocationById(int id)
        {
            return _flowsHelper.GetLocationById(id);
        }
    }
}
