using EnvoyNetFrameworkSdk.Models.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnvoyNetFrameworkSdk.Models.WebHook
{
    //public class EntrySignOutResponse
    //{
    //    [JsonProperty("meta")]
    //    public EntrySignOutMeta Meta { get; set; }

    //    [JsonProperty("payload")]
    //    public EntrySignOutPayload Payload { get; set; }
    //}

    //public class EntrySignOutMeta
    //{
    //    [JsonProperty("event")]
    //    public string Event { get; set; }

    //    [JsonProperty("plugin_id")]
    //    public string Plugin_id { get; set; }

    //    [JsonProperty("install_id")]
    //    public string Install_id { get; set; }

    //    [JsonProperty("env")]
    //    public Env Env { get; set; }

    //    [JsonProperty("config")]
    //    public Config Config { get; set; }

    //    [JsonProperty("")]
    //    public Job Job { get; set; }

    //    [JsonProperty("company")]
    //    public WebhookCompany Company { get; set; }

    //    [JsonProperty("auth")]
    //    public TokenResponse Auth { get; set; }

    //    [JsonProperty("location")]
    //    public WebhookLocation Location { get; set; }
    //}

    //public class Env
    //{
    //    [JsonProperty("accessGroups")]
    //    public string AccessGroups { get; set; }
    //}

    //public class Config
    //{
    //    [JsonProperty("accessGroups")]
    //    public string AccessGroups { get; set; }
    //}

    //public class Job
    //{
    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("identifier")]
    //    public string Identifier { get; set; }
    //}

    //public class WebhookCompany
    //{
    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("type")]
    //    public string Type { get; set; }

    //    [JsonProperty("attributes")]
    //    public CompanyAttributes Attributes { get; set; }
    //}

    //public class CompanyAttributes
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("plan-intent")]
    //    public string PlanIntent { get; set; }

    //    [JsonProperty("buy-intent")]
    //    public bool? BuyIntent { get; set; }

    //    [JsonProperty("created-at")]
    //    public bool? Active { get; set; }

    //    [JsonProperty("created-at")]
    //    public DateTime? CreatedAt { get; set; }
    //}

    //public class WebhookLocation
    //{
    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("type")]
    //    public string Type { get; set; }

    //    [JsonProperty("attributes")]
    //    public LocationsAttributes Attributes { get; set; }

    //    [JsonProperty("relationships")]
    //    public LocationRelationships Relationships { get; set; }
    //}

    //public class LocationsAttributes
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("company-name-override")]
    //    public object CompanyNameOverride { get; set; }

    //    [JsonProperty("time-zone")]
    //    public string Time_Zone { get; set; }

    //    [JsonProperty("timezone")]
    //    public string Timezone { get; set; }

    //    [JsonProperty("locale")]
    //    public string Locale { get; set; }

    //    [JsonProperty("address")]
    //    public string Address { get; set; }

    //    [JsonProperty("address-line-one")]
    //    public object AddressLineOne { get; set; }

    //    [JsonProperty("address-line-two")]
    //    public string AddressLineTwo { get; set; }

    //    [JsonProperty("city")]
    //    public string City { get; set; }

    //    [JsonProperty("state")]
    //    public string State { get; set; }

    //    [JsonProperty("country")]
    //    public string Country { get; set; }

    //    [JsonProperty("zip")]
    //    public object Zip { get; set; }

    //    [JsonProperty("longitude")]
    //    public double Longitude { get; set; }

    //    [JsonProperty("latitude")]
    //    public double Latitude { get; set; }

    //    [JsonProperty("created-at")]
    //    public DateTime CreatedAt { get; set; }
    //}
    //public class LocationRelationships
    //{
    //    [JsonProperty("company")]
    //    public RelationshipsCompany Company { get; set; }
    //}

    //public class RelationshipsCompany
    //{
    //    [JsonProperty("data")]
    //    public RelationshipsCompanyData Data { get; set; }
    //}

    //public class RelationshipsCompanyData
    //{
    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("type")]
    //    public string Type { get; set; }
    //}

    //public class EntrySignOutPayload
    //{
    //    [JsonProperty("id")]
    //    public string Id { get; set; }

    //    [JsonProperty("type")]
    //    public string Type { get; set; }

    //    [JsonProperty("attributes")]
    //    public EntrySignOutPayloadAttributes Attributes { get; set; }

    //    [JsonProperty("relationships")]
    //    public Relationships Relationships { get; set; }
    //}

    //public class EntrySignOutPayloadAttributes
    //{
    //    [JsonProperty("agreements-status")]
    //    public string AgreementsStatus { get; set; }

    //    [JsonProperty("checked-in-at")]
    //    public object CheckedInAt { get; set; }

    //    [JsonProperty("full-name")]
    //    public string FullName { get; set; }

    //    [JsonProperty("email")]
    //    public string Email { get; set; }

    //    [JsonProperty("employee-screening-flow")]
    //    public bool? EmployeeScreeningFlow { get; set; }

    //    [JsonProperty("host")]
    //    public string Host { get; set; }

    //    [JsonProperty("host-email")]
    //    public string HostEmail { get; set; }

    //    [JsonProperty("private-notes")]
    //    public object PrivateNotes { get; set; }

    //    [JsonProperty("signed-in-at")]
    //    public string SignedInAt { get; set; }

    //    [JsonProperty("device-session-uuid")]
    //    public string DeviceSessionUuid { get; set; }

    //    [JsonProperty("signed-in-via")]
    //    public string SignedInVia { get; set; }

    //    [JsonProperty("signed-in-by")]
    //    public object SignedInBy { get; set; }

    //    [JsonProperty("signed-out-via")]
    //    public string SignedOutVia { get; set; }

    //    [JsonProperty("signed-out-by")]
    //    public object SignedOutBy { get; set; }

    //    [JsonProperty("signed-out-at")]
    //    public string SignedOutAt { get; set; }

    //    [JsonProperty("thumbnails")]
    //    public Thumbnails Thumbnails { get; set; }

    //    [JsonProperty("flow-name")]
    //    public string FlowName { get; set; }

    //    [JsonProperty("original-nda-sign-date")]
    //    public object OriginalNdaSignDate { get; set; }

    //    [JsonProperty("nda")]
    //    public string Nda { get; set; }

    //    [JsonProperty("legal-docs")]
    //    public List<LegalDoc> LegalDocs { get; set; }

    //    [JsonProperty("group-name")]
    //    public object GroupName { get; set; }

    //    [JsonProperty("id-check-status")]
    //    public string IdCheckStatus { get; set; }

    //    [JsonProperty("is-delivery")]
    //    public bool? IsDelivery { get; set; }

    //    [JsonProperty("agreement-refused")]
    //    public bool? AgreementRefused { get; set; }

    //    [JsonProperty("pov-key")]
    //    public string PovKey { get; set; }

    //    [JsonProperty("user-data")]
    //    public List<UserDatum> UserData { get; set; }

    //    [JsonProperty("sms-status")]
    //    public string SmsStatus { get; set; }

    //    [JsonProperty("approval-status")]
    //    public ApprovalStatus ApprovalStatus { get; set; }

    //    [JsonProperty("failure-message-markdown")]
    //    public string FailureMessageMarkdown { get; set; }

    //    [JsonProperty("custom-deny-markdown")]
    //    public string CustomDenyMarkdown { get; set; }

    //    [JsonProperty("push-status")]
    //    public string PushStatus { get; set; }

    //    [JsonProperty("email-status")]
    //    public string EmailStatus { get; set; }
    //}
    //public class LegalDoc
    //{
    //    [JsonProperty("id")]
    //    public int Id { get; set; }

    //    [JsonProperty("url")]
    //    public string Url { get; set; }

    //    [JsonProperty("signed-at")]
    //    public string SignedAt { get; set; }

    //    [JsonProperty("agreement")]
    //    public Agreement Agreement { get; set; }
    //}

    //public class Agreement
    //{
    //    [JsonProperty("id")]
    //    public int Id { get; set; }
    //}

    //public class Thumbnails
    //{
    //    [JsonProperty("large")]
    //    public object Large { get; set; }

    //    [JsonProperty("original")]
    //    public object Original { get; set; }

    //    [JsonProperty("small")]
    //    public object Small { get; set; }
    //}

    //public class UserDatum
    //{
    //    [JsonProperty("field")]
    //    public string Field { get; set; }

    //    [JsonProperty("value")]
    //    public string Value { get; set; }
    //}

    //public class ApprovalStatus
    //{
    //    [JsonProperty("status")]
    //    public string Status { get; set; }

    //    [JsonProperty("auto-approved")]
    //    public bool? AutoApproved { get; set; }

    //    public List<Report> report { get; set; }

    //    [JsonProperty("reviewer-id")]
    //    public object ReviewerId { get; set; }

    //    [JsonProperty("reviewer-name")]
    //    public object ReviewerName { get; set; }

    //    [JsonProperty("review-note")]
    //    public object ReviewNote { get; set; }

    //    [JsonProperty("reviewed-at")]
    //    public object ReviewedAt { get; set; }
    //}

    //public class Report
    //{
    //    [JsonProperty("reason")]
    //    public string Reason { get; set; }

    //    [JsonProperty("result")]
    //    public string Result { get; set; }

    //    [JsonProperty("source")]
    //    public string Source { get; set; }

    //    [JsonProperty("messages")]
    //    public Messages Messages { get; set; }
    //}

    //public class Messages
    //{
    //    [JsonProperty("failure")]
    //    public Failure Failure { get; set; }
    //}

    //public class Failure
    //{
    //    [JsonProperty("text")]
    //    public string Text { get; set; }

    //    [JsonProperty("header")]
    //    public string Header { get; set; }
    //}

}
