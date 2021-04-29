using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBook.Storage.Entity
{
	public class TextEntry : Entry
	{
		public string Text { get; set; }
	}
}
