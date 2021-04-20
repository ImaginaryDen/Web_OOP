﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models
{
    public class WorkContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Belonging> Belongings { get; set; }
        public DbSet<EntriesBelonging> Entries { get; set; }
        public DbSet<TextEntry> TextEntries { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<News> NewsData { get; set; }

        public WorkContext(DbContextOptions<WorkContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
