using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class WorkSchedulesController : ApiController
    {
        [HttpGet]
        [Route("work-schedules")]
        public IEnumerable<Invite> GetWorkSchedules()
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules?page=1&perPage=100");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpGet]
        [Route("work-schedules/{id}")]
        public IEnumerable<Invite> GetWorkScheduleById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpPost]
        [Route("work-schedules/{id}/checkin")]
        public IEnumerable<Invite> CheckinWorkSchedule(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id/checkin");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpPost]
        [Route("work-schedules/{id}/checkout")]
        public IEnumerable<Invite> CheckoutWorkSchedule(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id/checkout");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpPost]
        [Route("work-schedules")]
        public IEnumerable<Invite> CreateWorkSchedule()
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpDelete]
        [Route("work-schedules")]
        public IEnumerable<Invite> DeleteWorkSchedule()
        {
            //var client = new RestClient("https://api.envoy.com/v1/work-schedules/id");
            //var request = new RestRequest(Method.DELETE);
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
