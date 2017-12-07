#region Usings
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SLICKIce.Application.Models;
using SLICKIce.Application.Data;
using SLICKIce.Application.Business;
using SLICKIce.Application;
using SLICKIce.DAL;
#endregion

namespace CIT255FinalAppTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
			var host = Program.BuildWebHost(new string[0]);
			SLICKIceDBContext context = new SLICKIceDBContext(new DbContextOptions<SLICKIceDBContext>());

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				//try
				//{
				context = services.GetRequiredService<SLICKIceDBContext>();
				DbInitializer.InitializeOverwrite(context);

				WinterGearRepositoryEFC winterGearRepo = new WinterGearRepositoryEFC(context);

				var items = winterGearRepo.SelectAll().ToList();
				Assert.IsNotNull(items);

				var newItem = new Item
				{
					ItemId = 5,
					ItemName = "The Rocket",
					ItemDescription = "",
					ItemType = ItemType.Gear,
					ItemCondition = 10
				};
				winterGearRepo.Insert(newItem);

				items = winterGearRepo.SelectAll().ToList();
				Assert.AreEqual(items.SingleOrDefault(i => i.ItemId == 5), newItem);

				newItem = new Item
				{
					ItemId = 5,
					ItemName = "The Raging Rocket",
					ItemDescription = "",
					ItemType = ItemType.Gear,
					ItemCondition = 9
				};
				winterGearRepo.Update(newItem);

				items = winterGearRepo.SelectAll().ToList();
				Assert.AreEqual(items.SingleOrDefault(i => i.ItemId == 5), newItem);

				winterGearRepo.Delete(new Item { ItemId = 5 });

				items = winterGearRepo.SelectAll().ToList();
				Assert.AreNotEqual(items.SingleOrDefault(i => i.ItemId == 5), newItem);
				//}
				//catch (Exception ex)
				//{
				//	var logger = services.GetRequiredService<ILogger<Program>>();
				//	logger.LogError(ex, "An error occured while seeding the database.");
				//}
			}
		}

		[TestMethod]
		public void TestMethod2()
		{
			var host = Program.BuildWebHost(new string[0]);
			SLICKIceDBContext context = new SLICKIceDBContext(new DbContextOptions<SLICKIceDBContext>());

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				context = services.GetRequiredService<SLICKIceDBContext>();
				DbInitializer.InitializeOverwrite(context);

				var accountRepo = new AccountRepositoryEFC(context);

				var items = accountRepo.SelectAll().ToList();
				Assert.IsNotNull(items);

				var account = new Account
				{
					AccountId = 3,
					AccountUsername = "david78",
					AccountPassword = "password",
					AccountFirstName = "David",
					AccountLastName = "Humpington"
				};
				accountRepo.Insert(account);

				items = accountRepo.SelectAll().ToList();
				Assert.AreEqual(account, accountRepo.SelectById(account));

				account = new Account
				{
					AccountId = 3,
					AccountUsername = "david88",
					AccountPassword = "password2",
					AccountFirstName = "David",
					AccountLastName = "Humpington"
				};
				accountRepo.Update(account);


				items = accountRepo.SelectAll().ToList();
				Assert.AreEqual(account, accountRepo.SelectById(account));

				accountRepo.Delete(account);

				items = accountRepo.SelectAll().ToList();
				Assert.AreNotEqual(account, accountRepo.SelectById(account));

			}
		}

		[TestMethod]
		public void TestMethod3()
		{
			var host = Program.BuildWebHost(new string[0]);
			SLICKIceDBContext context = new SLICKIceDBContext(new DbContextOptions<SLICKIceDBContext>());

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				context = services.GetRequiredService<SLICKIceDBContext>();
				DbInitializer.InitializeOverwrite(context);

				var inventoryRepo = new InventoryRepositoryEFC(context);

				var items = inventoryRepo.SelectAll();
				Assert.IsTrue(items.Count() > 0);

				var inventory = new Inventory
				{
					AccountId = 2,
					ItemId = 3,
					ShareKind = ItemShare.Borrower
				};
				inventoryRepo.Insert(inventory);

				items = inventoryRepo.SelectAll();
				Assert.AreEqual(inventory, inventoryRepo.SelectById(inventory));

				inventory = new Inventory
				{
					AccountId = 2,
					ItemId = 3,
					ShareKind = ItemShare.Owner
				};
				inventoryRepo.Update(inventory);

				items = inventoryRepo.SelectAll();
				Assert.AreEqual(inventory, inventoryRepo.SelectById(inventory));

				inventoryRepo.Delete(inventory);

				items = inventoryRepo.SelectAll();
				Assert.AreNotEqual(inventory, inventoryRepo.SelectById(inventory));
			}
		}
	}

	[TestClass]
	public class BusinessTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			var host = Program.BuildWebHost(new string[0]);
			SLICKIceDBContext context = new SLICKIceDBContext(new DbContextOptions<SLICKIceDBContext>());

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				//try
				//{
				context = services.GetRequiredService<SLICKIceDBContext>();
				DbInitializer.InitializeOverwrite(context);

				WinterGearRepositoryEFC winterGearRepo = new WinterGearRepositoryEFC(context);
				ICollection<Item> gearItems;
				ICollection<Item> goodItems;

				using (ItemBusiness itemBusiness = new ItemBusiness(winterGearRepo))
				{
					gearItems = itemBusiness.QueryItemsByType(ItemType.Gear).ToList();
					goodItems = itemBusiness.QueryItemsByCondition(10, 10).ToList();
				}

				// look for test data in selections
				// gear items
				Assert.IsNotNull(gearItems.SingleOrDefault(i => i.ItemId == 4));
				Assert.IsNotNull(gearItems.SingleOrDefault(i => i.ItemId == 3));

				// good-quality items
				Assert.IsNotNull(goodItems.SingleOrDefault(i => i.ItemId == 1));
			}
		}
	}
}
