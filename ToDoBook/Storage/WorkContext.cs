using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoBook.Storage.Entity;
using ToDoBook.Storage.StorgeEntity;

namespace ToDoBook.Storage
{
    public class WorkContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Diary> Diaries { get; set; }
        public DbSet<Belonging> Belongings { get; set; }
        public DbSet<EntriesBelonging> Entries { get; set; }
        public DbSet<TextEntry> TextEntries { get; set; }
        public DbSet<MitingEntry> MitingEntries { get; set; }
        public DbSet<ReminderEntry> ReminderEntries { get; set; }
        public DbSet<TimerEntry> TimerEntries { get; set; }
        public DbSet<ChecklistEntry> ChecklistEntries { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<News> NewsData { get; set; }

        public WorkContext(DbContextOptions<WorkContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
