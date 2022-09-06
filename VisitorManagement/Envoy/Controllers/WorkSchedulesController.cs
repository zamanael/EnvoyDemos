using Envoy.Api.ServerComponent.VisitorAndProtectApis;
using Envoy.Models;
using System.Collections.Generic;
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
        public IEnumerable<Invite> GetWorkSchedules()
        {
            return _workSchedulesHelper.GetWorkSchedules();
        }

        [HttpGet]
        [Route("work-schedules/{id}")]
        public IEnumerable<Invite> GetWorkScheduleById(int id)
        {
            return _workSchedulesHelper.GetWorkScheduleById(id);
        }

        [HttpPost]
        [Route("work-schedules/{id}/checkin")]
        public IEnumerable<Invite> CheckinWorkSchedule(int id)
        {
            return _workSchedulesHelper.CheckinWorkSchedule(id);
        }

        [HttpPost]
        [Route("work-schedules/{id}/checkout")]
        public IEnumerable<Invite> CheckoutWorkSchedule(int id)
        {
            return _workSchedulesHelper.CheckoutWorkSchedule(id);
        }

        [HttpPost]
        [Route("work-schedules")]
        public IEnumerable<Invite> CreateWorkSchedule()
        {
            return _workSchedulesHelper.CreateWorkSchedule();
        }

        [HttpDelete]
        [Route("work-schedules")]
        public IEnumerable<Invite> DeleteWorkSchedule()
        {
            return _workSchedulesHelper.DeleteWorkSchedule();
        }
    }
}
