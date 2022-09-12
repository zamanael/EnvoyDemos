using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.Spaces;
using EnvoyNetFrameworkSdk.SpacesApis;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class SpacesController : ApiController
    {
        private readonly SpacesHelper _spaceHelper;
        private readonly ILog _logger;

        public SpacesController()
        {
            _spaceHelper = new SpacesHelper();
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        [HttpGet]
        [Route("spaces")]
        public async Task<SpaceResponse> GetSpacesAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetSpacesAsync)}()");

                SpaceResponse spaceResponse = await _spaceHelper.GetSpacesAsync();

                _logger.Debug($"{nameof(GetSpacesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{spaceResponse.Serialize()}");

                return spaceResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("spaces/{id}")]
        public async Task<SpaceResponse> GetSpaceByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetSpaceByIdAsync)}({nameof(id)}: {id})");

                SpaceResponse spaceResponse = await _spaceHelper.GetSpaceByIdAsync(id);

                _logger.Debug($"{nameof(GetSpaceByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{spaceResponse.Serialize()}");

                return spaceResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
