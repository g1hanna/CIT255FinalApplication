using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SLICKIce.Application.Models;
using SLICKIce.Application.Data;
using System.Linq;

namespace SLICKIce.DAL
{
	/// <summary>
	/// A mechanism that manages the application's winter sports items through Entity Framework Core
	/// </summary>
	public class WinterGearRepositoryEFC : IRespository<Item>
	{
		SLICKIceDBContext _context;
		
		public WinterGearRepositoryEFC(SLICKIceDBContext context) {
			ReadFromContext(context);
		}

		public void ReadFromContext(SLICKIceDBContext context)
		{
			_context = context;
		}

		public void Delete(Item record) {
			var target = _context.Item.SingleOrDefault(i => i.ItemId == record.ItemId);

			_context.Remove(target);
			//_items.FromSql($"DELETE FROM Item WHERE ItemId = {record.ItemId};");
			Save();
		}

		public void Insert(Item record) {
			_context.Add(record);
			//_items.FromSql($"INSERT INTO Item VALUES ( {record.ItemId}, {record.ItemName}, {record.ItemDescription}, {(int)record.ItemType}, {record.ItemCondition} );");
			Save();
		}

		public void Save() {
			//_context.Item = _items;
			_context.SaveChanges();
		}

		public IQueryable<Item> SelectAll() {
			return _context.Item.FromSql("SELECT * FROM dbo.Item");
		}

		public Item SelectById(Item record) {
			return _context.Item.SingleOrDefault(i => i.ItemId == record.ItemId);
		}

		public void Update(Item record) {
			var target = _context.Item.SingleOrDefault(i => i.ItemId == record.ItemId);
			Delete(target);
			Insert(record);
			//_items.FromSql($"UPDATE Item SET "+
			//	$"ItemId = {record.ItemId}, "+
			//	$"ItemName = {record.ItemName}, "+
			//	$"ItemDescription = {record.ItemDescription}, "+
			//	$"ItemType = {record.ItemType}, "+
			//	$"ItemCondition = {record.ItemCondition} "+
			//	$"WHERE Item.ItemId = {record.ItemId};");
			//Save();
		}
		

		// recommended IDisposable logic
		#region IDisposable Support
		private bool _disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing) {
			if (!_disposedValue) {
				if (disposing) {
					// dispose managed state (managed objects).
					
				}

				// free unmanaged resources (unmanaged objects) and override a finalizer below.
				_context.Dispose();

				// set large fields to null.
				
				_disposedValue = true;
			}
		}

		// override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		~WinterGearRepositoryEFC()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(false);
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose() {
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// uncomment the following line if the finalizer is overridden above.
			GC.SuppressFinalize(this);
		}
		#endregion


	}
}