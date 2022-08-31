using Envoy.Api.ServerComponent;
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
            //var client = new RestClient("https://api.envoy.com/v1/reservations");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpGet]
        [Route("reservations/{id}")]
        public IEnumerable<Reservation> GetReservationById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpPost]
        [Route("reservations/{id}/{checkin}")]
        public IEnumerable<Reservation> UpdateReservationCheckin(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/Id/checkin");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpPost]
        [Route("reservations/{id}/{checkout}")]
        public IEnumerable<Reservation> UpdateReservationCheckout(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/id/checkout");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpPost]
        [Route("reservations")]
        public IEnumerable<Reservation> CreateReservation()
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        [HttpDelete]
        [Route("reservations/{id}/cancel")]
        public IEnumerable<Reservation> CancelReservation()
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/id/cancel");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
