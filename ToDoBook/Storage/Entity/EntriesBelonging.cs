using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBook.Storage.Entity
{
    public class EntriesBelonging
    {
        [Key]
        public int BelongingID { get; set; }
        public int DiaryID { get; set; }
        public int Type { get; set; }
        public int EntryID { get; set; }
    }
}
