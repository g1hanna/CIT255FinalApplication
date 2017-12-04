using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SLICKIce.Application.Models;
using SLICKIce.Application.Data;
using SLICKIce.DAL;

namespace SLICKIce.Application.Business
{
    public class ItemBusiness : IRespository<Item>
    {
		IRespository<Item> _itemsRepo;

		public ItemBusiness(IRespository<Item> itemsRepo)
		{
			_itemsRepo = itemsRepo;
		}

		public IQueryable<Item> QueryItemsByCondition(int minCondition, int maxCondition)
		{
			var items = _itemsRepo.SelectAll().Where(i => i.ItemCondition >= minCondition && i.ItemCondition <= maxCondition);

			return items;
		}

		public IQueryable<Item> QueryItemsByType(ItemType itemType)
		{
			var items = _itemsRepo.SelectAll().Where(i => (int)i.ItemType == (int)itemType);

			return items;
		}

		public IQueryable<Item> QueryItemsByName(string itemName)
		{
			Regex r = new Regex(itemName);

			var items = _itemsRepo.SelectAll().Where(i => r.IsMatch(itemName));

			return items;
		}

		public IQueryable<Item> SortItemsById(bool ascending = true)
		{
			return OrderBy(i => i.ItemId, ascending);
		}

		public IQueryable<Item> SortItemsByCondition(bool ascending = true)
		{
			return OrderBy(i => i.ItemCondition, ascending);
		}

		private IQueryable<Item> OrderBy(Expression<Func<Item, int>> keySelector, bool ascending = true)
		{
			if (ascending) return _itemsRepo.SelectAll().OrderBy(keySelector);
			else return _itemsRepo.SelectAll().OrderByDescending(keySelector);
		}

		#region IRepository<Item> Support
		public void Delete(Item record)
		{
			((IRespository<Item>)_itemsRepo).Delete(record);
		}

		public void Dispose()
		{
			((IRespository<Item>)_itemsRepo).Dispose();
		}

		public void Insert(Item record)
		{
			((IRespository<Item>)_itemsRepo).Insert(record);
		}

		public void Save()
		{
			((IRespository<Item>)_itemsRepo).Save();
		}

		public IQueryable<Item> SelectAll()
		{
			return ((IRespository<Item>)_itemsRepo).SelectAll();
		}

		public Item SelectById(Item record)
		{
			return ((IRespository<Item>)_itemsRepo).SelectById(record);
		}

		public void Update(Item record)
		{
			((IRespository<Item>)_itemsRepo).Update(record);
		}
		#endregion

	}
}
