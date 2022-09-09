using CardAccess.API;
using Envoy.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Envoy.Api.ServerComponent.VisitorAndProtectApis
{
    public class VisitorsHelper : BaseHelper
    {
        private ca4Knet caAccess;
        bool apiInitialized = false;

        public VisitorsHelper()
        {
            try
            {
                caAccess = new ca4Knet();
                caAccess.LogIn("admin", "");
                if (caAccess.ConnectStr != "")
                {
                    apiInitialized = true;
                }
            }
            catch (Exception ex)
            {
                if (caAccess != null) caAccess = null;
            }
        }

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
            List<Option> options = new List<Option>();

            var dt = caAccess.GetAccessGroups();

            if (dt!=null)
            {
                foreach (var dr in dt.AsEnumerable())
                {
                    options.Add(new Option
                    {
                       Label = dr["DisplayMember"].ToString(),
                       Value = dr["ValueMember"].ToString()
                    });
                }
            }

            return options;
        }
    }
}