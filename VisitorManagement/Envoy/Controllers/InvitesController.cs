using Envoy.Api.ServerComponent;
using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    public class InvitesController : ApiController
    {
        private readonly InvitesHelper _invitesHelper;

        public InvitesController()
        {
            _invitesHelper = new InvitesHelper();
        }

        [HttpGet]
        [Route("invites")]
        public IEnumerable<Invite> GetInvites()
        {
            return _invitesHelper.GetInvites();
        }

        [HttpGet]
        [Route("invites/{id}")]
        public IEnumerable<Invite> GetInviteById(int id)
        {
            return _invitesHelper.GetInviteById(id);
        }

        [HttpPost]
        [Route("invites/{id}")]
        public IEnumerable<Invite> UpdateInvite(int id)
        {
            return _invitesHelper.UpdateInvite(id);
        }

        [HttpPost]
        [Route("invites")]
        public IEnumerable<Invite> CreateInvite()
        {
            return _invitesHelper.CreateInvite();
        }

        [HttpDelete]
        [Route("invites")]
        public IEnumerable<Invite> DeleteInvite()
        {
            return _invitesHelper.DeleteInvite();
        }
    }
}
