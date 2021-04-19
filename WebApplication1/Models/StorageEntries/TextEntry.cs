using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class TextEntry
	{
		public string Text { get; set; }
		[Key]
		public int ID { get; set; }
		public int DiaryID { get; set; }
	}
}
