using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.VisitorAndProtectApis
{
    public class WorkSchedulesHelper : BaseHelper
    {
        private const string workSchedulesUri = "work-schedules";
        private readonly ILog _logger;

        public WorkSchedulesHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<WorkSchedulesResponse> GetWorkSchedulesAsync(int page = 1, int perPage = 100)
        {
            try
            {
                _logger.Debug($"{nameof(GetWorkSchedulesAsync)}()");

                var responseString = await GetAsync($"{workSchedulesUri}?page={page}&perPage={perPage}");
                WorkSchedulesResponse workSchedulesResponse = JsonConvert.DeserializeObject<WorkSchedulesResponse>(responseString);

                _logger.Debug($"{nameof(GetWorkSchedulesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{workSchedulesResponse.Serialize()}");

                return workSchedulesResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<WorkScheduleResponse> GetWorkScheduleByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(GetWorkScheduleByIdAsync)}({nameof(id)}: {id})");

                var responseString = await GetAsync($"{workSchedulesUri}/{id}");
                WorkScheduleResponse workScheduleResponse = JsonConvert.DeserializeObject<WorkScheduleResponse>(responseString);

                _logger.Debug($"{nameof(GetWorkScheduleByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{workScheduleResponse.Serialize()}");

                return workScheduleResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<WorkScheduleResponse> CheckinWorkScheduleAsync(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id/checkin");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<WorkScheduleResponse> CheckoutWorkScheduleAsync(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id/checkout");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<WorkScheduleResponse> CreateWorkScheduleAsync()
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<WorkScheduleResponse> DeleteWorkScheduleAsync()
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id");
            //var request = new RestRequest(Method.DELETE);
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
