﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBook.Storage.Entity
{
    public class TimerEntry : Entry
    {
        public DateTime EndTime { get; set; }
        public TimeSpan TimeLeft { get => EndTime - DateTime.Now; }

        public TimerEntry()
        {
            EndTime = new DateTime();
        }
    }
}
