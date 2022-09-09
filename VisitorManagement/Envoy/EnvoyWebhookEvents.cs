namespace VisitorManagement.Envoy
{
    public static class EnvoyWebhookEvents
    {
        //(Protect) Location capacity updated
        public const string LocationCapacityUpdated = "location_capacity_updated";
        // (Visitors) Entry screened (Beta)
        public const string EntryScreened = "entry_screened";
        // (Visitors) NDA file signed
        public const string NDAFileSigned = "nda_file";
        // (Visitors) Entry sign-in
        public const string EntrySignIn = "entry_sign_in";
        // (Visitors) Entry sign-out
        public const string EntrySignOut = "entry_sign_out";




        // (Visitors) Entry block-list review
        public const string EntryBlockListReview = "entry_block_list_review";
        // (Visitors) Entry block-list denied
        public const string EntryblockListDenied = "entry_block_list_denied";
        // (Visitors) Invite created
        public const string InviteCreated = "invite_created";
        // (Visitors) Invite updated
        public const string InviteUpdated = "invite_updated";
        // (Visitors) Invite removed
        public const string InviteRemoved = "invite_removed";
        // (Visitors) Invite removed
        public const string UpcomingInvitedVisit = "upcoming_invited_visit";
        // (Visitors) Invite QR code sent
        public const string InviteQRCodeSent = "invite_qr_code_sent";
        // (Protect) Employee check-in created
        public const string EmployeeCheckInCreated = "employee_check_in_created";
        // (Protect) Employee check-in updated
        public const string EmployeeCheckInUpdated = "employee_check_in_updated";
        // (Protect) Upcoming employee on-site
        public const string UpcomingEmployeeOnSite = "upcoming_employee_on_site";
        // (Protect) Employee entry sign-in
        public const string EmployeeEntrySignIn = "employee_entry_sign_in";
        // (Protect) Employee entry sign-out
        public const string EmployeeEntrySignOut = "employee_entry_sign_out";

        //(Protect) Ticket created - Beta
        public const string TicketCreated = "ticket_created";
        // (Desks) Sign-in - Beta
        public const string SignIn = "sign_in";
    }
}