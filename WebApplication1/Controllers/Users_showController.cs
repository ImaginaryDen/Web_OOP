using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class Users_showController : Controller
	{
		Users db;

		public Users_showController(Users context)
        {
			db = context;
        }

		// GET: Users_showController
		public ActionResult Index()
		{
			return View(db.Users_db.ToList());
		}

		[HttpGet]
		public ActionResult Del(int? id)
		{
			if(id == null) return RedirectToAction("Index");

			db.Users_db.Remove(db.Users_db.FirstOrDefault(users => users.Id == id.Value));
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(User_Data data)
		{
			db.Users_db.Add(data);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
