using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Users : DbContext
    {
        public DbSet<User_Data> Users_db { get; set; }

        public Users(DbContextOptions<Users> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
