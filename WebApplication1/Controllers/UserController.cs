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

        [HttpGet]
        public ActionResult AddDiary()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDiary(Diary data)
        {
            database.Diaries.Add(data);
            database.SaveChanges();
            Belonging belong = new Belonging();
            List<Diary> diaries = new List<Diary>();
            diaries = database.Diaries.ToList();
            belong.DiaryID = diaries.Last().ID;
            belong.UserID = 1;
            database.Belongings.Add(belong);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RequestDiary(int? ID)
        {
            if (ID == null) return RedirectToAction("Index");
            List<Diary> diaries = new List<Diary>();
            foreach(var item in database.Belongings.ToList().Where(x=> x.UserID == 1))
            {
                diaries.Add(database.Diaries.Find(item.DiaryID));
            }
            return View(diaries);
        }
    }
}
