using System;
using System.Configuration;
using System.Diagnostics;

namespace CardAccess.Archive.ServerComponent
{
    public static class AppSettings
    {
        public static readonly string ENVOY_CLIENT_ID = "ENVOY_CLIENT_ID".GetAppSettings<string>();
        public static readonly string ENVOY_CLIENT_SECRET = "ENVOY_CLIENT_SECRET".GetAppSettings<string>();
        public static readonly string ENVOY_CLIENT_API_KEY = "ENVOY_CLIENT_API_KEY".GetAppSettings<string>();
        public static readonly string ENVOY_API_URL = "ENVOY_API_URL".GetAppSettings<string>();

        private static T GetAppSettings<T>(this string name, T defaultValue = default(T))
        {
            Type type = typeof(T);
            string value = ConfigurationManager.AppSettings[name];

            try
            {
                return (type.IsNullableType() && value == null) ? defaultValue :
                    (T)Convert.ChangeType(value, !type.IsNullableType() ? type : type.GetNullableType());
            }
            catch
            {
                return defaultValue;
            }
        }

        private static string GetConnectionString(this string name)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            catch (Exception ex)
            {
                //ex.LogError($"Error getting connection string {name} from app.config");
                Debug.WriteLine($"Error getting connection string {name} from app.config");
                throw;
            }
        }
        private static bool IsNullableType(this Type type) => type.GetNullableType() != null;
        private static Type GetNullableType(this Type type) => Nullable.GetUnderlyingType(type);
    }
}
