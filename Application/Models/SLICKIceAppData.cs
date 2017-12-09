using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SLICKIce.Application.Data;
using SLICKIce.Application.Models;
using SLICKIce.DAL;

namespace SLICKIce.Application.Models {
	public class SLICKIceAppData {
		private Account _currentUser;

		public string UserName => _currentUser.AccountUsername;
		public string FirstName => _currentUser.AccountFirstName;
		public string LastName => _currentUser.AccountLastName;
		internal int UserId => _currentUser.AccountId;

		// hide the constructor
		private SLICKIceAppData(Account account) {
			_currentUser = account;
		}


	}
}