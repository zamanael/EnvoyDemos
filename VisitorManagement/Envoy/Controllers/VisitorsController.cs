using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace VisitorManagement.Envoy.Controllers
{
    [RoutePrefix("envoy")]
    public class VisitorsController : ApiController
    {
        private readonly VisitorsHelper _visitorsHelper;
        private readonly ILog _logger;

        public VisitorsController()
        {
            _visitorsHelper = new VisitorsHelper();
            _logger = Logger.GetLogger<VisitorsController>();
        }

        [HttpPost]
        [Route("access-group-options")]
        public IEnumerable<Option> AccessGroupsOption()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(AccessGroupsOption)}()");

                var options = _visitorsHelper.GetAccessGroupOption();

                _logger.Debug($"{nameof(AccessGroupsOption)}() - " +
                   $"\nResponse: " +
                   $"\n{options.Serialize()}");

                return options;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("hello-options")]
        public IEnumerable<Option> GetHelloOption()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetHelloOption)}()");

                var options = new Option[]
                {
                    new Option{Label = "Hello", Value = "Hello"},
                    new Option{Label = "Hola", Value = "Hola"},
                    new Option{Label = "Aloha", Value = "Aloha"},
                };

                _logger.Debug($"{nameof(GetHelloOption)}() - " +
                 $"\nResponse: " +
                 $"\n{options.Serialize()}");

                return options;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        [HttpPost]
        [Route("goodbye-options")]
        public IEnumerable<Option> GetGoodbyeOption()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(GetGoodbyeOption)}()");

                var options = new Option[]
                {
                    new Option{Label = "Goodbye", Value = "Goodbye"},
                    new Option{Label = "Adios", Value = "Adios"},
                    new Option{Label = "Aloha", Value = "Aloha"},
                };

                _logger.Debug($"{nameof(GetGoodbyeOption)}() - " +
                   $"\nResponse: " +
                   $"\n{options.Serialize()}");

                return options;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}