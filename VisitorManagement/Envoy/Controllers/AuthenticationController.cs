using EnvoyNetFrameworkSdk.CoreApis;
using EnvoyNetFrameworkSdk.Models;
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

        public AuthenticationController()
        {
            _authenticationHelper = new AuthenticationHelper();
        }

        [HttpPost]
        [Route("token")]
        public async Task<TokenResponse> GetTokenAsync()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            await Request.Content.ReadAsMultipartAsync(provider);

            var formData = provider.FormData.AllKeys
                  .Select(k => new KeyValuePair<string, string>(k, provider.FormData.GetValues(k).First()));

            return await _authenticationHelper.GetTokenAsync(formData);
        }
    }
}
