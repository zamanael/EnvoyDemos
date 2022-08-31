using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class VisitorsController : ApiController
    {
        [HttpPost]
        [Route("hello-options")]
        public IEnumerable<Option> GetHelloOption()
        {
            return new Option[]
            {
                new Option{Label = "Hello", Value = "Hello"},
                new Option{Label = "Hola", Value = "Hola"},
                new Option{Label = "Aloha", Value = "Aloha"},
            };
        }

        [HttpPost]
        [Route("goodbye-options")]
        public IEnumerable<Option> GetGoodbyeOption()
        {
            return new Option[]
            {
                new Option{Label = "Goodbye", Value = "Goodbye"},
                new Option{Label = "Adios", Value = "Adios"},
                new Option{Label = "Aloha", Value = "Aloha"},
            };
        }
    }
}