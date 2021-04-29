using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage;
using ToDoBook.Storage.Entity;

namespace ToDoBook.Managers.NewsM
{
	public class NewsManager
	{
		WorkContext _context;
		public NewsManager(WorkContext context)
		{
			_context = context;
		}

		public List<News> GetNews()
		{
			return _context.NewsData.ToList();
		}
	}
}
