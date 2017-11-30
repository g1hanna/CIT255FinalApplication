using System;
using System.Collections.Generic;

namespace SLICKIce.Application.Models
{
    /// <summary>
    /// Represents a user's SLICK Ice account
    /// </summary>
    public partial class Account
    {
        public int AccountId { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        public string AccountFirstName { get; set; }
        public string AccountLastName { get; set; }
    }
}
