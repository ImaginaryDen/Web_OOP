using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class UserController : Controller
    {
        WorkContext database;
        public UserController(WorkContext context)
        {
            database = context;
        }

        public ActionResult Index()
        {
            return View(database.Users.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User data)
        {
            database.Users.Add(data);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
