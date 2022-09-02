using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace VisitorManagement.Envoy
{
    public class GenericJsonWebHookHandler : WebHookHandler
    {
        public GenericJsonWebHookHandler()
        {
            this.Receiver = "genericjson";
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            // Get JSON from WebHook
            JObject data = context.GetDataOrDefault<JObject>();

            if (context.Id == "i")
            {
                //You can use the passed in Id to route differently depending on source.
            }
            else if (context.Id == "z")
            {
            }

            return Task.FromResult(true);
        }
    }
}