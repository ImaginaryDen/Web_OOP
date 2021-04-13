using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public static class Adm_inst
	{
		public static void Initialize(Users context)
		{
			if (!context.Users_db.Any())
			{
				context.Users_db.AddRange(
					new User_Data
					{
						Name = "Admin",
						Last_Name = "Super",
						Email = "adm@adm.ru",
						Password = "adm"
					}
				);
				
				context.SaveChanges();
			}
		}
	}
}
