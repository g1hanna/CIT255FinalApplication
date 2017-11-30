using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SLICKIce.Application.Models;
using SLICKIce.DAL;

namespace SLICKIce.DAL
{
	public class WinterGearRepositorySQL : IWinterGearRepository, IDisposable
	{
		DataSet _records;
		DataTable _recordsTable;

		public WinterGearRepositorySQL() {
			_records = new DataSet();
			_recordsTable = new DataTable();

			_records.DataSetName = "WinterGear_ds";
            _recordsTable = _records.Tables[0];
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Insert(Item record) {
			Insert(record, true);
		}

		public void Insert(Item record, bool checkId = true) {
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}

		public List<Item> SelectAll()
		{
			throw new NotImplementedException();
		}

		public Item SelectById(int id)
		{
			throw new NotImplementedException();	
		}

		public void Update(Item record)
		{
			throw new NotImplementedException();
		}

		private void reorder() {
			throw new NotImplementedException();
		}

		// recommended IDisposable logic
		#region IDisposable Support
		private bool _disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					// dispose managed state (managed objects).
				}

				// free unmanaged resources (unmanaged objects) and override a finalizer below.

				// set large fields to null.
				_records = null;

				_disposedValue = true;
			}
		}

		// override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~WinterGearRepositorySQL() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion


	}
}