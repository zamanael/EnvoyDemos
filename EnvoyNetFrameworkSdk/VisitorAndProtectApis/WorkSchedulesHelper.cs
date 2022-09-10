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

        public async Task<WorkSchedulesResponse> GetWorkSchedulesAsync(int page = 1, int perPage = 100)
        {
            try
            {
                var responseString = await GetAsync($"{workSchedulesUri}?page={page}&perPage={perPage}");
                return JsonConvert.DeserializeObject<WorkSchedulesResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<WorkScheduleResponse> GetWorkScheduleByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{workSchedulesUri}/{id}");
                return JsonConvert.DeserializeObject<WorkScheduleResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
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
