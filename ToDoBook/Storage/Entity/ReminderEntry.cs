using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBook.Storage.Entity
{
    public class ReminderEntry: Entry
    {
        public DateTime Time { get; set; }
        public string Email { get; set; }
    }
}
