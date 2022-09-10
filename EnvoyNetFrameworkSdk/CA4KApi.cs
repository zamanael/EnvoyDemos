using CardAccess.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EnvoyNetFrameworkSdk
{
    public sealed class CA4KApi
    {
        //the volatile keyword ensures that the instantiation is complete 
        //before it can be accessed further helping with thread safety.
        private static volatile CA4KApi _instance;
        private static readonly object SyncLock = new object();

        private ca4Knet caAccess;
        bool apiInitialized = false;

        private CA4KApi()
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

        //uses a pattern known as double check locking
        public static CA4KApi Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                lock (SyncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CA4KApi();
                    }
                }

                return _instance;
            }
        }

        public IEnumerable<(string DisplayMember, string ValueMember)> GetAccessGrous()
        {
            var dt = caAccess.GetAccessGroups();

            if (dt != null)
            {
                return dt.AsEnumerable()
                    .Select(dr => (dr["DisplayMember"].ToString(), dr["ValueMember"].ToString()))
                    .ToArray();
            }

            return Enumerable.Empty<(string, string)>();
        }

    }
}
