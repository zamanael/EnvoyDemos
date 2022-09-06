using Envoy.Api.ServerComponent.SpacesApis;
using Envoy.Models;
using System.Collections.Generic;
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
        public IEnumerable<Space> GetSpaces()
        {
           return _spaceHelper.GetSpaces(); 
        }

        [HttpGet]
        [Route("spaces/{id}")]
        public IEnumerable<Space> GetSpaceById(int id)
        {
            return _spaceHelper.GetSpaceById(id);
        }
    }
}
