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
    public class WorkSchedulesController : ApiController
    {
        private readonly WorkSchedulesHelper _workSchedulesHelper;
        private readonly ILog _logger;

        public WorkSchedulesController()
        {
            _workSchedulesHelper = new WorkSchedulesHelper();
            _logger = Logger.GetLogger<WorkSchedulesController>();
        }

        [HttpGet]
        [Route("work-schedules")]
        public async Task<WorkSchedulesResponse> GetWorkSchedulesAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetWorkSchedulesAsync)}()");

                WorkSchedulesResponse workSchedulesResponse = await _workSchedulesHelper.GetWorkSchedulesAsync();

                _logger.Debug($"{nameof(GetWorkSchedulesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{workSchedulesResponse.Serialize()}");

                return workSchedulesResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("work-schedules/{id}")]
        public async Task<WorkScheduleResponse> GetWorkScheduleByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetWorkScheduleByIdAsync)}({nameof(id)}: {id})");

                WorkScheduleResponse workScheduleResponse = await _workSchedulesHelper.GetWorkScheduleByIdAsync(id);

                _logger.Debug($"{nameof(GetWorkScheduleByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{workScheduleResponse.Serialize()}");

                return workScheduleResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("work-schedules/{id}/checkin")]
        public async Task<WorkScheduleResponse> CheckinWorkScheduleAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(CheckinWorkScheduleAsync)}({nameof(id)}: {id})");

                WorkScheduleResponse workScheduleResponse = await _workSchedulesHelper.CheckinWorkScheduleAsync(id);

                _logger.Debug($"{nameof(CheckinWorkScheduleAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{workScheduleResponse.Serialize()}");

                return workScheduleResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("work-schedules/{id}/checkout")]
        public async Task<WorkScheduleResponse> CheckoutWorkScheduleAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(CheckoutWorkScheduleAsync)}({nameof(id)}: {id})");

                WorkScheduleResponse workScheduleResponse = await _workSchedulesHelper.CheckoutWorkScheduleAsync(id);

                _logger.Debug($"{nameof(CheckoutWorkScheduleAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{workScheduleResponse.Serialize()}");

                return workScheduleResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("work-schedules")]
        public async Task<WorkScheduleResponse> CreateWorkScheduleAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(CreateWorkScheduleAsync)}()");

                WorkScheduleResponse workScheduleResponse = await _workSchedulesHelper.CreateWorkScheduleAsync();

                _logger.Debug($"{nameof(CreateWorkScheduleAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{workScheduleResponse.Serialize()}");

                return workScheduleResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpDelete]
        [Route("work-schedules")]
        public async Task<WorkScheduleResponse> DeleteWorkScheduleAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(DeleteWorkScheduleAsync)}()");

                WorkScheduleResponse workScheduleResponse = await _workSchedulesHelper.DeleteWorkScheduleAsync();

                _logger.Debug($"{nameof(DeleteWorkScheduleAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{workScheduleResponse.Serialize()}");

                return workScheduleResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
