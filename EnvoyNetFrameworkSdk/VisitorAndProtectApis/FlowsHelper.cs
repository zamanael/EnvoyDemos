using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.VisitorAndProtectApis
{
    public class FlowsHelper : BaseHelper
    {
        private const string flowsUri = "flows";
        private readonly ILog _logger;

        public FlowsHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<FlowsResponse> GetFlowsAsync()
        {
            try
            {
                _logger.Debug($"{nameof(GetFlowsAsync)}()");

                var responseString = await GetAsync(flowsUri);
                FlowsResponse flowsResponse = JsonConvert.DeserializeObject<FlowsResponse>(responseString);

                _logger.Debug($"{nameof(GetFlowsAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{flowsResponse.Serialize()}");

                return flowsResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<FlowResponse> GetFlowByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(GetFlowByIdAsync)}({nameof(id)}: {id})");

                var responseString = await GetAsync($"{flowsUri}/{id}");
                FlowResponse flowResponse = JsonConvert.DeserializeObject<FlowResponse>(responseString);

                _logger.Debug($"{nameof(GetFlowByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{flowResponse.Serialize()}");

                return flowResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }
    }
}
