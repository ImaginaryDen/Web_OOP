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
		public string Email { get; set; }
		public string Password { get; set; }
		public Diary Diary_data { get; set; }
	}
}
