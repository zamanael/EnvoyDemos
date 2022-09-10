using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class WorkSchedulesController : ApiController
    {
        private readonly WorkSchedulesHelper _workSchedulesHelper;

        public WorkSchedulesController()
        {
            _workSchedulesHelper = new WorkSchedulesHelper();
        }

        [HttpGet]
        [Route("work-schedules")]
        public async Task<WorkSchedulesResponse> GetWorkSchedulesAsync()
        {
            return await _workSchedulesHelper.GetWorkSchedulesAsync();
        }

        [HttpGet]
        [Route("work-schedules/{id}")]
        public async Task<WorkScheduleResponse> GetWorkScheduleByIdAsync(int id)
        {
            return await _workSchedulesHelper.GetWorkScheduleByIdAsync(id);
        }

        [HttpPost]
        [Route("work-schedules/{id}/checkin")]
        public async Task<WorkScheduleResponse> CheckinWorkScheduleAsync(int id)
        {
            return await _workSchedulesHelper.CheckinWorkScheduleAsync(id);
        }

        [HttpPost]
        [Route("work-schedules/{id}/checkout")]
        public async Task<WorkScheduleResponse> CheckoutWorkScheduleAsync(int id)
        {
            return await _workSchedulesHelper.CheckoutWorkScheduleAsync(id);
        }

        [HttpPost]
        [Route("work-schedules")]
        public async Task<WorkScheduleResponse> CreateWorkScheduleAsync()
        {
            return await _workSchedulesHelper.CreateWorkScheduleAsync();
        }

        [HttpDelete]
        [Route("work-schedules")]
        public async Task<WorkScheduleResponse> DeleteWorkScheduleAsync()
        {
            return await _workSchedulesHelper.DeleteWorkScheduleAsync();
        }
    }
}
