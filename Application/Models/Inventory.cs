using System;
using System.Collections.Generic;

namespace SLICKIce.Application.Models
{
    /// <summary>
    /// Represents the ownership between 
    /// </summary>
    public partial class Inventory
    {
        public int AccountId { get; set; }
        public int ItemId { get; set; }
    }
}
