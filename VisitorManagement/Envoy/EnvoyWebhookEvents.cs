namespace VisitorManagement.Envoy
{
    public static class EnvoyWebhookEvents
    {
        public const string EntrySignIn = "entry_sign_in";
        public const string EntrySignOut = "entry_sign_out";
        public const string EntryBlockListReview = "entry_block_list_review";
        public const string EntryblockListDenied = "entry_block_list_denied";
        public const string Invitecreated = "invite_created";
        public const string InviteUpdated = "invite_updated";
        public const string InviteRemoved = "invite_removed";
        public const string UpcomingInvitedVisit = "upcoming_invited_visit";
        public const string InviteQRCodeSent = "invite_qr_code_sent";
        public const string EmployeeCheckInCreated = "employee_check_in_created";
        public const string EmployeeCheckInUpdated = "employee_check_in_updated";
        public const string UpcomingEmployeeOnSite = "upcoming_employee_on_site";
        public const string EmployeeEntrySignIn = "employee_entry_sign_in";
        public const string EmployeeEntrySignOut = "employee_entry_sign_out";
        public const string LocationCapacityUpdated = "location_capacity_updated";
        public const string TicketCreated = "ticket_created";
        public const string SignIn = "sign_in";
    }
}