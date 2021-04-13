using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class User_Data
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Last_Name { get; set; }
		public string mail { get; set; }
		public string password { get; set; }
		public Diary diary { get; set; }
	}
}
