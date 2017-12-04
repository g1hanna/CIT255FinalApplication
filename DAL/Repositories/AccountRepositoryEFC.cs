using System;
using System.Collections.Generic;
using System.Text;
using SLICKIce.Application.Models;
using SLICKIce.Application.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SLICKIce.DAL
{
	public class AccountRepositoryEFC : IRespository<Account>
	{
		SLICKIceDBContext _context;

		public AccountRepositoryEFC(SLICKIceDBContext context)
		{
			ReadFromContext(context);
		}

		public void ReadFromContext(SLICKIceDBContext context)
		{
			_context = context;
		}

		public void Delete(Account record)
		{
			var target = _context.Account.SingleOrDefault(a => a.AccountId == record.AccountId);

			_context.Remove(target);
			//_accounts.FromSql($"DELETE FROM Account WHERE AccountId = {record.AccountId};");
			Save();
		}

		public void Insert(Account record)
		{
			_context.Add(record);
			//_accounts.FromSql($"INSERT INTO Account VALUES ( {record.AccountId}, {record.AccountUsername}, {record.AccountPassword}, {record.AccountFirstName}, {record.AccountLastName} )");
			Save();
		}

		public void Save()
		{
			//_context.Account = _accounts;
			_context.SaveChanges();
		}

		public IQueryable<Account> SelectAll()
		{
			return _context.Account.FromSql("SELECT * FROM Account");
		}

		public Account SelectById(Account record)
		{
			return _context.Account.SingleOrDefault(a => a.AccountId == record.AccountId);
		}

		public void Update(Account record)
		{
			var target = _context.Account.SingleOrDefault(a => a.AccountId == record.AccountId);
			Delete(target);
			Insert(record);
			//_accounts.FromSql("UPDATE Account SET "+
				//$"AccountId = {record.AccountId}, "+
				//$"AccountUsername = {record.AccountUsername}, "+
				//$"AccountPassword = {record.AccountPassword}, "+
				//$"AccountFirstName = {record.AccountFirstName}, "+
				//$"AccountLastName = {record.AccountLastName} "+
				//$"WHERE AccountId = {record.AccountId};");
			Save();
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
		// ~AccountRepository() {
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
