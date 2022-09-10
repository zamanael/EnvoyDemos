using EnvoyNetFrameworkSdk.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnvoyNetFrameworkSdk.VisitorAndProtectApis
{
    public class VisitorsHelper : BaseHelper
    {
        public IEnumerable<Option> GetHelloOption()
        {
            return new Option[]
            {
                new Option{Label = "Hello", Value = "Hello"},
                new Option{Label = "Hola", Value = "Hola"},
                new Option{Label = "Aloha", Value = "Aloha"},
            };
        }

        public IEnumerable<Option> GetGoodbyeOption()
        {
            return new Option[]
            {
                new Option{Label = "Goodbye", Value = "Goodbye"},
                new Option{Label = "Adios", Value = "Adios"},
                new Option{Label = "Aloha", Value = "Aloha"},
            };
        }

        public IEnumerable<Option> GetAccessGroupOption()
        {
            return CA4KApi.Instance.GetAccessGrous()
                .Select(a => new Option
                {
                    Label = a.DisplayMember,
                    Value = a.ValueMember
                });
        }
    }
}