using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Diary : DbContext
	{
		public DbSet<entry> Users_db { get; set; }

		public Diary(DbContextOptions<Diary> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
