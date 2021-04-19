using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class DiaryController : Controller
	{
		WorkContext database;
		public DiaryController(WorkContext context)
		{
			database = context;
		}

		[HttpGet]
		public IActionResult ShowDiary(int ID)
		{
			return View(database.Entries.ToList().Where(ent => ent.DiaryID == ID));
		}

		[HttpGet]
		public ActionResult AddEntry()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddEntry(TextEntry data)
		{
			database.TextEntries.Add(data);
			database.SaveChanges();
			EntriesBelonging belong = new EntriesBelonging();
			List<TextEntry> entries = new List<TextEntry>();
			entries = database.TextEntries.ToList();
			belong.DiaryID = data.DiaryID;
			belong.Type = 1;
			belong.EntryID = entries.Last().ID;
			database.Entries.Add(belong);
			database.SaveChanges();
			return RedirectToAction("ShowDiary");
		}

		[HttpGet]
		public ActionResult AddTextEntry()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddTextEntry(TextEntry data)
		{
			data.Type = "Edit_Text_Entry";
			database.TextEntries.Add(data);
			database.SaveChanges();
			EntriesBelonging belong = new EntriesBelonging();
			List<TextEntry> entries = new List<TextEntry>();
			entries = database.TextEntries.ToList();
			belong.DiaryID = data.DiaryID;
			belong.Type = 1;
			belong.EntryID = entries.Last().ID;
			database.Entries.Add(belong);
			database.SaveChanges();
			return RedirectToAction("ShowDiary");
		}
	}
}
