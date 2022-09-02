using Microsoft.AspNet.SignalR;

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
