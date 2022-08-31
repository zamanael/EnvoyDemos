using System;
using System.Collections.Generic;

namespace VisitorManagement
{
    public class Account
    {
        public string Email { get; internal set; }
        public bool Active { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public List<string> Roles { get; internal set; }
    }
}