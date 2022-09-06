using Envoy.Api.ServerComponent.VisitorAndProtectApis;
using Envoy.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class InvitesController : ApiController
    {
        private readonly InvitesHelper _invitesHelper;

        public InvitesController()
        {
            _invitesHelper = new InvitesHelper();
        }

        [HttpGet]
        [Route("invites")]
        public async Task<InvitesResponse> GetInvitesAsync()
        {
            return await _invitesHelper.GetInvitesAsync();
        }

        [HttpGet]
        [Route("invites/{id}")]
        public async Task<InviteResponse> GetInviteByIdAsync(int id)
        {
            return await _invitesHelper.GetInviteByIdAsync(id);
        }

        [HttpPost]
        [Route("invites/{id}")]
        public async Task<InviteResponse> UpdateInviteAsync(int id)
        {
            return await _invitesHelper.UpdateInviteAsync(id);
        }

        [HttpPost]
        [Route("invites")]
        public async Task<InviteResponse> CreateInviteAsync()
        {
            return await _invitesHelper.CreateInviteAsync();
        }

        [HttpDelete]
        [Route("invites")]
        public async Task<InviteResponse> DeleteInviteAsync()
        {
            return await _invitesHelper.DeleteInviteAsync();
        }
    }
}
