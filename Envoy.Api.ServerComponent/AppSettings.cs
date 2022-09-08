using System;
using System.Configuration;

namespace Envoy.Api.ServerComponent
{
    public static class AppSettings
    {
        public static readonly string ENVOY_CLIENT_ID = "ENVOY_CLIENT_ID".GetAppSettings<string>();
        public static readonly string ENVOY_CLIENT_SECRET = "ENVOY_CLIENT_SECRET".GetAppSettings<string>();
        public static readonly string ENVOY_CLIENT_API_KEY = "ENVOY_CLIENT_API_KEY".GetAppSettings<string>();
        public static readonly string ENVOY_API_URL = "ENVOY_API_URL".GetAppSettings<string>();
        public static readonly string ENVOY_TOKEN_URL = "ENVOY_TOKEN_URL".GetAppSettings<string>();
        public static readonly bool ENVOY_USE_X_API_KEY = "ENVOY_USE_X_API_KEY".GetAppSettings<bool>();

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
        private static bool IsNullableType(this Type type) => type.GetNullableType() != null;
        private static Type GetNullableType(this Type type) => Nullable.GetUnderlyingType(type);
    }
}
