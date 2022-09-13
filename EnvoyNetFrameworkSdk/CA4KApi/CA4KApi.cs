using CardAccess.API;
using CardAccess.Logging;
using System;

namespace EnvoyNetFrameworkSdk
{
    public sealed partial class CA4KApi
    {
        //the volatile keyword ensures that the instantiation is complete 
        //before it can be accessed further helping with thread safety.
        private static volatile CA4KApi _instance;
        private static readonly object SyncLock = new object();

        private readonly ca4Knet caAccess;
        readonly bool apiInitialized = false;
        private readonly ILog _logger;

        private CA4KApi()
        {
            try
            {
                _logger = Logger.GetLogger("CardAccess.Web.UI");
                caAccess = new ca4Knet();
                caAccess.LogIn("admin", "");
                if (caAccess.ConnectStr != "")
                {
                    apiInitialized = true;
                }
            }
            catch (Exception)
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
    }
}

