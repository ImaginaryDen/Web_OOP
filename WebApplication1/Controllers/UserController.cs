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

	   
		public IActionResult Show_Entry(int ID)
		{
			List<Entry> entry = new List<Entry>();

			foreach (var item in database.Entries.ToList().Where(x => x.DiaryID == ID))
			{
				switch (item.Type)
				{
					case 1:
						entry.Add(database.TextEntries.Find(item.EntryID));
						break;
					default:
						break;
				}
			}

			return View(entry);
		}
		[HttpGet]
		public IActionResult Edit_Text_Entry(int ID)
		{
			ViewBag.ID = database.TextEntries.Find(ID).ID;
			ViewBag.Name = database.TextEntries.Find(ID).Name;
			ViewBag.Text = database.TextEntries.Find(ID).Text;
			ViewBag.Description = database.TextEntries.Find(ID).Description;
			return View();
		}

		[HttpPost]
		public ActionResult Edit_Text_Entry(TextEntry data)
		{
			database.TextEntries.Find(data.ID).Text = data.Text;
			database.TextEntries.Find(data.ID).Name = data.Name;
			database.TextEntries.Find(data.ID).Description = data.Description;
			database.SaveChanges();
			return RedirectToAction("Show_Entry", new { ID = database.TextEntries.Find(data.ID).DiaryID.ToString() });
		}
	}
}
