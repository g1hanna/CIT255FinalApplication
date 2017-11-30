using System;
using System.Collections.Generic;

namespace SLICKIce.Application.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemType { get; set; }
        public short? ItemCondition { get; set; }
        public bool? ItemAvailable { get; set; }
    }
}
