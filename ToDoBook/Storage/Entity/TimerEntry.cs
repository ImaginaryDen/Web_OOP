using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBook.Storage.Entity
{
    public class TimerEntry : Entry
    {
        public DateTime EndTime { get; set; }
        public TimeSpan TimeLeft { get {
                TimeSpan value = EndTime - DateTime.Now;
                if (value < TimeSpan.Zero) value = TimeSpan.Zero;
                return value;
                }
            }

        public TimerEntry()
        {
            EndTime = new DateTime();
            EndTime = DateTime.Now;
        }
    }
}
