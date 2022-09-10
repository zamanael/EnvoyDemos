using EnvoyNetFrameworkSdk.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.SpacesApis
{
    public class ReservationsHelper : BaseHelper
    {
        private const string reservationsUri = "reservations";

        public async Task<ReservationResponse> GetReservationAsync()
        {
            try
            {
                var responseString = await GetAsync(reservationsUri);
                return JsonConvert.DeserializeObject<ReservationResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<ReservationResponse> GetReservationByIdAsync(int id)
        {
            try
            {
                var responseString = await GetAsync($"{reservationsUri}/{id}");
                return JsonConvert.DeserializeObject<ReservationResponse>(responseString);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception("An error occured");
            }
        }

        public async Task<ReservationResponse> UpdateReservationCheckinAsync(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/Id/checkin");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<ReservationResponse> UpdateReservationCheckoutAsync(int id)
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/id/checkout");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<ReservationResponse> CreateReservationAsync()
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            //IRestResponse response = client.Execute(request);

            return null;
        }

        public async Task<ReservationResponse> CancelReservationAsync()
        {
            //var client = new RestClient("https://api.envoy.com/v1/reservations/id/cancel");
            //var request = new RestRequest(Method.POST);
            //IRestResponse response = client.Execute(request);

            return null;
        }
    }
}
