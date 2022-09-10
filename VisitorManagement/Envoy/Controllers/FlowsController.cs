using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System.Threading.Tasks;
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
        public async Task<FlowsResponse> GetFlowsAsync()
        {
            return await _flowsHelper.GetFlowsAsync();
        }

        [HttpGet]
        [Route("flows/{id}")]
        public async Task<FlowResponse> GetLocationByIdAsync(int id)
        {
            return await _flowsHelper.GetFlowByIdAsync(id);
        }
    }
}
