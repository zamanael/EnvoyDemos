using Envoy.Api.ServerComponent.VisitorAndProtectApis;
using Envoy.Models;
using System.Threading.Tasks;
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
        public async Task<EntryResponse> GetEntriesAsync()
        {
            return await _entriesHelper.GetEntriesAsync();
        }

        [HttpGet]
        [Route("entries/{id}")]
        public async Task<EntryResponse> GetEntryByIdAsync(int id)
        {
            return await _entriesHelper.GetEntryByIdAsync(id);
        }

        [HttpPost]
        [Route("entries/{id}")]
        public async Task<EntryResponse> UpdateEntryAsync(int id)
        {
            return await _entriesHelper.UpdateEntryAsync(id);
        }

        [HttpPost]
        [Route("entries")]
        public async Task<EntryResponse> CreateEntryAsync()
        {
            return await _entriesHelper.CreateEntryAsync();
        }
    }
}
