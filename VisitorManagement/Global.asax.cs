using EnvoyNetFrameworkSdk.Webhook;
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
            log4net.Config.XmlConfigurator.Configure();

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

            EnvoyWebhookEventHandler.LocationCapacityUpdated += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EntryScreened += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.NDAFileSigned += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EntrySignIn += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EntrySignOut += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EntryBlockListReview += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EntryBlockListDenied += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.InviteCreated += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.InviteUpdated += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.InviteRemoved += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.UpcomingInvitedVisit += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.InviteQRCodeSent += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EmployeeCheckInCreated += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EmployeeCheckInUpdated += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.UpcomingEmployeeOnSite += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EmployeeEntrySignIn += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.EmployeeEntrySignOut += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.TicketCreated += EnvoyWebhookEventHandler_WebHookEventOccured;
            EnvoyWebhookEventHandler.SignIn += EnvoyWebhookEventHandler_WebHookEventOccured;
        }

        private void EnvoyWebhookEventHandler_WebHookEventOccured((string EventName, string PayLoad) obj)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<EnvoyWebhookEventHub>();
            hubContext.Clients.All.notifyEnvoyWebhookEvent(obj.EventName, obj.PayLoad);
        }
    }
}