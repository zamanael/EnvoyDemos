using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
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
            JObject data = context.GetDataOrDefault<JObject>();
            string @event = (string)data["event"];

            switch (@event)
            {
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
                case EnvoyWebhookEvents.EntrySignIn:
                    break;
                case EnvoyWebhookEvents.EntrySignOut:
                    break;
                case EnvoyWebhookEvents.Invitecreated:
                    break;
                case EnvoyWebhookEvents.InviteQRCodeSent:
                    break;
                case EnvoyWebhookEvents.InviteRemoved:
                    break;
                case EnvoyWebhookEvents.InviteUpdated:
                    break;
                case EnvoyWebhookEvents.LocationCapacityUpdated:
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
                    break;
            }

            //switch (context.Id)
            //{
            //    case "i":
            //        context.Response = context.Request.CreateResponse();
            //        context.Response.Content = new StringContent("Hello slash command!");
            //        break;
            //    case "z":
            //        context.Response = context.Request.CreateResponse();
            //        context.Response.Content = new StringContent("Hello slash command!");
            //        break;
            //    default:
            //        break;
            //}

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<EnvoyWebhookEventHub>();
            hubContext.Clients.All.notifyEnvoyWebhookEvent(@event, JsonConvert.SerializeObject(data, Formatting.Indented));

            return Task.FromResult(true);
        }
    }
}