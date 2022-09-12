using CardAccess.Logging;
using EnvoyNetFrameworkSdk.CoreApis;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class AuthenticationController : ApiController
    {
        private readonly AuthenticationHelper _authenticationHelper;
        private readonly ILog _logger;

        public AuthenticationController()
        {
            _authenticationHelper = new AuthenticationHelper();
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        [HttpPost]
        [Route("token")]
        public async Task<TokenResponse> GetTokenAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetTokenAsync)}()");

                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                string root = HttpContext.Current.Server.MapPath("~/App_Data");
                var provider = new MultipartFormDataStreamProvider(root);

                await Request.Content.ReadAsMultipartAsync(provider);

                var formData = provider.FormData.AllKeys
                      .Select(k => new KeyValuePair<string, string>(k, provider.FormData.GetValues(k).First()));

                TokenResponse tokenResponse = await _authenticationHelper.GetTokenAsync(formData);

                _logger.Debug($"{nameof(GetTokenAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{tokenResponse.Serialize()}");

                return tokenResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
