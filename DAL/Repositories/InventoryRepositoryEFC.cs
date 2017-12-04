using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SLICKIce.Application.Models;
using SLICKIce.Application.Data;
using System.Linq;

namespace SLICKIce.DAL
{
    public class InventoryRepositoryEFC : IRespository<Inventory>
    {
		SLICKIceDBContext _context;

		public InventoryRepositoryEFC(SLICKIceDBContext context)
		{
			ReadFromContext(context);
		}

		public void Delete(Inventory record)
		{
			var target = _context.Inventory.SingleOrDefault(i => i.AccountId == record.AccountId && i.ItemId == record.ItemId);

			_context.Remove(target);
			//_inventories.FromSql($"DELETE FROM Inventory WHERE AccountId = {record.AccountId}, ItemId = {record.ItemId};");
			Save();
		}

		public void Insert(Inventory record)
		{
			_context.Add(record);
			//_inventories.FromSql($"INSERT INTO Inventory VALUES ( {record.AccountId}, {record.ItemId}, {record.ShareKind} );");
			Save();
		}

		public void ReadFromContext(SLICKIceDBContext context)
		{
			_context = context;
		}

		public void Save()
		{
			//_context.Inventory = _inventories;
			_context.SaveChanges();
		}

		public IQueryable<Inventory> SelectAll()
		{
			return _context.Inventory.FromSql($"SELECT * FROM Inventory");
		}

		public Inventory SelectById(Inventory record)
		{
			return _context.Inventory.SingleOrDefault(i => i.AccountId == record.AccountId && i.ItemId == record.ItemId);
		}

		public void Update(Inventory record)
		{
			var target = _context.Inventory.SingleOrDefault(i => i.AccountId == record.AccountId && i.ItemId == record.ItemId);
			Delete(target);
			Insert(record);
			//_inventories.FromSql("UPDATE Inventory SET "+
			//	$"AccountId = {record.AccountId}, "+
			//	$"ItemId = {record.ItemId}, "+
			//	$"ShareKind = {(int)record.ShareKind} "+
			//	$"WHERE AccountId = {record.AccountId} AND ItemId = {record.ItemId};");
			//Save();
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
					
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				_context.Dispose();

				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~InventoryRepositoryEFC() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
