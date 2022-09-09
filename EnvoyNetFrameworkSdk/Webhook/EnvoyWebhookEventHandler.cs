//using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace VisitorManagement.Envoy
{
    /// <summary>
    /// This is a generic json webhook handler to receive Envoy events
    /// An entry added to Web.config file <add key="MS_WebHookReceiverSecret_GenericJson" value="80ad19e357b01a04fe767067df7cd31b96a844e1" />
    /// You can test this using postman with url {{webhook_base_url}}/api/webhooks/incoming/GenericJson?code=80ad19e357b01a04fe767067df7cd31b96a844e1
    /// Method: POST; Json Body: {"event": "foo","foo":"bar"}
    /// </summary>
    public class EnvoyWebhookEventHandler : WebHookHandler
    {
        public static event Action<(string EventName, string PayLoad)> WebHookEventOccured;

        public EnvoyWebhookEventHandler()
        {
            Receiver = "GenericJson";
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            JObject data = context.GetDataOrDefault<JObject>();
            string @event = (string)data["meta"]["event"];

            switch (@event)
            {
                case EnvoyWebhookEvents.LocationCapacityUpdated:
                    break;
                case EnvoyWebhookEvents.EntryScreened:
                    break;
                case EnvoyWebhookEvents.NDAFileSigned:
                    break;
                case EnvoyWebhookEvents.EntrySignIn:
                    break;
                case EnvoyWebhookEvents.EntrySignOut:
                    break;


                case EnvoyWebhookEvents.EmployeeCheckInCreated:
                    break;
                case EnvoyWebhookEvents.EmployeeCheckInUpdated:
                    break;
                case EnvoyWebhookEvents.EmployeeEntrySignIn:
                    break;
                case EnvoyWebhookEvents.EmployeeEntrySignOut:
                    break;
                case EnvoyWebhookEvents.EntryblockListDenied:
                    break;
                case EnvoyWebhookEvents.EntryBlockListReview:
                    break;
                case EnvoyWebhookEvents.InviteCreated:
                    break;
                case EnvoyWebhookEvents.InviteQRCodeSent:
                    break;
                case EnvoyWebhookEvents.InviteRemoved:
                    break;
                case EnvoyWebhookEvents.InviteUpdated:
                    break;
                case EnvoyWebhookEvents.SignIn:
                    break;
                case EnvoyWebhookEvents.TicketCreated:
                    break;
                case EnvoyWebhookEvents.UpcomingEmployeeOnSite:
                    break;
                case EnvoyWebhookEvents.UpcomingInvitedVisit:
                    break;
                default:
                    throw new NotImplementedException();
                    //break;
            }

            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<EnvoyWebhookEventHub>();
            //hubContext.Clients.All.notifyEnvoyWebhookEvent(@event, JsonConvert.SerializeObject(data));

            WebHookEventOccured?.Invoke((@event, JsonConvert.SerializeObject(data)));

            return Task.FromResult(true);
        }
    }
}