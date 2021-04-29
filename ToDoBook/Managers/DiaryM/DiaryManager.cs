using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage;
using ToDoBook.Storage.Entity;
using ToDoBook.Storage.StorgeEntity;

namespace ToDoBook.Managers.DiaryM
{
	public class DiaryManager
	{
		WorkContext _context;

		public DiaryManager(WorkContext context)
		{
			_context = context;
		}

		public void AddDiary(Diary NewDiary, int Userid)
		{
			_context.Diaries.Add(NewDiary);
			_context.SaveChanges();
			_context.Belongings.Add(new Belonging { UserID = Userid, DiaryID = _context.Diaries.ToList().Last().ID });
			_context.SaveChanges();
		}

		public List<Diary> GetDiaries(int id)
		{
			List<Diary> diaries = new List<Diary>();

			foreach (var item in _context.Belongings.ToList().Where(x => x.UserID == id))
			{
				diaries.Add(_context.Diaries.Find(item.DiaryID));
			}
			return diaries;
		}

		public WorkContext GetContext() => _context;
	}
}
