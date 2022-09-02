using Microsoft.AspNet.SignalR;

namespace VisitorManagement.Envoy
{
    public class EnvoyHub : Hub
    {
        public void Hello(string id, string message)
        {
            Clients.All.hello(id, message);
        }
    }
}