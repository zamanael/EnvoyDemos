using System.Collections.Generic;
using System.Web.Http;
using VisitorManagement.Envoy.Models;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class RecrurringInvitesController : ApiController
    {
        [HttpGet]
        [Route("recurring-invites/{id}")]
        public IEnumerable<Invite> GetRecurringInviteById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/recurring-invites/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpPost]
        [Route("recurring-invites/{id}")]
        public IEnumerable<Invite> UpdateRecurringInvite(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/recurring-invites/id");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpPost]
        [Route("recurring-invites")]
        public IEnumerable<Invite> CreateRecurringInvite()
        {
            //var client = new RestClient("https://api.envoy.com/v1/recurring-invites");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
