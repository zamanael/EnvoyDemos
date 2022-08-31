using Envoy.Api.ServerComponent;
using Envoy.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class EntriesController : ApiController
    {
        private readonly EntriesHelper _entriesHelper;

        public EntriesController()
        {
            _entriesHelper = new EntriesHelper();
        }

        [HttpGet]
        [Route("entries")]
        public IEnumerable<Entry> GetEntries()
        {
            return _entriesHelper.GetEntries();
        }

        [HttpGet]
        [Route("entries/{id}")]
        public IEnumerable<Entry> GetEntryById(int id)
        {
            return _entriesHelper.GetEntryById(id);
        }

        [HttpPost]
        [Route("entries/{id}")]
        public IEnumerable<Entry> UpdateEntry(int id)
        {
            return _entriesHelper.UpdateEntry(id);
        }

        [HttpPost]
        [Route("entries")]
        public IEnumerable<Entry> CreateEntry()
        {
            return _entriesHelper.CreateEntry();
        }
    }
}
