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
	public class HomeController : Controller {
		private readonly SLICKIceDBContext _context;
		private Account _currentUser;

		public HomeController(SLICKIceDBContext context) {
			_context = context;
			_currentUser = null;
		}
		
		// GET: /Home/
		public IActionResult Index()
		{
			return View();
		}

		// GET: /Home/Welcome
		public IActionResult Welcome(string name, int ID = 1)
		{
			ViewData["Name"] = name;
			ViewData["Id"] = ID;

			return View();
		}

		public IActionResult Login() {
			return View();
		}

		public IActionResult Login(string userName, string password) {
			bool success = login(userName, password);

			if (success) {
				ViewResult r = new ViewResult();
				
			}
		}

		private bool login(string userName, string password) {
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

						_currentUser = target;
					}
				}
			}

			// return status
			return loginSuccess;
		}
	}
}