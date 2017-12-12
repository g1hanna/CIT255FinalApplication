using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

		[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ItemId { get; set; }

		[StringLength(60, MinimumLength = 3)]
		[Required]
		public string ItemName { get; set; }

		[StringLength(255)]
		public string ItemDescription { get; set; }

		[EnumDataType(typeof(ItemType))]
		[Required]
		public ItemType ItemType { get; set; }

		[Range(0, 10)]
		[Required]
		public short ItemCondition { get; set; }

		public ICollection<Inventory> Inventory { get; set; }
	}
}
