using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace SLICKIce.Application.Models
{
	public enum ItemShare
	{
		Owner,
		Borrower
	}
	
    /// <summary>
    /// Represents the ownership between Accounts and Items
    /// </summary>
    public partial class Inventory
    {
		public int AccountId { get; set; }
		public int ItemId { get; set; }
		public ItemShare ShareKind { get; set; }

		public Account Account { get; set; }
		public Item Item { get; set; }
	}
}
