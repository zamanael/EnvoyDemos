using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.SpacesApis;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class SpacesController : ApiController
    {
        private readonly SpacesHelper _spaceHelper;

        public SpacesController()
        {
            _spaceHelper = new SpacesHelper();
        }

        [HttpGet]
        [Route("spaces")]
        public async Task<SpaceResponse> GetSpacesAsync()
        {
            return await _spaceHelper.GetSpacesAsync();
        }

        [HttpGet]
        [Route("spaces/{id}")]
        public async Task<SpaceResponse> GetSpaceByIdAsync(int id)
        {
            return await _spaceHelper.GetSpaceByIdAsync(id);
        }
    }
}
