using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBook.Storage.Entity;

namespace ToDoBook.Storage.Entity
{
	public class MitingEntry : Entry
	{
		public DateTime Time { get; set; }
		public string Place { get; set; }
	}
}
