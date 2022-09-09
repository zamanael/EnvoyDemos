using Microsoft.AspNet.SignalR;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using VisitorManagement.Envoy;

namespace VisitorManagement
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                config.InitializeReceiveGenericJsonWebHooks();
            });
            EnvoyWebhookEventHandler.WebHookEventOccured += EnvoyWebhookEventHandler_WebHookEventOccured;
        }

        private void EnvoyWebhookEventHandler_WebHookEventOccured((string EventName, string PayLoad) obj)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<EnvoyWebhookEventHub>();
            hubContext.Clients.All.notifyEnvoyWebhookEvent(obj.EventName, obj.PayLoad);
        }
    }
}