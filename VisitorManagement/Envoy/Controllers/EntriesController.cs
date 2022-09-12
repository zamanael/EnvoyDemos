using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models.VisitorAndProtect;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class EntriesController : ApiController
    {
        private readonly EntriesHelper _entriesHelper;
        private readonly ILog _logger;

        public EntriesController()
        {
            _entriesHelper = new EntriesHelper();
            _logger = Logger.GetLogger<EmployeesController>();
        }

        [HttpGet]
        [Route("entries")]
        public async Task<EntryResponse> GetEntriesAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetEntriesAsync)}()");

                EntryResponse entryResponse = await _entriesHelper.GetEntriesAsync();

                _logger.Debug($"{nameof(GetEntriesAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{entryResponse.Serialize()}");

                return entryResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpGet]
        [Route("entries/{id}")]
        public async Task<EntryResponse> GetEntryByIdAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetEntryByIdAsync)}({nameof(id)}: {id})");

                EntryResponse entryResponse = await _entriesHelper.GetEntryByIdAsync(id);

                _logger.Debug($"{nameof(GetEntryByIdAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{entryResponse.Serialize()}");

                return entryResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("entries/{id}")]
        public async Task<EntryResponse> UpdateEntryAsync(int id)
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(UpdateEntryAsync)}({nameof(id)}: {id})");

                EntryResponse entryResponse = await _entriesHelper.UpdateEntryAsync(id);

                _logger.Debug($"{nameof(UpdateEntryAsync)}({nameof(id)}: {id}) - " +
                   $"\nResponse: " +
                   $"\n{entryResponse.Serialize()}");

                return entryResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("entries")]
        public async Task<EntryResponse> CreateEntryAsync()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(CreateEntryAsync)}()");

                EntryResponse entryResponse = await _entriesHelper.CreateEntryAsync();

                _logger.Debug($"{nameof(CreateEntryAsync)}() - " +
                   $"\nResponse: " +
                   $"\n{entryResponse.Serialize()}");

                return entryResponse;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
