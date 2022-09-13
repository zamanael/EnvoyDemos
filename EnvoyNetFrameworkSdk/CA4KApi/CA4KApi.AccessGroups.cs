using EnvoyNetFrameworkSdk.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed partial class CA4KApi
    {
        public IEnumerable<Option> GetAccessGroupsOptions()
        {
            try
            {
                var dt = caAccess.GetAccessGroups();

                if (dt != null)
                {
                    return dt.AsEnumerable()
                        .Select(dr => new Option
                        {
                            Label = dr["DisplayMember"].ToString(),
                            Value = dr["ValueMember"].ToString()
                        })
                        .ToArray();
                }

                return Enumerable.Empty<Option>();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

