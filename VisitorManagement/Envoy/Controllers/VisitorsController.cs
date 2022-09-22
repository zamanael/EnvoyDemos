using CardAccess.Logging;
using EnvoyNetFrameworkSdk.Extensions;
using EnvoyNetFrameworkSdk.Models;
using EnvoyNetFrameworkSdk.VisitorAndProtectApis;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        [HttpPost]
        [Route("access-group-options")]
        public IEnumerable<Option> AccessGroupsOptions()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(AccessGroupsOptions)}()");


                var options = _visitorsHelper.GetAccessGroupOption();
                if (options.Count() == 0)
                {
                    options = new List<Option>()
                    {
                        new Option
                        {
                            Label = "Dummy Access Group 1",
                            Value = "1"
                        },
                        new Option
                        {
                            Label = "Dummy Access Group 2",
                            Value = "2"
                        },
                        new Option
                        {
                            Label = "Dummy Access Group 3",
                            Value = "3"
                        },
                    };
                }


                _logger.Debug($"{nameof(AccessGroupsOptions)}() - " +
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
        [Route("employee-access-duration-options")]
        public IEnumerable<Option> EmployeeAccessDurationOptions()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(EmployeeAccessDurationOptions)}()");


                var options = new List<Option>()
                {
                    new Option
                    {
                        Label = "12 Hours",
                        Value = "12"
                    },
                    new Option
                    {
                        Label = "15 Hours",
                        Value = "15"
                    },
                    new Option
                    {
                        Label = "18 Hours",
                        Value = "18"
                    },
                };


                _logger.Debug($"{nameof(EmployeeAccessDurationOptions)}() - " +
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
        [Route("excluded-employees-options")]
        public IEnumerable<Option> ExcludedEmployeesOptions()
        {
            try
            {
                _logger.Debug($"{nameof(Request.RequestUri.AbsolutePath)}: {Request.RequestUri.AbsolutePath}");
                _logger.Debug($"{nameof(EmployeeAccessDurationOptions)}()");


                var options = new List<Option>()
                {
                    new Option
                    {
                        Label = "John Doe",
                        Value = "12345"
                    },
                    new Option
                    {
                        Label = "Jenny Doe",
                        Value = "12346"
                    },
                    new Option
                    {
                        Label = "James Smith",
                        Value = "12347"
                    },
                    new Option
                    {
                        Label = "Mary Smith",
                        Value = "12348"
                    },
                };


                _logger.Debug($"{nameof(EmployeeAccessDurationOptions)}() - " +
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