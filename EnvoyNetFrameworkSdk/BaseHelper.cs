using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk
{
    public class BaseHelper
    {
        private static string token = "";

        public async Task<string> GetAsync(string requesUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppSettings.ENVOY_API_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                SetAuthorization(client);
                HttpResponseMessage response = await client.GetAsync(requesUri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        private static void SetAuthorization(HttpClient client)
        {
            if (AppSettings.ENVOY_USE_X_API_KEY)
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", AppSettings.ENVOY_CLIENT_API_KEY);
            }
            else
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
