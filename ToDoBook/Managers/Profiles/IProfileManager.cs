using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage.Entity;

namespace ToDoBook.Managers.Profiles
{
	interface IProfileManager
	{
		List<Profile> GetAll();
		Profile GetIn(int i);
	}
}
