using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using SLICKIce.Application.Data;
using SLICKIce.Application.Models;
using SLICKIce.DAL;

namespace SLICKIce.Application.Controllers {
	public class AccountController : Controller {
		SLICKIceDBContext _context;

		public AccountController(SLICKIceDBContext context) {
			_context = context;
		}

		public IActionResult SignIn() {
			return View();
		}

		public IActionResult SignOut() {
			return View();
		}

		public IActionResult SignUp() {
			return View();
		}

		private bool signin(string userName, string password) {
			// load accounts data
			var accountsRepo = new AccountRepositoryEFC(_context) as IRespository<Account>;
			var accounts = accountsRepo.SelectAll() as IEnumerable<Account>;
			bool loginSuccess = false;

			// get all accounts
			if (accounts.Count() > 0) {
				var targets = from a in accountsRepo.SelectAll() as IEnumerable<Account>
					where a.AccountUsername == userName select a;

				// get first matching
				if (targets.Count() > 0) {
					var target = targets.First();

					// find first password
					if (target.AccountPassword == password) {
						loginSuccess = true;
					}
				}
			}

			// return status
			return loginSuccess;
		}
	}
}