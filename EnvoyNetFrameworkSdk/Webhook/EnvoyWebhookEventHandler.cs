//using Microsoft.AspNet.SignalR;
using CardAccess.Logging;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace EnvoyNetFrameworkSdk.Webhook
{
    /// <summary>
    /// This is a generic json webhook handler to receive Envoy events
    /// An entry added to Web.config file <add key="MS_WebHookReceiverSecret_GenericJson" value="80ad19e357b01a04fe767067df7cd31b96a844e1" />
    /// You can test this using postman with url {{webhook_base_url}}/api/webhooks/incoming/GenericJson?code=80ad19e357b01a04fe767067df7cd31b96a844e1
    /// Method: POST; Json Body: {"event": "foo","foo":"bar"}
    /// </summary>
    public class EnvoyWebhookEventHandler : WebHookHandler
    {
        private readonly ILog _logger;

        public static event Action<(string EventName, string PayLoad)> LocationCapacityUpdated;
        public static event Action<(string EventName, string PayLoad)> EntryScreened;
        public static event Action<(string EventName, string PayLoad)> NDAFileSigned;
        public static event Action<(string EventName, string PayLoad)> EntrySignIn;
        public static event Action<(string EventName, string PayLoad)> EntrySignOut;
        public static event Action<(string EventName, string PayLoad)> EntryBlockListReview;
        public static event Action<(string EventName, string PayLoad)> EntryBlockListDenied;
        public static event Action<(string EventName, string PayLoad)> InviteCreated;
        public static event Action<(string EventName, string PayLoad)> InviteUpdated;
        public static event Action<(string EventName, string PayLoad)> InviteRemoved;
        public static event Action<(string EventName, string PayLoad)> UpcomingInvitedVisit;
        public static event Action<(string EventName, string PayLoad)> InviteQRCodeSent;
        public static event Action<(string EventName, string PayLoad)> EmployeeCheckInCreated;
        public static event Action<(string EventName, string PayLoad)> EmployeeCheckInUpdated;
        public static event Action<(string EventName, string PayLoad)> UpcomingEmployeeOnSite;
        public static event Action<(string EventName, string PayLoad)> EmployeeEntrySignIn;
        public static event Action<(string EventName, string PayLoad)> EmployeeEntrySignOut;
        public static event Action<(string EventName, string PayLoad)> TicketCreated;
        public static event Action<(string EventName, string PayLoad)> SignIn;

        public EnvoyWebhookEventHandler()
        {
            Receiver = "GenericJson";
            _logger = Logger.GetLogger("CardAccess.Web.UI");
        }

        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            JObject data = context.GetDataOrDefault<JObject>();
            string @event = (string)data["meta"]["event"];

            switch (@event)
            {
                case EnvoyWebhookEvents.LocationCapacityUpdated:
                    LocationCapacityUpdated?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.EntryScreened:
                    EntryScreened?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.NDAFileSigned:
                    NDAFileSigned?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.EntrySignIn:
                    CA4KApi.Instance.ActivateBadge(data);
                    EntrySignIn?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.EntrySignOut:
                    CA4KApi.Instance.DeactivateBadge(data);
                    EntrySignOut?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;


                case EnvoyWebhookEvents.EmployeeCheckInCreated:
                    EmployeeCheckInCreated?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.EmployeeCheckInUpdated:
                    EmployeeCheckInUpdated?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.EmployeeEntrySignIn:
                    EmployeeEntrySignIn?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.EmployeeEntrySignOut:
                    EmployeeEntrySignOut?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.EntryblockListDenied:
                    EntryBlockListDenied?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.EntryBlockListReview:
                    EntryBlockListReview?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.InviteCreated:
                    InviteCreated?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.InviteQRCodeSent:
                    InviteQRCodeSent?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.InviteRemoved:
                    InviteRemoved?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.InviteUpdated:
                    InviteUpdated?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.SignIn:
                    SignIn?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.TicketCreated:
                    TicketCreated?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.UpcomingEmployeeOnSite:
                    UpcomingEmployeeOnSite?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                case EnvoyWebhookEvents.UpcomingInvitedVisit:
                    UpcomingInvitedVisit?.Invoke((@event, JsonConvert.SerializeObject(data)));
                    break;
                default:
                    throw new NotImplementedException();
                    //break;
            }

            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<EnvoyWebhookEventHub>();
            //hubContext.Clients.All.notifyEnvoyWebhookEvent(@event, JsonConvert.SerializeObject(data));


            return Task.FromResult(true);
        }
    }
}