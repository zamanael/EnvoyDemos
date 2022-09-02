using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Linq;

namespace VisitorManagement.Envoy
{
    public class EnvoyWebhookEventHub : Hub
    {
        public void NotifyEnvoyWebhookEvent(string eventName, string data)
        {
            Clients.All.notifyEnvoyWebhookEvent(eventName, data);
        }
    }
}
