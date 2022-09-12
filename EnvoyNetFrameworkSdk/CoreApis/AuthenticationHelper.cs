using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Models.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.CoreApis
{
    public class AuthenticationHelper : BaseHelper
    {
        private readonly ILog _logger;

        public AuthenticationHelper()
        {
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public async Task<TokenResponse> GetTokenAsync(IEnumerable<KeyValuePair<string,string>> formData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string encoded = Convert
                        .ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                        .GetBytes(AppSettings.ENVOY_CLIENT_ID + ":" + AppSettings.ENVOY_CLIENT_SECRET));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);

                    var formContent = new FormUrlEncodedContent(formData);

                    HttpResponseMessage response = await client.PostAsync(AppSettings.ENVOY_TOKEN_URL, formContent);
                    response.EnsureSuccessStatusCode();
                    var responseString = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<TokenResponse>(responseString);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw new Exception("An error occured");
            }
        }
    }
}
