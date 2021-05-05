using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBook.Storage.Entity
{
	public class ImageEntry : Entry
	{
		public byte[] Image { get; set; }
	}
}
