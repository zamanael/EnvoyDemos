using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VisitorManagement.Startup))]

namespace VisitorManagement
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
