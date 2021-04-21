using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public ActionResult Index()
        {
            return View(database.Users.ToList());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
            try
            {
                belong.UserID = int.Parse(User.Identity.Name);
            }
            catch
			{
                belong.UserID = database.Users.FirstOrDefault(us => us.Email == User.Identity.Name).ID;
            }
            database.Belongings.Add(belong);
            database.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult RequestDiary(int? ID)
        {
            List<Diary> diaries = new List<Diary>();
            try
            {
                foreach (var item in database.Belongings.ToList().Where(x => x.UserID == (ID ?? int.Parse(User.Identity.Name))))
                {
                    diaries.Add(database.Diaries.Find(item.DiaryID));
                }
            }
            catch
			{
                foreach (var item in database.Belongings.ToList().Where(x => x.UserID == (ID ?? database.Users.FirstOrDefault(us => us.Email == User.Identity.Name).ID)))
                {
                    diaries.Add(database.Diaries.Find(item.DiaryID));
                }
            }
            return View(diaries);
        }
    }
}
