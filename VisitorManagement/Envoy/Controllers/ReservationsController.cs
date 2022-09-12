using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.SpacesApis;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class ReservationsController : ApiController
    {
        private readonly ReservationsHelper _reservationHelper;
        private readonly ILog _logger;

        public ReservationsController()
        {
            _reservationHelper = new ReservationsHelper();
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        [HttpGet]
        [Route("reservations")]
        public async Task<ReservationResponse> GetReservationAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetReservationAsync)}()");

                ReservationResponse reservationResponse = await _reservationHelper.GetReservationAsync();

                _logger.Debug($"{nameof(GetReservationAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{reservationResponse.Serialize()}");

                return reservationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("reservations/{id}")]
        public async Task<ReservationResponse> GetReservationByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetReservationByIdAsync)}({nameof(id)}: {id})");

                ReservationResponse reservationResponse = await _reservationHelper.GetReservationByIdAsync(id);

                _logger.Debug($"{nameof(GetReservationByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{reservationResponse.Serialize()}");

                return reservationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("reservations/{id}/{checkin}")]
        public async Task<ReservationResponse> UpdateReservationCheckinAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(UpdateReservationCheckinAsync)}({nameof(id)}: {id})");

                ReservationResponse reservationResponse = await _reservationHelper.UpdateReservationCheckinAsync(id);

                _logger.Debug($"{nameof(UpdateReservationCheckinAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{reservationResponse.Serialize()}");

                return reservationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("reservations/{id}/{checkout}")]
        public async Task<ReservationResponse> UpdateReservationCheckoutAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(UpdateReservationCheckoutAsync)}({nameof(id)}: {id})");

                ReservationResponse reservationResponse = await _reservationHelper.UpdateReservationCheckoutAsync(id);

                _logger.Debug($"{nameof(UpdateReservationCheckoutAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{reservationResponse.Serialize()}");

                return reservationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("reservations")]
        public async Task<ReservationResponse> CreateReservationAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(CreateReservationAsync)}()");

                ReservationResponse reservationResponse = await _reservationHelper.CreateReservationAsync();

                _logger.Debug($"{nameof(CreateReservationAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{reservationResponse.Serialize()}");

                return reservationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpDelete]
        [Route("reservations/{id}/cancel")]
        public async Task<ReservationResponse> CancelReservationAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(CancelReservationAsync)}()");

                ReservationResponse reservationResponse = await _reservationHelper.CancelReservationAsync();

                _logger.Debug($"{nameof(CancelReservationAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{reservationResponse.Serialize()}");

                return reservationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
