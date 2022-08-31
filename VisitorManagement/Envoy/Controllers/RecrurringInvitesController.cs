using Envoy.Api.ServerComponent;
using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class RecrurringInvitesController : ApiController
    {
        private readonly RecrurringInvitesHelper _recurringInvitesHelper;

        public RecrurringInvitesController()
        {
            _recurringInvitesHelper = new RecrurringInvitesHelper();
        }

        [HttpGet]
        [Route("recurring-invites/{id}")]
        public IEnumerable<Invite> GetRecurringInviteById(int id)
        {
            return _recurringInvitesHelper.GetRecurringInviteById(id);
        }

        [HttpPost]
        [Route("recurring-invites/{id}")]
        public IEnumerable<Invite> UpdateRecurringInvite(int id)
        {
           return _recurringInvitesHelper.UpdateRecurringInvite(id);
        }

        [HttpPost]
        [Route("recurring-invites")]
        public IEnumerable<Invite> CreateRecurringInvite()
        {
           return _recurringInvitesHelper.CreateRecurringInvite();
        }
    }
}
