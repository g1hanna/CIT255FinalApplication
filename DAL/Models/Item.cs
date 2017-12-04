using System;
using System.Collections.Generic;

namespace SLICKIce.Application.Models
{
	public enum ItemType
	{
		Snowboard,
		Ski,
		Gear
	}

    public partial class Item
    {
		public Item()
		{
			Inventory = new HashSet<Inventory>();
		}

		public int ItemId { get; set; }
		public string ItemName { get; set; }
		public string ItemDescription { get; set; }
		public ItemType ItemType { get; set; }
		public short ItemCondition { get; set; }

		public ICollection<Inventory> Inventory { get; set; }
	}
}
