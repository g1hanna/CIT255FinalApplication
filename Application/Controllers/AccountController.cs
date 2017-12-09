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
	public class AccountController {
		SLICKIceDBContext _context;

		public AccountController(SLICKIceDBContext context) {
			_context = context;
		}

		public IActionResult SignIn() {

		}

		public IActionResult SignOut() {

		}

		public IActionResult SignUp() {
			
		}
	}
}