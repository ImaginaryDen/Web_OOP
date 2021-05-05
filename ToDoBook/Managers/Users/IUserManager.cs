using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage.Entity;

namespace ToDoBook.Managers.Users
{
	interface IUsersManager
	{
		List<UserData> GetAll();
		UserData GetIn(int i);
		void DelUser(int i);
	}
}
