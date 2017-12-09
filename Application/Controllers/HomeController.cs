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

		public HomeController(SLICKIceDBContext context) {
			_context = context;
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
	}
}