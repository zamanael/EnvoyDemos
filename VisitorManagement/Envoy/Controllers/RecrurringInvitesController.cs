using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System.Threading.Tasks;
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
        public async Task<RecurringInviteResponse> GetRecurringInviteByIdAsync(int id)
        {
            return await _recurringInvitesHelper.GetRecurringInviteByIdAsync(id);
        }

        [HttpPost]
        [Route("recurring-invites/{id}")]
        public async Task<RecurringInviteResponse> UpdateRecurringInviteAsync(int id)
        {
            return await _recurringInvitesHelper.UpdateRecurringInviteAsync(id);
        }

        [HttpPost]
        [Route("recurring-invites")]
        public async Task<RecurringInviteResponse> CreateRecurringInviteAsync()
        {
            return await _recurringInvitesHelper.CreateRecurringInviteAsync();
        }
    }
}
