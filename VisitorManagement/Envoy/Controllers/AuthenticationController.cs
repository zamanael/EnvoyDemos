using Envoy.Api.ServerComponent.CoreApis;
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
    }
}
