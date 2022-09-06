using Envoy.Models;
using System.Collections.Generic;

namespace Envoy.Api.ServerComponent.VisitorAndProtectApis
{
    public class WorkSchedulesHelper : BaseHelper
    {
        public IEnumerable<Invite> GetWorkSchedules()
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules?page=1&perPage=100");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> GetWorkScheduleById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> CheckinWorkSchedule(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id/checkin");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> CheckoutWorkSchedule(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id/checkout");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> CreateWorkSchedule()
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Invite> DeleteWorkSchedule()
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id");
            //var request = new RestRequest(Method.DELETE);
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
