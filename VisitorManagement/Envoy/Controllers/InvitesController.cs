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
    public class InvitesController : ApiController
    {
        private readonly InvitesHelper _invitesHelper;
        private readonly ILog _logger;

        public InvitesController()
        {
            _invitesHelper = new InvitesHelper();
            _logger = Logger.GetLogger<InvitesController>();
        }

        [HttpGet]
        [Route("invites")]
        public async Task<InvitesResponse> GetInvitesAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetInvitesAsync)}()");

                InvitesResponse invitesResponse = await _invitesHelper.GetInvitesAsync();

                _logger.Debug($"{nameof(GetInvitesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{invitesResponse.Serialize()}");

                return invitesResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("invites/{id}")]
        public async Task<InviteResponse> GetInviteByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetInviteByIdAsync)}({nameof(id)}: {id})");

                InviteResponse inviteResponse = await _invitesHelper.GetInviteByIdAsync(id);

                _logger.Debug($"{nameof(GetInviteByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{inviteResponse.Serialize()}");

                return inviteResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("invites/{id}")]
        public async Task<InviteResponse> UpdateInviteAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(UpdateInviteAsync)}({nameof(id)}: {id})");

                InviteResponse inviteResponse = await _invitesHelper.UpdateInviteAsync(id);

                _logger.Debug($"{nameof(UpdateInviteAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{inviteResponse.Serialize()}");

                return inviteResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("invites")]
        public async Task<InviteResponse> CreateInviteAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(CreateInviteAsync)}()");

                InviteResponse inviteResponse = await _invitesHelper.CreateInviteAsync();

                _logger.Debug($"{nameof(CreateInviteAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{inviteResponse.Serialize()}");

                return inviteResponse;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("invites")]
        public async Task<InviteResponse> DeleteInviteAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(DeleteInviteAsync)}()");

                InviteResponse inviteResponse = await _invitesHelper.DeleteInviteAsync();

                _logger.Debug($"{nameof(DeleteInviteAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{inviteResponse.Serialize()}");

                return inviteResponse;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
