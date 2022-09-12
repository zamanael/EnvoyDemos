using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class FlowsController : ApiController
    {
        private readonly FlowsHelper _flowsHelper;
        private readonly ILog _logger;

        public FlowsController()
        {
            _flowsHelper = new FlowsHelper();
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        [HttpGet]
        [Route("flows")]
        public async Task<FlowsResponse> GetFlowsAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetFlowsAsync)}()");

                FlowsResponse flowsResponse = await _flowsHelper.GetFlowsAsync();

                _logger.Debug($"{nameof(GetFlowsAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{flowsResponse.Serialize()}");

                return flowsResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("flows/{id}")]
        public async Task<FlowResponse> GetFlowByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetFlowByIdAsync)}({nameof(id)}: {id})");

                FlowResponse flowResponse = await _flowsHelper.GetFlowByIdAsync(id);

                _logger.Debug($"{nameof(GetFlowByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{flowResponse.Serialize()}");

                return flowResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
