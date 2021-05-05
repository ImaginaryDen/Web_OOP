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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ToDoBook.Managers.ImageM;

namespace ToDoBook.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		WorkContext _context;

		public UserController(WorkContext context, IWebHostEnvironment appEnvironment)
		{
			_context = context;
		}
		[HttpGet]
		public ActionResult Index()
		{
			ProfileManager profileManager = new ProfileManager(_context);
			Profile prifile = profileManager.GetIn(int.Parse(User.Identity.Name));
			ViewBag.Profile = prifile;
			if (prifile.ImageId != 0)
				ViewBag.Avatar = _context.Images.FirstOrDefault(imeg => imeg.ID == prifile.ImageId).Image;
			return View();
		}
		//
		[HttpPost]
		public ActionResult Index(Profile data, IFormFile Avatar)
		{
			if(Avatar != null)
			{
				ImageManager AddImage = new ImageManager(_context);
				AddImage.AddAvatar(Avatar, int.Parse(User.Identity.Name));
				data.ImageId = _context.Profiles.Find(data.ID).ImageId;
				ViewBag.Avatar = _context.Images.FirstOrDefault(imeg => imeg.ID == data.ImageId).Image;
			}
			_context.Profiles.Remove(_context.Profiles.Find(data.ID));
			_context.Profiles.Add(data);
			_context.SaveChanges();
			ViewBag.Profile = data;
			return View(data);
		}

		public ActionResult News()
		{
			NewsManager News_data = new NewsManager(_context);
			return View(News_data.GetNews());
		}

		[HttpGet]
		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(UserData data)
		{
			_context.Users.Add(data);
			_context.SaveChanges();
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
			DiaryManager diary = new DiaryManager(_context);
			diary.AddDiary(data, int.Parse(User.Identity.Name));

			return RedirectToAction("Index");
		}

		public ActionResult RequestDiary(int? ID)
		{
			DiaryManager diary = new DiaryManager(_context);
			return View(diary.GetDiaries(ID ?? int.Parse(User.Identity.Name)));
		}

		public IActionResult Show_Entry(int ID)
		{
			EntryManager entry = new EntryManager(_context);
			ViewBag.ID = ID;
			return View(entry.GetEntries(ID));
		}

		[HttpGet]
		public IActionResult Edit_Text_Entry(int id, int id2)
		{
			ViewBag.ID = id2;
			ViewBag.Entries = _context.TextEntries.Find(id);
			return View();
		}

		[HttpPost]
		public ActionResult Edit_Text_Entry(TextEntry data, int DiaryID)
		{
			_context.TextEntries.Find(data.ID).Text = data.Text;
			_context.TextEntries.Find(data.ID).Name = data.Name;
			_context.TextEntries.Find(data.ID).Description = data.Description;
			_context.SaveChanges();
			return RedirectToAction("Show_Entry", new { ID = DiaryID });
		}

		[HttpGet]
		public IActionResult Edit_Miting_Entry(int id, int id2)
		{
			ViewBag.ID = id2;
			ViewBag.Entries = _context.MitingEntries.Find(id);
			return View();
		}

		[HttpPost]
		public ActionResult Edit_Miting_Entry(MitingEntry data, int DiaryID)
		{
			_context.MitingEntries.Find(data.ID).Name = data.Name;
			_context.MitingEntries.Find(data.ID).Description = data.Description;
			_context.MitingEntries.Find(data.ID).Time = data.Time;
			_context.SaveChanges();
			return RedirectToAction("Show_Entry", new { ID = DiaryID });
		}

		[HttpGet]
		public IActionResult Edit_Image_Entry(int id, int id2)
		{
			ImageEntry imageEntry = _context.Images.Find(id);
			ViewBag.ID = id2;
			ViewBag.Entries = imageEntry;
			if (imageEntry.Image != null)
				ViewBag.Image = imageEntry.Image;
			return View();
		}

		[HttpPost]
		public ActionResult Edit_Image_Entry(TextEntry data, int DiaryID, IFormFile pvm)
		{
			_context.Images.Find(data.ID).Name = data.Name;
			_context.Images.Find(data.ID).Description = data.Description;
			if (pvm != null)
			{
				byte[] imageData = null;
				using (var binaryReader = new BinaryReader(pvm.OpenReadStream()))
				{
					imageData = binaryReader.ReadBytes((int)pvm.Length);
				}
				_context.Images.Find(data.ID).Image = imageData;
			}
			_context.SaveChanges();
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
			EntryManager entry = new EntryManager(_context);
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
			EntryManager entry = new EntryManager(_context);
			data.ID = 0;
			entry.AddEntry(data, DiaryId);
			return RedirectToAction("Show_Entry", new { ID = DiaryId });
		}

		public ActionResult AddImageEntry(int ID)
		{
			ViewBag.ID = ID;
			return View();
		}

		[HttpPost]
		public ActionResult AddImageEntry(ImageEntry data, int DiaryId)
		{
			EntryManager entry = new EntryManager(_context);
			data.Type = "Edit_Image_Entry";
			data.ID = 0;
			entry.AddEntry(data, DiaryId);
			return RedirectToAction("Show_Entry", new { ID = DiaryId });
		}

	}
}
