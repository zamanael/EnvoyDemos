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
    public class RecrurringInvitesController : ApiController
    {
        private readonly RecrurringInvitesHelper _recurringInvitesHelper;
        private readonly ILog _logger;

        public RecrurringInvitesController()
        {
            _recurringInvitesHelper = new RecrurringInvitesHelper();
            _logger = Logger.GetLogger<RecrurringInvitesController>();
        }

        [HttpGet]
        [Route("recurring-invites/{id}")]
        public async Task<RecurringInviteResponse> GetRecurringInviteByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetRecurringInviteByIdAsync)}({nameof(id)}: {id})");

                RecurringInviteResponse recurringInviteResponse = await _recurringInvitesHelper.GetRecurringInviteByIdAsync(id);

                _logger.Debug($"{nameof(GetRecurringInviteByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{recurringInviteResponse.Serialize()}");

                return recurringInviteResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("recurring-invites/{id}")]
        public async Task<RecurringInviteResponse> UpdateRecurringInviteAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(UpdateRecurringInviteAsync)}({nameof(id)}: {id})");

                RecurringInviteResponse recurringInviteResponse = await _recurringInvitesHelper.UpdateRecurringInviteAsync(id);

                _logger.Debug($"{nameof(UpdateRecurringInviteAsync)}({nameof(id)}: {id}) - " +
                       $"\nResponse: " +
                       $"\n{recurringInviteResponse.Serialize()}");

                return recurringInviteResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("recurring-invites")]
        public async Task<RecurringInviteResponse> CreateRecurringInviteAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(CreateRecurringInviteAsync)}()");

                RecurringInviteResponse recurringInviteResponse = await _recurringInvitesHelper.CreateRecurringInviteAsync();

                _logger.Debug($"{nameof(CreateRecurringInviteAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{recurringInviteResponse.Serialize()}");

                return recurringInviteResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
