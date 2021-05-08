using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage;
using ToDoBook.Storage.Entity;
using ToDoBook.Managers.Profiles;
using ToDoBook.Managers.NewsM;
using ToDoBook.Storage.StorgeEntity;
using ToDoBook.Managers.DiaryM;
using ToDoBook.Managers.EntryM;
using Microsoft.AspNetCore.Authorization;

namespace ToDoBook.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		WorkContext database;

		public Profile ProfileMangare { get; private set; }

		public UserController(WorkContext context)
		{
			database = context;
		}
		[HttpGet]
		public ActionResult Index()
		{
			ProfileManager profile = new ProfileManager(database);

			ViewBag.Profile = profile.GetIn(int.Parse(User.Identity.Name));
			return View();
		}
		//
		[HttpPost]
		public ActionResult Index(Profile data)
		{
			database.Profiles.Remove(database.Profiles.Find(data.ID));
			database.Profiles.Add(data);
			database.SaveChanges();
			ViewBag.Profile = data;
			return View(data);
		}

		public ActionResult News()
		{
			NewsManager News_data = new NewsManager(database);
			return View(News_data.GetNews());
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
			DiaryManager diary = new DiaryManager(database);
			diary.AddDiary(data, int.Parse(User.Identity.Name));

			return RedirectToAction("Index");
		}

		public ActionResult RequestDiary(int? ID)
		{
			DiaryManager diary = new DiaryManager(database);
			return View(diary.GetDiaries(ID ?? int.Parse(User.Identity.Name)));
		}

		public IActionResult Show_Entry(int ID)
		{
			EntryManager entry = new EntryManager(database);
			ViewBag.ID = ID;
			return View(entry.GetEntries(ID));
		}

		[HttpGet]
		public IActionResult Edit_Text_Entry(int id, int id2)
		{
			ViewBag.ID = id2;
			ViewBag.Entries = database.TextEntries.Find(id);
			return View();
		}

		[HttpPost]
		public ActionResult Edit_Text_Entry(TextEntry data, int DiaryID)
		{
			database.TextEntries.Find(data.ID).Text = data.Text;
			database.TextEntries.Find(data.ID).Name = data.Name;
			database.TextEntries.Find(data.ID).Description = data.Description;
			database.SaveChanges();
			return RedirectToAction("Show_Entry", new { ID = DiaryID });
		}

		[HttpGet]
		public IActionResult Edit_Miting_Entry(int id, int id2)
		{
			ViewBag.ID = id2;
			ViewBag.Entries = database.MitingEntries.Find(id);
			return View();
		}

		[HttpPost]
		public ActionResult Edit_Miting_Entry(MitingEntry data, int DiaryID)
		{
			database.MitingEntries.Find(data.ID).Name = data.Name;
			database.MitingEntries.Find(data.ID).Description = data.Description;
			database.MitingEntries.Find(data.ID).Time = data.Time;
			database.SaveChanges();
			return RedirectToAction("Show_Entry", new { ID = DiaryID });
		}

		[HttpGet]
		public IActionResult Edit_Reminder_Entry(int id, int id2)
		{
			ViewBag.ID = id2;
			ViewBag.Entries = database.ReminderEntries.Find(id);
			return View();
		}

		[HttpPost]
		public ActionResult Edit_Reminder_Entry(ReminderEntry data, int DiaryID)
		{
			database.ReminderEntries.Find(data.ID).Name = data.Name;
			database.ReminderEntries.Find(data.ID).Description = data.Description;
			database.ReminderEntries.Find(data.ID).Time = data.Time;
			database.SaveChanges();
			return RedirectToAction("Show_Entry", new { ID = DiaryID });
		}
		
		[HttpGet]
		public IActionResult Edit_Timer_Entry(int id, int id2)
		{
			ViewBag.ID = id2;
			ViewBag.Entries = database.TimerEntries.Find(id);
			return View();
		}

		[HttpPost]
		public ActionResult Edit_Timer_Entry(TimerEntry data, int DiaryID)
		{
			database.TimerEntries.Find(data.ID).Name = data.Name;
			database.TimerEntries.Find(data.ID).Description = data.Description;
			database.TimerEntries.Find(data.ID).EndTime = data.EndTime;
			database.SaveChanges();
			return RedirectToAction("Show_Entry", new { ID = DiaryID });
		}

		[HttpGet]
		public IActionResult Edit_Cheklist_Entry(int id, int id2)
		{
			ViewBag.ID = id2;
			ViewBag.Entries = database.ChecklistEntries.Find(id);
			return View(ViewBag.Entries.ToList());
		}

		[HttpPost]
		public ActionResult Edit_Checklist_Entry(ChecklistEntry data, int DiaryID)
		{
			database.ChecklistEntries.Find(data.ID).Name = data.Name;
			database.ChecklistEntries.Find(data.ID).Description = data.Description;

			database.SaveChanges();
			return RedirectToAction("Show_Entry", new { ID = DiaryID });
		}

		[HttpGet]
		public ActionResult AddTextEntry(int ID)
		{
			ViewBag.ID = ID;
			return View();
		}

		[HttpPost]
		public ActionResult AddTextEntry(TextEntry data, int DiaryId)
		{
			EntryManager entry = new EntryManager(database);
			data.Type = "Edit_Text_Entry";
			data.ID = 0;
			entry.AddEntry(data, DiaryId);
			return RedirectToAction("Show_Entry", new { ID = DiaryId });
		}

		[HttpGet]
		public ActionResult AddMitingEntry(int ID)
		{
			ViewBag.ID = ID;
			return View();
		}

		[HttpPost]
		public ActionResult AddMitingEntry(MitingEntry data, int DiaryId)
		{
			EntryManager entry = new EntryManager(database);
			data.ID = 0;
			entry.AddEntry(data, DiaryId);
			return RedirectToAction("Show_Entry", new { ID = DiaryId });
		}

		[HttpGet]
		public ActionResult AddReminderEntry(int ID)
		{
			ViewBag.ID = ID;
			return View();
		}

		[HttpPost]
		public ActionResult AddReminderEntry(ReminderEntry data, int DiaryId)
		{
			EntryManager entry = new EntryManager(database);
			data.ID = 0;
			entry.AddEntry(data, DiaryId);
			return RedirectToAction("Show_Entry", new { ID = DiaryId });
		}

		[HttpGet]
		public ActionResult AddTimerEntry(int ID)
		{
			ViewBag.ID = ID;
			return View();
		}

		[HttpPost]
		public ActionResult AddTimerEntry(TimerEntry data, int DiaryId)
		{
			EntryManager entry = new EntryManager(database);
			data.ID = 0;
			entry.AddEntry(data, DiaryId);
			return RedirectToAction("Show_Entry", new { ID = DiaryId });
		}

		[HttpGet]
		public ActionResult AddChecklistEntry(int ID)
		{
			ViewBag.ID = ID;
			return View();
		}

		[HttpPost]
		public ActionResult AddChecklistEntry(ChecklistEntry data, int DiaryId)
		{
			EntryManager entry = new EntryManager(database);
			data.ID = 0;
			entry.AddEntry(data, DiaryId);
			return RedirectToAction("Show_Entry", new { ID = DiaryId });
		}
	}
}
