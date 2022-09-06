using Envoy.Api.ServerComponent.SpacesApis;
using Envoy.Models;
using System.Collections.Generic;
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
        public IEnumerable<Reservation> GetReservation()
        {
            return _reservationHelper.GetReservation();
        }

        [HttpGet]
        [Route("reservations/{id}")]
        public IEnumerable<Reservation> GetReservationById(int id)
        {
            return _reservationHelper.GetReservationById(id);
        }

        [HttpPost]
        [Route("reservations/{id}/{checkin}")]
        public IEnumerable<Reservation> UpdateReservationCheckin(int id)
        {
            return _reservationHelper.UpdateReservationCheckin(id);
        }

        [HttpPost]
        [Route("reservations/{id}/{checkout}")]
        public IEnumerable<Reservation> UpdateReservationCheckout(int id)
        {
            return _reservationHelper.UpdateReservationCheckout(id);
        }

        [HttpPost]
        [Route("reservations")]
        public IEnumerable<Reservation> CreateReservation()
        {
            return _reservationHelper.CreateReservation();
        }

        [HttpDelete]
        [Route("reservations/{id}/cancel")]
        public IEnumerable<Reservation> CancelReservation()
        {
            return _reservationHelper.CancelReservation();
        }
    }
}
