using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.SpacesApis;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class ReservationsController : ApiController
    {
        private readonly ReservationsHelper _reservationHelper;

        public ReservationsController()
        {
            _reservationHelper = new ReservationsHelper();
        }

        [HttpGet]
        [Route("reservations")]
        public async Task<ReservationResponse> GetReservationAsync()
        {
            return await _reservationHelper.GetReservationAsync();
        }

        [HttpGet]
        [Route("reservations/{id}")]
        public async Task<ReservationResponse> GetReservationByIdAsync(int id)
        {
            return await _reservationHelper.GetReservationByIdAsync(id);
        }

        [HttpPost]
        [Route("reservations/{id}/{checkin}")]
        public async Task<ReservationResponse> UpdateReservationCheckinAsync(int id)
        {
            return await _reservationHelper.UpdateReservationCheckinAsync(id);
        }

        [HttpPost]
        [Route("reservations/{id}/{checkout}")]
        public async Task<ReservationResponse> UpdateReservationCheckoutAsync(int id)
        {
            return await _reservationHelper.UpdateReservationCheckoutAsync(id);
        }

        [HttpPost]
        [Route("reservations")]
        public async Task<ReservationResponse> CreateReservationAsync()
        {
            return await _reservationHelper.CreateReservationAsync();
        }

        [HttpDelete]
        [Route("reservations/{id}/cancel")]
        public async Task<ReservationResponse> CancelReservationAsync()
        {
            return await _reservationHelper.CancelReservationAsync();
        }
    }
}
