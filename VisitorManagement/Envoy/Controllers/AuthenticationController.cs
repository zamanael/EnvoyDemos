using Envoy.Api.ServerComponent.CoreApis;
using Envoy.Models;
using System.Threading.Tasks;
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
            var v = await Request.Content.ReadAsStringAsync();
            // return await _authenticationHelper.GetTokenAsync();
            return null;
        }
    }
}
