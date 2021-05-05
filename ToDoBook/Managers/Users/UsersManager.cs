using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage;
using ToDoBook.Storage.Entity;

namespace ToDoBook.Managers.Users
{
	public class UsersManager : IUsersManager
	{
		WorkContext _context;
		public UsersManager(WorkContext context)
		{
			_context = context;
		}

		public void DelUser(int i)
		{
			var RemoveUser = _context.Users.FirstOrDefault(user => user.ID == i);
			if (RemoveUser != null)
				_context.Remove(RemoveUser);
		}

		public List<UserData> GetAll()
		{
			return _context.Users.ToList();
		}

		public UserData GetIn(int i)
		{
			return _context.Users.FirstOrDefault(user => user.ID == i);
		}
	}
}
