using Newtonsoft.Json;

namespace EnvoyNetFrameworkSdk.Extensions
{
    public static class ObjectExtensions
    {
        public static string Serialize(this object obj, Formatting formatting = Formatting.Indented)
        {
            return JsonConvert.SerializeObject(value: obj, formatting: formatting);
        }
    }
}
