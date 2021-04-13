using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public static class AdminUser
    {
        public static void Initialize(WorkContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        FirstName = "Admin",
                        LastName = "Super"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
