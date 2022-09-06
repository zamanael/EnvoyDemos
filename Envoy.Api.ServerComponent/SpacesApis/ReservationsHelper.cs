using Envoy.Models;
using System.Collections.Generic;

namespace Envoy.Api.ServerComponent.SpacesApis
{
    public class ReservationsHelper : BaseHelper
    {
        public IEnumerable<Reservation> GetReservation()
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Reservation> GetReservationById(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/id");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Accept", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Reservation> UpdateReservationCheckin(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/Id/checkin");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Reservation> UpdateReservationCheckout(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/id/checkout");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Reservation> CreateReservation()
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public IEnumerable<Reservation> CancelReservation()
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/id/cancel");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
