using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.Spaces;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.SpacesApis
{
    public class ReservationsHelper : BaseHelper
    {
        private const string reservationsUri = "reservations";
        private readonly ILog _logger;

        public ReservationsHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<ReservationResponse> GetReservationAsync()
        {
            try
            {
                _logger.Debug($"{nameof(GetReservationAsync)}()");

                var responseString = await GetAsync(reservationsUri);
                ReservationResponse reservationResponse = JsonConvert.DeserializeObject<ReservationResponse>(responseString);

                _logger.Debug($"{nameof(GetReservationAsync)}() - " +
                  $"\nResponse: " +
                  $"\n{reservationResponse.Serialize()}");

                return reservationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }

        public async Task<ReservationResponse> GetReservationByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(GetReservationByIdAsync)}({nameof(id)}: {id})");

                var responseString = await GetAsync($"{reservationsUri}/{id}");
                ReservationResponse reservationResponse = JsonConvert.DeserializeObject<ReservationResponse>(responseString);

                _logger.Debug($"{nameof(GetReservationByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{reservationResponse.Serialize()}");

                return reservationResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
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
