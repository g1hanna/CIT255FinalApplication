using System;
using System.Collections.Generic;
using System.Text;
using SLICKIce.Application.Models;
using SLICKIce.DAL;

namespace SLICKIce.DAL
{
	public class RepositoryException<T> : Exception {
		T _failedRecord;

		public T FailedRecord => _failedRecord;

		public RepositoryException(string message) : base(message) {

		}

		public RepositoryException(T failedRecord, string message) : base(message) {
			_failedRecord = failedRecord;
		}
	}

	public class RepositoryException : RepositoryException<object> {
		public RepositoryException(string message) : base(message) {}

		public RepositoryException(object failedObject, string message) : base(failedObject, message) {}
	}
}