using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SLICKIce.Application.Models;

namespace SLICKIce.Application.Data
{
    public static class DbInitializer
    {
		public static async void InitializeAsync(SLICKIceDBContext context)
		{
			context.Database.EnsureCreated();

			// look for any users
			bool anyAccounts = await context.Account.AnyAsync();
			
			// add some if none available
			if (!anyAccounts)
			{
				// add test accounts
				Account[] accounts = generateTestAccounts();

				foreach (Account a in accounts)
				{
					context.Add(a);
				}

				context.SaveChanges();

				// add test items
				Item[] items = generateTestItems();

				foreach (Item i in items)
				{
					context.Add(i);
				}

				context.SaveChanges();

				// add test inventory
				Inventory[] inventory = generateTestInventory();

				foreach (Inventory i in inventory)
				{
					context.Add(i);
				}

				context.SaveChanges();
			}

		}

		public static void InitializeOverwriteAsync(SLICKIceDBContext context)
		{
			context.Database.EnsureDeleted();
			context.Database.EnsureCreated();

			// add test accounts
			Account[] accounts = generateTestAccounts();

			foreach (Account a in accounts)
			{
				context.Add(a);
			}

			context.SaveChanges();

			// add test items
			Item[] items = generateTestItems();

			foreach (Item i in items)
			{
				context.Add(i);
			}

			context.SaveChanges();

			// add test inventory
			Inventory[] inventory = generateTestInventory();

			foreach (Inventory i in inventory)
			{
				context.Add(i);
			}

			context.SaveChanges();

		}

		private static Account[] generateTestAccounts()
		{
			return new Account[]
			{
				new Account {
					AccountId = 1,
					AccountFirstName = "Greg",
					AccountLastName = "Tomson",
					AccountUsername = "greg1Tomson",
					AccountPassword = "chubbybunny"
				},
				new Account
				{
					AccountId = 2,
					AccountFirstName = "Mary",
					AccountLastName = "Watson",
					AccountUsername = "maryw@tson",
					AccountPassword = "GiveItAway"
				}
			};
		}

		private static Item[] generateTestItems()
		{
			return new Item[]
			{
				new Item {
					ItemId = 1,
					ItemName = "Snow Shredder",
					ItemType = ItemType.Snowboard,
					ItemCondition = 10,
					ItemDescription = "A super sleek and thin snowboard. Perfect for racing through deep snow."
				},
				new Item {
					ItemId = 2,
					ItemName = "The Twin Torpedoes",
					ItemType = ItemType.Ski,
					ItemCondition = 9,
					ItemDescription = "Skis with fins at the top. Slight scratching damage."
				},
				new Item
				{
					ItemId = 3,
					ItemName = "The Marshmellow",
					ItemType = ItemType.Gear,
					ItemCondition = 8,
					ItemDescription = "A very poofy white winter coat with white snow pants. Size: Large."
				},
				new Item
				{
					ItemId = 4,
					ItemName = "The Rogue Boarder",
					ItemType = ItemType.Gear,
					ItemCondition = 10,
					ItemDescription = "Black snowboarding/skiing outfit. Complete with pants, snow-proof jacket, and boots."
				}
			};
		}

		private static Inventory[] generateTestInventory()
		{
			return new Inventory[] {
				new Inventory
				{
					AccountId = 1,
					ItemId = 1,
					ShareKind = ItemShare.Owner
				},
				new Inventory
				{
					AccountId = 2,
					ItemId = 2,
					ShareKind = ItemShare.Owner
				},
				new Inventory
				{
					AccountId = 1,
					ItemId = 3,
					ShareKind = ItemShare.Owner
				},
				new Inventory
				{
					AccountId = 2,
					ItemId = 4,
					ShareKind = ItemShare.Owner
				},
				new Inventory
				{
					AccountId = 1,
					ItemId = 4,
					ShareKind = ItemShare.Borrower
				}
			};
		}
    }
}
